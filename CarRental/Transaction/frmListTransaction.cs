using CarRental_Business;
using CarRental_Business;
using CarRental.GlobalClasses;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace CarRental.Transaction
{
    public partial class frmListTransaction : Form
    {
        private DataTable _dtAllTransactions;
        private const string ExportMenuItemName = "miExportTransactionsData";
        private Label _lblKpiTransaction;

        private static string _LocalizeTransactionType(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            string normalized = value.Trim().ToLowerInvariant().Replace(" ", string.Empty).Replace("_", string.Empty);
            switch (normalized)
            {
                case "pending": return "Đang chờ";
                case "paymentreceived": return "Đã nhận tiền";
                case "refundissued": return "Đã hoàn tiền";
                case "noactiontaken": return "Không xử lý";
                default: return value;
            }
        }

        private static string _EscapeRowFilterValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return value.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]");
        }

        private void _UpdateRecordsCount()
        {
            lblNumberOfRecords.Text = (_dtAllTransactions == null) ? "0" : _dtAllTransactions.DefaultView.Count.ToString();
            _UpdateEmptyState();
        }

        private void _UpdateEmptyState()
        {
            if (lblEmptyState == null)
                return;

            bool hasData = _dtAllTransactions != null && _dtAllTransactions.DefaultView.Count > 0;
            lblEmptyState.Visible = !hasData;

            if (!hasData)
                lblEmptyState.BringToFront();
        }

        private bool _TryGetSelectedTransactionID(out int transactionID)
        {
            transactionID = -1;

            if (dgvTransactionsList.CurrentRow == null || dgvTransactionsList.CurrentRow.Cells["TransactionID"] == null)
                return false;

            object value = dgvTransactionsList.CurrentRow.Cells["TransactionID"].Value;
            return value != null && int.TryParse(value.ToString(), out transactionID);
        }

        public frmListTransaction()
        {
            InitializeComponent();
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Mã giao dịch":
                    return "TransactionID";

                case "Mã lịch đặt":
                    return "BookingID";

                case "Họ tên":
                    return "Name";

                case "Ngày thanh toán":
                    return "TransactionDate";

                default:
                    return "None";
            }
        }

        private void _RefreshTransactionsList()
        {
            _dtAllTransactions = clsTransaction.GetAllRentalTransaction();
            dgvTransactionsList.DataSource = _dtAllTransactions;

            _UpdateRecordsCount();
            _UpdateKpiMini();

            if (dgvTransactionsList.Rows.Count > 0)
            {
                if (dgvTransactionsList.Columns.Contains("TransactionID")) dgvTransactionsList.Columns["TransactionID"].HeaderText = "Mã GD";
                if (dgvTransactionsList.Columns.Contains("BookingID")) dgvTransactionsList.Columns["BookingID"].HeaderText = "Mã đặt xe";
                if (dgvTransactionsList.Columns.Contains("Name")) dgvTransactionsList.Columns["Name"].HeaderText = "Khách hàng";
                if (dgvTransactionsList.Columns.Contains("Amount")) dgvTransactionsList.Columns["Amount"].HeaderText = "Số tiền";
                if (dgvTransactionsList.Columns.Contains("PaidInitialTotalDueAmount"))
                {
                    dgvTransactionsList.Columns["PaidInitialTotalDueAmount"].HeaderText = "Số tiền";
                    dgvTransactionsList.Columns["PaidInitialTotalDueAmount"].DefaultCellStyle.Format = "N0";
                }
                
                if (dgvTransactionsList.Columns.Contains("TransactionDate")) 
                {
                    dgvTransactionsList.Columns["TransactionDate"].HeaderText = "Ngày GD";
                    dgvTransactionsList.Columns["TransactionDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }

                if (dgvTransactionsList.Columns.Contains("PaymentDetails")) dgvTransactionsList.Columns["PaymentDetails"].HeaderText = "Ghi chú";

                if (dgvTransactionsList.Columns.Contains("ReturnID")) 
                    dgvTransactionsList.Columns["ReturnID"].HeaderText = "Mã trả xe";

                if (dgvTransactionsList.Columns.Contains("ActualTotalDueAmount")) 
                {
                    dgvTransactionsList.Columns["ActualTotalDueAmount"].HeaderText = "Thực tế trả";
                    dgvTransactionsList.Columns["ActualTotalDueAmount"].DefaultCellStyle.Format = "N0";
                }

                if (dgvTransactionsList.Columns.Contains("TotalRemaining")) 
                {
                    dgvTransactionsList.Columns["TotalRemaining"].HeaderText = "Còn lại";
                    dgvTransactionsList.Columns["TotalRemaining"].DefaultCellStyle.Format = "N0";
                }

                if (dgvTransactionsList.Columns.Contains("TotalRefundedAmount")) 
                {
                    dgvTransactionsList.Columns["TotalRefundedAmount"].HeaderText = "Hoàn tiền";
                    dgvTransactionsList.Columns["TotalRefundedAmount"].DefaultCellStyle.Format = "N0";
                }

                if (dgvTransactionsList.Columns.Contains("UpdatedTransactionDate")) 
                {
                    dgvTransactionsList.Columns["UpdatedTransactionDate"].HeaderText = "Ngày cập nhật";
                    dgvTransactionsList.Columns["UpdatedTransactionDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }

                if (dgvTransactionsList.Columns.Contains("TransactionTypeName")) 
                    dgvTransactionsList.Columns["TransactionTypeName"].HeaderText = "Loại GD";
                else if (dgvTransactionsList.Columns.Contains("TransactionType")) 
                    dgvTransactionsList.Columns["TransactionType"].HeaderText = "Loại GD";
                
                dgvTransactionsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void frmListTransaction_Load(object sender, EventArgs e)
        {
            cmsEditProfile.Opening += cmsEditProfile_Opening;
            dgvTransactionsList.CellMouseDown += dgvTransactionsList_CellMouseDown;
            dgvTransactionsList.CellFormatting += dgvTransactionsList_CellFormatting;
            _EnsureExportMenuItem();
            _EnsureKpiLabel();

            _RefreshTransactionsList();
            cbFilter.SelectedIndex = 0;
        }

        private void dgvTransactionsList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.Value == null)
                return;

            string columnName = dgvTransactionsList.Columns[e.ColumnIndex].Name;
            if (!columnName.Equals("TransactionTypeName", StringComparison.OrdinalIgnoreCase)
                && !columnName.Equals("TransactionType", StringComparison.OrdinalIgnoreCase))
                return;

            e.Value = _LocalizeTransactionType(e.Value.ToString());
            e.FormattingApplied = true;
        }

        private void _EnsureKpiLabel()
        {
            if (_lblKpiTransaction != null)
                return;

            _lblKpiTransaction = new Label
            {
                AutoSize = false,
                Name = "lblKpiTransaction",
                BackColor = Color.White,
                ForeColor = Color.FromArgb(30, 64, 175),
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                Location = new Point(20, 88),
                Size = new Size(900, 20)
            };

            guna2Panel1.Controls.Add(_lblKpiTransaction);
            _lblKpiTransaction.BringToFront();

            dgvTransactionsList.Location = new Point(dgvTransactionsList.Location.X, 110);
            dgvTransactionsList.Size = new Size(dgvTransactionsList.Size.Width, 615);
        }

        private void _UpdateKpiMini()
        {
            if (_lblKpiTransaction == null || _dtAllTransactions == null)
                return;

            string amountColumn = _dtAllTransactions.Columns.Contains("PaidInitialTotalDueAmount")
                ? "PaidInitialTotalDueAmount"
                : _dtAllTransactions.Columns.Contains("Amount")
                    ? "Amount"
                    : null;

            if (amountColumn == null || !_dtAllTransactions.Columns.Contains("TransactionDate"))
            {
                _lblKpiTransaction.Text = "KPI: Không đủ dữ liệu để tính doanh thu hôm nay/tháng.";
                return;
            }

            DateTime today = DateTime.Today;
            DateTime monthStart = new DateTime(today.Year, today.Month, 1);

            decimal totalToday = 0m;
            decimal totalMonth = 0m;

            foreach (DataRow row in _dtAllTransactions.Rows)
            {
                if (!(row["TransactionDate"] is DateTime transactionDate))
                    continue;

                if (!decimal.TryParse(Convert.ToString(row[amountColumn], CultureInfo.InvariantCulture), out decimal amount))
                    continue;

                if (transactionDate.Date == today)
                    totalToday += amount;

                if (transactionDate.Date >= monthStart && transactionDate.Date <= today)
                    totalMonth += amount;
            }

            _lblKpiTransaction.Text = $"KPI: Tổng thu hôm nay = {totalToday:N0} VNĐ | Tổng thu tháng này = {totalMonth:N0} VNĐ";
        }

        private void _EnsureExportMenuItem()
        {
            if (cmsEditProfile.Items[ExportMenuItemName] != null)
                return;

            cmsEditProfile.Items.Add(new ToolStripSeparator());
            ToolStripMenuItem exportItem = new ToolStripMenuItem("Xuất dữ liệu (CSV/Excel/PDF)")
            {
                Name = ExportMenuItemName
            };
            exportItem.Click += (s, e) => clsUtil.ExportDataGridView(dgvTransactionsList, "DanhSachGiaoDich", "Danh sách giao dịch");
            cmsEditProfile.Items.Add(exportItem);
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = !_TryGetSelectedTransactionID(out _);
        }

        private void dgvTransactionsList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.Button == MouseButtons.Right)
            {
                dgvTransactionsList.ClearSelection();
                dgvTransactionsList.Rows[e.RowIndex].Selected = true;
                dgvTransactionsList.CurrentCell = dgvTransactionsList.Rows[e.RowIndex].Cells[0];
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isNoneFilter = cbFilter.Text == "Không lọc";
            bool isDateFilter = cbFilter.Text == "Ngày thanh toán";

            txtSearch.Visible = !isNoneFilter && !isDateFilter;
            dtpTransactionDate.Visible = isDateFilter;

            if (txtSearch.Visible)
            {
                txtSearch.Clear();
                txtSearch.Focus();
            }

            if (dtpTransactionDate.Visible)
                dtpTransactionDate.Value = DateTime.Now;

            if (_dtAllTransactions != null)
                _dtAllTransactions.DefaultView.RowFilter = "";

            _UpdateRecordsCount();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllTransactions == null || _dtAllTransactions.Rows.Count == 0)
                return;

            string ColumnName = _GetRealColumnNameInDB();
            string FilterValue = txtSearch.Text.Trim();

            if (cbFilter.Text == "Ngày thanh toán")
            {
                _dtAllTransactions.DefaultView.RowFilter = string.Format("CONVERT([{0}], 'System.DateTime') >= #{1}# AND CONVERT([{0}], 'System.DateTime') < #{2}#",
                    ColumnName,
                    dtpTransactionDate.Value.Date.ToString("MM/dd/yyyy"),
                    dtpTransactionDate.Value.Date.AddDays(1).ToString("MM/dd/yyyy"));
            }
            else if (string.IsNullOrWhiteSpace(FilterValue) || cbFilter.Text == "Không lọc")
            {
                _dtAllTransactions.DefaultView.RowFilter = "";
            }
            else
            {
                if (cbFilter.Text == "Mã giao dịch" || cbFilter.Text == "Mã lịch đặt")
                {
                    if (int.TryParse(FilterValue, out int idValue))
                        _dtAllTransactions.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, idValue);
                    else
                        _dtAllTransactions.DefaultView.RowFilter = "1 = 0";
                }
                else
                {
                    _dtAllTransactions.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, _EscapeRowFilterValue(FilterValue));
                }
            }

            _UpdateRecordsCount();
        }

        private void dtpTransactionDate_ValueChanged(object sender, EventArgs e)
        {
            if (_dtAllTransactions == null || _dtAllTransactions.Rows.Count == 0)
                return;

            if (cbFilter.Text != "Ngày thanh toán")
                return;

            _dtAllTransactions.DefaultView.RowFilter = string.Format("CONVERT([TransactionDate], 'System.DateTime') >= #{0}# AND CONVERT([TransactionDate], 'System.DateTime') < #{1}#",
                dtpTransactionDate.Value.Date.ToString("MM/dd/yyyy"),
                dtpTransactionDate.Value.Date.AddDays(1).ToString("MM/dd/yyyy"));

            _UpdateRecordsCount();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Mã giao dịch" || cbFilter.Text == "Mã lịch đặt")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void showTransactionDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_TryGetSelectedTransactionID(out int transactionID))
            {
                MessageBox.Show("Vui lòng chọn giao dịch cần xem.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmShowTransactionDetailsWithBookingAndReturn frm = new frmShowTransactionDetailsWithBookingAndReturn(transactionID);
            frm.ShowDialog();

            _RefreshTransactionsList();
        }

        private void dgvTransactionsList_DoubleClick(object sender, EventArgs e)
        {
            if (dgvTransactionsList.Rows.Count > 0)
            {
                showTransactionDetailsToolStripMenuItem.PerformClick();
            }
        }
    }
}