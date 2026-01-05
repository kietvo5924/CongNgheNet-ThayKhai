using CarRental.GlobalClasses;
using CarRental.Vehicles.UserControls;
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
using static CarRental.Vehicles.UserControls.ucVehicleCardWithFilter;

namespace CarRental.Vehicles
{
    public partial class frmVehicleMaintenance : Form
    {

        private int? _MaintenanceID = null;

        private int? _SelectedVehicleID = null;

        public frmVehicleMaintenance()
        {
            InitializeComponent();

            dtpMaintenanceDate.MinDate = DateTime.Now;
        }

        public frmVehicleMaintenance(int VehicleID)
        {
            InitializeComponent();

            ucVehicleCardWithFilter1.LoadVehicleInfo(VehicleID);
            ucVehicleCardWithFilter1.FilterEnabled = false;

            dtpMaintenanceDate.MinDate = DateTime.Now;
        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCost_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCost.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCost, "Chi phí không được để trống!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCost, null);

            }


            if (!clsValidation.IsNumber(txtCost.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCost, "Giá trị không hợp lệ.");
            }
            else
            {
                errorProvider1.SetError(txtCost, null);
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "Vui lòng không để trống trường này!");
            }
            else
            {
                errorProvider1.SetError(txtDescription, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucVehicleCardWithFilter1_OnVehicleSelected(object sender, VehicleSelectedEventArgs e)
        {
            _SelectedVehicleID = e.VehicleID;

            if (!_SelectedVehicleID.HasValue)
            {
                btnSave.Enabled = false;
                llShowVehicleMaintenanceHistory.Enabled = false;
                lblVehicleID.Text = "[????]";
                return;
            }

            btnSave.Enabled = true;
            llShowVehicleMaintenanceHistory.Enabled = true;

            lblVehicleID.Text = _SelectedVehicleID.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Một số trường chưa hợp lệ, hãy di chuột lên biểu tượng màu đỏ để xem chi tiết lỗi.",
                    "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn tạo lịch bảo trì cho xe này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            _MaintenanceID = ucVehicleCardWithFilter1.SelectedVehicleInfo.
                Maintenance(txtDescription.Text.Trim(), dtpMaintenanceDate.Value,
                            Convert.ToSingle(txtCost.Text.Trim()));

            if (!_MaintenanceID.HasValue)
            {
                MessageBox.Show("Không thể tạo bảo trì cho xe", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblMaintenanceID.Text = _MaintenanceID.ToString();
            MessageBox.Show("Tạo bảo trì thành công với mã = " + _MaintenanceID,
                "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnSave.Enabled = false;
            ucVehicleCardWithFilter1.FilterEnabled = false;
            txtCost.Enabled = false;
            txtDescription.Enabled = false;
        }

        private void frmVehicleMaintenance_Activated(object sender, EventArgs e)
        {
            ucVehicleCardWithFilter1.FilterFocus();
        }

        private void llShowVehicleMaintenanceHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowVehicleMaintenanceHistory ShowVehicleMaintenanceHistory = new frmShowVehicleMaintenanceHistory(_SelectedVehicleID);
            ShowVehicleMaintenanceHistory.ShowDialog();
        }
    }
}
