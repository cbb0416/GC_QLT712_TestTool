namespace Cmd
{
    partial class Command
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
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbResp = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbWriteStringReg = new System.Windows.Forms.RadioButton();
            this.rbWriteReg = new System.Windows.Forms.RadioButton();
            this.rbReadReg = new System.Windows.Forms.RadioButton();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(591, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(21, 508);
            this.vScrollBar1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.tbSend);
            this.groupBox1.Location = new System.Drawing.Point(3, 502);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(608, 97);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(457, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "生成";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbResp);
            this.panel2.Location = new System.Drawing.Point(457, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(148, 26);
            this.panel2.TabIndex = 6;
            // 
            // cbResp
            // 
            this.cbResp.AutoSize = true;
            this.cbResp.Location = new System.Drawing.Point(3, 3);
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
            this.panel1.Location = new System.Drawing.Point(457, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(148, 26);
            this.panel1.TabIndex = 5;
            // 
            // rbWriteStringReg
            // 
            this.rbWriteStringReg.AutoSize = true;
            this.rbWriteStringReg.Location = new System.Drawing.Point(72, 3);
            this.rbWriteStringReg.Name = "rbWriteStringReg";
            this.rbWriteStringReg.Size = new System.Drawing.Size(71, 16);
            this.rbWriteStringReg.TabIndex = 4;
            this.rbWriteStringReg.Text = "写字符串";
            this.rbWriteStringReg.UseVisualStyleBackColor = true;
            // 
            // rbWriteReg
            // 
            this.rbWriteReg.AutoSize = true;
            this.rbWriteReg.Checked = true;
            this.rbWriteReg.Location = new System.Drawing.Point(3, 3);
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
            this.rbReadReg.Location = new System.Drawing.Point(38, 3);
            this.rbReadReg.Name = "rbReadReg";
            this.rbReadReg.Size = new System.Drawing.Size(35, 16);
            this.rbReadReg.TabIndex = 3;
            this.rbReadReg.Text = "读";
            this.rbReadReg.UseVisualStyleBackColor = true;
            // 
            // tbSend
            // 
            this.tbSend.Location = new System.Drawing.Point(6, 14);
            this.tbSend.Multiline = true;
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(445, 77);
            this.tbSend.TabIndex = 0;
            // 
            // Command
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.vScrollBar1);
            this.Name = "Command";
            this.Size = new System.Drawing.Size(612, 602);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.RadioButton rbWriteStringReg;
        private System.Windows.Forms.RadioButton rbReadReg;
        private System.Windows.Forms.RadioButton rbWriteReg;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbResp;
        private System.Windows.Forms.Button button1;

    }
}
