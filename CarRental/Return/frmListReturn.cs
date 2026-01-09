using CarRental.Booking;
using CarRental.Customers;
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

namespace CarRental.Return
{
    public partial class frmListReturn : Form
    {
        private DataTable _dtAllReturn;

        public frmListReturn()
        {
            InitializeComponent();
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Mã trả xe":
                    return "ReturenID";

                case "Mã khách hàng":
                    return "CustomerID";

                case "Mã xe":
                    return "VehicleID";

                case "Mã lịch đặt":
                    return "BookingID";

                case "Mã giao dịch":
                    return "TransactionID";

                case "Tên khách hàng":
                    return "Name";

                case "Ngày trả thực tế":
                    return "ActualReturnDate";

                default:
                    return "None";
            }
        }

        private void _RefreshReturnList()
        {
            _dtAllReturn = clsReturn.GetAllVehicleReturns();
            dgvReturnList.DataSource = _dtAllReturn;
            lblNumberOfRecords.Text = dgvReturnList.Rows.Count.ToString();

            if (dgvReturnList.Rows.Count > 0)
            {
                dgvReturnList.Columns[0].HeaderText = "Mã trả xe";
                dgvReturnList.Columns[0].Width = 100;

                dgvReturnList.Columns[1].HeaderText = "Tên khách hàng";
                dgvReturnList.Columns[1].Width = 180;

                dgvReturnList.Columns[2].HeaderText = "Mã KH";
                dgvReturnList.Columns[2].Width = 100;

                dgvReturnList.Columns[3].HeaderText = "Mã xe";
                dgvReturnList.Columns[3].Width = 100;

                dgvReturnList.Columns[4].HeaderText = "Mã lịch đặt";
                dgvReturnList.Columns[4].Width = 120;

                dgvReturnList.Columns[5].HeaderText = "Mã giao dịch";
                dgvReturnList.Columns[5].Width = 120;

                dgvReturnList.Columns[6].HeaderText = "Ngày trả";
                dgvReturnList.Columns[6].Width = 120;
                dgvReturnList.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy";

                dgvReturnList.Columns[7].HeaderText = "Số ngày";
                dgvReturnList.Columns[7].Width = 100;

                dgvReturnList.Columns[8].HeaderText = "Phụ phí";
                dgvReturnList.Columns[8].Width = 120;
                dgvReturnList.Columns[8].DefaultCellStyle.Format = "N0";

                dgvReturnList.Columns[9].HeaderText = "Tổng tiền TT";
                dgvReturnList.Columns[9].Width = 150;
                dgvReturnList.Columns[9].DefaultCellStyle.Format = "N0";
            }
        }

        private int _GetReturnIDFromDGV()
        {
            return (int)dgvReturnList.CurrentRow.Cells["ReturenID"].Value;
        }

        private void frmListReturn_Load(object sender, EventArgs e)
        {
            _RefreshReturnList();
            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "Không lọc") &&
                                (cbFilter.Text != "Ngày trả thực tế");

            dtpActualReturnDate.Visible = (cbFilter.Text == "Ngày trả thực tế");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
                _dtAllReturn.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvReturnList.Rows.Count.ToString();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllReturn == null || _dtAllReturn.Rows.Count == 0)
            {
                return;
            }

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) || cbFilter.Text == "Không lọc")
            {
                _dtAllReturn.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvReturnList.Rows.Count.ToString();
                return;
            }

            try
            {
                if (cbFilter.Text != "Ngày trả thực tế" &&
                    cbFilter.Text != "Tên khách hàng")
                {
                    // search with numbers
                    if (int.TryParse(txtSearch.Text.Trim(), out int id))
                        _dtAllReturn.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, id);
                }
                else
                {
                    // search with string
                    _dtAllReturn.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
                }
            }
            catch (Exception)
            {
                // Bỏ qua lỗi nếu filter không hợp lệ
            }

            lblNumberOfRecords.Text = dgvReturnList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text != "Ngày trả thực tế" &&
                cbFilter.Text != "Tên khách hàng")
            {
                // Chỉ cho nhập số
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (_dtAllReturn == null || _dtAllReturn.Rows.Count == 0)
            {
                return;
            }

            _dtAllReturn.DefaultView.RowFilter =
                    string.Format("[{0}] = #{1}#", "ActualReturnDate",
                    dtpActualReturnDate.Value.ToString("yyyy-MM-dd"));

            lblNumberOfRecords.Text = dgvReturnList.Rows.Count.ToString();
        }

        private void btnAddNewReturn_Click(object sender, EventArgs e)
        {
            frmReturnVehicle ReturnVehicle = new frmReturnVehicle();
            ReturnVehicle.ShowDialog();
            _RefreshReturnList();
        }

        private void ShowReturnDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvReturnList.CurrentRow == null) return;

            frmShowReturnDetailsWithCustomerAndVehicle ShowReturnDetails = new frmShowReturnDetailsWithCustomerAndVehicle(_GetReturnIDFromDGV());
            ShowReturnDetails.ShowDialog();

            _RefreshReturnList();
            txtSearch.Clear();
        }

        private void ShowBookingDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvReturnList.CurrentRow == null) return;

            frmShowBookingDetailsWithCustomerAndVehicle ShowBookingDetails = new frmShowBookingDetailsWithCustomerAndVehicle((int)dgvReturnList.CurrentRow.Cells["BookingID"].Value);
            ShowBookingDetails.ShowDialog();

            _RefreshReturnList();
        }

        private void ShowCustomerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvReturnList.CurrentRow == null) return;

            frmShowCustomerDetails ShowCustomerDetails = new frmShowCustomerDetails((int)dgvReturnList.CurrentRow.Cells["CustomerID"].Value);
            ShowCustomerDetails.ShowDialog();

            _RefreshReturnList();
        }

        private void ShowVehicleDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvReturnList.CurrentRow == null) return;

            frmShowVehicleDetails ShowVehicleDetails = new frmShowVehicleDetails((int)dgvReturnList.CurrentRow.Cells["VehicleID"].Value);
            ShowVehicleDetails.ShowDialog();

            _RefreshReturnList();
        }

        private void dgvReturnList_DoubleClick(object sender, EventArgs e)
        {
            if (dgvReturnList.CurrentRow == null) return;

            frmShowReturnDetailsWithCustomerAndVehicle ShowReturnDetails = new frmShowReturnDetailsWithCustomerAndVehicle(_GetReturnIDFromDGV());
            ShowReturnDetails.ShowDialog();

            _RefreshReturnList();
        }
    }
}