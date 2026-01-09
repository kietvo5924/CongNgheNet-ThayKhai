namespace CarRental.Return
{
    partial class frmListReturn
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
            this.ShowReturnDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowBookingDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowCustomerDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowVehicleDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtpActualReturnDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnAddNewReturn = new Guna.UI2.WinForms.Guna2Button();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvReturnList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.cmsEditProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnList)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsEditProfile
            // 
            this.cmsEditProfile.BackColor = System.Drawing.Color.White;
            this.cmsEditProfile.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmsEditProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowReturnDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.ShowBookingDetailsToolStripMenuItem1,
            this.ShowCustomerDetailsToolStripMenuItem,
            this.ShowVehicleDetailsToolStripMenuItem});
            this.cmsEditProfile.Name = "guna2ContextMenuStrip1";
            this.cmsEditProfile.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.cmsEditProfile.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmsEditProfile.RenderStyle.ColorTable = null;
            this.cmsEditProfile.RenderStyle.RoundedEdges = true;
            this.cmsEditProfile.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.cmsEditProfile.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.cmsEditProfile.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.cmsEditProfile.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.cmsEditProfile.Size = new System.Drawing.Size(225, 106);
            // 
            // ShowReturnDetailsToolStripMenuItem
            // 
            this.ShowReturnDetailsToolStripMenuItem.Image = null;
            this.ShowReturnDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowReturnDetailsToolStripMenuItem.Name = "ShowReturnDetailsToolStripMenuItem";
            this.ShowReturnDetailsToolStripMenuItem.Size = new System.Drawing.Size(224, 24);
            this.ShowReturnDetailsToolStripMenuItem.Text = "Xem chi tiết trả xe";
            this.ShowReturnDetailsToolStripMenuItem.Click += new System.EventHandler(this.ShowReturnDetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // ShowBookingDetailsToolStripMenuItem1
            // 
            this.ShowBookingDetailsToolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            this.ShowBookingDetailsToolStripMenuItem1.Image = null;
            this.ShowBookingDetailsToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowBookingDetailsToolStripMenuItem1.Name = "ShowBookingDetailsToolStripMenuItem1";
            this.ShowBookingDetailsToolStripMenuItem1.Size = new System.Drawing.Size(224, 24);
            this.ShowBookingDetailsToolStripMenuItem1.Text = "Xem thông tin lịch đặt";
            this.ShowBookingDetailsToolStripMenuItem1.Click += new System.EventHandler(this.ShowBookingDetailsToolStripMenuItem1_Click);
            // 
            // ShowCustomerDetailsToolStripMenuItem
            // 
            this.ShowCustomerDetailsToolStripMenuItem.Image = null;
            this.ShowCustomerDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowCustomerDetailsToolStripMenuItem.Name = "ShowCustomerDetailsToolStripMenuItem";
            this.ShowCustomerDetailsToolStripMenuItem.Size = new System.Drawing.Size(224, 24);
            this.ShowCustomerDetailsToolStripMenuItem.Text = "Xem thông tin khách hàng";
            this.ShowCustomerDetailsToolStripMenuItem.Click += new System.EventHandler(this.ShowCustomerDetailsToolStripMenuItem_Click);
            // 
            // ShowVehicleDetailsToolStripMenuItem
            // 
            this.ShowVehicleDetailsToolStripMenuItem.Image = null;
            this.ShowVehicleDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowVehicleDetailsToolStripMenuItem.Name = "ShowVehicleDetailsToolStripMenuItem";
            this.ShowVehicleDetailsToolStripMenuItem.Size = new System.Drawing.Size(224, 24);
            this.ShowVehicleDetailsToolStripMenuItem.Text = "Xem thông tin xe";
            this.ShowVehicleDetailsToolStripMenuItem.Click += new System.EventHandler(this.ShowVehicleDetailsToolStripMenuItem_Click);
            // 
            // dtpActualReturnDate
            // 
            this.dtpActualReturnDate.BorderRadius = 8;
            this.dtpActualReturnDate.Checked = true;
            this.dtpActualReturnDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.dtpActualReturnDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpActualReturnDate.ForeColor = System.Drawing.Color.White;
            this.dtpActualReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpActualReturnDate.Location = new System.Drawing.Point(305, 25);
            this.dtpActualReturnDate.Name = "dtpActualReturnDate";
            this.dtpActualReturnDate.Size = new System.Drawing.Size(180, 36);
            this.dtpActualReturnDate.TabIndex = 191;
            this.dtpActualReturnDate.Visible = false;
            this.dtpActualReturnDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // btnAddNewReturn
            // 
            this.btnAddNewReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewReturn.BorderRadius = 8;
            this.btnAddNewReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewReturn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnAddNewReturn.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddNewReturn.ForeColor = System.Drawing.Color.White;
            this.btnAddNewReturn.Location = new System.Drawing.Point(1150, 25);
            this.btnAddNewReturn.Name = "btnAddNewReturn";
            this.btnAddNewReturn.Size = new System.Drawing.Size(150, 40);
            this.btnAddNewReturn.TabIndex = 190;
            this.btnAddNewReturn.Text = "Trả xe mới";
            this.btnAddNewReturn.Click += new System.EventHandler(this.btnAddNewReturn_Click);
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Segoe UI Bold", 12F);
            this.lblNumberOfRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(145, 745);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(19, 21);
            this.lblNumberOfRecords.TabIndex = 187;
            this.lblNumberOfRecords.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(30, 745);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 21);
            this.label2.TabIndex = 186;
            this.label2.Text = "Số bản ghi:";
            // 
            // cbFilter
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
            "Mã trả xe",
            "Mã khách hàng",
            "Mã xe",
            "Mã lịch đặt",
            "Mã giao dịch",
            "Tên khách hàng",
            "Ngày trả thực tế"});
            this.cbFilter.Location = new System.Drawing.Point(110, 25);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(180, 36);
            this.cbFilter.TabIndex = 185;
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
            this.txtSearch.TabIndex = 184;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(30, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 183;
            this.label1.Text = "Lọc theo:";
            // 
            // dgvReturnList
            // 
            this.dgvReturnList.AllowUserToAddRows = false;
            this.dgvReturnList.AllowUserToDeleteRows = false;
            this.dgvReturnList.AllowUserToOrderColumns = true;
            this.dgvReturnList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvReturnList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReturnList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReturnList.BackgroundColor = System.Drawing.Color.White;
            this.dgvReturnList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReturnList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReturnList.ColumnHeadersHeight = 45;
            this.dgvReturnList.ContextMenuStrip = this.cmsEditProfile;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReturnList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReturnList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvReturnList.Location = new System.Drawing.Point(20, 85);
            this.dgvReturnList.Name = "dgvReturnList";
            this.dgvReturnList.ReadOnly = true;
            this.dgvReturnList.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvReturnList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvReturnList.RowTemplate.DividerHeight = 5;
            this.dgvReturnList.RowTemplate.Height = 40;
            this.dgvReturnList.Size = new System.Drawing.Size(1280, 640);
            this.dgvReturnList.TabIndex = 192;
            this.dgvReturnList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvReturnList.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvReturnList.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvReturnList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvReturnList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvReturnList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.dgvReturnList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dgvReturnList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReturnList.ThemeStyle.HeaderStyle.Height = 45;
            this.dgvReturnList.ThemeStyle.ReadOnly = true;
            this.dgvReturnList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvReturnList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReturnList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvReturnList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvReturnList.ThemeStyle.RowsStyle.Height = 40;
            this.dgvReturnList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.dgvReturnList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvReturnList.DoubleClick += new System.EventHandler(this.dgvReturnList_DoubleClick);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.Controls.Add(this.btnAddNewReturn);
            this.guna2Panel1.Controls.Add(this.dgvReturnList);
            this.guna2Panel1.Controls.Add(this.txtSearch);
            this.guna2Panel1.Controls.Add(this.dtpActualReturnDate);
            this.guna2Panel1.Controls.Add(this.lblNumberOfRecords);
            this.guna2Panel1.Controls.Add(this.cbFilter);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(20, 20);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1326, 780);
            this.guna2Panel1.TabIndex = 193;
            // 
            // frmListReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1366, 820);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListReturn";
            this.Tag = "Quản lý trả xe";
            this.Text = "Danh sách trả xe";
            this.Load += new System.EventHandler(this.frmListReturn_Load);
            this.cmsEditProfile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnList)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ContextMenuStrip cmsEditProfile;
        private System.Windows.Forms.ToolStripMenuItem ShowBookingDetailsToolStripMenuItem1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpActualReturnDate;
        private Guna.UI2.WinForms.Guna2Button btnAddNewReturn;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem ShowReturnDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowCustomerDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowVehicleDetailsToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2DataGridView dgvReturnList;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}