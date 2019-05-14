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
        MsgFrame msg_frame_0x05;

        public MainForm()
        {
            InitializeComponent();
            serialPort = new SerialPort();

            msg_frame_0x05 = new MsgFrame();
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
            }
            else if (button_SerialOpenClose.Text == "关闭")
            {
                serialPort.Close();
                button_SerialOpenClose.Text = "打开";
            }
        }

        private void comboBox_SerialPort_SelectedIndexChanged(object sender, EventArgs e)
        {

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
        void Msg0x05Encode()
        {
            byte[] dat = new byte[8];
            byte[] frame = new byte[12];
            UInt16 val16 = 0;

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
            val16 = Convert.ToUInt16(textBox_Speed.Text);
            dat[0] = (byte)val16;
            dat[1] = (byte)(val16 >> 8);
            //瞬时功率
            val16 = Convert.ToUInt16(textBox_InstantaneousPower.Text);
            dat[2] = (byte)val16;
            dat[3] = (byte)(val16 >> 8);
            //瞬时能耗
            dat[4] = Convert.ToByte(textBox_InstantaneousEnergyConsumption.Text);
            //百公里能耗
            dat[5] = Convert.ToByte(textBox_HundredKilometersOfEnergyConsumption.Text);


            frame = msg_frame_0x05.Encode(0x05, dat);
            textBox_0x05Send.Text = msg_frame_0x05.ByteArrayToHexString(frame);
            if ((textBox_0x05Send.Text != "") && serialPort.IsOpen)
            {
                serialPort.Write(msg_frame_0x05.HexStringToByteArray(textBox_0x05Send.Text), 0, 12);
            }
        }


        private void Msg0x05Send(object sender, EventArgs e)
        {
            if (textBox_0x05Send.Text == "")
            {
                return;
            }

            serialPort.Write(msg_frame_0x05.HexStringToByteArray(textBox_0x05Send.Text), 0, 12);
        }

        /****************************************** 车速 ****************************************/
        private void textBox_SpeedChange(object sender, EventArgs e)
        {
            trackBar_Speed.Value = Convert.ToInt32(textBox_Speed.Text);
        }

        private void trackerBar_SpeedChange(object sender, EventArgs e)
        {
            textBox_Speed.Text = trackBar_Speed.Value.ToString();
        }

        private void SpeedChangeConfirm()
        {
            //Msg0x05Encode();
        }

        private void textBox_Speed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //SpeedChangeConfirm();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
