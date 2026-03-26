using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Vehicles
{
    public partial class frmShowVehicleMaintenanceHistory : Form
    {
        public frmShowVehicleMaintenanceHistory(int? VehicleID)
        {
            InitializeComponent();
            _ApplyModernUiNoIcons();

            ucVehicleCard1.LoadVehicleInfo(VehicleID);
            ucShowVehicleHistory1.LoadVehicleMaintenanceHistoryInfo(VehicleID);
        }

        private void _ApplyModernUiNoIcons()
        {
            this.Font = new Font("Segoe UI", 10F);
            this.BackColor = Color.FromArgb(245, 247, 251);

            lblTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(31, 41, 55);

            btnClose.FillColor = Color.FromArgb(243, 244, 246);
            btnClose.ForeColor = Color.FromArgb(75, 85, 99);
            btnClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnClose.Text = "Đóng";

            ucVehicleCard1.BackColor = Color.White;
            ucShowVehicleHistory1.BackColor = Color.White;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
