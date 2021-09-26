
namespace MangaDownloader
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainSplit = new System.Windows.Forms.SplitContainer();
            this.MainLeftMainPanel = new System.Windows.Forms.Panel();
            this.MainSeachListView = new System.Windows.Forms.ListView();
            this.SearchImageList = new System.Windows.Forms.ImageList(this.components);
            this.MainLeftTopPanel = new System.Windows.Forms.Panel();
            this.MainHistoryCombo = new System.Windows.Forms.ComboBox();
            this.MainHitoryLabel = new System.Windows.Forms.Label();
            this.MainSearchBtn = new System.Windows.Forms.Button();
            this.MainSearchContent = new System.Windows.Forms.TextBox();
            this.MainMangaSearchLabel = new System.Windows.Forms.Label();
            this.MainMangaSiteCombo = new System.Windows.Forms.ComboBox();
            this.MainMangaSiteLabel = new System.Windows.Forms.Label();
            this.MainMainPanel = new System.Windows.Forms.Panel();
            this.MainMainMainPanel = new System.Windows.Forms.Panel();
            this.MainMainMainBottomPanel = new System.Windows.Forms.Panel();
            this.HistoryChapterText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ChapterCountText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LastUpdateTimeText = new System.Windows.Forms.TextBox();
            this.LastUpdateTime = new System.Windows.Forms.Label();
            this.LastUpdateChapterText = new System.Windows.Forms.TextBox();
            this.LastUpdateChapter = new System.Windows.Forms.Label();
            this.WebPageText = new System.Windows.Forms.TextBox();
            this.WebPageLabel = new System.Windows.Forms.Label();
            this.TotalPB = new System.Windows.Forms.ProgressBar();
            this.CurrentPB = new System.Windows.Forms.ProgressBar();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.CurrentLabel = new System.Windows.Forms.Label();
            this.MainMainMainTopPanel = new System.Windows.Forms.Panel();
            this.MangaPictureBox = new System.Windows.Forms.PictureBox();
            this.MainMainMiddlePanel = new System.Windows.Forms.Panel();
            this.MainChapterListView = new System.Windows.Forms.ListView();
            this.Chapter = new System.Windows.Forms.ColumnHeader();
            this.ChapterListViewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.下载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMainInfoPanel = new System.Windows.Forms.Panel();
            this.MainInfoText = new System.Windows.Forms.TextBox();
            this.帮助ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).BeginInit();
            this.MainSplit.Panel1.SuspendLayout();
            this.MainSplit.Panel2.SuspendLayout();
            this.MainSplit.SuspendLayout();
            this.MainLeftMainPanel.SuspendLayout();
            this.MainLeftTopPanel.SuspendLayout();
            this.MainMainPanel.SuspendLayout();
            this.MainMainMainPanel.SuspendLayout();
            this.MainMainMainBottomPanel.SuspendLayout();
            this.MainMainMainTopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MangaPictureBox)).BeginInit();
            this.MainMainMiddlePanel.SuspendLayout();
            this.ChapterListViewMenu.SuspendLayout();
            this.MainMainInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.帮助ToolStripMenuItem,
            this.帮助ToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1036, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.帮助ToolStripMenuItem.Text = "关于";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // MainSplit
            // 
            this.MainSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainSplit.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.MainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplit.Location = new System.Drawing.Point(0, 24);
            this.MainSplit.Margin = new System.Windows.Forms.Padding(2);
            this.MainSplit.Name = "MainSplit";
            // 
            // MainSplit.Panel1
            // 
            this.MainSplit.Panel1.Controls.Add(this.MainLeftMainPanel);
            this.MainSplit.Panel1.Controls.Add(this.MainLeftTopPanel);
            // 
            // MainSplit.Panel2
            // 
            this.MainSplit.Panel2.Controls.Add(this.MainMainPanel);
            this.MainSplit.Size = new System.Drawing.Size(1036, 566);
            this.MainSplit.SplitterDistance = 288;
            this.MainSplit.TabIndex = 1;
            // 
            // MainLeftMainPanel
            // 
            this.MainLeftMainPanel.Controls.Add(this.MainSeachListView);
            this.MainLeftMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLeftMainPanel.Location = new System.Drawing.Point(0, 106);
            this.MainLeftMainPanel.Name = "MainLeftMainPanel";
            this.MainLeftMainPanel.Size = new System.Drawing.Size(286, 458);
            this.MainLeftMainPanel.TabIndex = 1;
            // 
            // MainSeachListView
            // 
            this.MainSeachListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainSeachListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSeachListView.HideSelection = false;
            this.MainSeachListView.LargeImageList = this.SearchImageList;
            this.MainSeachListView.Location = new System.Drawing.Point(0, 0);
            this.MainSeachListView.Margin = new System.Windows.Forms.Padding(2);
            this.MainSeachListView.MultiSelect = false;
            this.MainSeachListView.Name = "MainSeachListView";
            this.MainSeachListView.Size = new System.Drawing.Size(286, 458);
            this.MainSeachListView.TabIndex = 0;
            this.MainSeachListView.UseCompatibleStateImageBehavior = false;
            this.MainSeachListView.SelectedIndexChanged += new System.EventHandler(this.MainSeachListView_SelectedIndexChanged);
            // 
            // SearchImageList
            // 
            this.SearchImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.SearchImageList.ImageSize = new System.Drawing.Size(250, 250);
            this.SearchImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MainLeftTopPanel
            // 
            this.MainLeftTopPanel.Controls.Add(this.MainHistoryCombo);
            this.MainLeftTopPanel.Controls.Add(this.MainHitoryLabel);
            this.MainLeftTopPanel.Controls.Add(this.MainSearchBtn);
            this.MainLeftTopPanel.Controls.Add(this.MainSearchContent);
            this.MainLeftTopPanel.Controls.Add(this.MainMangaSearchLabel);
            this.MainLeftTopPanel.Controls.Add(this.MainMangaSiteCombo);
            this.MainLeftTopPanel.Controls.Add(this.MainMangaSiteLabel);
            this.MainLeftTopPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainLeftTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainLeftTopPanel.Location = new System.Drawing.Point(0, 0);
            this.MainLeftTopPanel.Margin = new System.Windows.Forms.Padding(2);
            this.MainLeftTopPanel.Name = "MainLeftTopPanel";
            this.MainLeftTopPanel.Size = new System.Drawing.Size(286, 106);
            this.MainLeftTopPanel.TabIndex = 0;
            // 
            // MainHistoryCombo
            // 
            this.MainHistoryCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MainHistoryCombo.FormattingEnabled = true;
            this.MainHistoryCombo.Location = new System.Drawing.Point(73, 43);
            this.MainHistoryCombo.Margin = new System.Windows.Forms.Padding(2);
            this.MainHistoryCombo.Name = "MainHistoryCombo";
            this.MainHistoryCombo.Size = new System.Drawing.Size(203, 25);
            this.MainHistoryCombo.TabIndex = 6;
            this.MainHistoryCombo.SelectedIndexChanged += new System.EventHandler(this.MainHistoryCombo_SelectedIndexChanged);
            // 
            // MainHitoryLabel
            // 
            this.MainHitoryLabel.AutoSize = true;
            this.MainHitoryLabel.Location = new System.Drawing.Point(7, 45);
            this.MainHitoryLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MainHitoryLabel.Name = "MainHitoryLabel";
            this.MainHitoryLabel.Size = new System.Drawing.Size(59, 17);
            this.MainHitoryLabel.TabIndex = 5;
            this.MainHitoryLabel.Text = "下载历史:";
            // 
            // MainSearchBtn
            // 
            this.MainSearchBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.MainSearchBtn.Location = new System.Drawing.Point(214, 72);
            this.MainSearchBtn.Margin = new System.Windows.Forms.Padding(2);
            this.MainSearchBtn.Name = "MainSearchBtn";
            this.MainSearchBtn.Size = new System.Drawing.Size(61, 28);
            this.MainSearchBtn.TabIndex = 4;
            this.MainSearchBtn.Text = "搜索";
            this.MainSearchBtn.UseVisualStyleBackColor = true;
            this.MainSearchBtn.Click += new System.EventHandler(this.MainSearchBtn_Click);
            // 
            // MainSearchContent
            // 
            this.MainSearchContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MainSearchContent.Location = new System.Drawing.Point(73, 76);
            this.MainSearchContent.Margin = new System.Windows.Forms.Padding(2);
            this.MainSearchContent.Name = "MainSearchContent";
            this.MainSearchContent.Size = new System.Drawing.Size(133, 23);
            this.MainSearchContent.TabIndex = 3;
            // 
            // MainMangaSearchLabel
            // 
            this.MainMangaSearchLabel.AutoSize = true;
            this.MainMangaSearchLabel.Location = new System.Drawing.Point(7, 78);
            this.MainMangaSearchLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MainMangaSearchLabel.Name = "MainMangaSearchLabel";
            this.MainMangaSearchLabel.Size = new System.Drawing.Size(59, 17);
            this.MainMangaSearchLabel.TabIndex = 2;
            this.MainMangaSearchLabel.Text = "搜索漫画:";
            // 
            // MainMangaSiteCombo
            // 
            this.MainMangaSiteCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MainMangaSiteCombo.FormattingEnabled = true;
            this.MainMangaSiteCombo.Location = new System.Drawing.Point(73, 10);
            this.MainMangaSiteCombo.Margin = new System.Windows.Forms.Padding(2);
            this.MainMangaSiteCombo.Name = "MainMangaSiteCombo";
            this.MainMangaSiteCombo.Size = new System.Drawing.Size(203, 25);
            this.MainMangaSiteCombo.TabIndex = 1;
            this.MainMangaSiteCombo.SelectedIndexChanged += new System.EventHandler(this.MainMangaSiteCombo_SelectedIndexChanged);
            // 
            // MainMangaSiteLabel
            // 
            this.MainMangaSiteLabel.AutoSize = true;
            this.MainMangaSiteLabel.Location = new System.Drawing.Point(7, 12);
            this.MainMangaSiteLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MainMangaSiteLabel.Name = "MainMangaSiteLabel";
            this.MainMangaSiteLabel.Size = new System.Drawing.Size(47, 17);
            this.MainMangaSiteLabel.TabIndex = 0;
            this.MainMangaSiteLabel.Text = "漫画源:";
            // 
            // MainMainPanel
            // 
            this.MainMainPanel.Controls.Add(this.MainMainMainPanel);
            this.MainMainPanel.Controls.Add(this.MainMainMiddlePanel);
            this.MainMainPanel.Controls.Add(this.MainMainInfoPanel);
            this.MainMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainMainPanel.Margin = new System.Windows.Forms.Padding(2);
            this.MainMainPanel.Name = "MainMainPanel";
            this.MainMainPanel.Size = new System.Drawing.Size(742, 564);
            this.MainMainPanel.TabIndex = 0;
            // 
            // MainMainMainPanel
            // 
            this.MainMainMainPanel.Controls.Add(this.MainMainMainBottomPanel);
            this.MainMainMainPanel.Controls.Add(this.MainMainMainTopPanel);
            this.MainMainMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMainMainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainMainMainPanel.Margin = new System.Windows.Forms.Padding(2);
            this.MainMainMainPanel.Name = "MainMainMainPanel";
            this.MainMainMainPanel.Size = new System.Drawing.Size(250, 564);
            this.MainMainMainPanel.TabIndex = 6;
            // 
            // MainMainMainBottomPanel
            // 
            this.MainMainMainBottomPanel.Controls.Add(this.HistoryChapterText);
            this.MainMainMainBottomPanel.Controls.Add(this.label2);
            this.MainMainMainBottomPanel.Controls.Add(this.ChapterCountText);
            this.MainMainMainBottomPanel.Controls.Add(this.label1);
            this.MainMainMainBottomPanel.Controls.Add(this.LastUpdateTimeText);
            this.MainMainMainBottomPanel.Controls.Add(this.LastUpdateTime);
            this.MainMainMainBottomPanel.Controls.Add(this.LastUpdateChapterText);
            this.MainMainMainBottomPanel.Controls.Add(this.LastUpdateChapter);
            this.MainMainMainBottomPanel.Controls.Add(this.WebPageText);
            this.MainMainMainBottomPanel.Controls.Add(this.WebPageLabel);
            this.MainMainMainBottomPanel.Controls.Add(this.TotalPB);
            this.MainMainMainBottomPanel.Controls.Add(this.CurrentPB);
            this.MainMainMainBottomPanel.Controls.Add(this.TotalLabel);
            this.MainMainMainBottomPanel.Controls.Add(this.CurrentLabel);
            this.MainMainMainBottomPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainMainMainBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainMainMainBottomPanel.Location = new System.Drawing.Point(0, 323);
            this.MainMainMainBottomPanel.Margin = new System.Windows.Forms.Padding(2);
            this.MainMainMainBottomPanel.Name = "MainMainMainBottomPanel";
            this.MainMainMainBottomPanel.Size = new System.Drawing.Size(250, 241);
            this.MainMainMainBottomPanel.TabIndex = 1;
            // 
            // HistoryChapterText
            // 
            this.HistoryChapterText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HistoryChapterText.Location = new System.Drawing.Point(60, 148);
            this.HistoryChapterText.Margin = new System.Windows.Forms.Padding(2);
            this.HistoryChapterText.Name = "HistoryChapterText";
            this.HistoryChapterText.ReadOnly = true;
            this.HistoryChapterText.Size = new System.Drawing.Size(182, 23);
            this.HistoryChapterText.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 152);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "历史下载:";
            // 
            // ChapterCountText
            // 
            this.ChapterCountText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChapterCountText.Location = new System.Drawing.Point(59, 115);
            this.ChapterCountText.Margin = new System.Windows.Forms.Padding(2);
            this.ChapterCountText.Name = "ChapterCountText";
            this.ChapterCountText.ReadOnly = true;
            this.ChapterCountText.Size = new System.Drawing.Size(182, 23);
            this.ChapterCountText.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 118);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "章节数:";
            // 
            // LastUpdateTimeText
            // 
            this.LastUpdateTimeText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LastUpdateTimeText.Location = new System.Drawing.Point(59, 80);
            this.LastUpdateTimeText.Margin = new System.Windows.Forms.Padding(2);
            this.LastUpdateTimeText.Name = "LastUpdateTimeText";
            this.LastUpdateTimeText.ReadOnly = true;
            this.LastUpdateTimeText.Size = new System.Drawing.Size(182, 23);
            this.LastUpdateTimeText.TabIndex = 9;
            // 
            // LastUpdateTime
            // 
            this.LastUpdateTime.AutoSize = true;
            this.LastUpdateTime.Location = new System.Drawing.Point(3, 84);
            this.LastUpdateTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LastUpdateTime.Name = "LastUpdateTime";
            this.LastUpdateTime.Size = new System.Drawing.Size(59, 17);
            this.LastUpdateTime.TabIndex = 8;
            this.LastUpdateTime.Text = "更新时间:";
            // 
            // LastUpdateChapterText
            // 
            this.LastUpdateChapterText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LastUpdateChapterText.Location = new System.Drawing.Point(60, 44);
            this.LastUpdateChapterText.Margin = new System.Windows.Forms.Padding(2);
            this.LastUpdateChapterText.Name = "LastUpdateChapterText";
            this.LastUpdateChapterText.ReadOnly = true;
            this.LastUpdateChapterText.Size = new System.Drawing.Size(182, 23);
            this.LastUpdateChapterText.TabIndex = 7;
            // 
            // LastUpdateChapter
            // 
            this.LastUpdateChapter.AutoSize = true;
            this.LastUpdateChapter.Location = new System.Drawing.Point(2, 48);
            this.LastUpdateChapter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LastUpdateChapter.Name = "LastUpdateChapter";
            this.LastUpdateChapter.Size = new System.Drawing.Size(59, 17);
            this.LastUpdateChapter.TabIndex = 6;
            this.LastUpdateChapter.Text = "更新章节:";
            // 
            // WebPageText
            // 
            this.WebPageText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WebPageText.Location = new System.Drawing.Point(59, 7);
            this.WebPageText.Margin = new System.Windows.Forms.Padding(2);
            this.WebPageText.Name = "WebPageText";
            this.WebPageText.ReadOnly = true;
            this.WebPageText.Size = new System.Drawing.Size(182, 23);
            this.WebPageText.TabIndex = 5;
            // 
            // WebPageLabel
            // 
            this.WebPageLabel.AutoSize = true;
            this.WebPageLabel.Location = new System.Drawing.Point(2, 11);
            this.WebPageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.WebPageLabel.Name = "WebPageLabel";
            this.WebPageLabel.Size = new System.Drawing.Size(35, 17);
            this.WebPageLabel.TabIndex = 4;
            this.WebPageLabel.Text = "网页:";
            // 
            // TotalPB
            // 
            this.TotalPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalPB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.TotalPB.Location = new System.Drawing.Point(59, 209);
            this.TotalPB.Margin = new System.Windows.Forms.Padding(2);
            this.TotalPB.Name = "TotalPB";
            this.TotalPB.Size = new System.Drawing.Size(181, 17);
            this.TotalPB.TabIndex = 3;
            // 
            // CurrentPB
            // 
            this.CurrentPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentPB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.CurrentPB.Location = new System.Drawing.Point(60, 183);
            this.CurrentPB.Margin = new System.Windows.Forms.Padding(2);
            this.CurrentPB.Name = "CurrentPB";
            this.CurrentPB.Size = new System.Drawing.Size(181, 17);
            this.CurrentPB.TabIndex = 2;
            // 
            // TotalLabel
            // 
            this.TotalLabel.AutoSize = true;
            this.TotalLabel.Location = new System.Drawing.Point(2, 211);
            this.TotalLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(59, 17);
            this.TotalLabel.TabIndex = 1;
            this.TotalLabel.Text = "全部章节:";
            // 
            // CurrentLabel
            // 
            this.CurrentLabel.AutoSize = true;
            this.CurrentLabel.Location = new System.Drawing.Point(2, 185);
            this.CurrentLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CurrentLabel.Name = "CurrentLabel";
            this.CurrentLabel.Size = new System.Drawing.Size(59, 17);
            this.CurrentLabel.TabIndex = 0;
            this.CurrentLabel.Text = "当前章节:";
            // 
            // MainMainMainTopPanel
            // 
            this.MainMainMainTopPanel.Controls.Add(this.MangaPictureBox);
            this.MainMainMainTopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMainMainTopPanel.Location = new System.Drawing.Point(0, 0);
            this.MainMainMainTopPanel.Margin = new System.Windows.Forms.Padding(2);
            this.MainMainMainTopPanel.Name = "MainMainMainTopPanel";
            this.MainMainMainTopPanel.Size = new System.Drawing.Size(250, 564);
            this.MainMainMainTopPanel.TabIndex = 0;
            // 
            // MangaPictureBox
            // 
            this.MangaPictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.MangaPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MangaPictureBox.Location = new System.Drawing.Point(0, 0);
            this.MangaPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.MangaPictureBox.Name = "MangaPictureBox";
            this.MangaPictureBox.Size = new System.Drawing.Size(250, 564);
            this.MangaPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MangaPictureBox.TabIndex = 0;
            this.MangaPictureBox.TabStop = false;
            // 
            // MainMainMiddlePanel
            // 
            this.MainMainMiddlePanel.Controls.Add(this.MainChapterListView);
            this.MainMainMiddlePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.MainMainMiddlePanel.Location = new System.Drawing.Point(250, 0);
            this.MainMainMiddlePanel.Margin = new System.Windows.Forms.Padding(2);
            this.MainMainMiddlePanel.Name = "MainMainMiddlePanel";
            this.MainMainMiddlePanel.Size = new System.Drawing.Size(255, 564);
            this.MainMainMiddlePanel.TabIndex = 4;
            // 
            // MainChapterListView
            // 
            this.MainChapterListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Chapter});
            this.MainChapterListView.ContextMenuStrip = this.ChapterListViewMenu;
            this.MainChapterListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainChapterListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainChapterListView.FullRowSelect = true;
            this.MainChapterListView.HideSelection = false;
            this.MainChapterListView.Location = new System.Drawing.Point(0, 0);
            this.MainChapterListView.Margin = new System.Windows.Forms.Padding(2);
            this.MainChapterListView.Name = "MainChapterListView";
            this.MainChapterListView.Size = new System.Drawing.Size(255, 564);
            this.MainChapterListView.TabIndex = 0;
            this.MainChapterListView.UseCompatibleStateImageBehavior = false;
            this.MainChapterListView.View = System.Windows.Forms.View.Details;
            // 
            // Chapter
            // 
            this.Chapter.Text = "章节";
            this.Chapter.Width = 350;
            // 
            // ChapterListViewMenu
            // 
            this.ChapterListViewMenu.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.ChapterListViewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.下载ToolStripMenuItem});
            this.ChapterListViewMenu.Name = "ChapterListViewMenu";
            this.ChapterListViewMenu.Size = new System.Drawing.Size(101, 26);
            // 
            // 下载ToolStripMenuItem
            // 
            this.下载ToolStripMenuItem.Name = "下载ToolStripMenuItem";
            this.下载ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.下载ToolStripMenuItem.Text = "下载";
            this.下载ToolStripMenuItem.Click += new System.EventHandler(this.下载ToolStripMenuItem_Click);
            // 
            // MainMainInfoPanel
            // 
            this.MainMainInfoPanel.Controls.Add(this.MainInfoText);
            this.MainMainInfoPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.MainMainInfoPanel.Location = new System.Drawing.Point(505, 0);
            this.MainMainInfoPanel.Margin = new System.Windows.Forms.Padding(2);
            this.MainMainInfoPanel.Name = "MainMainInfoPanel";
            this.MainMainInfoPanel.Size = new System.Drawing.Size(237, 564);
            this.MainMainInfoPanel.TabIndex = 5;
            // 
            // MainInfoText
            // 
            this.MainInfoText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MainInfoText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainInfoText.Location = new System.Drawing.Point(0, 0);
            this.MainInfoText.Margin = new System.Windows.Forms.Padding(2);
            this.MainInfoText.Multiline = true;
            this.MainInfoText.Name = "MainInfoText";
            this.MainInfoText.ReadOnly = true;
            this.MainInfoText.Size = new System.Drawing.Size(237, 564);
            this.MainInfoText.TabIndex = 0;
            // 
            // 帮助ToolStripMenuItem1
            // 
            this.帮助ToolStripMenuItem1.Name = "帮助ToolStripMenuItem1";
            this.帮助ToolStripMenuItem1.Size = new System.Drawing.Size(44, 22);
            this.帮助ToolStripMenuItem1.Text = "帮助";
            this.帮助ToolStripMenuItem1.Click += new System.EventHandler(this.帮助ToolStripMenuItem1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 590);
            this.Controls.Add(this.MainSplit);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "漫画下载";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MainSplit.Panel1.ResumeLayout(false);
            this.MainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).EndInit();
            this.MainSplit.ResumeLayout(false);
            this.MainLeftMainPanel.ResumeLayout(false);
            this.MainLeftTopPanel.ResumeLayout(false);
            this.MainLeftTopPanel.PerformLayout();
            this.MainMainPanel.ResumeLayout(false);
            this.MainMainMainPanel.ResumeLayout(false);
            this.MainMainMainBottomPanel.ResumeLayout(false);
            this.MainMainMainBottomPanel.PerformLayout();
            this.MainMainMainTopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MangaPictureBox)).EndInit();
            this.MainMainMiddlePanel.ResumeLayout(false);
            this.ChapterListViewMenu.ResumeLayout(false);
            this.MainMainInfoPanel.ResumeLayout(false);
            this.MainMainInfoPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer MainSplit;
        private System.Windows.Forms.Panel MainLeftMainPanel;
        private System.Windows.Forms.Panel MainLeftTopPanel;
        private System.Windows.Forms.Label MainMangaSiteLabel;
        private System.Windows.Forms.ComboBox MainMangaSiteCombo;
        private System.Windows.Forms.Label MainMangaSearchLabel;
        private System.Windows.Forms.TextBox MainSearchContent;
        private System.Windows.Forms.Button MainSearchBtn;
        private System.Windows.Forms.Label MainHitoryLabel;
        private System.Windows.Forms.ComboBox MainHistoryCombo;
        private System.Windows.Forms.ListView MainSeachListView;
        private System.Windows.Forms.ImageList SearchImageList;
        private System.Windows.Forms.Panel MainMainPanel;
        private System.Windows.Forms.Panel MainMainMiddlePanel;
        private System.Windows.Forms.ListView MainChapterListView;
        private System.Windows.Forms.ColumnHeader Chapter;
        private System.Windows.Forms.Panel MainMainInfoPanel;
        private System.Windows.Forms.TextBox MainInfoText;
        private System.Windows.Forms.Panel MainMainMainPanel;
        private System.Windows.Forms.Panel MainMainMainTopPanel;
        private System.Windows.Forms.PictureBox MangaPictureBox;
        private System.Windows.Forms.Panel MainMainMainBottomPanel;
        private System.Windows.Forms.Label CurrentLabel;
        private System.Windows.Forms.Label TotalLabel;
        private System.Windows.Forms.ProgressBar TotalPB;
        private System.Windows.Forms.ProgressBar CurrentPB;
        private System.Windows.Forms.Label WebPageLabel;
        private System.Windows.Forms.TextBox WebPageText;
        private System.Windows.Forms.TextBox LastUpdateTimeText;
        private System.Windows.Forms.Label LastUpdateTime;
        private System.Windows.Forms.TextBox LastUpdateChapterText;
        private System.Windows.Forms.Label LastUpdateChapter;
        private System.Windows.Forms.TextBox HistoryChapterText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ChapterCountText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip ChapterListViewMenu;
        private System.Windows.Forms.ToolStripMenuItem 下载ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem1;
    }
}

