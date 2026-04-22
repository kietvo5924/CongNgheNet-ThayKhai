using CarRental.GlobalClasses;
using CarRental.Transaction;
using CarRental_Business;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Booking.UserControls
{
    public partial class ucBookingCard : UserControl
    {
        private int? _BookingID = null;
        private clsBooking _Booking;

        public int? BookingID => _BookingID;
        public clsBooking BookingInfo => _Booking;
        
        public ucBookingCard()
        {
            InitializeComponent();
        }

        private void _FillBookingInfo()
        {
            btnTransactionInfo.Enabled = true;

            string customerProvince = _Booking.CustomerInfo?.ProvinceInfo?.ProvinceName;
            string customerAddress = _Booking.CustomerInfo?.Address;
            string customerLocation = string.Empty;

            if (!string.IsNullOrWhiteSpace(customerProvince) && !string.IsNullOrWhiteSpace(customerAddress))
                customerLocation = customerProvince + " - " + customerAddress;
            else if (!string.IsNullOrWhiteSpace(customerProvince))
                customerLocation = customerProvince;
            else if (!string.IsNullOrWhiteSpace(customerAddress))
                customerLocation = customerAddress;

            lblBookingID.Text = _Booking.BookingID?.ToString();
            lblCustomerID.Text = _Booking.CustomerID?.ToString();
            lblVehicleID.Text = _Booking.VehicleID?.ToString();
            lblStartDate.Text = clsFormat.DateToShort(_Booking.RentalStartDate);
            lblEndDate.Text = clsFormat.DateToShort(_Booking.RentalEndDate);
            lblInitialRentalDays.Text = _Booking.InitialRentalDays?.ToString();
            lblInitialTotalDueAmount.Text = _Booking.InitialTotalDueAmount.HasValue
                ? _Booking.InitialTotalDueAmount.Value.ToString("N0") + " VNĐ"
                : "Không có";

            lblPickUpLocation.Text = !string.IsNullOrWhiteSpace(_Booking.PickupLocation)
                ? _Booking.PickupLocation
                : (!string.IsNullOrWhiteSpace(customerLocation) ? customerLocation : "Chưa cập nhật");

            lblDropOffLocation.Text = !string.IsNullOrWhiteSpace(_Booking.DropoffLocation)
                ? _Booking.DropoffLocation
                : (!string.IsNullOrWhiteSpace(customerLocation) ? customerLocation : "Chưa cập nhật");

            lblInitialCheckNotes.Text = string.IsNullOrWhiteSpace(_Booking.InitialCheckNotes) ? "Không có ghi chú" : _Booking.InitialCheckNotes;
        }

        public void Reset()
        {
            _BookingID = null;    
            _Booking = null;

            lblBookingID.Text = "[????]";
            lblCustomerID.Text = "[????]";
            lblVehicleID.Text = "[????]";
            lblStartDate.Text = "[????]";
            lblEndDate.Text = "[????]";
            lblInitialRentalDays.Text = "[????]";
            lblInitialTotalDueAmount.Text = "[????]";
            lblPickUpLocation.Text = "[????]";
            lblDropOffLocation.Text = "[????]";
            lblInitialCheckNotes.Text = "[????]";

            btnTransactionInfo.Enabled = false;
        }

        public async Task LoadBookingInfoAsync(int? BookingID)
        {
            this.Cursor = Cursors.WaitCursor;
            btnTransactionInfo.Enabled = false;

            try
            {
                _BookingID = BookingID;

                if (!_BookingID.HasValue)
                {
                    MessageBox.Show("Không có lịch đặt", "Thiếu dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Reset();

                    return;
                }

                var booking = await Task.Run(() => clsBooking.Find(_BookingID.Value));

                _Booking = booking;

                if (_Booking == null)
                {
                    MessageBox.Show($"Không tìm thấy lịch đặt với ID = {BookingID}", "Thiếu dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    _BookingID = null;

                    Reset();

                    return;
                }

                _FillBookingInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải dữ liệu từ máy chủ. Vui lòng kiểm tra kết nối mạng.\nChi tiết: {ex.Message}",
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnTransactionInfo.Enabled = _Booking != null;
            }
        }

        public async void LoadBookingInfo(int? BookingID)
        {
            await LoadBookingInfoAsync(BookingID);
        }

        private void btnTransactionInfo_Click(object sender, EventArgs e)
        {
            int? transactionID = BookingInfo?.TransactionInfo?.TransactionID;
            if (!transactionID.HasValue)
            {
                MessageBox.Show("Lịch đặt này chưa có giao dịch liên quan.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmShowTransactionDetails ShowTransactionDetails = new frmShowTransactionDetails(transactionID);
            ShowTransactionDetails.ShowDialog();
        }
    }
}
