namespace CarRental.Customers.UserControls
{
    partial class ucCustomerCard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucPersonCard1 = new CarRental.People.UserControls.ucPersonCard();
            this.guna2PanelCustomerInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.btnEditCustomerInfo = new Guna.UI2.WinForms.Guna2Button();
            this.lblHeaderCustomerInfo = new System.Windows.Forms.Label();
            this.lblDriverLicenseNumber = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2PanelCustomerInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucPersonCard1
            // 
            this.ucPersonCard1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucPersonCard1.BackColor = System.Drawing.Color.White;
            this.ucPersonCard1.Location = new System.Drawing.Point(3, 3);
            this.ucPersonCard1.Name = "ucPersonCard1";
            this.ucPersonCard1.Size = new System.Drawing.Size(718, 290);
            this.ucPersonCard1.TabIndex = 0;
            // 
            // guna2PanelCustomerInfo
            // 
            this.guna2PanelCustomerInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.guna2PanelCustomerInfo.BorderRadius = 14;
            this.guna2PanelCustomerInfo.BorderThickness = 1;
            this.guna2PanelCustomerInfo.Controls.Add(this.btnEditCustomerInfo);
            this.guna2PanelCustomerInfo.Controls.Add(this.lblHeaderCustomerInfo);
            this.guna2PanelCustomerInfo.Controls.Add(this.lblDriverLicenseNumber);
            this.guna2PanelCustomerInfo.Controls.Add(this.label22);
            this.guna2PanelCustomerInfo.Controls.Add(this.lblCustomerID);
            this.guna2PanelCustomerInfo.Controls.Add(this.label1);
            this.guna2PanelCustomerInfo.FillColor = System.Drawing.Color.White;
            this.guna2PanelCustomerInfo.Location = new System.Drawing.Point(8, 295);
            this.guna2PanelCustomerInfo.Name = "guna2PanelCustomerInfo";
            this.guna2PanelCustomerInfo.Size = new System.Drawing.Size(707, 97);
            this.guna2PanelCustomerInfo.TabIndex = 8;
            // 
            // btnEditCustomerInfo
            // 
            this.btnEditCustomerInfo.BorderRadius = 8;
            this.btnEditCustomerInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditCustomerInfo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.btnEditCustomerInfo.DisabledState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.btnEditCustomerInfo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnEditCustomerInfo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.btnEditCustomerInfo.Enabled = false;
            this.btnEditCustomerInfo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.btnEditCustomerInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditCustomerInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnEditCustomerInfo.Location = new System.Drawing.Point(530, 10);
            this.btnEditCustomerInfo.Name = "btnEditCustomerInfo";
            this.btnEditCustomerInfo.Size = new System.Drawing.Size(155, 32);
            this.btnEditCustomerInfo.TabIndex = 150;
            this.btnEditCustomerInfo.Text = "Chỉnh sửa";
            this.btnEditCustomerInfo.Click += new System.EventHandler(this.btnEditCustomerInfo_Click);
            // 
            // lblHeaderCustomerInfo
            // 
            this.lblHeaderCustomerInfo.AutoSize = true;
            this.lblHeaderCustomerInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderCustomerInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblHeaderCustomerInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblHeaderCustomerInfo.Location = new System.Drawing.Point(12, 10);
            this.lblHeaderCustomerInfo.Name = "lblHeaderCustomerInfo";
            this.lblHeaderCustomerInfo.Size = new System.Drawing.Size(160, 20);
            this.lblHeaderCustomerInfo.TabIndex = 151;
            this.lblHeaderCustomerInfo.Text = "Thông tin khách hàng";
            // 
            // lblDriverLicenseNumber
            // 
            this.lblDriverLicenseNumber.AutoSize = true;
            this.lblDriverLicenseNumber.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriverLicenseNumber.Location = new System.Drawing.Point(500, 55);
            this.lblDriverLicenseNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDriverLicenseNumber.Name = "lblDriverLicenseNumber";
            this.lblDriverLicenseNumber.Size = new System.Drawing.Size(50, 20);
            this.lblDriverLicenseNumber.TabIndex = 148;
            this.lblDriverLicenseNumber.Text = "[????]";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.label22.Location = new System.Drawing.Point(12, 55);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(116, 20);
            this.label22.TabIndex = 113;
            this.label22.Text = "Mã khách hàng:";
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.lblCustomerID.Location = new System.Drawing.Point(145, 55);
            this.lblCustomerID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(50, 20);
            this.lblCustomerID.TabIndex = 127;
            this.lblCustomerID.Text = "[????]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.label1.Location = new System.Drawing.Point(330, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 114;
            this.label1.Text = "Số bằng lái:";
            // 
            // ucCustomerCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2PanelCustomerInfo);
            this.Controls.Add(this.ucPersonCard1);
            this.Name = "ucCustomerCard";
            this.Size = new System.Drawing.Size(723, 397);
            this.guna2PanelCustomerInfo.ResumeLayout(false);
            this.guna2PanelCustomerInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private People.UserControls.ucPersonCard ucPersonCard1;
        private System.Windows.Forms.Label lblDriverLicenseNumber;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2PanelCustomerInfo;
        private System.Windows.Forms.Label lblHeaderCustomerInfo;
        private Guna.UI2.WinForms.Guna2Button btnEditCustomerInfo;
    }
}
