
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
            this.SettingMangaFolder.Location = new System.Drawing.Point(28, 56);
            this.SettingMangaFolder.Name = "SettingMangaFolder";
            this.SettingMangaFolder.Size = new System.Drawing.Size(122, 28);
            this.SettingMangaFolder.TabIndex = 0;
            this.SettingMangaFolder.Text = "漫画根目录:";
            // 
            // SettingZipLabel
            // 
            this.SettingZipLabel.AutoSize = true;
            this.SettingZipLabel.Location = new System.Drawing.Point(28, 126);
            this.SettingZipLabel.Name = "SettingZipLabel";
            this.SettingZipLabel.Size = new System.Drawing.Size(122, 28);
            this.SettingZipLabel.TabIndex = 1;
            this.SettingZipLabel.Text = "压缩包目录:";
            // 
            // SettingIsZipCB
            // 
            this.SettingIsZipCB.AutoSize = true;
            this.SettingIsZipCB.Location = new System.Drawing.Point(28, 195);
            this.SettingIsZipCB.Name = "SettingIsZipCB";
            this.SettingIsZipCB.Size = new System.Drawing.Size(122, 32);
            this.SettingIsZipCB.TabIndex = 2;
            this.SettingIsZipCB.Text = "是否压缩";
            this.SettingIsZipCB.UseVisualStyleBackColor = true;
            // 
            // SettingMangaFolderText
            // 
            this.SettingMangaFolderText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingMangaFolderText.Location = new System.Drawing.Point(167, 53);
            this.SettingMangaFolderText.Name = "SettingMangaFolderText";
            this.SettingMangaFolderText.Size = new System.Drawing.Size(594, 34);
            this.SettingMangaFolderText.TabIndex = 3;
            this.SettingMangaFolderText.Click += new System.EventHandler(this.SettingMangaFolderText_Click);
            // 
            // SettingZipFolderText
            // 
            this.SettingZipFolderText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingZipFolderText.Location = new System.Drawing.Point(167, 123);
            this.SettingZipFolderText.Name = "SettingZipFolderText";
            this.SettingZipFolderText.Size = new System.Drawing.Size(594, 34);
            this.SettingZipFolderText.TabIndex = 4;
            this.SettingZipFolderText.Click += new System.EventHandler(this.SettingZipFolderText_Click);
            // 
            // SettingCancelBtn
            // 
            this.SettingCancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingCancelBtn.Location = new System.Drawing.Point(483, 251);
            this.SettingCancelBtn.Name = "SettingCancelBtn";
            this.SettingCancelBtn.Size = new System.Drawing.Size(131, 51);
            this.SettingCancelBtn.TabIndex = 5;
            this.SettingCancelBtn.Text = "取消(&C)";
            this.SettingCancelBtn.UseVisualStyleBackColor = true;
            this.SettingCancelBtn.Click += new System.EventHandler(this.SettingCancelBtn_Click);
            // 
            // SettingSaveBtn
            // 
            this.SettingSaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingSaveBtn.Location = new System.Drawing.Point(630, 251);
            this.SettingSaveBtn.Name = "SettingSaveBtn";
            this.SettingSaveBtn.Size = new System.Drawing.Size(131, 51);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 323);
            this.Controls.Add(this.SettingSaveBtn);
            this.Controls.Add(this.SettingCancelBtn);
            this.Controls.Add(this.SettingZipFolderText);
            this.Controls.Add(this.SettingMangaFolderText);
            this.Controls.Add(this.SettingIsZipCB);
            this.Controls.Add(this.SettingZipLabel);
            this.Controls.Add(this.SettingMangaFolder);
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