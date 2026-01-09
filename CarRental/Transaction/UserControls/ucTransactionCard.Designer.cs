namespace CarRental.Transaction.UserControls
{
    partial class ucTransactionCard
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.guna2PanelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.lblActualTotalDueAmount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotalRefundedAmount = new System.Windows.Forms.Label();
            this.lblTotalRemaining = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTransactionType = new System.Windows.Forms.Label();
            this.lblTransactionDate = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPaidInitialTotalDueAmount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPaymentDetails = new System.Windows.Forms.Label();
            this.lblReturnID = new System.Windows.Forms.Label();
            this.lblBookingID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTransactionID = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.labelHeader = new System.Windows.Forms.Label();
            this.guna2PanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2PanelMain
            // 
            this.guna2PanelMain.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.guna2PanelMain.BorderRadius = 15;
            this.guna2PanelMain.BorderThickness = 1;
            this.guna2PanelMain.Controls.Add(this.labelHeader);
            this.guna2PanelMain.Controls.Add(this.lblActualTotalDueAmount);
            this.guna2PanelMain.Controls.Add(this.label10);
            this.guna2PanelMain.Controls.Add(this.lblTotalRefundedAmount);
            this.guna2PanelMain.Controls.Add(this.lblTotalRemaining);
            this.guna2PanelMain.Controls.Add(this.label11);
            this.guna2PanelMain.Controls.Add(this.label12);
            this.guna2PanelMain.Controls.Add(this.lblTransactionType);
            this.guna2PanelMain.Controls.Add(this.lblTransactionDate);
            this.guna2PanelMain.Controls.Add(this.label8);
            this.guna2PanelMain.Controls.Add(this.label9);
            this.guna2PanelMain.Controls.Add(this.lblPaidInitialTotalDueAmount);
            this.guna2PanelMain.Controls.Add(this.label7);
            this.guna2PanelMain.Controls.Add(this.lblPaymentDetails);
            this.guna2PanelMain.Controls.Add(this.lblReturnID);
            this.guna2PanelMain.Controls.Add(this.lblBookingID);
            this.guna2PanelMain.Controls.Add(this.label6);
            this.guna2PanelMain.Controls.Add(this.label4);
            this.guna2PanelMain.Controls.Add(this.label2);
            this.guna2PanelMain.Controls.Add(this.lblTransactionID);
            this.guna2PanelMain.Controls.Add(this.label22);
            this.guna2PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2PanelMain.FillColor = System.Drawing.Color.White;
            this.guna2PanelMain.Location = new System.Drawing.Point(0, 0);
            this.guna2PanelMain.Name = "guna2PanelMain";
            this.guna2PanelMain.Size = new System.Drawing.Size(785, 370);
            this.guna2PanelMain.TabIndex = 0;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.BackColor = System.Drawing.Color.Transparent;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelHeader.Location = new System.Drawing.Point(15, 12);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(155, 21);
            this.labelHeader.Text = "Thông tin giao dịch";
            // 
            // label22 (Mã GD)
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.Color.Gray;
            this.label22.Location = new System.Drawing.Point(25, 55);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(94, 19);
            this.label22.Text = "Mã giao dịch:";
            // 
            // lblTransactionID
            // 
            this.lblTransactionID.AutoSize = true;
            this.lblTransactionID.BackColor = System.Drawing.Color.Transparent;
            this.lblTransactionID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTransactionID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.lblTransactionID.Location = new System.Drawing.Point(160, 55);
            this.lblTransactionID.Name = "lblTransactionID";
            this.lblTransactionID.Size = new System.Drawing.Size(43, 19);
            this.lblTransactionID.Text = "[????]";
            // 
            // label2 (Mã đặt)
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(25, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 19);
            this.label2.Text = "Mã đặt xe:";
            // 
            // lblBookingID
            // 
            this.lblBookingID.AutoSize = true;
            this.lblBookingID.BackColor = System.Drawing.Color.Transparent;
            this.lblBookingID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBookingID.Location = new System.Drawing.Point(160, 95);
            this.lblBookingID.Name = "lblBookingID";
            this.lblBookingID.Size = new System.Drawing.Size(43, 19);
            this.lblBookingID.Text = "[????]";
            // 
            // label4 (Mã trả)
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(25, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 19);
            this.label4.Text = "Mã trả xe:";
            // 
            // lblReturnID
            // 
            this.lblReturnID.AutoSize = true;
            this.lblReturnID.BackColor = System.Drawing.Color.Transparent;
            this.lblReturnID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblReturnID.Location = new System.Drawing.Point(160, 135);
            this.lblReturnID.Name = "lblReturnID";
            this.lblReturnID.Size = new System.Drawing.Size(43, 19);
            this.lblReturnID.Text = "[????]";
            // 
            // label9 (Ngày GD)
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(25, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 19);
            this.label9.Text = "Ngày giao dịch:";
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.BackColor = System.Drawing.Color.Transparent;
            this.lblTransactionDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTransactionDate.Location = new System.Drawing.Point(160, 175);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(41, 19);
            this.lblTransactionDate.Text = "[????]";
            // 
            // label8 (Loại GD)
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(25, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 19);
            this.label8.Text = "Loại giao dịch:";
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.AutoSize = true;
            this.lblTransactionType.BackColor = System.Drawing.Color.Transparent;
            this.lblTransactionType.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTransactionType.Location = new System.Drawing.Point(160, 215);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(43, 19);
            this.lblTransactionType.Text = "[????]";
            // 
            // label12 (Tiền cọc)
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.Gray;
            this.label12.Location = new System.Drawing.Point(380, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 19);
            this.label12.Text = "Số tiền thanh toán:";
            // 
            // lblPaidInitialTotalDueAmount
            // 
            this.lblPaidInitialTotalDueAmount.AutoSize = true;
            this.lblPaidInitialTotalDueAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblPaidInitialTotalDueAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPaidInitialTotalDueAmount.ForeColor = System.Drawing.Color.Black;
            this.lblPaidInitialTotalDueAmount.Location = new System.Drawing.Point(530, 55);
            this.lblPaidInitialTotalDueAmount.Name = "lblPaidInitialTotalDueAmount";
            this.lblPaidInitialTotalDueAmount.Size = new System.Drawing.Size(43, 19);
            this.lblPaidInitialTotalDueAmount.Text = "[????]";
            // 
            // label10 (Tổng tiền)
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(380, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 19);
            this.label10.Text = "Tổng tiền thực tế:";
            // 
            // lblActualTotalDueAmount
            // 
            this.lblActualTotalDueAmount.AutoSize = true;
            this.lblActualTotalDueAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblActualTotalDueAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblActualTotalDueAmount.ForeColor = System.Drawing.Color.Green;
            this.lblActualTotalDueAmount.Location = new System.Drawing.Point(530, 95);
            this.lblActualTotalDueAmount.Name = "lblActualTotalDueAmount";
            this.lblActualTotalDueAmount.Size = new System.Drawing.Size(43, 19);
            this.lblActualTotalDueAmount.Text = "[????]";
            // 
            // label11 (Còn lại)
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Gray;
            this.label11.Location = new System.Drawing.Point(380, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 19);
            this.label11.Text = "Số tiền còn lại:";
            // 
            // lblTotalRemaining
            // 
            this.lblTotalRemaining.AutoSize = true;
            this.lblTotalRemaining.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRemaining.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalRemaining.ForeColor = System.Drawing.Color.Red;
            this.lblTotalRemaining.Location = new System.Drawing.Point(530, 135);
            this.lblTotalRemaining.Name = "lblTotalRemaining";
            this.lblTotalRemaining.Size = new System.Drawing.Size(43, 19);
            this.lblTotalRemaining.Text = "[????]";
            // 
            // label12 (Hoàn trả)
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.Gray;
            this.label12.Location = new System.Drawing.Point(380, 175);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 19);
            this.label12.Text = "Số tiền hoàn trả:";
            // 
            // lblTotalRefundedAmount
            // 
            this.lblTotalRefundedAmount.AutoSize = true;
            this.lblTotalRefundedAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRefundedAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalRefundedAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalRefundedAmount.Location = new System.Drawing.Point(530, 175);
            this.lblTotalRefundedAmount.Name = "lblTotalRefundedAmount";
            this.lblTotalRefundedAmount.Size = new System.Drawing.Size(43, 19);
            this.lblTotalRefundedAmount.Text = "[????]";
            // 
            // label6 (Ghi chú/PTTT)
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(25, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 19);
            this.label6.Text = "Chi tiết thanh toán:";
            // 
            // lblPaymentDetails
            // 
            this.lblPaymentDetails.AutoSize = false;
            this.lblPaymentDetails.BackColor = System.Drawing.Color.Transparent;
            this.lblPaymentDetails.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPaymentDetails.Location = new System.Drawing.Point(210, 240);
            this.lblPaymentDetails.Name = "lblPaymentDetails";
            this.lblPaymentDetails.Size = new System.Drawing.Size(500, 110);
            this.lblPaymentDetails.Text = "Không có dữ liệu";
            this.lblPaymentDetails.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // ucTransactionCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2PanelMain);
            this.Name = "ucTransactionCard";
            this.Size = new System.Drawing.Size(785, 370);
            this.guna2PanelMain.ResumeLayout(false);
            this.guna2PanelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2PanelMain;
        private System.Windows.Forms.Label lblTransactionID;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblPaymentDetails;
        private System.Windows.Forms.Label lblReturnID;
        private System.Windows.Forms.Label lblBookingID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Label lblActualTotalDueAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTotalRefundedAmount;
        private System.Windows.Forms.Label lblTotalRemaining;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTransactionType;
        private System.Windows.Forms.Label lblTransactionDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblPaidInitialTotalDueAmount;
        private System.Windows.Forms.Label label7;
    }
}