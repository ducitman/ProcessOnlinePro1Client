using ProcessOnlinePro1Client.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessOnlinePro1Client
{
    public partial class frmPickOtherSize : Form
    {
        public event EventHandler FormClosedEvent;
        DbBusiness _dbBusiness = new DbBusiness();
        DataTable _dataOtherSize = new DataTable();
        int _selectedIndex = 0;
        public frmPickOtherSize()
        {
            InitializeComponent();
        }

        private void frmPickOtherSize_Load(object sender, EventArgs e)
        {
            GetMachineData();

        }
        private void GetMachineData()
        {
            _dataOtherSize = _dbBusiness.GetMachineData();
            cBMachineName.DisplayMember = "MACHINENAMESHORT";
            cBMachineName.ValueMember = "MACHINEGROUP";
            cBMachineName.DataSource = _dataOtherSize;
        }
        
        private void cBMachineName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBSizeName.DisplayMember = "PARTNUMBER";
            cBSizeName.ValueMember = "REVISIONNO";
            _selectedIndex = cBMachineName.SelectedIndex;
            cBSizeName.DataSource = _dbBusiness.GetLastestProcessVersion(cBMachineName.SelectedValue.ToString());
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmPickOtherSize_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormClosedEvent?.Invoke(this, EventArgs.Empty);
        }

        private void cBSizeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string processInfor = cBSizeName.Text.ToString().Trim() + "_" + cBSizeName.SelectedValue.ToString().Trim();
            string machineGroup = cBMachineName.SelectedValue.ToString().Trim();
            Properties.Settings.Default.MachineGroup = machineGroup;
            Properties.Settings.Default.RevisionNo = cBSizeName.SelectedValue.ToString().Trim();
            Properties.Settings.Default.OtherSizeName = processInfor;
            Properties.Settings.Default.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
