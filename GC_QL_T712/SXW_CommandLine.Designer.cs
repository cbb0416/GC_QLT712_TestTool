namespace SXWUartProtocol
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
            this.cbSelect = new System.Windows.Forms.CheckBox();
            this.tbRegName = new System.Windows.Forms.TextBox();
            this.tbRegID = new System.Windows.Forms.TextBox();
            this.tbWriteRegValue = new System.Windows.Forms.TextBox();
            this.btnWriteReg = new System.Windows.Forms.Button();
            this.btnReadReg = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.pnlEdit = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbEditRegType = new System.Windows.Forms.ComboBox();
            this.tbReadRegValue = new System.Windows.Forms.TextBox();
            this.lblIndex = new System.Windows.Forms.Label();
            this.cbRegType = new System.Windows.Forms.ComboBox();
            this.tbWriteStringRegValue = new System.Windows.Forms.TextBox();
            this.pnlEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbSelect
            // 
            this.cbSelect.AutoSize = true;
            this.cbSelect.Location = new System.Drawing.Point(3, 4);
            this.cbSelect.Name = "cbSelect";
            this.cbSelect.Size = new System.Drawing.Size(15, 14);
            this.cbSelect.TabIndex = 0;
            this.cbSelect.UseVisualStyleBackColor = true;
            // 
            // tbRegName
            // 
            this.tbRegName.Location = new System.Drawing.Point(117, 1);
            this.tbRegName.Name = "tbRegName";
            this.tbRegName.Size = new System.Drawing.Size(100, 21);
            this.tbRegName.TabIndex = 1;
            this.tbRegName.TextChanged += new System.EventHandler(this.tbRegName_TextChanged);
            // 
            // tbRegID
            // 
            this.tbRegID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbRegID.Location = new System.Drawing.Point(218, 1);
            this.tbRegID.Name = "tbRegID";
            this.tbRegID.Size = new System.Drawing.Size(41, 21);
            this.tbRegID.TabIndex = 2;
            this.tbRegID.TextChanged += new System.EventHandler(this.tbRegID_TextChanged);
            // 
            // tbWriteRegValue
            // 
            this.tbWriteRegValue.Location = new System.Drawing.Point(260, 1);
            this.tbWriteRegValue.Name = "tbWriteRegValue";
            this.tbWriteRegValue.Size = new System.Drawing.Size(100, 21);
            this.tbWriteRegValue.TabIndex = 3;
            this.tbWriteRegValue.TextChanged += new System.EventHandler(this.tbWriteRegValue_TextChanged);
            // 
            // btnWriteReg
            // 
            this.btnWriteReg.Location = new System.Drawing.Point(488, 1);
            this.btnWriteReg.Name = "btnWriteReg";
            this.btnWriteReg.Size = new System.Drawing.Size(26, 21);
            this.btnWriteReg.TabIndex = 4;
            this.btnWriteReg.Text = "写";
            this.btnWriteReg.UseVisualStyleBackColor = true;
            // 
            // btnReadReg
            // 
            this.btnReadReg.Location = new System.Drawing.Point(461, 1);
            this.btnReadReg.Name = "btnReadReg";
            this.btnReadReg.Size = new System.Drawing.Size(27, 21);
            this.btnReadReg.TabIndex = 6;
            this.btnReadReg.Text = "读";
            this.btnReadReg.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEdit.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEdit.Location = new System.Drawing.Point(401, -41);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(17, 21);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "...";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // pnlEdit
            // 
            this.pnlEdit.Controls.Add(this.label3);
            this.pnlEdit.Controls.Add(this.cbEditRegType);
            this.pnlEdit.Controls.Add(this.btnEdit);
            this.pnlEdit.Location = new System.Drawing.Point(4, 32);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(476, 55);
            this.pnlEdit.TabIndex = 9;
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
            // tbReadRegValue
            // 
            this.tbReadRegValue.Location = new System.Drawing.Point(361, 1);
            this.tbReadRegValue.Name = "tbReadRegValue";
            this.tbReadRegValue.ReadOnly = true;
            this.tbReadRegValue.Size = new System.Drawing.Size(100, 21);
            this.tbReadRegValue.TabIndex = 11;
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Location = new System.Drawing.Point(18, 5);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(17, 12);
            this.lblIndex.TabIndex = 12;
            this.lblIndex.Text = "1:";
            // 
            // cbRegType
            // 
            this.cbRegType.FormattingEnabled = true;
            this.cbRegType.Items.AddRange(new object[] {
            "普通寄存器",
            "字符串寄存器"});
            this.cbRegType.Location = new System.Drawing.Point(45, 1);
            this.cbRegType.Name = "cbRegType";
            this.cbRegType.Size = new System.Drawing.Size(70, 20);
            this.cbRegType.TabIndex = 13;
            this.cbRegType.Text = "普通寄存器";
            // 
            // tbWriteStringRegValue
            // 
            this.tbWriteStringRegValue.Location = new System.Drawing.Point(260, 1);
            this.tbWriteStringRegValue.Name = "tbWriteStringRegValue";
            this.tbWriteStringRegValue.Size = new System.Drawing.Size(228, 21);
            this.tbWriteStringRegValue.TabIndex = 14;
            this.tbWriteStringRegValue.TextChanged += new System.EventHandler(this.tbWriteStringRegValue_TextChanged);
            // 
            // CommandLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.cbRegType);
            this.Controls.Add(this.lblIndex);
            this.Controls.Add(this.pnlEdit);
            this.Controls.Add(this.btnReadReg);
            this.Controls.Add(this.btnWriteReg);
            this.Controls.Add(this.tbRegID);
            this.Controls.Add(this.tbRegName);
            this.Controls.Add(this.cbSelect);
            this.Controls.Add(this.tbWriteRegValue);
            this.Controls.Add(this.tbReadRegValue);
            this.Controls.Add(this.tbWriteStringRegValue);
            this.Name = "CommandLine";
            this.Size = new System.Drawing.Size(517, 22);
            this.pnlEdit.ResumeLayout(false);
            this.pnlEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbSelect;
        private System.Windows.Forms.TextBox tbRegName;
        private System.Windows.Forms.TextBox tbRegID;
        private System.Windows.Forms.TextBox tbWriteRegValue;
        private System.Windows.Forms.Button btnWriteReg;
        private System.Windows.Forms.Button btnReadReg;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel pnlEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbEditRegType;
        private System.Windows.Forms.TextBox tbReadRegValue;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.ComboBox cbRegType;
        private System.Windows.Forms.TextBox tbWriteStringRegValue;
    }
}
