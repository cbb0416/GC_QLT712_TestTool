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

namespace SXWUartProtocol
{
    public partial class CommandList : UserControl
    {
        public Int16 CmdLineMinNum = 20;   // 最小命令行行数
        public Int16 CmdLineMaxNum = 50;
        public CommandLine[] cmdline = new CommandLine[50];
        public Int16 ValidCmdLineNum = 0;  // 有效命令行行数
        public byte[] EncodeArray = new byte[101];
        public Int16 EncodeArrayLen = 0;

        private Point CmdLineStartLocation = new Point(0, 0);

        public CommandList(string json_str)
        {
            Int16 i = 0;
            LineItem line_default = new LineItem();
            
            InitializeComponent();

            line_default.IsSelect = "false";
            line_default.Name = "";
            line_default.RegType = "普通寄存器";
            line_default.Index = 0;
            line_default.RegID = "";
            line_default.RFormat = "Dec";
            line_default.RValue = "";
            line_default.WSValue = "";
            line_default.WValue = "";

            Root rt = JsonConvert.DeserializeObject<Root>(json_str);
            Button add_btn = new Button();

            for (i = 0; (i < rt.Line.Count) | (i < CmdLineMinNum); i++)
            {
                if (i >= rt.Line.Count)
                {
                    line_default.Index = i;
                    cmdline[i] = new CommandLine(line_default);
                }
                else
                {
                    cmdline[i] = new CommandLine(rt.Line[i]);
                }

                if (i == 0)
                {
                    cmdline[i].Location = CmdLineStartLocation;
                }
                else
                {
                    cmdline[i].Location = new Point(CmdLineStartLocation.X, cmdline[i - 1].Location.Y + cmdline[i - 1].Size.Height);
                }
                this.scCommand.Panel1.Controls.Add(cmdline[i]);

                ValidCmdLineNum++;
            }

            // 增加“+”按钮
            add_btn.Size = new Size(80, 20);
            add_btn.Location = new Point(CmdLineStartLocation.X + cmdline[i - 1].Size.Width/2 - 40, cmdline[i - 1].Location.Y + cmdline[i - 1].Size.Height);
            add_btn.Text = "+";
            this.scCommand.Panel1.Controls.Add(add_btn);
        }

