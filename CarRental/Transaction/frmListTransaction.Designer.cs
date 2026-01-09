namespace CarRental.Transaction
{
    partial class frmListTransaction
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
            this.showTransactionDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvTransactionsList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsEditProfile.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionsList)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsEditProfile (Menu chuột phải hiện đại)
            // 
            this.cmsEditProfile.BackColor = System.Drawing.Color.White;
            this.cmsEditProfile.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmsEditProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showTransactionDetailsToolStripMenuItem});
            this.cmsEditProfile.Name = "cmsEditProfile";
            this.cmsEditProfile.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.cmsEditProfile.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.cmsEditProfile.Size = new System.Drawing.Size(188, 28);
            // 
            // showTransactionDetailsToolStripMenuItem
            // 
            this.showTransactionDetailsToolStripMenuItem.Name = "showTransactionDetailsToolStripMenuItem";
            this.showTransactionDetailsToolStripMenuItem.Size = new System.Drawing.Size(187, 24);
            this.showTransactionDetailsToolStripMenuItem.Text = "Xem chi tiết";
            this.showTransactionDetailsToolStripMenuItem.Click += new System.EventHandler(this.showTransactionDetailsToolStripMenuItem_Click);
            // 
            // guna2Panel1 (KHUNG THẺ TRẮNG CHÍNH)
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.Controls.Add(this.dgvTransactionsList);
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
            // dgvTransactionsList (Bảng dữ liệu phẳng hiện đại)
            // 
            this.dgvTransactionsList.AllowUserToAddRows = false;
            this.dgvTransactionsList.AllowUserToDeleteRows = false;
            this.dgvTransactionsList.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvTransactionsList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTransactionsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransactionsList.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransactionsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransactionsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTransactionsList.ColumnHeadersHeight = 45;
            this.dgvTransactionsList.ContextMenuStrip = this.cmsEditProfile;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransactionsList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTransactionsList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvTransactionsList.Location = new System.Drawing.Point(20, 85);
            this.dgvTransactionsList.Name = "dgvTransactionsList";
            this.dgvTransactionsList.ReadOnly = true;
            this.dgvTransactionsList.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvTransactionsList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTransactionsList.RowTemplate.Height = 40;
            this.dgvTransactionsList.Size = new System.Drawing.Size(1280, 640);
            this.dgvTransactionsList.TabIndex = 194;
            this.dgvTransactionsList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.dgvTransactionsList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvTransactionsList.DoubleClick += new System.EventHandler(this.dgvTransactionsList_DoubleClick);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(305, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tìm kiếm giao dịch...";
            this.txtSearch.Size = new System.Drawing.Size(280, 36);
            this.txtSearch.TabIndex = 173;
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
            "Mã giao dịch",
            "Mã lịch đặt",
            "Họ tên",
            "Ngày thanh toán"});
            this.cbFilter.Location = new System.Drawing.Point(110, 25);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(180, 36);
            this.cbFilter.TabIndex = 174;
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
            // frmListTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1366, 820);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListTransaction";
            this.Tag = "GIAO DỊCH";
            this.Text = "Danh sách giao dịch";
            this.Load += new System.EventHandler(this.frmListTransaction_Load);
            this.cmsEditProfile.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionsList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTransactionsList;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip cmsEditProfile;
        private System.Windows.Forms.ToolStripMenuItem showTransactionDetailsToolStripMenuItem;
    }
}