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
    public partial class frmEnterUsername : Form
    {
        public frmEnterUsername()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Một số trường chưa hợp lệ, hãy di chuột lên biểu tượng màu đỏ để xem chi tiết lỗi.",
                    "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!clsUser.DoesUserExist(txtUsername.Text.Trim()))
            {
                MessageBox.Show("Không tìm thấy người dùng với tên đăng nhập này!", "Không tìm thấy",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtUsername.Focus();

                return;
            }

            this.Close();

            frmRestorePasswordUsingSecurityQuestion RestorePassword = 
                new frmRestorePasswordUsingSecurityQuestion(txtUsername.Text.Trim());

            RestorePassword.ShowDialog();
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUsername, "Vui lòng không để trống trường này!");
            }
            else
            {
                errorProvider1.SetError(txtUsername, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
