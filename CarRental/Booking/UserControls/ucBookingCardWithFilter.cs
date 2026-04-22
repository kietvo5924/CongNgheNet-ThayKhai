using CarRental.Customers.UserControls;
using CarRental.GlobalClasses;
using CarRental_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private AutoCompleteStringCollection _defaultAutoCompleteSource;
        private ToolStripDropDown _suggestionsMenu;
        private ListBox _suggestionsListBox;

        public ucBookingCardWithFilter()
        {
            InitializeComponent();
            _InitializeSuggestionsDropDown();
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

        private async void btnFind_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            btnFind.Enabled = false;

            try
            {
            if (!this.ValidateChildren())
            {
                //Here we don't continue because the form is not valid
                MessageBox.Show("Một số trường chưa hợp lệ, hãy di chuột lên biểu tượng màu đỏ để xem chi tiết lỗi.",
                    "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (_defaultAutoCompleteSource != null)
                txtFilterValue.AutoCompleteCustomSource = _defaultAutoCompleteSource;

            await _EnsureBookingSourceLoadedAsync();

            string filterValue = txtFilterValue.Text.Trim();

            if (!_TryResolveBookingID(filterValue, out int bookingID))
            {
                if (_TrySuggestBookingSelection(filterValue, out List<string> suggestionsPreview))
                {
                    _ShowSuggestionsDropDown(suggestionsPreview);
                    return;
                }

                _HideSuggestionsDropDown();
                MessageBox.Show("Không tìm thấy lịch đặt theo mã/tên khách hàng đã nhập.",
                    "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _HideSuggestionsDropDown();

            await LoadBookingInfoAsync(bookingID);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải dữ liệu từ máy chủ. Vui lòng kiểm tra kết nối mạng.\nChi tiết: {ex.Message}",
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnFind.Enabled = true;
            }
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidateRequired(txtFilterValue, errorProvider1, e);
        }

        private async void ucBookingCardWithFilter_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            btnFind.Enabled = false;

            try
            {
                await _LoadBookingAutoCompleteAsync();
                cbSearchBy.SelectedIndex = 0;
                txtFilterValue.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải dữ liệu từ máy chủ. Vui lòng kiểm tra kết nối mạng.\nChi tiết: {ex.Message}",
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnFind.Enabled = true;
            }
        }

        private async Task _EnsureBookingSourceLoadedAsync()
        {
            if (_dtBookingSource == null)
                _dtBookingSource = await Task.Run(() => clsBooking.GetAllRentalBooking());
        }

        private async Task _LoadBookingAutoCompleteAsync()
        {
            await _EnsureBookingSourceLoadedAsync();
            _autoCompleteValues.Clear();

            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            if (_dtBookingSource != null)
            {
                foreach (DataRow row in _dtBookingSource.Rows)
                {
                    string id = row.Table.Columns.Contains("BookingID") ? row["BookingID"].ToString() : string.Empty;
                    string name = row.Table.Columns.Contains("CustomerName") ? row["CustomerName"].ToString() : string.Empty;

                    if (!string.IsNullOrWhiteSpace(name) && _autoCompleteValues.Add(name))
                        source.Add(name);

                    if (!string.IsNullOrWhiteSpace(id) && !string.IsNullOrWhiteSpace(name))
                    {
                        string composite = $"{id} - {name}";
                        if (_autoCompleteValues.Add(composite))
                            source.Add(composite);
                    }
                    else if (!string.IsNullOrWhiteSpace(id) && _autoCompleteValues.Add(id))
                    {
                        source.Add(id);
                    }
                }
            }

            txtFilterValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtFilterValue.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtFilterValue.AutoCompleteCustomSource = source;
            _defaultAutoCompleteSource = source;
        }

        private bool _TryResolveBookingID(string input, out int bookingID)
        {
            bookingID = -1;

            if (string.IsNullOrWhiteSpace(input))
                return false;

            input = input.Trim();
            string normalizedInput = _NormalizeSearchText(input);
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

            if (_dtBookingSource == null || !_dtBookingSource.Columns.Contains("BookingID") || !_dtBookingSource.Columns.Contains("CustomerName"))
                return false;

            DataRow matched = _dtBookingSource.AsEnumerable()
                .FirstOrDefault(r => _IsExactNameMatch(r["CustomerName"]?.ToString(), normalizedInput));

            if (matched == null)
                return false;

            return int.TryParse(matched["BookingID"].ToString(), out bookingID);
        }

        private bool _TrySuggestBookingSelection(string input, out List<string> suggestionsPreview)
        {
            suggestionsPreview = new List<string>();

            if (string.IsNullOrWhiteSpace(input))
                return false;

            if (_dtBookingSource == null || !_dtBookingSource.Columns.Contains("BookingID") || !_dtBookingSource.Columns.Contains("CustomerName"))
                return false;

            string normalizedInput = _NormalizeSearchText(input);
            List<DataRow> matches = _dtBookingSource.AsEnumerable()
                .Where(r => _IsNameSuggestionMatch(r["CustomerName"]?.ToString(), normalizedInput))
                .Take(20)
                .ToList();

            if (matches.Count == 0)
                return false;

            AutoCompleteStringCollection suggestions = new AutoCompleteStringCollection();
            HashSet<string> distinct = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            HashSet<string> distinctPreview = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (DataRow row in matches)
            {
                string id = row["BookingID"]?.ToString();
                string name = row["CustomerName"]?.ToString();
                string composite = $"{id} - {name}";

                if (!string.IsNullOrWhiteSpace(name) && distinct.Add(name))
                    suggestions.Add(name);

                if (!string.IsNullOrWhiteSpace(composite) && distinct.Add(composite))
                    suggestions.Add(composite);

                if (!string.IsNullOrWhiteSpace(composite))
                    distinctPreview.Add(composite);
            }

            txtFilterValue.AutoCompleteCustomSource = suggestions;
            txtFilterValue.SelectionStart = txtFilterValue.TextLength;
            txtFilterValue.SelectionLength = 0;

            suggestionsPreview = distinctPreview.Take(8).ToList();

            txtFilterValue.Focus();
            return true;
        }

        private static string _NormalizeSearchText(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            string trimmed = value.Trim();
            string normalized = trimmed.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder(normalized.Length);

            foreach (char c in normalized)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(c);
                if (uc != UnicodeCategory.NonSpacingMark)
                    sb.Append(char.ToUpperInvariant(c));
            }

            return sb.ToString()
                .Replace('Đ', 'D')
                .Replace('đ', 'd')
                .Normalize(NormalizationForm.FormC);
        }

        private static bool _IsExactNameMatch(string sourceName, string normalizedInput)
        {
            if (string.IsNullOrWhiteSpace(sourceName) || string.IsNullOrWhiteSpace(normalizedInput))
                return false;

            string normalizedName = _NormalizeSearchText(sourceName);
            return normalizedName == normalizedInput;
        }

        private static bool _IsNameSuggestionMatch(string sourceName, string normalizedInput)
        {
            if (string.IsNullOrWhiteSpace(sourceName) || string.IsNullOrWhiteSpace(normalizedInput))
                return false;

            string normalizedName = _NormalizeSearchText(sourceName);
            if (normalizedName.Contains(normalizedInput))
                return true;

            string[] nameParts = normalizedName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] inputParts = normalizedInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return inputParts.All(inputPart => nameParts.Any(namePart => namePart.Contains(inputPart)));
        }

        public async Task LoadBookingInfoAsync(int? BookingID)
        {
            this.Cursor = Cursors.WaitCursor;
            btnFind.Enabled = false;

            try
            {
                txtFilterValue.Text = BookingID.ToString();
                await ucBookingCard1.LoadBookingInfoAsync(BookingID);

                if (OnBookingSelected != null)
                    RaiseOnBookingSelected(ucBookingCard1.BookingID);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải dữ liệu từ máy chủ. Vui lòng kiểm tra kết nối mạng.\nChi tiết: {ex.Message}",
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnFind.Enabled = true;
            }
        }

        public async void LoadBookingInfo(int? BookingID)
        {
            await LoadBookingInfoAsync(BookingID);
        }

        private void _InitializeSuggestionsDropDown()
        {
            _suggestionsListBox = new ListBox
            {
                BorderStyle = BorderStyle.None,
                IntegralHeight = true,
                DrawMode = DrawMode.OwnerDrawFixed,
                ItemHeight = 22
            };

            _suggestionsListBox.Click += (s, e) => _ApplySelectedSuggestion();
            _suggestionsListBox.DrawItem += _suggestionsListBox_DrawItem;
            _suggestionsListBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    _ApplySelectedSuggestion();
                }
            };

            ToolStripControlHost host = new ToolStripControlHost(_suggestionsListBox)
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                AutoSize = false
            };

            _suggestionsMenu = new ToolStripDropDown
            {
                AutoSize = false,
                Padding = Padding.Empty,
                Margin = Padding.Empty
            };

            _suggestionsMenu.Items.Add(host);
        }

        private void _ShowSuggestionsDropDown(List<string> suggestions)
        {
            if (_suggestionsMenu == null || _suggestionsListBox == null || suggestions == null || suggestions.Count == 0)
                return;

            _suggestionsListBox.BeginUpdate();
            _suggestionsListBox.Items.Clear();
            foreach (string suggestion in suggestions)
                _suggestionsListBox.Items.Add(suggestion);
            _suggestionsListBox.EndUpdate();

            int width = txtFilterValue.Width;
            int visibleItems = Math.Min(8, _suggestionsListBox.Items.Count);
            int height = visibleItems * _suggestionsListBox.ItemHeight + 22;

            _suggestionsListBox.Size = new Size(width, height);
            _suggestionsMenu.Size = new Size(width, height);

            if (_suggestionsMenu.Visible)
                _suggestionsMenu.Close();

            _suggestionsMenu.Show(txtFilterValue.PointToScreen(new Point(0, txtFilterValue.Height)));
            _suggestionsListBox.Focus();
        }

        private void _HideSuggestionsDropDown()
        {
            if (_suggestionsMenu != null && _suggestionsMenu.Visible)
                _suggestionsMenu.Close();
        }

        private void _ApplySelectedSuggestion()
        {
            if (_suggestionsListBox.SelectedItem == null)
                return;

            txtFilterValue.Text = _suggestionsListBox.SelectedItem.ToString();
            txtFilterValue.SelectionStart = txtFilterValue.TextLength;
            txtFilterValue.SelectionLength = 0;
            _HideSuggestionsDropDown();
            txtFilterValue.Focus();
        }

        private void _suggestionsListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= _suggestionsListBox.Items.Count)
                return;

            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            Color backColor = isSelected ? SystemColors.Highlight : SystemColors.Window;
            Color textColor = isSelected ? SystemColors.HighlightText : SystemColors.WindowText;

            using (SolidBrush backBrush = new SolidBrush(backColor))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
                Rectangle textRect = new Rectangle(e.Bounds.Left + 6, e.Bounds.Top + 2, e.Bounds.Width - 8, e.Bounds.Height - 4);
                e.Graphics.DrawString(_suggestionsListBox.Items[e.Index].ToString(), e.Font, textBrush, textRect);
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
