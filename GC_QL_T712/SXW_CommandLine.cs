using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SXWUartProtocol
{
    public partial class CommandLine: UserControl
    {
        //private bool IsSelect = false;
        public bool WriteRegValid = false;
        public bool ReadRegValid = false;
        public byte[] WriteRegEncodeArray = new byte[6];
        public byte[] ReadRegEncodeArray = new byte[2];

        /// <summary>
        /// 命令行选中
        /// </summary>
        public bool IsSelect
        {
            set 
            { 
                cbSelect.Checked = value;
            }
            get 
            {
                return cbSelect.Checked;
            }
        }

        /// <summary>
        /// 行数
        /// </summary>
        public UInt16 Index
        {
            set { lblIndex.Text = value.ToString() + ":"; }
        }

        /// <summary>
        /// 寄存器类型："普通寄存器" or "字符串寄存器"
        /// </summary>
        public string RegisterType
        {
            set
            {
                if ((value == "普通寄存器")
                   ||(value == "字符串寄存器"))
                {
                    cbRegType.Text = value;
                }

                if (value == "普通寄存器")
                {
                    tbReadRegValue.Visible = true;
                    tbWriteRegValue.Visible = true;
                    btnReadReg.Visible = true;
                    tbWriteStringRegValue.Visible = false;

                }
                else
                {
                    tbReadRegValue.Visible = false;
                    tbWriteRegValue.Visible = false;
                    btnReadReg.Visible = false;
                    tbWriteStringRegValue.Visible = true;
                }
            }

            get
            {
                if ((cbRegType.Text != "普通寄存器")
                    && (cbRegType.Text != "字符串寄存器"))
                { 
                    cbRegType.Text = "普通寄存器";
                }
                return cbRegType.Text;
            }
        }

        /// <summary>
        /// 寄存器描述
        /// </summary>
        public string RegisterDescription
        {
            set {tbRegName.Text = value;}
            get {return tbRegName.Text;}
        }

        /// <summary>
        /// 寄存器ID
        /// </summary>
        public UInt16 RegisterID
        {
            get {return Convert.ToUInt16(tbRegID.Text);}
            set {tbRegID.Text = value.ToString();}
        }

        /// <summary>
        /// 写寄存器值
        /// </summary>
        public UInt32 RegisterWriteValue
        {
            get {return Convert.ToUInt32(tbWriteRegValue.Text);}
            set {tbWriteRegValue.Text = value.ToString();}
        }

        /// <summary>
        /// 读寄存器值
        /// </summary>
        public UInt32 RegisterReadValue
        {
            get {return Convert.ToUInt32(tbReadRegValue.Text);}
            set {tbReadRegValue.Text = value.ToString();}
        }

        /// <summary>
        /// 写字符串寄存器
        /// </summary>
        public string RegisterWriteStringValue
        {
            get {return tbWriteStringRegValue.Text;}
            set {tbWriteStringRegValue.Text = value;}
        }

        /// <summary>
        /// 写寄存器有效
        /// </summary>
        public bool RegisterWriteValid { set; get; }

        /// <summary>
        /// 读寄存器有效
        /// </summary>
        public bool RegisterReadValid { set; get; }

        /// <summary>
        /// 写字符串寄存器有效
        /// </summary>
        public bool RegisterWriteStringValid { set; get; }

        public CommandLine(LineItem line)
        {
            object sender = new object();
            EventArgs e = new EventArgs();

            InitializeComponent();

            if (line.IsSelect == "true")
            {
                this.IsSelect = true;
            }
            else
            {
                this.IsSelect = false;
            }

            this.Index = (UInt16)line.Index;
            this.RegisterType = line.RegType;
            this.RegisterDescription = line.Name;
            if (line.RegID == "")
            {
                this.RegisterID = 0;
            }
            else
            {
                this.RegisterID = Convert.ToUInt16(line.RegID);
            }

            if (line.WValue == "")
            {
                this.RegisterWriteValue = 0;
            }
            else
            {
                this.RegisterWriteValue = Convert.ToUInt32(line.WValue);
            }

            if (line.RValue == "")
            {
                this.RegisterReadValue = 0;
            }
            else
            {
                this.RegisterReadValue = Convert.ToUInt32(line.RValue);
            }

            this.RegisterWriteStringValue = line.WSValue;

            tbRegID_TextChanged(sender, e);
        }
#if false
        public void CommandLine_Load(LineItem line)
        {
            EventArgs e = new EventArgs();

            if (line.IsSelect == "true")
            {
                cbSelect.Checked = true;
            }
            else
            {
                cbSelect.Checked = false;
            }

            tbRegName.Text = line.Name;
            tbRegID.Text = line.RegID;
            tbWriteRegValue.Text = line.WValue;
            tbReadRegValue.Text = line.RValue;
            //cbReadFormat.Text = line.RFormat;

            Encode(0,e);
        }

        public void Encode(object sender, EventArgs e)
        {
            if ((tbRegID.Text == "") || (tbRegID.Text == "0"))
            {
                WriteRegValid = false;
                ReadRegValid = false;
            }
            else
            {
                 ReadRegValid = true;
                if (tbWriteRegValue.Text != "")
                {
                    UInt16 reg_id = 0;
                    UInt32 value = 0;

                    WriteRegValid = true;
                    
                    reg_id = Convert.ToUInt16(tbRegID.Text);
                    WriteRegEncodeArray[0] = (byte)(reg_id >> 8);
                    WriteRegEncodeArray[1] = (byte)reg_id;
                    value = Convert.ToUInt32(tbWriteRegValue.Text);
                    WriteRegEncodeArray[2] = (byte)(value >> 24);
                    WriteRegEncodeArray[3] = (byte)(value >> 16);
                    WriteRegEncodeArray[4] = (byte)(value >> 8);
                    WriteRegEncodeArray[5] = (byte)value;

                    ReadRegEncodeArray[0] = (byte)(reg_id >> 8);
                    ReadRegEncodeArray[1] = (byte)reg_id;
                }
                else
                {
                    WriteRegValid = false;
                }
            }
        }
#endif

        private void tbRegName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbWriteRegValue_TextChanged(object sender, EventArgs e)
        {
            if ((tbWriteRegValue.Text != "") && (tbRegID.Text != ""))
            {
                RegisterWriteValid = true;
            }
            else
            {
                RegisterWriteValid = false;
            }
        }

        private void tbWriteStringRegValue_TextChanged(object sender, EventArgs e)
        {
            if ((tbWriteStringRegValue.Text != "") && (tbRegID.Text != ""))
            {
                RegisterWriteStringValid = true;
            }
            else
            {
                RegisterWriteStringValid = false;
            }
        }

        private void tbRegID_TextChanged(object sender, EventArgs e)
        {
            if (tbRegID.Text != "")
            {
                RegisterReadValid = true;
            }
            else
            {
                RegisterReadValid = false;
            }

            if ((tbWriteRegValue.Text != "") && (tbRegID.Text != ""))
            {
                RegisterWriteValid = true;
            }
            else
            {
                RegisterWriteValid = false;
            }

            if ((tbWriteStringRegValue.Text != "") && (tbRegID.Text != ""))
            {
                RegisterWriteStringValid = true;
            }
            else
            {
                RegisterWriteStringValid = false;
            }
        }
    }
}
