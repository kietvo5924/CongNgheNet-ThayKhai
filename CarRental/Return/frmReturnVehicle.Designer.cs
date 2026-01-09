namespace CarRental.Return
{
    partial class frmReturnVehicle
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.guna2PanelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.llShowUpdatedTransactionDetails = new System.Windows.Forms.LinkLabel();
            this.llShowReturnDetails = new System.Windows.Forms.LinkLabel();
            this.btnReturn = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PanelReturnInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.labelHeaderGroup = new System.Windows.Forms.Label();
            this.txtFinalCheckNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAdditionalCharges = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMileage = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpActualReturnDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblActualRentalDays = new System.Windows.Forms.Label();
            this.lblActualTotalDueAmount = new System.Windows.Forms.Label();
            this.lblConsumedMileage = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblReturnID = new System.Windows.Forms.Label();
            this.ucBookingCardWithFilter1 = new CarRental.Booking.UserControls.ucBookingCardWithFilter();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.guna2PanelMain.SuspendLayout();
            this.guna2PanelReturnInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 6);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1061, 68);
            this.lblTitle.TabIndex = 175;
            this.lblTitle.Text = "HOÀN TẤT TRẢ XE";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2PanelMain
            // 
            this.guna2PanelMain.BorderRadius = 15;
            this.guna2PanelMain.Controls.Add(this.llShowUpdatedTransactionDetails);
            this.guna2PanelMain.Controls.Add(this.llShowReturnDetails);
            this.guna2PanelMain.Controls.Add(this.btnReturn);
            this.guna2PanelMain.Controls.Add(this.btnClose);
            this.guna2PanelMain.Controls.Add(this.guna2PanelReturnInfo);
            this.guna2PanelMain.Controls.Add(this.ucBookingCardWithFilter1);
            this.guna2PanelMain.FillColor = System.Drawing.Color.White;
            this.guna2PanelMain.Location = new System.Drawing.Point(16, 74);
            this.guna2PanelMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2PanelMain.Name = "guna2PanelMain";
            this.guna2PanelMain.Size = new System.Drawing.Size(1033, 929);
            this.guna2PanelMain.TabIndex = 220;
            // 
            // llShowUpdatedTransactionDetails
            // 
            this.llShowUpdatedTransactionDetails.AutoSize = true;
            this.llShowUpdatedTransactionDetails.Enabled = false;
            this.llShowUpdatedTransactionDetails.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.llShowUpdatedTransactionDetails.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.llShowUpdatedTransactionDetails.Location = new System.Drawing.Point(13, 880);
            this.llShowUpdatedTransactionDetails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llShowUpdatedTransactionDetails.Name = "llShowUpdatedTransactionDetails";
            this.llShowUpdatedTransactionDetails.Size = new System.Drawing.Size(210, 25);
            this.llShowUpdatedTransactionDetails.TabIndex = 202;
            this.llShowUpdatedTransactionDetails.TabStop = true;
            this.llShowUpdatedTransactionDetails.Text = "Xem giao dịch cập nhật";
            this.llShowUpdatedTransactionDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowUpdateTransactionDetails_LinkClicked);
            // 
            // llShowReturnDetails
            // 
            this.llShowReturnDetails.AutoSize = true;
            this.llShowReturnDetails.Enabled = false;
            this.llShowReturnDetails.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.llShowReturnDetails.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.llShowReturnDetails.Location = new System.Drawing.Point(293, 880);
            this.llShowReturnDetails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llShowReturnDetails.Name = "llShowReturnDetails";
            this.llShowReturnDetails.Size = new System.Drawing.Size(139, 25);
            this.llShowReturnDetails.TabIndex = 201;
            this.llShowReturnDetails.TabStop = true;
            this.llShowReturnDetails.Text = "Xem chi tiết trả";
            this.llShowReturnDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowReturnDetails_LinkClicked);
            // 
            // btnReturn
            // 
            this.btnReturn.BorderRadius = 8;
            this.btnReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturn.Enabled = false;
            this.btnReturn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnReturn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnReturn.ForeColor = System.Drawing.Color.White;
            this.btnReturn.Location = new System.Drawing.Point(804, 864);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(213, 55);
            this.btnReturn.TabIndex = 200;
            this.btnReturn.Text = "Xác nhận Trả";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 8;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.btnClose.Location = new System.Drawing.Point(569, 864);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(213, 55);
            this.btnClose.TabIndex = 199;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // guna2PanelReturnInfo
            // 
            this.guna2PanelReturnInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.guna2PanelReturnInfo.BorderRadius = 15;
            this.guna2PanelReturnInfo.BorderThickness = 1;
            this.guna2PanelReturnInfo.Controls.Add(this.labelHeaderGroup);
            this.guna2PanelReturnInfo.Controls.Add(this.txtFinalCheckNotes);
            this.guna2PanelReturnInfo.Controls.Add(this.txtAdditionalCharges);
            this.guna2PanelReturnInfo.Controls.Add(this.txtMileage);
            this.guna2PanelReturnInfo.Controls.Add(this.dtpActualReturnDate);
            this.guna2PanelReturnInfo.Controls.Add(this.lblActualRentalDays);
            this.guna2PanelReturnInfo.Controls.Add(this.lblActualTotalDueAmount);
            this.guna2PanelReturnInfo.Controls.Add(this.lblConsumedMileage);
            this.guna2PanelReturnInfo.Controls.Add(this.label26);
            this.guna2PanelReturnInfo.Controls.Add(this.label9);
            this.guna2PanelReturnInfo.Controls.Add(this.label10);
            this.guna2PanelReturnInfo.Controls.Add(this.label6);
            this.guna2PanelReturnInfo.Controls.Add(this.label27);
            this.guna2PanelReturnInfo.Controls.Add(this.label5);
            this.guna2PanelReturnInfo.Controls.Add(this.label3);
            this.guna2PanelReturnInfo.Controls.Add(this.label22);
            this.guna2PanelReturnInfo.Controls.Add(this.lblReturnID);
            this.guna2PanelReturnInfo.FillColor = System.Drawing.Color.White;
            this.guna2PanelReturnInfo.Location = new System.Drawing.Point(0, 455);
            this.guna2PanelReturnInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2PanelReturnInfo.Name = "guna2PanelReturnInfo";
            this.guna2PanelReturnInfo.Size = new System.Drawing.Size(1033, 394);
            this.guna2PanelReturnInfo.TabIndex = 180;
            // 
            // labelHeaderGroup
            // 
            this.labelHeaderGroup.AutoSize = true;
            this.labelHeaderGroup.BackColor = System.Drawing.Color.Transparent;
            this.labelHeaderGroup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelHeaderGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelHeaderGroup.Location = new System.Drawing.Point(20, 12);
            this.labelHeaderGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHeaderGroup.Name = "labelHeaderGroup";
            this.labelHeaderGroup.Size = new System.Drawing.Size(213, 28);
            this.labelHeaderGroup.TabIndex = 0;
            this.labelHeaderGroup.Text = "Thông tin quyết toán";
            // 
            // txtFinalCheckNotes
            // 
            this.txtFinalCheckNotes.BorderRadius = 8;
            this.txtFinalCheckNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFinalCheckNotes.DefaultText = "";
            this.txtFinalCheckNotes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFinalCheckNotes.Location = new System.Drawing.Point(227, 271);
            this.txtFinalCheckNotes.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtFinalCheckNotes.Multiline = true;
            this.txtFinalCheckNotes.Name = "txtFinalCheckNotes";
            this.txtFinalCheckNotes.PasswordChar = '\0';
            this.txtFinalCheckNotes.PlaceholderText = "";
            this.txtFinalCheckNotes.SelectedText = "";
            this.txtFinalCheckNotes.Size = new System.Drawing.Size(767, 98);
            this.txtFinalCheckNotes.TabIndex = 232;
            this.txtFinalCheckNotes.Validating += new System.ComponentModel.CancelEventHandler(this.txtFinalCheckNotes_Validating);
            // 
            // txtAdditionalCharges
            // 
            this.txtAdditionalCharges.BorderRadius = 8;
            this.txtAdditionalCharges.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAdditionalCharges.DefaultText = "";
            this.txtAdditionalCharges.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAdditionalCharges.Location = new System.Drawing.Point(753, 68);
            this.txtAdditionalCharges.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtAdditionalCharges.Name = "txtAdditionalCharges";
            this.txtAdditionalCharges.PasswordChar = '\0';
            this.txtAdditionalCharges.PlaceholderText = "";
            this.txtAdditionalCharges.SelectedText = "";
            this.txtAdditionalCharges.Size = new System.Drawing.Size(240, 44);
            this.txtAdditionalCharges.TabIndex = 231;
            this.txtAdditionalCharges.Validating += new System.ComponentModel.CancelEventHandler(this.txtAdditionalCharges_Validating);
            // 
            // txtMileage
            // 
            this.txtMileage.BorderRadius = 8;
            this.txtMileage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMileage.DefaultText = "";
            this.txtMileage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMileage.Location = new System.Drawing.Point(753, 129);
            this.txtMileage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtMileage.Name = "txtMileage";
            this.txtMileage.PasswordChar = '\0';
            this.txtMileage.PlaceholderText = "";
            this.txtMileage.SelectedText = "";
            this.txtMileage.Size = new System.Drawing.Size(240, 44);
            this.txtMileage.TabIndex = 230;
            this.txtMileage.Validating += new System.ComponentModel.CancelEventHandler(this.txtMileage_Validating);
            // 
            // dtpActualReturnDate
            // 
            this.dtpActualReturnDate.BorderRadius = 8;
            this.dtpActualReturnDate.Checked = true;
            this.dtpActualReturnDate.FillColor = System.Drawing.Color.White;
            this.dtpActualReturnDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpActualReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpActualReturnDate.Location = new System.Drawing.Point(227, 197);
            this.dtpActualReturnDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpActualReturnDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpActualReturnDate.MinDate = new System.DateTime(2023, 11, 8, 0, 0, 0, 0);
            this.dtpActualReturnDate.Name = "dtpActualReturnDate";
            this.dtpActualReturnDate.Size = new System.Drawing.Size(240, 44);
            this.dtpActualReturnDate.TabIndex = 207;
            this.dtpActualReturnDate.Value = new System.DateTime(2023, 11, 8, 23, 9, 0, 486);
            this.dtpActualReturnDate.ValueChanged += new System.EventHandler(this.dtpActualReturnDate_ValueChanged);
            // 
            // lblActualRentalDays
            // 
            this.lblActualRentalDays.AutoSize = true;
            this.lblActualRentalDays.BackColor = System.Drawing.Color.Transparent;
            this.lblActualRentalDays.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblActualRentalDays.Location = new System.Drawing.Point(227, 142);
            this.lblActualRentalDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActualRentalDays.Name = "lblActualRentalDays";
            this.lblActualRentalDays.Size = new System.Drawing.Size(58, 25);
            this.lblActualRentalDays.TabIndex = 206;
            this.lblActualRentalDays.Text = "[????]";
            // 
            // lblActualTotalDueAmount
            // 
            this.lblActualTotalDueAmount.AutoSize = true;
            this.lblActualTotalDueAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblActualTotalDueAmount.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblActualTotalDueAmount.ForeColor = System.Drawing.Color.Green;
            this.lblActualTotalDueAmount.Location = new System.Drawing.Point(753, 197);
            this.lblActualTotalDueAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActualTotalDueAmount.Name = "lblActualTotalDueAmount";
            this.lblActualTotalDueAmount.Size = new System.Drawing.Size(69, 37);
            this.lblActualTotalDueAmount.TabIndex = 204;
            this.lblActualTotalDueAmount.Text = "N/A";
            // 
            // lblConsumedMileage
            // 
            this.lblConsumedMileage.AutoSize = true;
            this.lblConsumedMileage.BackColor = System.Drawing.Color.Transparent;
            this.lblConsumedMileage.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblConsumedMileage.Location = new System.Drawing.Point(227, 172);
            this.lblConsumedMileage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConsumedMileage.Name = "lblConsumedMileage";
            this.lblConsumedMileage.Size = new System.Drawing.Size(48, 25);
            this.lblConsumedMileage.TabIndex = 201;
            this.lblConsumedMileage.Text = "N/A";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label26.ForeColor = System.Drawing.Color.Gray;
            this.label26.Location = new System.Drawing.Point(33, 172);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(128, 23);
            this.label26.TabIndex = 198;
            this.label26.Text = "Số Km đã chạy:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(533, 203);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(177, 23);
            this.label9.TabIndex = 191;
            this.label9.Text = "Tổng tiền thanh toán:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(533, 80);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 23);
            this.label10.TabIndex = 182;
            this.label10.Text = "Phí phát sinh:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(533, 142);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 23);
            this.label6.TabIndex = 179;
            this.label6.Text = "Số Km hiện tại:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label27.ForeColor = System.Drawing.Color.Gray;
            this.label27.Location = new System.Drawing.Point(33, 271);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(141, 23);
            this.label27.TabIndex = 159;
            this.label27.Text = "Ghi chú kiểm tra:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(33, 142);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 23);
            this.label5.TabIndex = 156;
            this.label5.Text = "Số ngày thuê TT:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(33, 203);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 23);
            this.label3.TabIndex = 153;
            this.label3.Text = "Ngày trả thực tế:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.Color.Gray;
            this.label22.Location = new System.Drawing.Point(33, 80);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(109, 23);
            this.label22.TabIndex = 147;
            this.label22.Text = "Mã hoàn trả:";
            // 
            // lblReturnID
            // 
            this.lblReturnID.AutoSize = true;
            this.lblReturnID.BackColor = System.Drawing.Color.Transparent;
            this.lblReturnID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblReturnID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.lblReturnID.Location = new System.Drawing.Point(227, 80);
            this.lblReturnID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReturnID.Name = "lblReturnID";
            this.lblReturnID.Size = new System.Drawing.Size(50, 23);
            this.lblReturnID.TabIndex = 148;
            this.lblReturnID.Text = "[????]";
            // 
            // ucBookingCardWithFilter1
            // 
            this.ucBookingCardWithFilter1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucBookingCardWithFilter1.BackColor = System.Drawing.Color.Transparent;
            this.ucBookingCardWithFilter1.FilterEnabled = true;
            this.ucBookingCardWithFilter1.Location = new System.Drawing.Point(0, 0);
            this.ucBookingCardWithFilter1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucBookingCardWithFilter1.Name = "ucBookingCardWithFilter1";
            this.ucBookingCardWithFilter1.ShowAddBookingButton = true;
            this.ucBookingCardWithFilter1.Size = new System.Drawing.Size(1060, 455);
            this.ucBookingCardWithFilter1.TabIndex = 176;
            this.ucBookingCardWithFilter1.OnBookingSelected += new System.EventHandler<CarRental.Booking.UserControls.ucBookingCardWithFilter.BookingSelectedEventArgs>(this.ucBookingCardWithFilter1_OnBookingSelected);
            this.ucBookingCardWithFilter1.Load += new System.EventHandler(this.ucBookingCardWithFilter1_Load);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmReturnVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1065, 1022);
            this.Controls.Add(this.guna2PanelMain);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmReturnVehicle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trả xe";
            this.Load += new System.EventHandler(this.frmReturnVehicle_Load);
            this.guna2PanelMain.ResumeLayout(false);
            this.guna2PanelMain.PerformLayout();
            this.guna2PanelReturnInfo.ResumeLayout(false);
            this.guna2PanelReturnInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel guna2PanelMain;
        private Booking.UserControls.ucBookingCardWithFilter ucBookingCardWithFilter1;
        private Guna.UI2.WinForms.Guna2Panel guna2PanelReturnInfo;
        private System.Windows.Forms.Label lblActualRentalDays;
        private System.Windows.Forms.Label lblActualTotalDueAmount;
        private System.Windows.Forms.Label lblConsumedMileage;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblReturnID;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpActualReturnDate;
        private Guna.UI2.WinForms.Guna2TextBox txtFinalCheckNotes;
        private Guna.UI2.WinForms.Guna2TextBox txtAdditionalCharges;
        private Guna.UI2.WinForms.Guna2TextBox txtMileage;
        private Guna.UI2.WinForms.Guna2Button btnReturn;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.LinkLabel llShowReturnDetails;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.LinkLabel llShowUpdatedTransactionDetails;
        private System.Windows.Forms.Label labelHeaderGroup;
    }
}