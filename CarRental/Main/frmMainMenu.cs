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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Main
{
    public partial class frmMainMenu : Form
    {
        private Guna2Button _CurrentButton;

        private Form _ActiveForm;

        private Form _frmLoginForm;

        public Form frmDeniedMassage = new frmAccessDeniedMessage();

        public frmMainMenu(Form frmLoginForm)
        {
            InitializeComponent();

            this._frmLoginForm = frmLoginForm;
        }

        private void _ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (_CurrentButton != (Guna2Button)btnSender)
                {
                    _DisableMenuButton();
                    _CurrentButton = (Guna2Button)btnSender;
                    _CurrentButton.FillColor = Color.White;
                    _CurrentButton.ForeColor = Color.FromArgb(0, 118, 212);
                    _CurrentButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void _DisableMenuButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn is Guna2Button button)
                {
                    button.FillColor = Color.FromArgb(0, 118, 212);
                    button.ForeColor = Color.White;
                    button.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private async void _OpenChildForm(Form childForm, object btnSender)
        {
            await Task.Delay(100);

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

            if (childForm.Tag != null)
            {
                lblTitle.Text = childForm.Tag.ToString();
            }
            else
            {
                lblTitle.Text = childForm.Text;
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
            // this method will show the context menu by clicking on the left click instead of the right click

            // Get the location of the button on the screen
            Point location = btnSubMenu.PointToScreen(new Point(0, btnSubMenu.Height));

            // Show the context menu at the calculated location
            cmsEditProfile.Show(location);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowUserDetails ShowUserDetails = new frmShowUserDetails(clsGlobal.CurrentUser.UserID, false);
            ShowUserDetails.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword ChangePassword = new frmChangePassword(clsGlobal.CurrentUser.UserID, false);
            ChangePassword.ShowDialog();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            btnDashboard.PerformClick();

            lblUsername.Text = clsGlobal.CurrentUser.Username;
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLoginForm.Show();
            this.Close();
        }

    }
}
