using CarRental.Customers;
using CarRental.Customers.UserControls;
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

namespace CarRental.Vehicles.UserControls
{
    public partial class ucVehicleCardWithFilter : UserControl
    {
        public ucVehicleCardWithFilter()
        {
            InitializeComponent();
        }

        #region Declare Event
        public class VehicleSelectedEventArgs : EventArgs
        {
            public int? VehicleID { get; }

            public VehicleSelectedEventArgs(int? vehicleID)
            {
                this.VehicleID = vehicleID;
            }
        }

        public event EventHandler<VehicleSelectedEventArgs> OnVehicleSelected;

        public void RaiseOnVehicleSelected(int? VehicleID)
        {
            RaiseOnVehicleSelected(new VehicleSelectedEventArgs(VehicleID));
        }

        protected void RaiseOnVehicleSelected(VehicleSelectedEventArgs e)
        {
            OnVehicleSelected?.Invoke(this, e);
        }
        #endregion

        private bool _ShowAddVehicleButton = true;
        public bool ShowAddVehicleButton
        {
            get => _ShowAddVehicleButton;

            set
            {
                _ShowAddVehicleButton = value;
                btnAddNew.Visible = _ShowAddVehicleButton;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get => _FilterEnabled;

            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }

        public int? VehicleID => ucVehicleCard1.VehicleID;
        public clsVehicle SelectedVehicleInfo => ucVehicleCard1.VehicleInfo;

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }

            // to make sure that the user can enter only numbers
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Một số trường chưa hợp lệ, hãy di chuột lên biểu tượng màu đỏ để xem chi tiết lỗi.",
                    "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            LoadVehicleInfo(int.Parse(txtFilterValue.Text.Trim()));
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "Vui lòng không để trống trường này!");
            }
            else
            {
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        private void ucVehicleCardWithFilter_Load(object sender, EventArgs e)
        {
            txtFilterValue.Focus();
        }

        public void LoadVehicleInfo(int? VehicleID)
        {
            txtFilterValue.Text = VehicleID.ToString();
            ucVehicleCard1.LoadVehicleInfo(VehicleID);

            if (OnVehicleSelected != null)
            {
                // Raise the event with a parameter
                RaiseOnVehicleSelected(ucVehicleCard1.VehicleID);
            }
        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        public void Clear()
        {
            ucVehicleCard1.Reset();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditVehicle AddNewVehicle = new frmAddEditVehicle();
            AddNewVehicle.GetVehicleIDByDelegate += LoadVehicleInfo;
            AddNewVehicle.ShowDialog();
        }
    }
}
