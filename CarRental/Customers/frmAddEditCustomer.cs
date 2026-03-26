using CarRental_Business;
using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace CarRental.Customers
{
    public partial class frmAddEditCustomer : Form
    {
        public Action<int?> GetCustomerIDByDelegate;

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        private int? _CustomerID = null;
        private clsCustomer _Customer;

        private void _FillProvinceComboBox()
        {
            DataTable dtProvinces = clsProvince.GetAllProvinces();

            if (dtProvinces == null)
                dtProvinces = new DataTable();

            if (!dtProvinces.Columns.Contains("ProvinceID"))
            {
                dtProvinces.Columns.Add("ProvinceID", typeof(int));

                if (dtProvinces.Columns.Contains("CountryID"))
                {
                    foreach (DataRow row in dtProvinces.Rows)
                    {
                        if (row["CountryID"] != DBNull.Value)
                            row["ProvinceID"] = row["CountryID"];
                    }
                }
            }

            if (!dtProvinces.Columns.Contains("ProvinceName"))
                dtProvinces.Columns.Add("ProvinceName", typeof(string));

            cbProvince.DataSource = dtProvinces;
            cbProvince.DisplayMember = "ProvinceName";
            cbProvince.ValueMember = "ProvinceID";

            if (dtProvinces.Rows.Count == 0)
            {
                MessageBox.Show("Không tải được dữ liệu Tỉnh/Thành phố từ cơ sở dữ liệu.\nHãy kiểm tra bảng dbo.Provinces và dữ liệu trong bảng.",
                    "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (cbProvince.Items.Count > 0)
            {
                int vietnamIndex = cbProvince.FindString("Vietnam");
                if (vietnamIndex < 0)
                    vietnamIndex = cbProvince.FindString("Việt Nam");

                cbProvince.SelectedIndex = (vietnamIndex >= 0) ? vietnamIndex : 0;
            }
        }

        public frmAddEditCustomer()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddEditCustomer(int? CustomerID)
        {
            InitializeComponent();
            _CustomerID = CustomerID;
            _Mode = enMode.Update;
        }

        private void _ResetDefaultValues()
        {
            _FillProvinceComboBox();

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "THÊM KHÁCH HÀNG";
                _Customer = new clsCustomer();
            }
            else
            {
                lblTitle.Text = "CẬP NHẬT KHÁCH HÀNG";
            }

            txtFullName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtDriverLicenseNumber.Clear();
            rbMale.Checked = true;
        }

        private void _LoadData()
        {
            _Customer = clsCustomer.Find(_CustomerID);

            if (_Customer == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng với ID = " + _CustomerID, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblCustomerID.Text = _Customer.CustomerID.ToString();
            txtFullName.Text = _Customer.Name;
            txtPhone.Text = _Customer.Phone;
            txtEmail.Text = _Customer.Email;
            txtDriverLicenseNumber.Text = _Customer.DriverLicenseNumber;

            rbMale.Checked = (_Customer.Gender == clsPerson.enGender.Male);
            rbFemale.Checked = (_Customer.Gender == clsPerson.enGender.Female);

            if (_Customer.NationalityCountryID.HasValue)
                cbProvince.SelectedValue = _Customer.NationalityCountryID.Value;
        }

        private void _ApplyDefaultPersonFieldsForCustomer()
        {
            if (string.IsNullOrWhiteSpace(_Customer.Address))
                _Customer.Address = "Chưa cập nhật";

            if (_Customer.DateOfBirth == default(DateTime))
                _Customer.DateOfBirth = DateTime.Now.AddYears(-18);

            _Customer.Gender = rbFemale.Checked ? clsPerson.enGender.Female : clsPerson.enGender.Male;

            if (!_Customer.NationalityCountryID.HasValue)
            {
                clsProvince vietnam = clsProvince.Find("Vietnam") ?? clsProvince.Find("Việt Nam");

                if (vietnam != null && vietnam.ProvinceID.HasValue)
                {
                    _Customer.NationalityCountryID = vietnam.ProvinceID.Value;
                }
                else
                {
                    DataTable dtProvinces = clsProvince.GetAllProvinces();
                    if (dtProvinces != null && dtProvinces.Rows.Count > 0 && dtProvinces.Columns.Contains("ProvinceID"))
                    {
                        _Customer.NationalityCountryID = Convert.ToInt32(dtProvinces.Rows[0]["ProvinceID"]);
                    }
                }
            }
        }

        private void frmAddEditCustomer_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Vui lòng kiểm tra lại các thông tin nhập liệu!", "Xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isDriverLicenseChanged = (_Mode == enMode.AddNew) ||
                                          !string.Equals(_Customer.DriverLicenseNumber, txtDriverLicenseNumber.Text.Trim(), StringComparison.OrdinalIgnoreCase);

            if (isDriverLicenseChanged && clsCustomer.DoesDriverLicenseNumberExist(txtDriverLicenseNumber.Text.Trim()))
            {
                MessageBox.Show("Số bằng lái đã tồn tại. Vui lòng nhập số khác.", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDriverLicenseNumber.Focus();
                return;
            }

            _Customer.Name = txtFullName.Text.Trim();
            _Customer.Phone = txtPhone.Text.Trim();
            _Customer.Email = txtEmail.Text.Trim();
            _Customer.DriverLicenseNumber = txtDriverLicenseNumber.Text.Trim();
            _Customer.NationalityCountryID = (cbProvince.SelectedValue == null || cbProvince.SelectedValue == DBNull.Value)
                ? (int?)null
                : Convert.ToInt32(cbProvince.SelectedValue);
            _ApplyDefaultPersonFieldsForCustomer();

            if (!_Customer.NationalityCountryID.HasValue)
            {
                MessageBox.Show("Vui lòng chọn Tỉnh/Thành phố hợp lệ.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbProvince.Focus();
                return;
            }

            if (_Customer.Save())
            {
                lblTitle.Text = "CẬP NHẬT KHÁCH HÀNG";
                _Mode = enMode.Update;
                lblCustomerID.Text = _Customer.CustomerID.ToString();

                MessageBox.Show("Lưu thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetCustomerIDByDelegate?.Invoke(_Customer.CustomerID);
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thể lưu thông tin khách hàng.\nVui lòng kiểm tra lại Email, SĐT, Số bằng lái và Tỉnh/Thành phố.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text.Trim()))
            {
                errorProvider1.SetError(txtEmail, null);
                return;
            }

            if (!CarRental.GlobalClasses.clsValidation.ValidateEmail(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Email không hợp lệ!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            Guna2TextBox temp = (Guna2TextBox)sender;
            if (string.IsNullOrWhiteSpace(temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "Trường này không được để trống!");
            }
            else
            {
                errorProvider1.SetError(temp, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}