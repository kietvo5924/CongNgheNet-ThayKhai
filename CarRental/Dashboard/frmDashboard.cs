using CarRental.GlobalClasses;
using CarRental_Business;
using System;
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
        }

        private void SetupVehicleChart()
        {
            int AvailableVehiclesCount = clsVehicle.GetAvailableVehiclesCount();
            int RentedVehiclesCount = _AllVehicles - AvailableVehiclesCount;

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