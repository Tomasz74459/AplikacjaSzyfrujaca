namespace EncryptionApp
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
            this.ButtonSelectFiles = new System.Windows.Forms.Button();
            this.ButtonEncrypt = new System.Windows.Forms.Button();
            this.ButtonDecrypt = new System.Windows.Forms.Button();
            this.textBoxFiles = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.comboBoxEncryptionMethod = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ButtonSelectFiles
            // 
            this.ButtonSelectFiles.Location = new System.Drawing.Point(12, 12);
            this.ButtonSelectFiles.Name = "ButtonSelectFiles";
            this.ButtonSelectFiles.Size = new System.Drawing.Size(120, 23);
            this.ButtonSelectFiles.TabIndex = 0;
            this.ButtonSelectFiles.Text = "Wybierz pliki";
            this.ButtonSelectFiles.UseVisualStyleBackColor = true;
            this.ButtonSelectFiles.Click += new System.EventHandler(this.ButtonSelectFiles_Click);
            // 
            // ButtonEncrypt
            // 
            this.ButtonEncrypt.Location = new System.Drawing.Point(138, 12);
            this.ButtonEncrypt.Name = "ButtonEncrypt";
            this.ButtonEncrypt.Size = new System.Drawing.Size(120, 23);
            this.ButtonEncrypt.TabIndex = 1;
            this.ButtonEncrypt.Text = "Szyfruj";
            this.ButtonEncrypt.UseVisualStyleBackColor = true;
            this.ButtonEncrypt.Click += new System.EventHandler(this.ButtonEncrypt_Click);
            // 
            // ButtonDecrypt
            // 
            this.ButtonDecrypt.Location = new System.Drawing.Point(264, 12);
            this.ButtonDecrypt.Name = "ButtonDecrypt";
            this.ButtonDecrypt.Size = new System.Drawing.Size(120, 23);
            this.ButtonDecrypt.TabIndex = 2;
            this.ButtonDecrypt.Text = "Deszyfruj";
            this.ButtonDecrypt.UseVisualStyleBackColor = true;
            this.ButtonDecrypt.Click += new System.EventHandler(this.ButtonDecrypt_Click);
            // 
            // textBoxFiles
            // 
            this.textBoxFiles.Location = new System.Drawing.Point(12, 41);
            this.textBoxFiles.Multiline = true;
            this.textBoxFiles.Name = "textBoxFiles";
            this.textBoxFiles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxFiles.Size = new System.Drawing.Size(372, 150);
            this.textBoxFiles.TabIndex = 3;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 197);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(372, 23);
            this.progressBar.TabIndex = 4;
            // 
            // comboBoxEncryptionMethod
            // 
            this.comboBoxEncryptionMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEncryptionMethod.FormattingEnabled = true;
            this.comboBoxEncryptionMethod.Items.AddRange(new object[] {
            "AES",
            "DES",
            "RSA"});
            this.comboBoxEncryptionMethod.Location = new System.Drawing.Point(12, 226);
            this.comboBoxEncryptionMethod.Name = "comboBoxEncryptionMethod";
            this.comboBoxEncryptionMethod.Size = new System.Drawing.Size(120, 21);
            this.comboBoxEncryptionMethod.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 259);
            this.Controls.Add(this.comboBoxEncryptionMethod);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.textBoxFiles);
            this.Controls.Add(this.ButtonDecrypt);
            this.Controls.Add(this.ButtonEncrypt);
            this.Controls.Add(this.ButtonSelectFiles);
            this.Name = "Form1";
            this.Text = "Aplikacja szyfrująca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonSelectFiles;
        private System.Windows.Forms.Button ButtonEncrypt;
        private System.Windows.Forms.Button ButtonDecrypt;
        private System.Windows.Forms.TextBox textBoxFiles;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ComboBox comboBoxEncryptionMethod;
    }
}