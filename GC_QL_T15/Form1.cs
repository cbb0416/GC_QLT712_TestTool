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
    public partial class Form1 : Form
    {
        SerialPort serialPort;
        MsgFrame msg_frame_0x05;

        public Form1()
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
            else if(button_SerialOpenClose.Text == "关闭")
            { 
                serialPort.Close();
                button_SerialOpenClose.Text = "打开";
            }
        }

        private void comboBox_SerialPort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        void Msg0x05Encode( )
        {
            byte[] dat = new byte[8];
            byte[] frame = new byte[12];
            UInt16 val16 = 0;

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

            //车速
            val16 = Convert.ToUInt16(textBox1.Text);
            dat[0] = (byte)val16;
            dat[1] = (byte)(val16 >> 8);
            //瞬时功率
            val16 = Convert.ToUInt16(textBox2.Text);
            dat[2] = (byte)val16;
            dat[3] = (byte)(val16 >> 8);
            //瞬时能耗
            dat[4] = Convert.ToByte(textBox3.Text);
            //百公里能耗
            dat[5] = Convert.ToByte(textBox4.Text);


            frame = msg_frame_0x05.Encode(0x05, dat);
            textBox_0x05Send.Text = msg_frame_0x05.ByteArrayToHexString(frame);
            if ((textBox_0x05Send.Text != "") && serialPort.IsOpen)
            {
                serialPort.Write(msg_frame_0x05.HexStringToByteArray(textBox_0x05Send.Text), 0, 12);
            }
        }

        private void button_0x05Send_Click(object sender, EventArgs e)
        {
            if (textBox_0x05Send.Text == "")
            {
                return;
            }

            serialPort.Write(msg_frame_0x05.HexStringToByteArray(textBox_0x05Send.Text), 0, 12);
        }

        private void textBox1Refresh()
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "0";
            }

            trackBar1.Value = Convert.ToInt32(textBox1.Text);

            Msg0x05Encode();
        }

        private void trackBar1Refresh()
        {
            textBox1.Text = trackBar1.Value.ToString();

            Msg0x05Encode();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1Refresh();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBox1Refresh();
            }
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            trackBar1Refresh();
        }

        private void trackBar1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "0";
            }

            Msg0x05Encode();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "0";
            }

            Msg0x05Encode();
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "0";
            }

            Msg0x05Encode();
        }

    }
}
