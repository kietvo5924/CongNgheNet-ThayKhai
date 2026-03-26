using CarRental.Booking;
using CarRental.Customers;
using CarRental.Dashboard;
using CarRental.GlobalClasses;
using CarRental.Permissions;
using CarRental.Return;
using CarRental.Transaction;
using CarRental.Users;
using CarRental.Vehicles;
using CarRental_Business;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Main
{
    public partial class frmMainMenu : Form
    {
        private Guna2Button _CurrentButton;
        private Form _ActiveForm;
        private Form _frmLoginForm;
        private Guna2Button _btnMaintenance;
        public Form frmDeniedMassage = new frmAccessDeniedMessage();

        public frmMainMenu(Form frmLoginForm)
        {
            InitializeComponent();
            this._frmLoginForm = frmLoginForm;
            this.DoubleBuffered = true;
            _EnableDoubleBuffer(panelHeader);
            _EnsureMaintenanceButton();
        }

        private void _EnsureMaintenanceButton()
        {
            if (_btnMaintenance != null)
                return;

            _btnMaintenance = new Guna2Button
            {
                Name = "btnMaintenance",
                ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton,
                CheckedState =
                {
                    CustomBorderColor = Color.FromArgb(0, 118, 212),
                    FillColor = Color.FromArgb(240, 247, 255),
                    ForeColor = Color.FromArgb(0, 118, 212)
                },
                CustomBorderThickness = new Padding(5, 0, 0, 0),
                FillColor = Color.White,
                Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(125, 137, 149),
                Location = new Point(0, 490),
                Size = new Size(240, 50),
                Text = "Bảo trì",
                TextAlign = HorizontalAlignment.Left,
                TextOffset = new Point(20, 0)
            };

            _btnMaintenance.Click += btnMaintenance_Click;
            panelMenu.Controls.Add(_btnMaintenance);
            _btnMaintenance.BringToFront();
            btnLogOut.BringToFront();
        }

        private void _EnableDoubleBuffer(Control control)
        {
            if (control == null)
                return;

            PropertyInfo doubleBufferedProperty = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            doubleBufferedProperty?.SetValue(control, true, null);

            foreach (Control child in control.Controls)
            {
                _EnableDoubleBuffer(child);
            }
        }

        private void _ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                Guna2Button clickedBtn = (Guna2Button)btnSender;
                if (_CurrentButton != clickedBtn)
                {
                    _DisableMenuButton();
                    _CurrentButton = clickedBtn;

                    // Hiệu ứng khi được chọn (Đã đồng bộ với Designer mới)
                    _CurrentButton.Checked = true;
                }
            }
        }

        private void _DisableMenuButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn is Guna2Button button)
                {
                    button.Checked = false;
                }
            }
        }

        private async void _OpenChildForm(Form childForm, object btnSender)
        {
            // Tạo hiệu ứng chuyển trang mượt mà
            await Task.Delay(50);

            if (_ActiveForm != null)
                _ActiveForm.Close();

            _ActivateButton(btnSender);
            _ActiveForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            // Cập nhật tiêu đề trên Header
            if (childForm.Tag != null)
            {
                lblTitle.Text = childForm.Tag.ToString().ToUpper();
            }
            else
            {
                lblTitle.Text = childForm.Text.ToUpper();
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            _OpenChildForm(new frmDashboard(), sender);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccessDenied(clsUser.enPermissions.ManageCustomers))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }
            _OpenChildForm(new frmListCustomers(), sender);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccessDenied(clsUser.enPermissions.ManageUsers))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }
            _OpenChildForm(new frmListUsers(), sender);
        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccessDenied(clsUser.enPermissions.ManageVehicles))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }
            _OpenChildForm(new frmListVehicles(), sender);
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccessDenied(clsUser.enPermissions.ManageVehicles))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }
            _OpenChildForm(new frmVehicleMaintenance(), sender);
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccessDenied(clsUser.enPermissions.ManageBooking))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }
            _OpenChildForm(new frmListBooking(), sender);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccessDenied(clsUser.enPermissions.ManageReturn))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }
            _OpenChildForm(new frmListReturn(), sender);
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccessDenied(clsUser.enPermissions.ManageTransactions))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }
            _OpenChildForm(new frmListTransaction(), sender);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLoginForm.Show();
            this.Close();
        }

        private void btnSubMenu_Click(object sender, EventArgs e)
        {
            // Hiển thị menu tùy chọn tại vị trí nút Tài khoản
            Point location = btnSubMenu.PointToScreen(new Point(0, btnSubMenu.Height));
            cmsEditProfile.Show(location);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Đổi false thành true ở đây để cho phép chỉnh sửa thông tin cá nhân
            frmShowUserDetails ShowUserDetails = new frmShowUserDetails(clsGlobal.CurrentUser.UserID, true);
            ShowUserDetails.ShowDialog();
            // Sau khi đóng form, có thể cập nhật lại tên trên Header nếu có thay đổi
            btnSubMenu.Text = clsGlobal.CurrentUser.Username;
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword ChangePassword = new frmChangePassword(clsGlobal.CurrentUser.UserID, false);
            ChangePassword.ShowDialog();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            // Mặc định mở Dashboard khi load
            btnDashboard.PerformClick();

            // Gán tên người dùng vào nút Tài khoản trên Header thay vì Label cũ
            btnSubMenu.Text = clsGlobal.CurrentUser.Username;
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLoginForm.Show();
            this.Close();
        }
    }
}