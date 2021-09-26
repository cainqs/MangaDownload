using DALS;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangaDownloader
{
    public partial class Setting : Form
    {
        private MangaSetting mangaSetting;
        private MangaDAL business = new();

        public Setting()
        {
            InitializeComponent();
        }

        private void SettingCancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SettingSaveBtn_Click(object sender, EventArgs e)
        {
            int ret;

            if (!string.IsNullOrEmpty(SettingMangaFolderText.Text) || !string.IsNullOrEmpty(SettingZipFolderText.Text))
            {
                if (!SettingMangaFolderText.Text.EndsWith(Path.DirectorySeparatorChar))
                {
                    SettingMangaFolderText.Text += Path.DirectorySeparatorChar;
                }

                if (!SettingZipFolderText.Text.EndsWith(Path.DirectorySeparatorChar))
                {
                    SettingZipFolderText.Text += Path.DirectorySeparatorChar;
                }

                if (mangaSetting != null)
                {
                    mangaSetting.MangaFolder = SettingMangaFolderText.Text;
                    mangaSetting.ZipFolder = SettingZipFolderText.Text;
                    mangaSetting.IsZip = SettingIsZipCB.Checked;

                    ret = business.UpdateMangaSetting(mangaSetting);
                }
                else
                {
                    mangaSetting = new();
                    mangaSetting.MangaFolder = SettingMangaFolderText.Text;
                    mangaSetting.ZipFolder = SettingZipFolderText.Text;
                    mangaSetting.IsZip = SettingIsZipCB.Checked;

                    ret = business.InserMangaSetting(mangaSetting);
                }

                if (ret > 0)
                {
                    Close();
                }
                else
                {
                    MessageBox.Show("保存失败!", "警告", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("漫画根目录和压缩目录必填", "警告", MessageBoxButtons.OK);
            }
        }

        private void SettingMangaFolderText_Click(object sender, EventArgs e)
        {
            var res = FolderBrowser.ShowDialog();

            if (res == DialogResult.OK || res == DialogResult.Yes)
            {
                SettingMangaFolderText.Text = FolderBrowser.SelectedPath;
            }
        }

        private void SettingZipFolderText_Click(object sender, EventArgs e)
        {
            var res = FolderBrowser.ShowDialog();

            if (res == DialogResult.OK || res == DialogResult.Yes)
            {
                SettingZipFolderText.Text = FolderBrowser.SelectedPath;
            }
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            mangaSetting = business.GetMangaSetting();

            if (mangaSetting != null)
            {
                SettingMangaFolderText.Text = mangaSetting.MangaFolder;
                SettingZipFolderText.Text = mangaSetting.ZipFolder;
                SettingIsZipCB.Checked = mangaSetting.IsZip;
            }
        }
    }
}
