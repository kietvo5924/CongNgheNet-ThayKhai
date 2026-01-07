namespace CarRental.Users.UserControls
{
    partial class ucUserCard
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.ucPersonCard1 = new CarRental.People.UserControls.ucPersonCard();
            this.guna2PanelUser = new Guna.UI2.WinForms.Guna2Panel();
            this.btnEditUserInfo = new Guna.UI2.WinForms.Guna2Button();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbUserImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2PanelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ucPersonCard1
            // 
            this.ucPersonCard1.BackColor = System.Drawing.Color.White;
            this.ucPersonCard1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucPersonCard1.Location = new System.Drawing.Point(0, 0);
            this.ucPersonCard1.Name = "ucPersonCard1";
            this.ucPersonCard1.Size = new System.Drawing.Size(718, 290);
            this.ucPersonCard1.TabIndex = 0;
            // 
            // guna2PanelUser
            // 
            this.guna2PanelUser.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.guna2PanelUser.BorderRadius = 12;
            this.guna2PanelUser.BorderThickness = 1;
            this.guna2PanelUser.Controls.Add(this.btnEditUserInfo);
            this.guna2PanelUser.Controls.Add(this.lblIsActive);
            this.guna2PanelUser.Controls.Add(this.label3);
            this.guna2PanelUser.Controls.Add(this.lblUsername);
            this.guna2PanelUser.Controls.Add(this.label22);
            this.guna2PanelUser.Controls.Add(this.lblUserID);
            this.guna2PanelUser.Controls.Add(this.label1);
            this.guna2PanelUser.Controls.Add(this.pbUserImage);
            this.guna2PanelUser.Controls.Add(this.label4);
            this.guna2PanelUser.FillColor = System.Drawing.Color.White;
            this.guna2PanelUser.Location = new System.Drawing.Point(0, 300);
            this.guna2PanelUser.Name = "guna2PanelUser";
            this.guna2PanelUser.Size = new System.Drawing.Size(718, 175);
            this.guna2PanelUser.TabIndex = 1;
            // 
            // btnEditUserInfo
            // 
            this.btnEditUserInfo.BorderRadius = 8;
            this.btnEditUserInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditUserInfo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditUserInfo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditUserInfo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditUserInfo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditUserInfo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnEditUserInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnEditUserInfo.ForeColor = System.Drawing.Color.White;
            this.btnEditUserInfo.Location = new System.Drawing.Point(380, 125);
            this.btnEditUserInfo.Name = "btnEditUserInfo";
            this.btnEditUserInfo.Size = new System.Drawing.Size(130, 35);
            this.btnEditUserInfo.TabIndex = 154;
            this.btnEditUserInfo.Text = "Chỉnh sửa";
            this.btnEditUserInfo.Click += new System.EventHandler(this.btnEditUserInfo_Click);
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.BackColor = System.Drawing.Color.Transparent;
            this.lblIsActive.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblIsActive.Location = new System.Drawing.Point(150, 133);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(43, 19);
            this.lblIsActive.Text = "[????]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(25, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 19);
            this.label3.Text = "Trạng thái:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsername.Location = new System.Drawing.Point(150, 93);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(43, 19);
            this.lblUsername.Text = "[????]";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.Color.Gray;
            this.label22.Location = new System.Drawing.Point(25, 53);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(107, 19);
            this.label22.Text = "Mã người dùng:";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.BackColor = System.Drawing.Color.Transparent;
            this.lblUserID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.lblUserID.Location = new System.Drawing.Point(150, 53);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(43, 19);
            this.lblUserID.Text = "[????]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(25, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.Text = "Tên đăng nhập:";
            // 
            // pbUserImage
            // 
            this.pbUserImage.BackColor = System.Drawing.Color.Transparent;
            this.pbUserImage.BorderRadius = 15;
            this.pbUserImage.Image = global::CarRental.Properties.Resources.DefaultMale;
            this.pbUserImage.ImageRotate = 0F;
            this.pbUserImage.Location = new System.Drawing.Point(550, 15);
            this.pbUserImage.Name = "pbUserImage";
            this.pbUserImage.Size = new System.Drawing.Size(145, 145);
            this.pbUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUserImage.TabIndex = 153;
            this.pbUserImage.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(15, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 21);
            this.label4.Text = "Thông tin đăng nhập";
            // 
            // ucUserCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2PanelUser);
            this.Controls.Add(this.ucPersonCard1);
            this.Name = "ucUserCard";
            this.Size = new System.Drawing.Size(719, 485);
            this.guna2PanelUser.ResumeLayout(false);
            this.guna2PanelUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private People.UserControls.ucPersonCard ucPersonCard1;
        private Guna.UI2.WinForms.Guna2Panel guna2PanelUser;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2PictureBox pbUserImage;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button btnEditUserInfo;
    }
}