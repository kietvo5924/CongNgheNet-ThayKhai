using CarRental.GlobalClasses;
using CarRental.Properties;
using CarRental_Business;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Users
{
    public partial class frmAddEditUser : Form
    {
        public Action<int?> GetUserIDByDelegate;

        public enum enMode { AddNew, Update };
        private enMode _Mode = enMode.AddNew;

        private int? _UserID = null;
        private clsUser _User;
        private readonly bool _canEditPermissions;

        public frmAddEditUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            _canEditPermissions = clsGlobal.CurrentUser == null
                || clsGlobal.CheckAccessDenied(clsUser.enPermissions.ManageUsers);
        }

        public frmAddEditUser(int? UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = enMode.Update;
            _canEditPermissions = clsGlobal.CurrentUser == null
                || clsGlobal.CheckAccessDenied(clsUser.enPermissions.ManageUsers);
        }

        private void _FillProvinceComboBox()
        {
            DataTable dtProvinces = _EnsureProvinceTableSchema(clsProvince.GetAllProvinces());

            cbProvince.DataSource = dtProvinces;
            cbProvince.DisplayMember = "ProvinceName";
            cbProvince.ValueMember = "ProvinceID";

            if (dtProvinces.Rows.Count == 0)
            {
                MessageBox.Show("Không tải được dữ liệu Tỉnh/Thành phố từ cơ sở dữ liệu.\nHãy kiểm tra bảng dbo.Provinces và dữ liệu trong bảng.",
                    "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private DataTable _EnsureProvinceTableSchema(DataTable dtProvinces)
        {
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

            return dtProvinces;
        }

        private bool _IsAllItemIsChecked()
        {
            foreach (Control item in gbPermissions.Controls)
            {
                if (item is Guna2CheckBox chk && chk.Tag != null && chk.Tag.ToString() != "-1")
                {
                    if (!chk.Checked) return false;
                }
            }
            return true;
        }

        private bool _DoesNotSelectAnyPermission()
        {
            if (!_canEditPermissions)
            {
                return false;
            }

            foreach (Control item in gbPermissions.Controls)
            {
                if (item is Guna2CheckBox chk && chk.Checked)
                    return false;
            }
            return true;
        }

        private void _ResetFields()
        {
            txtName.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtSecurityQuestion.Text = "";
            txtSecurityAnswer.Text = "";
        }

        private void _ResetDefaultValues()
        {
            _FillProvinceComboBox();

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "THÊM NGƯỜI DÙNG MỚI";
                this.Text = "Thêm người dùng mới";
                _User = new clsUser();
                _ResetFields();
            }
            else
            {
                lblTitle.Text = "CẬP NHẬT NGƯỜI DÙNG";
                this.Text = "Cập nhật người dùng";
            }

            pbUserImage.Image = rbMale.Checked ? Resources.DefaultMale : Resources.DefaultFemale;
            llRemoveImage.Visible = (pbUserImage.ImageLocation != null);
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            if (cbProvince.Items.Count > 0)
            {
                int vietnamIndex = cbProvince.FindString("Vietnam");
                cbProvince.SelectedIndex = (vietnamIndex != -1) ? vietnamIndex : 0;
            }

            gbPermissions.Visible = _canEditPermissions;
            gbPermissions.Enabled = _canEditPermissions;
        }

        private void _FillCheckBoxPermissions()
        {
            if (_User.Permissions == -1)
            {
                chkAllPermissions.Checked = true;
                return;
            }

            foreach (Control item in gbPermissions.Controls)
            {
                if (item is Guna2CheckBox chk && chk.Tag != null && chk.Tag.ToString() != "-1")
                {
                    int tagValue = Convert.ToInt32(chk.Tag);
                    if ((tagValue & _User.Permissions) == tagValue)
                    {
                        chk.Checked = true;
                    }
                }
            }
        }

        private void _FillFieldsWithUserInfo()
        {
            lblUserID.Text = _User.UserID.ToString();
            txtName.Text = _User.Name;
            txtEmail.Text = _User.Email;
            txtAddress.Text = _User.Address;
            txtPhone.Text = _User.Phone;
            dtpDateOfBirth.Value = _User.DateOfBirth;
            txtUsername.Text = _User.Username;
            txtSecurityQuestion.Text = _User.SecurityQuestion;
            txtSecurityAnswer.Text = clsGlobal.Decrypt(_User.SecurityAnswer);
            if (_User.ProvinceInfo?.ProvinceID != null)
            {
                cbProvince.SelectedValue = _User.ProvinceInfo.ProvinceID.Value;
            }
            else
            {
                string provinceName = _User.ProvinceInfo?.ProvinceName ?? string.Empty;
                int provinceIndex = cbProvince.FindString(provinceName);
                if (provinceIndex >= 0)
                    cbProvince.SelectedIndex = provinceIndex;
            }

            if (_User.Gender == (byte)clsPerson.enGender.Male)
            {
                rbMale.Checked = true;
                pbUserImage.Image = Resources.DefaultMale;
            }
            else
            {
                rbFemale.Checked = true;
                pbUserImage.Image = Resources.DefaultFemale;
            }

            chkIsActive.Checked = _User.IsActive;
            _FillCheckBoxPermissions();

            if (_User.ImagePath != null)
            {
                pbUserImage.ImageLocation = _User.ImagePath;
                llRemoveImage.Visible = true;
            }
        }

        private void _LoadData()
        {
            _User = clsUser.Find(_UserID);
            if (_User == null)
            {
                MessageBox.Show("Không tìm thấy người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            _FillFieldsWithUserInfo();
            panelPassword.Visible = false;
            llChangePassword.Visible = true;
        }

        private bool _HandleUserImage()
        {
            if (_User.ImagePath != pbUserImage.ImageLocation)
            {
                if (_User.ImagePath != null)
                {
                    try { File.Delete(_User.ImagePath); } catch { }
                }

                if (pbUserImage.ImageLocation != null)
                {
                    string SourceImageFile = pbUserImage.ImageLocation;
                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbUserImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    return false;
                }
            }
            return true;
        }

        private int _CountPermissions()
        {
            if (chkAllPermissions.Checked) return -1;
            int Permissions = 0;
            if (chkManageCustomers.Checked) Permissions += (int)clsUser.enPermissions.ManageCustomers;
            if (chkManageUsers.Checked) Permissions += (int)clsUser.enPermissions.ManageUsers;
            if (chkManageVehicles.Checked) Permissions += (int)clsUser.enPermissions.ManageVehicles;
            if (chkManageBooking.Checked) Permissions += (int)clsUser.enPermissions.ManageBooking;
            if (chkManageReturn.Checked) Permissions += (int)clsUser.enPermissions.ManageReturn;
            if (chkManageTransactions.Checked) Permissions += (int)clsUser.enPermissions.ManageTransactions;
            return Permissions;
        }

        private void _FillUserObjectWithFieldsData()
        {
            if (_Mode == enMode.Update) _User = clsUser.Find(_UserID);

            _User.Name = txtName.Text.Trim();
            _User.Email = txtEmail.Text.Trim();
            _User.Address = txtAddress.Text.Trim();
            _User.Phone = txtPhone.Text.Trim();
            if (cbProvince.SelectedValue == null || cbProvince.SelectedValue == DBNull.Value)
                _User.NationalityCountryID = null;
            else
                _User.NationalityCountryID = Convert.ToInt32(cbProvince.SelectedValue);
            _User.Gender = (rbMale.Checked) ? clsPerson.enGender.Male : clsPerson.enGender.Female;
            _User.DateOfBirth = dtpDateOfBirth.Value;
            _User.Username = txtUsername.Text.Trim();
            _User.IsActive = chkIsActive.Checked;
            if (_canEditPermissions)
            {
                _User.Permissions = _CountPermissions();
            }
            _User.SecurityQuestion = txtSecurityQuestion.Text.Trim();
            _User.SecurityAnswer = clsGlobal.Encrypt(txtSecurityAnswer.Text.Trim());

            if (_Mode == enMode.AddNew)
                _User.Password = clsGlobal.ComputeHash(txtPassword.Text.Trim());

            _User.ImagePath = pbUserImage.ImageLocation;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren()) return;

            if (_DoesNotSelectAnyPermission())
            {
                MessageBox.Show("Vui lòng chọn ít nhất một quyền!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_HandleUserImage()) return;

            _FillUserObjectWithFieldsData();

            if (_User.Save())
            {
                MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mode = enMode.Update;
                GetUserIDByDelegate?.Invoke(_User.UserID);
                this.Close();
            }
            else MessageBox.Show("Lưu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e) { this.Close(); }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update) _LoadData();
        }

        private void chkAllPermissions_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = chkAllPermissions.Checked;
            foreach (Control item in gbPermissions.Controls)
            {
                if (item is Guna2CheckBox chk && chk.Tag.ToString() != "-1")
                    chk.Checked = isChecked;
            }
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            Guna2CheckBox current = (Guna2CheckBox)sender;
            if (!current.Checked) { chkAllPermissions.Checked = false; return; }
            if (_IsAllItemIsChecked()) chkAllPermissions.Checked = true;
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            Control control = (Control)sender;
            clsValidation.ValidateRequired(control, errorProvider1, e, "Không được để trống!");

            if (!e.Cancel && control == txtPhone)
            {
                clsValidation.ValidateVietnamPhone(txtPhone, errorProvider1, e, required: true);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text.Trim())) return;
            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Email không hợp lệ!");
            }
            else errorProvider1.SetError(txtEmail, null);
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUsername, "Tên đăng nhập trống!");
                return;
            }
            if ((_Mode == enMode.AddNew || txtUsername.Text.ToLower() != _User.Username.ToLower()) && clsUser.DoesUserExist(txtUsername.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUsername, "Tên đăng nhập đã tồn tại!");
            }
            else errorProvider1.SetError(txtUsername, null);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!panelPassword.Visible) return;
            clsValidation.ValidateRequired(txtPassword, errorProvider1, e, "Mật khẩu trống!");
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!panelPassword.Visible) return;
            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Mật khẩu không khớp!");
            }
            else errorProvider1.SetError(txtConfirmPassword, null);
        }

        private void txtSecurityQuestion_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidateRequired(txtSecurityQuestion, errorProvider1, e, "Nhập câu hỏi bảo mật!");
        }

        private void txtSecurityAnswer_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidateRequired(txtSecurityAnswer, errorProvider1, e, "Nhập câu trả lời!");
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.HandlePhoneKeyPress(txtPhone, e);
        }

        private void rbMale_Click(object sender, EventArgs e) { if (pbUserImage.ImageLocation == null) pbUserImage.Image = Resources.DefaultMale; }
        private void rbFemale_Click(object sender, EventArgs e) { if (pbUserImage.ImageLocation == null) pbUserImage.Image = Resources.DefaultFemale; }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbUserImage.ImageLocation = openFileDialog1.FileName;
                llRemoveImage.Visible = true;
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbUserImage.ImageLocation = null;
            pbUserImage.Image = rbMale.Checked ? Resources.DefaultMale : Resources.DefaultFemale;
            llRemoveImage.Visible = false;
        }

        private void llChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(_UserID, false);
            frm.ShowDialog();
        }
    }
}