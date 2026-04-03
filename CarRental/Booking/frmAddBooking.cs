using CarRental.Transaction;
using CarRental.GlobalClasses;
using CarRental_Business;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Booking
{
    public partial class frmAddBooking : Form
    {
        public Action<int?> GetBookingIDByDelegate;
        private int? _TransactionID = null;

        public frmAddBooking()
        {
            InitializeComponent();
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            Control control = (Control)sender;
            clsValidation.ValidateRequired(control, errorProvider1, e);

            if (e.Cancel)
                return;

            if (control == txtPaymentDetails)
            {
                string paymentText = txtPaymentDetails.Text.Trim();
                if (paymentText.Length < 3)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtPaymentDetails, "Thông tin thanh toán quá ngắn.");
                    return;
                }

                if (!Regex.IsMatch(paymentText, @"\d"))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtPaymentDetails, "Thông tin thanh toán cần có số tham chiếu (VD: mã giao dịch/số tiền). ");
                    return;
                }

                errorProvider1.SetError(txtPaymentDetails, null);
            }
        }

        private void _UpdateInitialDays()
        {
            dtpEndDate.MinDate = dtpStartDate.Value.AddDays(1);
            int initialDays = (dtpEndDate.Value.Date - dtpStartDate.Value.Date).Days;
            lblInitialRentalDays.Text = initialDays.ToString();
        }

        private void _LoadData()
        {
            dtpStartDate.MinDate = DateTime.Now;
            dtpEndDate.MinDate = DateTime.Now.AddDays(1);
            int InitialDays = (dtpEndDate.Value.Date - dtpStartDate.Value.Date).Days;
            lblInitialRentalDays.Text = InitialDays.ToString();
        }

        private void frmAddBooking_Load(object sender, EventArgs e)
        {
            _LoadData();
            ucSelectedCustomerAndVehicleWithFilter1.SendCustomerID += _FillBookingInfoOnSelectedCustomer;
            ucSelectedCustomerAndVehicleWithFilter1.SendVehicleID += _FillBookingInfoOnSelectedVehicle;
        }

        private void _FillBookingInfoOnSelectedCustomer(int? CustomerID)
        {
            clsCustomer Customer = clsCustomer.Find(CustomerID);
            if (Customer == null)
            {
                lblCustomerID.Text = "[????]";
                btnBook.Enabled = false;
                return;
            }

            string provinceName = Customer.ProvinceInfo?.ProvinceName;
            string address = Customer.Address;
            string customerLocation = string.Empty;

            if (!string.IsNullOrWhiteSpace(provinceName) && !string.IsNullOrWhiteSpace(address))
                customerLocation = provinceName + " - " + address;
            else if (!string.IsNullOrWhiteSpace(provinceName))
                customerLocation = provinceName;
            else if (!string.IsNullOrWhiteSpace(address))
                customerLocation = address;

            if (!string.IsNullOrWhiteSpace(customerLocation))
            {
                if (string.IsNullOrWhiteSpace(txtPickUpLocation.Text.Trim()))
                    txtPickUpLocation.Text = customerLocation;

                if (string.IsNullOrWhiteSpace(txtDropOffLocation.Text.Trim()))
                    txtDropOffLocation.Text = customerLocation;
            }

            lblCustomerID.Text = Customer.CustomerID.ToString();
            _UpdateBookButtonState();
        }

        private void _FillBookingInfoOnSelectedVehicle(int? VehicleID)
        {
            clsVehicle Vehicle = clsVehicle.Find(VehicleID);
            if (Vehicle == null)
            {
                btnBook.Enabled = false;
                return;
            }
            lblVehicleID.Text = Vehicle.VehicleID.ToString();
            lblRentalPricePerDay.Text = Vehicle.RentalPricePerDay.ToString("N0") + " VNĐ";

            decimal initialTotal = _GetInitialTotalDueAmount(Vehicle);
            lblInitialTotalDueAmount.Text = initialTotal.ToString("N0") + " VNĐ";

            _UpdateBookButtonState();
        }

        private void _UpdateBookButtonState()
        {
            bool hasCustomer = ucSelectedCustomerAndVehicleWithFilter1.CustomerID.HasValue;
            bool hasVehicle = ucSelectedCustomerAndVehicleWithFilter1.VehicleID.HasValue;
            bool hasVehicleAvailable = ucSelectedCustomerAndVehicleWithFilter1.SelectedVehicleInfo != null
                                      && ucSelectedCustomerAndVehicleWithFilter1.SelectedVehicleInfo.IsAvailableForRent;
            bool hasValidDates = dtpEndDate.Value.Date > dtpStartDate.Value.Date;

            btnBook.Enabled = hasCustomer && hasVehicle && hasVehicleAvailable && hasValidDates;
        }

        private decimal _GetInitialTotalDueAmount(clsVehicle vehicle)
        {
            if (vehicle == null)
                return 0m;

            if (!int.TryParse(lblInitialRentalDays.Text, out int days))
                return 0m;

            return vehicle.RentalPricePerDay * days;
        }

        private void _Reset()
        {
            btnBook.Enabled = false;
            ucSelectedCustomerAndVehicleWithFilter1.FilterEnable = false;
            txtPickUpLocation.Enabled = false;
            txtDropOffLocation.Enabled = false;
            txtInitailCheckNotes.Enabled = false;
            txtPaymentDetails.Enabled = false;
            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;
        }

        private void _MakeTransactionThenBooking()
        {
            if (!ucSelectedCustomerAndVehicleWithFilter1.CustomerID.HasValue)
            {
                MessageBox.Show("Vui lòng chọn khách hàng trước khi đặt xe.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ucSelectedCustomerAndVehicleWithFilter1.VehicleID.HasValue || ucSelectedCustomerAndVehicleWithFilter1.SelectedVehicleInfo == null)
            {
                MessageBox.Show("Vui lòng chọn xe hợp lệ trước khi đặt xe.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpStartDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Ngày nhận xe không được ở quá khứ.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpEndDate.Value.Date <= dtpStartDate.Value.Date)
            {
                MessageBox.Show("Ngày trả xe phải lớn hơn ngày nhận xe.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsTransaction Transaction = new clsTransaction();
            Transaction.CustomerID = ucSelectedCustomerAndVehicleWithFilter1.CustomerID;
            Transaction.VehicleID = ucSelectedCustomerAndVehicleWithFilter1.VehicleID;
            Transaction.RentalStartDate = dtpStartDate.Value;
            Transaction.RentalEndDate = dtpEndDate.Value;
            Transaction.PickupLocation = txtPickUpLocation.Text.Trim();
            Transaction.DropoffLocation = txtDropOffLocation.Text.Trim();
            Transaction.RentalPricePerDay = ucSelectedCustomerAndVehicleWithFilter1.SelectedVehicleInfo.RentalPricePerDay;
            Transaction.InitialCheckNotes = txtInitailCheckNotes.Text.Trim();
            Transaction.PaidInitialTotalDueAmount = _GetInitialTotalDueAmount(ucSelectedCustomerAndVehicleWithFilter1.SelectedVehicleInfo);
            Transaction.PaymentDetails = txtPaymentDetails.Text.Trim();

            if (!Transaction.Save())
            {
                MessageBox.Show("Không thể tạo lịch đặt. Xe có thể đã được đặt trong khoảng thời gian này hoặc không còn sẵn sàng.", "Đặt xe thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"Đặt xe thành công với mã giao dịch = {Transaction.TransactionID.Value}", "Hoàn tất",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);

            _TransactionID = Transaction.TransactionID;
            lblBookingID.Text = Transaction.BookingID.Value.ToString();
            llTransactionInfo.Enabled = true;
            _Reset();
            GetBookingIDByDelegate?.Invoke(Transaction.BookingID.Value);
        }

        private void frmAddBooking_Activated(object sender, EventArgs e)
        {
            ucSelectedCustomerAndVehicleWithFilter1.FilterFocus();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            _UpdateInitialDays();
            _FillBookingInfoOnSelectedVehicle(ucSelectedCustomerAndVehicleWithFilter1.VehicleID);
            _UpdateBookButtonState();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            _UpdateInitialDays();
            _FillBookingInfoOnSelectedVehicle(ucSelectedCustomerAndVehicleWithFilter1.VehicleID);
            _UpdateBookButtonState();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Vui lòng kiểm tra lại các thông tin nhập liệu!",
                    "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _MakeTransactionThenBooking();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llTransactionInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowTransactionDetails ShowTransactionDetails = new frmShowTransactionDetails(_TransactionID);
            ShowTransactionDetails.ShowDialog();
        }
    }
}