namespace CarRental.Return
{
    partial class frmShowReturnDetailsWithCustomerAndVehicle
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
            this.ucReturnCardWithCustomerAndVehicle1 = new CarRental.Return.UserControls.ucReturnCardWithCustomerAndVehicle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.guna2PanelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(820, 55);
            this.lblTitle.TabIndex = 176;
            this.lblTitle.Text = "CHI TIẾT TRẢ XE";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2PanelMain
            // 
            this.guna2PanelMain.BorderRadius = 16;
            this.guna2PanelMain.FillColor = System.Drawing.Color.White;
            this.guna2PanelMain.Location = new System.Drawing.Point(12, 60);
            this.guna2PanelMain.Name = "guna2PanelMain";
            this.guna2PanelMain.Size = new System.Drawing.Size(800, 985);
            this.guna2PanelMain.TabIndex = 201;
            this.guna2PanelMain.Controls.Add(this.ucReturnCardWithCustomerAndVehicle1);
            this.guna2PanelMain.Controls.Add(this.btnClose);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderRadius = 8;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.btnClose.Location = new System.Drawing.Point(633, 935);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(155, 40);
            this.btnClose.TabIndex = 198;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // 
            // ucReturnCardWithCustomerAndVehicle1
            // 
            this.ucReturnCardWithCustomerAndVehicle1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucReturnCardWithCustomerAndVehicle1.BackColor = System.Drawing.Color.Transparent;
            this.ucReturnCardWithCustomerAndVehicle1.Location = new System.Drawing.Point(10, 10);
            this.ucReturnCardWithCustomerAndVehicle1.Name = "ucReturnCardWithCustomerAndVehicle1";
            this.ucReturnCardWithCustomerAndVehicle1.Size = new System.Drawing.Size(780, 915);
            this.ucReturnCardWithCustomerAndVehicle1.TabIndex = 0;
            // 
            // frmShowReturnDetailsWithCustomerAndVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(824, 1060);
            this.Controls.Add(this.guna2PanelMain);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmShowReturnDetailsWithCustomerAndVehicle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết trả xe";
            this.guna2PanelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucReturnCardWithCustomerAndVehicle ucReturnCardWithCustomerAndVehicle1;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel guna2PanelMain;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}