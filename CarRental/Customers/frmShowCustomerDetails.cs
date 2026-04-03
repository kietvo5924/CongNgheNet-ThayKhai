using System;
using System;
using System.Windows.Forms;

namespace CarRental.Customers
{
    public partial class frmShowCustomerDetails : Form
    {
        private readonly int _customerID;

        public frmShowCustomerDetails(int CustomerID)
        {
            InitializeComponent();
            _customerID = CustomerID;

            this.AcceptButton = btnClose;
            this.CancelButton = btnClose;

            if (_customerID <= 0)
            {
                MessageBox.Show("Mã khách hàng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ucCustomerCard1.LoadCustomerInfo(_customerID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
