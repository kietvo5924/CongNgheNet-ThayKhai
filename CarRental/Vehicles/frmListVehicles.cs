using CarRental_Business;
using System;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Vehicles
{
    public partial class frmListVehicles : Form
    {
        private DataTable _dtAllVehicles;
        private int _AllVehicleCount = 0;
        private short _RowsPerPage = 20;

        public frmListVehicles()
        {
            InitializeComponent();
        }

        private void _FillPagesComboBox()
        {
            cbPages.Items.Clear();

            _AllVehicleCount = clsVehicle.GetAllVehiclesCount();
            short NumberOfPages = (short)Math.Ceiling((decimal)_AllVehicleCount / _RowsPerPage);

            for (short i = 1; i <= NumberOfPages; i++)
            {
                cbPages.Items.Add(i.ToString());
            }

            if (cbPages.Items.Count > 0)
                cbPages.SelectedIndex = 0;
        }

        private async void _FillMakesComboBoxAsync()
        {
            await Task.Delay(100);
            cbMake.Items.Add("Tất cả");

            DataTable dtMakes = clsMake.GetAllMakesName();

            foreach (DataRow Make in dtMakes.Rows)
            {
                cbMake.Items.Add(Make["Make"].ToString());
            }
        }

        private async void _FillModelsComboBoxAsync()
        {
            await Task.Delay(100);
            cbModel.Items.Add("Tất cả");

            DataTable dtModels = clsModel.GetAllModelsNameAsync();

            foreach (DataRow Model in dtModels.Rows)
            {
                cbModel.Items.Add(Model["ModelName"].ToString());
            }
        }

        private async void _FillDriveTypesComboBoxAsync()
        {
            await Task.Delay(100);
            cbDriverType.Items.Add("Tất cả");

            DataTable dtDriveTypes = clsDriveType.GetAllDriveTypesNameAsync();

            foreach (DataRow DriveType in dtDriveTypes.Rows)
            {
                cbDriverType.Items.Add(DriveType["DriveTypeName"].ToString());
            }
        }

        private async void _FillFuelTypesComboBoxAsync()
        {
            await Task.Delay(100);
            cbFuelType.Items.Add("Tất cả");

            DataTable dtFuelTypes = clsFuelType.GetAllFuelTypesName();

            foreach (DataRow FuelType in dtFuelTypes.Rows)
            {
                cbFuelType.Items.Add(FuelType["FuelTypeName"].ToString());
            }
        }

        private void _FillYearComboBox()
        {
            cbYear.Items.Add("Tất cả");

            for (short year = 1950; year <= DateTime.Now.Year; year++)
            {
                cbYear.Items.Add(year.ToString());
            }
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Mã xe":
                    return "VehicleID";

                case "Tên xe":
                    return "VehicleName";

                case "Hãng xe":
                    return "Make";

                case "Dòng xe":
                    return "ModelName";

                case "Biển số":
                    return "PlateNumber";

                case "Năm sản xuất":
                    return "Year";

                case "Loại nhiên liệu":
                    return "FuelTypeName";

                case "Hệ dẫn động":
                    return "DriveTypeName";

                case "Sẵn sàng cho thuê":
                    return "IsAvailableForRent";

                default:
                    return "None";
            }
        }

        private void _RefreshVehiclesList()
        {
            _dtAllVehicles = clsVehicle.GetAllVehiclesInPages(short.Parse(cbPages.Text), _RowsPerPage);

            dgvVehiclesList.DataSource = _dtAllVehicles;

            lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();

            if (dgvVehiclesList.Rows.Count > 0)
            {
                dgvVehiclesList.Columns[0].HeaderText = "Mã xe";
                dgvVehiclesList.Columns[0].Width = 110;

                dgvVehiclesList.Columns[1].HeaderText = "Tên xe";
                dgvVehiclesList.Columns[1].Width = 200;

                dgvVehiclesList.Columns[2].HeaderText = "Hãng";
                dgvVehiclesList.Columns[2].Width = 120;

                dgvVehiclesList.Columns[3].HeaderText = "Dòng xe";
                dgvVehiclesList.Columns[3].Width = 120;

                dgvVehiclesList.Columns[4].HeaderText = "Biển số";
                dgvVehiclesList.Columns[4].Width = 130;

                dgvVehiclesList.Columns[5].HeaderText = "Năm SX";
                dgvVehiclesList.Columns[5].Width = 60;

                dgvVehiclesList.Columns[6].HeaderText = "Loại nhiên liệu";
                dgvVehiclesList.Columns[6].Width = 105;

                dgvVehiclesList.Columns[7].HeaderText = "Hệ dẫn động";
                dgvVehiclesList.Columns[7].Width = 108;

                dgvVehiclesList.Columns[8].HeaderText = "Số km";
                dgvVehiclesList.Columns[8].Width = 70;

                dgvVehiclesList.Columns[9].HeaderText = "Giá thuê/ngày";
                dgvVehiclesList.Columns[9].Width = 160;

                dgvVehiclesList.Columns[10].HeaderText = "Sẵn sàng cho thuê";
                dgvVehiclesList.Columns[10].Width = 110;
            }
        }

        private int _GetVehicleIDFromDGV()
        {
            return (int)dgvVehiclesList.CurrentRow.Cells["VehicleID"].Value;
        }

        private void frmListVehicles_Load(object sender, EventArgs e)
        {
            _FillPagesComboBox();
            _RefreshVehiclesList();

            _FillMakesComboBoxAsync();
            _FillModelsComboBoxAsync();
            _FillDriveTypesComboBoxAsync();
            _FillFuelTypesComboBoxAsync();

            _FillYearComboBox();

            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool filterNone = cbFilter.Text == "Không lọc";
            bool filterMake = cbFilter.Text == "Hãng xe";
            bool filterModel = cbFilter.Text == "Dòng xe";
            bool filterYear = cbFilter.Text == "Năm sản xuất";
            bool filterFuel = cbFilter.Text == "Loại nhiên liệu";
            bool filterDrive = cbFilter.Text == "Hệ dẫn động";
            bool filterAvailability = cbFilter.Text == "Sẵn sàng cho thuê";

            bool requiresCombo = filterMake || filterModel || filterYear || filterFuel || filterDrive || filterAvailability;

            txtSearch.Visible = !filterNone && !requiresCombo;

            cbMake.Visible = filterMake;
            cbModel.Visible = filterModel;
            cbYear.Visible = filterYear;
            cbFuelType.Visible = filterFuel;
            cbDriverType.Visible = filterDrive;
            cbIsAvailableForRent.Visible = filterAvailability;

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }

            if (cbMake.Visible && cbMake.Items.Count > 0)
            {
                int index = cbMake.FindStringExact("Tất cả");
                cbMake.SelectedIndex = (index >= 0) ? index : 0;
            }

            if (cbModel.Visible && cbModel.Items.Count > 0)
            {
                int index = cbModel.FindStringExact("Tất cả");
                cbModel.SelectedIndex = (index >= 0) ? index : 0;
            }

            if (cbYear.Visible && cbYear.Items.Count > 0)
            {
                int index = cbYear.FindStringExact("Tất cả");
                cbYear.SelectedIndex = (index >= 0) ? index : 0;
            }

            if (cbFuelType.Visible && cbFuelType.Items.Count > 0)
            {
                int index = cbFuelType.FindStringExact("Tất cả");
                cbFuelType.SelectedIndex = (index >= 0) ? index : 0;
            }

            if (cbDriverType.Visible && cbDriverType.Items.Count > 0)
            {
                int index = cbDriverType.FindStringExact("Tất cả");
                cbDriverType.SelectedIndex = (index >= 0) ? index : 0;
            }

            if (cbIsAvailableForRent.Visible && cbIsAvailableForRent.Items.Count > 0)
            {
                cbIsAvailableForRent.SelectedIndex = 0;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllVehicles.Rows.Count == 0)
            {
                return;
            }

            string ColumnName = _GetRealColumnNameInDB();
            string searchValue = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue) || cbFilter.Text == "Không lọc")
            {
                _dtAllVehicles.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "Mã xe")
            {
                // search with numbers
                _dtAllVehicles.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, searchValue);
            }
            else
            {
                // search with string
                string escapedValue = searchValue.Replace("'", "''");
                _dtAllVehicles.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, escapedValue);
            }

            lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Mã xe")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void cbMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllVehicles.Rows.Count == 0)
            {
                return;
            }

            if (cbMake.Text == "Tất cả")
            {
                _dtAllVehicles.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();

                return;
            }

            _dtAllVehicles.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "Make", cbMake.Text.Replace("'", "''"));

            lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();
        }

        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllVehicles.Rows.Count == 0)
            {
                return;
            }

            if (cbModel.Text == "Tất cả")
            {
                _dtAllVehicles.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();

                return;
            }

            _dtAllVehicles.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "ModelName", cbModel.Text.Replace("'", "''"));

            lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllVehicles.Rows.Count == 0)
            {
                return;
            }

            if (cbYear.Text == "Tất cả")
            {
                _dtAllVehicles.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();

                return;
            }

            _dtAllVehicles.DefaultView.RowFilter =
                string.Format("[{0}] = {1}", "Year", cbYear.Text);

            lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();
        }

        private void cbFuelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllVehicles.Rows.Count == 0)
            {
                return;
            }

            if (cbFuelType.Text == "Tất cả")
            {
                _dtAllVehicles.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();

                return;
            }

            _dtAllVehicles.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "FuelTypeName", cbFuelType.Text.Replace("'", "''"));

            lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();
        }

        private void cbDriverType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllVehicles.Rows.Count == 0)
            {
                return;
            }

            if (cbDriverType.Text == "Tất cả")
            {
                _dtAllVehicles.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();

                return;
            }

            _dtAllVehicles.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "DriveTypeName", cbDriverType.Text.Replace("'", "''"));

            lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();
        }

        private void cbIsAvailableForRent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllVehicles.Rows.Count == 0)
            {
                return;
            }

            if (cbIsAvailableForRent.Text == "Tất cả")
            {
                _dtAllVehicles.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();

                return;
            }

            bool isAvailable = cbIsAvailableForRent.Text == "Có";
            _dtAllVehicles.DefaultView.RowFilter =
                string.Format("[{0}] = {1}", "IsAvailableForRent", isAvailable);

            lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();
        }

        private void ShowVehicleDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowVehicleDetails ShowVehicleDetails = new frmShowVehicleDetails(_GetVehicleIDFromDGV());
            ShowVehicleDetails.ShowDialog();

            _RefreshVehiclesList();
            txtSearch.Clear();
        }

        private void EditVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditVehicle EditVehicle = new frmAddEditVehicle(_GetVehicleIDFromDGV());
            EditVehicle.ShowDialog();

            _RefreshVehiclesList();
        }

        private void DeleteVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string confirmMessage = "Are you sure you want to delete this vehicle?\nBạn có chắc muốn xóa xe này?";
            if (MessageBox.Show(confirmMessage, "Confirm / Xác nhận", MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (clsVehicle.DeleteVehicle(_GetVehicleIDFromDGV()))
                {
                    MessageBox.Show("Deleted successfully.\nXóa dữ liệu thành công", "Deleted / Đã xóa",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmListVehicles_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Deletion failed.\nXóa dữ liệu thất bại", "Failed / Lỗi",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddNewVehicle_Click(object sender, EventArgs e)
        {
            frmAddEditVehicle AddVehicle = new frmAddEditVehicle();
            AddVehicle.ShowDialog();

            frmListVehicles_Load(null, null);
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            DeleteVehicleToolStripMenuItem.Enabled = (bool)dgvVehiclesList.CurrentRow.Cells["IsAvailableForRent"].Value;
        }

        private void dgvVehiclesList_DoubleClick(object sender, EventArgs e)
        {
            frmShowVehicleDetails ShowVehicleDetails = new frmShowVehicleDetails(_GetVehicleIDFromDGV());
            ShowVehicleDetails.ShowDialog();

            _RefreshVehiclesList();
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            frmVehicleMaintenance Maintenance = new frmVehicleMaintenance();
            Maintenance.ShowDialog();
        }

        private void MaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVehicleMaintenance Maintenance = new frmVehicleMaintenance((int)dgvVehiclesList.CurrentRow.Cells["VehicleID"].Value);
            Maintenance.ShowDialog();

            _RefreshVehiclesList();
            txtSearch.Clear();
        }

        private void ShowMaintenanceHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowVehicleMaintenanceHistory ShowVehicleMaintenanceHistory = new frmShowVehicleMaintenanceHistory(_GetVehicleIDFromDGV());
            ShowVehicleMaintenanceHistory.ShowDialog();

            _RefreshVehiclesList();
            txtSearch.Clear();
        }

        private void cbPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshVehiclesList();
        }
    }
}
