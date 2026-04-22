using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Booking
{
    public partial class frmShowBookingDetailsWithCustomerAndVehicle : Form
    {
        private readonly int? _bookingID;

        public frmShowBookingDetailsWithCustomerAndVehicle(int? BookingID)
        {
            InitializeComponent();
            _bookingID = BookingID;
            this.Load += frmShowBookingDetailsWithCustomerAndVehicle_Load;
        }

        private async void frmShowBookingDetailsWithCustomerAndVehicle_Load(object sender, EventArgs e)
        {
            await ucBookingCardWithCustomerAndVehicle1.LoadBookingWithCustomerAndVehicleInfoAsync(_bookingID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
