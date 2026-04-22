using CarRental_Business;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Vehicles.UserControls
{
    public partial class ucVehicleCard : UserControl
    {
        private int? _VehicleID = null;
        private clsVehicle _Vehicle;

        public int? VehicleID => _VehicleID;

        // FIX LỖI CS1061: Các file khác gọi thuộc tính này, nên phải đặt tên là VehicleInfo
        public clsVehicle VehicleInfo => _Vehicle;

        public ucVehicleCard()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            _VehicleID = null;
            _Vehicle = null;

            lblVehicleID.Text = "[????]";
            lblVehicleName.Text = "[????]";
            lblPlateNumber.Text = "[????]";
            lblMake.Text = "[????]";
            lblModel.Text = "[????]";
            lblSubModelName.Text = "[????]";
            lblBody.Text = "[????]";
            lblYear.Text = "[????]";
            lblDriverType.Text = "[????]";
            lblEngine.Text = "[????]";
            lblFuelType.Text = "[????]";
            lblNumberDoors.Text = "[????]";
            lblMileage.Text = "[????]";
            lblRentalPricePerDay.Text = "[????]";
            lblIsAvailable.Text = "[????]";
        }

        private void _FillVehicleInfo()
        {
            lblVehicleID.Text = _Vehicle.VehicleID.ToString();
            lblVehicleName.Text = _Vehicle.VehicleName;
            lblPlateNumber.Text = _Vehicle.PlateNumber;
            lblYear.Text = _Vehicle.Year.ToString();
            lblEngine.Text = _Vehicle.Engine;
            lblNumberDoors.Text = _Vehicle.NumberDoors.ToString();

            // Việt hóa định dạng
            lblMileage.Text = _Vehicle.Mileage.ToString("N0") + " KM";
            lblRentalPricePerDay.Text = _Vehicle.RentalPricePerDay.ToString("N0") + " VNĐ";

            // SỬA LỖI CS1061: Sử dụng đúng tên thuộc tính từ Business Layer
            // LƯU Ý: Nếu vẫn lỗi ở các dòng dưới, hãy gõ dấu "." sau các chữ Info để chọn đúng tên hiện ra
            lblMake.Text = _Vehicle.MakeInfo?.Make ?? "Không có";
            lblModel.Text = _Vehicle.ModelInfo?.ModelName ?? "Không có";
            lblSubModelName.Text = _Vehicle.SubModelInfo?.SubModelName ?? "Không có";
            lblBody.Text = _Vehicle.BodyInfo?.BodyName ?? "Không có";
            lblDriverType.Text = _Vehicle.DriverTypeInfo?.DriveTypeName ?? "Không có";
            lblFuelType.Text = _Vehicle.FuelTypeInfo?.FuelTypeName ?? "Không có";

            // Việt hóa trạng thái
            if (_Vehicle.IsAvailableForRent)
            {
                lblIsAvailable.Text = "Sẵn sàng";
                lblIsAvailable.ForeColor = Color.Green;
            }
            else
            {
                lblIsAvailable.Text = "Đang được thuê";
                lblIsAvailable.ForeColor = Color.Red;
            }

            if (_Vehicle.ImagePath != null)
                pbVehicleImage.ImageLocation = _Vehicle.ImagePath;
            else
                pbVehicleImage.ImageLocation = null;
        }

        public async Task LoadVehicleInfoAsync(int? VehicleID)
        {
            this.Cursor = Cursors.WaitCursor;
            btnEditVehicleInfo.Enabled = false;

            try
            {
                _VehicleID = VehicleID;

                if (!_VehicleID.HasValue)
                {
                    Reset();
                    return;
                }

                var vehicle = await Task.Run(() => clsVehicle.Find(_VehicleID));

                _Vehicle = vehicle;

                if (_Vehicle == null)
                {
                    MessageBox.Show($"Không tìm thấy xe với mã ID = {VehicleID}", "Lỗi dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    return;
                }

                _FillVehicleInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải dữ liệu từ máy chủ. Vui lòng kiểm tra kết nối mạng.\nChi tiết: {ex.Message}",
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnEditVehicleInfo.Enabled = _Vehicle != null;
            }
        }

        public async void LoadVehicleInfo(int? VehicleID)
        {
            await LoadVehicleInfoAsync(VehicleID);
        }

        private async void llEditVehicleInfo_LinkClicked(object sender, EventArgs e)
        {
            frmAddEditVehicle EditVehicle = new frmAddEditVehicle(_VehicleID);
            EditVehicle.ShowDialog();
            await LoadVehicleInfoAsync(_VehicleID);
        }
    }
}