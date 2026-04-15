namespace CarRental.Booking
{
    partial class frmListBooking
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsEditProfile = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.ShowBookingDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelBookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReturnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnAddNewBooking = new Guna.UI2.WinForms.Guna2Button();
            this.dgvBookingList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblEmptyState = new System.Windows.Forms.Label();
            this.lblAlerts = new System.Windows.Forms.Label();
            this.btnQuickClearAlerts = new Guna.UI2.WinForms.Guna2Button();
            this.btnQuickPickupToday = new Guna.UI2.WinForms.Guna2Button();
            this.btnQuickDueToday = new Guna.UI2.WinForms.Guna2Button();
            this.btnQuickOverdue = new Guna.UI2.WinForms.Guna2Button();
            this.btnToggleAutoRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.cmsEditProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookingList)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsEditProfile
            // 
            this.cmsEditProfile.BackColor = System.Drawing.Color.White;
            this.cmsEditProfile.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmsEditProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowBookingDetailsToolStripMenuItem1,
            this.toolStripSeparator1,
            this.cancelBookingToolStripMenuItem,
            this.ReturnToolStripMenuItem});
            this.cmsEditProfile.Name = "guna2ContextMenuStrip1";
            this.cmsEditProfile.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.cmsEditProfile.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmsEditProfile.RenderStyle.ColorTable = null;
            this.cmsEditProfile.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.cmsEditProfile.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.cmsEditProfile.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.cmsEditProfile.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.cmsEditProfile.Size = new System.Drawing.Size(193, 84);
            // 
            // ShowBookingDetailsToolStripMenuItem1
            // 
            this.ShowBookingDetailsToolStripMenuItem1.Name = "ShowBookingDetailsToolStripMenuItem1";
            this.ShowBookingDetailsToolStripMenuItem1.Size = new System.Drawing.Size(192, 24);
            this.ShowBookingDetailsToolStripMenuItem1.Text = "Xem chi tiết đặt xe";
            this.ShowBookingDetailsToolStripMenuItem1.Click += new System.EventHandler(this.ShowBookingDetailsToolStripMenuItem1_Click);
            // 
            // cancelBookingToolStripMenuItem
            // 
            this.cancelBookingToolStripMenuItem.Name = "cancelBookingToolStripMenuItem";
            this.cancelBookingToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.cancelBookingToolStripMenuItem.Text = "Hủy đặt xe";
            this.cancelBookingToolStripMenuItem.Click += new System.EventHandler(this.cancelBookingToolStripMenuItem_Click);
            // 
            // ReturnToolStripMenuItem
            // 
            this.ReturnToolStripMenuItem.Name = "ReturnToolStripMenuItem";
            this.ReturnToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.ReturnToolStripMenuItem.Text = "Trả xe";
            this.ReturnToolStripMenuItem.Click += new System.EventHandler(this.ReturnToolStripMenuItem_Click);
            // 
            // lblNumberOfRecords (SỬA LẠI: ĐẨY SANG PHẢI ĐỂ KHÔNG ĐÈ)
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.BackColor = System.Drawing.Color.White;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Segoe UI Bold", 12F);
            this.lblNumberOfRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(145, 745);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(19, 21);
            this.lblNumberOfRecords.TabIndex = 177;
            this.lblNumberOfRecords.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(30, 745);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 21);
            this.label2.TabIndex = 176;
            this.label2.Text = "Số bản ghi:";
            // 
            // cbFilter (SỬA LẠI: GIỮ NGUYÊN FONT KHI RÊ CHUỘT)
            // 
            this.cbFilter.BackColor = System.Drawing.Color.Transparent;
            this.cbFilter.BorderRadius = 8;
            this.cbFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.cbFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.cbFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbFilter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.cbFilter.ItemHeight = 30;
            this.cbFilter.Items.AddRange(new object[] {
            "Không lọc",
            "Mã lịch đặt",
            "Mã khách hàng",
            "Tên khách hàng",
            "Mã xe",
            "Ngày nhận xe",
            "Ngày trả xe",
            "Điểm nhận",
            "Điểm trả"});
            this.cbFilter.Location = new System.Drawing.Point(110, 25);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(180, 36);
            this.cbFilter.TabIndex = 174;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.txtSearch.Location = new System.Drawing.Point(305, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "Tìm kiếm nhanh...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(280, 36);
            this.txtSearch.TabIndex = 173;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(30, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 172;
            this.label1.Text = "Lọc theo:";
            // 
            // dtpDate
            // 
            this.dtpDate.BorderRadius = 8;
            this.dtpDate.Checked = true;
            this.dtpDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDate.ForeColor = System.Drawing.Color.White;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(305, 25);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(180, 36);
            this.dtpDate.TabIndex = 182;
            this.dtpDate.Visible = false;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // btnAddNewBooking (SỬA LẠI: BỎ HÌNH ẢNH)
            // 
            this.btnAddNewBooking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewBooking.BorderRadius = 8;
            this.btnAddNewBooking.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewBooking.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnAddNewBooking.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddNewBooking.ForeColor = System.Drawing.Color.White;
            this.btnAddNewBooking.Location = new System.Drawing.Point(1150, 25);
            this.btnAddNewBooking.Name = "btnAddNewBooking";
            this.btnAddNewBooking.Size = new System.Drawing.Size(150, 40);
            this.btnAddNewBooking.TabIndex = 181;
            this.btnAddNewBooking.Text = "Đặt xe mới";
            this.btnAddNewBooking.Click += new System.EventHandler(this.btnAddNewBooking_Click);
            // 
            // dgvBookingList
            // 
            this.dgvBookingList.AllowUserToAddRows = false;
            this.dgvBookingList.AllowUserToDeleteRows = false;
            this.dgvBookingList.AllowUserToOrderColumns = true;
            this.dgvBookingList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvBookingList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBookingList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBookingList.BackgroundColor = System.Drawing.Color.White;
            this.dgvBookingList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBookingList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBookingList.ColumnHeadersHeight = 45;
            this.dgvBookingList.ContextMenuStrip = this.cmsEditProfile;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBookingList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBookingList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvBookingList.Location = new System.Drawing.Point(20, 85);
            this.dgvBookingList.Name = "dgvBookingList";
            this.dgvBookingList.ReadOnly = true;
            this.dgvBookingList.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvBookingList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBookingList.RowTemplate.DividerHeight = 5;
            this.dgvBookingList.RowTemplate.Height = 40;
            this.dgvBookingList.Size = new System.Drawing.Size(1280, 640);
            this.dgvBookingList.TabIndex = 193;
            this.dgvBookingList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBookingList.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvBookingList.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvBookingList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvBookingList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.dgvBookingList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dgvBookingList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBookingList.ThemeStyle.RowsStyle.Height = 40;
            this.dgvBookingList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.dgvBookingList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvBookingList.DoubleClick += new System.EventHandler(this.dgvBookingList_DoubleClick);
            // 
            // guna2Panel1 (CARD CHỨA NỘI DUNG)
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.Controls.Add(this.btnAddNewBooking);
            this.guna2Panel1.Controls.Add(this.dgvBookingList);
            this.guna2Panel1.Controls.Add(this.txtSearch);
            this.guna2Panel1.Controls.Add(this.dtpDate);
            this.guna2Panel1.Controls.Add(this.btnQuickClearAlerts);
            this.guna2Panel1.Controls.Add(this.btnQuickPickupToday);
            this.guna2Panel1.Controls.Add(this.btnQuickDueToday);
            this.guna2Panel1.Controls.Add(this.btnQuickOverdue);
            this.guna2Panel1.Controls.Add(this.btnToggleAutoRefresh);
            this.guna2Panel1.Controls.Add(this.lblAlerts);
            this.guna2Panel1.Controls.Add(this.lblEmptyState);
            this.guna2Panel1.Controls.Add(this.lblNumberOfRecords);
            this.guna2Panel1.Controls.Add(this.cbFilter);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(20, 20);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1326, 780);
            this.guna2Panel1.TabIndex = 194;
            // 
            // lblEmptyState
            // 
            this.lblEmptyState.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEmptyState.AutoSize = true;
            this.lblEmptyState.BackColor = System.Drawing.Color.White;
            this.lblEmptyState.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblEmptyState.ForeColor = System.Drawing.Color.Gray;
            this.lblEmptyState.Location = new System.Drawing.Point(506, 395);
            this.lblEmptyState.Name = "lblEmptyState";
            this.lblEmptyState.Size = new System.Drawing.Size(315, 21);
            this.lblEmptyState.TabIndex = 195;
            this.lblEmptyState.Text = "Không có dữ liệu phù hợp với bộ lọc hiện tại.";
            this.lblEmptyState.Visible = false;
            // 
            // lblAlerts
            // 
            this.lblAlerts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlerts.BackColor = System.Drawing.Color.White;
            this.lblAlerts.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblAlerts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(9)))));
            this.lblAlerts.Location = new System.Drawing.Point(20, 66);
            this.lblAlerts.Name = "lblAlerts";
            this.lblAlerts.Size = new System.Drawing.Size(950, 20);
            this.lblAlerts.TabIndex = 196;
            this.lblAlerts.Text = "";
            // 
            // btnQuickClearAlerts
            // 
            this.btnQuickClearAlerts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuickClearAlerts.BorderRadius = 6;
            this.btnQuickClearAlerts.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnQuickClearAlerts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnQuickClearAlerts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnQuickClearAlerts.Location = new System.Drawing.Point(1140, 72);
            this.btnQuickClearAlerts.Name = "btnQuickClearAlerts";
            this.btnQuickClearAlerts.Size = new System.Drawing.Size(160, 24);
            this.btnQuickClearAlerts.TabIndex = 200;
            this.btnQuickClearAlerts.Text = "Bỏ lọc cảnh báo";
            this.btnQuickClearAlerts.Click += new System.EventHandler(this.btnQuickClearAlerts_Click);
            // 
            // btnQuickPickupToday
            // 
            this.btnQuickPickupToday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuickPickupToday.BorderRadius = 6;
            this.btnQuickPickupToday.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            this.btnQuickPickupToday.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnQuickPickupToday.ForeColor = System.Drawing.Color.White;
            this.btnQuickPickupToday.Location = new System.Drawing.Point(996, 72);
            this.btnQuickPickupToday.Name = "btnQuickPickupToday";
            this.btnQuickPickupToday.Size = new System.Drawing.Size(140, 24);
            this.btnQuickPickupToday.TabIndex = 199;
            this.btnQuickPickupToday.Text = "Nhận hôm nay";
            this.btnQuickPickupToday.Click += new System.EventHandler(this.btnQuickPickupToday_Click);
            // 
            // btnQuickDueToday
            // 
            this.btnQuickDueToday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuickDueToday.BorderRadius = 6;
            this.btnQuickDueToday.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(88)))), ((int)(((byte)(12)))));
            this.btnQuickDueToday.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnQuickDueToday.ForeColor = System.Drawing.Color.White;
            this.btnQuickDueToday.Location = new System.Drawing.Point(850, 72);
            this.btnQuickDueToday.Name = "btnQuickDueToday";
            this.btnQuickDueToday.Size = new System.Drawing.Size(140, 24);
            this.btnQuickDueToday.TabIndex = 198;
            this.btnQuickDueToday.Text = "Đến hạn hôm nay";
            this.btnQuickDueToday.Click += new System.EventHandler(this.btnQuickDueToday_Click);
            // 
            // btnQuickOverdue
            // 
            this.btnQuickOverdue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuickOverdue.BorderRadius = 6;
            this.btnQuickOverdue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnQuickOverdue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnQuickOverdue.ForeColor = System.Drawing.Color.White;
            this.btnQuickOverdue.Location = new System.Drawing.Point(704, 72);
            this.btnQuickOverdue.Name = "btnQuickOverdue";
            this.btnQuickOverdue.Size = new System.Drawing.Size(140, 24);
            this.btnQuickOverdue.TabIndex = 197;
            this.btnQuickOverdue.Text = "Quá hạn trả";
            this.btnQuickOverdue.Click += new System.EventHandler(this.btnQuickOverdue_Click);
            // 
            // btnToggleAutoRefresh
            // 
            this.btnToggleAutoRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToggleAutoRefresh.BorderRadius = 8;
            this.btnToggleAutoRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnToggleAutoRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnToggleAutoRefresh.ForeColor = System.Drawing.Color.White;
            this.btnToggleAutoRefresh.Location = new System.Drawing.Point(980, 25);
            this.btnToggleAutoRefresh.Name = "btnToggleAutoRefresh";
            this.btnToggleAutoRefresh.Size = new System.Drawing.Size(164, 27);
            this.btnToggleAutoRefresh.TabIndex = 201;
            this.btnToggleAutoRefresh.Text = "Tự làm mới: Bật";
            this.btnToggleAutoRefresh.Click += new System.EventHandler(this.btnToggleAutoRefresh_Click);
            // 
            // frmListBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1366, 820);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListBooking";
            this.Tag = "Quản lý đặt xe";
            this.Text = "Danh sách đặt xe";
            this.Load += new System.EventHandler(this.frmListBooking_Load);
            this.cmsEditProfile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookingList)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ContextMenuStrip cmsEditProfile;
        private System.Windows.Forms.ToolStripMenuItem ShowBookingDetailsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cancelBookingToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2Button btnAddNewBooking;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDate;
        private System.Windows.Forms.ToolStripMenuItem ReturnToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2DataGridView dgvBookingList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblEmptyState;
        private System.Windows.Forms.Label lblAlerts;
        private Guna.UI2.WinForms.Guna2Button btnQuickClearAlerts;
        private Guna.UI2.WinForms.Guna2Button btnQuickPickupToday;
        private Guna.UI2.WinForms.Guna2Button btnQuickDueToday;
        private Guna.UI2.WinForms.Guna2Button btnQuickOverdue;
        private Guna.UI2.WinForms.Guna2Button btnToggleAutoRefresh;
    }
}