using CarRental.Properties;
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

namespace CarRental.Customers.UserControls
{
    public partial class ucCustomerCard : UserControl
    {

        private int? _CustomerID = null;
        private clsCustomer _Customer;

        public int? CustomerID => _CustomerID;
        public clsCustomer CustomerInfo => _Customer;

        public ucCustomerCard()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            _CustomerID = null;
            _Customer = null;

            ucPersonCard1.Reset();

            lblCustomerID.Text = "[????]";
            lblDriverLicenseNumber.Text = "[????]";

            btnEditCustomerInfo.Enabled = false;
        }

        private async Task _FillCustomerInfoAsync()
        {
            btnEditCustomerInfo.Enabled = true;

            await ucPersonCard1.LoadPersonInfoAsync(_Customer.PersonID);

            lblCustomerID.Text = _Customer.CustomerID.ToString();
            lblDriverLicenseNumber.Text = _Customer.DriverLicenseNumber;
        }

        public async Task LoadCustomerInfoAsync(int? CustomerID)
        {
            this.Cursor = Cursors.WaitCursor;
            btnEditCustomerInfo.Enabled = false;

            try
            {
                _CustomerID = CustomerID;

                if (!_CustomerID.HasValue)
                {
                    MessageBox.Show("Không có thông tin khách hàng.", "Thiếu dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Reset();

                    return;
                }

                var customer = await Task.Run(() => clsCustomer.Find(_CustomerID));

                _Customer = customer;

                if (_Customer == null)
                {
                    MessageBox.Show($"Không tìm thấy khách hàng với ID = {CustomerID}", "Thiếu dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Reset();

                    return;
                }

                await _FillCustomerInfoAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải dữ liệu từ máy chủ. Vui lòng kiểm tra kết nối mạng.\nChi tiết: {ex.Message}",
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnEditCustomerInfo.Enabled = _Customer != null;
            }
        }

        public async void LoadCustomerInfo(int? CustomerID)
        {
            await LoadCustomerInfoAsync(CustomerID);
        }

        private async void llEditCustomerInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditCustomer EditCustomer = new frmAddEditCustomer(_CustomerID);
            EditCustomer.GetCustomerIDByDelegate += LoadCustomerInfo;
            EditCustomer.ShowDialog();
            await LoadCustomerInfoAsync(_CustomerID);
        }

        private void btnEditCustomerInfo_Click(object sender, EventArgs e)
        {
            llEditCustomerInfo_LinkClicked(sender, null);
        }
    }
}
