namespace Cmd
{
    partial class CommandLine
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
            this.cbChecked = new System.Windows.Forms.CheckBox();
            this.tbRegName = new System.Windows.Forms.TextBox();
            this.tbRegID = new System.Windows.Forms.TextBox();
            this.tbWriteRegValue = new System.Windows.Forms.TextBox();
            this.btnWriteReg = new System.Windows.Forms.Button();
            this.btnReadReg = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.pnlEdit = new System.Windows.Forms.Panel();
            this.tbEditRegName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbEditRegID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEditRegType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbReadRegValue = new System.Windows.Forms.TextBox();
            this.cbReadFormat = new System.Windows.Forms.ComboBox();
            this.pnlEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbChecked
            // 
            this.cbChecked.AutoSize = true;
            this.cbChecked.Location = new System.Drawing.Point(3, 6);
            this.cbChecked.Name = "cbChecked";
            this.cbChecked.Size = new System.Drawing.Size(15, 14);
            this.cbChecked.TabIndex = 0;
            this.cbChecked.UseVisualStyleBackColor = true;
            this.cbChecked.CheckedChanged += new System.EventHandler(this.cbChecked_CheckedChanged);
            // 
            // tbRegName
            // 
            this.tbRegName.Location = new System.Drawing.Point(24, 3);
            this.tbRegName.Name = "tbRegName";
            this.tbRegName.Size = new System.Drawing.Size(100, 21);
            this.tbRegName.TabIndex = 1;
            // 
            // tbRegID
            // 
            this.tbRegID.Location = new System.Drawing.Point(126, 3);
            this.tbRegID.Name = "tbRegID";
            this.tbRegID.Size = new System.Drawing.Size(67, 21);
            this.tbRegID.TabIndex = 2;
            this.tbRegID.Enter += new System.EventHandler(this.Encode);
            // 
            // tbWriteRegValue
            // 
            this.tbWriteRegValue.Location = new System.Drawing.Point(196, 3);
            this.tbWriteRegValue.Name = "tbWriteRegValue";
            this.tbWriteRegValue.Size = new System.Drawing.Size(100, 21);
            this.tbWriteRegValue.TabIndex = 3;
            this.tbWriteRegValue.Enter += new System.EventHandler(this.Encode);
            // 
            // btnWriteReg
            // 
            this.btnWriteReg.Location = new System.Drawing.Point(421, 3);
            this.btnWriteReg.Name = "btnWriteReg";
            this.btnWriteReg.Size = new System.Drawing.Size(37, 23);
            this.btnWriteReg.TabIndex = 4;
            this.btnWriteReg.Text = "写";
            this.btnWriteReg.UseVisualStyleBackColor = true;
            this.btnWriteReg.Click += new System.EventHandler(this.Encode);
            this.btnWriteReg.Enter += new System.EventHandler(this.Encode);
            // 
            // btnReadReg
            // 
            this.btnReadReg.Location = new System.Drawing.Point(460, 3);
            this.btnReadReg.Name = "btnReadReg";
            this.btnReadReg.Size = new System.Drawing.Size(38, 23);
            this.btnReadReg.TabIndex = 6;
            this.btnReadReg.Text = "读";
            this.btnReadReg.UseVisualStyleBackColor = true;
            this.btnReadReg.Click += new System.EventHandler(this.Encode);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(500, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(43, 23);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // pnlEdit
            // 
            this.pnlEdit.Controls.Add(this.tbEditRegName);
            this.pnlEdit.Controls.Add(this.label3);
            this.pnlEdit.Controls.Add(this.tbEditRegID);
            this.pnlEdit.Controls.Add(this.label1);
            this.pnlEdit.Controls.Add(this.cbEditRegType);
            this.pnlEdit.Controls.Add(this.label2);
            this.pnlEdit.Location = new System.Drawing.Point(4, 32);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(578, 178);
            this.pnlEdit.TabIndex = 9;
            // 
            // tbEditRegName
            // 
            this.tbEditRegName.Location = new System.Drawing.Point(92, 56);
            this.tbEditRegName.Multiline = true;
            this.tbEditRegName.Name = "tbEditRegName";
            this.tbEditRegName.Size = new System.Drawing.Size(97, 46);
            this.tbEditRegName.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "寄存器类型:";
            // 
            // tbEditRegID
            // 
            this.tbEditRegID.Location = new System.Drawing.Point(92, 31);
            this.tbEditRegID.Name = "tbEditRegID";
            this.tbEditRegID.Size = new System.Drawing.Size(97, 21);
            this.tbEditRegID.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "寄存器ID:";
            // 
            // cbEditRegType
            // 
            this.cbEditRegType.FormattingEnabled = true;
            this.cbEditRegType.Items.AddRange(new object[] {
            "数值",
            "有限数值",
            "开关",
            "字符串"});
            this.cbEditRegType.Location = new System.Drawing.Point(92, 6);
            this.cbEditRegType.Name = "cbEditRegType";
            this.cbEditRegType.Size = new System.Drawing.Size(97, 20);
            this.cbEditRegType.TabIndex = 9;
            this.cbEditRegType.Text = "数值";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "寄存器名称:";
            // 
            // tbReadRegValue
            // 
            this.tbReadRegValue.Location = new System.Drawing.Point(298, 3);
            this.tbReadRegValue.Name = "tbReadRegValue";
            this.tbReadRegValue.ReadOnly = true;
            this.tbReadRegValue.Size = new System.Drawing.Size(100, 21);
            this.tbReadRegValue.TabIndex = 11;
            // 
            // cbReadFormat
            // 
            this.cbReadFormat.FormattingEnabled = true;
            this.cbReadFormat.Items.AddRange(new object[] {
            "Bin",
            "Dec",
            "Hex"});
            this.cbReadFormat.Location = new System.Drawing.Point(398, 3);
            this.cbReadFormat.Name = "cbReadFormat";
            this.cbReadFormat.Size = new System.Drawing.Size(20, 20);
            this.cbReadFormat.TabIndex = 12;
            this.cbReadFormat.Text = "Dec";
            // 
            // CommandLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbReadFormat);
            this.Controls.Add(this.tbReadRegValue);
            this.Controls.Add(this.pnlEdit);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnReadReg);
            this.Controls.Add(this.btnWriteReg);
            this.Controls.Add(this.tbWriteRegValue);
            this.Controls.Add(this.tbRegID);
            this.Controls.Add(this.tbRegName);
            this.Controls.Add(this.cbChecked);
            this.Name = "CommandLine";
            this.Size = new System.Drawing.Size(588, 29);
            this.pnlEdit.ResumeLayout(false);
            this.pnlEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbChecked;
        private System.Windows.Forms.TextBox tbRegName;
        private System.Windows.Forms.TextBox tbRegID;
        private System.Windows.Forms.TextBox tbWriteRegValue;
        private System.Windows.Forms.Button btnWriteReg;
        private System.Windows.Forms.Button btnReadReg;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel pnlEdit;
        private System.Windows.Forms.TextBox tbEditRegName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbEditRegID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbEditRegType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbReadRegValue;
        private System.Windows.Forms.ComboBox cbReadFormat;
    }
}
