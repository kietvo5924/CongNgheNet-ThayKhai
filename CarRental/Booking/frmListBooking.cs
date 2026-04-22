using CarRental.Return;
using CarRental.GlobalClasses;
using CarRental.Return;
using CarRental.Properties;
using CarRental_Business;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Booking
{
    public partial class frmListBooking : Form
    {
        private DataTable _dtAllBooking;
        private const string BookingStatusColumnName = "BookingAlertStatus";
        private const string BookingRealStatusColumnName = "BookingRealStatus";
        private const string BookingAlertPriorityColumnName = "BookingAlertPriority";
        private const string ExportMenuItemName = "miExportBookingsData";
        private readonly Timer _autoRefreshTimer = new Timer();
        private bool _isAutoRefreshing;
        private bool _isAutoRefreshEnabled = true;
        private bool _realStatusQuickButtonsInitialized;
        private bool _quickButtonsRegistered;
        private Guna2Button _btnQuickPendingPickup;
        private Guna2Button _btnQuickActiveRental;
        private Guna2Button _btnQuickOverdueStatus;
        private Guna2Button _btnQuickCompleted;
        private readonly Dictionary<Guna2Button, Color> _quickButtonBaseColors = new Dictionary<Guna2Button, Color>();
        private readonly Dictionary<Guna2Button, Color> _quickButtonBaseForeColors = new Dictionary<Guna2Button, Color>();
        private readonly ToolTip _quickFiltersToolTip = new ToolTip();

        private static string _EscapeRowFilterValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return value.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]");
        }

        private static string _ResolveBookingRealStatus(bool isReturned, DateTime rentalStartDate, DateTime rentalEndDate)
        {
            if (isReturned)
                return "Đã hoàn tất";

            DateTime today = DateTime.Today;

            if (rentalEndDate.Date < today)
                return "Quá hạn";

            if (rentalStartDate.Date > today)
                return "Chờ nhận xe";

            return "Đang thuê";
        }

        private void _UpdateRecordsCount()
        {
            lblNumberOfRecords.Text = (_dtAllBooking == null) ? "0" : _dtAllBooking.DefaultView.Count.ToString();
            _UpdateEmptyState();
        }

        private void _UpdateAlertSummary()
        {
            if (lblAlerts == null || _dtAllBooking == null || !_dtAllBooking.Columns.Contains(BookingStatusColumnName))
            {
                if (lblAlerts != null)
                    lblAlerts.Text = string.Empty;
                return;
            }

            int overdue = _dtAllBooking.AsEnumerable().Count(r => string.Equals(r[BookingStatusColumnName]?.ToString(), "Quá hạn trả xe", StringComparison.Ordinal));
            int dueToday = _dtAllBooking.AsEnumerable().Count(r => string.Equals(r[BookingStatusColumnName]?.ToString(), "Đến hạn trả hôm nay", StringComparison.Ordinal));
            int pickupToday = _dtAllBooking.AsEnumerable().Count(r => string.Equals(r[BookingStatusColumnName]?.ToString(), "Nhận xe hôm nay", StringComparison.Ordinal));

            lblAlerts.Text = $"Cảnh báo: Quá hạn {overdue} | Đến hạn hôm nay {dueToday} | Nhận xe hôm nay {pickupToday}";
        }

        private static int _ResolveBookingAlertPriority(string status)
        {
            switch (status)
            {
                case "Quá hạn trả xe": return 1;
                case "Đến hạn trả hôm nay": return 2;
                case "Nhận xe hôm nay": return 3;
                case "Đang thuê": return 4;
                case "Sắp nhận xe": return 5;
                case "Đã hoàn tất": return 6;
                default: return 9;
            }
        }

        private Guna2Button _CreateQuickStatusButton(string text, Color fillColor, int x, int y)
        {
            return new Guna2Button
            {
                BorderRadius = 6,
                FillColor = fillColor,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(x, y),
                Size = new Size(122, 24),
                Text = text
            };
        }

        private void _EnsureRealStatusQuickButtons()
        {
            if (_realStatusQuickButtonsInitialized)
                return;

            _btnQuickPendingPickup = _CreateQuickStatusButton("Chờ nhận xe", Color.FromArgb(2, 132, 199), 20, 102);
            _btnQuickActiveRental = _CreateQuickStatusButton("Đang thuê", Color.FromArgb(234, 88, 12), 148, 102);
            _btnQuickOverdueStatus = _CreateQuickStatusButton("Quá hạn thuê", Color.FromArgb(220, 38, 38), 276, 102);
            _btnQuickCompleted = _CreateQuickStatusButton("Đã hoàn tất", Color.FromArgb(22, 163, 74), 404, 102);

            _btnQuickPendingPickup.Click += (s, e) => cbFilter.SelectedItem = "Chờ nhận xe";
            _btnQuickActiveRental.Click += (s, e) => cbFilter.SelectedItem = "Đang thuê";
            _btnQuickOverdueStatus.Click += (s, e) => cbFilter.SelectedItem = "Quá hạn";
            _btnQuickCompleted.Click += (s, e) => cbFilter.SelectedItem = "Đã hoàn tất";

            guna2Panel1.Controls.Add(_btnQuickPendingPickup);
            guna2Panel1.Controls.Add(_btnQuickActiveRental);
            guna2Panel1.Controls.Add(_btnQuickOverdueStatus);
            guna2Panel1.Controls.Add(_btnQuickCompleted);

            dgvBookingList.Location = new Point(dgvBookingList.Location.X, 132);
            dgvBookingList.Size = new Size(dgvBookingList.Size.Width, 593);

            _realStatusQuickButtonsInitialized = true;
        }

        private static string _ResolveBookingStatus(bool isReturned, DateTime rentalStartDate, DateTime rentalEndDate)
        {
            if (isReturned)
                return "Đã hoàn tất";

            DateTime today = DateTime.Today;

            if (rentalEndDate.Date < today)
                return "Quá hạn trả xe";

            if (rentalEndDate.Date == today)
                return "Đến hạn trả hôm nay";

            if (rentalStartDate.Date == today)
                return "Nhận xe hôm nay";

            if (rentalStartDate.Date > today)
                return "Sắp nhận xe";

            return "Đang thuê";
        }

        private static void _BuildBookingStatusColumn(DataTable bookingTable)
        {
            if (bookingTable == null)
                return;

            HashSet<int> returnedBookingIDs = clsTransaction.GetReturnedBookingIDs();

            if (!bookingTable.Columns.Contains(BookingStatusColumnName))
                bookingTable.Columns.Add(BookingStatusColumnName, typeof(string));

            if (!bookingTable.Columns.Contains(BookingRealStatusColumnName))
                bookingTable.Columns.Add(BookingRealStatusColumnName, typeof(string));

            if (!bookingTable.Columns.Contains(BookingAlertPriorityColumnName))
                bookingTable.Columns.Add(BookingAlertPriorityColumnName, typeof(int));

            foreach (DataRow row in bookingTable.Rows)
            {
                if (!int.TryParse(row["BookingID"]?.ToString(), out int bookingID))
                {
                    row[BookingStatusColumnName] = "Không xác định";
                    row[BookingRealStatusColumnName] = "Không xác định";
                    row[BookingAlertPriorityColumnName] = _ResolveBookingAlertPriority("Không xác định");
                    continue;
                }

                DateTime rentalStart = row["RentalStartDate"] is DateTime startDate ? startDate : DateTime.Today;
                DateTime rentalEnd = row["RentalEndDate"] is DateTime endDate ? endDate : DateTime.Today;
                bool isReturned = returnedBookingIDs.Contains(bookingID);

                string status = _ResolveBookingStatus(isReturned, rentalStart, rentalEnd);
                string realStatus = _ResolveBookingRealStatus(isReturned, rentalStart, rentalEnd);

                row[BookingStatusColumnName] = status;
                row[BookingRealStatusColumnName] = realStatus;
                row[BookingAlertPriorityColumnName] = _ResolveBookingAlertPriority(status);
            }
        }

        private void _SetLoadingState(bool isLoading)
        {
            this.Cursor = isLoading ? Cursors.WaitCursor : Cursors.Default;

            if (btnAddNewBooking != null)
                btnAddNewBooking.Enabled = !isLoading;

            if (btnToggleAutoRefresh != null)
                btnToggleAutoRefresh.Enabled = !isLoading;

            if (cbFilter != null)
                cbFilter.Enabled = !isLoading;

            if (txtSearch != null)
                txtSearch.Enabled = !isLoading;
        }

        private void _ApplyAlertPrioritySort()
        {
            if (_dtAllBooking == null || !_dtAllBooking.Columns.Contains(BookingAlertPriorityColumnName))
                return;

            if (_dtAllBooking.Columns.Contains("RentalEndDate"))
                _dtAllBooking.DefaultView.Sort = $"[{BookingAlertPriorityColumnName}] ASC, [RentalEndDate] ASC";
            else
                _dtAllBooking.DefaultView.Sort = $"[{BookingAlertPriorityColumnName}] ASC";
        }

        private void _ApplyAlertFilterIfNeeded()
        {
            if (_dtAllBooking == null || !_dtAllBooking.Columns.Contains(BookingStatusColumnName))
                return;

            switch (cbFilter.Text)
            {
                case "Cảnh báo quá hạn":
                    _dtAllBooking.DefaultView.RowFilter = $"[{BookingStatusColumnName}] = 'Quá hạn trả xe'";
                    break;
                case "Đến hạn hôm nay":
                    _dtAllBooking.DefaultView.RowFilter = $"[{BookingStatusColumnName}] = 'Đến hạn trả hôm nay'";
                    break;
                case "Nhận xe hôm nay":
                    _dtAllBooking.DefaultView.RowFilter = $"[{BookingStatusColumnName}] = 'Nhận xe hôm nay'";
                    break;
                default:
                    break;
            }
        }

        private void _ApplySelectedFilter()
        {
            if (_dtAllBooking == null)
                return;

            bool isNoneFilter = cbFilter.Text == "Không lọc";
            bool isDateFilter = cbFilter.Text == "Ngày nhận xe" || cbFilter.Text == "Ngày trả xe";
            bool isAlertFilter = cbFilter.Text == "Cảnh báo quá hạn" || cbFilter.Text == "Đến hạn hôm nay" || cbFilter.Text == "Nhận xe hôm nay";
            bool isRealStatusFilter = cbFilter.Text == "Chờ nhận xe" || cbFilter.Text == "Đang thuê" || cbFilter.Text == "Quá hạn" || cbFilter.Text == "Đã hoàn tất";

            if (isNoneFilter)
                _dtAllBooking.DefaultView.RowFilter = "";
            else if (isDateFilter)
                dtpDate_ValueChanged(dtpDate, EventArgs.Empty);
            else if (isAlertFilter)
                _ApplyAlertFilterIfNeeded();
            else if (isRealStatusFilter)
                _dtAllBooking.DefaultView.RowFilter = $"[{BookingRealStatusColumnName}] = '{_EscapeRowFilterValue(cbFilter.Text)}'";
            else
                txtSearch_TextChanged(txtSearch, EventArgs.Empty);

            _ApplyAlertPrioritySort();
            _UpdateRecordsCount();
        }

        private void _UpdateEmptyState()
        {
            if (lblEmptyState == null)
                return;

            bool hasData = _dtAllBooking != null && _dtAllBooking.DefaultView.Count > 0;
            lblEmptyState.Visible = !hasData;

            if (!hasData)
                lblEmptyState.BringToFront();
        }

        private bool _TryGetSelectedBookingID(out int bookingID)
        {
            bookingID = -1;

            if (dgvBookingList.CurrentRow == null || dgvBookingList.CurrentRow.Cells["BookingID"] == null)
                return false;

            object value = dgvBookingList.CurrentRow.Cells["BookingID"].Value;
            return value != null && int.TryParse(value.ToString(), out bookingID);
        }

        public frmListBooking()
        {
            InitializeComponent();

            _autoRefreshTimer.Interval = 60000;
            _autoRefreshTimer.Tick += _autoRefreshTimer_Tick;
            this.FormClosed += frmListBooking_FormClosed;

            _isAutoRefreshEnabled = Settings.Default.BookingAutoRefreshEnabled;

            _UpdateAutoRefreshButtonUi();
        }

        private void _UpdateAutoRefreshButtonUi()
        {
            if (btnToggleAutoRefresh == null)
                return;

            btnToggleAutoRefresh.Text = _isAutoRefreshEnabled ? "Tự làm mới: Bật" : "Tự làm mới: Tắt";
            btnToggleAutoRefresh.FillColor = _isAutoRefreshEnabled
                ? Color.FromArgb(22, 163, 74)
                : Color.FromArgb(107, 114, 128);
        }

        private void _RegisterQuickFilterButton(Guna2Button button, string filterText, string toolTipText)
        {
            if (button == null || _quickButtonBaseColors.ContainsKey(button))
                return;

            button.Tag = filterText;
            _quickButtonBaseColors[button] = button.FillColor;
            _quickButtonBaseForeColors[button] = button.ForeColor;
            _quickFiltersToolTip.SetToolTip(button, toolTipText);
        }

        private void _RegisterQuickFilterButtonsIfNeeded()
        {
            if (_quickButtonsRegistered)
                return;

            _RegisterQuickFilterButton(btnQuickOverdue, "Cảnh báo quá hạn", "Hiển thị các lịch đặt đã quá hạn trả xe.");
            _RegisterQuickFilterButton(btnQuickDueToday, "Đến hạn hôm nay", "Hiển thị các lịch đặt đến hạn trả trong hôm nay.");
            _RegisterQuickFilterButton(btnQuickPickupToday, "Nhận xe hôm nay", "Hiển thị các lịch đặt nhận xe trong hôm nay.");
            _RegisterQuickFilterButton(btnQuickClearAlerts, "Không lọc", "Xóa bộ lọc cảnh báo và quay lại danh sách đầy đủ.");
            _RegisterQuickFilterButton(_btnQuickPendingPickup, "Chờ nhận xe", "Hiển thị các lịch đặt chưa đến ngày nhận xe.");
            _RegisterQuickFilterButton(_btnQuickActiveRental, "Đang thuê", "Hiển thị các lịch đặt đang thuê.");
            _RegisterQuickFilterButton(_btnQuickOverdueStatus, "Quá hạn", "Hiển thị các lịch đặt đã quá hạn và chưa trả.");
            _RegisterQuickFilterButton(_btnQuickCompleted, "Đã hoàn tất", "Hiển thị các lịch đặt đã hoàn tất (đã trả xe).");

            _quickButtonsRegistered = true;
        }

        private void _UpdateQuickFilterButtonsVisualState()
        {
            foreach (var pair in _quickButtonBaseColors)
            {
                Guna2Button button = pair.Key;
                string targetFilter = button.Tag as string;
                bool isActive = string.Equals(cbFilter.Text, targetFilter, StringComparison.Ordinal);

                if (isActive)
                {
                    button.FillColor = Color.FromArgb(0, 118, 212);
                    button.ForeColor = Color.White;
                }
                else
                {
                    button.FillColor = pair.Value;
                    button.ForeColor = _quickButtonBaseForeColors.ContainsKey(button)
                        ? _quickButtonBaseForeColors[button]
                        : Color.White;
                }
            }
        }

        private void frmListBooking_FormClosed(object sender, FormClosedEventArgs e)
        {
            _autoRefreshTimer.Stop();
            Settings.Default.BookingAutoRefreshEnabled = _isAutoRefreshEnabled;
            Settings.Default.Save();
        }

        private void _autoRefreshTimer_Tick(object sender, EventArgs e)
        {
            if (!_isAutoRefreshEnabled)
                return;

            if (!this.Visible || this.WindowState == FormWindowState.Minimized || !this.ContainsFocus)
                return;

            if (_isAutoRefreshing)
                return;

            _isAutoRefreshing = true;
            try
            {
                int? selectedBookingID = null;
                if (_TryGetSelectedBookingID(out int bookingID))
                    selectedBookingID = bookingID;

                _RefreshBookingList();
                _ApplySelectedFilter();

                if (selectedBookingID.HasValue)
                    _TrySelectBookingByID(selectedBookingID.Value);
            }
            finally
            {
                _isAutoRefreshing = false;
            }
        }

        private void btnToggleAutoRefresh_Click(object sender, EventArgs e)
        {
            _isAutoRefreshEnabled = !_isAutoRefreshEnabled;
            _UpdateAutoRefreshButtonUi();
            Settings.Default.BookingAutoRefreshEnabled = _isAutoRefreshEnabled;
            Settings.Default.Save();

            if (_isAutoRefreshEnabled && this.Visible)
                _autoRefreshTimer_Tick(_autoRefreshTimer, EventArgs.Empty);
        }

        private void _TrySelectBookingByID(int bookingID)
        {
            foreach (DataGridViewRow row in dgvBookingList.Rows)
            {
                if (row.Cells["BookingID"]?.Value == null)
                    continue;

                if (int.TryParse(row.Cells["BookingID"].Value.ToString(), out int currentID) && currentID == bookingID)
                {
                    dgvBookingList.ClearSelection();
                    row.Selected = true;
                    if (row.Cells.Count > 0)
                        dgvBookingList.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Mã lịch đặt": return "BookingID";
                case "Mã khách hàng": return "CustomerID";
                case "Tên khách hàng": return "CustomerName";
                case "Mã xe": return "VehicleID";
                case "Ngày nhận xe": return "RentalStartDate";
                case "Ngày trả xe": return "RentalEndDate";
                case "Điểm nhận": return "PickupLocation";
                case "Điểm trả": return "DropoffLocation";
                default: return "None";
            }
        }

        private async Task _RefreshBookingListAsync()
        {
            _SetLoadingState(true);

            try
            {
                DataTable loadedBookings = await Task.Run(() =>
                {
                    DataTable bookings = clsBooking.GetAllRentalBooking();
                    _BuildBookingStatusColumn(bookings);
                    return bookings;
                });

                _dtAllBooking = loadedBookings;
                dgvBookingList.DataSource = _dtAllBooking;
                _ApplyAlertPrioritySort();
                _UpdateRecordsCount();
                _UpdateAlertSummary();

                if (dgvBookingList.Rows.Count > 0)
                {
                    dgvBookingList.Columns[0].HeaderText = "Mã đặt";
                    dgvBookingList.Columns[1].HeaderText = "Khách hàng";
                    dgvBookingList.Columns[2].HeaderText = "Mã KH";
                    dgvBookingList.Columns[3].HeaderText = "Mã xe";
                    dgvBookingList.Columns[4].HeaderText = "Ngày thuê";
                    dgvBookingList.Columns[5].HeaderText = "Ngày trả";
                    dgvBookingList.Columns[6].HeaderText = "Điểm nhận";
                    dgvBookingList.Columns[7].HeaderText = "Điểm trả";
                    dgvBookingList.Columns[8].HeaderText = "Giá/Ngày";
                    dgvBookingList.Columns[9].HeaderText = "Số ngày";
                    dgvBookingList.Columns[10].HeaderText = "Tổng tiền";
                    if (dgvBookingList.Columns.Contains(BookingStatusColumnName))
                        dgvBookingList.Columns[BookingStatusColumnName].HeaderText = "Trạng thái";
                    if (dgvBookingList.Columns.Contains(BookingRealStatusColumnName))
                        dgvBookingList.Columns[BookingRealStatusColumnName].HeaderText = "Tình trạng thuê";
                    if (dgvBookingList.Columns.Contains(BookingAlertPriorityColumnName))
                        dgvBookingList.Columns[BookingAlertPriorityColumnName].Visible = false;

                    var rentalPriceColumn = dgvBookingList.Columns["RentalPricePerDay"];
                    if (rentalPriceColumn != null)
                    {
                        rentalPriceColumn.DefaultCellStyle.Format = "N0";
                        rentalPriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    else if (dgvBookingList.Columns.Count > 8)
                    {
                        dgvBookingList.Columns[8].DefaultCellStyle.Format = "N0";
                        dgvBookingList.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    var initialTotalColumn = dgvBookingList.Columns["InitialTotalDueAmount"];
                    if (initialTotalColumn != null)
                    {
                        initialTotalColumn.DefaultCellStyle.Format = "N0";
                        initialTotalColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    else if (dgvBookingList.Columns.Count > 10)
                    {
                        dgvBookingList.Columns[10].DefaultCellStyle.Format = "N0";
                        dgvBookingList.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    dgvBookingList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải dữ liệu từ máy chủ. Vui lòng kiểm tra kết nối mạng.\nChi tiết: {ex.Message}",
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _SetLoadingState(false);
            }
        }

        private async void _RefreshBookingList()
        {
            await _RefreshBookingListAsync();
        }

        private async void frmListBooking_Load(object sender, EventArgs e)
        {
            dgvBookingList.CellMouseDown += dgvBookingList_CellMouseDown;
            dgvBookingList.CellFormatting += dgvBookingList_CellFormatting;
            _EnsureExportMenuItem();
            _EnsureRealStatusQuickButtons();
            _RegisterQuickFilterButtonsIfNeeded();

            if (!cbFilter.Items.Contains("Cảnh báo quá hạn")) cbFilter.Items.Add("Cảnh báo quá hạn");
            if (!cbFilter.Items.Contains("Đến hạn hôm nay")) cbFilter.Items.Add("Đến hạn hôm nay");
            if (!cbFilter.Items.Contains("Nhận xe hôm nay")) cbFilter.Items.Add("Nhận xe hôm nay");
            if (!cbFilter.Items.Contains("Chờ nhận xe")) cbFilter.Items.Add("Chờ nhận xe");
            if (!cbFilter.Items.Contains("Đang thuê")) cbFilter.Items.Add("Đang thuê");
            if (!cbFilter.Items.Contains("Quá hạn")) cbFilter.Items.Add("Quá hạn");
            if (!cbFilter.Items.Contains("Đã hoàn tất")) cbFilter.Items.Add("Đã hoàn tất");

            await _RefreshBookingListAsync();
            cbFilter.SelectedIndex = 0;
            _UpdateQuickFilterButtonsVisualState();

            _autoRefreshTimer.Start();
        }

        private void _EnsureExportMenuItem()
        {
            if (cmsEditProfile.Items[ExportMenuItemName] != null)
                return;

            cmsEditProfile.Items.Add(new ToolStripSeparator());
            ToolStripMenuItem exportItem = new ToolStripMenuItem("Xuất dữ liệu (CSV/Excel/PDF)")
            {
                Name = ExportMenuItemName
            };
            exportItem.Click += (s, e) => clsUtil.ExportDataGridView(dgvBookingList, "DanhSachDatXe", "Danh sách đặt xe");
            cmsEditProfile.Items.Add(exportItem);
        }

        private void dgvBookingList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvBookingList.Columns[e.ColumnIndex].Name != BookingStatusColumnName || e.Value == null)
            {
                if (dgvBookingList.Columns[e.ColumnIndex].Name != BookingRealStatusColumnName || e.Value == null)
                    return;

                string realStatus = e.Value.ToString();
                if (realStatus == "Quá hạn")
                    e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                else if (realStatus == "Chờ nhận xe")
                    e.CellStyle.ForeColor = Color.FromArgb(2, 132, 199);
                else if (realStatus == "Đã hoàn tất")
                    e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74);
                else if (realStatus == "Đang thuê")
                    e.CellStyle.ForeColor = Color.FromArgb(234, 88, 12);

                return;
            }

            string status = e.Value.ToString();
            if (status == "Quá hạn trả xe")
                e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38);
            else if (status == "Đến hạn trả hôm nay")
                e.CellStyle.ForeColor = Color.FromArgb(234, 88, 12);
            else if (status == "Nhận xe hôm nay")
                e.CellStyle.ForeColor = Color.FromArgb(2, 132, 199);
            else if (status == "Đã hoàn tất")
                e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74);
        }

        private void dgvBookingList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.Button == MouseButtons.Right)
            {
                dgvBookingList.ClearSelection();
                dgvBookingList.Rows[e.RowIndex].Selected = true;
                dgvBookingList.CurrentCell = dgvBookingList.Rows[e.RowIndex].Cells[0];
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isNoneFilter = cbFilter.Text == "Không lọc";
            bool isDateFilter = cbFilter.Text == "Ngày nhận xe" || cbFilter.Text == "Ngày trả xe";
            bool isAlertFilter = cbFilter.Text == "Cảnh báo quá hạn" || cbFilter.Text == "Đến hạn hôm nay" || cbFilter.Text == "Nhận xe hôm nay";
            bool isRealStatusFilter = cbFilter.Text == "Chờ nhận xe" || cbFilter.Text == "Đang thuê" || cbFilter.Text == "Quá hạn" || cbFilter.Text == "Đã hoàn tất";

            txtSearch.Visible = !isNoneFilter && !isDateFilter && !isAlertFilter && !isRealStatusFilter;
            dtpDate.Visible = isDateFilter;

            if (txtSearch.Visible)
            {
                txtSearch.Clear();
                txtSearch.Focus();
            }

            if (_dtAllBooking != null)
                _dtAllBooking.DefaultView.RowFilter = "";

            _ApplySelectedFilter();
            _UpdateQuickFilterButtonsVisualState();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllBooking == null || _dtAllBooking.Rows.Count == 0) return;

            string ColumnName = _GetRealColumnNameInDB();
            string FilterValue = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(FilterValue) || cbFilter.Text == "Không lọc")
            {
                _dtAllBooking.DefaultView.RowFilter = "";
            }
            else
            {
                bool isNumeric = cbFilter.Text == "Mã lịch đặt" || cbFilter.Text == "Mã khách hàng" || cbFilter.Text == "Mã xe";
                if (isNumeric)
                {
                    if (int.TryParse(FilterValue, out int idValue))
                        _dtAllBooking.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, idValue);
                    else
                        _dtAllBooking.DefaultView.RowFilter = "1 = 0";
                }
                else
                    _dtAllBooking.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, _EscapeRowFilterValue(FilterValue));
            }
            _UpdateRecordsCount();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool isNumeric = cbFilter.Text == "Mã lịch đặt" || cbFilter.Text == "Mã khách hàng" || cbFilter.Text == "Mã xe";
            if (isNumeric)
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (_dtAllBooking == null || _dtAllBooking.Rows.Count == 0) return;

            string ColumnName = (cbFilter.Text == "Ngày nhận xe") ? "RentalStartDate" : "RentalEndDate";
            _dtAllBooking.DefaultView.RowFilter = string.Format("CONVERT([{0}], 'System.DateTime') >= #{1}# AND CONVERT([{0}], 'System.DateTime') < #{2}#",
                ColumnName,
                dtpDate.Value.Date.ToString("MM/dd/yyyy"),
                dtpDate.Value.Date.AddDays(1).ToString("MM/dd/yyyy"));
            _ApplyAlertPrioritySort();
            _UpdateRecordsCount();
        }

        private void btnQuickOverdue_Click(object sender, EventArgs e)
        {
            cbFilter.SelectedItem = "Cảnh báo quá hạn";
        }

        private void btnQuickDueToday_Click(object sender, EventArgs e)
        {
            cbFilter.SelectedItem = "Đến hạn hôm nay";
        }

        private void btnQuickPickupToday_Click(object sender, EventArgs e)
        {
            cbFilter.SelectedItem = "Nhận xe hôm nay";
        }

        private void btnQuickClearAlerts_Click(object sender, EventArgs e)
        {
            cbFilter.SelectedItem = "Không lọc";
        }

        private async void btnAddNewBooking_Click(object sender, EventArgs e)
        {
            frmAddBooking frm = new frmAddBooking();
            frm.ShowDialog();
            await _RefreshBookingListAsync();
        }

        private async void cancelBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_TryGetSelectedBookingID(out int bookingID))
            {
                MessageBox.Show("Vui lòng chọn lịch đặt cần hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            clsBooking booking = clsBooking.Find(bookingID);
            if (booking == null)
            {
                MessageBox.Show("Không tìm thấy lịch đặt để hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (booking.IsBookingReturned)
            {
                MessageBox.Show("Lịch đặt đã hoàn tất trả xe nên không thể hủy.", "Không thể hủy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (booking.RentalStartDate.Date <= DateTime.Today)
            {
                MessageBox.Show("Đơn đã đến ngày nhận xe hoặc đang thuê. Vui lòng xử lý theo luồng trả xe, không hủy đăng ký.",
                    "Không thể hủy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn hủy lịch đặt xe này?", "Xác nhận hủy đặt xe",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            bool cancelled = false;
            clsTransaction transaction = clsTransaction.FindByBookingID(bookingID);

            if (transaction != null)
                cancelled = transaction.DeleteTransaction();
            else
                cancelled = booking.DeleteBooking();

            if (cancelled)
            {
                MessageBox.Show("Hủy đăng ký đặt xe thành công.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await _RefreshBookingListAsync();
            }
            else
            {
                MessageBox.Show("Không thể hủy đăng ký đặt xe. Có thể đơn đã phát sinh dữ liệu liên quan.",
                    "Không thể hủy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void ShowBookingDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!_TryGetSelectedBookingID(out int bookingID))
            {
                MessageBox.Show("Vui lòng chọn lịch đặt cần xem.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmShowBookingDetailsWithCustomerAndVehicle frm = new frmShowBookingDetailsWithCustomerAndVehicle(bookingID);
            frm.ShowDialog();
            await _RefreshBookingListAsync();
        }

        private async void ReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_TryGetSelectedBookingID(out int bookingID))
            {
                MessageBox.Show("Vui lòng chọn lịch đặt cần trả xe.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmReturnVehicle frm = new frmReturnVehicle(bookingID);
            frm.ShowDialog();
            await _RefreshBookingListAsync();
        }

        private void dgvBookingList_DoubleClick(object sender, EventArgs e)
        {
            if (dgvBookingList.Rows.Count > 0)
                ShowBookingDetailsToolStripMenuItem1.PerformClick();
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            if (!_TryGetSelectedBookingID(out int bookingID))
            {
                e.Cancel = true;
                return;
            }

            clsBooking Booking = clsBooking.Find(bookingID);
            ReturnToolStripMenuItem.Enabled = (Booking != null && !Booking.IsBookingReturned);
            cancelBookingToolStripMenuItem.Enabled = (Booking != null && !Booking.IsBookingReturned && Booking.RentalStartDate.Date > DateTime.Today);
        }
    }
}