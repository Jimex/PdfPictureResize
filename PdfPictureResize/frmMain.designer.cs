
namespace PdfPictureResize
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectIEncryptSourceFolder = new System.Windows.Forms.Button();
            this.btnSelectEncryptOutputFolder = new System.Windows.Forms.Button();
            this.btnSelectPgpPublicKey = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnStartConvertPDF = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmbPageSize = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudLeft = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudRight = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudTop = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudBottom = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeft)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBottom)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.ForeColor = System.Drawing.Color.Red;
            this.txtLog.Location = new System.Drawing.Point(12, 300);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(802, 166);
            this.txtLog.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input folder";
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceFolder.Location = new System.Drawing.Point(148, 14);
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.Size = new System.Drawing.Size(587, 34);
            this.txtSourceFolder.TabIndex = 3;
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputFolder.Location = new System.Drawing.Point(148, 65);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(587, 34);
            this.txtOutputFolder.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output folder";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 28);
            this.label4.TabIndex = 11;
            this.label4.Text = "Log";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // btnSelectIEncryptSourceFolder
            // 
            this.btnSelectIEncryptSourceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectIEncryptSourceFolder.Location = new System.Drawing.Point(742, 14);
            this.btnSelectIEncryptSourceFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelectIEncryptSourceFolder.Name = "btnSelectIEncryptSourceFolder";
            this.btnSelectIEncryptSourceFolder.Size = new System.Drawing.Size(44, 36);
            this.btnSelectIEncryptSourceFolder.TabIndex = 19;
            this.btnSelectIEncryptSourceFolder.Text = "...";
            this.btnSelectIEncryptSourceFolder.UseVisualStyleBackColor = true;
            this.btnSelectIEncryptSourceFolder.Click += new System.EventHandler(this.btnSelectInputFolder_Click);
            // 
            // btnSelectEncryptOutputFolder
            // 
            this.btnSelectEncryptOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectEncryptOutputFolder.Location = new System.Drawing.Point(742, 65);
            this.btnSelectEncryptOutputFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelectEncryptOutputFolder.Name = "btnSelectEncryptOutputFolder";
            this.btnSelectEncryptOutputFolder.Size = new System.Drawing.Size(44, 36);
            this.btnSelectEncryptOutputFolder.TabIndex = 20;
            this.btnSelectEncryptOutputFolder.Text = "...";
            this.btnSelectEncryptOutputFolder.UseVisualStyleBackColor = true;
            this.btnSelectEncryptOutputFolder.Click += new System.EventHandler(this.btnSelectOutputFolder_Click);
            // 
            // btnSelectPgpPublicKey
            // 
            this.btnSelectPgpPublicKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectPgpPublicKey.Location = new System.Drawing.Point(778, 156);
            this.btnSelectPgpPublicKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelectPgpPublicKey.Name = "btnSelectPgpPublicKey";
            this.btnSelectPgpPublicKey.Size = new System.Drawing.Size(22, 23);
            this.btnSelectPgpPublicKey.TabIndex = 21;
            this.btnSelectPgpPublicKey.Text = "...";
            this.btnSelectPgpPublicKey.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 8);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(804, 257);
            this.tabControl1.TabIndex = 23;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtSourceFolder);
            this.tabPage1.Controls.Add(this.btnSelectEncryptOutputFolder);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnSelectIEncryptSourceFolder);
            this.tabPage1.Controls.Add(this.txtOutputFolder);
            this.tabPage1.Location = new System.Drawing.Point(4, 37);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(796, 216);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Folders";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnStartConvertPDF
            // 
            this.btnStartConvertPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartConvertPDF.AutoSize = true;
            this.btnStartConvertPDF.Location = new System.Drawing.Point(717, 476);
            this.btnStartConvertPDF.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStartConvertPDF.Name = "btnStartConvertPDF";
            this.btnStartConvertPDF.Size = new System.Drawing.Size(97, 38);
            this.btnStartConvertPDF.TabIndex = 24;
            this.btnStartConvertPDF.Text = "Start";
            this.btnStartConvertPDF.UseVisualStyleBackColor = true;
            this.btnStartConvertPDF.Click += new System.EventHandler(this.btnStartConvertPDF_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.cmbPageSize);
            this.tabPage2.Location = new System.Drawing.Point(4, 37);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(796, 216);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Options";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cmbPageSize
            // 
            this.cmbPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPageSize.FormattingEnabled = true;
            this.cmbPageSize.Items.AddRange(new object[] {
            "A4",
            "A5",
            "B4",
            "Kindle"});
            this.cmbPageSize.Location = new System.Drawing.Point(114, 14);
            this.cmbPageSize.Name = "cmbPageSize";
            this.cmbPageSize.Size = new System.Drawing.Size(121, 36);
            this.cmbPageSize.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "Page Size";
            // 
            // nudLeft
            // 
            this.nudLeft.Location = new System.Drawing.Point(95, 39);
            this.nudLeft.Name = "nudLeft";
            this.nudLeft.Size = new System.Drawing.Size(74, 34);
            this.nudLeft.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 28);
            this.label5.TabIndex = 3;
            this.label5.Text = "Left";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudBottom);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.nudTop);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.nudRight);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.nudLeft);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(19, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(736, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Margin";
            // 
            // nudRight
            // 
            this.nudRight.Location = new System.Drawing.Point(273, 39);
            this.nudRight.Name = "nudRight";
            this.nudRight.Size = new System.Drawing.Size(74, 34);
            this.nudRight.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(204, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 28);
            this.label6.TabIndex = 5;
            this.label6.Text = "Right";
            // 
            // nudTop
            // 
            this.nudTop.Location = new System.Drawing.Point(438, 39);
            this.nudTop.Name = "nudTop";
            this.nudTop.Size = new System.Drawing.Size(74, 34);
            this.nudTop.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(369, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 28);
            this.label7.TabIndex = 7;
            this.label7.Text = "Top";
            // 
            // nudBottom
            // 
            this.nudBottom.Location = new System.Drawing.Point(622, 37);
            this.nudBottom.Name = "nudBottom";
            this.nudBottom.Size = new System.Drawing.Size(74, 34);
            this.nudBottom.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(538, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 28);
            this.label8.TabIndex = 9;
            this.label8.Text = "Bottom";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(832, 521);
            this.Controls.Add(this.btnStartConvertPDF);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSelectPgpPublicKey);
            this.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDF Picture Adjustment Tools by Jimex Studio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeft)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBottom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSelectIEncryptSourceFolder;
        private System.Windows.Forms.Button btnSelectEncryptOutputFolder;
        private System.Windows.Forms.Button btnSelectPgpPublicKey;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnStartConvertPDF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPageSize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudBottom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudTop;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudRight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudLeft;
        private System.Windows.Forms.Label label5;
    }
}

