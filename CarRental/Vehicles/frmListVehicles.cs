using CarRental.GlobalClasses;
using CarRental_Business;
using CarRental_Business;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CarRental.Vehicles
{
    public partial class frmListVehicles : Form
    {
        private DataTable _dtAllVehicles;
        private const string ExportMenuItemName = "miExportVehiclesData";

        private static string _EscapeRowFilterValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return value.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]");
        }

        private void _UpdateRecordsCount()
        {
            lblNumberOfRecords.Text = (_dtAllVehicles == null)
                ? "0"
                : _dtAllVehicles.DefaultView.Count.ToString();

            _UpdateEmptyState();
        }

        private void _UpdateEmptyState()
        {
            if (lblEmptyState == null)
                return;

            bool hasData = _dtAllVehicles != null && _dtAllVehicles.DefaultView.Count > 0;
            lblEmptyState.Visible = !hasData;

            if (!hasData)
                lblEmptyState.BringToFront();
        }

        private bool _TryGetSelectedVehicleID(out int vehicleID)
        {
            vehicleID = -1;

            if (dgvVehiclesList.CurrentRow == null || dgvVehiclesList.CurrentRow.Cells["VehicleID"] == null)
                return false;

            object value = dgvVehiclesList.CurrentRow.Cells["VehicleID"].Value;
            return value != null && int.TryParse(value.ToString(), out vehicleID);
        }

        public frmListVehicles()
        {
            InitializeComponent();
        }

        private void _FillMakeComboBox()
        {
            DataTable dtMakes = clsMake.GetAllMakes();
            cbMake.Items.Clear();
            cbMake.Items.Add("Tất cả");
            foreach (DataRow row in dtMakes.Rows)
            {
                // Bảng Makes có cột tên là "Make" (không phải "MakeName")
                cbMake.Items.Add(row["Make"].ToString());
            }
        }

        private void cancelUpcomingBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_TryGetSelectedVehicleID(out int vehicleID))
            {
                MessageBox.Show("Vui lòng chọn xe để hủy lịch đặt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dtBookings = clsBooking.GetAllRentalBooking();
            if (dtBookings == null || dtBookings.Rows.Count == 0 || !dtBookings.Columns.Contains("BookingID") || !dtBookings.Columns.Contains("VehicleID"))
            {
                MessageBox.Show("Không có dữ liệu lịch đặt để xử lý.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int? targetBookingID = dtBookings.AsEnumerable()
                .Where(r => int.TryParse(r["VehicleID"]?.ToString(), out int rowVehicleID) && rowVehicleID == vehicleID)
                .Select(r =>
                {
                    int.TryParse(r["BookingID"]?.ToString(), out int bId);
                    return clsBooking.Find(bId);
                })
                .Where(b => b != null && !b.IsBookingReturned && b.RentalStartDate.Date > DateTime.Today)
                .OrderBy(b => b.RentalStartDate)
                .Select(b => b.BookingID)
                .FirstOrDefault();

            if (!targetBookingID.HasValue)
            {
                MessageBox.Show("Xe này hiện không có lịch đặt sắp tới để hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            clsBooking booking = clsBooking.Find(targetBookingID.Value);
            if (booking == null)
            {
                MessageBox.Show("Không tìm thấy lịch đặt để hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                $"Hủy lịch đặt #{booking.BookingID} cho xe #{vehicleID} (ngày nhận: {booking.RentalStartDate:dd/MM/yyyy})?",
                "Xác nhận hủy lịch đặt",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            clsTransaction transaction = clsTransaction.FindByBookingID(booking.BookingID);
            bool cancelled = transaction != null ? transaction.DeleteTransaction() : booking.DeleteBooking();

            if (cancelled)
            {
                MessageBox.Show("Hủy lịch đặt xe thành công.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshVehiclesList();
            }
            else
                MessageBox.Show("Không thể hủy lịch đặt xe này.", "Không thể hủy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void _FillFuelTypeComboBox()
        {
            DataTable dtFuelTypes = clsFuelType.GetAllFuelTypes();
            cbFuelType.Items.Clear();
            cbFuelType.Items.Add("Tất cả");
            foreach (DataRow row in dtFuelTypes.Rows)
            {
                cbFuelType.Items.Add(row["FuelTypeName"].ToString());
            }
        }

        private string _GetRealColumnNameInDB()
        {
            // Fix lỗi Column Name để khớp với Database View thực tế
            switch (cbFilter.Text)
            {
                case "Mã xe": return "VehicleID";
                case "Tên xe": return "VehicleName";
                case "Biển số": return "PlateNumber";
                case "Hãng xe": return "Make"; 
                case "Loại nhiên liệu":
                    if (_dtAllVehicles != null)
                    {
                        if (_dtAllVehicles.Columns.Contains("FuelType")) return "FuelType";
                        if (_dtAllVehicles.Columns.Contains("FuelTypeName")) return "FuelTypeName";
                    }
                    return "FuelType";
                case "Trạng thái": return "IsAvailableForRent"; 
                default: return "None";
            }
        }

        private void _RefreshVehiclesList()
        {
            _dtAllVehicles = clsVehicle.GetAllVehicles();
            dgvVehiclesList.DataSource = _dtAllVehicles;
            _UpdateRecordsCount();

            if (dgvVehiclesList.Rows.Count > 0)
            {
                // Việt hóa tiêu đề bảng (theo tên cột trong VehiclesDetails_View)
                if (dgvVehiclesList.Columns.Contains("VehicleID"))
                    dgvVehiclesList.Columns["VehicleID"].HeaderText = "Mã xe";

                if (dgvVehiclesList.Columns.Contains("VehicleName"))
                    dgvVehiclesList.Columns["VehicleName"].HeaderText = "Tên xe";

                if (dgvVehiclesList.Columns.Contains("PlateNumber"))
                    dgvVehiclesList.Columns["PlateNumber"].HeaderText = "Biển số";

                if (dgvVehiclesList.Columns.Contains("Make"))
                    dgvVehiclesList.Columns["Make"].HeaderText = "Hãng xe";

                if (dgvVehiclesList.Columns.Contains("Model"))
                    dgvVehiclesList.Columns["Model"].HeaderText = "Dòng xe";

                if (dgvVehiclesList.Columns.Contains("FuelType"))
                    dgvVehiclesList.Columns["FuelType"].HeaderText = "Nhiên liệu";
                else if (dgvVehiclesList.Columns.Contains("FuelTypeName"))
                    dgvVehiclesList.Columns["FuelTypeName"].HeaderText = "Nhiên liệu";

                if (dgvVehiclesList.Columns.Contains("RentalPricePerDay"))
                {
                    var rentalPriceColumn = dgvVehiclesList.Columns["RentalPricePerDay"];
                    rentalPriceColumn.HeaderText = "Giá thuê/ngày";
                    rentalPriceColumn.DefaultCellStyle.Format = "N0";
                    rentalPriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (dgvVehiclesList.Columns.Contains("IsAvailableForRent"))
                    dgvVehiclesList.Columns["IsAvailableForRent"].HeaderText = "Trạng thái";

                // Một số view trả về tên cột khác; thêm fallback theo index cho các cột cuối
                if (dgvVehiclesList.Columns.Count >= 8)
                {
                    dgvVehiclesList.Columns[dgvVehiclesList.Columns.Count - 2].HeaderText = "Giá thuê/ngày";
                    dgvVehiclesList.Columns[dgvVehiclesList.Columns.Count - 2].DefaultCellStyle.Format = "N0";
                    dgvVehiclesList.Columns[dgvVehiclesList.Columns.Count - 2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvVehiclesList.Columns[dgvVehiclesList.Columns.Count - 1].HeaderText = "Trạng thái";
                }

                dgvVehiclesList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void frmListVehicles_Load(object sender, EventArgs e)
        {
            cmsEditProfile.Opening += cmsEditProfile_Opening;
            dgvVehiclesList.CellFormatting += dgvVehiclesList_CellFormatting;
            dgvVehiclesList.CellMouseDown += dgvVehiclesList_CellMouseDown;
            dgvVehiclesList.DataError += dgvVehiclesList_DataError;
            _EnsureExportMenuItem();

            _RefreshVehiclesList();
            _FillMakeComboBox();
            _FillFuelTypeComboBox();
            cbFilter.SelectedIndex = 0;
        }

        private void dgvVehiclesList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
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
            exportItem.Click += (s, e) => clsUtil.ExportDataGridView(dgvVehiclesList, "DanhSachXe", "Danh sách xe");
            cmsEditProfile.Items.Add(exportItem);
        }

        private void dgvVehiclesList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.Button == MouseButtons.Right)
            {
                dgvVehiclesList.ClearSelection();
                dgvVehiclesList.Rows[e.RowIndex].Selected = true;
                dgvVehiclesList.CurrentCell = dgvVehiclesList.Rows[e.RowIndex].Cells[0];
            }
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = !_TryGetSelectedVehicleID(out _);
        }

        private void dgvVehiclesList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvVehiclesList.Columns[e.ColumnIndex].Name != "IsAvailableForRent" || e.Value == null)
                return;

            if (dgvVehiclesList.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                return;

            if (bool.TryParse(e.Value.ToString(), out bool isAvailable))
            {
                e.Value = isAvailable ? "Sẵn sàng" : "Đang thuê";
                e.CellStyle.ForeColor = isAvailable ? Color.FromArgb(22, 163, 74) : Color.FromArgb(220, 38, 38);
                e.FormattingApplied = true;
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "Không lọc") && (cbFilter.Text != "Hãng xe") 
                                && (cbFilter.Text != "Loại nhiên liệu") && (cbFilter.Text != "Trạng thái");
            cbMake.Visible = (cbFilter.Text == "Hãng xe");
            cbFuelType.Visible = (cbFilter.Text == "Loại nhiên liệu");
            cbIsAvailable.Visible = (cbFilter.Text == "Trạng thái");

            if (txtSearch.Visible) { txtSearch.Clear(); txtSearch.Focus(); }
            if (cbMake.Visible) cbMake.SelectedIndex = 0;
            if (cbFuelType.Visible) cbFuelType.SelectedIndex = 0;
            if (cbIsAvailable.Visible) cbIsAvailable.SelectedIndex = 0;

            if (_dtAllVehicles != null) _dtAllVehicles.DefaultView.RowFilter = "";
            _UpdateRecordsCount();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllVehicles == null || _dtAllVehicles.Rows.Count == 0) return;
            string ColumnName = _GetRealColumnNameInDB();
            string FilterValue = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(FilterValue) || cbFilter.Text == "Không lọc")
                _dtAllVehicles.DefaultView.RowFilter = "";
            else
            {
                if (cbFilter.Text == "Mã xe")
                {
                    if (int.TryParse(FilterValue, out int vehicleID))
                        _dtAllVehicles.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, vehicleID);
                    else
                        _dtAllVehicles.DefaultView.RowFilter = "1 = 0";
                }
                else
                    _dtAllVehicles.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, _EscapeRowFilterValue(FilterValue));
            }
            _UpdateRecordsCount();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Mã xe")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllVehicles == null) return;
            if (cbMake.Text == "Tất cả") _dtAllVehicles.DefaultView.RowFilter = "";
            else _dtAllVehicles.DefaultView.RowFilter = string.Format("[Make] = '{0}'", _EscapeRowFilterValue(cbMake.Text));
            _UpdateRecordsCount();
        }

        private void cbFuelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllVehicles == null) return;

            string fuelColumn = _dtAllVehicles.Columns.Contains("FuelType") ? "FuelType"
                : _dtAllVehicles.Columns.Contains("FuelTypeName") ? "FuelTypeName"
                : null;

            if (string.IsNullOrEmpty(fuelColumn))
            {
                _dtAllVehicles.DefaultView.RowFilter = "";
                _UpdateRecordsCount();
                return;
            }

            if (cbFuelType.Text == "Tất cả") _dtAllVehicles.DefaultView.RowFilter = "";
            else _dtAllVehicles.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", fuelColumn, _EscapeRowFilterValue(cbFuelType.Text));
            _UpdateRecordsCount();
        }

        private void cbIsAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllVehicles == null) return;
            string val = (cbIsAvailable.Text == "Sẵn sàng") ? "1" : (cbIsAvailable.Text == "Đang thuê") ? "0" : "";
            if (val == "") _dtAllVehicles.DefaultView.RowFilter = "";
            else _dtAllVehicles.DefaultView.RowFilter = string.Format("[IsAvailableForRent] = {0}", val);
            _UpdateRecordsCount();
        }

        private void btnAddNewVehicle_Click(object sender, EventArgs e)
        {
            frmAddEditVehicle frm = new frmAddEditVehicle();
            frm.ShowDialog();
            _RefreshVehiclesList();
        }

        private void showVehicleDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_TryGetSelectedVehicleID(out int vehicleID))
            {
                MessageBox.Show("Vui lòng chọn xe cần xem.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmShowVehicleDetails frm = new frmShowVehicleDetails(vehicleID);
            frm.ShowDialog();
        }

        private void editVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_TryGetSelectedVehicleID(out int vehicleID))
            {
                MessageBox.Show("Vui lòng chọn xe cần chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmAddEditVehicle frm = new frmAddEditVehicle(vehicleID);
            frm.ShowDialog();
            _RefreshVehiclesList();
        }

        private void deleteVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_TryGetSelectedVehicleID(out int vehicleID))
            {
                MessageBox.Show("Vui lòng chọn xe cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Xóa xe này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (clsVehicle.DeleteVehicle(vehicleID))
                {
                    MessageBox.Show("Xóa xe thành công.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshVehiclesList();
                }
                else
                {
                    MessageBox.Show("Không thể xóa xe. Xe có thể đang phát sinh dữ liệu liên quan (đặt xe, trả xe hoặc giao dịch).",
                        "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dgvVehiclesList_DoubleClick(object sender, EventArgs e)
        {
            if (dgvVehiclesList.Rows.Count > 0)
                showVehicleDetailsToolStripMenuItem.PerformClick();
        }
    }
}