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

namespace CarRental.Booking.UserControls
{
    public partial class ucBookingCardWithCustomerAndVehicle : UserControl
    {
        public int? BookingID => ucBookingCard1.BookingID;
        public clsBooking BookingInfo => ucBookingCard1.BookingInfo;

        public int? CustomerID => ucSelectedCustomerAndVehicleCard1.CustomerID;
        public clsCustomer CustomerInfo => ucSelectedCustomerAndVehicleCard1.SelectedCustomerInfo;

        public int? VehicleID => ucSelectedCustomerAndVehicleCard1.VehicleID;
        public clsVehicle VehicleInfo => ucSelectedCustomerAndVehicleCard1.SelectedVehicleInfo;

        public ucBookingCardWithCustomerAndVehicle()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            ucSelectedCustomerAndVehicleCard1.Clear();
            ucBookingCard1.Reset();
        }

        public void LoadBookingWithCustomerAndVehicleInfo(int? BookingID)
        {
            ucBookingCard1.LoadBookingInfo(BookingID);

            if (BookingInfo == null)
            {
                ucSelectedCustomerAndVehicleCard1.Clear();
                return;
            }

            ucSelectedCustomerAndVehicleCard1.LoadCustomerVehicleInfo(BookingInfo.CustomerID, BookingInfo.VehicleID);
        }

        public async Task LoadBookingWithCustomerAndVehicleInfoAsync(int? BookingID)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                await ucBookingCard1.LoadBookingInfoAsync(BookingID);

                if (BookingInfo == null)
                {
                    ucSelectedCustomerAndVehicleCard1.Clear();
                    return;
                }

                await ucSelectedCustomerAndVehicleCard1.LoadCustomerVehicleInfoAsync(BookingInfo.CustomerID, BookingInfo.VehicleID);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải dữ liệu từ máy chủ. Vui lòng kiểm tra kết nối mạng.\nChi tiết: {ex.Message}",
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

    }
}
