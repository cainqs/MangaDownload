
namespace MangaDownloader
{
    partial class Setting
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
            this.SettingMangaFolder = new System.Windows.Forms.Label();
            this.SettingZipLabel = new System.Windows.Forms.Label();
            this.SettingIsZipCB = new System.Windows.Forms.CheckBox();
            this.SettingMangaFolderText = new System.Windows.Forms.TextBox();
            this.SettingZipFolderText = new System.Windows.Forms.TextBox();
            this.SettingCancelBtn = new System.Windows.Forms.Button();
            this.SettingSaveBtn = new System.Windows.Forms.Button();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // SettingMangaFolder
            // 
            this.SettingMangaFolder.AutoSize = true;
            this.SettingMangaFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingMangaFolder.Location = new System.Drawing.Point(15, 34);
            this.SettingMangaFolder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SettingMangaFolder.Name = "SettingMangaFolder";
            this.SettingMangaFolder.Size = new System.Drawing.Size(71, 17);
            this.SettingMangaFolder.TabIndex = 0;
            this.SettingMangaFolder.Text = "漫画根目录:";
            // 
            // SettingZipLabel
            // 
            this.SettingZipLabel.AutoSize = true;
            this.SettingZipLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingZipLabel.Location = new System.Drawing.Point(15, 76);
            this.SettingZipLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SettingZipLabel.Name = "SettingZipLabel";
            this.SettingZipLabel.Size = new System.Drawing.Size(71, 17);
            this.SettingZipLabel.TabIndex = 1;
            this.SettingZipLabel.Text = "压缩包目录:";
            // 
            // SettingIsZipCB
            // 
            this.SettingIsZipCB.AutoSize = true;
            this.SettingIsZipCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SettingIsZipCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingIsZipCB.Location = new System.Drawing.Point(15, 118);
            this.SettingIsZipCB.Margin = new System.Windows.Forms.Padding(2);
            this.SettingIsZipCB.Name = "SettingIsZipCB";
            this.SettingIsZipCB.Size = new System.Drawing.Size(72, 21);
            this.SettingIsZipCB.TabIndex = 2;
            this.SettingIsZipCB.Text = "是否压缩";
            this.SettingIsZipCB.UseVisualStyleBackColor = false;
            // 
            // SettingMangaFolderText
            // 
            this.SettingMangaFolderText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingMangaFolderText.BackColor = System.Drawing.Color.Gray;
            this.SettingMangaFolderText.Location = new System.Drawing.Point(90, 32);
            this.SettingMangaFolderText.Margin = new System.Windows.Forms.Padding(2);
            this.SettingMangaFolderText.Name = "SettingMangaFolderText";
            this.SettingMangaFolderText.Size = new System.Drawing.Size(322, 23);
            this.SettingMangaFolderText.TabIndex = 3;
            this.SettingMangaFolderText.Click += new System.EventHandler(this.SettingMangaFolderText_Click);
            // 
            // SettingZipFolderText
            // 
            this.SettingZipFolderText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingZipFolderText.BackColor = System.Drawing.Color.Gray;
            this.SettingZipFolderText.Location = new System.Drawing.Point(90, 75);
            this.SettingZipFolderText.Margin = new System.Windows.Forms.Padding(2);
            this.SettingZipFolderText.Name = "SettingZipFolderText";
            this.SettingZipFolderText.Size = new System.Drawing.Size(322, 23);
            this.SettingZipFolderText.TabIndex = 4;
            this.SettingZipFolderText.Click += new System.EventHandler(this.SettingZipFolderText_Click);
            // 
            // SettingCancelBtn
            // 
            this.SettingCancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingCancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingCancelBtn.Location = new System.Drawing.Point(260, 152);
            this.SettingCancelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SettingCancelBtn.Name = "SettingCancelBtn";
            this.SettingCancelBtn.Size = new System.Drawing.Size(71, 31);
            this.SettingCancelBtn.TabIndex = 5;
            this.SettingCancelBtn.Text = "取消(&C)";
            this.SettingCancelBtn.UseVisualStyleBackColor = true;
            this.SettingCancelBtn.Click += new System.EventHandler(this.SettingCancelBtn_Click);
            // 
            // SettingSaveBtn
            // 
            this.SettingSaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingSaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingSaveBtn.Location = new System.Drawing.Point(339, 152);
            this.SettingSaveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SettingSaveBtn.Name = "SettingSaveBtn";
            this.SettingSaveBtn.Size = new System.Drawing.Size(71, 31);
            this.SettingSaveBtn.TabIndex = 6;
            this.SettingSaveBtn.Text = "保存(&S)";
            this.SettingSaveBtn.UseVisualStyleBackColor = true;
            this.SettingSaveBtn.Click += new System.EventHandler(this.SettingSaveBtn_Click);
            // 
            // FolderBrowser
            // 
            this.FolderBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(431, 196);
            this.Controls.Add(this.SettingSaveBtn);
            this.Controls.Add(this.SettingCancelBtn);
            this.Controls.Add(this.SettingZipFolderText);
            this.Controls.Add(this.SettingMangaFolderText);
            this.Controls.Add(this.SettingIsZipCB);
            this.Controls.Add(this.SettingZipLabel);
            this.Controls.Add(this.SettingMangaFolder);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SettingMangaFolder;
        private System.Windows.Forms.Label SettingZipLabel;
        private System.Windows.Forms.CheckBox SettingIsZipCB;
        private System.Windows.Forms.TextBox SettingMangaFolderText;
        private System.Windows.Forms.TextBox SettingZipFolderText;
        private System.Windows.Forms.Button SettingCancelBtn;
        private System.Windows.Forms.Button SettingSaveBtn;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
    }
}