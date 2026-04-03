using CarRental.Booking;
using CarRental.Customers;
using CarRental.GlobalClasses;
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
        private const string ExportMenuItemName = "miExportReturnsData";
        private Label _lblKpiReturn;

        private static string _EscapeRowFilterValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return value.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]");
        }

        private void _UpdateRecordsCount()
        {
            lblNumberOfRecords.Text = (_dtAllReturn == null) ? "0" : _dtAllReturn.DefaultView.Count.ToString();
            _UpdateEmptyState();
        }

        private void _UpdateEmptyState()
        {
            if (lblEmptyState == null)
                return;

            bool hasData = _dtAllReturn != null && _dtAllReturn.DefaultView.Count > 0;
            lblEmptyState.Visible = !hasData;

            if (!hasData)
                lblEmptyState.BringToFront();
        }

        private bool _TryGetSelectedReturnID(out int returnID)
        {
            returnID = -1;

            if (dgvReturnList.CurrentRow == null || dgvReturnList.CurrentRow.Cells["ReturenID"] == null)
                return false;

            object value = dgvReturnList.CurrentRow.Cells["ReturenID"].Value;
            return value != null && int.TryParse(value.ToString(), out returnID);
        }

        private bool _TryGetSelectedCellIntValue(string columnName, out int value)
        {
            value = -1;

            if (dgvReturnList.CurrentRow == null || !dgvReturnList.Columns.Contains(columnName))
                return false;

            object cellValue = dgvReturnList.CurrentRow.Cells[columnName].Value;
            return cellValue != null && int.TryParse(cellValue.ToString(), out value);
        }

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
            _UpdateRecordsCount();
            _UpdateKpiMini();

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

        private void frmListReturn_Load(object sender, EventArgs e)
        {
            cmsEditProfile.Opening += cmsEditProfile_Opening;
            dgvReturnList.CellMouseDown += dgvReturnList_CellMouseDown;
            _EnsureExportMenuItem();
            _EnsureKpiLabel();

            _RefreshReturnList();
            cbFilter.SelectedIndex = 0;
        }

        private void _EnsureKpiLabel()
        {
            if (_lblKpiReturn != null)
                return;

            _lblKpiReturn = new Label
            {
                AutoSize = false,
                Name = "lblKpiReturn",
                BackColor = Color.White,
                ForeColor = Color.FromArgb(30, 64, 175),
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                Location = new Point(20, 88),
                Size = new Size(700, 20)
            };

            guna2Panel1.Controls.Add(_lblKpiReturn);
            _lblKpiReturn.BringToFront();

            dgvReturnList.Location = new Point(dgvReturnList.Location.X, 110);
            dgvReturnList.Size = new Size(dgvReturnList.Size.Width, 615);
        }

        private void _UpdateKpiMini()
        {
            if (_lblKpiReturn == null || _dtAllReturn == null)
                return;

            if (!_dtAllReturn.Columns.Contains("ActualReturnDate") || !_dtAllReturn.Columns.Contains("AdditionalCharges"))
            {
                _lblKpiReturn.Text = "KPI: Không đủ dữ liệu để tính phụ phí hôm nay.";
                return;
            }

            DateTime today = DateTime.Today;
            decimal surchargeToday = 0m;

            foreach (DataRow row in _dtAllReturn.Rows)
            {
                if (!(row["ActualReturnDate"] is DateTime returnDate) || returnDate.Date != today)
                    continue;

                if (decimal.TryParse(row["AdditionalCharges"]?.ToString(), out decimal surcharge))
                    surchargeToday += surcharge;
            }

            _lblKpiReturn.Text = $"KPI: Tổng phụ phí hôm nay = {surchargeToday:N0} VNĐ";
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
            exportItem.Click += (s, e) => clsUtil.ExportDataGridView(dgvReturnList, "DanhSachTraXe", "Danh sách trả xe");
            cmsEditProfile.Items.Add(exportItem);
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = !_TryGetSelectedReturnID(out _);
        }

        private void dgvReturnList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.Button == MouseButtons.Right)
            {
                dgvReturnList.ClearSelection();
                dgvReturnList.Rows[e.RowIndex].Selected = true;
                dgvReturnList.CurrentCell = dgvReturnList.Rows[e.RowIndex].Cells[0];
            }
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
                if (_dtAllReturn != null)
                    _dtAllReturn.DefaultView.RowFilter = "";
            }

            if (dtpActualReturnDate.Visible)
                dtpDate_ValueChanged(dtpActualReturnDate, EventArgs.Empty);

            _UpdateRecordsCount();
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
                _UpdateRecordsCount();
                return;
            }

            if (cbFilter.Text != "Ngày trả thực tế" &&
                cbFilter.Text != "Tên khách hàng")
            {
                if (int.TryParse(txtSearch.Text.Trim(), out int id))
                    _dtAllReturn.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, id);
                else
                    _dtAllReturn.DefaultView.RowFilter = "1 = 0";
            }
            else
                _dtAllReturn.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, _EscapeRowFilterValue(txtSearch.Text.Trim()));

            _UpdateRecordsCount();
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
                    string.Format("CONVERT([{0}], 'System.DateTime') >= #{1}# AND CONVERT([{0}], 'System.DateTime') < #{2}#",
                    "ActualReturnDate",
                    dtpActualReturnDate.Value.Date.ToString("MM/dd/yyyy"),
                    dtpActualReturnDate.Value.Date.AddDays(1).ToString("MM/dd/yyyy"));

            _UpdateRecordsCount();
        }

        private void btnAddNewReturn_Click(object sender, EventArgs e)
        {
            frmReturnVehicle ReturnVehicle = new frmReturnVehicle();
            ReturnVehicle.ShowDialog();
            _RefreshReturnList();
        }

        private void ShowReturnDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_TryGetSelectedReturnID(out int returnID))
            {
                MessageBox.Show("Vui lòng chọn phiếu trả xe cần xem.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmShowReturnDetailsWithCustomerAndVehicle ShowReturnDetails = new frmShowReturnDetailsWithCustomerAndVehicle(returnID);
            ShowReturnDetails.ShowDialog();

            _RefreshReturnList();
            txtSearch.Clear();
        }

        private void ShowBookingDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!_TryGetSelectedCellIntValue("BookingID", out int bookingID))
            {
                MessageBox.Show("Không xác định được lịch đặt của phiếu trả xe này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmShowBookingDetailsWithCustomerAndVehicle ShowBookingDetails = new frmShowBookingDetailsWithCustomerAndVehicle(bookingID);
            ShowBookingDetails.ShowDialog();

            _RefreshReturnList();
        }

        private void ShowCustomerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_TryGetSelectedCellIntValue("CustomerID", out int customerID))
            {
                MessageBox.Show("Không xác định được khách hàng của phiếu trả xe này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmShowCustomerDetails ShowCustomerDetails = new frmShowCustomerDetails(customerID);
            ShowCustomerDetails.ShowDialog();

            _RefreshReturnList();
        }

        private void ShowVehicleDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_TryGetSelectedCellIntValue("VehicleID", out int vehicleID))
            {
                MessageBox.Show("Không xác định được xe của phiếu trả xe này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmShowVehicleDetails ShowVehicleDetails = new frmShowVehicleDetails(vehicleID);
            ShowVehicleDetails.ShowDialog();

            _RefreshReturnList();
        }

        private void dgvReturnList_DoubleClick(object sender, EventArgs e)
        {
            if (dgvReturnList.Rows.Count > 0)
                ShowReturnDetailsToolStripMenuItem.PerformClick();
        }
    }
}