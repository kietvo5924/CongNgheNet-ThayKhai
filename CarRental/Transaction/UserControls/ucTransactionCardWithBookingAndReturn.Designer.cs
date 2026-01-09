namespace CarRental.Transaction.UserControls
{
    partial class ucTransactionCardWithBookingAndReturn
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
            this.ucBookingAndReturnCard1 = new CarRental.Transaction.UserControls.ucBookingAndReturnCard();
            this.ucTransactionCard1 = new CarRental.Transaction.UserControls.ucTransactionCard();
            this.SuspendLayout();
            // 
            // ucBookingAndReturnCard1 (Thông tin tổng hợp)
            // 
            this.ucBookingAndReturnCard1.BackColor = System.Drawing.Color.White;
            this.ucBookingAndReturnCard1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucBookingAndReturnCard1.Location = new System.Drawing.Point(0, 0);
            this.ucBookingAndReturnCard1.Name = "ucBookingAndReturnCard1";
            this.ucBookingAndReturnCard1.Size = new System.Drawing.Size(799, 360);
            this.ucBookingAndReturnCard1.TabIndex = 0;
            // 
            // ucTransactionCard1 (Chi tiết tiền nong)
            // 
            this.ucTransactionCard1.BackColor = System.Drawing.Color.White;
            this.ucTransactionCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTransactionCard1.Location = new System.Drawing.Point(0, 360);
            this.ucTransactionCard1.Name = "ucTransactionCard1";
            this.ucTransactionCard1.Size = new System.Drawing.Size(785, 380);
            this.ucTransactionCard1.TabIndex = 1;
            // 
            // ucTransactionCardWithBookingAndReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ucTransactionCard1);
            this.Controls.Add(this.ucBookingAndReturnCard1);
            this.Name = "ucTransactionCardWithBookingAndReturn";
            this.Size = new System.Drawing.Size(800, 740);
            this.ResumeLayout(false);

        }

        #endregion

        private ucBookingAndReturnCard ucBookingAndReturnCard1;
        private ucTransactionCard ucTransactionCard1;
    }
}