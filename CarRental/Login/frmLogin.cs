using CarRental.GlobalClasses;
using CarRental.Main;
using CarRental_Business;
using Guna.UI2.WinForms;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void ValidatingOfTextBoxes(object sender, CancelEventArgs e)
        {
            clsValidation.ValidateRequired((Control)sender, errorProvider1, e);
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            ((Guna2TextBox)sender).BorderColor = Color.FromArgb(26, 83, 92);
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            ((Guna2TextBox)sender).BorderColor = Color.Silver;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Một số trường chưa hợp lệ, hãy di chuột lên biểu tượng màu đỏ để xem chi tiết lỗi.",
                    "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string HashedPassword = clsGlobal.ComputeHash(txtPassword.Text.Trim());

            if (!clsUser.DoesUserExist(txtUsername.Text.Trim(), HashedPassword))
            {
                txtUsername.Focus();
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Đăng nhập thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            clsUser User = clsUser.Find(txtUsername.Text.Trim(), HashedPassword);

            if (User == null)
            {
                txtUsername.Focus();
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Đăng nhập thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (chkRememberMe.Checked)
            {
                //store username and password
                clsGlobal.RememberUsernameAndPassword
                    (txtUsername.Text.Trim(), clsGlobal.Encrypt(txtPassword.Text.Trim()));
            }
            else
            {
                //remove username and password
                clsGlobal.RemoveStoredCredential();
            }

            if (!User.IsActive)
            {
                txtUsername.Focus();

                MessageBox.Show("Tài khoản của bạn đang bị khóa, vui lòng liên hệ quản trị viên.",
                    "Tài khoản không hoạt động", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsGlobal.CurrentUser = User;
            this.Hide();
            frmMainMenu OpenMainMenu = new frmMainMenu(this);
            OpenMainMenu.ShowDialog();
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUsername.Text = UserName;
                txtPassword.Text = clsGlobal.Decrypt(Password);
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            frmEnterUsername EnterUsername = new frmEnterUsername();
            EnterUsername.ShowDialog();
        }

        private void llOpenMyProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Tính năng này đang được cập nhật.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
