
namespace ProcessOnlinePro1Client
{
    partial class frmPickOtherSize
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
            this.btnDisplay = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cBSizeName = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cBMachineName = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(404, 42);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(122, 34);
            this.btnDisplay.TabIndex = 2;
            this.btnDisplay.Text = "Hiển Thị";
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(404, 148);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 34);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBSizeName);
            this.groupBox1.Location = new System.Drawing.Point(25, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 88);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tên Size";
            // 
            // cBSizeName
            // 
            this.cBSizeName.FormattingEnabled = true;
            this.cBSizeName.Location = new System.Drawing.Point(6, 35);
            this.cBSizeName.Name = "cBSizeName";
            this.cBSizeName.Size = new System.Drawing.Size(312, 28);
            this.cBSizeName.TabIndex = 1;
            this.cBSizeName.SelectedIndexChanged += new System.EventHandler(this.cBSizeName_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cBMachineName);
            this.groupBox2.Location = new System.Drawing.Point(25, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 80);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tên Máy";
            // 
            // cBMachineName
            // 
            this.cBMachineName.FormattingEnabled = true;
            this.cBMachineName.Location = new System.Drawing.Point(6, 30);
            this.cBMachineName.Name = "cBMachineName";
            this.cBMachineName.Size = new System.Drawing.Size(312, 28);
            this.cBMachineName.TabIndex = 1;
            this.cBMachineName.SelectedIndexChanged += new System.EventHandler(this.cBMachineName_SelectedIndexChanged);
            // 
            // frmPickOtherSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 218);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDisplay);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPickOtherSize";
            this.Text = "Chọn Size Khác";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPickOtherSize_FormClosed);
            this.Load += new System.EventHandler(this.frmPickOtherSize_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnDisplay;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cBSizeName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cBMachineName;
    }
}