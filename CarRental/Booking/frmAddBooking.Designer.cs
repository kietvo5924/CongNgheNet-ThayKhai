namespace CarRental.Booking
{
    partial class frmAddBooking
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
            this.components = new System.ComponentModel.Container();
            this.guna2PanelBookingInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.txtPaymentDetails = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInitialTotalDueAmount = new System.Windows.Forms.Label();
            this.lblRentalPricePerDay = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtInitailCheckNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDropOffLocation = new Guna.UI2.WinForms.Guna2TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblInitialRentalDays = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblVehicleID = new System.Windows.Forms.Label();
            this.txtPickUpLocation = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblBookingID = new System.Windows.Forms.Label();
            this.labelHeaderGroup = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnBook = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.llTransactionInfo = new System.Windows.Forms.LinkLabel();
            this.ucSelectedCustomerAndVehicleWithFilter1 = new CarRental.Booking.UserControls.ucSelectedCustomerAndVehicleWithFilter();
            this.guna2PanelBookingInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2PanelBookingInfo (THẺ CHI TIẾT TRẮNG)
            // 
            this.guna2PanelBookingInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.guna2PanelBookingInfo.BorderRadius = 15;
            this.guna2PanelBookingInfo.BorderThickness = 1;
            this.guna2PanelBookingInfo.Controls.Add(this.labelHeaderGroup);
            this.guna2PanelBookingInfo.Controls.Add(this.txtPaymentDetails);
            this.guna2PanelBookingInfo.Controls.Add(this.label4);
            this.guna2PanelBookingInfo.Controls.Add(this.lblInitialTotalDueAmount);
            this.guna2PanelBookingInfo.Controls.Add(this.lblRentalPricePerDay);
            this.guna2PanelBookingInfo.Controls.Add(this.label7);
            this.guna2PanelBookingInfo.Controls.Add(this.label12);
            this.guna2PanelBookingInfo.Controls.Add(this.txtInitailCheckNotes);
            this.guna2PanelBookingInfo.Controls.Add(this.label9);
            this.guna2PanelBookingInfo.Controls.Add(this.txtDropOffLocation);
            this.guna2PanelBookingInfo.Controls.Add(this.label10);
            this.guna2PanelBookingInfo.Controls.Add(this.label6);
            this.guna2PanelBookingInfo.Controls.Add(this.lblInitialRentalDays);
            this.guna2PanelBookingInfo.Controls.Add(this.label2);
            this.guna2PanelBookingInfo.Controls.Add(this.lblVehicleID);
            this.guna2PanelBookingInfo.Controls.Add(this.txtPickUpLocation);
            this.guna2PanelBookingInfo.Controls.Add(this.dtpEndDate);
            this.guna2PanelBookingInfo.Controls.Add(this.dtpStartDate);
            this.guna2PanelBookingInfo.Controls.Add(this.label11);
            this.guna2PanelBookingInfo.Controls.Add(this.label5);
            this.guna2PanelBookingInfo.Controls.Add(this.label3);
            this.guna2PanelBookingInfo.Controls.Add(this.label1);
            this.guna2PanelBookingInfo.Controls.Add(this.lblCustomerID);
            this.guna2PanelBookingInfo.Controls.Add(this.label22);
            this.guna2PanelBookingInfo.Controls.Add(this.lblBookingID);
            this.guna2PanelBookingInfo.FillColor = System.Drawing.Color.White;
            this.guna2PanelBookingInfo.Location = new System.Drawing.Point(12, 655);
            this.guna2PanelBookingInfo.Name = "guna2PanelBookingInfo";
            this.guna2PanelBookingInfo.Size = new System.Drawing.Size(775, 270);
            this.guna2PanelBookingInfo.TabIndex = 177;
            // 
            // labelHeaderGroup
            // 
            this.labelHeaderGroup.AutoSize = true;
            this.labelHeaderGroup.BackColor = System.Drawing.Color.Transparent;
            this.labelHeaderGroup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelHeaderGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelHeaderGroup.Location = new System.Drawing.Point(15, 10);
            this.labelHeaderGroup.Name = "labelHeaderGroup";
            this.labelHeaderGroup.Size = new System.Drawing.Size(140, 21);
            this.labelHeaderGroup.Text = "Chi tiết đặt xe";
            // 
            // label22 (Mã lịch đặt)
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.Color.Gray;
            this.label22.Location = new System.Drawing.Point(25, 45);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 19);
            this.label22.Text = "Mã lịch đặt:";
            // 
            // lblBookingID
            // 
            this.lblBookingID.AutoSize = true;
            this.lblBookingID.BackColor = System.Drawing.Color.Transparent;
            this.lblBookingID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBookingID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.lblBookingID.Location = new System.Drawing.Point(150, 45);
            this.lblBookingID.Name = "lblBookingID";
            this.lblBookingID.Size = new System.Drawing.Size(43, 19);
            this.lblBookingID.Text = "[????]";
            // 
            // label1 (Mã KH)
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(25, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 19);
            this.label1.Text = "Mã khách hàng:";
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomerID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCustomerID.Location = new System.Drawing.Point(150, 80);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(43, 19);
            this.lblCustomerID.Text = "[????]";
            // 
            // label2 (Mã xe)
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(25, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.Text = "Mã xe:";
            // 
            // lblVehicleID
            // 
            this.lblVehicleID.AutoSize = true;
            this.lblVehicleID.BackColor = System.Drawing.Color.Transparent;
            this.lblVehicleID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVehicleID.Location = new System.Drawing.Point(150, 115);
            this.lblVehicleID.Name = "lblVehicleID";
            this.lblVehicleID.Size = new System.Drawing.Size(43, 19);
            this.lblVehicleID.Text = "[????]";
            // 
            // label3 (Ngày nhận)
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(25, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 19);
            this.label3.Text = "Ngày nhận:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.BorderRadius = 8;
            this.dtpStartDate.Checked = true;
            this.dtpStartDate.FillColor = System.Drawing.Color.White;
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(150, 145);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(180, 36);
            this.dtpStartDate.TabIndex = 171;
            // 
            // label5 (Ngày trả)
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(25, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 19);
            this.label5.Text = "Ngày trả:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.BorderRadius = 8;
            this.dtpEndDate.Checked = true;
            this.dtpEndDate.FillColor = System.Drawing.Color.White;
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(150, 185);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(180, 36);
            this.dtpEndDate.TabIndex = 172;
            // 
            // label6 (Số ngày)
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(25, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 19);
            this.label6.Text = "Số ngày thuê:";
            // 
            // lblInitialRentalDays
            // 
            this.lblInitialRentalDays.AutoSize = true;
            this.lblInitialRentalDays.BackColor = System.Drawing.Color.Transparent;
            this.lblInitialRentalDays.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblInitialRentalDays.Location = new System.Drawing.Point(150, 233);
            this.lblInitialRentalDays.Name = "lblInitialRentalDays";
            this.lblInitialRentalDays.Size = new System.Drawing.Size(43, 19);
            this.lblInitialRentalDays.Text = "[????]";
            // 
            // label12 (Giá thuê/ngày)
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.Gray;
            this.label12.Location = new System.Drawing.Point(400, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 19);
            this.label12.Text = "Giá thuê/ngày:";
            // 
            // lblRentalPricePerDay
            // 
            this.lblRentalPricePerDay.AutoSize = true;
            this.lblRentalPricePerDay.BackColor = System.Drawing.Color.Transparent;
            this.lblRentalPricePerDay.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblRentalPricePerDay.Location = new System.Drawing.Point(580, 45);
            this.lblRentalPricePerDay.Name = "lblRentalPricePerDay";
            this.lblRentalPricePerDay.Size = new System.Drawing.Size(51, 20);
            this.lblRentalPricePerDay.Text = "[????]";
            // 
            // label7 (Tổng tiền)
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(400, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 19);
            this.label7.Text = "Tổng tiền dự kiến:";
            // 
            // lblInitialTotalDueAmount
            // 
            this.lblInitialTotalDueAmount.AutoSize = true;
            this.lblInitialTotalDueAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblInitialTotalDueAmount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblInitialTotalDueAmount.ForeColor = System.Drawing.Color.Green;
            this.lblInitialTotalDueAmount.Location = new System.Drawing.Point(580, 80);
            this.lblInitialTotalDueAmount.Name = "lblInitialTotalDueAmount";
            this.lblInitialTotalDueAmount.Size = new System.Drawing.Size(51, 20);
            this.lblInitialTotalDueAmount.Text = "[????]";
            // 
            // label11 (Điểm nhận)
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Gray;
            this.label11.Location = new System.Drawing.Point(400, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 19);
            this.label11.Text = "Điểm nhận xe:";
            // 
            // txtPickUpLocation
            // 
            this.txtPickUpLocation.BorderRadius = 8;
            this.txtPickUpLocation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPickUpLocation.DefaultText = "";
            this.txtPickUpLocation.Location = new System.Drawing.Point(580, 110);
            this.txtPickUpLocation.Name = "txtPickUpLocation";
            this.txtPickUpLocation.Size = new System.Drawing.Size(180, 32);
            this.txtPickUpLocation.TabIndex = 173;
            this.txtPickUpLocation.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // label10 (Điểm trả)
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(400, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 19);
            this.label10.Text = "Điểm trả xe:";
            // 
            // txtDropOffLocation
            // 
            this.txtDropOffLocation.BorderRadius = 8;
            this.txtDropOffLocation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDropOffLocation.DefaultText = "";
            this.txtDropOffLocation.Location = new System.Drawing.Point(580, 145);
            this.txtDropOffLocation.Name = "txtDropOffLocation";
            this.txtDropOffLocation.Size = new System.Drawing.Size(180, 32);
            this.txtDropOffLocation.TabIndex = 184;
            this.txtDropOffLocation.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // label9 (Ghi chú)
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(400, 188);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 19);
            this.label9.Text = "Ghi chú:";
            // 
            // txtInitailCheckNotes
            // 
            this.txtInitailCheckNotes.BorderRadius = 8;
            this.txtInitailCheckNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInitailCheckNotes.DefaultText = "";
            this.txtInitailCheckNotes.Location = new System.Drawing.Point(580, 180);
            this.txtInitailCheckNotes.Name = "txtInitailCheckNotes";
            this.txtInitailCheckNotes.Size = new System.Drawing.Size(180, 32);
            this.txtInitailCheckNotes.TabIndex = 193;
            // 
            // label4 (Thanh toán)
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(400, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 19);
            this.label4.Text = "Thanh toán:";
            // 
            // txtPaymentDetails
            // 
            this.txtPaymentDetails.BorderRadius = 8;
            this.txtPaymentDetails.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPaymentDetails.DefaultText = "";
            this.txtPaymentDetails.Location = new System.Drawing.Point(580, 215);
            this.txtPaymentDetails.Name = "txtPaymentDetails";
            this.txtPaymentDetails.Size = new System.Drawing.Size(180, 32);
            this.txtPaymentDetails.TabIndex = 204;
            this.txtPaymentDetails.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // btnBook
            // 
            this.btnBook.BorderRadius = 8;
            this.btnBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBook.Enabled = false;
            this.btnBook.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnBook.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnBook.ForeColor = System.Drawing.Color.White;
            this.btnBook.Location = new System.Drawing.Point(625, 940);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(160, 45);
            this.btnBook.TabIndex = 198;
            this.btnBook.Text = "Đặt xe";
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 8;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.btnClose.Location = new System.Drawing.Point(450, 940);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(160, 45);
            this.btnClose.TabIndex = 197;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(795, 55);
            this.lblTitle.TabIndex = 175;
            this.lblTitle.Text = "ĐẶT XE MỚI";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // llTransactionInfo
            // 
            this.llTransactionInfo.AutoSize = true;
            this.llTransactionInfo.Enabled = false;
            this.llTransactionInfo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.llTransactionInfo.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.llTransactionInfo.Location = new System.Drawing.Point(20, 950);
            this.llTransactionInfo.Name = "llTransactionInfo";
            this.llTransactionInfo.Size = new System.Drawing.Size(164, 20);
            this.llTransactionInfo.TabIndex = 214;
            this.llTransactionInfo.TabStop = true;
            this.llTransactionInfo.Text = "Xem thông tin giao dịch";
            this.llTransactionInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llTransactionInfo_LinkClicked);
            // 
            // ucSelectedCustomerAndVehicleWithFilter1
            // 
            this.ucSelectedCustomerAndVehicleWithFilter1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucSelectedCustomerAndVehicleWithFilter1.BackColor = System.Drawing.Color.Transparent;
            this.ucSelectedCustomerAndVehicleWithFilter1.FilterEnable = true;
            this.ucSelectedCustomerAndVehicleWithFilter1.Location = new System.Drawing.Point(2, 65);
            this.ucSelectedCustomerAndVehicleWithFilter1.Name = "ucSelectedCustomerAndVehicleWithFilter1";
            this.ucSelectedCustomerAndVehicleWithFilter1.Size = new System.Drawing.Size(795, 585);
            this.ucSelectedCustomerAndVehicleWithFilter1.TabIndex = 176;
            // 
            // frmAddBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(799, 1000);
            this.Controls.Add(this.llTransactionInfo);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.guna2PanelBookingInfo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ucSelectedCustomerAndVehicleWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmAddBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm lịch đặt";
            this.Activated += new System.EventHandler(this.frmAddBooking_Activated);
            this.Load += new System.EventHandler(this.frmAddBooking_Load);
            this.guna2PanelBookingInfo.ResumeLayout(false);
            this.guna2PanelBookingInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private UserControls.ucSelectedCustomerAndVehicleWithFilter ucSelectedCustomerAndVehicleWithFilter1;
        private Guna.UI2.WinForms.Guna2Panel guna2PanelBookingInfo;
        private Guna.UI2.WinForms.Guna2TextBox txtPickUpLocation;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEndDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblBookingID;
        private Guna.UI2.WinForms.Guna2TextBox txtDropOffLocation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblInitialRentalDays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblVehicleID;
        private Guna.UI2.WinForms.Guna2TextBox txtInitailCheckNotes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblInitialTotalDueAmount;
        private System.Windows.Forms.Label lblRentalPricePerDay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2Button btnBook;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2TextBox txtPaymentDetails;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.LinkLabel llTransactionInfo;
        private System.Windows.Forms.Label labelHeaderGroup;
    }
}