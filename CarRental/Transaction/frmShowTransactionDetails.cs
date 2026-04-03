using System;
using System;
using System.Windows.Forms;

namespace CarRental.Transaction
{
    public partial class frmShowTransactionDetails : Form
    {
        private readonly int? _transactionID;

        public frmShowTransactionDetails(int? TransactionID)
        {
            InitializeComponent();
            _transactionID = TransactionID;

            this.AcceptButton = btnClose;
            this.CancelButton = btnClose;

            if (!_transactionID.HasValue || _transactionID.Value <= 0)
            {
                MessageBox.Show("Mã giao dịch không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ucTransactionCard1.LoadTransactionInfo(_transactionID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
