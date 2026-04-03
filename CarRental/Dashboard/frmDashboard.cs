using CarRental.GlobalClasses;
using CarRental_Business;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CarRental.Dashboard
{
    public partial class frmDashboard : Form
    {
        private int _AllVehicles = 0;
        private Label _lblBookingMiniKpi;
        private Label _lblReturnMiniKpi;
        private Label _lblTransactionMiniKpi;
        private Label _lblLastUpdated;
        private Guna2CustomGradientPanel _pnlTransactionAnalytics;
        private Chart _chartRevenueAnalytics;
        private ComboBox _cbAnalyticsMetric;
        private readonly Timer _dashboardRefreshTimer = new Timer();

        public frmDashboard()
        {
            InitializeComponent();
            _EnsureMiniKpiLabels();
            _EnsureTransactionAnalyticsPanel();

            _dashboardRefreshTimer.Interval = 60000;
            _dashboardRefreshTimer.Tick += _dashboardRefreshTimer_Tick;
            this.FormClosed += frmDashboard_FormClosed;

            LoadDashboardData();
            _dashboardRefreshTimer.Start();
        }

        private void _dashboardRefreshTimer_Tick(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void frmDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            _dashboardRefreshTimer.Stop();
        }

        private void _EnsureMiniKpiLabels()
        {
            if (_lblBookingMiniKpi == null)
            {
                _lblBookingMiniKpi = new Label
                {
                    AutoSize = false,
                    Size = new Size(230, 18),
                    Location = new Point(20, 126),
                    BackColor = Color.Transparent,
                    ForeColor = Color.WhiteSmoke,
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                guna2CustomGradientPanel4.Controls.Add(_lblBookingMiniKpi);
                _lblBookingMiniKpi.BringToFront();
            }

            if (_lblReturnMiniKpi == null)
            {
                _lblReturnMiniKpi = new Label
                {
                    AutoSize = false,
                    Size = new Size(230, 18),
                    Location = new Point(20, 126),
                    BackColor = Color.Transparent,
                    ForeColor = Color.WhiteSmoke,
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                guna2CustomGradientPanel5.Controls.Add(_lblReturnMiniKpi);
                _lblReturnMiniKpi.BringToFront();
            }

            if (_lblTransactionMiniKpi == null)
            {
                _lblTransactionMiniKpi = new Label
                {
                    AutoSize = false,
                    Size = new Size(230, 18),
                    Location = new Point(20, 126),
                    BackColor = Color.Transparent,
                    ForeColor = Color.WhiteSmoke,
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                guna2CustomGradientPanel6.Controls.Add(_lblTransactionMiniKpi);
                _lblTransactionMiniKpi.BringToFront();
            }

            if (_lblLastUpdated == null)
            {
                _lblLastUpdated = new Label
                {
                    AutoSize = false,
                    Size = new Size(350, 16),
                    Location = new Point(15, 281),
                    BackColor = Color.Transparent,
                    ForeColor = Color.FromArgb(107, 114, 128),
                    Font = new Font("Segoe UI", 8.5F),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                guna2CustomGradientPanel8.Controls.Add(_lblLastUpdated);
                _lblLastUpdated.BringToFront();
            }

            lstActiveRentals.Location = new Point(15, 45);
            lstActiveRentals.Size = new Size(350, 238);
        }

        private Chart _CreateAnalyticsChart(string title, SeriesChartType chartType, string seriesName)
        {
            Chart chart = new Chart
            {
                BackColor = Color.White,
                BorderlineColor = Color.Transparent,
                BorderlineWidth = 0
            };

            ChartArea area = new ChartArea(seriesName + "Area")
            {
                BackColor = Color.White
            };
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(229, 231, 235);
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8F);
            area.AxisY.Minimum = 0;
            chart.ChartAreas.Add(area);

            Legend legend = new Legend(seriesName + "Legend")
            {
                Enabled = false,
                BackColor = Color.White
            };
            chart.Legends.Add(legend);

            Series series = new Series(seriesName)
            {
                ChartType = chartType,
                ChartArea = area.Name,
                Legend = legend.Name,
                IsValueShownAsLabel = true,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold)
            };
            chart.Series.Add(series);

            chart.Titles.Add(new Title
            {
                Text = title,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 41, 55),
                Docking = Docking.Top
            });

            return chart;
        }

        private DataTable _GetTransactionsDataForAnalytics(out string amountColumn, out string dateColumn)
        {
            amountColumn = null;
            dateColumn = null;

            DataTable dtTransactions = clsTransaction.GetAllRentalTransaction();
            if (dtTransactions == null)
                return null;

            amountColumn = dtTransactions.Columns.Contains("PaidInitialTotalDueAmount")
                ? "PaidInitialTotalDueAmount"
                : dtTransactions.Columns.Contains("ActualTotalDueAmount")
                    ? "ActualTotalDueAmount"
                    : dtTransactions.Columns.Contains("Amount") ? "Amount" : null;

            dateColumn = dtTransactions.Columns.Contains("TransactionDate")
                ? "TransactionDate"
                : dtTransactions.Columns.Contains("UpdatedTransactionDate")
                    ? "UpdatedTransactionDate"
                    : null;

            if (string.IsNullOrEmpty(amountColumn) || string.IsNullOrEmpty(dateColumn))
                return null;

            return dtTransactions;
        }

        private void _EnsureTransactionAnalyticsPanel()
        {
            if (_pnlTransactionAnalytics != null)
                return;

            _pnlTransactionAnalytics = new Guna2CustomGradientPanel
            {
                Name = "pnlTransactionAnalytics",
                BorderRadius = 20,
                FillColor = Color.White,
                FillColor2 = Color.White,
                FillColor3 = Color.White,
                FillColor4 = Color.White,
                Location = new Point(40, 400),
                Size = new Size(860, 340)
            };

            _cbAnalyticsMetric = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(20, 15),
                Size = new Size(330, 28)
            };
            _cbAnalyticsMetric.Items.AddRange(new object[]
            {
                "Doanh thu 7 ngày gần nhất",
                "Doanh thu 30 ngày gần nhất",
                "Số giao dịch 30 ngày gần nhất"
            });
            _cbAnalyticsMetric.SelectedIndexChanged += _cbAnalyticsMetric_SelectedIndexChanged;

            _chartRevenueAnalytics = _CreateAnalyticsChart("Xu hướng giao dịch", SeriesChartType.Spline, "RevenueAnalytics");
            _chartRevenueAnalytics.Location = new Point(10, 50);
            _chartRevenueAnalytics.Size = new Size(840, 280);
            _chartRevenueAnalytics.Series[0].IsValueShownAsLabel = false;

            _pnlTransactionAnalytics.Controls.Add(_cbAnalyticsMetric);
            _pnlTransactionAnalytics.Controls.Add(_chartRevenueAnalytics);

            this.Controls.Add(_pnlTransactionAnalytics);
            _pnlTransactionAnalytics.BringToFront();

            _cbAnalyticsMetric.SelectedIndex = 0;
        }

        private void _cbAnalyticsMetric_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTransactionAnalyticsCharts();
        }

        private void LoadDashboardData()
        {
            // 1. Cập nhật các con số thống kê
            CountElements();

            // 1.1 KPI mini cho vận hành
            LoadMiniKpis();

            // 2. Xử lý biểu đồ trạng thái xe
            SetupVehicleChart();

            // 3. Danh sách khách hàng còn đang thuê chưa trả
            LoadActiveRentalsList();

            // 4. Biểu đồ giao dịch trực quan ở khu vực giữa
            LoadTransactionAnalyticsCharts();
        }

        private void SetupVehicleChart()
        {
            int AvailableVehiclesCount = clsVehicle.GetAvailableVehiclesCount();
            int RentedVehiclesCount = Math.Max(0, _AllVehicles - AvailableVehiclesCount);

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

        private void LoadMiniKpis()
        {
            // Booking KPI: tổng đơn, đang thuê, quá hạn (chưa trả) - dùng chung nguồn thống kê
            int totalBookings = clsBooking.GetBookingCount();
            int activeBookings = clsBooking.GetCurrentlyActiveUnreturnedBookingsCount();
            int overdueBookings = clsBooking.GetOverdueUnreturnedBookingsCount();
            int dueTodayBookings = clsBooking.GetDueTodayUnreturnedBookingsCount();
            int pickupTodayBookings = clsBooking.GetPickupTodayUnreturnedBookingsCount();

            _lblBookingMiniKpi.Text = $"Tổng {totalBookings} | Đang thuê {activeBookings} | Quá hạn {overdueBookings}";

            // Return KPI: tổng phụ phí hôm nay
            DataTable dtReturns = clsReturn.GetAllVehicleReturns();
            decimal surchargeToday = 0m;

            if (dtReturns != null && dtReturns.Columns.Contains("ActualReturnDate") && dtReturns.Columns.Contains("AdditionalCharges"))
            {
                DateTime today = DateTime.Today;
                foreach (DataRow row in dtReturns.Rows)
                {
                    if (!(row["ActualReturnDate"] is DateTime returnDate) || returnDate.Date != today)
                        continue;

                    if (decimal.TryParse(Convert.ToString(row["AdditionalCharges"], CultureInfo.InvariantCulture), out decimal surcharge))
                        surchargeToday += surcharge;
                }
            }

            _lblReturnMiniKpi.Text = $"Phụ phí hôm nay: {surchargeToday:N0} VNĐ";

            // Transaction KPI: tổng thu hôm nay/tháng
            DataTable dtTransactions = clsTransaction.GetAllRentalTransaction();
            decimal totalToday = 0m;
            decimal totalMonth = 0m;

            if (dtTransactions != null)
            {
                string amountColumn = dtTransactions.Columns.Contains("PaidInitialTotalDueAmount")
                    ? "PaidInitialTotalDueAmount"
                    : dtTransactions.Columns.Contains("Amount") ? "Amount" : null;

                if (!string.IsNullOrEmpty(amountColumn) && dtTransactions.Columns.Contains("TransactionDate"))
                {
                    DateTime today = DateTime.Today;
                    DateTime monthStart = new DateTime(today.Year, today.Month, 1);

                    foreach (DataRow row in dtTransactions.Rows)
                    {
                        if (!(row["TransactionDate"] is DateTime transactionDate))
                            continue;

                        if (!decimal.TryParse(Convert.ToString(row[amountColumn], CultureInfo.InvariantCulture), out decimal amount))
                            continue;

                        if (transactionDate.Date == today)
                            totalToday += amount;

                        if (transactionDate.Date >= monthStart && transactionDate.Date <= today)
                            totalMonth += amount;
                    }
                }
            }

            _lblTransactionMiniKpi.Text = $"Hôm nay {totalToday:N0} | Tháng {totalMonth:N0}";
            _lblLastUpdated.Text = $"Cập nhật lúc: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
        }

        private void LoadTransactionAnalyticsCharts()
        {
            if (_chartRevenueAnalytics == null || _cbAnalyticsMetric == null)
                return;

            DataTable dtTransactions = _GetTransactionsDataForAnalytics(out string amountColumn, out string dateColumn);
            if (dtTransactions == null)
                return;

            DateTime today = DateTime.Today;
            int selectedMetric = _cbAnalyticsMetric.SelectedIndex;

            int daysBack = (selectedMetric == 0) ? 6 : 29;
            DateTime startDate = today.AddDays(-daysBack);

            Dictionary<DateTime, decimal> valuesByDay = new Dictionary<DateTime, decimal>();
            for (DateTime d = startDate; d <= today; d = d.AddDays(1))
                valuesByDay[d] = 0m;

            foreach (DataRow row in dtTransactions.Rows)
            {
                if (!_TryGetDateTime(row[dateColumn], out DateTime transactionDate))
                    continue;

                _TryGetDecimal(row[amountColumn], out decimal amount);

                DateTime txDate = transactionDate.Date;

                if (txDate < startDate || txDate > today)
                    continue;

                if (selectedMetric == 2)
                    valuesByDay[txDate] += 1;
                else
                    valuesByDay[txDate] += amount;
            }

            Series series = _chartRevenueAnalytics.Series[0];
            series.Points.Clear();
            series.Color = (selectedMetric == 2) ? Color.FromArgb(124, 58, 237) : Color.FromArgb(0, 118, 212);
            series.BorderWidth = 3;
            series.ChartType = SeriesChartType.Spline;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 6;
            series.MarkerColor = series.Color;
            series.IsValueShownAsLabel = true;
            series.LabelForeColor = Color.FromArgb(31, 41, 55);
            series.Font = new Font("Segoe UI", 8F, FontStyle.Bold);

            decimal totalValue = 0m;

            foreach (var point in valuesByDay.OrderBy(k => k.Key))
            {
                DataPoint p = new DataPoint();
                p.SetValueXY(point.Key.ToString("dd/MM"), point.Value);
                p.Label = point.Value > 0 ? point.Value.ToString("N0") : string.Empty;
                series.Points.Add(p);
                totalValue += point.Value;
            }

            if (_chartRevenueAnalytics.Titles.Count > 0)
            {
                _chartRevenueAnalytics.Titles[0].Text = (selectedMetric == 0)
                    ? "Doanh thu 7 ngày gần nhất"
                    : (selectedMetric == 1)
                        ? "Doanh thu 30 ngày gần nhất"
                        : "Số giao dịch 30 ngày gần nhất";
            }

            if (totalValue <= 0)
            {
                _chartRevenueAnalytics.Titles[0].Text += " (không có dữ liệu trong khoảng)";
            }

            _chartRevenueAnalytics.ChartAreas[0].AxisY.LabelStyle.Format = (selectedMetric == 2) ? "N0" : "N0";
            _chartRevenueAnalytics.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
            _chartRevenueAnalytics.ChartAreas[0].RecalculateAxesScale();

            _lblLastUpdated.Text = $"Cập nhật lúc: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
        }

        private bool _TryGetDateTime(object value, out DateTime dateTime)
        {
            if (value is DateTime dt)
            {
                dateTime = dt;
                return true;
            }

            return DateTime.TryParse(Convert.ToString(value, CultureInfo.CurrentCulture), out dateTime)
                   || DateTime.TryParse(Convert.ToString(value, CultureInfo.InvariantCulture), out dateTime);
        }

        private bool _TryGetDecimal(object value, out decimal amount)
        {
            if (value is decimal d)
            {
                amount = d;
                return true;
            }

            if (value is double db)
            {
                amount = Convert.ToDecimal(db);
                return true;
            }

            if (value is int i)
            {
                amount = i;
                return true;
            }

            return decimal.TryParse(Convert.ToString(value, CultureInfo.CurrentCulture), NumberStyles.Any, CultureInfo.CurrentCulture, out amount)
                   || decimal.TryParse(Convert.ToString(value, CultureInfo.InvariantCulture), NumberStyles.Any, CultureInfo.InvariantCulture, out amount);
        }
    }
}