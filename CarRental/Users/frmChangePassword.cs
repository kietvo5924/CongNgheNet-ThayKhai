using CarRental.GlobalClasses;
using CarRental_Business;
using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CarRental.Users
{
    public partial class frmChangePassword : Form
    {
        private int? _UserID;
        private clsUser _User;

        public frmChangePassword(int? UserID, bool EditEnabled)
        {
            InitializeComponent();
            _UserID = UserID;
            ucUserCard1.EditEnabled = EditEnabled;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _User = clsUser.Find(_UserID);
            if (_User == null)
            {
                MessageBox.Show("Không tìm thấy người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ucUserCard1.LoadUserInfo(_UserID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Vui lòng kiểm tra lại các thông tin nhập liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clsGlobal.ComputeHash(txtCurrentPassword.Text.Trim()) != _User.Password)
            {
                MessageBox.Show("Mật khẩu hiện tại không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrentPassword.Focus();
                return;
            }

            _User.Password = clsGlobal.ComputeHash(txtNewPassword.Text.Trim());

            if (_User.Save())
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi lưu mật khẩu mới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidateRequired((Control)sender, errorProvider1, e, "Vui lòng nhập mật khẩu hiện tại!");
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidateRequired((Control)sender, errorProvider1, e, "Vui lòng nhập mật khẩu mới!");
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            Guna2TextBox temp = (Guna2TextBox)sender;
            if (temp.Text != txtNewPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "Mật khẩu xác nhận không khớp!");
            }
            else
            {
                errorProvider1.SetError(temp, null);
            }
        }
    }
}