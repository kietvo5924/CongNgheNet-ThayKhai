using CarRental.GlobalClasses;
using CarRental.Properties;
using CarRental_Business;
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
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
            txtRentalPricePerDay.Text = _Vehicle.RentalPricePerDay.ToString();
            chkIsAvailableForRent.Checked = _Vehicle.IsAvailableForRent;

            cbMake.SelectedIndex = cbMake.FindString(_Vehicle.MakeInfo.Make);
            cbBody.SelectedIndex = cbBody.FindString(_Vehicle.BodyInfo.BodyName);
            cbFuelType.SelectedIndex = cbFuelType.FindString(_Vehicle.FuelTypeInfo.FuelTypeName);
            cbDriveType.SelectedIndex = cbDriveType.FindString(_Vehicle.DriverTypeInfo.DriveTypeName);

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
                cbModel.SelectedIndex = cbModel.FindString(_Vehicle.ModelInfo.ModelName);
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
                cbSubModel.SelectedIndex = cbSubModel.FindString(_Vehicle.SubModelInfo.SubModelName);
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

            _Vehicle.VehicleName = txtVehicleName.Text.Trim();
            _Vehicle.PlateNumber = txtPlateNumber.Text.Trim();
            _Vehicle.Year = Convert.ToInt16(txtYear.Text.Trim());
            _Vehicle.Mileage = Convert.ToInt32(txtMileage.Text.Trim());
            _Vehicle.RentalPricePerDay = Convert.ToSingle(txtRentalPricePerDay.Text.Trim());
            _Vehicle.Engine = txtEngine.Text.Trim();
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
            }
            else errorProvider1.SetError(temp, null);
        }

        private void frmAddEditVehicle_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update) _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

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