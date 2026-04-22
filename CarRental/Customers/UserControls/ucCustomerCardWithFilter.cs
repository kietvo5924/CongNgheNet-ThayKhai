using CarRental_Business;
using CarRental.GlobalClasses;
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

namespace CarRental.Customers.UserControls
{
    public partial class ucCustomerCardWithFilter : UserControl
    {
        private DataTable _dtCustomerSource;
        private readonly HashSet<string> _autoCompleteValues = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private AutoCompleteStringCollection _defaultAutoCompleteSource;
        private ToolStripDropDown _suggestionsMenu;
        private ListBox _suggestionsListBox;

        public ucCustomerCardWithFilter()
        {
            InitializeComponent();
            _InitializeSuggestionsDropDown();
        }

        #region Declare Event
        public class CustomerSelectedEventArgs : EventArgs
        {
            public int? CustomerID { get; }

            public CustomerSelectedEventArgs(int? customerID)
            {
                this.CustomerID = customerID;
            }
        }

        public event EventHandler<CustomerSelectedEventArgs> OnCustomerSelected;

        public void RaiseOnCustomerSelected(int? CustomerID)
        {
            RaiseOnCustomerSelected(new CustomerSelectedEventArgs(CustomerID));
        }

        protected virtual void RaiseOnCustomerSelected(CustomerSelectedEventArgs e)
        {
            OnCustomerSelected?.Invoke(this, e);
        }
        #endregion

        private bool _ShowAddCustomerButton = true;
        public bool ShowAddMemberButton
        {
            get => _ShowAddCustomerButton;

            set
            {
                _ShowAddCustomerButton = value;
                btnAddNew.Visible = _ShowAddCustomerButton;
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

        public int? CustomerID => ucCustomerCard1.CustomerID;
        public clsCustomer SelectedCustomerInfo => ucCustomerCard1.CustomerInfo;

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbSearchBy.SelectedIndex == 1)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
                if (e.Handled)
                    return;
            }

            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                btnFind.PerformClick();
            }
        }

        private void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Clear();
            errorProvider1.SetError(txtFilterValue, null);
            txtFilterValue.Focus();
        }

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

            await _EnsureCustomerSourceLoadedAsync();

            string filterValue = txtFilterValue.Text.Trim();

            if (!_TryResolveCustomerID(filterValue, out int customerID))
            {
                if (_TrySuggestCustomerSelection(filterValue, out List<string> suggestionsPreview))
                {
                    _ShowSuggestionsDropDown(suggestionsPreview);
                    return;
                }

                _HideSuggestionsDropDown();
                MessageBox.Show("Không tìm thấy khách hàng theo mã/tên đã nhập.",
                    "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _HideSuggestionsDropDown();

            await LoadCustomerInfoAsync(customerID);
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

        private async void ucCustomerCardWithFilter_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            btnFind.Enabled = false;

            try
            {
                await _LoadCustomerAutoCompleteAsync();
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

        private async Task _EnsureCustomerSourceLoadedAsync()
        {
            if (_dtCustomerSource == null)
                _dtCustomerSource = await Task.Run(() => clsCustomer.GetAllCustomers());
        }

        private async Task _LoadCustomerAutoCompleteAsync()
        {
            await _EnsureCustomerSourceLoadedAsync();
            _autoCompleteValues.Clear();

            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            if (_dtCustomerSource != null)
            {
                foreach (DataRow row in _dtCustomerSource.Rows)
                {
                    string id = row.Table.Columns.Contains("CustomerID") ? row["CustomerID"].ToString() : string.Empty;
                    string name = row.Table.Columns.Contains("Name") ? row["Name"].ToString() : string.Empty;

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

        private bool _TryResolveCustomerID(string input, out int customerID)
        {
            customerID = -1;

            if (string.IsNullOrWhiteSpace(input))
                return false;

            input = input.Trim();
            string normalizedInput = _NormalizeSearchText(input);
            bool allowById = cbSearchBy.SelectedIndex != 2;
            bool allowByName = cbSearchBy.SelectedIndex != 1;

            if (allowById && int.TryParse(input, out customerID))
                return true;

            int dashIndex = input.IndexOf('-');
            if (allowById && dashIndex > 0)
            {
                string prefix = input.Substring(0, dashIndex).Trim();
                if (int.TryParse(prefix, out customerID))
                    return true;
            }

            if (!allowByName)
                return false;

            if (_dtCustomerSource == null || !_dtCustomerSource.Columns.Contains("CustomerID") || !_dtCustomerSource.Columns.Contains("Name"))
                return false;

            DataRow matched = _dtCustomerSource.AsEnumerable()
                .FirstOrDefault(r => _IsExactNameMatch(r["Name"]?.ToString(), normalizedInput));

            if (matched == null)
                return false;

            return int.TryParse(matched["CustomerID"].ToString(), out customerID);
        }

        private bool _TrySuggestCustomerSelection(string input, out List<string> suggestionsPreview)
        {
            suggestionsPreview = new List<string>();

            if (string.IsNullOrWhiteSpace(input))
                return false;

            if (_dtCustomerSource == null || !_dtCustomerSource.Columns.Contains("CustomerID") || !_dtCustomerSource.Columns.Contains("Name"))
                return false;

            string normalizedInput = _NormalizeSearchText(input);
            List<DataRow> matches = _dtCustomerSource.AsEnumerable()
                .Where(r => _IsNameSuggestionMatch(r["Name"]?.ToString(), normalizedInput))
                .Take(20)
                .ToList();

            if (matches.Count == 0)
                return false;

            AutoCompleteStringCollection suggestions = new AutoCompleteStringCollection();
            HashSet<string> distinct = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            HashSet<string> distinctPreview = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (DataRow row in matches)
            {
                string id = row["CustomerID"]?.ToString();
                string name = row["Name"]?.ToString();
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

        public async Task LoadCustomerInfoAsync(int? CustomerID)
        {
            this.Cursor = Cursors.WaitCursor;
            btnFind.Enabled = false;

            try
            {
                txtFilterValue.Text = CustomerID.HasValue ? CustomerID.Value.ToString() : string.Empty;
                await ucCustomerCard1.LoadCustomerInfoAsync(CustomerID);

                RaiseOnCustomerSelected(ucCustomerCard1.CustomerID);
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

        public async void LoadCustomerInfo(int? CustomerID)
        {
            await LoadCustomerInfoAsync(CustomerID);
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
            frmAddEditCustomer AddNewCustomer = new frmAddEditCustomer();
            AddNewCustomer.GetCustomerIDByDelegate += LoadCustomerInfo;
            AddNewCustomer.ShowDialog();
        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        public void Clear()
        {
            ucCustomerCard1.Reset();
        }
    }
}
