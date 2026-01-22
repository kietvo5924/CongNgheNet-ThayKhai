using CarRental_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace CarRental.Vehicles
{
    public partial class frmListVehicles : Form
    {
        private DataTable _dtAllVehicles;

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
                case "Loại nhiên liệu": return "FuelType";
                case "Trạng thái": return "IsAvailableForRent"; 
                default: return "None";
            }
        }

        private void _RefreshVehiclesList()
        {
            _dtAllVehicles = clsVehicle.GetAllVehicles();
            dgvVehiclesList.DataSource = _dtAllVehicles;
            lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();

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
            _RefreshVehiclesList();
            _FillMakeComboBox();
            _FillFuelTypeComboBox();
            cbFilter.SelectedIndex = 0;
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
            lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();
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
                    _dtAllVehicles.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, FilterValue);
                else
                    _dtAllVehicles.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, FilterValue);
            }
            lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();
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
            else _dtAllVehicles.DefaultView.RowFilter = string.Format("[Make] = '{0}'", cbMake.Text);
            lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();
        }

        private void cbFuelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllVehicles == null) return;
            if (cbFuelType.Text == "Tất cả") _dtAllVehicles.DefaultView.RowFilter = "";
            else _dtAllVehicles.DefaultView.RowFilter = string.Format("[FuelType] = '{0}'", cbFuelType.Text);
            lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();
        }

        private void cbIsAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllVehicles == null) return;
            string val = (cbIsAvailable.Text == "Sẵn sàng") ? "1" : (cbIsAvailable.Text == "Đang thuê") ? "0" : "";
            if (val == "") _dtAllVehicles.DefaultView.RowFilter = "";
            else _dtAllVehicles.DefaultView.RowFilter = string.Format("[IsAvailableForRent] = {0}", val);
            lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();
        }

        private void btnAddNewVehicle_Click(object sender, EventArgs e)
        {
            frmAddEditVehicle frm = new frmAddEditVehicle();
            frm.ShowDialog();
            _RefreshVehiclesList();
        }

        private void showVehicleDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowVehicleDetails frm = new frmShowVehicleDetails((int)dgvVehiclesList.CurrentRow.Cells["VehicleID"].Value);
            frm.ShowDialog();
        }

        private void editVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditVehicle frm = new frmAddEditVehicle((int)dgvVehiclesList.CurrentRow.Cells["VehicleID"].Value);
            frm.ShowDialog();
            _RefreshVehiclesList();
        }

        private void deleteVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa xe này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (clsVehicle.DeleteVehicle((int)dgvVehiclesList.CurrentRow.Cells["VehicleID"].Value))
                {
                    MessageBox.Show("Thành công");
                    _RefreshVehiclesList();
                }
                else MessageBox.Show("Lỗi");
            }
        }

        private void dgvVehiclesList_DoubleClick(object sender, EventArgs e)
        {
            showVehicleDetailsToolStripMenuItem.PerformClick();
        }
    }
}