using CarRental.Customers;
using CarRental.Customers.UserControls;
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

namespace CarRental.Vehicles.UserControls
{
    public partial class ucVehicleCardWithFilter : UserControl
    {
        private DataTable _dtVehicleSource;

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
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Một số trường chưa hợp lệ, hãy di chuột lên biểu tượng màu đỏ để xem chi tiết lỗi.",
                    "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (!_TryResolveVehicleID(txtFilterValue.Text.Trim(), out int vehicleID))
            {
                MessageBox.Show("Không tìm thấy xe theo mã/tên đã nhập.",
                    "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadVehicleInfo(vehicleID);
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidateRequired(txtFilterValue, errorProvider1, e);
        }

        private void ucVehicleCardWithFilter_Load(object sender, EventArgs e)
        {
            _LoadVehicleAutoComplete();
            cbSearchBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }

        private void _LoadVehicleAutoComplete()
        {
            _dtVehicleSource = clsVehicle.GetAllVehicles();

            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            if (_dtVehicleSource != null)
            {
                foreach (DataRow row in _dtVehicleSource.Rows)
                {
                    string id = row.Table.Columns.Contains("VehicleID") ? row["VehicleID"].ToString() : string.Empty;
                    string name = row.Table.Columns.Contains("VehicleName") ? row["VehicleName"].ToString() : string.Empty;

                    if (!string.IsNullOrWhiteSpace(id))
                        source.Add(id);

                    if (!string.IsNullOrWhiteSpace(name))
                        source.Add(name);

                    if (!string.IsNullOrWhiteSpace(id) && !string.IsNullOrWhiteSpace(name))
                        source.Add($"{id} - {name}");
                }
            }

            txtFilterValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtFilterValue.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtFilterValue.AutoCompleteCustomSource = source;
        }

        private bool _TryResolveVehicleID(string input, out int vehicleID)
        {
            vehicleID = -1;

            if (string.IsNullOrWhiteSpace(input))
                return false;

            input = input.Trim();
            bool allowById = cbSearchBy.SelectedIndex != 2;
            bool allowByName = cbSearchBy.SelectedIndex != 1;

            if (allowById && int.TryParse(input, out vehicleID))
                return true;

            int dashIndex = input.IndexOf('-');
            if (allowById && dashIndex > 0)
            {
                string prefix = input.Substring(0, dashIndex).Trim();
                if (int.TryParse(prefix, out vehicleID))
                    return true;
            }

            if (!allowByName)
                return false;

            if (_dtVehicleSource == null)
                _dtVehicleSource = clsVehicle.GetAllVehicles();

            if (_dtVehicleSource == null || !_dtVehicleSource.Columns.Contains("VehicleID") || !_dtVehicleSource.Columns.Contains("VehicleName"))
                return false;

            DataRow matched = _dtVehicleSource.AsEnumerable()
                .FirstOrDefault(r => string.Equals((r["VehicleName"]?.ToString() ?? string.Empty).Trim(), input, StringComparison.OrdinalIgnoreCase));

            if (matched == null)
            {
                matched = _dtVehicleSource.AsEnumerable()
                    .FirstOrDefault(r => (r["VehicleName"]?.ToString() ?? string.Empty)
                        .Trim().StartsWith(input, StringComparison.OrdinalIgnoreCase));
            }

            if (matched == null)
                return false;

            return int.TryParse(matched["VehicleID"].ToString(), out vehicleID);
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
