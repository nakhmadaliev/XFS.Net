namespace TestForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.grbWebase = new System.Windows.Forms.GroupBox();
            this.btnWebase1 = new System.Windows.Forms.Button();
            this.cmbWebaseServices = new System.Windows.Forms.ComboBox();
            this.grbWebase.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(417, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "ReadRawData";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(417, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 1;
            this.button2.Text = "EjectCard";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(417, 132);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 25);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(417, 182);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 25);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(336, 27);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 25);
            this.button5.TabIndex = 4;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 27);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 25);
            this.button6.TabIndex = 5;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(12, 77);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 25);
            this.button7.TabIndex = 6;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(417, 225);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 25);
            this.button8.TabIndex = 7;
            this.button8.Text = "idc stu";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(417, 269);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 25);
            this.button9.TabIndex = 8;
            this.button9.Text = "idc cap";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // grbWebase
            // 
            this.grbWebase.Controls.Add(this.cmbWebaseServices);
            this.grbWebase.Controls.Add(this.btnWebase1);
            this.grbWebase.Location = new System.Drawing.Point(12, 119);
            this.grbWebase.Name = "grbWebase";
            this.grbWebase.Size = new System.Drawing.Size(263, 305);
            this.grbWebase.TabIndex = 9;
            this.grbWebase.TabStop = false;
            this.grbWebase.Text = "Webase";
            // 
            // btnWebase1
            // 
            this.btnWebase1.Location = new System.Drawing.Point(6, 52);
            this.btnWebase1.Name = "btnWebase1";
            this.btnWebase1.Size = new System.Drawing.Size(251, 23);
            this.btnWebase1.TabIndex = 0;
            this.btnWebase1.Text = "LogInfo";
            this.btnWebase1.UseVisualStyleBackColor = true;
            this.btnWebase1.Click += new System.EventHandler(this.btnWebase1_Click);
            // 
            // cmbWebaseServices
            // 
            this.cmbWebaseServices.FormattingEnabled = true;
            this.cmbWebaseServices.Items.AddRange(new object[] {
            "BarcodeReader1",
            "BRMAcceptor1",
            "BRMDispenser1",
            "BunchCheque1",
            "Camera1",
            "CardDispenser1",
            "CashInModule1",
            "ChequeProcessor1",
            "Contactless1",
            "CRDCardUnit1",
            "DocumentProcessor1",
            "ElectronicDocumentProcessor1",
            "Envelope1",
            "IDCardUnit1",
            "IDCardUnit2",
            "JournalPrinter1",
            "NightSafe1",
            "PassbookPrinter1",
            "Pinpad1",
            "ReceiptPrinter1",
            "ReceiptPrinter2",
            "SCPMChequeProcessor1",
            "SDMBunchCheque1",
            "SDMCashInModule1",
            "SignatureScanner1",
            "SingleNoteCashInModule1",
            "SIU",
            "StatementPrinter1",
            "TextTerminalUnit1",
            "USBJournalPrinter1",
            "USBReceiptPrinter1",
            "USBStatementPrinter1",
            "VendorDependentMode1"});
            this.cmbWebaseServices.Location = new System.Drawing.Point(6, 19);
            this.cmbWebaseServices.Name = "cmbWebaseServices";
            this.cmbWebaseServices.Size = new System.Drawing.Size(251, 21);
            this.cmbWebaseServices.TabIndex = 2;
            this.cmbWebaseServices.Text = "BRMDispenser1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 450);
            this.Controls.Add(this.grbWebase);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grbWebase.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.GroupBox grbWebase;
        private System.Windows.Forms.Button btnWebase1;
        private System.Windows.Forms.ComboBox cmbWebaseServices;
    }
}

