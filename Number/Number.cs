using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Number
{
    public partial class Number: UserControl
    {
        [Category("配置")]
        [Description("显示名称")]
        [DefaultValue("Name:")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string _Text
        {
            get
            { 
                return this.lbl_Name.Text; 
            }
            set
            {
                this.lbl_Name.Text = value;
            }
        }

        [Category("配置")]
        [Description("最小值")]
        [DefaultValue(0)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 _Min 
        {
            get 
            {
                return this.tBar_Number.Minimum;
            }
            set
            {
                this.tBar_Number.Minimum = value;
            }
        }

        [Category("配置")]
        [Description("最大值")]
        [DefaultValue(100)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 _Max 
        { 
            get
            {
                return this.tBar_Number.Maximum;
            }
            set
            {
                this.tBar_Number.Maximum = value;
            }
        }

        [Category("配置")]
        [Description("起始bit位")]
        [DefaultValue(0)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 _StartBit { get; set; }

        [Category("配置")]
        [Description("bit位数")]
        [DefaultValue(0)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 _BitLen { get; set; }

        [Category("配置")]
        [Description("精度")]
        [DefaultValue(0)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 _Resolution { get; set; }

        [Category("配置")]
        [Description("数值")]
        [DefaultValue(0)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 _Value 
        {
            get
            {
                return this.tBar_Number.Value;
            }
            set
            {
                this.tBox_Number.Text = value.ToString();
                this.tBar_Number.Value = value;
            }
        }
        
        public Number()
        {
            InitializeComponent();
            this._Text = "Name:";
            this._Min = 0;
            this._Max = 100;
            this._StartBit = 0;
            this._BitLen = 8;
            this._Resolution = 1;
        }

        private void tBox_Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.tBar_Number.Value = int.Parse(tBox_Number.Text);
            }
        }

        private void tBar_Number_Leave(object sender, EventArgs e)
        {
            tBox_Number.Text = this.tBar_Number.Value.ToString();
        }

        private void tBar_Number_MouseLeave(object sender, EventArgs e)
        {
            tBox_Number.Text = this.tBar_Number.Value.ToString();
        }

        private void tBar_Number_MouseMove(object sender, MouseEventArgs e)
        {
            tBox_Number.Text = this.tBar_Number.Value.ToString();
        }

        private void tBox_Number_Leave(object sender, EventArgs e)
        {
            tBox_Number.Text = this.tBar_Number.Value.ToString();
        }

    }
}
