using System;
using System.Windows.Forms;

namespace CarRental.Vehicles
{
    public partial class frmShowVehicleDetails : Form
    {
        private int? _VehicleID = null;

        public frmShowVehicleDetails(int? VehicleID)
        {
            InitializeComponent();
            _VehicleID = VehicleID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowVehicleDetails_Load(object sender, EventArgs e)
        {
            if (!_VehicleID.HasValue)
            {
                MessageBox.Show("Mã xe không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Gọi hàm Load dữ liệu từ ucVehicleCard mà chúng ta đã fix lỗi ở bước trước
            ucVehicleCard1.LoadVehicleInfo(_VehicleID);
        }
    }
}