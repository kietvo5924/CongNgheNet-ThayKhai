using CarRental_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace CarRental.Transaction
{
    public partial class frmListTransaction : Form
    {
        private DataTable _dtAllTransactions;

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
            // SỬA LỖI CS0117 TẠI ĐÂY: Gọi đúng tên hàm trong Business Layer
            _dtAllTransactions = clsTransaction.GetAllRentalTransaction();
            dgvTransactionsList.DataSource = _dtAllTransactions;

            lblNumberOfRecords.Text = dgvTransactionsList.Rows.Count.ToString();

            if (dgvTransactionsList.Rows.Count > 0)
            {
                // Set headers by column name to be safe against order changes
                if (dgvTransactionsList.Columns.Contains("TransactionID")) dgvTransactionsList.Columns["TransactionID"].HeaderText = "Mã GD";
                if (dgvTransactionsList.Columns.Contains("BookingID")) dgvTransactionsList.Columns["BookingID"].HeaderText = "Mã đặt xe";
                if (dgvTransactionsList.Columns.Contains("Name")) dgvTransactionsList.Columns["Name"].HeaderText = "Khách hàng";
                if (dgvTransactionsList.Columns.Contains("Amount")) dgvTransactionsList.Columns["Amount"].HeaderText = "Số tiền"; // Check actual name
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

                // Map other columns
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

        private int _GetTransactionIDFromDGV()
        {
            return (int)dgvTransactionsList.CurrentRow.Cells["TransactionID"].Value;
        }

        private void frmListTransaction_Load(object sender, EventArgs e)
        {
            _RefreshTransactionsList();
            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "Không lọc");

            if (txtSearch.Visible)
            {
                txtSearch.Clear();
                txtSearch.Focus();
            }

            if (_dtAllTransactions != null)
                _dtAllTransactions.DefaultView.RowFilter = "";

            lblNumberOfRecords.Text = dgvTransactionsList.Rows.Count.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllTransactions == null || _dtAllTransactions.Rows.Count == 0)
                return;

            string ColumnName = _GetRealColumnNameInDB();
            string FilterValue = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(FilterValue) || cbFilter.Text == "Không lọc")
            {
                _dtAllTransactions.DefaultView.RowFilter = "";
            }
            else
            {
                if (cbFilter.Text == "Mã giao dịch" || cbFilter.Text == "Mã lịch đặt")
                {
                    // Lọc cho kiểu số
                    _dtAllTransactions.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, FilterValue);
                }
                else
                {
                    // Lọc cho kiểu chuỗi
                    _dtAllTransactions.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, FilterValue);
                }
            }

            lblNumberOfRecords.Text = dgvTransactionsList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Mã giao dịch" || cbFilter.Text == "Mã lịch đặt")
            {
                // Chỉ cho phép nhập số nếu đang lọc theo ID
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void showTransactionDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở form chi tiết giao dịch
            frmShowTransactionDetailsWithBookingAndReturn frm = new frmShowTransactionDetailsWithBookingAndReturn(_GetTransactionIDFromDGV());
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