namespace FTPUploader
{
    partial class ConfigForm
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
            this.localGroupBox = new System.Windows.Forms.GroupBox();
            this.dirButton = new System.Windows.Forms.Button();
            this.localPathTextBox = new System.Windows.Forms.TextBox();
            this.ftpGroupBox = new System.Windows.Forms.GroupBox();
            this.verifyButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.ftpURL = new System.Windows.Forms.Label();
            this.passwordGroupBox = new System.Windows.Forms.GroupBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.configPasswordTextBox = new System.Windows.Forms.TextBox();
            this.localPathBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.openConfigFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.localGroupBox.SuspendLayout();
            this.ftpGroupBox.SuspendLayout();
            this.passwordGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // localGroupBox
            // 
            this.localGroupBox.Controls.Add(this.dirButton);
            this.localGroupBox.Controls.Add(this.localPathTextBox);
            this.localGroupBox.Location = new System.Drawing.Point(25, 12);
            this.localGroupBox.Name = "localGroupBox";
            this.localGroupBox.Size = new System.Drawing.Size(370, 55);
            this.localGroupBox.TabIndex = 2;
            this.localGroupBox.TabStop = false;
            this.localGroupBox.Text = "Local";
            // 
            // dirButton
            // 
            this.dirButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dirButton.Location = new System.Drawing.Point(269, 22);
            this.dirButton.Name = "dirButton";
            this.dirButton.Size = new System.Drawing.Size(98, 20);
            this.dirButton.TabIndex = 2;
            this.dirButton.Text = "Choose Path";
            this.dirButton.UseVisualStyleBackColor = true;
            this.dirButton.Click += new System.EventHandler(this.dirButton_Click);
            // 
            // localPathTextBox
            // 
            this.localPathTextBox.Location = new System.Drawing.Point(24, 22);
            this.localPathTextBox.Name = "localPathTextBox";
            this.localPathTextBox.Size = new System.Drawing.Size(239, 20);
            this.localPathTextBox.TabIndex = 1;
            // 
            // ftpGroupBox
            // 
            this.ftpGroupBox.Controls.Add(this.verifyButton);
            this.ftpGroupBox.Controls.Add(this.passwordTextBox);
            this.ftpGroupBox.Controls.Add(this.passwordLabel);
            this.ftpGroupBox.Controls.Add(this.usernameTextBox);
            this.ftpGroupBox.Controls.Add(this.usernameLabel);
            this.ftpGroupBox.Controls.Add(this.urlTextBox);
            this.ftpGroupBox.Controls.Add(this.ftpURL);
            this.ftpGroupBox.Location = new System.Drawing.Point(25, 73);
            this.ftpGroupBox.Name = "ftpGroupBox";
            this.ftpGroupBox.Size = new System.Drawing.Size(370, 140);
            this.ftpGroupBox.TabIndex = 3;
            this.ftpGroupBox.TabStop = false;
            this.ftpGroupBox.Text = "FTP";
            // 
            // verifyButton
            // 
            this.verifyButton.Location = new System.Drawing.Point(269, 22);
            this.verifyButton.Name = "verifyButton";
            this.verifyButton.Size = new System.Drawing.Size(98, 101);
            this.verifyButton.TabIndex = 7;
            this.verifyButton.Text = "Verify";
            this.verifyButton.UseVisualStyleBackColor = true;
            this.verifyButton.Click += new System.EventHandler(this.verifyButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(85, 103);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(178, 20);
            this.passwordTextBox.TabIndex = 6;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(21, 106);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 5;
            this.passwordLabel.Text = "Password";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(85, 62);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(178, 20);
            this.usernameTextBox.TabIndex = 4;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(21, 65);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 3;
            this.usernameLabel.Text = "Username";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlTextBox.Location = new System.Drawing.Point(85, 22);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(178, 20);
            this.urlTextBox.TabIndex = 2;
            this.urlTextBox.Text = "ftp://";
            // 
            // ftpURL
            // 
            this.ftpURL.AutoSize = true;
            this.ftpURL.Location = new System.Drawing.Point(21, 25);
            this.ftpURL.Name = "ftpURL";
            this.ftpURL.Size = new System.Drawing.Size(29, 13);
            this.ftpURL.TabIndex = 1;
            this.ftpURL.Text = "URL";
            // 
            // passwordGroupBox
            // 
            this.passwordGroupBox.Controls.Add(this.resetButton);
            this.passwordGroupBox.Controls.Add(this.configPasswordTextBox);
            this.passwordGroupBox.Location = new System.Drawing.Point(25, 219);
            this.passwordGroupBox.Name = "passwordGroupBox";
            this.passwordGroupBox.Size = new System.Drawing.Size(370, 55);
            this.passwordGroupBox.TabIndex = 3;
            this.passwordGroupBox.TabStop = false;
            this.passwordGroupBox.Text = "Config Password";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(269, 18);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(98, 23);
            this.resetButton.TabIndex = 1;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // configPasswordTextBox
            // 
            this.configPasswordTextBox.Location = new System.Drawing.Point(24, 20);
            this.configPasswordTextBox.Name = "configPasswordTextBox";
            this.configPasswordTextBox.Size = new System.Drawing.Size(239, 20);
            this.configPasswordTextBox.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(115, 285);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(230, 285);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 5;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // openConfigFileDialog
            // 
            this.openConfigFileDialog.FileName = "Uploader.cfg";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 320);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.passwordGroupBox);
            this.Controls.Add(this.ftpGroupBox);
            this.Controls.Add(this.localGroupBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(436, 359);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(436, 359);
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.localGroupBox.ResumeLayout(false);
            this.localGroupBox.PerformLayout();
            this.ftpGroupBox.ResumeLayout(false);
            this.ftpGroupBox.PerformLayout();
            this.passwordGroupBox.ResumeLayout(false);
            this.passwordGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox localGroupBox;
        private System.Windows.Forms.Button dirButton;
        private System.Windows.Forms.TextBox localPathTextBox;
        private System.Windows.Forms.GroupBox ftpGroupBox;
        private System.Windows.Forms.GroupBox passwordGroupBox;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label ftpURL;
        private System.Windows.Forms.FolderBrowserDialog localPathBrowserDialog;
        private System.Windows.Forms.Button verifyButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.TextBox configPasswordTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.OpenFileDialog openConfigFileDialog;

    }
}