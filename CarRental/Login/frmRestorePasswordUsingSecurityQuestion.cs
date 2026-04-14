using CarRental.GlobalClasses;
using CarRental.GlobalClasses;
using CarRental_Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Login
{
    public partial class frmRestorePasswordUsingSecurityQuestion : Form
    {
        private class SecurityAnswerAttemptState
        {
            public int FailedAttempts { get; set; }
            public DateTime? LockedUntilUtc { get; set; }
        }

        private static readonly Dictionary<string, SecurityAnswerAttemptState> _attemptStates
            = new Dictionary<string, SecurityAnswerAttemptState>(StringComparer.OrdinalIgnoreCase);
        private static readonly object _attemptStatesLock = new object();
        private static readonly int _maxFailedAttempts = _GetConfigInt("SecurityAnswerMaxAttempts", 5, 1, 10);
        private static readonly int _cooldownMinutes = _GetConfigInt("SecurityAnswerCooldownMinutes", 5, 1, 120);

        private string _Username;
        private clsUser _User;

        public frmRestorePasswordUsingSecurityQuestion(string username)
        {
            InitializeComponent();

            _Username = username;
        }

        private void _ShowSecurityQuestion()
        {
            _User = clsUser.Find(_Username);

            if (_User == null)
            {
                MessageBox.Show("Không tìm thấy người dùng với tên đăng nhập này!", "Không tìm thấy",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();

                return;
            }

            if (string.IsNullOrWhiteSpace(_User.SecurityQuestion))
            {
                MessageBox.Show("Người dùng này chưa thiết lập câu hỏi bảo mật!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();

                return;
            }

            lblSecurityQuestion.Text = _User.SecurityQuestion;
        }

        private bool _CheckAnswer()
        {
            try
            {
                string decryptedAnswer = clsGlobal.Decrypt(_User.SecurityAnswer);
                return string.Equals(decryptedAnswer?.Trim(), txtAnswer.Text.Trim(), StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        private static int _GetConfigInt(string key, int defaultValue, int minValue, int maxValue)
        {
            string raw = ConfigurationManager.AppSettings[key];
            if (!int.TryParse(raw, out int value))
                return defaultValue;

            if (value < minValue)
                return minValue;

            if (value > maxValue)
                return maxValue;

            return value;
        }

        private bool _TryGetLockoutMessage(out string message)
        {
            message = string.Empty;

            lock (_attemptStatesLock)
            {
                if (!_attemptStates.TryGetValue(_Username, out SecurityAnswerAttemptState state)
                    || !state.LockedUntilUtc.HasValue)
                {
                    return false;
                }

                DateTime nowUtc = DateTime.UtcNow;
                if (state.LockedUntilUtc.Value <= nowUtc)
                {
                    state.LockedUntilUtc = null;
                    state.FailedAttempts = 0;
                    return false;
                }

                TimeSpan remaining = state.LockedUntilUtc.Value - nowUtc;
                int remainingMinutes = (int)Math.Ceiling(remaining.TotalMinutes);
                if (remainingMinutes < 1)
                    remainingMinutes = 1;

                message = $"Bạn đã trả lời sai quá {_maxFailedAttempts} lần. Vui lòng thử lại sau {remainingMinutes} phút.";
                return true;
            }
        }

        private void _RegisterFailedAttempt(out bool isNowLocked, out int attemptsLeft)
        {
            isNowLocked = false;
            attemptsLeft = 0;

            lock (_attemptStatesLock)
            {
                if (!_attemptStates.TryGetValue(_Username, out SecurityAnswerAttemptState state))
                {
                    state = new SecurityAnswerAttemptState();
                    _attemptStates[_Username] = state;
                }

                DateTime nowUtc = DateTime.UtcNow;
                if (state.LockedUntilUtc.HasValue && state.LockedUntilUtc.Value <= nowUtc)
                {
                    state.LockedUntilUtc = null;
                    state.FailedAttempts = 0;
                }

                state.FailedAttempts++;

                if (state.FailedAttempts >= _maxFailedAttempts)
                {
                    state.LockedUntilUtc = nowUtc.AddMinutes(_cooldownMinutes);
                    isNowLocked = true;
                    attemptsLeft = 0;
                }
                else
                {
                    attemptsLeft = _maxFailedAttempts - state.FailedAttempts;
                }
            }
        }

        private void _ResetAttemptState()
        {
            lock (_attemptStatesLock)
            {
                if (_attemptStates.ContainsKey(_Username))
                    _attemptStates.Remove(_Username);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_TryGetLockoutMessage(out string lockoutMessage))
            {
                MessageBox.Show(lockoutMessage, "Tạm khóa khôi phục mật khẩu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!this.ValidateChildren())
            {
                //Here we don't continue because the form is not valid
                MessageBox.Show("Một số trường chưa hợp lệ, hãy di chuột lên biểu tượng màu đỏ để xem chi tiết lỗi.",
                    "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_CheckAnswer())
            {
                _ResetAttemptState();

                MessageBox.Show("Câu trả lời chính xác, bạn có thể đổi mật khẩu ngay bây giờ.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();

                frmChangePasswordUsingSecurityQuestion ChangePassword =
                    new frmChangePasswordUsingSecurityQuestion(_Username);

                ChangePassword.ShowDialog();
            }
            else
            {
                _RegisterFailedAttempt(out bool isNowLocked, out int attemptsLeft);

                string message = isNowLocked
                    ? $"Bạn đã trả lời sai quá {_maxFailedAttempts} lần. Vui lòng thử lại sau {_cooldownMinutes} phút."
                    : $"Câu trả lời chưa chính xác! Bạn còn {attemptsLeft} lần thử.";

                MessageBox.Show(message,
                    "Sai câu trả lời", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtAnswer.Focus();
            }
        }

        private void txtAnswer_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAnswer.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAnswer, "Vui lòng không để trống trường này!");
            }
            else
            {
                errorProvider1.SetError(txtAnswer, null);
            }
        }

        private void frmRestorePasswordUsingSecurityQuestion_Load(object sender, EventArgs e)
        {
            _ShowSecurityQuestion();

            txtAnswer.Focus();
        }
    }
}
