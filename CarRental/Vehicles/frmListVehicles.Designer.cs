namespace CarRental.Vehicles
{
    partial class frmListVehicles
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
            this.showVehicleDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editVehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteVehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAddNewVehicle = new Guna.UI2.WinForms.Guna2Button();
            this.dgvVehiclesList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbIsAvailable = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbFuelType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbMake = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblEmptyState = new System.Windows.Forms.Label();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsEditProfile.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiclesList)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsEditProfile
            // 
            this.cmsEditProfile.BackColor = System.Drawing.Color.White;
            this.cmsEditProfile.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmsEditProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showVehicleDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.editVehicleToolStripMenuItem,
            this.deleteVehicleToolStripMenuItem});
            this.cmsEditProfile.Name = "cmsEditProfile";
            this.cmsEditProfile.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.cmsEditProfile.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.cmsEditProfile.Size = new System.Drawing.Size(155, 82);
            // 
            // showVehicleDetailsToolStripMenuItem
            // 
            this.showVehicleDetailsToolStripMenuItem.Name = "showVehicleDetailsToolStripMenuItem";
            this.showVehicleDetailsToolStripMenuItem.Size = new System.Drawing.Size(154, 24);
            this.showVehicleDetailsToolStripMenuItem.Text = "Xem chi tiết";
            this.showVehicleDetailsToolStripMenuItem.Click += new System.EventHandler(this.showVehicleDetailsToolStripMenuItem_Click);
            // 
            // editVehicleToolStripMenuItem
            // 
            this.editVehicleToolStripMenuItem.Name = "editVehicleToolStripMenuItem";
            this.editVehicleToolStripMenuItem.Size = new System.Drawing.Size(154, 24);
            this.editVehicleToolStripMenuItem.Text = "Chỉnh sửa";
            this.editVehicleToolStripMenuItem.Click += new System.EventHandler(this.editVehicleToolStripMenuItem_Click);
            // 
            // deleteVehicleToolStripMenuItem
            // 
            this.deleteVehicleToolStripMenuItem.Name = "deleteVehicleToolStripMenuItem";
            this.deleteVehicleToolStripMenuItem.Size = new System.Drawing.Size(154, 24);
            this.deleteVehicleToolStripMenuItem.Text = "Xóa xe";
            this.deleteVehicleToolStripMenuItem.Click += new System.EventHandler(this.deleteVehicleToolStripMenuItem_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.Controls.Add(this.btnAddNewVehicle);
            this.guna2Panel1.Controls.Add(this.dgvVehiclesList);
            this.guna2Panel1.Controls.Add(this.txtSearch);
            this.guna2Panel1.Controls.Add(this.cbIsAvailable);
            this.guna2Panel1.Controls.Add(this.cbFuelType);
            this.guna2Panel1.Controls.Add(this.cbMake);
            this.guna2Panel1.Controls.Add(this.cbFilter);
            this.guna2Panel1.Controls.Add(this.lblEmptyState);
            this.guna2Panel1.Controls.Add(this.lblNumberOfRecords);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(20, 20);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1326, 780);
            this.guna2Panel1.TabIndex = 0;
            // 
            // btnAddNewVehicle
            // 
            this.btnAddNewVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewVehicle.BorderRadius = 8;
            this.btnAddNewVehicle.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnAddNewVehicle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddNewVehicle.ForeColor = System.Drawing.Color.White;
            this.btnAddNewVehicle.Location = new System.Drawing.Point(1150, 25);
            this.btnAddNewVehicle.Name = "btnAddNewVehicle";
            this.btnAddNewVehicle.Size = new System.Drawing.Size(150, 40);
            this.btnAddNewVehicle.Text = "Thêm xe mới";
            this.btnAddNewVehicle.Click += new System.EventHandler(this.btnAddNewVehicle_Click);
            // 
            // dgvVehiclesList
            // 
            this.dgvVehiclesList.AllowUserToAddRows = false;
            this.dgvVehiclesList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvVehiclesList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVehiclesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVehiclesList.BackgroundColor = System.Drawing.Color.White;
            this.dgvVehiclesList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvVehiclesList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVehiclesList.ColumnHeadersHeight = 45;
            this.dgvVehiclesList.ContextMenuStrip = this.cmsEditProfile;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvVehiclesList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvVehiclesList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvVehiclesList.Location = new System.Drawing.Point(20, 85);
            this.dgvVehiclesList.Name = "dgvVehiclesList";
            this.dgvVehiclesList.ReadOnly = true;
            this.dgvVehiclesList.RowHeadersVisible = false;
            this.dgvVehiclesList.RowTemplate.Height = 40;
            this.dgvVehiclesList.Size = new System.Drawing.Size(1280, 640);
            this.dgvVehiclesList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.dgvVehiclesList.DoubleClick += new System.EventHandler(this.dgvVehiclesList_DoubleClick);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(305, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tìm kiếm xe...";
            this.txtSearch.Size = new System.Drawing.Size(280, 36);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // cbFilter
            // 
            this.cbFilter.BackColor = System.Drawing.Color.Transparent;
            this.cbFilter.BorderRadius = 8;
            this.cbFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFilter.ItemHeight = 30;
            this.cbFilter.Items.AddRange(new object[] {
            "Không lọc",
            "Mã xe",
            "Tên xe",
            "Biển số",
            "Hãng xe",
            "Loại nhiên liệu",
            "Trạng thái"});
            this.cbFilter.Location = new System.Drawing.Point(110, 25);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(180, 36);
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // cbMake
            // 
            this.cbMake.BackColor = System.Drawing.Color.Transparent;
            this.cbMake.BorderRadius = 8;
            this.cbMake.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMake.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbMake.ItemHeight = 30;
            this.cbMake.Location = new System.Drawing.Point(305, 25);
            this.cbMake.Name = "cbMake";
            this.cbMake.Size = new System.Drawing.Size(200, 36);
            this.cbMake.Visible = false;
            this.cbMake.SelectedIndexChanged += new System.EventHandler(this.cbMake_SelectedIndexChanged);
            // 
            // cbFuelType
            // 
            this.cbFuelType.BackColor = System.Drawing.Color.Transparent;
            this.cbFuelType.BorderRadius = 8;
            this.cbFuelType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFuelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFuelType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFuelType.ItemHeight = 30;
            this.cbFuelType.Location = new System.Drawing.Point(305, 25);
            this.cbFuelType.Name = "cbFuelType";
            this.cbFuelType.Size = new System.Drawing.Size(200, 36);
            this.cbFuelType.Visible = false;
            this.cbFuelType.SelectedIndexChanged += new System.EventHandler(this.cbFuelType_SelectedIndexChanged);
            // 
            // cbIsAvailable
            // 
            this.cbIsAvailable.BackColor = System.Drawing.Color.Transparent;
            this.cbIsAvailable.BorderRadius = 8;
            this.cbIsAvailable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbIsAvailable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsAvailable.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbIsAvailable.ItemHeight = 30;
            this.cbIsAvailable.Items.AddRange(new object[] {
            "Tất cả",
            "Sẵn sàng",
            "Đang thuê"});
            this.cbIsAvailable.Location = new System.Drawing.Point(305, 25);
            this.cbIsAvailable.Name = "cbIsAvailable";
            this.cbIsAvailable.Size = new System.Drawing.Size(200, 36);
            this.cbIsAvailable.Visible = false;
            this.cbIsAvailable.SelectedIndexChanged += new System.EventHandler(this.cbIsAvailable_SelectedIndexChanged);
            // 
            // lblEmptyState
            // 
            this.lblEmptyState.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEmptyState.AutoSize = true;
            this.lblEmptyState.BackColor = System.Drawing.Color.White;
            this.lblEmptyState.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblEmptyState.ForeColor = System.Drawing.Color.Gray;
            this.lblEmptyState.Location = new System.Drawing.Point(522, 395);
            this.lblEmptyState.Name = "lblEmptyState";
            this.lblEmptyState.Size = new System.Drawing.Size(278, 21);
            this.lblEmptyState.TabIndex = 10;
            this.lblEmptyState.Text = "Không có dữ liệu phù hợp với bộ lọc.";
            this.lblEmptyState.Visible = false;
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
            this.label1.Text = "Lọc theo:";
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.BackColor = System.Drawing.Color.White;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Segoe UI Bold", 12F);
            this.lblNumberOfRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(145, 745);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(19, 21);
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
            this.label2.Text = "Số bản ghi:";
            // 
            // frmListVehicles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1366, 820);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListVehicles";
            this.Text = "Danh sách xe";
            this.Load += new System.EventHandler(this.frmListVehicles_Load);
            this.cmsEditProfile.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiclesList)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvVehiclesList;
        private Guna.UI2.WinForms.Guna2Button btnAddNewVehicle;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cbMake;
        private Guna.UI2.WinForms.Guna2ComboBox cbFuelType;
        private Guna.UI2.WinForms.Guna2ComboBox cbIsAvailable;
        private System.Windows.Forms.Label lblEmptyState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip cmsEditProfile;
        private System.Windows.Forms.ToolStripMenuItem showVehicleDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem editVehicleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteVehicleToolStripMenuItem;
    }
}