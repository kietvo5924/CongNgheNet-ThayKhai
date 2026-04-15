using CarRental.Booking.UserControls;
using CarRental.GlobalClasses;
using CarRental.Transaction;
using CarRental_Business;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CarRental.Booking.UserControls.ucBookingCardWithFilter;

namespace CarRental.Return
{
    public partial class frmReturnVehicle : Form
    {
        private static readonly decimal _overdueFeePerDay = _GetConfigDecimal("OverdueFeePerDay", 200000m, 0m);

        public Action<int?> GetReturnByDelegate;

        private int? _SelectedBookingID = null;
        private int? _ReturnID = null;
        private clsReturn _Return;

        public frmReturnVehicle()
        {
            InitializeComponent();
        }

        public frmReturnVehicle(int? BookingID)
        {
            InitializeComponent();
            ucBookingCardWithFilter1.LoadBookingInfo(BookingID);
            ucBookingCardWithFilter1.FilterEnabled = false;
        }

        private void _ApplyModernUiNoIcons()
        {
            // Keep it minimal and consistent with other modern screens.
            this.Font = new Font("Segoe UI", 10F);

            // Buttons
            btnReturn.Image = null;
            btnReturn.ImageAlign = HorizontalAlignment.Center;
            btnReturn.TextOffset = new Point(0, 0);
            btnReturn.BorderRadius = 8;
            btnReturn.FillColor = Color.FromArgb(0, 118, 212);
            btnReturn.ForeColor = Color.White;
            btnReturn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);

            btnClose.Image = null;
            btnClose.ImageAlign = HorizontalAlignment.Center;
            btnClose.TextOffset = new Point(0, 0);
            btnClose.BorderRadius = 8;
            btnClose.FillColor = Color.FromArgb(243, 244, 246);
            btnClose.ForeColor = Color.FromArgb(75, 85, 99);
            btnClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);

            // Inputs
            _StyleTextBox(txtMileage, "Nhập số KM hiện tại...");
            _StyleTextBox(txtAdditionalCharges, "Nhập phí phát sinh (nếu có)...");
            _StyleTextBox(txtPaidAtReturn, "Nhập số tiền khách thanh toán khi trả...");
            _StyleTextBox(txtFinalCheckNotes, "Ghi chú kiểm tra xe...");

            dtpActualReturnDate.BorderRadius = 8;
            dtpActualReturnDate.FillColor = Color.White;
            dtpActualReturnDate.Font = new Font("Segoe UI", 10F);

