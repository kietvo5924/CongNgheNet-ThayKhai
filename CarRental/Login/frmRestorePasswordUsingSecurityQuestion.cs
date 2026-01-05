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
    public partial class frmRestorePasswordUsingSecurityQuestion : Form
    {
        private string _Username;
        private clsUser _User;

        public frmRestorePasswordUsingSecurityQuestion(string username)
        {
            InitializeComponent();

            _Username = username;
        }

        private void _ShowSecurityQuestion()
        {
            _User = clsUser.Find(_Username);

            if (_User == null)
            {
                MessageBox.Show("Không tìm thấy người dùng với tên đăng nhập này!", "Không tìm thấy",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();

                return;
            }

            if (string.IsNullOrWhiteSpace(_User.SecurityQuestion))
            {
                MessageBox.Show("Người dùng này chưa thiết lập câu hỏi bảo mật!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();

                return;
            }

            lblSecurityQuestion.Text = _User.SecurityQuestion;
        }

        private bool _CheckAnswer()
        {
            return (clsGlobal.Decrypt(_User.SecurityAnswer).ToLower() == txtAnswer.Text.Trim().ToLower());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we don't continue because the form is not valid
                MessageBox.Show("Một số trường chưa hợp lệ, hãy di chuột lên biểu tượng màu đỏ để xem chi tiết lỗi.",
                    "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_CheckAnswer())
            {
                MessageBox.Show("Câu trả lời chính xác, bạn có thể đổi mật khẩu ngay bây giờ.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();

                frmChangePasswordUsingSecurityQuestion ChangePassword =
                    new frmChangePasswordUsingSecurityQuestion(_Username);

                ChangePassword.ShowDialog();
            }
            else
            {
                MessageBox.Show("Câu trả lời chưa chính xác!",
                    "Sai câu trả lời", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtAnswer.Focus();
            }
        }

        private void txtAnswer_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAnswer.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAnswer, "Vui lòng không để trống trường này!");
            }
            else
            {
                errorProvider1.SetError(txtAnswer, null);
            }
        }

        private void frmRestorePasswordUsingSecurityQuestion_Load(object sender, EventArgs e)
        {
            _ShowSecurityQuestion();

            txtAnswer.Focus();
        }
    }
}
