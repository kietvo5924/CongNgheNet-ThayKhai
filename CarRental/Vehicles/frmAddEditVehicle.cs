using CarRental.GlobalClasses;
using CarRental.GlobalClasses;
using CarRental.Properties;
using CarRental_Business;
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace CarRental.Vehicles
{
    public partial class frmAddEditVehicle : Form
    {
        public Action<int?> GetVehicleIDByDelegate;

        public enum enMode { AddNew, Update };
        private enMode _Mode = enMode.AddNew;
        private int? _VehicleID = null;
        private clsVehicle _Vehicle;

        public frmAddEditVehicle()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddEditVehicle(int? VehicleID)
        {
            InitializeComponent();
            _VehicleID = VehicleID;
            _Mode = enMode.Update;
        }

        private void _FillComboBoxes()
        {
            // Tải Hãng xe
            DataTable dtMakes = clsMake.GetAllMakes();
            cbMake.Items.Clear();
            foreach (DataRow row in dtMakes.Rows) cbMake.Items.Add(row["Make"].ToString());

            // Tải Kiểu dáng
            DataTable dtBodies = clsBody.GetAllBodies();
            cbBody.Items.Clear();
            foreach (DataRow row in dtBodies.Rows) cbBody.Items.Add(row["BodyName"].ToString());

            // Tải Nhiên liệu
            DataTable dtFuels = clsFuelType.GetAllFuelTypes();
            cbFuelType.Items.Clear();
            foreach (DataRow row in dtFuels.Rows) cbFuelType.Items.Add(row["FuelTypeName"].ToString());

            // Tải Truyền động
            DataTable dtDrives = clsDriveType.GetAllDriveTypes();
            cbDriveType.Items.Clear();
            foreach (DataRow row in dtDrives.Rows) cbDriveType.Items.Add(row["DriveTypeName"].ToString());
        }

        private void _ResetDefaultValues()
        {
            _FillComboBoxes();

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "THÊM XE MỚI";
                _Vehicle = new clsVehicle();
                chkIsAvailableForRent.Checked = true;
            }
            else
            {
                lblTitle.Text = "CẬP NHẬT THÔNG TIN XE";
            }

            pbVehicleImage.Image = null;
            pbVehicleImage.ImageLocation = null;
            llRemoveImage.Visible = false;

            if (_Mode == enMode.AddNew)
            {
                if (cbMake.Items.Count > 0) cbMake.SelectedIndex = 0;
                if (cbBody.Items.Count > 0) cbBody.SelectedIndex = 0;
                if (cbFuelType.Items.Count > 0) cbFuelType.SelectedIndex = 0;
                if (cbDriveType.Items.Count > 0) cbDriveType.SelectedIndex = 0;
            }
        }

        private void _LoadData()
        {
            _Vehicle = clsVehicle.Find(_VehicleID);

            if (_Vehicle == null)
            {
                MessageBox.Show("Không tìm thấy xe!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblVehicleID.Text = _Vehicle.VehicleID.ToString();
            txtVehicleName.Text = _Vehicle.VehicleName;
            txtPlateNumber.Text = _Vehicle.PlateNumber;
            txtYear.Text = _Vehicle.Year.ToString();
            txtEngine.Text = _Vehicle.Engine;
            txtMileage.Text = _Vehicle.Mileage.ToString();
            txtRentalPricePerDay.Text = _Vehicle.RentalPricePerDay.ToString("N0");
            chkIsAvailableForRent.Checked = _Vehicle.IsAvailableForRent;

            cbMake.SelectedIndex = cbMake.FindString(_Vehicle.MakeInfo?.Make ?? string.Empty);
            cbBody.SelectedIndex = cbBody.FindString(_Vehicle.BodyInfo?.BodyName ?? string.Empty);
            cbFuelType.SelectedIndex = cbFuelType.FindString(_Vehicle.FuelTypeInfo?.FuelTypeName ?? string.Empty);
            cbDriveType.SelectedIndex = cbDriveType.FindString(_Vehicle.DriverTypeInfo?.DriveTypeName ?? string.Empty);

            if (_Vehicle.ImagePath != null)
            {
                pbVehicleImage.ImageLocation = _Vehicle.ImagePath;
                llRemoveImage.Visible = true;
            }
            else
            {
                pbVehicleImage.ImageLocation = null;
                llRemoveImage.Visible = false;
            }
        }

        private void cbMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbModel.Items.Clear();
            cbSubModel.Items.Clear();

            clsMake make = clsMake.Find(cbMake.Text);
            if (make == null || !make.MakeID.HasValue)
                return;

            DataTable dtModels = clsModel.GetAllModels();
            foreach (DataRow row in dtModels.Rows)
            {
                if (row["MakeID"] != DBNull.Value && (int)row["MakeID"] == make.MakeID.Value)
                    cbModel.Items.Add(row["ModelName"].ToString());
            }

            if (_Mode == enMode.Update && _Vehicle != null)
                cbModel.SelectedIndex = cbModel.FindString(_Vehicle.ModelInfo?.ModelName ?? string.Empty);
        }

        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSubModel.Items.Clear();

            clsModel model = clsModel.Find(cbModel.Text);
            if (model == null || !model.ModelID.HasValue)
                return;

            DataTable dtSubModels = clsSubModel.GetAllSubModels();
            foreach (DataRow row in dtSubModels.Rows)
            {
                if (row["ModelID"] != DBNull.Value && (int)row["ModelID"] == model.ModelID.Value)
                    cbSubModel.Items.Add(row["SubModelName"].ToString());
            }

            if (_Mode == enMode.Update && _Vehicle != null)
                cbSubModel.SelectedIndex = cbSubModel.FindString(_Vehicle.SubModelInfo?.SubModelName ?? string.Empty);
        }

        private bool _HandleVehicleImage()
        {
            // clsVehicle hiện không có ImagePath nên chỉ copy image vào thư mục project (nếu chọn)
            if (pbVehicleImage.ImageLocation != null)
            {
                string SourceImageFile = pbVehicleImage.ImageLocation;
                if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                {
                    pbVehicleImage.ImageLocation = SourceImageFile;
                    _Vehicle.ImagePath = SourceImageFile;
                    return true;
                }
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren()) return;

            if (!_HandleVehicleImage()) return;

            string vehicleName = txtVehicleName.Text.Trim();
            string plateNumber = txtPlateNumber.Text.Trim().ToUpperInvariant();
            string engine = txtEngine.Text.Trim();

            if (plateNumber.Length < 6)
            {
                MessageBox.Show("Biển số xe không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPlateNumber.Focus();
                return;
            }

            if (!short.TryParse(txtYear.Text.Trim(), out short year))
            {
                MessageBox.Show("Năm sản xuất không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtYear.Focus();
                return;
            }

            int currentYear = DateTime.Now.Year;
            if (year < 1980 || year > currentYear + 1)
            {
                MessageBox.Show($"Năm sản xuất phải trong khoảng từ 1980 đến {currentYear + 1}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtYear.Focus();
                return;
            }

            if (!int.TryParse(txtMileage.Text.Trim(), out int mileage) || mileage < 0)
            {
                MessageBox.Show("Số KM không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMileage.Focus();
                return;
            }

            if (!decimal.TryParse(txtRentalPricePerDay.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal rentalPricePerDay))
            {
                MessageBox.Show("Giá thuê mỗi ngày không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRentalPricePerDay.Focus();
                return;
            }

            if (rentalPricePerDay <= 0)
            {
                MessageBox.Show("Giá thuê mỗi ngày phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRentalPricePerDay.Focus();
                return;
            }

            bool plateChanged = _Mode == enMode.AddNew ||
                               !string.Equals(_Vehicle.PlateNumber ?? string.Empty, plateNumber, StringComparison.OrdinalIgnoreCase);

            if (plateChanged && clsVehicle.DoesPlateNumberExist(plateNumber))
            {
                MessageBox.Show("Biển số xe đã tồn tại. Vui lòng nhập biển số khác.",
                    "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPlateNumber.Focus();
                return;
            }

            _Vehicle.VehicleName = vehicleName;
            _Vehicle.PlateNumber = plateNumber;
            txtPlateNumber.Text = plateNumber;
            _Vehicle.Year = year;
            _Vehicle.Mileage = mileage;
            _Vehicle.RentalPricePerDay = rentalPricePerDay;
            _Vehicle.Engine = engine;
            _Vehicle.IsAvailableForRent = chkIsAvailableForRent.Checked;

            // Gán ID từ các ComboBox
            clsMake make = clsMake.Find(cbMake.Text);
            clsModel model = clsModel.Find(cbModel.Text);
            clsSubModel subModel = clsSubModel.Find(cbSubModel.Text);
            clsBody body = clsBody.Find(cbBody.Text);
            clsFuelType fuel = clsFuelType.Find(cbFuelType.Text);
            clsDriveType drive = clsDriveType.Find(cbDriveType.Text);

            if (make == null || !make.MakeID.HasValue ||
                model == null || !model.ModelID.HasValue ||
                subModel == null || !subModel.SubModelID.HasValue ||
                body == null || !body.BodyID.HasValue ||
                fuel == null || !fuel.FuelTypeID.HasValue ||
                drive == null || !drive.DriveTypeID.HasValue)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin (hãng, dòng, phiên bản, kiểu dáng, nhiên liệu, truyền động).",
                    "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _Vehicle.MakeID = make.MakeID.Value;
            _Vehicle.ModelID = model.ModelID.Value;
            _Vehicle.SubModelID = subModel.SubModelID.Value;
            _Vehicle.BodyID = body.BodyID.Value;
            _Vehicle.FuelTypeID = fuel.FuelTypeID.Value;
            _Vehicle.DriveTypeID = drive.DriveTypeID.Value;

            if (_Vehicle.Save())
            {
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetVehicleIDByDelegate?.Invoke(_Vehicle.VehicleID);
                this.Close();
            }
            else MessageBox.Show("Lưu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ValidateEmptyTextBox(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Guna2TextBox temp = (Guna2TextBox)sender;

            if (string.IsNullOrWhiteSpace(temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "Không được để trống!");
                return;
            }

            if (temp == txtYear)
            {
                if (!short.TryParse(temp.Text.Trim(), out short year))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(temp, "Năm sản xuất không hợp lệ.");
                    return;
                }

                int currentYear = DateTime.Now.Year;
                if (year < 1980 || year > currentYear + 1)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(temp, $"Năm sản xuất phải từ 1980 đến {currentYear + 1}.");
                    return;
                }
            }

            if (temp == txtMileage)
            {
                if (!int.TryParse(temp.Text.Trim(), out int mileage) || mileage < 0)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(temp, "Số KM phải là số nguyên không âm.");
                    return;
                }
            }

            if (temp == txtRentalPricePerDay)
            {
                if (!decimal.TryParse(temp.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal price) || price <= 0)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(temp, "Giá thuê/ngày phải là số lớn hơn 0.");
                    return;
                }

                temp.Text = price.ToString("N0");
            }

            errorProvider1.SetError(temp, null);
        }

        private void frmAddEditVehicle_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update) _LoadData();

            this.AcceptButton = btnSave;
            this.CancelButton = btnClose;

            txtYear.KeyPress += NumericTextBox_KeyPress;
            txtMileage.KeyPress += NumericTextBox_KeyPress;
            txtRentalPricePerDay.KeyPress += DecimalTextBox_KeyPress;
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void DecimalTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            char decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != decimalSeparator)
            {
                e.Handled = true;
                return;
            }

            Guna2TextBox txt = sender as Guna2TextBox;
            if (txt != null && e.KeyChar == decimalSeparator && txt.Text.Contains(decimalSeparator.ToString()))
                e.Handled = true;
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbVehicleImage.ImageLocation = openFileDialog1.FileName;
                llRemoveImage.Visible = true;
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbVehicleImage.ImageLocation = null;
            pbVehicleImage.Image = null;
            llRemoveImage.Visible = false;
            _Vehicle.ImagePath = null;
        }
    }
}