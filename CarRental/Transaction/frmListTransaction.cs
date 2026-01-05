using CarRental.Booking;
using CarRental.Customers;
using CarRental.Return;
using CarRental.Vehicles;
using CarRental_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Transaction
{
    public partial class frmListTransaction : Form
    {
        private DataTable _dtAllTransaction;

        private readonly Dictionary<string, string> _transactionTypeFilterMap = new Dictionary<string, string>
        {
            ["Đang chờ"] = "Pending",
            ["Đã nhận tiền"] = "Payment Received",
            ["Đã hoàn tiền"] = "Refund Issued",
            ["Chưa xử lý"] = "No Action Taken"
        };

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

                case "Mã khách hàng":
                    return "CustomerID";

                case "Tên khách hàng":
                    return "Name";

                case "Mã trả xe":
                    return "ReturnID";

                case "Loại giao dịch":
                    return "TransactionType";

                case "Ngày giao dịch":
                    return "TransactionDate";

                case "Ngày cập nhật giao dịch":
                    return "UpdatedTransactionDate";

                default:
                    return "None";
            }
        }

        private void _RefreshTransactionList()
        {
            _dtAllTransaction = clsTransaction.GetAllRentalTransaction();
            dgvTransactionList.DataSource = _dtAllTransaction;
            lblNumberOfRecords.Text = dgvTransactionList.Rows.Count.ToString();

            if (dgvTransactionList.Rows.Count > 0)
            {
                dgvTransactionList.Columns[0].HeaderText = "Mã giao dịch";
                dgvTransactionList.Columns[0].Width = 140;

                dgvTransactionList.Columns[1].HeaderText = "Tên khách hàng";
                dgvTransactionList.Columns[1].Width = 190;

                dgvTransactionList.Columns[2].HeaderText = "Mã khách hàng";
                dgvTransactionList.Columns[2].Width = 125;

                dgvTransactionList.Columns[3].HeaderText = "Mã lịch đặt";
                dgvTransactionList.Columns[3].Width = 125;

                dgvTransactionList.Columns[4].HeaderText = "Mã trả xe";
                dgvTransactionList.Columns[4].Width = 125;

                dgvTransactionList.Columns[5].HeaderText = "Tổng tiền thực tế";
                dgvTransactionList.Columns[5].Width = 210;

                dgvTransactionList.Columns[6].HeaderText = "Còn lại";
                dgvTransactionList.Columns[6].Width = 140;

                dgvTransactionList.Columns[7].HeaderText = "Số tiền hoàn";
                dgvTransactionList.Columns[7].Width = 180;

                dgvTransactionList.Columns[8].HeaderText = "Loại giao dịch";
                dgvTransactionList.Columns[8].Width = 180;

                dgvTransactionList.Columns[9].HeaderText = "Ngày giao dịch";
                dgvTransactionList.Columns[9].Width = 180;

                dgvTransactionList.Columns[10].HeaderText = "Ngày cập nhật";
                dgvTransactionList.Columns[10].Width = 230;
            }
        }

        private int _GetTransactionFromDGV()
        {
            return (int)dgvTransactionList.CurrentRow.Cells["TransactionID"].Value;
        }

        private void frmListTransaction_Load(object sender, EventArgs e)
        {
            _RefreshTransactionList();

            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "Không lọc") &&
                               (cbFilter.Text != "Ngày giao dịch") &&
                               (cbFilter.Text != "Ngày cập nhật giao dịch") &&
                               (cbFilter.Text != "Loại giao dịch");

            cbTransactionType.Visible = (cbFilter.Text == "Loại giao dịch");

            if (cbTransactionType.Visible)
            {
                cbTransactionType.SelectedIndex = 0;
            }

            string FilterName = cbFilter.Text;

            if (FilterName == "Ngày giao dịch" || FilterName == "Ngày cập nhật giao dịch")
            {
                // refresh
                _dtAllTransaction.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvTransactionList.Rows.Count.ToString();

                FilterName = _GetRealColumnNameInDB();
                dtpDate.Visible = true;

                if (dgvTransactionList.Rows.Count > 0)
                {
                    dtpDate.Value = (DateTime)dgvTransactionList.CurrentRow.Cells[FilterName].Value;
                }
                else
                {
                    dtpDate.Value = DateTime.Now;
                }
            }
            else
            {
                dtpDate.Visible = false;
            }

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
                _dtAllTransaction.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvTransactionList.Rows.Count.ToString();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllTransaction.Rows.Count == 0)
            {
                return;
            }

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) || cbFilter.Text == "Không lọc")
            {
                _dtAllTransaction.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvTransactionList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text != "Tên khách hàng" &&
                cbFilter.Text != "Ngày giao dịch" &&
                cbFilter.Text != "Ngày cập nhật giao dịch")
            {
                // search with numbers
                _dtAllTransaction.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtAllTransaction.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvTransactionList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text != "Tên khách hàng" &&
                cbFilter.Text != "Ngày giao dịch" &&
                cbFilter.Text != "Ngày cập nhật giao dịch")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (_dtAllTransaction.Rows.Count == 0)
            {
                return;
            }

            if (cbFilter.Text == "Ngày giao dịch")
            {
                _dtAllTransaction.DefaultView.RowFilter =
                        string.Format("[{0}] = #{1}#", "TransactionDate", dtpDate.Value.ToString("yyyy-MM-dd")); // Including # around a date value is a way to inform the DataView that the value being compared is a date
            }
            else
            {
                _dtAllTransaction.DefaultView.RowFilter =
                        string.Format("[{0}] = #{1}#", "UpdatedTransactionDate", dtpDate.Value.ToString("yyyy-MM-dd"));
            }


            lblNumberOfRecords.Text = dgvTransactionList.Rows.Count.ToString();
        }

        private void ShowTransactionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowTransactionDetailsWithBookingAndReturn ShowTransactionDetails = new frmShowTransactionDetailsWithBookingAndReturn(_GetTransactionFromDGV());
            ShowTransactionDetails.ShowDialog();

            _RefreshTransactionList();
            txtSearch.Clear();
        }

        private void ShowCustomerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowCustomerDetails ShowCustomerDetails = new frmShowCustomerDetails((int)dgvTransactionList.CurrentRow.Cells["CustomerID"].Value);
            ShowCustomerDetails.ShowDialog();

            _RefreshTransactionList();
        }

        private void ShowVehicleDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsTransaction Transaction = clsTransaction.FindByTransactionID(_GetTransactionFromDGV());

            frmShowVehicleDetails ShowVehicleDetails = new frmShowVehicleDetails(Transaction?.VehicleID);
            ShowVehicleDetails.ShowDialog();

            _RefreshTransactionList();
        }

        private void ShowBookingDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowBookingDetailsWithCustomerAndVehicle ShowBookingDetails = new frmShowBookingDetailsWithCustomerAndVehicle((int)dgvTransactionList.CurrentRow.Cells["BookingID"].Value);
            ShowBookingDetails.ShowDialog();

            _RefreshTransactionList();
        }

        private void ShowReturnDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowReturnDetailsWithCustomerAndVehicle ShowReturnDetails = new frmShowReturnDetailsWithCustomerAndVehicle((int)dgvTransactionList.CurrentRow.Cells["ReturnID"].Value);
            ShowReturnDetails.ShowDialog();

            _RefreshTransactionList();
        }

        private void dgvTransactionList_DoubleClick(object sender, EventArgs e)
        {
            frmShowTransactionDetailsWithBookingAndReturn ShowTransactionDetails = new frmShowTransactionDetailsWithBookingAndReturn(_GetTransactionFromDGV());
            ShowTransactionDetails.ShowDialog();

            _RefreshTransactionList();
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            if (dgvTransactionList.Rows.Count == 0)
            {
                return;
            }

            ShowReturnDetailsToolStripMenuItem.Enabled = (dgvTransactionList.CurrentRow.Cells["ReturnID"].Value != DBNull.Value);

            #region Manage Total Remaining
            if (dgvTransactionList.CurrentRow.Cells["TotalRemaining"].Value == DBNull.Value)
            {
                TakeOrPayRefundToolStripMenuItem.Enabled = false;
                return;
            }

            float? TotalRemaining = Convert.ToSingle(dgvTransactionList.CurrentRow.Cells["TotalRemaining"].Value);

            if (!TotalRemaining.HasValue)
            {
                TakeOrPayRefundToolStripMenuItem.Enabled = false;
                return;
            }

            if (TotalRemaining == 0)
            {
                TakeOrPayRefundToolStripMenuItem.Enabled = false;
                return;
            }

            TakeOrPayRefundToolStripMenuItem.Enabled = true;

            TakeOrPayRefundToolStripMenuItem.Text = (TotalRemaining > 0)
                ? "   Hoàn tiền"
                : "   Thu thêm tiền";
            #endregion
        }

        private void cbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllTransaction.Rows.Count == 0)
            {
                return;
            }

            if (cbTransactionType.Text == "Tất cả")
            {
                _dtAllTransaction.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvTransactionList.Rows.Count.ToString();

                return;
            }

            if (_transactionTypeFilterMap.TryGetValue(cbTransactionType.Text, out string typeValue))
            {
                _dtAllTransaction.DefaultView.RowFilter =
                    string.Format("[{0}] like '{1}%'", "TransactionType", typeValue);
            }
            else
            {
                _dtAllTransaction.DefaultView.RowFilter = "";
            }

            lblNumberOfRecords.Text = dgvTransactionList.Rows.Count.ToString();
        }

        private void TakeOrPayRefundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float? TotalRemaining = Convert.ToSingle(dgvTransactionList.CurrentRow.Cells["TotalRemaining"].Value);

            if (clsTransaction.UpdateTotalRefundedAmount(_GetTransactionFromDGV(), TotalRemaining))
            {
                MessageBox.Show("Xử lý giao dịch thành công", "Xác nhận",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _RefreshTransactionList();
            }
            else
            {
                MessageBox.Show("Xử lý giao dịch thất bại", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
