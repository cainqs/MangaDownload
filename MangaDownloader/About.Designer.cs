
namespace MangaDownloader
{
    partial class About
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
            this.HelperBottomPanel = new System.Windows.Forms.Panel();
            this.HelperCloseBtn = new System.Windows.Forms.Button();
            this.HelperMainPanel = new System.Windows.Forms.Panel();
            this.HelperText = new System.Windows.Forms.TextBox();
            this.HelperBottomPanel.SuspendLayout();
            this.HelperMainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HelperBottomPanel
            // 
            this.HelperBottomPanel.Controls.Add(this.HelperCloseBtn);
            this.HelperBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HelperBottomPanel.Location = new System.Drawing.Point(0, 450);
            this.HelperBottomPanel.Name = "HelperBottomPanel";
            this.HelperBottomPanel.Size = new System.Drawing.Size(486, 59);
            this.HelperBottomPanel.TabIndex = 0;
            // 
            // HelperCloseBtn
            // 
            this.HelperCloseBtn.Location = new System.Drawing.Point(163, 4);
            this.HelperCloseBtn.Name = "HelperCloseBtn";
            this.HelperCloseBtn.Size = new System.Drawing.Size(131, 49);
            this.HelperCloseBtn.TabIndex = 0;
            this.HelperCloseBtn.Text = "确认(&O)";
            this.HelperCloseBtn.UseVisualStyleBackColor = true;
            this.HelperCloseBtn.Click += new System.EventHandler(this.HelperCloseBtn_Click);
            // 
            // HelperMainPanel
            // 
            this.HelperMainPanel.Controls.Add(this.HelperText);
            this.HelperMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HelperMainPanel.Location = new System.Drawing.Point(0, 0);
            this.HelperMainPanel.Name = "HelperMainPanel";
            this.HelperMainPanel.Size = new System.Drawing.Size(486, 450);
            this.HelperMainPanel.TabIndex = 1;
            // 
            // HelperText
            // 
            this.HelperText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HelperText.Location = new System.Drawing.Point(0, 0);
            this.HelperText.Multiline = true;
            this.HelperText.Name = "HelperText";
            this.HelperText.ReadOnly = true;
            this.HelperText.Size = new System.Drawing.Size(486, 450);
            this.HelperText.TabIndex = 0;
            this.HelperText.Text = "\r\n\r\n\r\n\r\n\r\n漫画下载器，是本人兴趣所致，并已学习技术为本意。\r\n\r\n\r\n请不要用下载的漫画从事营利活动，并在阅读完删除漫画";
            this.HelperText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Helper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 509);
            this.Controls.Add(this.HelperMainPanel);
            this.Controls.Add(this.HelperBottomPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Helper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "帮助";
            this.HelperBottomPanel.ResumeLayout(false);
            this.HelperMainPanel.ResumeLayout(false);
            this.HelperMainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel HelperBottomPanel;
        private System.Windows.Forms.Button HelperCloseBtn;
        private System.Windows.Forms.Panel HelperMainPanel;
        private System.Windows.Forms.TextBox HelperText;
    }
}