using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace GC_QL_T15
{
    public partial class MainForm : Form
    {
        SerialPort serialPort;
        MsgFrame msg_frame_0x02;
        MsgFrame msg_frame_0x03;
        MsgFrame msg_frame_0x04;
        MsgFrame msg_frame_0x05;
        MsgFrame msg_frame_0x06;
        MsgFrame msg_frame_0x07;
        MsgFrame msg_frame_0x08;
        MsgFrame msg_frame_0x09;
        MsgFrame msg_frame_0x0A;
        MsgFrame msg_frame_0x0B;
        MsgFrame msg_frame_0x0C;
        MsgFrame msg_frame_0x0D;

        public MainForm()
        {
            InitializeComponent();
            serialPort = new SerialPort();

            msg_frame_0x02 = new MsgFrame();
            msg_frame_0x03 = new MsgFrame();
            msg_frame_0x04 = new MsgFrame();
            msg_frame_0x05 = new MsgFrame();
            msg_frame_0x06 = new MsgFrame();
            msg_frame_0x07 = new MsgFrame();
            msg_frame_0x08 = new MsgFrame();
            msg_frame_0x09 = new MsgFrame();
            msg_frame_0x0A = new MsgFrame();
            msg_frame_0x0B = new MsgFrame();
            msg_frame_0x0C = new MsgFrame();
            msg_frame_0x0D = new MsgFrame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button_SerialOpenClose.Text == "打开")
            {
                serialPort.PortName = comboBox_SerialPort.Text;
                serialPort.BaudRate = 115200;
                serialPort.Parity = Parity.None;
                serialPort.DataBits = 8;
                //serialPort.StopBits = StopBits.None;

                serialPort.Open();
                button_SerialOpenClose.Text = "关闭";
                Msg0x02Encode(sender, e);
                Msg0x05Encode(sender, e);
                Msg0x06Encode(sender, e);
                Msg0x07Encode(sender, e);
                Msg0x08Encode(sender, e);
                Msg0x09Encode(sender, e);
                //Msg0x0AEncode(sender, e);
                Msg0x0BEncode(sender, e);
                Msg0x0CEncode(sender, e);
                Msg0x0DEncode(sender, e);
            }
            else if (button_SerialOpenClose.Text == "关闭")
            {
                serialPort.Close();
                button_SerialOpenClose.Text = "打开";
            }
        }

        /// <summary>
        /// 串口扫描按钮点击处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SerialScan_Click(object sender, EventArgs e)
        {
            int i = 0;
            string[] ArryPort = SerialPort.GetPortNames();

            if (serialPort.IsOpen)
            {
                button_SerialOpenClose.Enabled = false;
                return;
            }

            comboBox_SerialPort.Items.Clear();

            for (i = 0; i < ArryPort.Length; i++)
            {
                comboBox_SerialPort.Items.Add(ArryPort[i]);
            }

            if (i != 0)
            {
                comboBox_SerialPort.SelectedIndex = 0;
                comboBox_SerialPort.Enabled = true;
                button_SerialOpenClose.Text = "打开";
                button_SerialOpenClose.Enabled = true;
            }
            else
            {
                comboBox_SerialPort.SelectedIndex = 0;
                comboBox_SerialPort.Enabled = false;
                button_SerialOpenClose.Text = "打开";
                button_SerialOpenClose.Enabled = false;
            }
        }

        /// <summary>
        /// MSG 0x05帧数据组包
        /// </summary>
        void Msg0x05Encode(object sender, EventArgs e)
        {
            byte[] dat = new byte[8];
            byte[] frame = new byte[12];
            UInt16 val16 = 0;
            byte val8 = 0;
            double dbl = 0.0;

            if (textBox_Speed.Text == "")
            {
                textBox_Speed.Text = "0";
            }
            if (textBox_InstantaneousPower.Text == "")
            {
                textBox_InstantaneousPower.Text = "0";
            }
            if (textBox_InstantaneousEnergyConsumption.Text == "")
            {
                textBox_InstantaneousEnergyConsumption.Text = "0";
            }
            if (textBox_HundredKilometersOfEnergyConsumption.Text == "")
            {
                textBox_HundredKilometersOfEnergyConsumption.Text = "0";
            }

            //车速
            dbl = Convert.ToDouble(textBox_Speed.Text);
            val16 = Convert.ToUInt16(dbl * 10);
            dat[0] = (byte)val16;
            dat[1] = (byte)(val16 >> 8);
            //瞬时功率
            dbl = Convert.ToDouble(textBox_InstantaneousPower.Text);
            val16 = Convert.ToUInt16(dbl * 10);
            dat[2] = (byte)val16;
            dat[3] = (byte)(val16 >> 8);
            //瞬时能耗
            dbl = Convert.ToDouble(textBox_InstantaneousEnergyConsumption.Text);
            val8 = Convert.ToByte(dbl * 4);
            dat[4] = val8;
            //百公里能耗
            dbl = Convert.ToDouble(textBox_HundredKilometersOfEnergyConsumption.Text);
            val8 = Convert.ToByte(dbl * 4);
            dat[5] = val8;
            //主界面切换
            if (radioButton1.Checked == true)
            {
                dat[6] &= 0xF0;
                dat[6] |= 0x00;
            }
            else if (radioButton2.Checked == true)
            {
                dat[6] &= 0xF0;
                dat[6] |= 0x01;
            }
            else if (radioButton3.Checked == true)
            {
                dat[6] &= 0xF0;
                dat[6] |= 0x02;
            }
            else if (radioButton4.Checked == true)
            {
                dat[6] &= 0xF0;
                dat[6] |= 0x03;
            }
            else if (radioButton5.Checked == true)
            {
                dat[6] &= 0xF0;
                dat[6] |= 0x04;
            }
            else
            {
                radioButton1.Checked = true;
                dat[6] &= 0xF0;
                dat[6] |= 0x00;
            }
            //行车界面切换
            if (radioButton11.Checked == true)
            {
                dat[6] &= 0x0F;
                dat[6] |= 0x00;
            }
            else if (radioButton12.Checked == true)
            {
                dat[6] &= 0x0F;
                dat[6] |= 0x10;
            }
            else if (radioButton13.Checked == true)
            {
                dat[6] &= 0x0F;
                dat[6] |= 0x20;
            }
            else if (radioButton14.Checked == true)
            {
                dat[6] &= 0x0F;
                dat[6] |= 0x30;
            }
            else if (radioButton15.Checked == true)
            {
                dat[6] &= 0x0F;
                dat[6] |= 0x40;
            }
            else
            {
                radioButton11.Checked = true;
                dat[6] &= 0x0F;
                dat[6] |= 0x00;
            }
            //弹窗界面切换
            if (radioButton6.Checked == true)
            {
                dat[7] &= 0xF0;
                dat[7] |= 0x00;
            }
            else if (radioButton7.Checked == true)
            {
                dat[7] &= 0xF0;
                dat[7] |= 0x01;
            }
            else if (radioButton8.Checked == true)
            {
                dat[7] &= 0xF0;
                dat[7] |= 0x02;
            }
            else if (radioButton9.Checked == true)
            {
                dat[7] &= 0xF0;
                dat[7] |= 0x03;
            }
            else if (radioButton10.Checked == true)
            {
                dat[7] &= 0xF0;
                dat[7] |= 0x04;
            }
            else
            {
                radioButton6.Checked = true;
                dat[7] &= 0xF0;
                dat[7] |= 0x00;
            }
            //档位
            if (rBtn_Gear_None.Checked == true)
            {
                dat[7] &= 0x0F;
                dat[7] |= 0x00;
            }
            else if (rBtn_Gear_R.Checked == true)
            {
                dat[7] &= 0x0F;
                dat[7] |= 0x10;
            }
            else if (rBtn_Gear_D.Checked == true)
            {
                dat[7] &= 0x0F;
                dat[7] |= 0x20;
            }
            else if (rBtn_Gear_P.Checked == true)
            {
                dat[7] &= 0x0F;
                dat[7] |= 0x30;
            }
            else if (rBtn_Gear_N.Checked == true)
            {
                dat[7] &= 0x0F;
                dat[7] |= 0x40;
            }
            else
            {
                rBtn_Gear_None.Checked = true;
                dat[7] &= 0x0F;
                dat[7] |= 0x00;
            }

            frame = msg_frame_0x05.Encode(0x05, dat);
            textBox_0x05Send.Text = msg_frame_0x05.ByteArrayToHexString(frame);
            if ((textBox_0x05Send.Text != "") && serialPort.IsOpen)
            {
                serialPort.Write(msg_frame_0x05.HexStringToByteArray(textBox_0x05Send.Text), 0, 12);
            }
        }

        /// <summary>
        /// MSG 0x06帧数据组包
        /// </summary>
        void Msg0x06Encode(object sender, EventArgs e)
        {
            byte[] dat = new byte[8];
            byte[] frame = new byte[12];
            UInt16 val16 = 0;
            double dbl = 0.0;

            if (textBox1.Text == "")
            {
                textBox1.Text = "0";
            }
            if (textBox2.Text == "")
            {
                textBox2.Text = "0";
            }
            if (textBox3.Text == "")
            {
                textBox3.Text = "0";
            }
            if (textBox4.Text == "")
            {
                textBox4.Text = "0";
            }

            //总电压
            dbl = Convert.ToDouble(textBox1.Text);
            val16 = (UInt16)dbl;
            dat[0] = (byte)val16;
            dat[1] = (byte)(val16 >> 8);
            //总电流
            dbl = Convert.ToDouble(textBox2.Text);
            val16 = (UInt16)dbl;
            val16 += 1000;
            val16 *= 10;           
            dat[2] = (byte)val16;
            dat[3] = (byte)(val16 >> 8);
            //单体最高电压
            dbl = Convert.ToDouble(textBox3.Text);
            dbl *= 1000;
            val16 = (UInt16)dbl;
            dat[4] = (byte)val16;
            dat[5] = (byte)(val16 >> 8);
            //单体最低电压
            dbl = Convert.ToDouble(textBox4.Text);
            dbl *= 1000;
            val16 = (UInt16)dbl;
            dat[6] = (byte)val16;
            dat[7] = (byte)(val16 >> 8);

            frame = msg_frame_0x06.Encode(0x06, dat);
            textBox_0x06Send.Text = msg_frame_0x06.ByteArrayToHexString(frame);
            if ((textBox_0x06Send.Text != "") && serialPort.IsOpen)
            {
                serialPort.Write(msg_frame_0x06.HexStringToByteArray(textBox_0x06Send.Text), 0, 12);
            }
        }

        /// <summary>
        /// MSG 0x07帧数据组包
        /// </summary>
        void Msg0x07Encode(object sender, EventArgs e)
        {
            byte[] dat = new byte[8];
            byte[] frame = new byte[12];
            byte val8 = 0;
            UInt16 val16 = 0;
            UInt32 val32 = 0;
            double dbl = 0.0;

            if (textBox10.Text == "")
            {
                textBox10.Text = "0";
            }
            if (textBox9.Text == "")
            {
                textBox9.Text = "0";
            }
            if (textBox8.Text == "")
            {
                textBox8.Text = "0";
            }
            if (textBox7.Text == "")
            {
                textBox7.Text = "0";
            }

            //充电剩余时间
            dbl = Convert.ToDouble(textBox10.Text);
            dbl *= 10;
            val8 = (byte)dbl;
            dat[0] = val8;
            //总里程
            dbl = Convert.ToDouble(textBox9.Text);
            val32 = (UInt32)dbl;
            dat[1] = (byte)val32;
            dat[2] = (byte)(val32 >> 8);
            dat[3] = (byte)(val32 >> 16);
            //小计里程A
            dbl = Convert.ToDouble(textBox8.Text);
            dbl *= 10;
            val16 = (UInt16)dbl;
            dat[4] = (byte)val16;
            dat[5] = (byte)(val16 >> 8);
            //续航里程
            dbl = Convert.ToDouble(textBox7.Text);
            val16 = (UInt16)dbl;
            dat[6] = (byte)val16;
            dat[7] = (byte)(val16 >> 8);

            frame = msg_frame_0x07.Encode(0x07, dat);
            textBox_0x07Send.Text = msg_frame_0x07.ByteArrayToHexString(frame);
            if ((textBox_0x07Send.Text != "") && serialPort.IsOpen)
            {
                serialPort.Write(msg_frame_0x07.HexStringToByteArray(textBox_0x07Send.Text), 0, 12);
            }
        }

        /// <summary>
        /// MSG 0x08帧数据组包
        /// </summary>
        void Msg0x08Encode(object sender, EventArgs e)
        {
            byte[] dat = new byte[8];
            byte[] frame = new byte[12];
            byte val8 = 0;
            double dbl = 0.0;

            if (textBox12.Text == "")
            {
                textBox12.Text = "0";
            }
            if (textBox13.Text == "")
            {
                textBox13.Text = "0";
            }
            if (textBox14.Text == "")
            {
                textBox14.Text = "0";
            }
            if (textBox15.Text == "")
            {
                textBox15.Text = "0";
            }
            if (textBox16.Text == "")
            {
                textBox16.Text = "0";
            }
            if (textBox17.Text == "")
            {
                textBox17.Text = "0";
            }
            if (textBox18.Text == "")
            {
                textBox18.Text = "0";
            }

            //电机温度
            if (checkBox34.Checked == true)
            {
                dat[0] = 0xff;
            }
            else
            {
                dbl = Convert.ToDouble(textBox15.Text);
                val8 = (byte)dbl;
                val8 += 40;
                dat[0] = val8;
            }
            //控制器温度
            dbl = Convert.ToDouble(textBox14.Text);
            val8 = (byte)dbl;
            val8 += 40;
            dat[1] = val8;
            //单体最高温度
            dbl = Convert.ToDouble(textBox13.Text);
            val8 = (byte)dbl;
            val8 += 40;
            dat[2] = val8;
            //单体最低温度
            dbl = Convert.ToDouble(textBox12.Text);
            val8 = (byte)dbl;
            val8 += 40;
            dat[3] = val8;
            //单体最高温度编号  
            dbl = Convert.ToDouble(textBox16.Text);
            val8 = (byte)dbl;
            dat[4] = val8;
            //单体最高电压编号
            dbl = Convert.ToDouble(textBox17.Text);
            val8 = (byte)dbl;
            dat[5] = val8;
            //单体最低电压编号
            dbl = Convert.ToDouble(textBox18.Text);
            val8 = (byte)dbl;
            dat[6] = val8;

            frame = msg_frame_0x08.Encode(0x08, dat);
            textBox_0x08Send.Text = msg_frame_0x08.ByteArrayToHexString(frame);
            if ((textBox_0x08Send.Text != "") && serialPort.IsOpen)
            {
                serialPort.Write(msg_frame_0x08.HexStringToByteArray(textBox_0x08Send.Text), 0, 12);
            }
        }

        /// <summary>
        /// MSG 0x09帧数据组包
        /// </summary>
        void Msg0x09Encode(object sender, EventArgs e)
        {
            byte[] dat = new byte[8];
            byte[] frame = new byte[12];
            byte val8 = 0;
            UInt16 val16 = 0;
            UInt32 val32 = 0;
            double dbl = 0.0;

            if (textBox23.Text == "")
            {
                textBox23.Text = "0";
            }
            if (textBox22.Text == "")
            {
                textBox22.Text = "0";
            }
            if (textBox21.Text == "")
            {
                textBox21.Text = "0";
            }
            if (textBox20.Text == "")
            {
                textBox20.Text = "0";
            }

            //行驶时间
            dbl = Convert.ToDouble(textBox23.Text);
            dbl *= 10;
            val16 = (UInt16)dbl;
            dat[0] = (byte)val16;
            dat[1] = (byte)(val16 >> 8);
            //BAT电池电压
            dbl = Convert.ToDouble(textBox22.Text);
            dbl *= 10;
            val8 = (byte)dbl;
            dat[2] = val8;
            //SOC
            dbl = Convert.ToDouble(textBox21.Text);
            val8 = (byte)dbl;
            dat[3] = val8;
            //电池箱就位数
            dbl = Convert.ToDouble(textBox20.Text);
            val8 = (byte)dbl;
            dat[4] = val8;

            frame = msg_frame_0x09.Encode(0x09, dat);
            textBox_0x09Send.Text = msg_frame_0x09.ByteArrayToHexString(frame);
            if ((textBox_0x09Send.Text != "") && serialPort.IsOpen)
            {
                serialPort.Write(msg_frame_0x09.HexStringToByteArray(textBox_0x09Send.Text), 0, 12);
            }
        }

        /// <summary>
        /// MSG 0x0B帧数据组包
        /// </summary>
        void Msg0x0BEncode(object sender, EventArgs e)
        {
            byte[] dat = new byte[8];
            byte[] frame = new byte[12];
            UInt16 val16 = 0;
            double dbl = 0.0;

            if (textBox28.Text == "")
            {
                textBox28.Text = "0";
            }
            if (textBox27.Text == "")
            {
                textBox27.Text = "0";
            }
            if (textBox26.Text == "")
            {
                textBox26.Text = "0";
            }
            if (textBox25.Text == "")
            {
                textBox25.Text = "0";
            }

            //故障代码1
            dbl = Convert.ToDouble(textBox28.Text);
            val16 = (UInt16)dbl;
            dat[0] = (byte)val16;
            dat[1] = (byte)(val16 >> 8);
            //故障代码2
            dbl = Convert.ToDouble(textBox27.Text);
            val16 = (UInt16)dbl;
            dat[2] = (byte)val16;
            dat[3] = (byte)(val16 >> 8);
            //故障代码3
            dbl = Convert.ToDouble(textBox26.Text);
            val16 = (UInt16)dbl;
            dat[4] = (byte)val16;
            dat[5] = (byte)(val16 >> 8);
            //故障代码4
            dbl = Convert.ToDouble(textBox25.Text);
            val16 = (UInt16)dbl;
            dat[6] = (byte)val16;
            dat[7] = (byte)(val16 >> 8);

            frame = msg_frame_0x0B.Encode(0x0B, dat);
            textBox_0x0BSend.Text = msg_frame_0x0B.ByteArrayToHexString(frame);
            if ((textBox_0x0BSend.Text != "") && serialPort.IsOpen)
            {
                serialPort.Write(msg_frame_0x0B.HexStringToByteArray(textBox_0x0BSend.Text), 0, 12);
            }
        }

        /// <summary>
        /// MSG 0x0A帧数据组包
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Msg0x0AEncode(object sender, EventArgs e)
        {
            byte[] dat = new byte[8];
            byte[] frame = new byte[12];

            if (textBox29.Text == "")
            {
                textBox20.Text = "0";
            }

            if (textBox30.Text == "")
            {
                textBox30.Text = "0";
            }

            if (checkBox1.Checked == true)
            {
                dat[0] |= 0x01;
            }
            else
            {
                dat[0] &= 0xFE;
            }

            if (checkBox2.Checked == true)
            {
                dat[0] |= 0x02;
            }
            else
            {
                dat[0] &= 0xFD;
            }

            if (checkBox3.Checked == true)
            {
                dat[0] |= 0x04;
            }
            else
            {
                dat[0] &= 0xFB;
            }

            if (checkBox4.Checked == true)
            {
                dat[0] |= 0x08;
            }
            else
            {
                dat[0] &= 0xF7;
            }

            if (checkBox5.Checked == true)
            {
                dat[0] |= 0x10;
            }
            else
            {
                dat[0] &= 0xEF;
            }

            if (checkBox6.Checked == true)
            {
                dat[0] |= 0x20;
            }
            else
            {
                dat[0] &= 0xDF;
            }

            if (checkBox7.Checked == true)
            {
                dat[0] |= 0x40;
            }
            else
            {
                dat[0] &= 0xBF;
            }

            if (checkBox8.Checked == true)
            {
                dat[0] |= 0x80;
            }
            else
            {
                dat[0] &= 0x7F;
            }

            if (checkBox9.Checked == true)
            {
                dat[1] |= 0x01;
            }
            else
            {
                dat[1] &= 0xFE;
            }

            if (checkBox10.Checked == true)
            {
                dat[1] |= 0x02;
            }
            else
            {
                dat[1] &= 0xFD;
            }

            if (checkBox11.Checked == true)
            {
                dat[1] |= 0x04;
            }
            else
            {
                dat[1] &= 0xFB;
            }

            if (checkBox12.Checked == true)
            {
                dat[1] |= 0x08;
            }
            else
            {
                dat[1] &= 0xF7;
            }

            if (checkBox13.Checked == true)
            {
                dat[1] |= 0x10;
            }
            else
            {
                dat[1] &= 0xEF;
            }

            if (checkBox14.Checked == true)
            {
                dat[1] |= 0x20;
            }
            else
            {
                dat[1] &= 0xDF;
            }

            if (checkBox15.Checked == true)
            {
                dat[1] |= 0x40;
            }
            else
            {
                dat[1] &= 0xBF;
            }

            if (checkBox16.Checked == true)
            {
                dat[1] |= 0x80;
            }
            else
            {
                dat[1] &= 0x7F;
            }

            if (checkBox17.Checked == true)
            {
                dat[2] |= 0x01;
            }
            else
            {
                dat[2] &= 0xFE;
            }         
            
            //故障总数
            dat[3] = Convert.ToByte(textBox29.Text);

            //故障代码
            dat[4] = Convert.ToByte(textBox30.Text);

            frame = msg_frame_0x0A.Encode(0x0C, dat);
            textBox_0x0ASend.Text = msg_frame_0x0A.ByteArrayToHexString(frame);
            if ((textBox_0x0ASend.Text != "") && serialPort.IsOpen)
            {
                serialPort.Write(msg_frame_0x0A.HexStringToByteArray(textBox_0x0ASend.Text), 0, 12);
            }
        }

        /// <summary>
        /// MSG 0x0C帧数据组包
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Msg0x0CEncode(object sender, EventArgs e)
        {
            byte[] dat = new byte[8];
            byte[] frame = new byte[12];

            if (textBox31.Text == "")
            {
                textBox31.Text = "0";
            }

            if (textBox32.Text == "")
            {
                textBox32.Text = "0";
            }

            if (radioButton16.Checked == true)
            {
                dat[0] |= 0x01;
            }
            else
            {
                dat[0] &= 0xFE;
            }

            if (radioButton17.Checked == true)
            {
                dat[0] |= 0x02;
            }
            else
            {
                dat[0] &= 0xFD;
            }

            if (radioButton18.Checked == true)
            {
                dat[0] |= 0x04;
            }
            else
            {
                dat[0] &= 0xFB;
            }

            if (radioButton19.Checked == true)
            {
                dat[0] |= 0x08;
            }
            else
            {
                dat[0] &= 0xF7;
            }

            if (radioButton20.Checked == true)
            {
                dat[0] |= 0x10;
            }
            else
            {
                dat[0] &= 0xEF;
            }

            if (radioButton21.Checked == true)
            {
                dat[0] |= 0x20;
            }
            else
            {
                dat[0] &= 0xDF;
            }

            if (radioButton22.Checked == true)
            {
                dat[0] |= 0x40;
            }
            else
            {
                dat[0] &= 0xBF;
            }

            if (radioButton23.Checked == true)
            {
                dat[0] |= 0x80;
            }
            else
            {
                dat[0] &= 0x7F;
            }

            if (radioButton24.Checked == true)
            {
                dat[1] |= 0x01;
            }
            else
            {
                dat[1] &= 0xFE;
            }

            if (radioButton25.Checked == true)
            {
                dat[1] |= 0x02;
            }
            else
            {
                dat[1] &= 0xFD;
            }

            if (radioButton26.Checked == true)
            {
                dat[1] |= 0x04;
            }
            else
            {
                dat[1] &= 0xFB;
            }

            if (radioButton27.Checked == true)
            {
                dat[1] |= 0x08;
            }
            else
            {
                dat[1] &= 0xF7;
            }

            if (radioButton28.Checked == true)
            {
                dat[1] |= 0x10;
            }
            else
            {
                dat[1] &= 0xEF;
            }

            if (radioButton29.Checked == true)
            {
                dat[1] |= 0x20;
            }
            else
            {
                dat[1] &= 0xDF;
            }

            if (radioButton30.Checked == true)
            {
                dat[1] |= 0x40;
            }
            else
            {
                dat[1] &= 0xBF;
            }

            if (radioButton31.Checked == true)
            {
                dat[1] |= 0x80;
            }
            else
            {
                dat[1] &= 0x7F;
            }

            if (radioButton32.Checked == true)
            {
                dat[2] |= 0x01;
            }
            else
            {
                dat[2] &= 0xFE;
            }

            //故障总数
            dat[3] = Convert.ToByte(textBox31.Text);

            //故障代码
            dat[4] = Convert.ToByte(textBox32.Text);

            frame = msg_frame_0x0C.Encode(0x0C, dat);
            textBox_0x0CSend.Text = msg_frame_0x0C.ByteArrayToHexString(frame);
            if ((textBox_0x0CSend.Text != "") && serialPort.IsOpen)
            {
                serialPort.Write(msg_frame_0x0C.HexStringToByteArray(textBox_0x0CSend.Text), 0, 12);
            }
        }

        /// <summary>
        /// MSG 0x0D帧数据组包
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Msg0x0DEncode(object sender, EventArgs e)
        {
            byte[] dat = new byte[8];
            byte[] frame = new byte[12];
            double dbl;
            byte val8 = 0;
            UInt16 val16 = 0;

            if (textBox33.Text == "")
            {
                textBox33.Text = "0";
            }

            if (textBox34.Text == "")
            {
                textBox34.Text = "0";
            }

            if (radioButton37.Checked == true)
            {
                dat[0] = 0x00;
            }
            else if (radioButton38.Checked == true)
            {
                dat[0] = 0x01;
            }
            else if (radioButton39.Checked == true)
            {
                dat[0] = 0x10;
            }
            else if (radioButton40.Checked == true)
            {
                dat[0] = 0x11;
            }
            else if (radioButton41.Checked == true)
            {
                dat[0] = 0x12;
            }
            else if (radioButton42.Checked == true)
            {
                dat[0] = 0x13;
            }
            else if (radioButton43.Checked == true)
            {
                dat[0] = 0x20;
            }
            else if (radioButton44.Checked == true)
            {
                dat[0] = 0x21;
            }
            else if (radioButton45.Checked == true)
            {
                dat[0] = 0x22;
            }
            else
            {
                dat[0] = 0x00;
            }

            //轮胎压力
            if (checkBox35.Checked == true)
            {
                dat[1] = 0xff;
            }
            else
            {
                dbl = Convert.ToDouble(textBox33.Text);
                val16 = (UInt16)dbl;
                val8 = (byte)(val16 / 5);
                dat[1] = val8;
            }

            //轮胎温度
            if (checkBox36.Checked == true)
            {
                dat[2] = 0xff;
                dat[3] = 0xff;
            }
            else
            {
                dbl = Convert.ToDouble(textBox34.Text);
                dbl += 273;
                dbl /= 0.03125;
                val16 = (UInt16)dbl;
                dat[2] = (byte)val16;
                dat[3] = (byte)(val16 >> 8);
            }

            if (checkBox30.Checked == true)
            {
                dat[4] |= 0x04;
            }
            else
            {
                dat[4] &= 0xF3;
            }

            if (checkBox31.Checked == true)
            {
                dat[4] |= 0x10;
            }
            else
            {
                dat[4] &= 0xCF;
            }

            if (checkBox32.Checked == true)
            {
                dat[7] |= 0x01;
            }
            else
            {
                dat[7] &= 0xFE;
            }

            if (checkBox33.Checked == true)
            {
                dat[7] |= 0x08;
            }
            else
            {
                dat[7] &= 0xF7;
            }

            if (radioButton46.Checked == true)
            {
                dat[7] &= 0x1F;
                dat[7] |= 0x40;
            }
            else if (radioButton47.Checked == true)
            {
                dat[7] &= 0x1F;
                dat[7] |= 0x00;
            }
            else if (radioButton48.Checked == true)
            {
                dat[7] &= 0x1F;
                dat[7] |= 0x20;
            }
            else if (radioButton49.Checked == true)
            {
                dat[7] &= 0x1F;
                dat[7] |= 0x60;
            }
            else if (radioButton50.Checked == true)
            {
                dat[7] &= 0x1F;
                dat[7] |= 0x80;
            }
            else
            {
                dat[7] &= 0x1F;
                dat[7] |= 0x40;
            }

            frame = msg_frame_0x0D.Encode(0x0D, dat);
            textBox_0x0DSend.Text = msg_frame_0x0D.ByteArrayToHexString(frame);
            if ((textBox_0x0DSend.Text != "") && serialPort.IsOpen)
            {
                serialPort.Write(msg_frame_0x0D.HexStringToByteArray(textBox_0x0DSend.Text), 0, 12);
            }
        }

        /// <summary>
        /// MSG 0x02帧数据组包
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Msg0x02Encode(object sender, EventArgs e)
        {
            byte[] dat = new byte[8];
            byte[] frame = new byte[12];

            if (checkBox18.Checked == true)
            {
                dat[0] |= 0x01;
            }
            else
            {
                dat[0] &= 0xFE;
            }

            if (checkBox19.Checked == true)
            {
                dat[0] |= 0x02;
            }
            else
            {
                dat[0] &= 0xFD;
            }

            if (checkBox20.Checked == true)
            {
                dat[0] |= 0x04;
            }
            else
            {
                dat[0] &= 0xFB;
            }

            if (checkBox21.Checked == true)
            {
                dat[0] |= 0x08;
            }
            else
            {
                dat[0] &= 0xF7;
            }

            if (checkBox22.Checked == true)
            {
                dat[0] |= 0x10;
            }
            else
            {
                dat[0] &= 0xEF;
            }

            if (checkBox23.Checked == true)
            {
                dat[0] |= 0x20;
            }
            else
            {
                dat[0] &= 0xDF;
            }

            if (checkBox24.Checked == true)
            {
                dat[0] |= 0x40;
            }
            else
            {
                dat[0] &= 0xBF;
            }

            if (checkBox25.Checked == true)
            {
                dat[0] |= 0x80;
            }
            else
            {
                dat[0] &= 0x7F;
            }

            if (checkBox26.Checked == true)
            {
                dat[1] |= 0x01;
            }
            else
            {
                dat[1] &= 0xFE;
            }

            if (checkBox27.Checked == true)
            {
                dat[1] |= 0x02;
            }
            else
            {
                dat[1] &= 0xFD;
            }

            if (checkBox28.Checked == true)
            {
                dat[1] |= 0x04;
            }
            else
            {
                dat[1] &= 0xFB;
            }

            if (checkBox29.Checked == true)
            {
                dat[1] |= 0x08;
            }
            else
            {
                dat[1] &= 0xF7;
            }

            if (radioButton33.Checked == true)
            {
                dat[7] = 0x00;
            }
            else if (radioButton34.Checked == true)
            {
                dat[7] = 0x01;
            }
            else if (radioButton34.Checked == true)
            {
                dat[7] = 0x02;
            }
            else if (radioButton34.Checked == true)
            {
                dat[7] = 0x03;
            }
            else
            {
                dat[7] = 0x00;
            }

            frame = msg_frame_0x02.Encode(0x02, dat);
            textBox_0x02Send.Text = msg_frame_0x02.ByteArrayToHexString(frame);
            if ((textBox_0x02Send.Text != "") && serialPort.IsOpen)
            {
                serialPort.Write(msg_frame_0x02.HexStringToByteArray(textBox_0x02Send.Text), 0, 12);
            }
        }

        private void button_0x0ASend_Click(object sender, EventArgs e)
        {
            if (textBox_0x0ASend.Text == "")
            {
                return;
            }

            serialPort.Write(msg_frame_0x0A.HexStringToByteArray(textBox_0x0ASend.Text), 0, 12);
        }

        private void button_0x0CSend_Click(object sender, EventArgs e)
        {
            if (textBox_0x0CSend.Text == "")
            {
                return;
            }

            serialPort.Write(msg_frame_0x0C.HexStringToByteArray(textBox_0x0CSend.Text), 0, 12);
        }

        private void textBox31_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Msg0x0CEncode(sender, e);
            }
        }

        private void textBox32_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Msg0x0CEncode(sender, e);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox_0x0CSend.Text == "")
            {
                return;
            }

            serialPort.Write(msg_frame_0x0C.HexStringToByteArray(textBox_0x0CSend.Text), 0, 12);
        }

        private void button_0x05Send_Click(object sender, EventArgs e)
        {
            if (textBox_0x05Send.Text == "")
            {
                return;
            }

            serialPort.Write(msg_frame_0x05.HexStringToByteArray(textBox_0x05Send.Text), 0, 12);
        }

        private void textBox_Speed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox_Speed.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox_Speed.Text = "0";
                }
                Msg0x05Encode(sender, e);
            }
        }

        private void textBox_InstantaneousPower_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox_InstantaneousPower.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox_InstantaneousPower.Text = "0";
                }
                Msg0x05Encode(sender, e);
            }
        }

        private void textBox_InstantaneousEnergyConsumption_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox_InstantaneousEnergyConsumption.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox_InstantaneousEnergyConsumption.Text = "0";
                }
                Msg0x05Encode(sender, e);
            }
        }

        private void textBox_HundredKilometersOfEnergyConsumption_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox_HundredKilometersOfEnergyConsumption.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox_HundredKilometersOfEnergyConsumption.Text = "0";
                }
                Msg0x05Encode(sender, e);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox1.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox1.Text = "0";
                }
                Msg0x06Encode(sender, e);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox2.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox2.Text = "0";
                }
                Msg0x06Encode(sender, e);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox3.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox3.Text = "0";
                }
                Msg0x06Encode(sender, e);
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox4.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox4.Text = "0";
                }
                Msg0x06Encode(sender, e);
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox10.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox10.Text = "0";
                }
                Msg0x07Encode(sender, e);
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox9.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox9.Text = "0";
                }
                Msg0x07Encode(sender, e);
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox8.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox8.Text = "0";
                }
                Msg0x07Encode(sender, e);
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox7.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox7.Text = "0";
                }
                Msg0x07Encode(sender, e);
            }
        }

        private void textBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox23.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox23.Text = "0";
                }
                Msg0x09Encode(sender, e);
            }
        }

        private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox22.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox22.Text = "0";
                }
                Msg0x09Encode(sender, e);
            }
        }

        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox21.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox21.Text = "0";
                }
                Msg0x09Encode(sender, e);
            }
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox20.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox20.Text = "0";
                }
                Msg0x09Encode(sender, e);
            }
        }

        private void textBox28_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox28.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox28.Text = "0";
                }
                Msg0x0BEncode(sender, e);
            }
        }

        private void textBox27_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox27.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox27.Text = "0";
                }
                Msg0x0BEncode(sender, e);
            }
        }

        private void textBox26_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox26.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox26.Text = "0";
                }
                Msg0x0BEncode(sender, e);
            }
        }

        private void textBox25_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox25.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox25.Text = "0";
                }
                Msg0x0BEncode(sender, e);
            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox15.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox15.Text = "0";
                }
                Msg0x08Encode(sender, e);
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox14.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox14.Text = "0";
                }
                Msg0x08Encode(sender, e);
            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox13.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox13.Text = "0";
                }
                Msg0x08Encode(sender, e);
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox12.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox12.Text = "0";
                }
                Msg0x08Encode(sender, e);
            }
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox16.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox16.Text = "0";
                }
                Msg0x08Encode(sender, e);
            }
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox17.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox17.Text = "0";
                }
                Msg0x08Encode(sender, e);
            }
        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox18.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox18.Text = "0";
                }
                Msg0x08Encode(sender, e);
            }
        }

        private void textBox33_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox33.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox33.Text = "0";
                }
                Msg0x0DEncode(sender, e);
            }
        }

        private void textBox34_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float tmp;
                if (!float.TryParse(textBox34.Text, out tmp))
                {
                    MessageBox.Show("请正确输入数字");
                    textBox34.Text = "0";
                }
                Msg0x0DEncode(sender, e);
            }
        }

        private void button_0x0DSend_Click(object sender, EventArgs e)
        {
            if (textBox_0x0DSend.Text == "")
            {
                return;
            }

            serialPort.Write(msg_frame_0x0D.HexStringToByteArray(textBox_0x0DSend.Text), 0, 12);
        }

        private void button_0x08Send_Click(object sender, EventArgs e)
        {
            if (textBox_0x08Send.Text == "")
            {
                return;
            }

            serialPort.Write(msg_frame_0x08.HexStringToByteArray(textBox_0x08Send.Text), 0, 12);
        }

        private void button_0x06Send_Click(object sender, EventArgs e)
        {
            if (textBox_0x06Send.Text == "")
            {
                return;
            }

            serialPort.Write(msg_frame_0x06.HexStringToByteArray(textBox_0x06Send.Text), 0, 12);
        }

        private void button_0x07Send_Click(object sender, EventArgs e)
        {
            if (textBox_0x07Send.Text == "")
            {
                return;
            }

            serialPort.Write(msg_frame_0x07.HexStringToByteArray(textBox_0x07Send.Text), 0, 12);
        }

        private void button_0x09Send_Click(object sender, EventArgs e)
        {
            if (textBox_0x09Send.Text == "")
            {
                return;
            }

            serialPort.Write(msg_frame_0x09.HexStringToByteArray(textBox_0x09Send.Text), 0, 12);
        }

        private void button_0x0BSend_Click(object sender, EventArgs e)
        {
            if (textBox_0x0BSend.Text == "")
            {
                return;
            }

            serialPort.Write(msg_frame_0x0B.HexStringToByteArray(textBox_0x0BSend.Text), 0, 12);
        }
    }
}
