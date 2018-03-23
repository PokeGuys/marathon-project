namespace MarathonSystem
{
    partial class frm_credit
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_pay = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_cancel = new System.Windows.Forms.Label();
            this.lbl_item = new System.Windows.Forms.Label();
            this.creditcard = new System.Windows.Forms.Panel();
            this.txt_cvv = new System.Windows.Forms.TextBox();
            this.lbl_cvv = new System.Windows.Forms.Label();
            this.cardBar = new System.Windows.Forms.Panel();
            this.lbl_cost = new System.Windows.Forms.Label();
            this.cardInfo = new System.Windows.Forms.Panel();
            this.txt_expire_year = new System.Windows.Forms.TextBox();
            this.txt_expire_month = new System.Windows.Forms.TextBox();
            this.lbl_expire = new System.Windows.Forms.Label();
            this.lbl_credit = new System.Windows.Forms.Label();
            this.txt_credit = new System.Windows.Forms.TextBox();
            this.pic_credit = new System.Windows.Forms.PictureBox();
            this.creditcard.SuspendLayout();
            this.cardInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_credit)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_pay
            // 
            this.btn_pay.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_pay.Enabled = false;
            this.btn_pay.FlatAppearance.BorderSize = 0;
            this.btn_pay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pay.Font = new System.Drawing.Font("Open Sans Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pay.Location = new System.Drawing.Point(327, 357);
            this.btn_pay.Margin = new System.Windows.Forms.Padding(4);
            this.btn_pay.Name = "btn_pay";
            this.btn_pay.Size = new System.Drawing.Size(172, 51);
            this.btn_pay.TabIndex = 35;
            this.btn_pay.Text = "Pay Now";
            this.btn_pay.UseVisualStyleBackColor = false;
            this.btn_pay.Click += new System.EventHandler(this.btn_pay_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_close.Location = new System.Drawing.Point(453, 0);
            this.btn_close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(69, 57);
            this.btn_close.TabIndex = 34;
            this.btn_close.Text = "×";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.lbl_title.Font = new System.Drawing.Font("Open Sans Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_title.Location = new System.Drawing.Point(0, 0);
            this.lbl_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(522, 57);
            this.lbl_title.TabIndex = 33;
            this.lbl_title.Text = "Payment via Credit/Debit Card";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_title_MouseDown);
            this.lbl_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_title_MouseMove);
            // 
            // lbl_cancel
            // 
            this.lbl_cancel.AutoSize = true;
            this.lbl_cancel.Font = new System.Drawing.Font("Open Sans Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cancel.Location = new System.Drawing.Point(16, 377);
            this.lbl_cancel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cancel.Name = "lbl_cancel";
            this.lbl_cancel.Size = new System.Drawing.Size(179, 19);
            this.lbl_cancel.TabIndex = 36;
            this.lbl_cancel.Text = "< Back to payment method";
            this.lbl_cancel.Click += new System.EventHandler(this.lbl_cancel_Click);
            // 
            // lbl_item
            // 
            this.lbl_item.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lbl_item.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_item.Font = new System.Drawing.Font("Open Sans Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_item.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_item.Location = new System.Drawing.Point(16, 81);
            this.lbl_item.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_item.Name = "lbl_item";
            this.lbl_item.Size = new System.Drawing.Size(493, 42);
            this.lbl_item.TabIndex = 37;
            this.lbl_item.Text = "   Event Registration";
            this.lbl_item.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // creditcard
            // 
            this.creditcard.BackColor = System.Drawing.SystemColors.ControlLight;
            this.creditcard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.creditcard.Controls.Add(this.txt_cvv);
            this.creditcard.Controls.Add(this.lbl_cvv);
            this.creditcard.Controls.Add(this.cardBar);
            this.creditcard.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.creditcard.Location = new System.Drawing.Point(200, 180);
            this.creditcard.Margin = new System.Windows.Forms.Padding(4);
            this.creditcard.Name = "creditcard";
            this.creditcard.Size = new System.Drawing.Size(299, 169);
            this.creditcard.TabIndex = 5;
            // 
            // txt_cvv
            // 
            this.txt_cvv.Font = new System.Drawing.Font("Open Sans Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cvv.Location = new System.Drawing.Point(190, 73);
            this.txt_cvv.Margin = new System.Windows.Forms.Padding(4);
            this.txt_cvv.MaxLength = 3;
            this.txt_cvv.Name = "txt_cvv";
            this.txt_cvv.PasswordChar = '•';
            this.txt_cvv.Size = new System.Drawing.Size(83, 26);
            this.txt_cvv.TabIndex = 2;
            this.txt_cvv.TextChanged += new System.EventHandler(this.txt_field_TextChanged);
            // 
            // lbl_cvv
            // 
            this.lbl_cvv.AutoSize = true;
            this.lbl_cvv.Font = new System.Drawing.Font("Open Sans Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cvv.Location = new System.Drawing.Point(186, 49);
            this.lbl_cvv.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cvv.Name = "lbl_cvv";
            this.lbl_cvv.Size = new System.Drawing.Size(81, 19);
            this.lbl_cvv.TabIndex = 1;
            this.lbl_cvv.Text = "CVV2/CVC2";
            // 
            // cardBar
            // 
            this.cardBar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cardBar.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cardBar.Location = new System.Drawing.Point(0, 17);
            this.cardBar.Margin = new System.Windows.Forms.Padding(4);
            this.cardBar.Name = "cardBar";
            this.cardBar.Size = new System.Drawing.Size(351, 28);
            this.cardBar.TabIndex = 0;
            // 
            // lbl_cost
            // 
            this.lbl_cost.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lbl_cost.Font = new System.Drawing.Font("Open Sans Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cost.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_cost.Location = new System.Drawing.Point(227, 93);
            this.lbl_cost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cost.Name = "lbl_cost";
            this.lbl_cost.Size = new System.Drawing.Size(272, 19);
            this.lbl_cost.TabIndex = 39;
            this.lbl_cost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cardInfo
            // 
            this.cardInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.cardInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardInfo.Controls.Add(this.txt_expire_year);
            this.cardInfo.Controls.Add(this.txt_expire_month);
            this.cardInfo.Controls.Add(this.lbl_expire);
            this.cardInfo.Controls.Add(this.lbl_credit);
            this.cardInfo.Controls.Add(this.txt_credit);
            this.cardInfo.Controls.Add(this.pic_credit);
            this.cardInfo.Location = new System.Drawing.Point(16, 132);
            this.cardInfo.Margin = new System.Windows.Forms.Padding(4);
            this.cardInfo.Name = "cardInfo";
            this.cardInfo.Size = new System.Drawing.Size(319, 182);
            this.cardInfo.TabIndex = 3;
            // 
            // txt_expire_year
            // 
            this.txt_expire_year.Font = new System.Drawing.Font("Open Sans Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_expire_year.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_expire_year.Location = new System.Drawing.Point(73, 92);
            this.txt_expire_year.Margin = new System.Windows.Forms.Padding(4);
            this.txt_expire_year.MaxLength = 2;
            this.txt_expire_year.Name = "txt_expire_year";
            this.txt_expire_year.Size = new System.Drawing.Size(47, 26);
            this.txt_expire_year.TabIndex = 11;
            this.txt_expire_year.Text = "YY";
            this.txt_expire_year.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_expire_year.TextChanged += new System.EventHandler(this.txt_field_TextChanged);
            this.txt_expire_year.GotFocus += new System.EventHandler(this.txt_expire_year_GotFocus);
            this.txt_expire_year.LostFocus += new System.EventHandler(this.txt_expire_year_LostFocus);
            // 
            // txt_expire_month
            // 
            this.txt_expire_month.Font = new System.Drawing.Font("Open Sans Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_expire_month.ForeColor = System.Drawing.Color.LightGray;
            this.txt_expire_month.Location = new System.Drawing.Point(17, 92);
            this.txt_expire_month.Margin = new System.Windows.Forms.Padding(4);
            this.txt_expire_month.MaxLength = 2;
            this.txt_expire_month.Name = "txt_expire_month";
            this.txt_expire_month.Size = new System.Drawing.Size(47, 26);
            this.txt_expire_month.TabIndex = 10;
            this.txt_expire_month.Text = "MM";
            this.txt_expire_month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_expire_month.TextChanged += new System.EventHandler(this.txt_field_TextChanged);
            this.txt_expire_month.GotFocus += new System.EventHandler(this.txt_expire_month_GotFocus);
            this.txt_expire_month.LostFocus += new System.EventHandler(this.txt_expire_month_LostFocus);
            // 
            // lbl_expire
            // 
            this.lbl_expire.AutoSize = true;
            this.lbl_expire.Font = new System.Drawing.Font("Open Sans Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_expire.Location = new System.Drawing.Point(13, 69);
            this.lbl_expire.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_expire.Name = "lbl_expire";
            this.lbl_expire.Size = new System.Drawing.Size(103, 19);
            this.lbl_expire.TabIndex = 9;
            this.lbl_expire.Text = "Expiration date";
            // 
            // lbl_credit
            // 
            this.lbl_credit.AutoSize = true;
            this.lbl_credit.Font = new System.Drawing.Font("Open Sans Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_credit.Location = new System.Drawing.Point(13, 12);
            this.lbl_credit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_credit.Name = "lbl_credit";
            this.lbl_credit.Size = new System.Drawing.Size(91, 19);
            this.lbl_credit.TabIndex = 7;
            this.lbl_credit.Text = "Card number";
            // 
            // txt_credit
            // 
            this.txt_credit.Font = new System.Drawing.Font("Open Sans Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_credit.Location = new System.Drawing.Point(17, 36);
            this.txt_credit.Margin = new System.Windows.Forms.Padding(4);
            this.txt_credit.Name = "txt_credit";
            this.txt_credit.Size = new System.Drawing.Size(290, 26);
            this.txt_credit.TabIndex = 8;
            this.txt_credit.TextChanged += new System.EventHandler(this.txt_field_TextChanged);
            // 
            // pic_credit
            // 
            this.pic_credit.Image = global::MarathonSystem.Properties.Resources.accept_credit;
            this.pic_credit.Location = new System.Drawing.Point(98, 131);
            this.pic_credit.Margin = new System.Windows.Forms.Padding(4);
            this.pic_credit.Name = "pic_credit";
            this.pic_credit.Size = new System.Drawing.Size(209, 38);
            this.pic_credit.TabIndex = 6;
            this.pic_credit.TabStop = false;
            // 
            // frm_credit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 424);
            this.Controls.Add(this.cardInfo);
            this.Controls.Add(this.lbl_cost);
            this.Controls.Add(this.lbl_item);
            this.Controls.Add(this.lbl_cancel);
            this.Controls.Add(this.btn_pay);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.creditcard);
            this.Controls.Add(this.lbl_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_credit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payment via Credit Card";
            this.Load += new System.EventHandler(this.Frm_Credit_Load);
            this.creditcard.ResumeLayout(false);
            this.creditcard.PerformLayout();
            this.cardInfo.ResumeLayout(false);
            this.cardInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_credit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_pay;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_cancel;
        private System.Windows.Forms.Label lbl_item;
        private System.Windows.Forms.Panel creditcard;
        private System.Windows.Forms.TextBox txt_cvv;
        private System.Windows.Forms.Label lbl_cvv;
        private System.Windows.Forms.Panel cardBar;
        private System.Windows.Forms.Label lbl_cost;
        private System.Windows.Forms.Panel cardInfo;
        private System.Windows.Forms.TextBox txt_expire_year;
        private System.Windows.Forms.TextBox txt_expire_month;
        private System.Windows.Forms.Label lbl_expire;
        private System.Windows.Forms.Label lbl_credit;
        private System.Windows.Forms.TextBox txt_credit;
        private System.Windows.Forms.PictureBox pic_credit;
    }
}