using CarRental.GlobalClasses;
using CarRental_Business;
using System.Threading.Tasks;
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

            CountElements();

            int AvailableVehiclesCount = clsVehicle.GetAvailableVehiclesCount();
            int RentedVehiclesCount = _AllVehicles - AvailableVehiclesCount;

            chartVehiclesStatus.Titles.Add("");
            chartVehiclesStatus.Series["s1"].IsValueShownAsLabel = true;

            // Add data points with legend text
            DataPoint availableDataPoint = new DataPoint();
            availableDataPoint.SetValueXY("Sẵn sàng", AvailableVehiclesCount);
            availableDataPoint.LegendText = "Sẵn sàng";
            chartVehiclesStatus.Series["s1"].Points.Add(availableDataPoint);

            DataPoint rentedDataPoint = new DataPoint();
            rentedDataPoint.SetValueXY("Đang thuê", RentedVehiclesCount);
            rentedDataPoint.LegendText = "Đang thuê";
            chartVehiclesStatus.Series["s1"].Points.Add(rentedDataPoint);

            lblHiUsername.Text = $"Xin chào {clsGlobal.CurrentUser.Username}";
        }

        private  void CountElements()
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
