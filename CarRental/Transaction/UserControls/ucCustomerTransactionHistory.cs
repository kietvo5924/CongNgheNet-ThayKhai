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

namespace CarRental.Transaction.UserControls
{
    public partial class ucCustomerTransactionHistory : UserControl
    {
        private DataTable _dtAllTransactionHistory;

        private int? _CustomerID = null;

        public ucCustomerTransactionHistory()
        {
            InitializeComponent();
        }

        private void _RefreshTransactionHistoryList()
        {
            _dtAllTransactionHistory = clsTransaction.GetAllRentalTransactionByCustomerID(_CustomerID);
            dgvTransactionHistoryList.DataSource = _dtAllTransactionHistory;

            lblNumberOfRecords.Text = dgvTransactionHistoryList.Rows.Count.ToString();

            if (dgvTransactionHistoryList.Rows.Count > 0)
            {
                dgvTransactionHistoryList.Columns[0].HeaderText = "Mã giao dịch";
                dgvTransactionHistoryList.Columns[0].Width = 140;

                dgvTransactionHistoryList.Columns[1].HeaderText = "Khách hàng";
                dgvTransactionHistoryList.Columns[1].Width = 190;

                dgvTransactionHistoryList.Columns[2].HeaderText = "Mã khách hàng";
                dgvTransactionHistoryList.Columns[2].Width = 125;

                dgvTransactionHistoryList.Columns[3].HeaderText = "Mã đặt xe";
                dgvTransactionHistoryList.Columns[3].Width = 125;

                dgvTransactionHistoryList.Columns[4].HeaderText = "Mã trả xe";
                dgvTransactionHistoryList.Columns[4].Width = 125;

                dgvTransactionHistoryList.Columns[5].HeaderText = "Tổng phải trả thực tế";
                dgvTransactionHistoryList.Columns[5].Width = 220;

                dgvTransactionHistoryList.Columns[6].HeaderText = "Còn lại phải trả";
                dgvTransactionHistoryList.Columns[6].Width = 160;

                dgvTransactionHistoryList.Columns[7].HeaderText = "Số tiền hoàn trả";
                dgvTransactionHistoryList.Columns[7].Width = 210;

                dgvTransactionHistoryList.Columns[8].HeaderText = "Loại giao dịch";
                dgvTransactionHistoryList.Columns[8].Width = 180;

                dgvTransactionHistoryList.Columns[9].HeaderText = "Ngày giao dịch";
                dgvTransactionHistoryList.Columns[9].Width = 180;

                dgvTransactionHistoryList.Columns[10].HeaderText = "Ngày cập nhật giao dịch";
                dgvTransactionHistoryList.Columns[10].Width = 230;
            }
        }

        private int _GetTransactionIDFromDGV()
        {
            return (int)dgvTransactionHistoryList.CurrentRow.Cells["TransactionID"].Value;
        }

        public void LoadCustomerTransactionHistoryInfo(int? CustomerID)
        {
            this._CustomerID = CustomerID;
            _RefreshTransactionHistoryList();
        }

        public void Clear()
        {
            _dtAllTransactionHistory.Clear();
        }

        private void ShowTransactionDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowTransactionDetailsWithBookingAndReturn ShowTransactionDetailsWithBookingAndReturn =
                 new frmShowTransactionDetailsWithBookingAndReturn(_GetTransactionIDFromDGV());

            ShowTransactionDetailsWithBookingAndReturn.ShowDialog();

            _RefreshTransactionHistoryList();
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (dgvTransactionHistoryList.Rows.Count > 0);
        }

        private void dgvTransactionHistoryList_DoubleClick(object sender, EventArgs e)
        {
            frmShowTransactionDetailsWithBookingAndReturn ShowTransactionDetailsWithBookingAndReturn =
                 new frmShowTransactionDetailsWithBookingAndReturn(_GetTransactionIDFromDGV());

            ShowTransactionDetailsWithBookingAndReturn.ShowDialog();

            _RefreshTransactionHistoryList();
        }
    }
}
