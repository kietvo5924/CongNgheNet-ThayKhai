using System;
using System.ComponentModel;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.GlobalClasses
{
    public class clsValidation
    {
        public static bool ValidateRequired(Control control, ErrorProvider errorProvider,
            CancelEventArgs e, string message = "Vui lòng không để trống trường này!")
        {
            if (control == null || errorProvider == null)
                return true;

            string text = control.Text == null ? string.Empty : control.Text.Trim();

            if (string.IsNullOrWhiteSpace(text))
            {
                if (e != null)
                    e.Cancel = true;

                errorProvider.SetError(control, message);
                return false;
            }

            errorProvider.SetError(control, null);
            return true;
        }

        public static bool ValidateMoney(Control control, ErrorProvider errorProvider,
            CancelEventArgs e, out decimal amount,
            bool required = true,
            bool allowNegative = false,
            bool formatAfterValidate = false,
            string emptyMessage = "Vui lòng không để trống trường này!",
            string invalidMessage = "Giá trị tiền không hợp lệ.")
        {
            amount = 0m;

            if (control == null || errorProvider == null)
                return true;

            string rawValue = control.Text == null ? string.Empty : control.Text.Trim();

            if (string.IsNullOrWhiteSpace(rawValue))
            {
                if (!required)
                {
                    errorProvider.SetError(control, null);
                    return true;
                }

                if (e != null)
                    e.Cancel = true;

                errorProvider.SetError(control, emptyMessage);
                return false;
            }

            if (!decimal.TryParse(rawValue, NumberStyles.Number, CultureInfo.CurrentCulture, out amount))
            {
                if (e != null)
                    e.Cancel = true;

                errorProvider.SetError(control, invalidMessage);
                return false;
            }

            if (!allowNegative && amount < 0)
            {
                if (e != null)
                    e.Cancel = true;

                errorProvider.SetError(control, invalidMessage);
                return false;
            }

            errorProvider.SetError(control, null);

            if (formatAfterValidate)
                control.Text = amount.ToString("N0");

            return true;
        }

        public static bool ValidateDateInRange(Control dateControl, DateTime value, ErrorProvider errorProvider,
            CancelEventArgs e, DateTime? minDate = null, DateTime? maxDate = null,
            string rangeMessage = "Ngày không hợp lệ.")
        {
            if (dateControl == null || errorProvider == null)
                return true;

            DateTime dateValue = value.Date;

            if (minDate.HasValue && dateValue < minDate.Value.Date)
            {
                if (e != null)
                    e.Cancel = true;

                errorProvider.SetError(dateControl, rangeMessage);
                return false;
            }

            if (maxDate.HasValue && dateValue > maxDate.Value.Date)
            {
                if (e != null)
                    e.Cancel = true;

                errorProvider.SetError(dateControl, rangeMessage);
                return false;
            }

            errorProvider.SetError(dateControl, null);
            return true;
        }

        public static bool ValidateEmail(string emailAddress)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(emailAddress);
        }

        public static bool ValidateInteger(string Number)
        {
            var pattern = @"^[0-9]*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool ValidateVietnamPhone(Control control, ErrorProvider errorProvider,
            CancelEventArgs e = null, bool required = true)
        {
            if (control == null || errorProvider == null)
                return true;

            string rawValue = control.Text == null ? string.Empty : control.Text.Trim();

            if (string.IsNullOrWhiteSpace(rawValue))
            {
                if (!required)
                {
                    errorProvider.SetError(control, null);
                    return true;
                }

                if (e != null)
                    e.Cancel = true;

                errorProvider.SetError(control, "Vui lòng nhập số điện thoại.");
                return false;
            }

            if (!Regex.IsMatch(rawValue, @"^0\d{9}$"))
            {
                if (e != null)
                    e.Cancel = true;

                errorProvider.SetError(control, "Số điện thoại phải gồm đúng 10 số và bắt đầu bằng 0.");
                return false;
            }

            errorProvider.SetError(control, null);
            return true;
        }

        public static void HandlePhoneKeyPress(Control control, KeyPressEventArgs e, int maxLength = 10)
        {
            if (e == null)
                return;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            if (!char.IsDigit(e.KeyChar))
                return;

            int currentLength = (control?.Text ?? string.Empty).Length;
            if (currentLength >= maxLength)
            {
                e.Handled = true;
            }
        }

        public static bool ValidateFloat(string Number)
        {
            var pattern = @"^[0-9]*(?:\.[0-9]*)?$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool IsNumber(string Number)
        {
            return (ValidateInteger(Number) || ValidateFloat(Number));
        }
    }
}
