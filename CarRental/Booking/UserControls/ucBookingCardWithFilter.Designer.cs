namespace CarRental.Booking.UserControls
{
    partial class ucBookingCardWithFilter
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
            this.components = new System.ComponentModel.Container();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.cbSearchBy = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.ucBookingCard1 = new CarRental.Booking.UserControls.ucBookingCard();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.cbSearchBy);
            this.gbFilters.Controls.Add(this.label22);
            this.gbFilters.Controls.Add(this.btnAddNew);
            this.gbFilters.Controls.Add(this.btnFind);
            this.gbFilters.Controls.Add(this.txtFilterValue);
            this.gbFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilters.Location = new System.Drawing.Point(3, 3);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(776, 77);
            this.gbFilters.TabIndex = 19;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Bộ lọc";
            // 
            // cbSearchBy
            // 
            this.cbSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchBy.FormattingEnabled = true;
            this.cbSearchBy.Items.AddRange(new object[] {
            "Tất cả",
            "Theo mã",
            "Theo tên KH"});
            this.cbSearchBy.Location = new System.Drawing.Point(137, 29);
            this.cbSearchBy.Name = "cbSearchBy";
            this.cbSearchBy.Size = new System.Drawing.Size(120, 28);
            this.cbSearchBy.TabIndex = 16;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(20, 31);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(103, 20);
            this.label22.TabIndex = 114;
            this.label22.Text = "Từ khóa:";
            // 
            // btnAddNew
            // 
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.Image = global::CarRental.Properties.Resources.add_booking32;
            this.btnAddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNew.Location = new System.Drawing.Point(485, 23);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(120, 37);
            this.btnAddNew.TabIndex = 20;
            this.btnAddNew.Text = "  Thêm";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnFind
            // 
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Image = global::CarRental.Properties.Resources.search_booking32;
            this.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFind.Location = new System.Drawing.Point(365, 23);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(105, 37);
            this.btnFind.TabIndex = 18;
            this.btnFind.Text = "  Tìm";
            this.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Location = new System.Drawing.Point(263, 29);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(88, 26);
            this.txtFilterValue.TabIndex = 17;
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            this.txtFilterValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilterValue_Validating);
            // 
            // ucBookingCard1
            // 
            this.ucBookingCard1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucBookingCard1.BackColor = System.Drawing.Color.White;
            this.ucBookingCard1.Location = new System.Drawing.Point(0, 86);
            this.ucBookingCard1.Name = "ucBookingCard1";
            this.ucBookingCard1.Size = new System.Drawing.Size(785, 247);
            this.ucBookingCard1.TabIndex = 20;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucBookingCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucBookingCard1);
            this.Controls.Add(this.gbFilters);
            this.Name = "ucBookingCardWithFilter";
            this.Size = new System.Drawing.Size(788, 336);
            this.Load += new System.EventHandler(this.ucBookingCardWithFilter_Load);
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.ComboBox cbSearchBy;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtFilterValue;
        private ucBookingCard ucBookingCard1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
