namespace CarRental.Return.UserControls
{
    partial class ucReturnCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2PanelCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblReturnID = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblActualReturnDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblActualRentalDays = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMileage = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblConsumedMileage = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblAdditionalCharges = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblActualTotalDueAmount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblFinalCheckNotes = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.btnShowTransactionInfo = new Guna.UI2.WinForms.Guna2Button();
            this.btnShowBookingInfo = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PanelCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2PanelCard
            // 
            this.guna2PanelCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.guna2PanelCard.BorderRadius = 14;
            this.guna2PanelCard.BorderThickness = 1;
            this.guna2PanelCard.FillColor = System.Drawing.Color.White;
            this.guna2PanelCard.Location = new System.Drawing.Point(0, 0);
            this.guna2PanelCard.Name = "guna2PanelCard";
            this.guna2PanelCard.Size = new System.Drawing.Size(784, 330);
            this.guna2PanelCard.TabIndex = 0;
            this.guna2PanelCard.Controls.Add(this.btnShowBookingInfo);
            this.guna2PanelCard.Controls.Add(this.btnShowTransactionInfo);
            this.guna2PanelCard.Controls.Add(this.lblFinalCheckNotes);
            this.guna2PanelCard.Controls.Add(this.label26);
            this.guna2PanelCard.Controls.Add(this.lblActualTotalDueAmount);
            this.guna2PanelCard.Controls.Add(this.label9);
            this.guna2PanelCard.Controls.Add(this.lblAdditionalCharges);
            this.guna2PanelCard.Controls.Add(this.label10);
            this.guna2PanelCard.Controls.Add(this.lblConsumedMileage);
            this.guna2PanelCard.Controls.Add(this.label25);
            this.guna2PanelCard.Controls.Add(this.lblMileage);
            this.guna2PanelCard.Controls.Add(this.label6);
            this.guna2PanelCard.Controls.Add(this.lblActualRentalDays);
            this.guna2PanelCard.Controls.Add(this.label5);
            this.guna2PanelCard.Controls.Add(this.lblActualReturnDate);
            this.guna2PanelCard.Controls.Add(this.label3);
            this.guna2PanelCard.Controls.Add(this.lblReturnID);
            this.guna2PanelCard.Controls.Add(this.label22);
            this.guna2PanelCard.Controls.Add(this.lblHeader);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblHeader.Location = new System.Drawing.Point(15, 12);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(154, 21);
            this.lblHeader.TabIndex = 300;
            this.lblHeader.Text = "Thông tin hoàn trả";
            // 
            // btnShowBookingInfo
            // 
            this.btnShowBookingInfo.BorderRadius = 8;
            this.btnShowBookingInfo.Enabled = false;
            this.btnShowBookingInfo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnShowBookingInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnShowBookingInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnShowBookingInfo.Location = new System.Drawing.Point(580, 255);
            this.btnShowBookingInfo.Name = "btnShowBookingInfo";
            this.btnShowBookingInfo.Size = new System.Drawing.Size(180, 35);
            this.btnShowBookingInfo.TabIndex = 215;
            this.btnShowBookingInfo.Text = "Xem lịch đặt";
            this.btnShowBookingInfo.Click += new System.EventHandler(this.btnShowBookingInfo_Click);
            // 
            // btnShowTransactionInfo
            // 
            this.btnShowTransactionInfo.BorderRadius = 8;
            this.btnShowTransactionInfo.Enabled = false;
            this.btnShowTransactionInfo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnShowTransactionInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnShowTransactionInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnShowTransactionInfo.Location = new System.Drawing.Point(400, 255);
            this.btnShowTransactionInfo.Name = "btnShowTransactionInfo";
            this.btnShowTransactionInfo.Size = new System.Drawing.Size(170, 35);
            this.btnShowTransactionInfo.TabIndex = 214;
            this.btnShowTransactionInfo.Text = "Xem giao dịch";
            this.btnShowTransactionInfo.Click += new System.EventHandler(this.btnShowTransactionInfo_Click);
            // 
            // lblActualRentalDays
            // 
            this.lblActualRentalDays.AutoSize = true;
            this.lblActualRentalDays.BackColor = System.Drawing.Color.Transparent;
            this.lblActualRentalDays.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblActualRentalDays.Location = new System.Drawing.Point(140, 125);
            this.lblActualRentalDays.Name = "lblActualRentalDays";
            this.lblActualRentalDays.Size = new System.Drawing.Size(43, 19);
            this.lblActualRentalDays.TabIndex = 206;
            this.lblActualRentalDays.Text = "[????]";
            // 
            // lblActualReturnDate
            // 
            this.lblActualReturnDate.AutoSize = true;
            this.lblActualReturnDate.BackColor = System.Drawing.Color.Transparent;
            this.lblActualReturnDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblActualReturnDate.Location = new System.Drawing.Point(140, 90);
            this.lblActualReturnDate.Name = "lblActualReturnDate";
            this.lblActualReturnDate.Size = new System.Drawing.Size(43, 19);
            this.lblActualReturnDate.TabIndex = 205;
            this.lblActualReturnDate.Text = "[????]";
            // 
            // lblActualTotalDueAmount
            // 
            this.lblActualTotalDueAmount.AutoSize = true;
            this.lblActualTotalDueAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblActualTotalDueAmount.ForeColor = System.Drawing.Color.Green;
            this.lblActualTotalDueAmount.Location = new System.Drawing.Point(540, 195);
            this.lblActualTotalDueAmount.Name = "lblActualTotalDueAmount";
            this.lblActualTotalDueAmount.Size = new System.Drawing.Size(55, 21);
            this.lblActualTotalDueAmount.TabIndex = 204;
            this.lblActualTotalDueAmount.Text = "[????]";
            // 
            // lblAdditionalCharges
            // 
            this.lblAdditionalCharges.AutoSize = true;
            this.lblAdditionalCharges.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAdditionalCharges.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblAdditionalCharges.Location = new System.Drawing.Point(580, 105);
            this.lblAdditionalCharges.Name = "lblAdditionalCharges";
            this.lblAdditionalCharges.Size = new System.Drawing.Size(46, 19);
            this.lblAdditionalCharges.TabIndex = 203;
            this.lblAdditionalCharges.Text = "[????]";
            // 
            // lblFinalCheckNotes
            // 
            this.lblFinalCheckNotes.AutoSize = true;
            this.lblFinalCheckNotes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFinalCheckNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblFinalCheckNotes.Location = new System.Drawing.Point(580, 165);
            this.lblFinalCheckNotes.Name = "lblFinalCheckNotes";
            this.lblFinalCheckNotes.Size = new System.Drawing.Size(46, 19);
            this.lblFinalCheckNotes.TabIndex = 202;
            this.lblFinalCheckNotes.Text = "[????]";
            // 
            // lblConsumedMileage
            // 
            this.lblConsumedMileage.AutoSize = true;
            this.lblConsumedMileage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblConsumedMileage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblConsumedMileage.Location = new System.Drawing.Point(580, 45);
            this.lblConsumedMileage.Name = "lblConsumedMileage";
            this.lblConsumedMileage.Size = new System.Drawing.Size(46, 19);
            this.lblConsumedMileage.TabIndex = 201;
            this.lblConsumedMileage.Text = "[????]";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label25.ForeColor = System.Drawing.Color.Gray;
            this.label25.Location = new System.Drawing.Point(400, 55);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(107, 19);
            this.label25.TabIndex = 198;
            this.label25.Text = "Số Km đã chạy:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(400, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 19);
            this.label10.TabIndex = 182;
            this.label10.Text = "Phí phát sinh:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(400, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 19);
            this.label9.TabIndex = 191;
            this.label9.Text = "Tổng thanh toán:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.Color.Gray;
            this.label22.Location = new System.Drawing.Point(25, 55);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(103, 20);
            this.label22.TabIndex = 147;
            this.label22.Text = "Mã hoàn trả:";
            // 
            // lblReturnID
            // 
            this.lblReturnID.AutoSize = true;
            this.lblReturnID.BackColor = System.Drawing.Color.Transparent;
            this.lblReturnID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblReturnID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.lblReturnID.Location = new System.Drawing.Point(140, 55);
            this.lblReturnID.Name = "lblReturnID";
            this.lblReturnID.Size = new System.Drawing.Size(43, 19);
            this.lblReturnID.TabIndex = 148;
            this.lblReturnID.Text = "[????]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(25, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 153;
            this.label3.Text = "Ngày hoàn trả:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(25, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 20);
            this.label5.TabIndex = 156;
            this.label5.Text = "Số ngày thực:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(25, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 19);
            this.label6.TabIndex = 179;
            this.label6.Text = "Số Km:";
            // 
            // lblMileage
            // 
            this.lblMileage.AutoSize = true;
            this.lblMileage.BackColor = System.Drawing.Color.Transparent;
            this.lblMileage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMileage.Location = new System.Drawing.Point(140, 160);
            this.lblMileage.Name = "lblMileage";
            this.lblMileage.Size = new System.Drawing.Size(43, 19);
            this.lblMileage.TabIndex = 180;
            this.lblMileage.Text = "[????]";
            // 
            // ucReturnCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.guna2PanelCard);
            this.Name = "ucReturnCard";
            this.Size = new System.Drawing.Size(784, 330);
            this.guna2PanelCard.ResumeLayout(false);
            this.guna2PanelCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2PanelCard;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblActualRentalDays;
        private System.Windows.Forms.Label lblActualReturnDate;
        private System.Windows.Forms.Label lblActualTotalDueAmount;
        private System.Windows.Forms.Label lblAdditionalCharges;
        private System.Windows.Forms.Label lblFinalCheckNotes;
        private System.Windows.Forms.Label lblConsumedMileage;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMileage;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblReturnID;
        private Guna.UI2.WinForms.Guna2Button btnShowBookingInfo;
        private Guna.UI2.WinForms.Guna2Button btnShowTransactionInfo;
    }
}