        public void Encode(object sender, EventArgs e)
        {
            Int16 cnt = 0;
            Int16 arr_cnt = 0;
            byte[] crc = new byte[2];
            Int16 cmd_index = 0;
            Int16 total_string_Len_index = 0;

            EncodeArray[0] = 0xA5;
            arr_cnt += 1;

            if (cbVersion.Checked == true)
            {
                EncodeArray[arr_cnt] = 1;
                arr_cnt += 1;
            }

            if (rbWriteReg.Checked == true)
            {
                Int16 i = 0;

                EncodeArray[arr_cnt] = 0x00;
                cmd_index = arr_cnt;
                arr_cnt += 1;

                for (i = 0; i < ValidCmdLineNum; i++)
                {
                    if ((cmdline[i].IsSelect == true)
                        && (cmdline[i].RegisterWriteValid == true)
                        && (cmdline[i].RegisterType == "普通寄存器"))
                    {
                        EncodeArray[arr_cnt] = (byte)(cmdline[i].RegisterID >> 8);
                        arr_cnt += 1;
                        EncodeArray[arr_cnt] = (byte)cmdline[i].RegisterID;
                        arr_cnt += 1;
                        EncodeArray[arr_cnt] = (byte)(cmdline[i].RegisterWriteValue >> 24);
                        arr_cnt += 1;
                        EncodeArray[arr_cnt] = (byte)(cmdline[i].RegisterWriteValue >> 16);
                        arr_cnt += 1;
                        EncodeArray[arr_cnt] = (byte)(cmdline[i].RegisterWriteValue >> 8);
                        arr_cnt += 1;
                        EncodeArray[arr_cnt] = (byte)cmdline[i].RegisterWriteValue;
                        arr_cnt += 1;

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

                EncodeArray[arr_cnt] = 0x40;
                cmd_index = arr_cnt;
                arr_cnt += 1;

                for (i = 0; i < ValidCmdLineNum; i++)
                {
                    if ((cmdline[i].IsSelect == true)
                        && (cmdline[i].RegisterReadValid == true)
                        && (cmdline[i].RegisterType == "普通寄存器"))
                    {
                        EncodeArray[arr_cnt] = (byte)(cmdline[i].RegisterID >> 8);
                        arr_cnt += 1;
                        EncodeArray[arr_cnt] = (byte)cmdline[i].RegisterID;
                        arr_cnt += 1;

                        cnt += 1;
                        if (cnt >= 16)
                        {
                            break;
                        }
                    }
                }
            }
            else if (rbWriteStringReg.Checked == true)
            {
                Int16 i = 0;
                Int16 j = 0;
                byte[] total_string_byte = new byte[35];
                byte[] string_byte = new byte[32];
                byte string_len = 0;
                Int16 num_of_string = 0;
                Encoding utf8 = Encoding.UTF8;
                Encoding gb2312 = Encoding.GetEncoding(936);
                Encoding ascii = Encoding.GetEncoding(936); 

                EncodeArray[arr_cnt] = 0x10;
                cmd_index = arr_cnt;
                arr_cnt += 1;
                total_string_Len_index = arr_cnt;
                EncodeArray[arr_cnt] = 0;
                arr_cnt += 1;

                for (i = 0; i < ValidCmdLineNum; i++)
                {
                    if ((cmdline[i].IsSelect == true)
                        && (cmdline[i].RegisterWriteStringValid == true)
                        && (cmdline[i].RegisterType == "字符串寄存器"))
                    {
                        byte[] gb2312_bytes = gb2312.GetBytes(cmdline[i].RegisterWriteStringValue);
                        byte[] utf8_bytes = utf8.GetBytes(cmdline[i].RegisterWriteStringValue);
                        byte[] ascii_bytes = System.Text.Encoding.ASCII.GetBytes(cmdline[i].RegisterWriteStringValue);

                        total_string_byte[0] = (byte)(cmdline[i].RegisterID >> 8);
                        total_string_byte[1] = (byte)cmdline[i].RegisterID;
                        if (rbStringFormat_ASCII.Checked == true)
                        {
                            string_len = (byte)cmdline[i].RegisterWriteStringValue.Length;
                            string_byte = ascii_bytes;
                        }
                        else if (rbStringFormat_UTF8.Checked == true)
                        {
                            string_len = (byte)utf8_bytes.Length;
                            string_byte = utf8_bytes;
                        }
                        else if (rbStringFormat_GB2312.Checked == true)
                        {
                            string_len = (byte)gb2312_bytes.Length;
                            string_byte = gb2312_bytes;
                        }

                        total_string_byte[2] = string_len;
                        for (j = 0; j < string_len; j++)
                        {
                            total_string_byte[3 + j] = string_byte[j];
                        }

                        num_of_string += (Int16)(string_len + 3);

                        if (arr_cnt + string_len + 3 > 96)
                        {
                            break;
                        }

                        for (j = 0; j < string_len + 3; j++)
                        {
                            EncodeArray[arr_cnt++] = total_string_byte[j];
                        }

                        cnt += 1;
                        if (cnt >= 16)
                        {
                            break;
                        }
                    }
                }

                EncodeArray[total_string_Len_index] = (byte)num_of_string;
            }
            else
            { 
                //
            }

            if (cnt == 0)
            {
                return;
            }

            EncodeArray[cmd_index] |= (byte)(cnt - 1);
            if (cbResp.Checked == true)
            {
                EncodeArray[cmd_index] |= 0x80;
            }

            if (rbVerifyNone.Checked == true)
            {
                EncodeArray[arr_cnt] = 0xC3;
                arr_cnt += 1;
            }
            else if (rbVerifyCRC.Checked == true)
            {
                crc = ToModbus(EncodeArray, arr_cnt - 1, 1);
                EncodeArray[arr_cnt] = crc[0];
                EncodeArray[arr_cnt + 1] = crc[1];
                EncodeArray[arr_cnt + 2] = 0xC3;
                arr_cnt += 3;
            }
            else if (rbVerifyChecksum.Checked == true)
            {
                Int16 i;
                UInt16 checksum = 0;
                byte[] checksum_byte = new byte[2];

                for (i = 1; i < arr_cnt; i++)
                {
                    checksum += EncodeArray[i];
                }
                EncodeArray[arr_cnt] = (byte)checksum;
                EncodeArray[arr_cnt + 1] = (byte)(checksum >> 8);
                EncodeArray[arr_cnt + 2] = 0xC3;
                arr_cnt += 3;
            }
            
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

        private void scCommand_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rbVerifyCRC_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Command_Load(object sender, EventArgs e)
        {

        }

        private void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSelectAll.Checked == true)
            { 
            }
        }

        private void rbWriteStringReg_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWriteStringReg.Checked == true)
            {
                panelStringFormat.Enabled = true;
            }
            else
            {
                panelStringFormat.Enabled = false;
            }
        }
    }
}
