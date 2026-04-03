using CarRental.Booking;
using CarRental.GlobalClasses;
using CarRental.Transaction;
using CarRental_Business;
using System;
using System.Windows.Forms;

namespace CarRental.Return.UserControls
{
    public partial class ucReturnCard : UserControl
    {
        private int? _ReturnID = null;
        private clsReturn _Return;

        public int? ReturnID => _ReturnID;
        public clsReturn ReturnInfo => _Return;

        public ucReturnCard()
        {
            InitializeComponent();
        }

        private void _FillReturnInfo()
        {
            btnShowBookingInfo.Enabled = _Return?.TransactionInfo?.BookingID.HasValue == true;
            btnShowTransactionInfo.Enabled = _Return?.TransactionInfo?.TransactionID.HasValue == true;

            lblReturnID.Text = _Return.ReturnID?.ToString();
            lblActualReturnDate.Text = clsFormat.DateToShort(_Return.ActualReturnDate);
            lblActualRentalDays.Text = _Return.ActualRentalDays.ToString();
            lblMileage.Text = _Return.Mileage.ToString();
            lblConsumedMileage.Text = _Return.ConsumedMileage.ToString();
            lblFinalCheckNotes.Text = _Return.FinalCheckNotes;
            lblAdditionalCharges.Text = _Return.AdditionalCharges.ToString("N0") + " VNĐ";
            lblActualTotalDueAmount.Text = _Return.ActualTotalDueAmount.ToString("N0") + " VNĐ";
        }

        public void Reset()
        {
            _ReturnID = null;
            _Return = null;

            lblReturnID.Text = "[????]";
            lblActualReturnDate.Text = "[????]";
            lblActualRentalDays.Text = "[????]";
            lblMileage.Text = "[????]";
            lblConsumedMileage.Text = "[????]";
            lblFinalCheckNotes.Text = "[????]";
            lblAdditionalCharges.Text = "[????]";
            lblActualTotalDueAmount.Text = "[????]";

            btnShowBookingInfo.Enabled = false;
            btnShowTransactionInfo.Enabled = false;
        }

        public void LoadReturnInfo(int? ReturnID)
        {
            _ReturnID = ReturnID;

            if (!_ReturnID.HasValue)
            {
                MessageBox.Show("Không có thông tin trả xe!", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _Return = clsReturn.Find(_ReturnID.Value);

            if (_Return == null)
            {
                MessageBox.Show("Không tìm thấy thông tin trả xe!", "Thiếu dữ liệu",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillReturnInfo();
        }

        private void llShowBookingInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowBookingInfo();
        }

        private void btnShowBookingInfo_Click(object sender, EventArgs e)
        {
            _ShowBookingInfo();
        }

        private void llShowTransactionInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowTransactionInfo();
        }

        private void btnShowTransactionInfo_Click(object sender, EventArgs e)
        {
            _ShowTransactionInfo();
        }

        private void _ShowBookingInfo()
        {
            int? bookingID = ReturnInfo?.TransactionInfo?.BookingID;
            if (!bookingID.HasValue)
            {
                MessageBox.Show("Phiếu trả xe này chưa có lịch đặt liên quan.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmShowBookingDetails ShowBookingDetails = new frmShowBookingDetails(bookingID);
            ShowBookingDetails.ShowDialog();
        }

        private void _ShowTransactionInfo()
        {
            int? transactionID = ReturnInfo?.TransactionInfo?.TransactionID;
            if (!transactionID.HasValue)
            {
                MessageBox.Show("Phiếu trả xe này chưa có giao dịch liên quan.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmShowTransactionDetails ShowTransactionDetails = new frmShowTransactionDetails(transactionID);
            ShowTransactionDetails.ShowDialog();
        }
    }
}
