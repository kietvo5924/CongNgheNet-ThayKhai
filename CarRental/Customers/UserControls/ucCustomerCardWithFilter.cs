using CarRental_Business;
using CarRental.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Customers.UserControls
{
    public partial class ucCustomerCardWithFilter : UserControl
    {
        private DataTable _dtCustomerSource;
        private readonly HashSet<string> _autoCompleteValues = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public ucCustomerCardWithFilter()
        {
            InitializeComponent();
        }

        #region Declare Event
        public class CustomerSelectedEventArgs : EventArgs
        {
            public int? CustomerID { get; }

            public CustomerSelectedEventArgs(int? customerID)
            {
                this.CustomerID = customerID;
            }
        }

        public event EventHandler<CustomerSelectedEventArgs> OnCustomerSelected;

        public void RaiseOnCustomerSelected(int? CustomerID)
        {
            RaiseOnCustomerSelected(new CustomerSelectedEventArgs(CustomerID));
        }

        protected virtual void RaiseOnCustomerSelected(CustomerSelectedEventArgs e)
        {
            OnCustomerSelected?.Invoke(this, e);
        }
        #endregion

        private bool _ShowAddCustomerButton = true;
        public bool ShowAddMemberButton
        {
            get => _ShowAddCustomerButton;

            set
            {
                _ShowAddCustomerButton = value;
                btnAddNew.Visible = _ShowAddCustomerButton;
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

        public int? CustomerID => ucCustomerCard1.CustomerID;
        public clsCustomer SelectedCustomerInfo => ucCustomerCard1.CustomerInfo;

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbSearchBy.SelectedIndex == 1)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
                if (e.Handled)
                    return;
            }

            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                btnFind.PerformClick();
            }
        }

        private void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Clear();
            errorProvider1.SetError(txtFilterValue, null);
            txtFilterValue.Focus();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we don't continue because the form is not valid
                MessageBox.Show("Một số trường chưa hợp lệ, hãy di chuột lên biểu tượng màu đỏ để xem chi tiết lỗi.",
                    "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (!_TryResolveCustomerID(txtFilterValue.Text.Trim(), out int customerID))
            {
                MessageBox.Show("Không tìm thấy khách hàng theo mã/tên đã nhập.",
                    "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadCustomerInfo(customerID);
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidateRequired(txtFilterValue, errorProvider1, e);
        }

        private void ucCustomerCardWithFilter_Load(object sender, EventArgs e)
        {
            _LoadCustomerAutoComplete();
            cbSearchBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }

        private void _LoadCustomerAutoComplete()
        {
            _dtCustomerSource = clsCustomer.GetAllCustomers();
            _autoCompleteValues.Clear();

            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            if (_dtCustomerSource != null)
            {
                foreach (DataRow row in _dtCustomerSource.Rows)
                {
                    string id = row.Table.Columns.Contains("CustomerID") ? row["CustomerID"].ToString() : string.Empty;
                    string name = row.Table.Columns.Contains("Name") ? row["Name"].ToString() : string.Empty;

                    if (!string.IsNullOrWhiteSpace(id) && _autoCompleteValues.Add(id))
                        source.Add(id);

                    if (!string.IsNullOrWhiteSpace(name) && _autoCompleteValues.Add(name))
                        source.Add(name);

                    string composite = $"{id} - {name}";
                    if (!string.IsNullOrWhiteSpace(id) && !string.IsNullOrWhiteSpace(name) && _autoCompleteValues.Add(composite))
                        source.Add(composite);
                }
            }

            txtFilterValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtFilterValue.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtFilterValue.AutoCompleteCustomSource = source;
        }

        private bool _TryResolveCustomerID(string input, out int customerID)
        {
            customerID = -1;

            if (string.IsNullOrWhiteSpace(input))
                return false;

            input = input.Trim();
            bool allowById = cbSearchBy.SelectedIndex != 2;
            bool allowByName = cbSearchBy.SelectedIndex != 1;

            if (allowById && int.TryParse(input, out customerID))
                return true;

            int dashIndex = input.IndexOf('-');
            if (allowById && dashIndex > 0)
            {
                string prefix = input.Substring(0, dashIndex).Trim();
                if (int.TryParse(prefix, out customerID))
                    return true;
            }

            if (!allowByName)
                return false;

            if (_dtCustomerSource == null)
                _dtCustomerSource = clsCustomer.GetAllCustomers();

            if (_dtCustomerSource == null || !_dtCustomerSource.Columns.Contains("CustomerID") || !_dtCustomerSource.Columns.Contains("Name"))
                return false;

            DataRow matched = _dtCustomerSource.AsEnumerable()
                .FirstOrDefault(r => string.Equals((r["Name"]?.ToString() ?? string.Empty).Trim(), input, StringComparison.OrdinalIgnoreCase));

            if (matched == null)
            {
                matched = _dtCustomerSource.AsEnumerable()
                    .FirstOrDefault(r => (r["Name"]?.ToString() ?? string.Empty)
                        .Trim().StartsWith(input, StringComparison.OrdinalIgnoreCase));
            }

            if (matched == null)
                return false;

            return int.TryParse(matched["CustomerID"].ToString(), out customerID);
        }

        public void LoadCustomerInfo(int? CustomerID)
        {
            txtFilterValue.Text = CustomerID.HasValue ? CustomerID.Value.ToString() : string.Empty;
            ucCustomerCard1.LoadCustomerInfo(CustomerID);
           
            RaiseOnCustomerSelected(ucCustomerCard1.CustomerID);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditCustomer AddNewCustomer = new frmAddEditCustomer();
            AddNewCustomer.GetCustomerIDByDelegate += LoadCustomerInfo;
            AddNewCustomer.ShowDialog();
        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        public void Clear()
        {
            ucCustomerCard1.Reset();
        }
    }
}
