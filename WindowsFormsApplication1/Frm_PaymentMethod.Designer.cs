namespace MarathonSystem
{
    partial class Frm_PaymentMethod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_PaymentMethod));
            this.btn_close = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btn_credit = new System.Windows.Forms.Button();
            this.btn_bank = new System.Windows.Forms.Button();
            this.lbl_cancel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_close.Location = new System.Drawing.Point(377, 0);
            this.btn_close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(69, 57);
            this.btn_close.TabIndex = 18;
            this.btn_close.Text = "×";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.lbl_title.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_title.Location = new System.Drawing.Point(0, 0);
            this.lbl_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(447, 57);
            this.lbl_title.TabIndex = 17;
            this.lbl_title.Text = "Payment Method";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_title_MouseDown);
            this.lbl_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_title_MouseMove);
            // 
            // btn_credit
            // 
            this.btn_credit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_credit.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_credit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_credit.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_credit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.btn_credit.Image = global::MarathonSystem.Properties.Resources.credit_card;
            this.btn_credit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_credit.Location = new System.Drawing.Point(16, 89);
            this.btn_credit.Margin = new System.Windows.Forms.Padding(4);
            this.btn_credit.Name = "btn_credit";
            this.btn_credit.Size = new System.Drawing.Size(188, 51);
            this.btn_credit.TabIndex = 31;
            this.btn_credit.Text = "Credit Card";
            this.btn_credit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_credit.UseVisualStyleBackColor = false;
            this.btn_credit.Click += new System.EventHandler(this.btn_credit_Click);
            // 
            // btn_bank
            // 
            this.btn_bank.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_bank.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_bank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_bank.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_bank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.btn_bank.Image = global::MarathonSystem.Properties.Resources.receipt;
            this.btn_bank.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_bank.Location = new System.Drawing.Point(244, 89);
            this.btn_bank.Margin = new System.Windows.Forms.Padding(4);
            this.btn_bank.Name = "btn_bank";
            this.btn_bank.Size = new System.Drawing.Size(188, 51);
            this.btn_bank.TabIndex = 32;
            this.btn_bank.Text = "Bank-in receipt";
            this.btn_bank.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_bank.UseVisualStyleBackColor = false;
            this.btn_bank.Click += new System.EventHandler(this.btn_bank_Click);
            // 
            // lbl_cancel
            // 
            this.lbl_cancel.AutoSize = true;
            this.lbl_cancel.Font = new System.Drawing.Font("Open Sans Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.lbl_cancel.Location = new System.Drawing.Point(12, 201);
            this.lbl_cancel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cancel.Name = "lbl_cancel";
            this.lbl_cancel.Size = new System.Drawing.Size(179, 19);
            this.lbl_cancel.TabIndex = 37;
            this.lbl_cancel.Text = "< Back to payment method";
            this.lbl_cancel.Click += new System.EventHandler(this.lbl_cancel_Click);
            // 
            // Frm_PaymentMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 235);
            this.Controls.Add(this.lbl_cancel);
            this.Controls.Add(this.btn_bank);
            this.Controls.Add(this.btn_credit);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.lbl_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_PaymentMethod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payment Method";
            this.Load += new System.EventHandler(this.Frm_PaymentMethod_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btn_credit;
        private System.Windows.Forms.Button btn_bank;
        private System.Windows.Forms.Label lbl_cancel;
    }
}