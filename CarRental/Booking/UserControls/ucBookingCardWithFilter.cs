using CarRental.Customers.UserControls;
using CarRental.GlobalClasses;
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

namespace CarRental.Booking.UserControls
{
    public partial class ucBookingCardWithFilter : UserControl
    {
        private DataTable _dtBookingSource;
        private readonly HashSet<string> _autoCompleteValues = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public ucBookingCardWithFilter()
        {
            InitializeComponent();
        }

        #region Declare Event
        public class BookingSelectedEventArgs : EventArgs
        {
            public int? BookingID { get; }

            public BookingSelectedEventArgs(int? BookingID)
            {
                this.BookingID = BookingID;
            }
        }

        public event EventHandler<BookingSelectedEventArgs> OnBookingSelected;

        public void RaiseOnBookingSelected(int? BookingID)
        {
            RaiseOnBookingSelected(new BookingSelectedEventArgs(BookingID));
        }

        protected virtual void RaiseOnBookingSelected(BookingSelectedEventArgs e)
        {
            OnBookingSelected?.Invoke(this, e);
        }
        #endregion

        private bool _ShowAddBookingButton = true;
        public bool ShowAddBookingButton
        {
            get => _ShowAddBookingButton;

            set
            {
                _ShowAddBookingButton = value;
                btnAddNew.Visible = _ShowAddBookingButton;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get => _FilterEnabled;

            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }

        public int? BookingID => ucBookingCard1.BookingID;
        public clsBooking SelectedBookingInfo => ucBookingCard1.BookingInfo;

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we don't continue because the form is not valid
                MessageBox.Show("Một số trường chưa hợp lệ, hãy di chuột lên biểu tượng màu đỏ để xem chi tiết lỗi.",
                    "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (!_TryResolveBookingID(txtFilterValue.Text.Trim(), out int bookingID))
            {
                MessageBox.Show("Không tìm thấy lịch đặt theo mã/tên khách hàng đã nhập.",
                    "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadBookingInfo(bookingID);
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidateRequired(txtFilterValue, errorProvider1, e);
        }

        private void ucBookingCardWithFilter_Load(object sender, EventArgs e)
        {
            _LoadBookingAutoComplete();
            cbSearchBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }

        private void _LoadBookingAutoComplete()
        {
            _dtBookingSource = clsBooking.GetAllRentalBooking();
            _autoCompleteValues.Clear();

            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            if (_dtBookingSource != null)
            {
                foreach (DataRow row in _dtBookingSource.Rows)
                {
                    string id = row.Table.Columns.Contains("BookingID") ? row["BookingID"].ToString() : string.Empty;
                    string name = row.Table.Columns.Contains("CustomerName") ? row["CustomerName"].ToString() : string.Empty;

                    if (!string.IsNullOrWhiteSpace(id) && _autoCompleteValues.Add(id))
                        source.Add(id);

                    if (!string.IsNullOrWhiteSpace(name) && _autoCompleteValues.Add(name))
                        source.Add(name);

                    string composite = $"{id} - {name}";
                    if (!string.IsNullOrWhiteSpace(id) && !string.IsNullOrWhiteSpace(name) && _autoCompleteValues.Add(composite))
                        source.Add(composite);
                }
            }

            txtFilterValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtFilterValue.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtFilterValue.AutoCompleteCustomSource = source;
        }

        private bool _TryResolveBookingID(string input, out int bookingID)
        {
            bookingID = -1;

            if (string.IsNullOrWhiteSpace(input))
                return false;

            input = input.Trim();
            bool allowById = cbSearchBy.SelectedIndex != 2;
            bool allowByName = cbSearchBy.SelectedIndex != 1;

            if (allowById && int.TryParse(input, out bookingID))
                return true;

            int dashIndex = input.IndexOf('-');
            if (allowById && dashIndex > 0)
            {
                string prefix = input.Substring(0, dashIndex).Trim();
                if (int.TryParse(prefix, out bookingID))
                    return true;
            }

            if (!allowByName)
                return false;

            if (_dtBookingSource == null)
                _dtBookingSource = clsBooking.GetAllRentalBooking();

            if (_dtBookingSource == null || !_dtBookingSource.Columns.Contains("BookingID") || !_dtBookingSource.Columns.Contains("CustomerName"))
                return false;

            DataRow matched = _dtBookingSource.AsEnumerable()
                .FirstOrDefault(r => string.Equals((r["CustomerName"]?.ToString() ?? string.Empty).Trim(), input, StringComparison.OrdinalIgnoreCase));

            if (matched == null)
            {
                matched = _dtBookingSource.AsEnumerable()
                    .FirstOrDefault(r => (r["CustomerName"]?.ToString() ?? string.Empty)
                        .Trim().StartsWith(input, StringComparison.OrdinalIgnoreCase));
            }

            if (matched == null)
                return false;

            return int.TryParse(matched["BookingID"].ToString(), out bookingID);
        }

        public void LoadBookingInfo(int? BookingID)
        {
            txtFilterValue.Text = BookingID.ToString();
            ucBookingCard1.LoadBookingInfo(BookingID);

            if (OnBookingSelected != null)
            {
                // Raise the event with a parameter
                RaiseOnBookingSelected(ucBookingCard1.BookingID);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddBooking AddNewBooking = new frmAddBooking();
            AddNewBooking.GetBookingIDByDelegate += LoadBookingInfo;
            AddNewBooking.ShowDialog();
        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        public void Clear()
        {
            ucBookingCard1.Reset();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                btnFind.PerformClick();
            }
        }
    }
}
