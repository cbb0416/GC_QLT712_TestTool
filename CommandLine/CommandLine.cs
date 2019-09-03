using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cmd
{
    public partial class CommandLine: UserControl
    {
        public bool SelectValid = false;
        public bool WriteRegValid = false;
        public bool ReadRegValid = false;
        public byte[] WriteRegEncodeArray = new byte[6];
        public byte[] ReadRegEncodeArray = new byte[2];


        public CommandLine()
        {
            InitializeComponent();
            SelectValid = false;
            WriteRegValid = false;
            ReadRegValid = false;

            cbChecked.Checked = false;
            tbRegName.Text = "";
            tbRegID.Text = "";
            tbWriteRegValue.Text = "";
            tbReadRegValue.Text = "";
            cbReadFormat.Text = "";
        }

        public void Load(LineItem line)
        {
            EventArgs e = new EventArgs();

            if (line.IsSelect == "true")
            {
                cbChecked.Checked = true;
                SelectValid = true;
            }
            else
            {
                cbChecked.Checked = false;
                SelectValid = false;
            }

            tbRegName.Text = line.Name;
            tbRegID.Text = line.RegID;
            tbWriteRegValue.Text = line.WValue;
            tbReadRegValue.Text = line.RValue;
            cbReadFormat.Text = line.RFormat;

            Encode(0,e);
        }

        public void Init(LineItem line)
        {
            SelectValid = false;
            line.IsSelect = "false";
            line.Name = null;
            line.RegID = null;
            line.RFormat = "Dec";
            line.RValue = null;
            line.WValue = null;
        }

        public void Encode(object sender, EventArgs e)
        {
            if (tbRegID.Text == "")
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
                }
                else
                {
                    WriteRegValid = false;
                }
            }
        }

        private void cbChecked_CheckedChanged(object sender, EventArgs e)
        {
            if (cbChecked.Checked == true)
            {
                SelectValid = true;
            }
            else
            {
                SelectValid = false;
            }
        }
    }
}
