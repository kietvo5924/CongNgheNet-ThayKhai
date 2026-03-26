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
            _ApplyModernUiNoIcons();

            dtpMaintenanceDate.MinDate = DateTime.Now;
        }

        public frmVehicleMaintenance(int VehicleID)
        {
            InitializeComponent();
            _ApplyModernUiNoIcons();

            ucVehicleCardWithFilter1.LoadVehicleInfo(VehicleID);
            ucVehicleCardWithFilter1.FilterEnabled = false;

            dtpMaintenanceDate.MinDate = DateTime.Now;
        }

        private void _ApplyModernUiNoIcons()
        {
            this.Font = new Font("Segoe UI", 10F);
            this.BackColor = Color.FromArgb(245, 247, 251);

            lblTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(31, 41, 55);

            groupBox1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(55, 65, 81);
            groupBox1.BackColor = Color.White;

            foreach (Control control in groupBox1.Controls)
            {
                if (control is Label lbl)
                {
                    lbl.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
                    lbl.ForeColor = Color.FromArgb(107, 114, 128);
                }
            }

            lblVehicleID.ForeColor = Color.FromArgb(31, 41, 55);
            lblMaintenanceID.ForeColor = Color.FromArgb(0, 118, 212);

            btnSave.FillColor = Color.FromArgb(0, 118, 212);
            btnSave.ForeColor = Color.White;
            btnSave.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnSave.Text = "Lưu";

            btnClose.FillColor = Color.FromArgb(243, 244, 246);
            btnClose.ForeColor = Color.FromArgb(75, 85, 99);
            btnClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnClose.Text = "Đóng";

            txtCost.Font = new Font("Segoe UI", 10F);
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtCost.FillColor = Color.White;
            txtDescription.FillColor = Color.White;

            dtpMaintenanceDate.BorderRadius = 8;
            dtpMaintenanceDate.FillColor = Color.White;
            dtpMaintenanceDate.ForeColor = Color.FromArgb(31, 41, 55);
            dtpMaintenanceDate.Font = new Font("Segoe UI", 10F);

            llShowVehicleMaintenanceHistory.LinkColor = Color.FromArgb(0, 118, 212);
            llShowVehicleMaintenanceHistory.ActiveLinkColor = Color.FromArgb(0, 118, 212);
            llShowVehicleMaintenanceHistory.VisitedLinkColor = Color.FromArgb(0, 118, 212);
            llShowVehicleMaintenanceHistory.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox8.Visible = false;
            pbGender.Visible = false;
        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCost_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidateMoney(
                txtCost,
                errorProvider1,
                e,
                out _,
                required: true,
                allowNegative: false,
                formatAfterValidate: true,
                emptyMessage: "Chi phí không được để trống!",
                invalidMessage: "Giá trị chi phí không hợp lệ.");
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidateRequired(txtDescription, errorProvider1, e);
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

            if (!clsValidation.ValidateDateInRange(
                dtpMaintenanceDate,
                dtpMaintenanceDate.Value,
                errorProvider1,
                null,
                minDate: DateTime.Now.Date,
                maxDate: null,
                rangeMessage: "Ngày bảo trì không được nhỏ hơn ngày hiện tại."))
            {
                MessageBox.Show("Ngày bảo trì không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn tạo lịch bảo trì cho xe này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (!clsValidation.ValidateMoney(
                txtCost,
                errorProvider1,
                null,
                out decimal cost,
                required: true,
                allowNegative: false,
                formatAfterValidate: false,
                emptyMessage: "Chi phí không được để trống!",
                invalidMessage: "Giá trị chi phí không hợp lệ."))
            {
                MessageBox.Show("Giá trị chi phí không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _MaintenanceID = ucVehicleCardWithFilter1.SelectedVehicleInfo.
                Maintenance(txtDescription.Text.Trim(), dtpMaintenanceDate.Value,
                            cost);

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
