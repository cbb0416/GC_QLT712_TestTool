namespace SXWUartProtocol
{
    partial class CommandList
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.cbResp = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbWriteStringReg = new System.Windows.Forms.RadioButton();
            this.rbWriteReg = new System.Windows.Forms.RadioButton();
            this.rbReadReg = new System.Windows.Forms.RadioButton();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.scCommand = new System.Windows.Forms.SplitContainer();
            this.cbVersion = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbVerifyChecksum = new System.Windows.Forms.RadioButton();
            this.rbVerifyCRC = new System.Windows.Forms.RadioButton();
            this.rbVerifyNone = new System.Windows.Forms.RadioButton();
            this.cbSelectAll = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelStringFormat = new System.Windows.Forms.Panel();
            this.rbStringFormat_UTF8 = new System.Windows.Forms.RadioButton();
            this.rbStringFormat_GB2312 = new System.Windows.Forms.RadioButton();
            this.rbStringFormat_ASCII = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scCommand)).BeginInit();
            this.scCommand.Panel2.SuspendLayout();
            this.scCommand.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelStringFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(443, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 48);
            this.button1.TabIndex = 7;
            this.button1.Text = "生成";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbResp
            // 
            this.cbResp.AutoSize = true;
            this.cbResp.Location = new System.Drawing.Point(193, 9);
            this.cbResp.Name = "cbResp";
            this.cbResp.Size = new System.Drawing.Size(48, 16);
            this.cbResp.TabIndex = 0;
            this.cbResp.Text = "回复";
            this.cbResp.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbWriteStringReg);
            this.panel1.Controls.Add(this.rbWriteReg);
            this.panel1.Controls.Add(this.rbReadReg);
            this.panel1.Location = new System.Drawing.Point(6, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(148, 26);
            this.panel1.TabIndex = 5;
            // 
            // rbWriteStringReg
            // 
            this.rbWriteStringReg.AutoSize = true;
            this.rbWriteStringReg.Location = new System.Drawing.Point(72, 5);
            this.rbWriteStringReg.Name = "rbWriteStringReg";
            this.rbWriteStringReg.Size = new System.Drawing.Size(71, 16);
            this.rbWriteStringReg.TabIndex = 4;
            this.rbWriteStringReg.Text = "写字符串";
            this.rbWriteStringReg.UseVisualStyleBackColor = true;
            this.rbWriteStringReg.CheckedChanged += new System.EventHandler(this.rbWriteStringReg_CheckedChanged);
            // 
            // rbWriteReg
            // 
            this.rbWriteReg.AutoSize = true;
            this.rbWriteReg.Checked = true;
            this.rbWriteReg.Location = new System.Drawing.Point(3, 5);
            this.rbWriteReg.Name = "rbWriteReg";
            this.rbWriteReg.Size = new System.Drawing.Size(35, 16);
            this.rbWriteReg.TabIndex = 2;
            this.rbWriteReg.TabStop = true;
            this.rbWriteReg.Text = "写";
            this.rbWriteReg.UseVisualStyleBackColor = true;
            // 
            // rbReadReg
            // 
            this.rbReadReg.AutoSize = true;
            this.rbReadReg.Location = new System.Drawing.Point(38, 5);
            this.rbReadReg.Name = "rbReadReg";
            this.rbReadReg.Size = new System.Drawing.Size(35, 16);
            this.rbReadReg.TabIndex = 3;
            this.rbReadReg.Text = "读";
            this.rbReadReg.UseVisualStyleBackColor = true;
            // 
            // tbSend
            // 
            this.tbSend.Location = new System.Drawing.Point(5, 56);
            this.tbSend.Multiline = true;
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(509, 47);
            this.tbSend.TabIndex = 0;
            // 
            // scCommand
            // 
            this.scCommand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scCommand.Location = new System.Drawing.Point(0, 25);
            this.scCommand.Name = "scCommand";
            this.scCommand.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scCommand.Panel1
            // 
            this.scCommand.Panel1.AutoScroll = true;
            this.scCommand.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.scCommand_Panel1_Paint);
            // 
            // scCommand.Panel2
            // 
            this.scCommand.Panel2.Controls.Add(this.panelStringFormat);
            this.scCommand.Panel2.Controls.Add(this.cbVersion);
            this.scCommand.Panel2.Controls.Add(this.panel2);
            this.scCommand.Panel2.Controls.Add(this.cbResp);
            this.scCommand.Panel2.Controls.Add(this.button1);
            this.scCommand.Panel2.Controls.Add(this.tbSend);
            this.scCommand.Panel2.Controls.Add(this.panel1);
            this.scCommand.Size = new System.Drawing.Size(519, 605);
            this.scCommand.SplitterDistance = 495;
            this.scCommand.TabIndex = 2;
            // 
            // cbVersion
            // 
            this.cbVersion.AutoSize = true;
            this.cbVersion.Location = new System.Drawing.Point(241, 9);
            this.cbVersion.Name = "cbVersion";
            this.cbVersion.Size = new System.Drawing.Size(48, 16);
            this.cbVersion.TabIndex = 9;
            this.cbVersion.Text = "版本";
            this.cbVersion.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbVerifyChecksum);
            this.panel2.Controls.Add(this.rbVerifyCRC);
            this.panel2.Controls.Add(this.rbVerifyNone);
            this.panel2.Location = new System.Drawing.Point(190, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(194, 26);
            this.panel2.TabIndex = 8;
            // 
            // rbVerifyChecksum
            // 
            this.rbVerifyChecksum.AutoSize = true;
            this.rbVerifyChecksum.Location = new System.Drawing.Point(116, 5);
            this.rbVerifyChecksum.Name = "rbVerifyChecksum";
            this.rbVerifyChecksum.Size = new System.Drawing.Size(71, 16);
            this.rbVerifyChecksum.TabIndex = 2;
            this.rbVerifyChecksum.TabStop = true;
            this.rbVerifyChecksum.Text = "Checksum";
            this.rbVerifyChecksum.UseVisualStyleBackColor = true;
            // 
            // rbVerifyCRC
            // 
            this.rbVerifyCRC.AutoSize = true;
            this.rbVerifyCRC.Checked = true;
            this.rbVerifyCRC.Location = new System.Drawing.Point(69, 5);
            this.rbVerifyCRC.Name = "rbVerifyCRC";
            this.rbVerifyCRC.Size = new System.Drawing.Size(41, 16);
            this.rbVerifyCRC.TabIndex = 1;
            this.rbVerifyCRC.TabStop = true;
            this.rbVerifyCRC.Text = "CRC";
            this.rbVerifyCRC.UseVisualStyleBackColor = true;
            this.rbVerifyCRC.CheckedChanged += new System.EventHandler(this.rbVerifyCRC_CheckedChanged);
            // 
            // rbVerifyNone
            // 
            this.rbVerifyNone.AutoSize = true;
            this.rbVerifyNone.Location = new System.Drawing.Point(3, 5);
            this.rbVerifyNone.Name = "rbVerifyNone";
            this.rbVerifyNone.Size = new System.Drawing.Size(59, 16);
            this.rbVerifyNone.TabIndex = 0;
            this.rbVerifyNone.TabStop = true;
            this.rbVerifyNone.Text = "无校验";
            this.rbVerifyNone.UseVisualStyleBackColor = true;
            // 
            // cbSelectAll
            // 
            this.cbSelectAll.AutoSize = true;
            this.cbSelectAll.Location = new System.Drawing.Point(4, 3);
            this.cbSelectAll.Name = "cbSelectAll";
            this.cbSelectAll.Size = new System.Drawing.Size(48, 16);
            this.cbSelectAll.TabIndex = 3;
            this.cbSelectAll.Text = "全选";
            this.cbSelectAll.UseVisualStyleBackColor = true;
            this.cbSelectAll.CheckedChanged += new System.EventHandler(this.cbSelectAll_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "描述       寄存器ID      写值             读值";
            // 
            // panelStringFormat
            // 
            this.panelStringFormat.Controls.Add(this.rbStringFormat_UTF8);
            this.panelStringFormat.Controls.Add(this.rbStringFormat_GB2312);
            this.panelStringFormat.Controls.Add(this.rbStringFormat_ASCII);
            this.panelStringFormat.Enabled = false;
            this.panelStringFormat.Location = new System.Drawing.Point(6, 30);
            this.panelStringFormat.Name = "panelStringFormat";
            this.panelStringFormat.Size = new System.Drawing.Size(167, 26);
            this.panelStringFormat.TabIndex = 9;
            // 
            // rbStringFormat_UTF8
            // 
            this.rbStringFormat_UTF8.AutoSize = true;
            this.rbStringFormat_UTF8.Location = new System.Drawing.Point(112, 5);
            this.rbStringFormat_UTF8.Name = "rbStringFormat_UTF8";
            this.rbStringFormat_UTF8.Size = new System.Drawing.Size(53, 16);
            this.rbStringFormat_UTF8.TabIndex = 2;
            this.rbStringFormat_UTF8.TabStop = true;
            this.rbStringFormat_UTF8.Text = "UTF-8";
            this.rbStringFormat_UTF8.UseVisualStyleBackColor = true;
            // 
            // rbStringFormat_GB2312
            // 
            this.rbStringFormat_GB2312.AutoSize = true;
            this.rbStringFormat_GB2312.Checked = true;
            this.rbStringFormat_GB2312.Location = new System.Drawing.Point(54, 5);
            this.rbStringFormat_GB2312.Name = "rbStringFormat_GB2312";
            this.rbStringFormat_GB2312.Size = new System.Drawing.Size(59, 16);
            this.rbStringFormat_GB2312.TabIndex = 1;
            this.rbStringFormat_GB2312.TabStop = true;
            this.rbStringFormat_GB2312.Text = "GB2312";
            this.rbStringFormat_GB2312.UseVisualStyleBackColor = true;
            // 
            // rbStringFormat_ASCII
            // 
            this.rbStringFormat_ASCII.AutoSize = true;
            this.rbStringFormat_ASCII.Location = new System.Drawing.Point(3, 5);
            this.rbStringFormat_ASCII.Name = "rbStringFormat_ASCII";
            this.rbStringFormat_ASCII.Size = new System.Drawing.Size(53, 16);
            this.rbStringFormat_ASCII.TabIndex = 0;
            this.rbStringFormat_ASCII.TabStop = true;
            this.rbStringFormat_ASCII.Text = "ASCII";
            this.rbStringFormat_ASCII.UseVisualStyleBackColor = true;
            // 
            // CommandList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSelectAll);
            this.Controls.Add(this.scCommand);
            this.Name = "CommandList";
            this.Size = new System.Drawing.Size(522, 634);
            this.Load += new System.EventHandler(this.Command_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.scCommand.Panel2.ResumeLayout(false);
            this.scCommand.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scCommand)).EndInit();
            this.scCommand.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelStringFormat.ResumeLayout(false);
            this.panelStringFormat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.RadioButton rbWriteStringReg;
        private System.Windows.Forms.RadioButton rbReadReg;
        private System.Windows.Forms.RadioButton rbWriteReg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbResp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer scCommand;
        private System.Windows.Forms.CheckBox cbVersion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbVerifyChecksum;
        private System.Windows.Forms.RadioButton rbVerifyCRC;
        private System.Windows.Forms.RadioButton rbVerifyNone;
        private System.Windows.Forms.CheckBox cbSelectAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelStringFormat;
        private System.Windows.Forms.RadioButton rbStringFormat_UTF8;
        private System.Windows.Forms.RadioButton rbStringFormat_GB2312;
        private System.Windows.Forms.RadioButton rbStringFormat_ASCII;

    }
}
