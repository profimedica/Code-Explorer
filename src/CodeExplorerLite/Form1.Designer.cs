namespace CodeExplorerLite
{
    partial class Form1
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.comboBoxProjectRoot = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonInstertLoggingSystem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonEraseLog = new System.Windows.Forms.Button();
            this.buttonViewLog = new System.Windows.Forms.Button();
            this.buttonAnalyzeLog = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxProjectRoot
            // 
            this.comboBoxProjectRoot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxProjectRoot.FormattingEnabled = true;
            this.comboBoxProjectRoot.Location = new System.Drawing.Point(102, 38);
            this.comboBoxProjectRoot.Name = "comboBoxProjectRoot";
            this.comboBoxProjectRoot.Size = new System.Drawing.Size(404, 24);
            this.comboBoxProjectRoot.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Project Root:";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowse.Location = new System.Drawing.Point(512, 38);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buttonInstertLoggingSystem);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonBrowse);
            this.groupBox1.Controls.Add(this.comboBoxProjectRoot);
            this.groupBox1.Location = new System.Drawing.Point(12, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(593, 134);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project";
            // 
            // buttonInstertLoggingSystem
            // 
            this.buttonInstertLoggingSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInstertLoggingSystem.Location = new System.Drawing.Point(102, 68);
            this.buttonInstertLoggingSystem.Name = "buttonInstertLoggingSystem";
            this.buttonInstertLoggingSystem.Size = new System.Drawing.Size(186, 32);
            this.buttonInstertLoggingSystem.TabIndex = 4;
            this.buttonInstertLoggingSystem.Text = "Insert Logging System";
            this.buttonInstertLoggingSystem.UseVisualStyleBackColor = true;
            this.buttonInstertLoggingSystem.Click += new System.EventHandler(this.buttonInstertLoggingSystem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select a project to explore";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 73);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(593, 91);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // buttonEraseLog
            // 
            this.buttonEraseLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEraseLog.Location = new System.Drawing.Point(12, 310);
            this.buttonEraseLog.Name = "buttonEraseLog";
            this.buttonEraseLog.Size = new System.Drawing.Size(126, 32);
            this.buttonEraseLog.TabIndex = 5;
            this.buttonEraseLog.Text = "Erase Log";
            this.buttonEraseLog.UseVisualStyleBackColor = true;
            this.buttonEraseLog.Click += new System.EventHandler(this.buttonEraseLog_Click);
            // 
            // buttonViewLog
            // 
            this.buttonViewLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonViewLog.Location = new System.Drawing.Point(144, 310);
            this.buttonViewLog.Name = "buttonViewLog";
            this.buttonViewLog.Size = new System.Drawing.Size(126, 32);
            this.buttonViewLog.TabIndex = 6;
            this.buttonViewLog.Text = "View Log";
            this.buttonViewLog.UseVisualStyleBackColor = true;
            this.buttonViewLog.Click += new System.EventHandler(this.buttonViewLog_Click);
            // 
            // buttonAnalyzeLog
            // 
            this.buttonAnalyzeLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAnalyzeLog.Location = new System.Drawing.Point(276, 310);
            this.buttonAnalyzeLog.Name = "buttonAnalyzeLog";
            this.buttonAnalyzeLog.Size = new System.Drawing.Size(126, 32);
            this.buttonAnalyzeLog.TabIndex = 7;
            this.buttonAnalyzeLog.Text = "Analyze Log";
            this.buttonAnalyzeLog.UseVisualStyleBackColor = true;
            this.buttonAnalyzeLog.Click += new System.EventHandler(this.buttonAnalyzeLog_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(99, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(428, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "This version will not check if the logging system is already inserted!";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "ReadMe!";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(74, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(465, 25);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Fast way to start working with a new project";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 353);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonAnalyzeLog);
            this.Controls.Add(this.buttonViewLog);
            this.Controls.Add(this.buttonEraseLog);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Code Explorer Lite v.0.1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox comboBoxProjectRoot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonInstertLoggingSystem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonEraseLog;
        private System.Windows.Forms.Button buttonViewLog;
        private System.Windows.Forms.Button buttonAnalyzeLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

