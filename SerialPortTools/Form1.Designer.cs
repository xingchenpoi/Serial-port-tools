namespace SerialPortTools
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SettingsBox = new System.Windows.Forms.GroupBox();
            this.RbnHex = new System.Windows.Forms.RadioButton();
            this.RbnChar = new System.Windows.Forms.RadioButton();
            this.BtnOpenCOM = new System.Windows.Forms.Button();
            this.BtnCheckCOM = new System.Windows.Forms.Button();
            this.CbxDataBits = new System.Windows.Forms.ComboBox();
            this.CbxParity = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CbxStopBits = new System.Windows.Forms.ComboBox();
            this.CbxBaudBate = new System.Windows.Forms.ComboBox();
            this.CbxCOMPort = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RevDATABox = new System.Windows.Forms.GroupBox();
            this.TbxRecvData = new System.Windows.Forms.TextBox();
            this.SendDataBox = new System.Windows.Forms.GroupBox();
            this.BtnSend = new System.Windows.Forms.Button();
            this.BtnCleanData = new System.Windows.Forms.Button();
            this.TbxSendData = new System.Windows.Forms.TextBox();
            this.SettingsBox.SuspendLayout();
            this.RevDATABox.SuspendLayout();
            this.SendDataBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingsBox
            // 
            this.SettingsBox.Controls.Add(this.RbnHex);
            this.SettingsBox.Controls.Add(this.RbnChar);
            this.SettingsBox.Controls.Add(this.BtnOpenCOM);
            this.SettingsBox.Controls.Add(this.BtnCheckCOM);
            this.SettingsBox.Controls.Add(this.CbxDataBits);
            this.SettingsBox.Controls.Add(this.CbxParity);
            this.SettingsBox.Controls.Add(this.label5);
            this.SettingsBox.Controls.Add(this.label4);
            this.SettingsBox.Controls.Add(this.CbxStopBits);
            this.SettingsBox.Controls.Add(this.CbxBaudBate);
            this.SettingsBox.Controls.Add(this.CbxCOMPort);
            this.SettingsBox.Controls.Add(this.label3);
            this.SettingsBox.Controls.Add(this.label2);
            this.SettingsBox.Controls.Add(this.label1);
            this.SettingsBox.Location = new System.Drawing.Point(13, 13);
            this.SettingsBox.Name = "SettingsBox";
            this.SettingsBox.Size = new System.Drawing.Size(577, 136);
            this.SettingsBox.TabIndex = 0;
            this.SettingsBox.TabStop = false;
            this.SettingsBox.Text = "参数设置";
            // 
            // RbnHex
            // 
            this.RbnHex.AutoSize = true;
            this.RbnHex.Location = new System.Drawing.Point(322, 89);
            this.RbnHex.Name = "RbnHex";
            this.RbnHex.Size = new System.Drawing.Size(65, 16);
            this.RbnHex.TabIndex = 13;
            this.RbnHex.Text = "HEX显示";
            this.RbnHex.UseVisualStyleBackColor = true;
            // 
            // RbnChar
            // 
            this.RbnChar.AutoSize = true;
            this.RbnChar.Checked = true;
            this.RbnChar.Location = new System.Drawing.Point(220, 89);
            this.RbnChar.Name = "RbnChar";
            this.RbnChar.Size = new System.Drawing.Size(71, 16);
            this.RbnChar.TabIndex = 12;
            this.RbnChar.TabStop = true;
            this.RbnChar.Text = "字符显示";
            this.RbnChar.UseVisualStyleBackColor = true;
            // 
            // BtnOpenCOM
            // 
            this.BtnOpenCOM.Location = new System.Drawing.Point(453, 56);
            this.BtnOpenCOM.Name = "BtnOpenCOM";
            this.BtnOpenCOM.Size = new System.Drawing.Size(75, 23);
            this.BtnOpenCOM.TabIndex = 11;
            this.BtnOpenCOM.Text = "打开串口";
            this.BtnOpenCOM.UseVisualStyleBackColor = true;
            this.BtnOpenCOM.Click += new System.EventHandler(this.BtnOpenCOM_Click);
            // 
            // BtnCheckCOM
            // 
            this.BtnCheckCOM.Location = new System.Drawing.Point(453, 26);
            this.BtnCheckCOM.Name = "BtnCheckCOM";
            this.BtnCheckCOM.Size = new System.Drawing.Size(75, 23);
            this.BtnCheckCOM.TabIndex = 10;
            this.BtnCheckCOM.Text = "串口检测";
            this.BtnCheckCOM.UseVisualStyleBackColor = true;
            this.BtnCheckCOM.Click += new System.EventHandler(this.BtnCheckCOM_Click);
            // 
            // CbxDataBits
            // 
            this.CbxDataBits.FormattingEnabled = true;
            this.CbxDataBits.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5"});
            this.CbxDataBits.Location = new System.Drawing.Point(284, 60);
            this.CbxDataBits.Name = "CbxDataBits";
            this.CbxDataBits.Size = new System.Drawing.Size(121, 20);
            this.CbxDataBits.TabIndex = 9;

            // 
            // CbxParity
            // 
            this.CbxParity.FormattingEnabled = true;
            this.CbxParity.Items.AddRange(new object[] {
            "无",
            "奇校验",
            "偶校验"});
            this.CbxParity.Location = new System.Drawing.Point(284, 31);
            this.CbxParity.Name = "CbxParity";
            this.CbxParity.Size = new System.Drawing.Size(121, 20);
            this.CbxParity.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "数据位：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "奇偶校验：";
            // 
            // CbxStopBits
            // 
            this.CbxStopBits.FormattingEnabled = true;
            this.CbxStopBits.Items.AddRange(new object[] {
            "0",
            "1",
            "1.5",
            "2"});
            this.CbxStopBits.Location = new System.Drawing.Point(66, 86);
            this.CbxStopBits.Name = "CbxStopBits";
            this.CbxStopBits.Size = new System.Drawing.Size(121, 20);
            this.CbxStopBits.TabIndex = 5;
            // 
            // CbxBaudBate
            // 
            this.CbxBaudBate.FormattingEnabled = true;
            this.CbxBaudBate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "43000",
            "56000",
            "57600",
            "115200"});
            this.CbxBaudBate.Location = new System.Drawing.Point(66, 57);
            this.CbxBaudBate.Name = "CbxBaudBate";
            this.CbxBaudBate.Size = new System.Drawing.Size(121, 20);
            this.CbxBaudBate.TabIndex = 4;
            // 
            // CbxCOMPort
            // 
            this.CbxCOMPort.FormattingEnabled = true;
            this.CbxCOMPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16",
            "COM17",
            "COM18",
            "COM19",
            "COM20",
            "COM21",
            "COM22",
            "COM23",
            "COM24",
            "COM25",
            "COM26",
            "COM27",
            "COM28",
            "COM29",
            "COM30",
            "COM31",
            "COM32",
            "COM33",
            "COM34",
            "COM35",
            "COM36",
            "COM37",
            "COM38",
            "COM39",
            "COM40"});
            this.CbxCOMPort.Location = new System.Drawing.Point(66, 28);
            this.CbxCOMPort.Name = "CbxCOMPort";
            this.CbxCOMPort.Size = new System.Drawing.Size(121, 20);
            this.CbxCOMPort.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "停止位：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号：";
            // 
            // RevDATABox
            // 
            this.RevDATABox.Controls.Add(this.TbxRecvData);
            this.RevDATABox.Location = new System.Drawing.Point(13, 177);
            this.RevDATABox.Name = "RevDATABox";
            this.RevDATABox.Size = new System.Drawing.Size(577, 199);
            this.RevDATABox.TabIndex = 1;
            this.RevDATABox.TabStop = false;
            this.RevDATABox.Text = "数据接收";
            // 
            // TbxRecvData
            // 
            this.TbxRecvData.BackColor = System.Drawing.SystemColors.HighlightText;
            this.TbxRecvData.Location = new System.Drawing.Point(9, 21);
            this.TbxRecvData.Multiline = true;
            this.TbxRecvData.Name = "TbxRecvData";
            this.TbxRecvData.ReadOnly = true;
            this.TbxRecvData.Size = new System.Drawing.Size(562, 172);
            this.TbxRecvData.TabIndex = 0;
            // 
            // SendDataBox
            // 
            this.SendDataBox.Controls.Add(this.BtnSend);
            this.SendDataBox.Controls.Add(this.BtnCleanData);
            this.SendDataBox.Controls.Add(this.TbxSendData);
            this.SendDataBox.Location = new System.Drawing.Point(13, 403);
            this.SendDataBox.Name = "SendDataBox";
            this.SendDataBox.Size = new System.Drawing.Size(577, 105);
            this.SendDataBox.TabIndex = 2;
            this.SendDataBox.TabStop = false;
            this.SendDataBox.Text = "数据发送";
            // 
            // BtnSend
            // 
            this.BtnSend.Location = new System.Drawing.Point(477, 75);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(75, 23);
            this.BtnSend.TabIndex = 2;
            this.BtnSend.Text = "发送数据";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // BtnCleanData
            // 
            this.BtnCleanData.Location = new System.Drawing.Point(477, 21);
            this.BtnCleanData.Name = "BtnCleanData";
            this.BtnCleanData.Size = new System.Drawing.Size(75, 23);
            this.BtnCleanData.TabIndex = 1;
            this.BtnCleanData.Text = "清空数据";
            this.BtnCleanData.UseVisualStyleBackColor = true;
            this.BtnCleanData.Click += new System.EventHandler(this.BtnCleanData_Click);
            // 
            // TbxSendData
            // 
            this.TbxSendData.Location = new System.Drawing.Point(9, 21);
            this.TbxSendData.Multiline = true;
            this.TbxSendData.Name = "TbxSendData";
            this.TbxSendData.Size = new System.Drawing.Size(422, 78);
            this.TbxSendData.TabIndex = 0;
            // 
            // Form1
            // 
            this.AcceptButton = this.BtnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 520);
            this.Controls.Add(this.SendDataBox);
            this.Controls.Add(this.RevDATABox);
            this.Controls.Add(this.SettingsBox);
            this.Name = "Form1";
            this.Text = "串口工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SettingsBox.ResumeLayout(false);
            this.SettingsBox.PerformLayout();
            this.RevDATABox.ResumeLayout(false);
            this.RevDATABox.PerformLayout();
            this.SendDataBox.ResumeLayout(false);
            this.SendDataBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox SettingsBox;
        private System.Windows.Forms.GroupBox RevDATABox;
        private System.Windows.Forms.GroupBox SendDataBox;
        private System.Windows.Forms.RadioButton RbnHex;
        private System.Windows.Forms.RadioButton RbnChar;
        private System.Windows.Forms.Button BtnOpenCOM;
        private System.Windows.Forms.Button BtnCheckCOM;
        private System.Windows.Forms.ComboBox CbxDataBits;
        private System.Windows.Forms.ComboBox CbxParity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CbxStopBits;
        private System.Windows.Forms.ComboBox CbxBaudBate;
        private System.Windows.Forms.ComboBox CbxCOMPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbxRecvData;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.Button BtnCleanData;
        private System.Windows.Forms.TextBox TbxSendData;
    }
}

