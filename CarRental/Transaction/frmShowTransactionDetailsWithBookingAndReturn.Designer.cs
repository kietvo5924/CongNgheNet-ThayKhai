namespace CarRental.Transaction
{
    partial class frmShowTransactionDetailsWithBookingAndReturn
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.ucTransactionCardWithBookingAndReturn1 = new CarRental.Transaction.UserControls.ucTransactionCardWithBookingAndReturn();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(815, 50);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "CHI TIẾT GIAO DỊCH";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderRadius = 8;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.btnClose.Location = new System.Drawing.Point(650, 810);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(145, 42);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ucTransactionCardWithBookingAndReturn1
            // 
            this.ucTransactionCardWithBookingAndReturn1.BackColor = System.Drawing.Color.Transparent;
            this.ucTransactionCardWithBookingAndReturn1.Location = new System.Drawing.Point(12, 70);
            this.ucTransactionCardWithBookingAndReturn1.Name = "ucTransactionCardWithBookingAndReturn1";
            this.ucTransactionCardWithBookingAndReturn1.Size = new System.Drawing.Size(790, 730);
            this.ucTransactionCardWithBookingAndReturn1.TabIndex = 0;
            // 
            // frmShowTransactionDetailsWithBookingAndReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(815, 870);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ucTransactionCardWithBookingAndReturn1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmShowTransactionDetailsWithBookingAndReturn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin chi tiết giao dịch";
            this.Load += new System.EventHandler(this.frmShowTransactionDetailsWithBookingAndReturn_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucTransactionCardWithBookingAndReturn ucTransactionCardWithBookingAndReturn1;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}