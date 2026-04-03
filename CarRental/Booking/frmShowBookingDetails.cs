using System;
using System;
using System.Windows.Forms;

namespace CarRental.Booking
{
    public partial class frmShowBookingDetails : Form
    {
        private readonly int? _bookingID;

        public frmShowBookingDetails(int? BookingID)
        {
            InitializeComponent();
            _bookingID = BookingID;

            this.AcceptButton = btnClose;
            this.CancelButton = btnClose;

            if (!_bookingID.HasValue || _bookingID.Value <= 0)
            {
                MessageBox.Show("Mã lịch đặt không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ucBookingCard1.LoadBookingInfo(_bookingID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
