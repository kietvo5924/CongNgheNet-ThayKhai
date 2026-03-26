using CarRental.GlobalClasses;
using CarRental_Business;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CarRental.Dashboard
{
    public partial class frmDashboard : Form
    {
        private int _AllVehicles = 0;

        public frmDashboard()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            // 1. Cập nhật các con số thống kê
            CountElements();

            // 2. Xử lý biểu đồ trạng thái xe
            SetupVehicleChart();

            // 3. Danh sách khách hàng còn đang thuê chưa trả
            LoadActiveRentalsList();
        }

        private void SetupVehicleChart()
        {
            int RentedVehiclesCount = clsBooking.GetActiveRentalBookingsCount();
            int AvailableVehiclesCount = Math.Max(0, _AllVehicles - RentedVehiclesCount);

            chartVehiclesStatus.Series["s1"].Points.Clear();

            // Data Point: Sẵn sàng (Màu xanh lá hiện đại)
            DataPoint availablePoint = new DataPoint();
            availablePoint.SetValueXY("Sẵn sàng", AvailableVehiclesCount);
            availablePoint.Label = AvailableVehiclesCount.ToString();
            availablePoint.LegendText = "Xe sẵn sàng";
            availablePoint.Color = Color.FromArgb(40, 199, 111); // Green success
            chartVehiclesStatus.Series["s1"].Points.Add(availablePoint);

            // Data Point: Đang thuê (Màu đỏ cam hiện đại)
            DataPoint rentedPoint = new DataPoint();
            rentedPoint.SetValueXY("Đang thuê", RentedVehiclesCount);
            rentedPoint.Label = RentedVehiclesCount.ToString();
            rentedPoint.LegendText = "Xe đang thuê";
            rentedPoint.Color = Color.FromArgb(234, 84, 85); // Red danger
            chartVehiclesStatus.Series["s1"].Points.Add(rentedPoint);

            // Tinh chỉnh hiệu ứng Doughnut
            chartVehiclesStatus.Series["s1"]["PieLabelStyle"] = "Inside";
            chartVehiclesStatus.Series["s1"]["DoughnutRadius"] = "60";
        }

        private void LoadActiveRentalsList()
        {
            lstActiveRentals.Items.Clear();

            DataTable dt = clsBooking.GetActiveRentalBookingsForDashboard();

            if (dt == null || dt.Rows.Count == 0)
            {
                lstActiveRentals.Items.Add("Không có khách hàng nào đang thuê chưa trả.");
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                string customerName = row["CustomerName"]?.ToString() ?? "N/A";
                string customerId = row["CustomerID"]?.ToString() ?? "?";
                string vehicleId = row["VehicleID"]?.ToString() ?? "?";

                DateTime startDate;
                string startDateText = DateTime.TryParse(row["RentalStartDate"]?.ToString(), out startDate)
                    ? startDate.ToString("dd/MM/yyyy")
                    : "N/A";

                lstActiveRentals.Items.Add($"KH#{customerId} - {customerName} | Xe#{vehicleId} | Nhận: {startDateText}");
            }
        }

        private void CountElements()
        {
            _AllVehicles = clsVehicle.GetAllVehiclesCount();

            lblNumberOfCustomers.Text = clsCustomer.GetCustomersCount().ToString();
            lblNumberOfUsers.Text = clsUser.GetUsersCount().ToString();
            lblNumberOfVehicles.Text = _AllVehicles.ToString();
            lblNumberOfBooking.Text = clsBooking.GetBookingCount().ToString();
            lblNumberOfReturn.Text = clsReturn.GetReturnCount().ToString();
            lblNumberOfTransaction.Text = clsTransaction.GetTransactionsCount().ToString();
        }
    }
}