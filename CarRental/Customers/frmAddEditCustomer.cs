using CarRental_Business;
using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CarRental.Customers
{
    public partial class frmAddEditCustomer : Form
    {
        public Action<int?> GetCustomerIDByDelegate;

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        private int? _CustomerID = null;
        private clsCustomer _Customer;

        public frmAddEditCustomer()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddEditCustomer(int? CustomerID)
        {
            InitializeComponent();
            _CustomerID = CustomerID;
            _Mode = enMode.Update;
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "THÊM KHÁCH HÀNG";
                _Customer = new clsCustomer();
            }
            else
            {
                lblTitle.Text = "CẬP NHẬT KHÁCH HÀNG";
            }

            txtFullName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtDriverLicenseNumber.Clear();
        }

        private void _LoadData()
        {
            _Customer = clsCustomer.Find(_CustomerID);

            if (_Customer == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng với ID = " + _CustomerID, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblCustomerID.Text = _Customer.CustomerID.ToString();
            txtFullName.Text = _Customer.Name;
            txtPhone.Text = _Customer.Phone;
            txtEmail.Text = _Customer.Email;
            txtDriverLicenseNumber.Text = _Customer.DriverLicenseNumber;
        }

        private void frmAddEditCustomer_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Vui lòng kiểm tra lại các thông tin nhập liệu!", "Xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _Customer.Name = txtFullName.Text.Trim();
            _Customer.Phone = txtPhone.Text.Trim();
            _Customer.Email = txtEmail.Text.Trim();
            _Customer.DriverLicenseNumber = txtDriverLicenseNumber.Text.Trim();

            if (_Customer.Save())
            {
                lblTitle.Text = "CẬP NHẬT KHÁCH HÀNG";
                _Mode = enMode.Update;
                lblCustomerID.Text = _Customer.CustomerID.ToString();

                MessageBox.Show("Lưu thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetCustomerIDByDelegate?.Invoke(_Customer.CustomerID);
                this.Close();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi lưu thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            Guna2TextBox temp = (Guna2TextBox)sender;
            if (string.IsNullOrWhiteSpace(temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "Trường này không được để trống!");
            }
            else
            {
                errorProvider1.SetError(temp, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}