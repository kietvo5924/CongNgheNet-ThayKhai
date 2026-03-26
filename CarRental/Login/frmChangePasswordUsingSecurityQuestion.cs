using CarRental.GlobalClasses;
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

namespace CarRental.Login
{
    public partial class frmChangePasswordUsingSecurityQuestion : Form
    {
        private string _Username;

        public frmChangePasswordUsingSecurityQuestion(string Username)
        {
            InitializeComponent();

            _Username = Username;
        }

        private void _ChangePassword()
        {
            clsUser User = clsUser.Find(_Username);

            if (User == null)
            {
                MessageBox.Show("Không tìm thấy người dùng với tên đăng nhập này!", "Không tìm thấy",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();

                return;
            }

            if (User.ChangePassword(clsGlobal.ComputeHash(txtNewPassword.Text.Trim())))
            {
                MessageBox.Show("Đổi mật khẩu thành công, bạn có thể đăng nhập ngay bây giờ.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, mật khẩu chưa được thay đổi.",
                   "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            ((TextBox)sender).UseSystemPasswordChar = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidateRequired(txtNewPassword, ErrorProvider1, e, "Mật khẩu mới không được để trống");
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                ErrorProvider1.SetError(txtConfirmPassword,
                    "Mật khẩu xác nhận không khớp với mật khẩu mới!");
            }
            else
            {
                ErrorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we don't continue because the form is not valid
                MessageBox.Show("Một số trường chưa hợp lệ, hãy di chuột lên biểu tượng màu đỏ để xem chi tiết lỗi.",
                    "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ChangePassword();
        }
    }
}
