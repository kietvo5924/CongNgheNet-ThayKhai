using System;
using System.Windows.Forms;

namespace CarRental.Return
{
    public partial class frmShowReturnDetails : Form
    {
        private readonly int? _returnID;

        public frmShowReturnDetails(int? ReturnID)
        {
            InitializeComponent();
            _returnID = ReturnID;

            this.AcceptButton = btnClose;
            this.CancelButton = btnClose;

            if (!_returnID.HasValue || _returnID.Value <= 0)
            {
                MessageBox.Show("Mã trả xe không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ucReturnCard1.LoadReturnInfo(_returnID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
