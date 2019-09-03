namespace GC_QL_T15
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_SerialPort = new System.Windows.Forms.ComboBox();
            this.button_SerialOpenClose = new System.Windows.Forms.Button();
            this.button_SerialScan = new System.Windows.Forms.Button();
            this.btnSaveJson = new System.Windows.Forms.Button();
            this.btnOpenJson = new System.Windows.Forms.Button();
            this.tbJsonFileDir = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSend = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.串口设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlQuickSet = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabpageSWXUartCmd = new System.Windows.Forms.TabPage();
            this.tbRecv = new System.Windows.Forms.TextBox();
            this.scSerialPortOpera = new System.Windows.Forms.SplitContainer();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.tmrRecvCpltCheckTimer = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbRecvHex = new System.Windows.Forms.RadioButton();
            this.rbRecvAscii = new System.Windows.Forms.RadioButton();
            this.cbRecvTime = new System.Windows.Forms.CheckBox();
            this.btnRecvClear = new System.Windows.Forms.Button();
            this.rbSendAscii = new System.Windows.Forms.RadioButton();
            this.rbSendHex = new System.Windows.Forms.RadioButton();
            this.btnSendClear = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.pnlQuickSet.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scSerialPortOpera)).BeginInit();
            this.scSerialPortOpera.Panel1.SuspendLayout();
            this.scSerialPortOpera.Panel2.SuspendLayout();
            this.scSerialPortOpera.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(20, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "Port:";
            // 
            // comboBox_SerialPort
            // 
            this.comboBox_SerialPort.FormattingEnabled = true;
            this.comboBox_SerialPort.Location = new System.Drawing.Point(60, 13);
            this.comboBox_SerialPort.Name = "comboBox_SerialPort";
            this.comboBox_SerialPort.Size = new System.Drawing.Size(65, 20);
            this.comboBox_SerialPort.TabIndex = 14;
            // 
            // button_SerialOpenClose
            // 
            this.button_SerialOpenClose.Location = new System.Drawing.Point(31, 165);
            this.button_SerialOpenClose.Name = "button_SerialOpenClose";
            this.button_SerialOpenClose.Size = new System.Drawing.Size(103, 59);
            this.button_SerialOpenClose.TabIndex = 15;
            this.button_SerialOpenClose.Text = "打开";
            this.button_SerialOpenClose.UseVisualStyleBackColor = true;
            this.button_SerialOpenClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_SerialScan
            // 
            this.button_SerialScan.Location = new System.Drawing.Point(31, 66);
            this.button_SerialScan.Name = "button_SerialScan";
            this.button_SerialScan.Size = new System.Drawing.Size(103, 60);
            this.button_SerialScan.TabIndex = 16;
            this.button_SerialScan.Text = "扫描";
            this.button_SerialScan.UseVisualStyleBackColor = true;
            this.button_SerialScan.Click += new System.EventHandler(this.button_SerialScan_Click);
            // 
            // btnSaveJson
            // 
            this.btnSaveJson.Location = new System.Drawing.Point(705, 5);
            this.btnSaveJson.Name = "btnSaveJson";
            this.btnSaveJson.Size = new System.Drawing.Size(45, 21);
            this.btnSaveJson.TabIndex = 23;
            this.btnSaveJson.Text = "保存";
            this.btnSaveJson.UseVisualStyleBackColor = true;
            // 
            // btnOpenJson
            // 
            this.btnOpenJson.Location = new System.Drawing.Point(657, 5);
            this.btnOpenJson.Name = "btnOpenJson";
            this.btnOpenJson.Size = new System.Drawing.Size(42, 21);
            this.btnOpenJson.TabIndex = 22;
            this.btnOpenJson.Text = "打开";
            this.btnOpenJson.UseVisualStyleBackColor = true;
            // 
            // tbJsonFileDir
            // 
            this.tbJsonFileDir.Location = new System.Drawing.Point(347, 4);
            this.tbJsonFileDir.Name = "tbJsonFileDir";
            this.tbJsonFileDir.Size = new System.Drawing.Size(304, 21);
            this.tbJsonFileDir.TabIndex = 21;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(676, 3);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(79, 100);
            this.btnSend.TabIndex = 24;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 686);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1287, 22);
            this.statusStrip1.TabIndex = 25;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1287, 25);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.串口设置ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 串口设置ToolStripMenuItem
            // 
            this.串口设置ToolStripMenuItem.Name = "串口设置ToolStripMenuItem";
            this.串口设置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.串口设置ToolStripMenuItem.Text = "串口设置";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // pnlQuickSet
            // 
            this.pnlQuickSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQuickSet.Controls.Add(this.tbJsonFileDir);
            this.pnlQuickSet.Controls.Add(this.btnOpenJson);
            this.pnlQuickSet.Controls.Add(this.btnSaveJson);
            this.pnlQuickSet.Location = new System.Drawing.Point(1, 23);
            this.pnlQuickSet.Name = "pnlQuickSet";
            this.pnlQuickSet.Size = new System.Drawing.Size(755, 31);
            this.pnlQuickSet.TabIndex = 27;
            this.pnlQuickSet.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlQuickSet_Paint);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabpageSWXUartCmd);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.Location = new System.Drawing.Point(758, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(529, 661);
            this.tabControl1.TabIndex = 28;
            // 
            // tabpageSWXUartCmd
            // 
            this.tabpageSWXUartCmd.BackColor = System.Drawing.SystemColors.Control;
            this.tabpageSWXUartCmd.Location = new System.Drawing.Point(4, 22);
            this.tabpageSWXUartCmd.Name = "tabpageSWXUartCmd";
            this.tabpageSWXUartCmd.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageSWXUartCmd.Size = new System.Drawing.Size(521, 635);
            this.tabpageSWXUartCmd.TabIndex = 0;
            this.tabpageSWXUartCmd.Text = "速显微串口协议命令";
            // 
            // tbRecv
            // 
            this.tbRecv.Location = new System.Drawing.Point(172, 0);
            this.tbRecv.Multiline = true;
            this.tbRecv.Name = "tbRecv";
            this.tbRecv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbRecv.Size = new System.Drawing.Size(583, 517);
            this.tbRecv.TabIndex = 29;
            this.tbRecv.WordWrap = false;
            // 
            // scSerialPortOpera
            // 
            this.scSerialPortOpera.Location = new System.Drawing.Point(1, 55);
            this.scSerialPortOpera.Name = "scSerialPortOpera";
            this.scSerialPortOpera.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scSerialPortOpera.Panel1
            // 
            this.scSerialPortOpera.Panel1.Controls.Add(this.panel2);
            this.scSerialPortOpera.Panel1.Controls.Add(this.panel1);
            this.scSerialPortOpera.Panel1.Controls.Add(this.tbRecv);
            // 
            // scSerialPortOpera.Panel2
            // 
            this.scSerialPortOpera.Panel2.Controls.Add(this.panel3);
            this.scSerialPortOpera.Panel2.Controls.Add(this.tbSend);
            this.scSerialPortOpera.Panel2.Controls.Add(this.btnSend);
            this.scSerialPortOpera.Size = new System.Drawing.Size(755, 628);
            this.scSerialPortOpera.SplitterDistance = 518;
            this.scSerialPortOpera.TabIndex = 29;
            // 
            // tbSend
            // 
            this.tbSend.Location = new System.Drawing.Point(172, 3);
            this.tbSend.Multiline = true;
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(498, 100);
            this.tbSend.TabIndex = 25;
            // 
            // tmrRecvCpltCheckTimer
            // 
            this.tmrRecvCpltCheckTimer.Interval = 20;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button_SerialOpenClose);
            this.panel1.Controls.Add(this.comboBox_SerialPort);
            this.panel1.Controls.Add(this.button_SerialScan);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(166, 238);
            this.panel1.TabIndex = 30;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnRecvClear);
            this.panel2.Controls.Add(this.cbRecvTime);
            this.panel2.Controls.Add(this.rbRecvAscii);
            this.panel2.Controls.Add(this.rbRecvHex);
            this.panel2.Location = new System.Drawing.Point(0, 244);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(166, 273);
            this.panel2.TabIndex = 31;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnSendClear);
            this.panel3.Controls.Add(this.rbSendHex);
            this.panel3.Controls.Add(this.rbSendAscii);
            this.panel3.Location = new System.Drawing.Point(0, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(165, 100);
            this.panel3.TabIndex = 26;
            // 
            // rbRecvHex
            // 
            this.rbRecvHex.AutoSize = true;
            this.rbRecvHex.Checked = true;
            this.rbRecvHex.Location = new System.Drawing.Point(22, 12);
            this.rbRecvHex.Name = "rbRecvHex";
            this.rbRecvHex.Size = new System.Drawing.Size(41, 16);
            this.rbRecvHex.TabIndex = 0;
            this.rbRecvHex.TabStop = true;
            this.rbRecvHex.Text = "HEX";
            this.rbRecvHex.UseVisualStyleBackColor = true;
            // 
            // rbRecvAscii
            // 
            this.rbRecvAscii.AutoSize = true;
            this.rbRecvAscii.Location = new System.Drawing.Point(81, 12);
            this.rbRecvAscii.Name = "rbRecvAscii";
            this.rbRecvAscii.Size = new System.Drawing.Size(53, 16);
            this.rbRecvAscii.TabIndex = 1;
            this.rbRecvAscii.TabStop = true;
            this.rbRecvAscii.Text = "ASCII";
            this.rbRecvAscii.UseVisualStyleBackColor = true;
            // 
            // cbRecvTime
            // 
            this.cbRecvTime.AutoSize = true;
            this.cbRecvTime.Checked = true;
            this.cbRecvTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRecvTime.Location = new System.Drawing.Point(22, 34);
            this.cbRecvTime.Name = "cbRecvTime";
            this.cbRecvTime.Size = new System.Drawing.Size(120, 16);
            this.cbRecvTime.TabIndex = 2;
            this.cbRecvTime.Text = "显示接收数据时间";
            this.cbRecvTime.UseVisualStyleBackColor = true;
            // 
            // btnRecvClear
            // 
            this.btnRecvClear.Location = new System.Drawing.Point(31, 70);
            this.btnRecvClear.Name = "btnRecvClear";
            this.btnRecvClear.Size = new System.Drawing.Size(103, 51);
            this.btnRecvClear.TabIndex = 3;
            this.btnRecvClear.Text = "接收清空";
            this.btnRecvClear.UseVisualStyleBackColor = true;
            this.btnRecvClear.Click += new System.EventHandler(this.btnRecvClear_Click);
            // 
            // rbSendAscii
            // 
            this.rbSendAscii.AutoSize = true;
            this.rbSendAscii.Location = new System.Drawing.Point(81, 16);
            this.rbSendAscii.Name = "rbSendAscii";
            this.rbSendAscii.Size = new System.Drawing.Size(53, 16);
            this.rbSendAscii.TabIndex = 5;
            this.rbSendAscii.TabStop = true;
            this.rbSendAscii.Text = "ASCII";
            this.rbSendAscii.UseVisualStyleBackColor = true;
            // 
            // rbSendHex
            // 
            this.rbSendHex.AutoSize = true;
            this.rbSendHex.Checked = true;
            this.rbSendHex.Location = new System.Drawing.Point(22, 16);
            this.rbSendHex.Name = "rbSendHex";
            this.rbSendHex.Size = new System.Drawing.Size(41, 16);
            this.rbSendHex.TabIndex = 4;
            this.rbSendHex.TabStop = true;
            this.rbSendHex.Text = "HEX";
            this.rbSendHex.UseVisualStyleBackColor = true;
            // 
            // btnSendClear
            // 
            this.btnSendClear.Location = new System.Drawing.Point(22, 38);
            this.btnSendClear.Name = "btnSendClear";
            this.btnSendClear.Size = new System.Drawing.Size(103, 51);
            this.btnSendClear.TabIndex = 4;
            this.btnSendClear.Text = "发送清空";
            this.btnSendClear.UseVisualStyleBackColor = true;
            this.btnSendClear.Click += new System.EventHandler(this.btnSendClear_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 708);
            this.Controls.Add(this.scSerialPortOpera);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pnlQuickSet);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "速显微电子-群龙T712测试 V1.0";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlQuickSet.ResumeLayout(false);
            this.pnlQuickSet.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.scSerialPortOpera.Panel1.ResumeLayout(false);
            this.scSerialPortOpera.Panel1.PerformLayout();
            this.scSerialPortOpera.Panel2.ResumeLayout(false);
            this.scSerialPortOpera.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scSerialPortOpera)).EndInit();
            this.scSerialPortOpera.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_SerialPort;
        private System.Windows.Forms.Button button_SerialOpenClose;
        private System.Windows.Forms.Button button_SerialScan;
        private SXWUartProtocol.CommandList command1;
        private System.Windows.Forms.Button btnSaveJson;
        private System.Windows.Forms.Button btnOpenJson;
        private System.Windows.Forms.TextBox tbJsonFileDir;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 串口设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.Panel pnlQuickSet;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabpageSWXUartCmd;
        private System.Windows.Forms.TextBox tbRecv;
        private System.Windows.Forms.SplitContainer scSerialPortOpera;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.Timer tmrRecvCpltCheckTimer;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRecvClear;
        private System.Windows.Forms.CheckBox cbRecvTime;
        private System.Windows.Forms.RadioButton rbRecvAscii;
        private System.Windows.Forms.RadioButton rbRecvHex;
        private System.Windows.Forms.Button btnSendClear;
        private System.Windows.Forms.RadioButton rbSendHex;
        private System.Windows.Forms.RadioButton rbSendAscii;

    }
}

