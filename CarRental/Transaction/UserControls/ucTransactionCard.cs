using CarRental_Business;
using System.Drawing;
using System.Windows.Forms;

namespace CarRental.Transaction.UserControls
{
    public partial class ucTransactionCard : UserControl
    {
        private int? _TransactionID = null;
        private clsTransaction _Transaction;

        public int? TransactionID => _TransactionID;
        public clsTransaction Transaction => _Transaction;
        public clsTransaction TransactionInfo => _Transaction;

        public ucTransactionCard()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            _TransactionID = null;
            _Transaction = null;

            lblTransactionID.Text = "[????]";
            lblBookingID.Text = "[????]";
            lblReturnID.Text = "[????]";
            lblPaymentDetails.Text = "Không có dữ liệu";
            lblPaidInitialTotalDueAmount.Text = "[????]";
            lblActualTotalDueAmount.Text = "[????]";
            lblTotalRemaining.Text = "[????]";
            lblTotalRefundedAmount.Text = "[????]";
            lblTransactionDate.Text = "[????]";
            lblTransactionType.Text = "[????]";
        }

        private string _GetTransactionTypeText(clsTransaction.enTransactionType type)
        {
            // VIỆT HÓA CÁC TRẠNG THÁI GIAO DỊCH
            switch (type)
            {
                case clsTransaction.enTransactionType.Pending: return "Đang chờ";
                case clsTransaction.enTransactionType.PaymentReceived: return "Đã nhận tiền";
                case clsTransaction.enTransactionType.RefundIssued: return "Đã hoàn tiền";
                case clsTransaction.enTransactionType.NoActionTaken: return "Không xử lý";
                default: return "Không xác định";
            }
        }

        private void _FillTransactionInfo()
        {
            lblTransactionID.Text = _Transaction.TransactionID.ToString();
            lblBookingID.Text = _Transaction.BookingID.ToString();
            lblReturnID.Text = _Transaction.ReturnID?.ToString() ?? "Không có";
            lblPaymentDetails.Text = string.IsNullOrWhiteSpace(_Transaction.PaymentDetails) ? "Không có" : _Transaction.PaymentDetails;

            lblPaidInitialTotalDueAmount.Text = _Transaction.PaidInitialTotalDueAmount.ToString("N0") + " VNĐ";
            lblActualTotalDueAmount.Text = _Transaction.ActualTotalDueAmount.HasValue
                ? _Transaction.ActualTotalDueAmount.Value.ToString("N0") + " VNĐ"
                : "Không có";
            lblTotalRemaining.Text = _Transaction.TotalRemaining.HasValue
                ? _Transaction.TotalRemaining.Value.ToString("N0") + " VNĐ"
                : "Không có";
            lblTotalRefundedAmount.Text = _Transaction.TotalRefundedAmount.HasValue
                ? _Transaction.TotalRefundedAmount.Value.ToString("N0") + " VNĐ"
                : "Không có";

            lblTransactionDate.Text = _Transaction.TransactionDate.ToString("dd/MM/yyyy HH:mm");

            lblTransactionType.Text = _GetTransactionTypeText(_Transaction.TransactionType);

            // Đổi màu trạng thái để dễ nhận biết
            if (_Transaction.TransactionType == clsTransaction.enTransactionType.PaymentReceived)
                lblTransactionType.ForeColor = Color.Green;
            else if (_Transaction.TransactionType == clsTransaction.enTransactionType.RefundIssued)
                lblTransactionType.ForeColor = Color.Blue;
            else
                lblTransactionType.ForeColor = Color.Orange;
        }

        public void LoadTransactionInfo(int? TransactionID)
        {
            _TransactionID = TransactionID;

            if (!_TransactionID.HasValue)
            {
                Reset();
                return;
            }

            _Transaction = clsTransaction.FindByTransactionID(_TransactionID);

            if (_Transaction == null)
            {
                MessageBox.Show($"Không tìm thấy giao dịch với mã = {TransactionID}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Reset();
                return;
            }

            _FillTransactionInfo();
        }
    }
}