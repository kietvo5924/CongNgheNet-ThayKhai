using CarRental.Properties;
using CarRental_Business;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarRental.Users.UserControls
{
    public partial class ucUserCard : UserControl
    {
        private int? _UserID = null;
        private clsUser _User;

        public int? UserID => _UserID;
        public clsUser User => _User;

        private bool _EditEnabled = true; // Mặc định cho phép sửa

        public bool EditEnabled
        {
            get => _EditEnabled;
            set
            {
                _EditEnabled = value;
                btnEditUserInfo.Visible = value; // Hiển thị nút dựa trên cấu hình
            }
        }

        public ucUserCard()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            _UserID = null;
            _User = null;
            ucPersonCard1.Reset();
            lblUserID.Text = "[????]";
            lblUsername.Text = "[????]";
            lblIsActive.Text = "[????]";
            btnEditUserInfo.Visible = false;
        }

        private void _LoadUserImage()
        {
            if (_User.ImagePath != null && File.Exists(_User.ImagePath))
            {
                pbUserImage.ImageLocation = _User.ImagePath;
            }
            else
            {
                pbUserImage.Image = (_User.Gender == (byte)clsPerson.enGender.Male)
                                    ? Resources.DefaultMale
                                    : Resources.DefaultFemale;
            }
        }

        private void _FillUserInfo()
        {
            // Quan trọng: Phải gán Visible theo trạng thái _EditEnabled
            btnEditUserInfo.Visible = _EditEnabled;

            ucPersonCard1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID?.ToString();
            lblUsername.Text = _User.Username;

            lblIsActive.Text = _User.IsActive ? "Đang hoạt động" : "Ngưng hoạt động";
            lblIsActive.ForeColor = _User.IsActive ? Color.Green : Color.Red;

            _LoadUserImage();
        }

        public void LoadUserInfo(int? UserID)
        {
            _UserID = UserID;
            if (!_UserID.HasValue) { Reset(); return; }

            _User = clsUser.Find(_UserID);
            if (_User == null) { Reset(); return; }

            _FillUserInfo();
        }

        private void btnEditUserInfo_Click(object sender, EventArgs e)
        {
            frmAddEditUser EditUser = new frmAddEditUser(_UserID);
            EditUser.GetUserIDByDelegate += LoadUserInfo;
            EditUser.ShowDialog();
        }
    }
}