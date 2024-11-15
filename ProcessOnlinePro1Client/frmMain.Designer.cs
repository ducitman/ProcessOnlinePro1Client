
namespace ProcessOnlinePro1Client
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.labelSizeName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.labelVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.labelMaterialLot = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.btnOtherSizes = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.btnNextSize = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabOthersSize = new DevExpress.XtraTab.XtraTabPage();
            this.pdfOtherSizes = new DevExpress.XtraPdfViewer.PdfViewer();
            this.xtraTabProcess = new DevExpress.XtraTab.XtraTabPage();
            this.pdfCurrentSize = new DevExpress.XtraPdfViewer.PdfViewer();
            this.xtraTabCounter = new DevExpress.XtraTab.XtraTabPage();
            this.pdfCounterProcess = new DevExpress.XtraPdfViewer.PdfViewer();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::ProcessOnlinePro1Client.WaitForm1), true, true);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MainMonitortoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NextSizetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ZoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExittoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabOthersSize.SuspendLayout();
            this.xtraTabProcess.SuspendLayout();
            this.xtraTabCounter.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer1.Panel1.Controls.Add(this.splitter1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.xtraTabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1845, 856);
            this.splitContainer1.SplitterDistance = 99;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.splitContainer3.Panel1.Controls.Add(this.labelSizeName);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer3.Panel1.ForeColor = System.Drawing.Color.WhiteSmoke;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(1842, 99);
            this.splitContainer3.SplitterDistance = 353;
            this.splitContainer3.TabIndex = 1;
            // 
            // labelSizeName
            // 
            this.labelSizeName.AutoSize = true;
            this.labelSizeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSizeName.Location = new System.Drawing.Point(9, 57);
            this.labelSizeName.Name = "labelSizeName";
            this.labelSizeName.Size = new System.Drawing.Size(162, 32);
            this.labelSizeName.TabIndex = 1;
            this.labelSizeName.Text = "Size Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Size:";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.splitContainer4.Panel1.Controls.Add(this.labelVersion);
            this.splitContainer4.Panel1.Controls.Add(this.label2);
            this.splitContainer4.Panel1.ForeColor = System.Drawing.SystemColors.Control;
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer4.Size = new System.Drawing.Size(1485, 99);
            this.splitContainer4.SplitterDistance = 247;
            this.splitContainer4.TabIndex = 0;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(14, 57);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(119, 32);
            this.labelVersion.TabIndex = 1;
            this.labelVersion.Text = "Version";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Version:";
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.labelMaterialLot);
            this.splitContainer5.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.splitContainer7);
            this.splitContainer5.Size = new System.Drawing.Size(1234, 99);
            this.splitContainer5.SplitterDistance = 289;
            this.splitContainer5.TabIndex = 0;
            // 
            // labelMaterialLot
            // 
            this.labelMaterialLot.AutoSize = true;
            this.labelMaterialLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaterialLot.Location = new System.Drawing.Point(14, 57);
            this.labelMaterialLot.Name = "labelMaterialLot";
            this.labelMaterialLot.Size = new System.Drawing.Size(191, 32);
            this.labelMaterialLot.TabIndex = 1;
            this.labelMaterialLot.Text = "Lot Sản Xuất";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Số Lot Sản Xuất:";
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.Location = new System.Drawing.Point(0, 0);
            this.splitContainer7.Name = "splitContainer7";
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.label3);
            this.splitContainer7.Panel1.Controls.Add(this.labelStatus);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.labelTime);
            this.splitContainer7.Panel2.Controls.Add(this.btnOtherSizes);
            this.splitContainer7.Panel2.Controls.Add(this.label5);
            this.splitContainer7.Panel2.Controls.Add(this.btnNextSize);
            this.splitContainer7.Panel2.Controls.Add(this.btnRefresh);
            this.splitContainer7.Size = new System.Drawing.Size(941, 99);
            this.splitContainer7.SplitterDistance = 275;
            this.splitContainer7.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Trạng Thái:";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(14, 57);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(162, 32);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "Trạng Thái";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.Location = new System.Drawing.Point(503, 55);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(163, 25);
            this.labelTime.TabIndex = 14;
            this.labelTime.Text = "Interval Refresh";
            // 
            // btnOtherSizes
            // 
            this.btnOtherSizes.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOtherSizes.Appearance.Options.UseFont = true;
            this.btnOtherSizes.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOtherSizes.ImageOptions.Image")));
            this.btnOtherSizes.Location = new System.Drawing.Point(328, 24);
            this.btnOtherSizes.Name = "btnOtherSizes";
            this.btnOtherSizes.Size = new System.Drawing.Size(152, 56);
            this.btnOtherSizes.TabIndex = 11;
            this.btnOtherSizes.Text = "Size Khác";
            this.btnOtherSizes.Click += new System.EventHandler(this.btnOtherSizes_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(496, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Thời gian:";
            // 
            // btnNextSize
            // 
            this.btnNextSize.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextSize.Appearance.Options.UseFont = true;
            this.btnNextSize.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNextSize.ImageOptions.Image")));
            this.btnNextSize.Location = new System.Drawing.Point(163, 24);
            this.btnNextSize.Name = "btnNextSize";
            this.btnNextSize.Size = new System.Drawing.Size(159, 56);
            this.btnNextSize.TabIndex = 13;
            this.btnNextSize.Text = "Size Sau";
            this.btnNextSize.Click += new System.EventHandler(this.btnNextSize_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(3, 24);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(154, 56);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Làm Mới ";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 99);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabOthersSize;
            this.xtraTabControl1.Size = new System.Drawing.Size(1845, 753);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabProcess,
            this.xtraTabOthersSize,
            this.xtraTabCounter});
            this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            // 
            // xtraTabOthersSize
            // 
            this.xtraTabOthersSize.Controls.Add(this.pdfOtherSizes);
            this.xtraTabOthersSize.Name = "xtraTabOthersSize";
            this.xtraTabOthersSize.Size = new System.Drawing.Size(1843, 718);
            this.xtraTabOthersSize.Text = "Size Khác";
            // 
            // pdfOtherSizes
            // 
            this.pdfOtherSizes.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pdfOtherSizes.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.pdfOtherSizes.Appearance.Options.UseBackColor = true;
            this.pdfOtherSizes.Appearance.Options.UseBorderColor = true;
            this.pdfOtherSizes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfOtherSizes.Location = new System.Drawing.Point(0, 0);
            this.pdfOtherSizes.Name = "pdfOtherSizes";
            this.pdfOtherSizes.Size = new System.Drawing.Size(1843, 718);
            this.pdfOtherSizes.TabIndex = 3;
            this.pdfOtherSizes.PopupMenuShowing += new DevExpress.XtraPdfViewer.PdfPopupMenuShowingEventHandler(this.pdfOtherSizes_PopupMenuShowing);
            // 
            // xtraTabProcess
            // 
            this.xtraTabProcess.Appearance.PageClient.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.xtraTabProcess.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabProcess.Controls.Add(this.pdfCurrentSize);
            this.xtraTabProcess.Name = "xtraTabProcess";
            this.xtraTabProcess.Size = new System.Drawing.Size(1843, 718);
            this.xtraTabProcess.Text = "Process";
            // 
            // pdfCurrentSize
            // 
            this.pdfCurrentSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfCurrentSize.Location = new System.Drawing.Point(0, 0);
            this.pdfCurrentSize.Name = "pdfCurrentSize";
            this.pdfCurrentSize.Size = new System.Drawing.Size(1843, 718);
            this.pdfCurrentSize.TabIndex = 4;
            this.pdfCurrentSize.PopupMenuShowing += new DevExpress.XtraPdfViewer.PdfPopupMenuShowingEventHandler(this.pdfCurrentSize_PopupMenuShowing);
            // 
            // xtraTabCounter
            // 
            this.xtraTabCounter.Appearance.PageClient.BackColor = System.Drawing.Color.OrangeRed;
            this.xtraTabCounter.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabCounter.Controls.Add(this.pdfCounterProcess);
            this.xtraTabCounter.Name = "xtraTabCounter";
            this.xtraTabCounter.Size = new System.Drawing.Size(1843, 718);
            this.xtraTabCounter.Text = "Counter Process";
            // 
            // pdfCounterProcess
            // 
            this.pdfCounterProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfCounterProcess.Location = new System.Drawing.Point(0, 0);
            this.pdfCounterProcess.Name = "pdfCounterProcess";
            this.pdfCounterProcess.Size = new System.Drawing.Size(1843, 718);
            this.pdfCounterProcess.TabIndex = 0;
            this.pdfCounterProcess.PopupMenuShowing += new DevExpress.XtraPdfViewer.PdfPopupMenuShowingEventHandler(this.pdfCounterProcess_PopupMenuShowing);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Process Online";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMonitortoolStripMenuItem,
            this.ChangeMonitorToolStripMenuItem,
            this.toolStripSeparator3,
            this.RefreshToolStripMenuItem,
            this.NextSizetoolStripMenuItem,
            this.toolStripSeparator1,
            this.ZoomInToolStripMenuItem,
            this.ZoomOutToolStripMenuItem,
            this.toolStripSeparator2,
            this.ExittoolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(227, 246);
            // 
            // MainMonitortoolStripMenuItem
            // 
            this.MainMonitortoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("MainMonitortoolStripMenuItem.Image")));
            this.MainMonitortoolStripMenuItem.Name = "MainMonitortoolStripMenuItem";
            this.MainMonitortoolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.MainMonitortoolStripMenuItem.Text = "Về Màn Chính";
            this.MainMonitortoolStripMenuItem.Click += new System.EventHandler(this.MainMonitortoolStripMenuItem_Click);
            // 
            // ChangeMonitorToolStripMenuItem
            // 
            this.ChangeMonitorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ChangeMonitorToolStripMenuItem.Image")));
            this.ChangeMonitorToolStripMenuItem.Name = "ChangeMonitorToolStripMenuItem";
            this.ChangeMonitorToolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.ChangeMonitorToolStripMenuItem.Text = "Chuyển Màn Phụ";
            this.ChangeMonitorToolStripMenuItem.Click += new System.EventHandler(this.ChangeMonitorToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(223, 6);
            // 
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RefreshToolStripMenuItem.Image")));
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.RefreshToolStripMenuItem.Text = "Làm Mới";
            this.RefreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // NextSizetoolStripMenuItem
            // 
            this.NextSizetoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("NextSizetoolStripMenuItem.Image")));
            this.NextSizetoolStripMenuItem.Name = "NextSizetoolStripMenuItem";
            this.NextSizetoolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.NextSizetoolStripMenuItem.Text = "Size Sau";
            this.NextSizetoolStripMenuItem.Click += new System.EventHandler(this.NextSizetoolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(223, 6);
            // 
            // ZoomInToolStripMenuItem
            // 
            this.ZoomInToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ZoomInToolStripMenuItem.Image")));
            this.ZoomInToolStripMenuItem.Name = "ZoomInToolStripMenuItem";
            this.ZoomInToolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.ZoomInToolStripMenuItem.Text = "Phóng To +++";
            this.ZoomInToolStripMenuItem.Click += new System.EventHandler(this.ZoomInToolStripMenuItem_Click);
            // 
            // ZoomOutToolStripMenuItem
            // 
            this.ZoomOutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ZoomOutToolStripMenuItem.Image")));
            this.ZoomOutToolStripMenuItem.Name = "ZoomOutToolStripMenuItem";
            this.ZoomOutToolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.ZoomOutToolStripMenuItem.Text = "Thu Nhỏ ---";
            this.ZoomOutToolStripMenuItem.Click += new System.EventHandler(this.ZoomOutToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(223, 6);
            // 
            // ExittoolStripMenuItem
            // 
            this.ExittoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ExittoolStripMenuItem.Image")));
            this.ExittoolStripMenuItem.Name = "ExittoolStripMenuItem";
            this.ExittoolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.ExittoolStripMenuItem.Text = "Thoát";
            this.ExittoolStripMenuItem.Click += new System.EventHandler(this.ExittoolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1845, 856);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmMain";
            this.Text = "Process Online ver.24";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel1.PerformLayout();
            this.splitContainer7.Panel2.ResumeLayout(false);
            this.splitContainer7.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
            this.splitContainer7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabOthersSize.ResumeLayout(false);
            this.xtraTabProcess.ResumeLayout(false);
            this.xtraTabCounter.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label labelSizeName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelMaterialLot;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraEditors.SimpleButton btnNextSize;
        private DevExpress.XtraEditors.SimpleButton btnOtherSizes;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.SplitContainer splitContainer7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelStatus;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabProcess;
        private DevExpress.XtraPdfViewer.PdfViewer pdfCurrentSize;
        private DevExpress.XtraTab.XtraTabPage xtraTabOthersSize;
        private DevExpress.XtraPdfViewer.PdfViewer pdfOtherSizes;
        private DevExpress.XtraTab.XtraTabPage xtraTabCounter;
        private DevExpress.XtraPdfViewer.PdfViewer pdfCounterProcess;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ChangeMonitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ZoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MainMonitortoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem NextSizetoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ZoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ExittoolStripMenuItem;
    }
}