            // Links
            _StyleLink(llShowReturnDetails);
            _StyleLink(llShowUpdatedTransactionDetails);
        }

        private void _StyleTextBox(Guna2TextBox txt, string placeholder)
        {
            if (txt == null) return;

            txt.BorderRadius = 8;
            txt.PlaceholderText = placeholder;
            txt.PlaceholderForeColor = Color.FromArgb(156, 163, 175);
            txt.Font = new Font("Segoe UI", 10F);
            txt.ForeColor = Color.FromArgb(31, 41, 55);
            txt.FillColor = Color.White;

            txt.BorderColor = Color.FromArgb(229, 231, 235);
            txt.FocusedState.BorderColor = Color.FromArgb(0, 118, 212);
            txt.HoverState.BorderColor = Color.FromArgb(0, 118, 212);
        }

        private void _StyleLink(LinkLabel ll)
        {
            if (ll == null) return;

            ll.LinkColor = Color.FromArgb(0, 118, 212);
            ll.ActiveLinkColor = Color.FromArgb(0, 118, 212);
            ll.VisitedLinkColor = Color.FromArgb(0, 118, 212);
            ll.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
        }

        private bool _UpdateMileageOfTheVehicleInDB()
        {
            if (double.TryParse(txtMileage.Text.Trim(), out double mileage))
            {
                return ucBookingCardWithFilter1.SelectedBookingInfo?.VehicleInfo?.
                       UpdateMileage((int)mileage) ?? false;
            }
            return false;
        }

        private bool _SetVehicleAvailableForRent()
        {
            return ucBookingCardWithFilter1.SelectedBookingInfo?.VehicleInfo?.
                SetAvailableForRent() ?? false;
        }

        private int _CalculateActualRentalDays()
        {
            if (ucBookingCardWithFilter1.SelectedBookingInfo == null) return 0;

            int DiffDays = (dtpActualReturnDate.Value.Date - ucBookingCardWithFilter1.SelectedBookingInfo.RentalStartDate.Date).Days;

            // Nếu trả sớm hoặc cùng ngày, tối thiểu tính 1 ngày
            return DiffDays < 1 ? 1 : DiffDays;
        }

        private double _CalculateConsumedMileage()
        {
            if (string.IsNullOrEmpty(txtMileage.Text.Trim())) return 0;

            double InitialMileage = ucBookingCardWithFilter1.SelectedBookingInfo?.VehicleInfo?.Mileage ?? 0;
            double FinalMileage = 0;

            if (double.TryParse(txtMileage.Text.Trim(), out FinalMileage))
            {
                return (FinalMileage) - (InitialMileage);
            }
            return 0;
        }

        private static decimal _GetConfigDecimal(string key, decimal defaultValue, decimal minValue)
        {
            string raw = ConfigurationManager.AppSettings[key];
            if (!decimal.TryParse(raw, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal value))
                return defaultValue;

            return value < minValue ? minValue : value;
        }

        private decimal _GetManualAdditionalCharges()
        {
            if (string.IsNullOrWhiteSpace(txtAdditionalCharges.Text.Trim()))
                return 0m;

            return decimal.TryParse(txtAdditionalCharges.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal parsed)
                ? parsed
                : 0m;
        }

        private int _CalculateOverdueDays()
        {
            if (ucBookingCardWithFilter1.SelectedBookingInfo == null)
                return 0;

            int overdueDays = (dtpActualReturnDate.Value.Date - ucBookingCardWithFilter1.SelectedBookingInfo.RentalEndDate.Date).Days;
            return overdueDays > 0 ? overdueDays : 0;
        }

        private decimal _CalculateOverduePenaltyAmount()
        {
            return _CalculateOverdueDays() * _overdueFeePerDay;
        }

        private decimal _GetPaidAmountAtReturn()
        {
            if (string.IsNullOrWhiteSpace(txtPaidAtReturn.Text.Trim()))
                return 0m;

            return decimal.TryParse(txtPaidAtReturn.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal parsed)
                ? parsed
                : 0m;
        }

        private decimal _CalculateActualTotalDueAmount()
        {
            if (ucBookingCardWithFilter1.SelectedBookingInfo == null) return 0m;

            decimal RentalPricePerDay = ucBookingCardWithFilter1.SelectedBookingInfo.RentalPricePerDay;
            int ActualRentalDays = _CalculateActualRentalDays();
            decimal AdditionalCharges = _GetManualAdditionalCharges();
            decimal overduePenaltyAmount = _CalculateOverduePenaltyAmount();

            return (ActualRentalDays * RentalPricePerDay) + AdditionalCharges + overduePenaltyAmount;
        }

        private void _Reset()
        {
            ucBookingCardWithFilter1.FilterEnabled = false;
            txtAdditionalCharges.Enabled = false;
            txtPaidAtReturn.Enabled = false;
            txtFinalCheckNotes.Enabled = false;
            txtMileage.Enabled = false;
            btnReturn.Enabled = false;
            dtpActualReturnDate.Enabled = false;
        }

        private void _ReturnVehicle()
        {
            string validationError;
            if (!_ValidateBeforeReturn(out validationError))
            {
                MessageBox.Show("Không thể trả xe.\nLý do: " + validationError,
                    "Trả xe thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _Return = new clsReturn();

            _Return.ActualReturnDate = dtpActualReturnDate.Value;

            if (int.TryParse(txtMileage.Text.Trim(), out int mileage))
                _Return.Mileage = mileage;
            else
                _Return.Mileage = 0;

            _Return.FinalCheckNotes = txtFinalCheckNotes.Text.Trim();

            decimal additionalCharges = _GetManualAdditionalCharges();
            decimal overduePenaltyAmount = _CalculateOverduePenaltyAmount();
            _Return.AdditionalCharges = additionalCharges + overduePenaltyAmount;
            _Return.PaidAmountAtReturn = _GetPaidAmountAtReturn();

            _Return.ConsumedMileage = (int)_CalculateConsumedMileage();
            _Return.ActualRentalDays = _CalculateActualRentalDays();
            _Return.ActualTotalDueAmount = _CalculateActualTotalDueAmount();

            int? transactionID = ucBookingCardWithFilter1.SelectedBookingInfo?.TransactionInfo?.TransactionID;

            if (!_Return.CompleteReturnWorkflow(transactionID))
            {
                string reason = string.IsNullOrWhiteSpace(_Return.LastError)
                    ? "Không xác định nguyên nhân. Vui lòng kiểm tra dữ liệu đơn và thử lại."
                    : _Return.LastError;

                MessageBox.Show("Không thể hoàn tất trả xe.\nLý do: " + reason, "Trả xe thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblReturnID.Text = _Return.ReturnID?.ToString();
            lblActualRentalDays.Text = _Return.ActualRentalDays.ToString();
            lblConsumedMileage.Text = _Return.ConsumedMileage.ToString();
            lblActualTotalDueAmount.Text = _Return.ActualTotalDueAmount.ToString("N");

            int overdueDays = _CalculateOverdueDays();
            string overdueSummary = overdueDays > 0
                ? $"\nPhí trễ hạn ({overdueDays} ngày x {_overdueFeePerDay:N0}) = {overduePenaltyAmount:N0}."
                : "\nKhông phát sinh phí trễ hạn.";

            MessageBox.Show("Trả xe thành công!\nSố KM hiện tại đã được cập nhật vào xe và dùng cho lịch sử/bảo trì."
                + overdueSummary, "Hoàn tất",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);

            _ReturnID = _Return.ReturnID;

            llShowReturnDetails.Enabled = true;
            llShowUpdatedTransactionDetails.Enabled = true;

            _Reset();

            GetReturnByDelegate?.Invoke(_Return.ReturnID.Value);
        }

        private bool _ValidateBeforeReturn(out string errorMessage)
        {
            errorMessage = null;

            if (!_SelectedBookingID.HasValue || ucBookingCardWithFilter1.SelectedBookingInfo == null)
            {
                errorMessage = "Bạn chưa chọn đơn đặt xe hợp lệ.";
                return false;
            }

            if (ucBookingCardWithFilter1.SelectedBookingInfo.IsBookingReturned)
            {
                errorMessage = "Đơn đặt xe này đã được trả trước đó.";
                return false;
            }

            int? transactionID = ucBookingCardWithFilter1.SelectedBookingInfo.TransactionInfo?.TransactionID;
            if (!transactionID.HasValue)
            {
                errorMessage = "Không tìm thấy giao dịch của đơn đặt xe để quyết toán.";
                return false;
            }

            if (!int.TryParse(txtMileage.Text.Trim(), out int mileage))
            {
                errorMessage = "Số KM hiện tại không hợp lệ.";
                return false;
            }

            int initialMileage = ucBookingCardWithFilter1.SelectedBookingInfo.VehicleInfo?.Mileage ?? 0;
            if (mileage < initialMileage)
            {
                errorMessage = "Số KM hiện tại không được nhỏ hơn số KM ban đầu (" + initialMileage + ").";
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtAdditionalCharges.Text.Trim()))
            {
                if (!decimal.TryParse(txtAdditionalCharges.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal additionalCharges))
                {
                    errorMessage = "Phí phát sinh không hợp lệ.";
                    return false;
                }

                if (additionalCharges < 0)
                {
                    errorMessage = "Phí phát sinh không được âm.";
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtFinalCheckNotes.Text.Trim()))
            {
                errorMessage = "Bạn cần nhập ghi chú kiểm tra xe trước khi trả xe.";
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtPaidAtReturn.Text.Trim()))
            {
                if (!decimal.TryParse(txtPaidAtReturn.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal paidAtReturn))
                {
                    errorMessage = "Số tiền thanh toán khi trả xe không hợp lệ.";
                    return false;
                }

                if (paidAtReturn < 0)
                {
                    errorMessage = "Số tiền thanh toán khi trả xe không được âm.";
                    return false;
                }
            }

            return true;
        }

        private void txtFinalCheckNotes_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidateRequired((Control)sender, errorProvider1, e, "Vui lòng nhập ghi chú kiểm tra xe!");
        }

        private void frmReturnVehicle_Load(object sender, EventArgs e)
        {
            dtpActualReturnDate.MinDate = DateTime.Now;
            _ApplyModernUiNoIcons();
        }

        private void ucBookingCardWithFilter1_OnBookingSelected(object sender, BookingSelectedEventArgs e)
        {
            _SelectedBookingID = e.BookingID;

            if (!_SelectedBookingID.HasValue)
            {
                btnReturn.Enabled = false;
                return;
            }

            if (ucBookingCardWithFilter1.SelectedBookingInfo.IsBookingReturned)
            {
                MessageBox.Show("Đơn đặt hàng này đã hoàn tất và xe đã được trả!", "Không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                btnReturn.Enabled = false;
                return;
            }

            btnReturn.Enabled = true;

            lblActualRentalDays.Text = _CalculateActualRentalDays().ToString();

            // Reset fields
            txtMileage.Text = "";
            txtAdditionalCharges.Text = "";
            txtPaidAtReturn.Text = "";
            txtFinalCheckNotes.Text = "";
            lblActualTotalDueAmount.Text = "N/A";
            lblConsumedMileage.Text = "N/A";
        }

        private void txtAdditionalCharges_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidateMoney(
                (Control)sender,
                errorProvider1,
                e,
                out _,
                required: false,
                allowNegative: false,
                formatAfterValidate: false,
                invalidMessage: "Vui lòng nhập số hợp lệ.");

            if (!e.Cancel)
            {
                lblActualTotalDueAmount.Text = _CalculateActualTotalDueAmount().ToString("N");
            }
        }

        private void txtPaidAtReturn_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidateMoney(
                (Control)sender,
                errorProvider1,
                e,
                out _,
                required: false,
                allowNegative: false,
                formatAfterValidate: false,
                invalidMessage: "Vui lòng nhập số tiền hợp lệ.");
        }

        private void txtMileage_Validating(object sender, CancelEventArgs e)
        {
            Control temp = (Control)sender;

            if (!clsValidation.ValidateMoney(
                temp,
                errorProvider1,
                e,
                out decimal mileageDecimal,
                required: true,
                allowNegative: false,
                formatAfterValidate: false,
                emptyMessage: "Vui lòng nhập số KM hiện tại!",
                invalidMessage: "Số không hợp lệ."))
            {
                return;
            }

            double mileage = (double)mileageDecimal;

            if (_SelectedBookingID.HasValue &&
                mileage < ucBookingCardWithFilter1.SelectedBookingInfo?.VehicleInfo?.Mileage)
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, $"Số KM ban đầu là: " +
                    $" {ucBookingCardWithFilter1.SelectedBookingInfo?.VehicleInfo?.Mileage}." +
                    $" \nSố KM trả xe không được nhỏ hơn số KM ban đầu!");
            }
            else
            {
                errorProvider1.SetError(temp, null);
            }

            if (!e.Cancel)
            {
                lblConsumedMileage.Text = _CalculateConsumedMileage().ToString();
            }
        }

        private void dtpActualReturnDate_ValueChanged(object sender, EventArgs e)
        {
            if (!_SelectedBookingID.HasValue) return;

            lblActualRentalDays.Text = _CalculateActualRentalDays().ToString();
            lblActualTotalDueAmount.Text = _CalculateActualTotalDueAmount().ToString("N");
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Dữ liệu nhập vào chưa hợp lệ. Vui lòng kiểm tra lại các trường báo đỏ!",
                    "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _ReturnVehicle();
        }

        private void llShowReturnDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowReturnDetailsWithCustomerAndVehicle ShowReturnDetails = new frmShowReturnDetailsWithCustomerAndVehicle(_ReturnID);
            ShowReturnDetails.ShowDialog();
        }

        private void llShowUpdateTransactionDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowTransactionDetails ShowTransactionDetails = new frmShowTransactionDetails(ucBookingCardWithFilter1.SelectedBookingInfo?.TransactionInfo?.TransactionID);
            ShowTransactionDetails.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucBookingCardWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}