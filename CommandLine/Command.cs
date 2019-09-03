using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace Cmd
{
    public partial class Command : UserControl
    {
        public Int32 baseCmdLineHigh = 26; // 单命令行高度
        public Int16 CmdLineMinNum = 20;   // 最小命令行行数
        public Int16 CmdLineMaxNum = 50;
        public CommandLine[] cmdline = new CommandLine[50];
        public byte[] EncodeArray = new byte[101];
        public Int16 EncodeArrayLen = 0;

        private Int32 CurrentCmdLineHighCnt = 0;//当前命令行总高度


        public Command(string json_str)
        {
            Int16 i = 0;
            //CommandLine[] cmdline;// = new CommandLine[50];
            
            InitializeComponent();

            Root rt = JsonConvert.DeserializeObject<Root>(json_str);

            for (i = 0; i < CmdLineMaxNum; i++)
            {
                cmdline[i] = new CommandLine();
            }

            for (i = 0; i < rt.Line.Count; i++)
            {
                //CommandLine cmdline = new CommandLine();
                cmdline[i].Location = new Point(0, baseCmdLineHigh * i);
                CurrentCmdLineHighCnt = baseCmdLineHigh * i;
                this.Controls.Add(cmdline[i]);
                cmdline[i].Load(rt.Line[i]);
            }

            for (; i < CmdLineMinNum; i++)
            {
                //CommandLine cmdline = new CommandLine();
                LineItem line_item = new LineItem();

                CurrentCmdLineHighCnt = baseCmdLineHigh * i;
                cmdline[i].Location = new Point(0, CurrentCmdLineHighCnt);
                this.Controls.Add(cmdline[i]);
                cmdline[i].Init(line_item);
                cmdline[i].Load(line_item);
            }            
        }

        public void Encode(object sender, EventArgs e)
        {
            Int16 cnt = 0;
            Int16 arr_cnt = 0;
            byte[] crc = new byte[2];

            EncodeArray[0] = 0xA5;
            arr_cnt += 1;

            if (rbWriteReg.Checked == true)
            {
                Int16 i = 0;

                for (i = 0; i < CmdLineMaxNum; i++)
                {
                    cmdline[i].Encode(0, e);
                    if ((cmdline[i].SelectValid == true)
                        && (cmdline[i].WriteRegValid == true))
                    {
                        EncodeArray[2 + 6 * cnt] = cmdline[i].WriteRegEncodeArray[0];
                        EncodeArray[3 + 6 * cnt] = cmdline[i].WriteRegEncodeArray[1];
                        EncodeArray[4 + 6 * cnt] = cmdline[i].WriteRegEncodeArray[2];
                        EncodeArray[5 + 6 * cnt] = cmdline[i].WriteRegEncodeArray[3];
                        EncodeArray[6 + 6 * cnt] = cmdline[i].WriteRegEncodeArray[4];
                        EncodeArray[7 + 6 * cnt] = cmdline[i].WriteRegEncodeArray[5];

                        arr_cnt += 6;
                        cnt += 1;
                        if (cnt >= 16)
                        {
                            break;
                        }
                    }
                }
            }
            else if (rbReadReg.Checked == true)
            {
                Int16 i = 0;

                for (i = 0; i < CmdLineMaxNum; i++)
                {
                    cmdline[i].Encode(0, e);
                    if ((cmdline[i].SelectValid == true)
                        && (cmdline[i].ReadRegValid == true))
                    {
                        EncodeArray[2 + 2 * cnt] = cmdline[i].ReadRegEncodeArray[0];
                        EncodeArray[3 + 2 * cnt] = cmdline[i].ReadRegEncodeArray[1];

                        arr_cnt += 2;
                        cnt += 1;
                        if (cnt >= 16)
                        {
                            break;
                        }
                    }
                }
            }

            if (cnt == 0)
            {
                return;
            }

            EncodeArray[1] = (byte)(cnt - 1);
            if (cbResp.Checked == true)
            {
                EncodeArray[1] |= 0x80;
            }
            arr_cnt += 1;

            crc = ToModbus(EncodeArray, arr_cnt - 1, 1);
            EncodeArray[arr_cnt] = crc[0];
            EncodeArray[arr_cnt+1] = crc[1];
            EncodeArray[arr_cnt + 2] = 0xC3;
            arr_cnt += 3;
            EncodeArrayLen = arr_cnt;

            tbSend.Text = ByteArrayToHexString(EncodeArray, (UInt16)arr_cnt);

        }

        /// <summary> Convert a string of hex digits (ex: E4 CA B2) to a byte array. </summary>
        /// <param name="s"> The string containing the hex digits (with or without spaces). </param>
        /// <returns> Returns an array of bytes. </returns>
        public byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
            {
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            }

            return buffer;
        }

        /// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
        /// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
        /// <returns> Returns a well formatted string of hex digits with spacing. </returns>
        public string ByteArrayToHexString(byte[] data, UInt16 len)
        {
            StringBuilder sb = new StringBuilder(len * 3);
            UInt16 i = 0;
            byte b;

            for (i = 0; i < len; i++)
            {
                b = data[i];
                //foreach (byte b in data)
                {
                    sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
                }
            }

            return sb.ToString().ToUpper();
        }

        /// <summary>
        /// CRC16_Modbus效验
        /// </summary>
        /// <param name="byteData">要进行计算的字节数组</param>
        /// <returns>计算后的数组</returns>
        public static byte[] ToModbus(byte[] byteData)
        {
            byte[] CRC = new byte[2];

            UInt16 wCrc = 0xFFFF;
            for (int i = 0; i < byteData.Length; i++)
            {
                wCrc ^= Convert.ToUInt16(byteData[i]);
                for (int j = 0; j < 8; j++)
                {
                    if ((wCrc & 0x0001) == 1)
                    {
                        wCrc >>= 1;
                        wCrc ^= 0xA001;//异或多项式
                    }
                    else
                    {
                        wCrc >>= 1;
                    }
                }
            }

            CRC[1] = (byte)((wCrc & 0xFF00) >> 8);//高位在后
            CRC[0] = (byte)(wCrc & 0x00FF);       //低位在前
            return CRC;

        }


        /// <summary>
        /// CRC16_Modbus效验
        /// </summary>
        /// <param name="byteData">要进行计算的字节数组</param>
        /// <param name="byteLength">长度</param>
        /// <returns>计算后的数组</returns>
        public static byte[] ToModbus(byte[] byteData, int byteLength, int offset = 0)
        {
            byte[] CRC = new byte[2];

            UInt16 wCrc = 0xFFFF;
            for (int i = 0; i < byteLength; i++)
            {
                wCrc ^= Convert.ToUInt16(byteData[i+offset]);
                for (int j = 0; j < 8; j++)
                {
                    if ((wCrc & 0x0001) == 1)
                    {
                        wCrc >>= 1;
                        wCrc ^= 0xA001;//异或多项式
                    }
                    else
                    {
                        wCrc >>= 1;
                    }
                }
            }

            CRC[1] = (byte)((wCrc & 0xFF00) >> 8);//高位在后
            CRC[0] = (byte)(wCrc & 0x00FF);       //低位在前
            return CRC;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Encode(sender, e);
        }
    }
}
