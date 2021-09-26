using DALS;
using MangaDownloader.Model;
using MangeDownload.Models;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangaDownloader
{
    public partial class Main : Form
    {
        #region 配置及变量
        private readonly string MangaSiteAssembly = "Services";
        private readonly string MangaSiteClassPathPrefix = "Services.Manga.";
        private readonly List<string> MangaSiteList = new() { "Manhua123Site", "IKHMSite", "_18ComicVipSite" };
        private IMangaSite MangaSite;
        private IMangaInfo MangaInfo;
        private readonly MangaDAL business = new();
        #endregion

        #region 行为
        public Main()
        {
            InitializeComponent();
        }

        #region 菜单
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About helper = new();
            helper.ShowDialog();
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting setting = new();
            setting.ShowDialog();
        }

        private void 帮助ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Helper helper = new();
            helper.ShowDialog();
        }
        #endregion

        #region 界面
        private void 下载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainChapterListView.SelectedItems.Count > 0 && MangaInfo != null)
            {
                var mangaSetting = new MangaDAL().GetMangaSetting();

                if (mangaSetting == null || string.IsNullOrEmpty(mangaSetting.MangaFolder) || string.IsNullOrEmpty(mangaSetting.ZipFolder))
                {
                    MessageBox.Show("需要先去设置页面配置下载地址", "警告", MessageBoxButtons.OK);

                    return;
                }

                Download(mangaSetting.MangaFolder, mangaSetting.ZipFolder, mangaSetting.IsZip);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitMangaSiteCombo();
        }

        private void MainMangaSiteCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetGlobal();

            MangaSite = ((MangaSiteComboItem)MainMangaSiteCombo.SelectedItem).Tag;
            MangaInfo = (IMangaInfo)System.Reflection.Assembly.Load(MangaSiteAssembly).CreateInstance(((MangaSiteComboItem)MainMangaSiteCombo.SelectedItem).MangaInfoClassPath, false);

            GetMangaSiteHistory();
        }

        private void MainHistoryCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MangaSite != null)
            {
                var history = ((MangaHistoryComboItem)MainHistoryCombo.SelectedItem).Tag;

                if (history != null)
                {
                    DoSearch(history.MangaName);
                }
            }
        }

        private void MainSearchBtn_Click(object sender, EventArgs e)
        {
            if (MangaSite != null && !string.IsNullOrEmpty(MainSearchContent.Text))
            {
                DoSearch(MainSearchContent.Text);
            }
            else 
            {
                MessageBox.Show("没有选择漫画源或者没有填写搜索内容", "警告", MessageBoxButtons.OK);
            }
        }

        private void MainSeachListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainSeachListView.SelectedItems.Count > 0 && MangaInfo != null)
            {
                MangaInfo.mi = (MangaInfo)MainSeachListView.SelectedItems[0].Tag;

                Progress<ListViewItem> progress = new();
                progress.ProgressChanged += ChapterListViewAdd;

                DoAddAdditionalInfo(progress);
            }
        }
        #endregion
        #endregion

        #region 方法
        private void ResetGlobal()
        {
            MangaInfo = null;
            MangaSite = null;
            MainSearchContent.Text = "";
            MainHistoryCombo.Items.Clear();
            MangaPictureBox.Image = null;
            MainSeachListView.Items.Clear();
            SearchImageList.Images.Clear();
            MainChapterListView.Items.Clear();
            CurrentPB.Value = 0;
            TotalPB.Value = 0;
            WebPageText.Text = "";
            LastUpdateChapterText.Text = "";
            LastUpdateTimeText.Text = "";
            ChapterCountText.Text = "";
            HistoryChapterText.Text = "";
            MainInfoText.Text = "";
        }

        private void InitMangaSiteCombo()
        {
            MainMangaSiteCombo.DisplayMember = "ShowTitle";
            MainMangaSiteCombo.ValueMember = "MangaInfoClassPath";

            MainMangaSiteCombo.Items.Clear();

            foreach (var site in MangaSiteList)
            { 
                IMangaSite tempSite = (IMangaSite)System.Reflection.Assembly.Load(MangaSiteAssembly).CreateInstance(MangaSiteClassPathPrefix + site, false);

                MainMangaSiteCombo.Items.Add(new MangaSiteComboItem (){ ShowTitle = tempSite.siteModel.ShowTitle, MangaInfoClassPath = MangaSiteClassPathPrefix + site.Replace("Site", "Info"), Tag = tempSite });
            }
        }

        private void GetMangaSiteHistory()
        {
            MainHistoryCombo.DisplayMember = "MangaName";

            MainHistoryCombo.Items.Clear();

            if (MangaSite != null && MangaSite.siteModel != null)
            {
                var history = business.GetMangaHistory(MangaSite.siteModel.ShowTitle);

                if (history != null && history.Any())
                {
                    foreach (var mangaHistory in history)
                    {
                        MainHistoryCombo.Items.Add(new MangaHistoryComboItem() { MangaName = mangaHistory.MangaName, Tag = mangaHistory });
                    }
                }
                else
                {
                    MainHistoryCombo.Items.Add(new MangaHistoryComboItem() { MangaName = "无", Tag = null });
                }
            }
        }

        private async void DoSearch(string content)
        {
            MainSeachListView.Items.Clear();
            SearchImageList.Images.Clear();

            var result = await MangaSite.Search(content);

            if (result != null && result.Any())
            {
                foreach (var res in result)
                {
                    using HttpClient c = new();
                    try
                    {
                        using Stream s = await c.GetStreamAsync(res.mi.MangaPic);
                        SearchImageList.Images.Add(res.mi.MangaName, Image.FromStream(s));
                    }
                    catch
                    {

                    }

                    ListViewItem lvi = new(res.mi.MangaName);
                    lvi.Tag = res.mi;

                    lvi.ImageIndex = SearchImageList.Images.IndexOfKey(res.mi.MangaName);
                    MainSeachListView.Items.Add(lvi);
                }
            }
            else
            {
                MessageBox.Show("没有找到所要搜索的漫画", "提示", MessageBoxButtons.OK);
            }
        }

        private async void DoAddAdditionalInfo(IProgress<ListViewItem> report)
        {
            MangaPictureBox.Image = null;
            MainChapterListView.Items.Clear();
            CurrentPB.Value = 0;
            TotalPB.Value = 0;
            WebPageText.Text = "";
            LastUpdateChapterText.Text = "";
            LastUpdateTimeText.Text = "";
            ChapterCountText.Text = "";
            HistoryChapterText.Text = "";
            MainInfoText.Text = "";

            await MangaInfo.AddAdditionalInfo();

            using HttpClient c = new();
            try
            {
                using Stream s = await c.GetStreamAsync(MangaInfo.mi.MangaPic);
                MangaPictureBox.Image =  Image.FromStream(s);
            }
            catch
            {

            }

            var history = business.GetMangaHistory(MangaSite.siteModel.ShowTitle).FirstOrDefault(x => x.MangaName == MangaInfo.mi.MangaName);

            WebPageText.Text = MangaInfo.mi.MangeUrl;
            LastUpdateChapterText.Text = MangaInfo.mi.LastChapter;
            LastUpdateTimeText.Text = MangaInfo.mi.LastUpdateTimeStr;

            ChapterCountText.Text = MangaInfo.mi.Urls.Count + "章";
            HistoryChapterText.Text = history == null ? "无" : history.DownloadedChapter.Count + "章";

            await Task.Run(() =>
            {
                foreach (var url in MangaInfo.mi.Urls)
                {
                    ListViewItem lvi = new(url.Title);
                    lvi.Tag = url;

                    if (history != null && history.DownloadedChapter.Exists(x => x == url.Title))
                    {
                        lvi.BackColor = Color.Green;
                    }

                    report.Report(lvi);
                }
            });
        }

        private void ChapterListViewAdd(object sender, ListViewItem e)
        {
            MainChapterListView.Items.Add(e);
        }

        private async void Download(string folder, string zipFolder, bool isZip)
        {
            List<DetailUrl> downloadList = new();

            foreach (ListViewItem item in MainChapterListView.SelectedItems)
            {
                downloadList.Add((DetailUrl)item.Tag);
            }

            MainInfoText.AppendText("开始下载" + Environment.NewLine);

            Progress<(string name, int value)> pbProgress = new();
            Progress<string> infoProgress = new();

            pbProgress.ProgressChanged += PbChanged;
            infoProgress.ProgressChanged += InfoChanged;

            var rootFolder = await MangaInfo.Download(folder, downloadList, pbProgress, infoProgress);

            MainInfoText.AppendText("下载完毕" + Environment.NewLine);

            if (isZip)
            {
                MainInfoText.AppendText($"设置为压缩，现在开始压缩 {rootFolder} 到 {zipFolder} " + Environment.NewLine);

                var zip = zipFolder + MangaInfo.mi.MangaName + "_" + DateTime.Now.ToString("yyy-MM-dd-HH-mm-ss") + "-" + downloadList.Count + ".zip";

                ZipFile.CreateFromDirectory(rootFolder, zip);

                MainInfoText.AppendText($"已经压缩到{zip}" + Environment.NewLine);
            }
            else
            {
                MainInfoText.AppendText($"设置不压缩，下载已完成，漫画文件夹为{rootFolder}" + Environment.NewLine);
            }

            MainInfoText.AppendText("开始保存设置" + Environment.NewLine);

            MangaHistory history = new();
            history.MangaSite = MangaSite.siteModel.ShowTitle;
            history.MangaName = MangaInfo.mi.MangaName;
            var tempDownloadedStr = string.Join(",", downloadList.Select(x => x.Title));
            history.LastDownloadTimeStr = DateTime.Now.ToString("yyyy-MM-dd");
            history.MangaUrl = MangaInfo.mi.MangeUrl;

            var mangaHistory = business.GetMangaHistory(MangaSite.siteModel.ShowTitle).FirstOrDefault(x => x.MangaName == MangaInfo.mi.MangaName);

            if (mangaHistory == null)
            {
                history.Downloaded = tempDownloadedStr;
                business.InsertMangaHistory(history);
            }
            else
            {
                history.Downloaded += mangaHistory.Downloaded + "," + tempDownloadedStr;
                business.UpdateMangaHistory(history);
            }

            GetMangaSiteHistory();

            MainInfoText.AppendText("下载完成" + Environment.NewLine);
        }

        private void InfoChanged(object sender, string e)
        {
            MainInfoText.AppendText(e + Environment.NewLine);
        }

        private void PbChanged(object sender, (string name, int value) e)
        {
            switch (e.name)
            {
                case "totalmax":
                    TotalPB.Maximum = e.value;
                    break;
                case "totalvalue":
                    TotalPB.Value = e.value;
                    break;
                case "currentmax":
                    CurrentPB.Maximum = e.value;
                    break;
                case "currentvalue":
                    CurrentPB.Value = e.value;
                    break;
                default:
                    break;
            }
        }
        #endregion

    }
}
