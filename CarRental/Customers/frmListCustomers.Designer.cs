namespace CarRental.Customers
{
    partial class frmListCustomers
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
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAddNewCustomer = new Guna.UI2.WinForms.Guna2Button();
            this.dgvCustomersList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsEditProfile.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomersList)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsEditProfile (Menu chuột phải)
            // 
            this.cmsEditProfile.BackColor = System.Drawing.Color.White;
            this.cmsEditProfile.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmsEditProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.editCustomerToolStripMenuItem,
            this.deleteCustomerToolStripMenuItem});
            this.cmsEditProfile.Name = "cmsEditProfile";
            this.cmsEditProfile.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.cmsEditProfile.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.cmsEditProfile.Size = new System.Drawing.Size(183, 82);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.showDetailsToolStripMenuItem.Text = "Xem chi tiết";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // editCustomerToolStripMenuItem
            // 
            this.editCustomerToolStripMenuItem.Name = "editCustomerToolStripMenuItem";
            this.editCustomerToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.editCustomerToolStripMenuItem.Text = "Chỉnh sửa";
            this.editCustomerToolStripMenuItem.Click += new System.EventHandler(this.editCustomerToolStripMenuItem_Click);
            // 
            // deleteCustomerToolStripMenuItem
            // 
            this.deleteCustomerToolStripMenuItem.Name = "deleteCustomerToolStripMenuItem";
            this.deleteCustomerToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.deleteCustomerToolStripMenuItem.Text = "Xóa khách hàng";
            this.deleteCustomerToolStripMenuItem.Click += new System.EventHandler(this.deleteCustomerToolStripMenuItem_Click);
            // 
            // guna2Panel1 (Card chính)
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.Controls.Add(this.btnAddNewCustomer);
            this.guna2Panel1.Controls.Add(this.dgvCustomersList);
            this.guna2Panel1.Controls.Add(this.txtSearch);
            this.guna2Panel1.Controls.Add(this.cbFilter);
            this.guna2Panel1.Controls.Add(this.lblNumberOfRecords);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(20, 20);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1326, 780);
            this.guna2Panel1.TabIndex = 0;
            // 
            // btnAddNewCustomer (Nút thêm mới)
            // 
            this.btnAddNewCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewCustomer.BorderRadius = 8;
            this.btnAddNewCustomer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnAddNewCustomer.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddNewCustomer.ForeColor = System.Drawing.Color.White;
            this.btnAddNewCustomer.Location = new System.Drawing.Point(1135, 25);
            this.btnAddNewCustomer.Name = "btnAddNewCustomer";
            this.btnAddNewCustomer.Size = new System.Drawing.Size(165, 40);
            this.btnAddNewCustomer.Text = "Thêm khách";
            this.btnAddNewCustomer.Click += new System.EventHandler(this.btnAddNewCustomer_Click);
            // 
            // dgvCustomersList
            // 
            this.dgvCustomersList.AllowUserToAddRows = false;
            this.dgvCustomersList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvCustomersList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomersList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCustomersList.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomersList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray;
            this.dgvCustomersList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCustomersList.ColumnHeadersHeight = 45;
            this.dgvCustomersList.ContextMenuStrip = this.cmsEditProfile;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCustomersList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCustomersList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvCustomersList.Location = new System.Drawing.Point(20, 85);
            this.dgvCustomersList.Name = "dgvCustomersList";
            this.dgvCustomersList.ReadOnly = true;
            this.dgvCustomersList.RowHeadersVisible = false;
            this.dgvCustomersList.RowHeadersWidth = 4;
            this.dgvCustomersList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCustomersList.RowTemplate.Height = 40;
            this.dgvCustomersList.Size = new System.Drawing.Size(1280, 640);
            this.dgvCustomersList.DoubleClick += new System.EventHandler(this.dgvCustomersList_DoubleClick);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(305, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tìm kiếm khách hàng...";
            this.txtSearch.Size = new System.Drawing.Size(280, 36);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
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
            "Mã khách hàng",
            "Họ tên",
            "Số điện thoại",
            "Số bằng lái"});
            this.cbFilter.Location = new System.Drawing.Point(110, 25);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(180, 36);
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
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
            // frmListCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1366, 820);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListCustomers";
            this.Text = "Quản lý khách hàng";
            this.Load += new System.EventHandler(this.frmListCustomers_Load);
            this.cmsEditProfile.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomersList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCustomersList;
        private Guna.UI2.WinForms.Guna2Button btnAddNewCustomer;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip cmsEditProfile;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem editCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCustomerToolStripMenuItem;
    }
}