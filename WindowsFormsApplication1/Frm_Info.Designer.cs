namespace MarathonSystem
{
    partial class Frm_Info
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
            this.lbl_event_title = new System.Windows.Forms.Label();
            this.txt_title = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_submit = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_period = new System.Windows.Forms.Label();
            this.lbl_event_type = new System.Windows.Forms.Label();
            this.eventTypeList = new System.Windows.Forms.ComboBox();
            this.lbl_startdatetime = new System.Windows.Forms.Label();
            this.numQuota = new System.Windows.Forms.NumericUpDown();
            this.lbl_quota = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.dateStartAt = new System.Windows.Forms.DateTimePicker();
            this.dateRegStart = new System.Windows.Forms.DateTimePicker();
            this.dateRegEnd = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.numQuota)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_event_title
            // 
            this.lbl_event_title.AutoSize = true;
            this.lbl_event_title.Location = new System.Drawing.Point(15, 92);
            this.lbl_event_title.Name = "lbl_event_title";
            this.lbl_event_title.Size = new System.Drawing.Size(27, 13);
            this.lbl_event_title.TabIndex = 39;
            this.lbl_event_title.Text = "Title";
            // 
            // txt_title
            // 
            this.txt_title.ForeColor = System.Drawing.Color.Black;
            this.txt_title.Location = new System.Drawing.Point(116, 89);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(268, 20);
            this.txt_title.TabIndex = 36;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_cancel.FlatAppearance.BorderSize = 0;
            this.btn_cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btn_cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(18, 234);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(167, 42);
            this.btn_cancel.TabIndex = 35;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_submit
            // 
            this.btn_submit.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_submit.FlatAppearance.BorderSize = 0;
            this.btn_submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_submit.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.Location = new System.Drawing.Point(218, 234);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(166, 42);
            this.btn_submit.TabIndex = 34;
            this.btn_submit.UseVisualStyleBackColor = false;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_close.Location = new System.Drawing.Point(357, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(52, 47);
            this.btn_close.TabIndex = 33;
            this.btn_close.Text = "×";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.lbl_title.Font = new System.Drawing.Font("Microsoft YaHei Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_title.Location = new System.Drawing.Point(0, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(409, 47);
            this.lbl_title.TabIndex = 32;
            this.lbl_title.Text = "Marathon Info";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Lbl_title_MouseDown);
            this.lbl_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Lbl_title_MouseMove);
            // 
            // lbl_period
            // 
            this.lbl_period.AutoSize = true;
            this.lbl_period.Location = new System.Drawing.Point(15, 121);
            this.lbl_period.Name = "lbl_period";
            this.lbl_period.Size = new System.Drawing.Size(95, 13);
            this.lbl_period.TabIndex = 40;
            this.lbl_period.Text = "Registration period";
            // 
            // lbl_event_type
            // 
            this.lbl_event_type.AutoSize = true;
            this.lbl_event_type.Location = new System.Drawing.Point(15, 65);
            this.lbl_event_type.Name = "lbl_event_type";
            this.lbl_event_type.Size = new System.Drawing.Size(62, 13);
            this.lbl_event_type.TabIndex = 46;
            this.lbl_event_type.Text = "Event Type";
            // 
            // eventTypeList
            // 
            this.eventTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventTypeList.FormattingEnabled = true;
            this.eventTypeList.Location = new System.Drawing.Point(116, 62);
            this.eventTypeList.Name = "eventTypeList";
            this.eventTypeList.Size = new System.Drawing.Size(268, 21);
            this.eventTypeList.TabIndex = 48;
            // 
            // lbl_startdatetime
            // 
            this.lbl_startdatetime.AutoSize = true;
            this.lbl_startdatetime.Location = new System.Drawing.Point(15, 147);
            this.lbl_startdatetime.Name = "lbl_startdatetime";
            this.lbl_startdatetime.Size = new System.Drawing.Size(42, 13);
            this.lbl_startdatetime.TabIndex = 49;
            this.lbl_startdatetime.Text = "Start At";
            // 
            // numQuota
            // 
            this.numQuota.Location = new System.Drawing.Point(116, 168);
            this.numQuota.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numQuota.Name = "numQuota";
            this.numQuota.Size = new System.Drawing.Size(268, 20);
            this.numQuota.TabIndex = 51;
            // 
            // lbl_quota
            // 
            this.lbl_quota.AutoSize = true;
            this.lbl_quota.Location = new System.Drawing.Point(15, 173);
            this.lbl_quota.Name = "lbl_quota";
            this.lbl_quota.Size = new System.Drawing.Size(36, 13);
            this.lbl_quota.TabIndex = 52;
            this.lbl_quota.Text = "Quota";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Price";
            // 
            // numPrice
            // 
            this.numPrice.Location = new System.Drawing.Point(116, 194);
            this.numPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(269, 20);
            this.numPrice.TabIndex = 53;
            // 
            // dateStartAt
            // 
            this.dateStartAt.CustomFormat = " ";
            this.dateStartAt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStartAt.Location = new System.Drawing.Point(116, 141);
            this.dateStartAt.Name = "dateStartAt";
            this.dateStartAt.Size = new System.Drawing.Size(268, 20);
            this.dateStartAt.TabIndex = 55;
            this.dateStartAt.ValueChanged += new System.EventHandler(this.dateRegStart_ValueChanged);
            // 
            // dateRegStart
            // 
            this.dateRegStart.CustomFormat = " ";
            this.dateRegStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateRegStart.Location = new System.Drawing.Point(116, 115);
            this.dateRegStart.Name = "dateRegStart";
            this.dateRegStart.Size = new System.Drawing.Size(131, 20);
            this.dateRegStart.TabIndex = 56;
            this.dateRegStart.ValueChanged += new System.EventHandler(this.dateRegStart_ValueChanged);
            // 
            // dateRegEnd
            // 
            this.dateRegEnd.CustomFormat = " ";
            this.dateRegEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateRegEnd.Location = new System.Drawing.Point(253, 115);
            this.dateRegEnd.Name = "dateRegEnd";
            this.dateRegEnd.Size = new System.Drawing.Size(131, 20);
            this.dateRegEnd.TabIndex = 57;
            this.dateRegEnd.ValueChanged += new System.EventHandler(this.dateRegStart_ValueChanged);
            // 
            // Frm_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 290);
            this.Controls.Add(this.dateRegEnd);
            this.Controls.Add(this.dateRegStart);
            this.Controls.Add(this.dateStartAt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.lbl_quota);
            this.Controls.Add(this.numQuota);
            this.Controls.Add(this.lbl_startdatetime);
            this.Controls.Add(this.lbl_period);
            this.Controls.Add(this.lbl_event_title);
            this.Controls.Add(this.txt_title);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.eventTypeList);
            this.Controls.Add(this.lbl_event_type);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frm_Info";
            this.Load += new System.EventHandler(this.Frm_Info_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuota)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_event_title;
        private System.Windows.Forms.TextBox txt_title;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_period;
        private System.Windows.Forms.Label lbl_event_type;
        private System.Windows.Forms.ComboBox eventTypeList;
        private System.Windows.Forms.Label lbl_startdatetime;
        private System.Windows.Forms.NumericUpDown numQuota;
        private System.Windows.Forms.Label lbl_quota;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.DateTimePicker dateStartAt;
        private System.Windows.Forms.DateTimePicker dateRegStart;
        private System.Windows.Forms.DateTimePicker dateRegEnd;
    }
}