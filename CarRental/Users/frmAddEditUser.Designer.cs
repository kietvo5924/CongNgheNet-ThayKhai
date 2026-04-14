namespace CarRental.Users
{
    partial class frmAddEditUser
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2PanelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSecurityAnswer = new Guna.UI2.WinForms.Guna2TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSecurityQuestion = new Guna.UI2.WinForms.Guna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gbPermissions = new Guna.UI2.WinForms.Guna2GroupBox();
            this.chkManageTransactions = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkManageReturn = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkManageBooking = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkManageVehicles = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkManageUsers = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkManageCustomers = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkAllPermissions = new Guna.UI2.WinForms.Guna2CheckBox();
            this.llRemoveImage = new System.Windows.Forms.LinkLabel();
            this.llSetImage = new System.Windows.Forms.LinkLabel();
            this.pbUserImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.chkIsActive = new Guna.UI2.WinForms.Guna2CheckBox();
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelPassword = new System.Windows.Forms.Panel();
            this.txtConfirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.llChangePassword = new System.Windows.Forms.LinkLabel();
            this.cbProvince = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rbFemale = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbMale = new Guna.UI2.WinForms.Guna2RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.guna2PanelMain.SuspendLayout();
            this.gbPermissions.SuspendLayout();
            this.panelPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2PanelMain
            // 
            this.guna2PanelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2PanelMain.BorderRadius = 15;
            this.guna2PanelMain.Controls.Add(this.txtSecurityAnswer);
            this.guna2PanelMain.Controls.Add(this.label11);
            this.guna2PanelMain.Controls.Add(this.txtSecurityQuestion);
            this.guna2PanelMain.Controls.Add(this.label9);
            this.guna2PanelMain.Controls.Add(this.gbPermissions);
            this.guna2PanelMain.Controls.Add(this.llRemoveImage);
            this.guna2PanelMain.Controls.Add(this.llSetImage);
            this.guna2PanelMain.Controls.Add(this.pbUserImage);
            this.guna2PanelMain.Controls.Add(this.chkIsActive);
            this.guna2PanelMain.Controls.Add(this.txtUsername);
            this.guna2PanelMain.Controls.Add(this.label3);
            this.guna2PanelMain.Controls.Add(this.panelPassword);
            this.guna2PanelMain.Controls.Add(this.llChangePassword);
            this.guna2PanelMain.Controls.Add(this.cbProvince);
            this.guna2PanelMain.Controls.Add(this.label8);
            this.guna2PanelMain.Controls.Add(this.txtPhone);
            this.guna2PanelMain.Controls.Add(this.label4);
            this.guna2PanelMain.Controls.Add(this.txtAddress);
            this.guna2PanelMain.Controls.Add(this.label12);
            this.guna2PanelMain.Controls.Add(this.txtEmail);
            this.guna2PanelMain.Controls.Add(this.label6);
            this.guna2PanelMain.Controls.Add(this.rbFemale);
            this.guna2PanelMain.Controls.Add(this.rbMale);
            this.guna2PanelMain.Controls.Add(this.label5);
            this.guna2PanelMain.Controls.Add(this.dtpDateOfBirth);
            this.guna2PanelMain.Controls.Add(this.label2);
            this.guna2PanelMain.Controls.Add(this.txtName);
            this.guna2PanelMain.Controls.Add(this.label1);
            this.guna2PanelMain.Controls.Add(this.lblUserID);
            this.guna2PanelMain.Controls.Add(this.label22);
            this.guna2PanelMain.FillColor = System.Drawing.Color.White;
            this.guna2PanelMain.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.guna2PanelMain.Location = new System.Drawing.Point(30, 85);
            this.guna2PanelMain.Name = "guna2PanelMain";
            this.guna2PanelMain.Size = new System.Drawing.Size(1238, 560);
            this.guna2PanelMain.TabIndex = 0;
            // 
            // txtSecurityAnswer
            // 
            this.txtSecurityAnswer.BorderRadius = 8;
            this.txtSecurityAnswer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSecurityAnswer.DefaultText = "";
            this.txtSecurityAnswer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSecurityAnswer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.txtSecurityAnswer.Location = new System.Drawing.Point(620, 160);
            this.txtSecurityAnswer.Name = "txtSecurityAnswer";
            this.txtSecurityAnswer.Size = new System.Drawing.Size(250, 36);
            this.txtSecurityAnswer.TabIndex = 11;
            this.txtSecurityAnswer.Validating += new System.ComponentModel.CancelEventHandler(this.txtSecurityAnswer_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.label11.Location = new System.Drawing.Point(460, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 19);
            this.label11.Text = "Trả lời bảo mật:";
            // 
            // txtSecurityQuestion
            // 
            this.txtSecurityQuestion.BorderRadius = 8;
            this.txtSecurityQuestion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSecurityQuestion.DefaultText = "";
            this.txtSecurityQuestion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSecurityQuestion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.txtSecurityQuestion.Location = new System.Drawing.Point(620, 80);
            this.txtSecurityQuestion.Multiline = true;
            this.txtSecurityQuestion.Name = "txtSecurityQuestion";
            this.txtSecurityQuestion.Size = new System.Drawing.Size(250, 70);
            this.txtSecurityQuestion.TabIndex = 10;
            this.txtSecurityQuestion.Validating += new System.ComponentModel.CancelEventHandler(this.txtSecurityQuestion_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.label9.Location = new System.Drawing.Point(460, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 19);
            this.label9.Text = "Câu hỏi bảo mật:";
            // 
            // gbPermissions
            // 
            this.gbPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPermissions.BorderRadius = 10;
            this.gbPermissions.Controls.Add(this.chkManageTransactions);
            this.gbPermissions.Controls.Add(this.chkManageReturn);
            this.gbPermissions.Controls.Add(this.chkManageBooking);
            this.gbPermissions.Controls.Add(this.chkManageVehicles);
            this.gbPermissions.Controls.Add(this.chkManageUsers);
            this.gbPermissions.Controls.Add(this.chkManageCustomers);
            this.gbPermissions.Controls.Add(this.chkAllPermissions);
            this.gbPermissions.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.gbPermissions.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.gbPermissions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.gbPermissions.Location = new System.Drawing.Point(900, 270);
            this.gbPermissions.Name = "gbPermissions";
            this.gbPermissions.Size = new System.Drawing.Size(230, 290);
            this.gbPermissions.TabIndex = 15;
            this.gbPermissions.Text = "Quyền truy cập";
            // 
            // chkManageTransactions
            // 
            this.chkManageTransactions.AutoSize = true;
            this.chkManageTransactions.Location = new System.Drawing.Point(15, 245);
            this.chkManageTransactions.Name = "chkManageTransactions";
            this.chkManageTransactions.Size = new System.Drawing.Size(136, 23);
            this.chkManageTransactions.TabIndex = 6;
            this.chkManageTransactions.Tag = "32";
            this.chkManageTransactions.Text = "Quản lý giao dịch";
            this.chkManageTransactions.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkManageReturn
            // 
            this.chkManageReturn.AutoSize = true;
            this.chkManageReturn.Location = new System.Drawing.Point(15, 212);
            this.chkManageReturn.Name = "chkManageReturn";
            this.chkManageReturn.Size = new System.Drawing.Size(113, 23);
            this.chkManageReturn.TabIndex = 5;
            this.chkManageReturn.Tag = "16";
            this.chkManageReturn.Text = "Quản lý trả xe";
            this.chkManageReturn.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkManageBooking
            // 
            this.chkManageBooking.AutoSize = true;
            this.chkManageBooking.Location = new System.Drawing.Point(15, 179);
            this.chkManageBooking.Name = "chkManageBooking";
            this.chkManageBooking.Size = new System.Drawing.Size(116, 23);
            this.chkManageBooking.TabIndex = 4;
            this.chkManageBooking.Tag = "8";
            this.chkManageBooking.Text = "Quản lý đặt xe";
            this.chkManageBooking.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkManageVehicles
            // 
            this.chkManageVehicles.AutoSize = true;
            this.chkManageVehicles.Location = new System.Drawing.Point(15, 146);
            this.chkManageVehicles.Name = "chkManageVehicles";
            this.chkManageVehicles.Size = new System.Drawing.Size(94, 23);
            this.chkManageVehicles.TabIndex = 3;
            this.chkManageVehicles.Tag = "4";
            this.chkManageVehicles.Text = "Quản lý xe";
            this.chkManageVehicles.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkManageUsers
            // 
            this.chkManageUsers.AutoSize = true;
            this.chkManageUsers.Location = new System.Drawing.Point(15, 113);
            this.chkManageUsers.Name = "chkManageUsers";
            this.chkManageUsers.Size = new System.Drawing.Size(150, 23);
            this.chkManageUsers.TabIndex = 2;
            this.chkManageUsers.Tag = "2";
            this.chkManageUsers.Text = "Quản lý người dùng";
            this.chkManageUsers.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkManageCustomers
            // 
            this.chkManageCustomers.AutoSize = true;
            this.chkManageCustomers.Location = new System.Drawing.Point(15, 80);
            this.chkManageCustomers.Name = "chkManageCustomers";
            this.chkManageCustomers.Size = new System.Drawing.Size(152, 23);
            this.chkManageCustomers.TabIndex = 1;
            this.chkManageCustomers.Tag = "1";
            this.chkManageCustomers.Text = "Quản lý khách hàng";
            this.chkManageCustomers.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkAllPermissions
            // 
            this.chkAllPermissions.AutoSize = true;
            this.chkAllPermissions.Location = new System.Drawing.Point(15, 47);
            this.chkAllPermissions.Name = "chkAllPermissions";
            this.chkAllPermissions.Size = new System.Drawing.Size(102, 23);
            this.chkAllPermissions.TabIndex = 0;
            this.chkAllPermissions.Tag = "-1";
            this.chkAllPermissions.Text = "Toàn quyền";
            this.chkAllPermissions.CheckedChanged += new System.EventHandler(this.chkAllPermissions_CheckedChanged);
            // 
            // llRemoveImage
            // 
            this.llRemoveImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llRemoveImage.AutoSize = false;
            this.llRemoveImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.llRemoveImage.LinkColor = System.Drawing.Color.Red;
            this.llRemoveImage.Location = new System.Drawing.Point(1050, 220);
            this.llRemoveImage.Name = "llRemoveImage";
            this.llRemoveImage.Size = new System.Drawing.Size(160, 20);
            this.llRemoveImage.TabIndex = 14;
            this.llRemoveImage.TabStop = true;
            this.llRemoveImage.Text = "Xóa ảnh";
            this.llRemoveImage.Visible = false;
            this.llRemoveImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llRemoveImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRemoveImage_LinkClicked);
            // 
            // llSetImage
            // 
            this.llSetImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llSetImage.AutoSize = false;
            this.llSetImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.llSetImage.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.llSetImage.Location = new System.Drawing.Point(1050, 195);
            this.llSetImage.Name = "llSetImage";
            this.llSetImage.Size = new System.Drawing.Size(160, 20);
            this.llSetImage.TabIndex = 13;
            this.llSetImage.TabStop = true;
            this.llSetImage.Text = "Chọn ảnh";
            this.llSetImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llSetImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSetImage_LinkClicked);
            // 
            // pbUserImage
            // 
            this.pbUserImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbUserImage.BackColor = System.Drawing.Color.Transparent;
            this.pbUserImage.BorderRadius = 15;
            this.pbUserImage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.pbUserImage.ImageRotate = 0F;
            this.pbUserImage.Location = new System.Drawing.Point(1050, 30);
            this.pbUserImage.Name = "pbUserImage";
            this.pbUserImage.Size = new System.Drawing.Size(160, 160);
            this.pbUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUserImage.TabIndex = 226;
            this.pbUserImage.TabStop = false;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.BackColor = System.Drawing.Color.Transparent;
            this.chkIsActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkIsActive.CheckedState.BorderRadius = 2;
            this.chkIsActive.CheckedState.BorderThickness = 0;
            this.chkIsActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.chkIsActive.Location = new System.Drawing.Point(464, 210);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(123, 23);
            this.chkIsActive.TabIndex = 12;
            this.chkIsActive.Text = "Kích hoạt User";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderRadius = 8;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.DefaultText = "";
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.txtUsername.Location = new System.Drawing.Point(620, 30);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(250, 36);
            this.txtUsername.TabIndex = 9;
            this.txtUsername.Validating += new System.ComponentModel.CancelEventHandler(this.txtUsername_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.label3.Location = new System.Drawing.Point(460, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.Text = "Tên đăng nhập:";
            // 
            // panelPassword
            // 
            this.panelPassword.BackColor = System.Drawing.Color.Transparent;
            this.panelPassword.Controls.Add(this.txtConfirmPassword);
            this.panelPassword.Controls.Add(this.label7);
            this.panelPassword.Controls.Add(this.label10);
            this.panelPassword.Controls.Add(this.txtPassword);
            this.panelPassword.Location = new System.Drawing.Point(450, 245);
            this.panelPassword.Name = "panelPassword";
            this.panelPassword.Size = new System.Drawing.Size(430, 95);
            this.panelPassword.TabIndex = 261;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BorderRadius = 8;
            this.txtConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmPassword.DefaultText = "";
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.txtConfirmPassword.Location = new System.Drawing.Point(170, 50);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '●';
            this.txtConfirmPassword.Size = new System.Drawing.Size(250, 36);
            this.txtConfirmPassword.TabIndex = 2;
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.label7.Location = new System.Drawing.Point(10, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 19);
            this.label7.Text = "Xác nhận mật khẩu:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.label10.Location = new System.Drawing.Point(10, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 19);
            this.label10.Text = "Mật khẩu mới:";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderRadius = 8;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.txtPassword.Location = new System.Drawing.Point(170, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(250, 36);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // llChangePassword
            // 
            this.llChangePassword.AutoSize = true;
            this.llChangePassword.BackColor = System.Drawing.Color.Transparent;
            this.llChangePassword.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.llChangePassword.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.llChangePassword.Location = new System.Drawing.Point(464, 350);
            this.llChangePassword.Name = "llChangePassword";
            this.llChangePassword.Size = new System.Drawing.Size(102, 19);
            this.llChangePassword.TabIndex = 254;
            this.llChangePassword.TabStop = true;
            this.llChangePassword.Text = "Đổi mật khẩu?";
            this.llChangePassword.Visible = false;
            this.llChangePassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llChangePassword_LinkClicked);
            // 
            // cbProvince
            // 
            this.cbProvince.BackColor = System.Drawing.Color.Transparent;
            this.cbProvince.BorderRadius = 8;
            this.cbProvince.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProvince.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cbProvince.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.cbProvince.ItemHeight = 30;
            this.cbProvince.Location = new System.Drawing.Point(180, 330);
            this.cbProvince.Name = "cbProvince";
            this.cbProvince.Size = new System.Drawing.Size(230, 36);
            this.cbProvince.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.label8.Location = new System.Drawing.Point(30, 338);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 19);
            this.label8.Text = "Tỉnh/Thành phố:";
            // 
            // txtPhone
            // 
            this.txtPhone.BorderRadius = 8;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.DefaultText = "";
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.txtPhone.Location = new System.Drawing.Point(160, 280);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(250, 36);
            this.txtPhone.TabIndex = 6;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            this.txtPhone.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.label4.Location = new System.Drawing.Point(30, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 19);
            this.label4.Text = "Điện thoại:";
            // 
            // txtAddress
            // 
            this.txtAddress.BorderRadius = 8;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.txtAddress.Location = new System.Drawing.Point(160, 380);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(250, 80);
            this.txtAddress.TabIndex = 8;
            this.txtAddress.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.label12.Location = new System.Drawing.Point(30, 388);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 19);
            this.label12.Text = "Địa chỉ:";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderRadius = 8;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.txtEmail.Location = new System.Drawing.Point(160, 230);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 36);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.label6.Location = new System.Drawing.Point(30, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 19);
            this.label6.Text = "Email:";
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.BackColor = System.Drawing.Color.Transparent;
            this.rbFemale.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbFemale.CheckedState.BorderThickness = 0;
            this.rbFemale.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbFemale.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbFemale.Location = new System.Drawing.Point(240, 190);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(43, 21);
            this.rbFemale.TabIndex = 4;
            this.rbFemale.Text = "Nữ";
            this.rbFemale.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbFemale.UncheckedState.BorderThickness = 2;
            this.rbFemale.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbFemale.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbFemale.Click += new System.EventHandler(this.rbFemale_Click);
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.BackColor = System.Drawing.Color.Transparent;
            this.rbMale.Checked = true;
            this.rbMale.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbMale.CheckedState.BorderThickness = 0;
            this.rbMale.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbMale.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbMale.Location = new System.Drawing.Point(160, 190);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(56, 21);
            this.rbMale.TabIndex = 3;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Nam";
            this.rbMale.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbMale.UncheckedState.BorderThickness = 2;
            this.rbMale.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbMale.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbMale.Click += new System.EventHandler(this.rbMale_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.label5.Location = new System.Drawing.Point(30, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 19);
            this.label5.Text = "Giới tính:";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.BorderRadius = 8;
            this.dtpDateOfBirth.Checked = true;
            this.dtpDateOfBirth.FillColor = System.Drawing.Color.White;
            this.dtpDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(160, 130);
            this.dtpDateOfBirth.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDateOfBirth.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(250, 36);
            this.dtpDateOfBirth.TabIndex = 2;
            this.dtpDateOfBirth.Value = new System.DateTime(2024, 3, 5, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.label2.Location = new System.Drawing.Point(30, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.Text = "Ngày sinh:";
            // 
            // txtName
            // 
            this.txtName.BorderRadius = 8;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.txtName.Location = new System.Drawing.Point(160, 80);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 36);
            this.txtName.TabIndex = 1;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.label1.Location = new System.Drawing.Point(30, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 19);
            this.label1.Text = "Họ tên:";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.BackColor = System.Drawing.Color.Transparent;
            this.lblUserID.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblUserID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.lblUserID.Location = new System.Drawing.Point(160, 38);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(43, 19);
            this.lblUserID.Text = "[????]";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.label22.Location = new System.Drawing.Point(30, 38);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(107, 19);
            this.label22.Text = "Mã người dùng:";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1298, 50);
            this.lblTitle.TabIndex = 206;
            this.lblTitle.Text = "TIÊU ĐỀ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BorderRadius = 8;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(1100, 660);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 45);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu thông tin";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderRadius = 8;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.btnClose.Location = new System.Drawing.Point(920, 660);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(160, 45);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Hủy bỏ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmAddEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(0, 740);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1298, 730);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.guna2PanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "frmAddEditUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm/Sửa người dùng";
            this.Load += new System.EventHandler(this.frmAddEditUser_Load);
            this.guna2PanelMain.ResumeLayout(false);
            this.guna2PanelMain.PerformLayout();
            this.gbPermissions.ResumeLayout(false);
            this.gbPermissions.PerformLayout();
            this.panelPassword.ResumeLayout(false);
            this.panelPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2PanelMain;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private Guna.UI2.WinForms.Guna2ComboBox cbProvince;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDateOfBirth;
        private Guna.UI2.WinForms.Guna2RadioButton rbMale;
        private Guna.UI2.WinForms.Guna2RadioButton rbFemale;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtConfirmPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtSecurityQuestion;
        private Guna.UI2.WinForms.Guna2TextBox txtSecurityAnswer;
        private Guna.UI2.WinForms.Guna2CheckBox chkIsActive;
        private Guna.UI2.WinForms.Guna2GroupBox gbPermissions;
        private Guna.UI2.WinForms.Guna2CheckBox chkAllPermissions;
        private Guna.UI2.WinForms.Guna2CheckBox chkManageCustomers;
        private Guna.UI2.WinForms.Guna2CheckBox chkManageUsers;
        private Guna.UI2.WinForms.Guna2CheckBox chkManageVehicles;
        private Guna.UI2.WinForms.Guna2CheckBox chkManageBooking;
        private Guna.UI2.WinForms.Guna2CheckBox chkManageReturn;
        private Guna.UI2.WinForms.Guna2CheckBox chkManageTransactions;
        private Guna.UI2.WinForms.Guna2PictureBox pbUserImage;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.LinkLabel llSetImage;
        private System.Windows.Forms.LinkLabel llRemoveImage;
        private System.Windows.Forms.LinkLabel llChangePassword;
        private System.Windows.Forms.Panel panelPassword;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}