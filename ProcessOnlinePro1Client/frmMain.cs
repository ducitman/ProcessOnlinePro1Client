using DevExpress.XtraTab;
using ProcessOnlinePro1Client.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessOnlinePro1Client
{
    public partial class frmMain : Form
    {
        string _pdfUrl = @"http://10.118.11.112/Common/API/API/file/MTRL?";
        string _pdfCurrentSize = "";
        string _pdfNextSize = "";
        string _pdfOthertSize = "";
        string _machineName = Environment.MachineName;
        string _machineID = "";
        string _machineGroup = "";
        string _pdfLocation = "";
        string _pdfProcessName = "";
        string _currentSizeStatus = "1";
        string _oldSizeStatus = "3";
        string _nextSizeStatus = "0";
        string _otherSizeStatus = "2";
        int _maxMinute = Properties.Settings.Default.RefreshMinutes;
        int _countMinute;
        int _countSecond = 0;
        DbBusiness _dbBusiness = new DbBusiness();
        DataTable _dataCurrentSchedule = new DataTable();
        DataTable _dataOldSchedule = new DataTable();
        DataTable _dataNextSchedule = new DataTable();
        public frmMain()
        {
            InitializeComponent();
            try
            {
                Process thisProc = Process.GetCurrentProcess();
                if (IsProcessOpen("ProcessOnlinePro1Client"))
                {
                    if (Process.GetProcessesByName(thisProc.ProcessName).Length > 1)
                    {
                        // If ther is more than one, than it is already running.
                        MessageBox.Show("Đã có chương trình đang được chạy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
        //kiểm tra form có đang chạy hay không
        public bool IsProcessOpen(string name)
        {

            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    //clsProcess.Kill();
                    return true;
                }
            }

            return false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Resize += new EventHandler(frmMain_Resize);
            splitContainer3.SplitterDistance = splitContainer3.Width / 5;
            splitContainer3.FixedPanel = FixedPanel.Panel1;
            splitContainer3.IsSplitterFixed = true;
            splitContainer4.SplitterDistance = splitContainer3.Width / 7;
            splitContainer4.FixedPanel = FixedPanel.Panel1;
            splitContainer4.IsSplitterFixed = true;
            splitContainer5.SplitterDistance = splitContainer3.Width / 7;
            splitContainer5.FixedPanel = FixedPanel.Panel1;
            splitContainer5.IsSplitterFixed = true;
            splitContainer1.SplitterDistance = 80;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.IsSplitterFixed = true;
            Properties.Settings.Default.isTerminalPC = _dbBusiness.isTerminalPC(_machineName);
            this.Text += "- Máy:" + _machineName;
            pdfCurrentSize.ReadOnly = true;
            pdfCounterProcess.ReadOnly = true;
            pdfOtherSizes.ReadOnly = true;
            pdfCurrentSize.NavigationPanePageVisibility = DevExpress.XtraPdfViewer.PdfNavigationPanePageVisibility.None;
            pdfOtherSizes.NavigationPanePageVisibility = DevExpress.XtraPdfViewer.PdfNavigationPanePageVisibility.None;
            pdfCounterProcess.NavigationPanePageVisibility = DevExpress.XtraPdfViewer.PdfNavigationPanePageVisibility.None;
            if (Properties.Settings.Default.isTerminalPC)
            {
                GetPDFLocation();
                ProcessData(_currentSizeStatus);
                xtraTabOthersSize.PageVisible = false;
                timer1.Enabled = true;
                timer1.Start();
            }
            else
            {
                btnRefresh.Enabled = false;
                btnNextSize.Enabled = false;
                xtraTabProcess.PageVisible = false;
            }
        }
        public string isValidApplicationDate(string materialSize, string machineGroup)
        {
            string result = "NG";
            //Get applicationdate revision
            DataTable tbl = _dbBusiness.GetOldAndNewApplicationdateRevision(materialSize, machineGroup);
            _dataOldSchedule = new DataTable();
            if(_dataOldSchedule.Columns.Count == 0)
            {
                _dataOldSchedule.Columns.Add("MATERIALSIZE");
                _dataOldSchedule.Columns.Add("MATERIALLOTNO");
                _dataOldSchedule.Columns.Add("WORKINGDATETIME");
                _dataOldSchedule.Columns.Add("SCHEDULEORDER");
                _dataOldSchedule.Columns.Add("REVISIONNO");
                _dataOldSchedule.Columns.Add("STATUSFLAG");
            }
            
            //Return process revision
            if (tbl.Rows.Count == 2)
            {
                DateTime newApplicationDate = DateTime.ParseExact(tbl.Rows[0]["APPLICATIONDATE"].ToString().Substring(0,8),"yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                DateTime oldApplicationDate = DateTime.ParseExact(tbl.Rows[1]["APPLICATIONDATE"].ToString().Substring(0, 8), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                if(newApplicationDate > DateTime.Now && oldApplicationDate < DateTime.Now)
                {
                    DataRow row = _dataOldSchedule.NewRow();
                    row.ItemArray = _dataCurrentSchedule.Rows[0].ItemArray;
                    row["REVISIONNO"] = tbl.Rows[1]["REVISIONNO"].ToString();
                    _dataOldSchedule.Rows.Add(row);
                    return "Old";
                }
                else if(newApplicationDate <= DateTime.Now && oldApplicationDate < DateTime.Now)
                {                    
                    return "New";
                }
                else
                {
                    return "NG";
                }
            }
            else if(tbl.Rows.Count == 1)
            {
                DateTime applicationDate = DateTime.ParseExact(tbl.Rows[0]["APPLICATIONDATE"].ToString().Substring(0, 8), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                if (applicationDate > DateTime.Now)
                {
                    result = "NG";
                }
                else
                {
                    result = "New";
                }
            }
            else
            {
                result = "NG";
            }
            return result;
        }
        private void ProcessData(string status)
        {
            this._countMinute = this._maxMinute;
            this._countSecond = 0;
            switch (status)
            {
                case "1":
                    GetCurrentScheduleData();
                    try
                    {
                        if (_dataCurrentSchedule.Rows.Count > 0)
                        {
                            if(isValidApplicationDate(_dataCurrentSchedule.Rows[0]["MATERIALSIZE"].ToString().Trim(), _machineGroup).Contains("New"))
                            {
                                DownloadPDF(_currentSizeStatus);
                                DisplayData(_dataCurrentSchedule);
                            }
                            else
                            {
                                DownloadPDF(_oldSizeStatus);
                                DisplayData(_dataOldSchedule);
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi");
                    }                                       
                    break;
                case "0":
                    GetNextScheduleData();
                    try
                    {
                        if (_dataNextSchedule.Rows.Count > 0)
                        {
                            DownloadPDF(_nextSizeStatus);
                            DisplayData(_dataNextSchedule);
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi");
                    }                                      
                    break;
                case "2":
                    GetNextScheduleData();
                    try
                    {
                        DownloadPDF(_nextSizeStatus);
                        DisplayData(_dataNextSchedule);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi");
                    }                    
                    break;
            }            
        }
        private void GetCurrentScheduleData()
        {
            _dataCurrentSchedule = _dbBusiness.GetCurrentSchedulelotData(_machineID,_machineGroup);
        }
        private void GetNextScheduleData()
        {
            _dataNextSchedule = _dbBusiness.GetNextSchedulelotData(_machineID, _machineGroup);
        }
        public void GetOtherSizeData()
        {

        }
        private void GetPDFLocation()
        {
            DataTable dataMachineInfor = _dbBusiness.GetMachineInformation(_machineName);
            _machineID = dataMachineInfor.Rows[0]["MACHINEID"].ToString();
            _machineGroup = dataMachineInfor.Rows[0]["MACHINEGROUP"].ToString();
            switch (_machineGroup)
            {
                case "51":
                    _pdfLocation = "TOP_1";
                    break;
                case "5A":
                    _pdfLocation = "TOP_2";
                    break;
                case "5B":
                    _pdfLocation = "TOP_3";
                    break;
                case "53":
                    _pdfLocation = "SIDE_1";
                    break;
                case "5P":
                    _pdfLocation = "SIDE_2";
                    break;
                case "5Q":
                    _pdfLocation = "SIDE_3";
                    break;
                case "55":
                    _pdfLocation = "BF";
                    break;
                case "61":
                    _pdfLocation = "PLY";
                    break;
                case "62":
                    _pdfLocation = "SQPRESET";
                    break;
                case "65":
                    _pdfLocation = "BEXTERCUTTER";
                    break;
                case "6D":
                    _pdfLocation = "BEXTERINS_4";
                    break;
                case "6C":
                    _pdfLocation = "BEXTERINS_3";
                    break;
                case "64":
                    _pdfLocation = "BEXTERINS_2";
                    break;
                case "6B":
                    _pdfLocation = "BEXTERINS_1";
                    break;
                case "66":
                    _pdfLocation = "1STLAYER";
                    break;
                case "68":
                    _pdfLocation = "2NDLAYER";
                    break;
                case "69":
                    _pdfLocation = "CCHCUTTER";
                    break;
                case "63":
                    _pdfLocation = "CCHSLITTER";
                    break;
                case "70":
                    _pdfLocation = "2RH";
                    break;
                case "71":
                    _pdfLocation = "3PA";
                    break;
                case "74":
                    _pdfLocation = "TEXCAL";
                    break;
                case "75":
                    _pdfLocation = "SMALLCAL";
                    break;
                case "77":
                    _pdfLocation = "SMALLSLITTER";
                    break;
                case "81":
                    _pdfLocation = "BEAD";
                    break;
                case "85":
                    _pdfLocation = "BEADPRESET";
                    break;
            }
        }
        private string GetPDFLocation(string _machineGroup)
        {
            string _pdfLocation = "";
            switch (_machineGroup)
            {
                case "51":
                    _pdfLocation = "TOP_1";
                    break;
                case "5A":
                    _pdfLocation = "TOP_2";
                    break;
                case "5B":
                    _pdfLocation = "TOP_3";
                    break;
                case "53":
                    _pdfLocation = "SIDE_1";
                    break;
                case "5P":
                    _pdfLocation = "SIDE_2";
                    break;
                case "5Q":
                    _pdfLocation = "SIDE_3";
                    break;
                case "55":
                    _pdfLocation = "BF";
                    break;
                case "61":
                    _pdfLocation = "PLY";
                    break;
                case "62":
                    _pdfLocation = "SQPRESET";
                    break;
                case "65":
                    _pdfLocation = "BEXTERCUTTER";
                    break;
                case "6D":
                    _pdfLocation = "BEXTERINS_4";
                    break;
                case "6C":
                    _pdfLocation = "BEXTERINS_3";
                    break;
                case "64":
                    _pdfLocation = "BEXTERINS_2";
                    break;
                case "6B":
                    _pdfLocation = "BEXTERINS_1";
                    break;
                case "66":
                    _pdfLocation = "1STLAYER";
                    break;
                case "68":
                    _pdfLocation = "2NDLAYER";
                    break;
                case "69":
                    _pdfLocation = "CCHCUTTER";
                    break;
                case "63":
                    _pdfLocation = "CCHSLITTER";
                    break;
                case "70":
                    _pdfLocation = "2RH";
                    break;
                case "71":
                    _pdfLocation = "3PA";
                    break;
                case "74":
                    _pdfLocation = "TEXCAL";
                    break;
                case "75":
                    _pdfLocation = "SMALLCAL";
                    break;
                case "77":
                    _pdfLocation = "SMALLSLITTER";
                    break;
                case "81":
                    _pdfLocation = "BEAD";
                    break;
                case "85":
                    _pdfLocation = "BEADPRESET";
                    break;
            }
            return _pdfLocation;
        }
        private void DownloadPDF(string status)
        {
            MemoryStream ms ;
            switch (status)
            {
                case "1":
                    if (_dataCurrentSchedule.Rows.Count < 0)
                    {
                        MessageBox.Show("Vui lòng liên hệ IT - TS!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        _pdfCurrentSize = _pdfUrl + @"MC=" + _pdfLocation + "&PARTNO=" + _dataCurrentSchedule.Rows[0]["MATERIALSIZE"].ToString().Trim() + "_" + _dataCurrentSchedule.Rows[0]["REVISIONNO"].ToString().Trim();
                        using (WebClient client = new WebClient())
                        {
                            byte[] fileBytes = client.DownloadData(_pdfCurrentSize);
                            ms = new MemoryStream(fileBytes);
                            this.pdfCurrentSize.LoadDocument(ms);
                            this.xtraTabControl1.SelectedTabPage = xtraTabProcess;
                        }
                    }                    
                    break;
                case "0":
                    if (_dataNextSchedule.Rows.Count < 0)
                    {
                        MessageBox.Show("Vui lòng liên hệ IT - TS!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        _pdfNextSize = _pdfUrl + @"MC=" + _pdfLocation + "&PARTNO=" + _dataNextSchedule.Rows[0]["MATERIALSIZE"].ToString().Trim() + "_" + _dataNextSchedule.Rows[0]["REVISIONNO"].ToString().Trim();
                        using (WebClient client = new WebClient())
                        {
                            byte[] fileBytes = client.DownloadData(_pdfNextSize);
                            ms = new MemoryStream(fileBytes);
                            this.pdfOtherSizes.LoadDocument(ms);
                            this.xtraTabControl1.SelectedTabPageIndex = 1;
                        }
                    }
                    break;
                case "2":
                    if (_dataCurrentSchedule.Rows.Count < 0)
                    {
                        MessageBox.Show("Vui lòng liên hệ IT - TS!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        _pdfOthertSize = _pdfUrl + @"MC=" + GetPDFLocation(Properties.Settings.Default.MachineGroup) + @"&PARTNO=" + Properties.Settings.Default.OtherSizeName;
                            /*_pdfUrl + @"MC=" + _pdfLocation + "&PARTNO=" + _dataCurrentSchedule.Rows[0]["MATERIALSIZE"].ToString().Trim() + "_" + _dataCurrentSchedule.Rows[0]["REVISIONNO"].ToString().Trim();*/
                        using (WebClient client = new WebClient())
                        {
                            byte[] fileBytes = client.DownloadData(_pdfOthertSize);
                            ms = new MemoryStream(fileBytes);
                            this.pdfOtherSizes.LoadDocument(ms);
                            this.xtraTabControl1.SelectedTabPage = xtraTabOthersSize;
                        }
                    }
                    break;
                case "3":
                    if (_dataCurrentSchedule.Rows.Count < 0)
                    {
                        MessageBox.Show("Vui lòng liên hệ IT - TS!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        _pdfCurrentSize = _pdfUrl + @"MC=" + _pdfLocation + "&PARTNO=" + _dataCurrentSchedule.Rows[0]["MATERIALSIZE"].ToString().Trim() + "_" + _dataOldSchedule.Rows[0]["REVISIONNO"].ToString().Trim();
                        /*_pdfUrl + @"MC=" + _pdfLocation + "&PARTNO=" + _dataCurrentSchedule.Rows[0]["MATERIALSIZE"].ToString().Trim() + "_" + _dataCurrentSchedule.Rows[0]["REVISIONNO"].ToString().Trim();*/
                        using (WebClient client = new WebClient())
                        {
                            byte[] fileBytes = client.DownloadData(_pdfCurrentSize);
                            ms = new MemoryStream(fileBytes);
                            this.pdfCurrentSize.LoadDocument(ms);
                            this.xtraTabControl1.SelectedTabPage = xtraTabProcess;
                        }
                    }
                    break;
            }
        }
        private void CheckCounter()
        {

        }
        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                splitContainer3.SplitterDistance = splitContainer3.Width / 5;
                splitContainer3.FixedPanel = FixedPanel.Panel1;
                splitContainer3.IsSplitterFixed = true;
                splitContainer4.SplitterDistance = splitContainer3.Width / 7;
                splitContainer4.FixedPanel = FixedPanel.Panel1;
                splitContainer4.IsSplitterFixed = true;
                splitContainer5.SplitterDistance = splitContainer3.Width / 7;
                splitContainer5.FixedPanel = FixedPanel.Panel1;
                splitContainer5.IsSplitterFixed = true;
                splitContainer1.SplitterDistance = 80;
                splitContainer1.FixedPanel = FixedPanel.Panel1;
                splitContainer1.IsSplitterFixed = true;
               
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                splitContainer3.SplitterDistance = splitContainer3.Width / 5;
                splitContainer3.FixedPanel = FixedPanel.Panel1;
                splitContainer3.IsSplitterFixed = true;
                splitContainer4.SplitterDistance = splitContainer3.Width / 7;
                splitContainer4.FixedPanel = FixedPanel.Panel1;
                splitContainer4.IsSplitterFixed = true;
                splitContainer5.SplitterDistance = splitContainer3.Width / 7;
                splitContainer5.FixedPanel = FixedPanel.Panel1;
                splitContainer5.IsSplitterFixed = true;
                splitContainer1.SplitterDistance = 80;
                splitContainer1.FixedPanel = FixedPanel.Panel1;
                splitContainer1.IsSplitterFixed = true;
                
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ProcessData(_currentSizeStatus);
        }
        private void DisplayData(DataTable tbl)
        {
            if(tbl.Rows.Count > 0)
            {
                this.labelSizeName.Text = tbl.Rows[0]["MATERIALSIZE"].ToString();
                this.labelMaterialLot.Text = tbl.Rows[0]["MATERIALLOTNO"].ToString();
                this.labelVersion.Text = tbl.Rows[0]["REVISIONNO"].ToString();
                this.labelStatus.ForeColor = tbl.Rows[0]["STATUSFLAG"].ToString() == "0" || tbl.Rows[0]["STATUSFLAG"].ToString() == "4" ? Color.Red : Color.Black;
                this.labelStatus.Text = tbl.Rows[0]["STATUSFLAG"].ToString() == "0" || tbl.Rows[0]["STATUSFLAG"].ToString() == "4" ? "Tiếp Theo" : "Đang chạy";
            }                
        }
        private void DisplayOtherSizeData(string materialSize, string revisionNo)
        {
            this.labelSizeName.Text = materialSize;
            this.labelMaterialLot.Text = "";
            this.labelVersion.Text = revisionNo;
            this.labelStatus.ForeColor = Color.Blue;
            this.labelStatus.Text = "Không chạy";
            this.labelTime.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this._countSecond > 0)
                this._countSecond -= 1;
            else
            {
                if (this._countMinute > 0)
                {
                    this._countSecond = 59;
                    this._countMinute -= 1;
                }
                else
                {
                    ProcessData(_currentSizeStatus);
                }
            }
            this.labelTime.Text = (this._countMinute >= _maxMinute ? this._countMinute.ToString() : "0" + this._countMinute) + ":" + (this._countSecond >= _maxMinute ? this._countSecond.ToString() : ("0" + this._countSecond)) + " s";
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            XtraTabControl tabControl = (XtraTabControl)sender;
            XtraTabPage selectedPage = e.Page;
            this.splashScreenManager1.ShowWaitForm();
            if(selectedPage.Name == "xtraTabProcess")
            {
                DisplayData(_dataCurrentSchedule);
                xtraTabOthersSize.PageVisible = false;
            }
            else if(selectedPage.Name == "xtraTabOthersSize")
            {
                DisplayData(_dataNextSchedule);
                timer1.Stop();
                timer1.Start();
            }
            Thread.Sleep(3000);
            this.splashScreenManager1.CloseWaitForm();
        }

        private void btnNextSize_Click(object sender, EventArgs e)
        {
            xtraTabOthersSize.PageVisible = true;
            ProcessData(_nextSizeStatus);
        }

        private void btnOtherSizes_Click(object sender, EventArgs e)
        {
            frmPickOtherSize frm = new frmPickOtherSize();
            frm.FormClosedEvent += PickOtherSizeForm_FormClosed;
            frm.ShowDialog();
        }
        private void PickOtherSizeForm_FormClosed(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.OtherSizeName != null)
            {
                DisplayOtherProcess();
            }
        }
        public void DisplayOtherProcess()
        {
            if (!xtraTabOthersSize.PageVisible)
            {
                xtraTabOthersSize.PageVisible = true;
            }
            try
            {
                DownloadPDF(_otherSizeStatus);
                DisplayOtherSizeData(Properties.Settings.Default.OtherSizeName.Split('_')[0].ToString(), Properties.Settings.Default.RevisionNo);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }            
        }

        private void pdfCurrentSize_PopupMenuShowing(object sender, DevExpress.XtraPdfViewer.PdfPopupMenuShowingEventArgs e)
        {
            e.ItemLinks.Clear();
        }

        private void pdfOtherSizes_PopupMenuShowing(object sender, DevExpress.XtraPdfViewer.PdfPopupMenuShowingEventArgs e)
        {
            e.ItemLinks.Clear();
        }

        private void pdfCounterProcess_PopupMenuShowing(object sender, DevExpress.XtraPdfViewer.PdfPopupMenuShowingEventArgs e)
        {
            e.ItemLinks.Clear();
        }

        private void MainMonitortoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.Location = Screen.AllScreens[0].WorkingArea.Location;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.Location = Screen.AllScreens[0].WorkingArea.Location;
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void ChangeMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.Location = Screen.AllScreens[1].WorkingArea.Location;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.Location = Screen.AllScreens[1].WorkingArea.Location;
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
        }

        private void NextSizetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNextSize_Click(null, null);
        }

        private void ZoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(pdfCurrentSize.ZoomMode != DevExpress.XtraPdfViewer.PdfZoomMode.Custom)
            {
                pdfCurrentSize.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.Custom;
                pdfCurrentSize.ZoomFactor += 2.5f;
            }
            else
            {
                pdfCurrentSize.ZoomFactor += 2.5f;
            }
            
        }

        private void ZoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pdfCurrentSize.ZoomMode != DevExpress.XtraPdfViewer.PdfZoomMode.Custom)
            {
                pdfCurrentSize.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.Custom;
                pdfCurrentSize.ZoomFactor -= 2.5f;
            }
            else
            {
                pdfCurrentSize.ZoomFactor -= 2.5f;
            }            
        }

        private void ExittoolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Thông Báo", "Bạn có thực sự muốn tắt phần mềm!", MessageBoxButtons.YesNo);
            if(rs == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
