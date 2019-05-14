namespace Number
{
    partial class Number
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
            this.lbl_Name = new System.Windows.Forms.Label();
            this.tBox_Number = new System.Windows.Forms.TextBox();
            this.tBar_Number = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_Number)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(3, 3);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(29, 12);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "Name";
            // 
            // tBox_Number
            // 
            this.tBox_Number.Location = new System.Drawing.Point(6, 12);
            this.tBox_Number.Name = "tBox_Number";
            this.tBox_Number.Size = new System.Drawing.Size(61, 21);
            this.tBox_Number.TabIndex = 1;
            this.tBox_Number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBox_Number_KeyPress);
            this.tBox_Number.Leave += new System.EventHandler(this.tBox_Number_Leave);
            // 
            // tBar_Number
            // 
            this.tBar_Number.Location = new System.Drawing.Point(64, 12);
            this.tBar_Number.Name = "tBar_Number";
            this.tBar_Number.Size = new System.Drawing.Size(104, 45);
            this.tBar_Number.TabIndex = 2;
            this.tBar_Number.MouseLeave += new System.EventHandler(this.tBar_Number_MouseLeave);
            this.tBar_Number.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tBar_Number_MouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tBox_Number);
            this.groupBox1.Controls.Add(this.tBar_Number);
            this.groupBox1.Location = new System.Drawing.Point(5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 41);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // Number
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_Name);
            this.Name = "Number";
            this.Size = new System.Drawing.Size(199, 44);
            ((System.ComponentModel.ISupportInitialize)(this.tBar_Number)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.TextBox tBox_Number;
        private System.Windows.Forms.TrackBar tBar_Number;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
