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
using System.IO;
using SXWUartProtocol;

namespace GC_QL_T15
{
    public partial class MainForm : Form
    {
        SerialPort serialPort;
        CommandList cmd;
        MsgFrame msg_frame_0x05;
        private StringBuilder sb = new StringBuilder();     //为了避免在接收处理函数中反复调用，依然声明为一个全局变量
        private DateTime current_time = new DateTime();    //为了避免在接收处理函数中反复调用，依然声明为一个全局变量

        public MainForm()
        {
            InitializeComponent();
            serialPort = new SerialPort();
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);

            msg_frame_0x05 = new MsgFrame();

            /// 
            /// 自动生成命令行
            /// 
            cmd = new CommandList(File.ReadAllText("cmdline.json"));

            cmd.Location = new Point(0, 0);
            //grpCmd.Controls.Add(cmd);
            tabpageSWXUartCmd.Controls.Add(cmd);

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pnlQuickSet_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (cmd.EncodeArrayLen != 0)
            {
                try
                {
                    if (serialPort.IsOpen == true)
                    {
                        serialPort.Write(cmd.EncodeArray, 0, cmd.EncodeArrayLen);
                    }
                    else
                    {
                        MessageBox.Show("未打开串口！");
                    }
                }
                catch (IOException eio)
                {
                    MessageBox.Show("串口异常：" + eio);
                }
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int num = serialPort.BytesToRead;      //获取接收缓冲区中的字节数
            byte[] received_buf = new byte[num];    //声明一个大小为num的字节数据用于存放读出的byte型数据

            serialPort.Read(received_buf, 0, num);   //读取接收缓冲区中num个字节到byte数组中

            sb.Clear();     //防止出错,首先清空字符串构造器
            //遍历数组进行字符串转化及拼接
            foreach (byte b in received_buf)
            {
                if (rbRecvHex.Checked == true)
                {
                    sb.Append(b.ToString("X2") + ' ');
                }
                else if (rbRecvAscii.Checked == true)
                {
                    sb.Append(b.ToString());
                }
            }

            try
            {
                //因为要访问UI资源，所以需要使用invoke方式同步ui
                Invoke((EventHandler)(delegate
                {
                    if (cbRecvTime.Checked == true)
                    {
                        current_time = System.DateTime.Now;     //获取当前时间
                        tbRecv.AppendText(current_time.ToString("[" + "HH:mm:ss") + "] " + sb.ToString() + "\r\n");
                    }
                    else
                    {
                        tbRecv.AppendText(sb.ToString() + "\r\n");
                    }
                }));
            }
            catch (Exception ex)
            {
                //响铃并显示异常给用户
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show(ex.Message);

            }
#if false
                try
                {
                    //因为要访问UI资源，所以需要使用invoke方式同步ui
                    this.Invoke((EventHandler)(delegate
                    {
                        tbRecv.AppendText(serialPort.ReadExisting());
                    }));
                }
                catch (Exception ex)
                {
                    //响铃并显示异常给用户
                    System.Media.SystemSounds.Beep.Play();
                    MessageBox.Show(ex.Message);

                }
#endif
        }

        private void btnRecvClear_Click(object sender, EventArgs e)
        {
            tbRecv.Text = "";
        }

        private void btnSendClear_Click(object sender, EventArgs e)
        {
            tbSend.Text = "";
        }
    }
}
