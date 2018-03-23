namespace MarathonSystem
{
    partial class Frm_ManageMarathon
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
            this.txt_name = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_submit = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.countryList = new System.Windows.Forms.ComboBox();
            this.lbl_event_type = new System.Windows.Forms.Label();
            this.txt_city = new System.Windows.Forms.TextBox();
            this.lbl_city = new System.Windows.Forms.Label();
            this.lbl_year = new System.Windows.Forms.Label();
            this.date_holdat = new System.Windows.Forms.DateTimePicker();
            this.btn_upload_map = new System.Windows.Forms.Button();
            this.txt_map = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_logo = new System.Windows.Forms.Label();
            this.txt_logo = new System.Windows.Forms.TextBox();
            this.btn_upload_logo = new System.Windows.Forms.Button();
            this.lbl_seal = new System.Windows.Forms.Label();
            this.txt_seal = new System.Windows.Forms.TextBox();
            this.btn_upload_seal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_event_title
            // 
            this.lbl_event_title.AutoSize = true;
            this.lbl_event_title.Location = new System.Drawing.Point(15, 91);
            this.lbl_event_title.Name = "lbl_event_title";
            this.lbl_event_title.Size = new System.Drawing.Size(37, 15);
            this.lbl_event_title.TabIndex = 63;
            this.lbl_event_title.Text = "Name";
            // 
            // txt_name
            // 
            this.txt_name.ForeColor = System.Drawing.Color.Black;
            this.txt_name.Location = new System.Drawing.Point(116, 88);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(268, 22);
            this.txt_name.TabIndex = 62;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_cancel.FlatAppearance.BorderSize = 0;
            this.btn_cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btn_cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(18, 271);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(167, 42);
            this.btn_cancel.TabIndex = 61;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_submit
            // 
            this.btn_submit.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_submit.Enabled = false;
            this.btn_submit.FlatAppearance.BorderSize = 0;
            this.btn_submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_submit.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.Location = new System.Drawing.Point(218, 271);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(166, 42);
            this.btn_submit.TabIndex = 60;
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
            this.btn_close.Location = new System.Drawing.Point(357, -1);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(52, 47);
            this.btn_close.TabIndex = 59;
            this.btn_close.Text = "×";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.lbl_title.Font = new System.Drawing.Font("Microsoft YaHei Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_title.Location = new System.Drawing.Point(0, -1);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(409, 47);
            this.lbl_title.TabIndex = 58;
            this.lbl_title.Text = "Marathon Info";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Lbl_title_MouseDown);
            this.lbl_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Lbl_title_MouseMove);
            // 
            // countryList
            // 
            this.countryList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countryList.FormattingEnabled = true;
            this.countryList.Location = new System.Drawing.Point(116, 61);
            this.countryList.Name = "countryList";
            this.countryList.Size = new System.Drawing.Size(268, 23);
            this.countryList.TabIndex = 66;
            this.countryList.SelectedIndexChanged += new System.EventHandler(this.countryList_SelectedIndexChanged);
            // 
            // lbl_event_type
            // 
            this.lbl_event_type.AutoSize = true;
            this.lbl_event_type.Location = new System.Drawing.Point(15, 64);
            this.lbl_event_type.Name = "lbl_event_type";
            this.lbl_event_type.Size = new System.Drawing.Size(49, 15);
            this.lbl_event_type.TabIndex = 65;
            this.lbl_event_type.Text = "Country";
            // 
            // txt_city
            // 
            this.txt_city.ForeColor = System.Drawing.Color.Black;
            this.txt_city.Location = new System.Drawing.Point(116, 116);
            this.txt_city.Name = "txt_city";
            this.txt_city.Size = new System.Drawing.Size(268, 22);
            this.txt_city.TabIndex = 72;
            // 
            // lbl_city
            // 
            this.lbl_city.AutoSize = true;
            this.lbl_city.Location = new System.Drawing.Point(15, 119);
            this.lbl_city.Name = "lbl_city";
            this.lbl_city.Size = new System.Drawing.Size(27, 15);
            this.lbl_city.TabIndex = 73;
            this.lbl_city.Text = "City";
            // 
            // lbl_year
            // 
            this.lbl_year.AutoSize = true;
            this.lbl_year.Location = new System.Drawing.Point(15, 150);
            this.lbl_year.Name = "lbl_year";
            this.lbl_year.Size = new System.Drawing.Size(45, 15);
            this.lbl_year.TabIndex = 74;
            this.lbl_year.Text = "Hold at";
            // 
            // date_holdat
            // 
            this.date_holdat.CustomFormat = "yyyy";
            this.date_holdat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_holdat.Location = new System.Drawing.Point(116, 144);
            this.date_holdat.Name = "date_holdat";
            this.date_holdat.ShowUpDown = true;
            this.date_holdat.Size = new System.Drawing.Size(268, 22);
            this.date_holdat.TabIndex = 75;
            // 
            // btn_upload_map
            // 
            this.btn_upload_map.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_upload_map.FlatAppearance.BorderSize = 0;
            this.btn_upload_map.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_upload_map.Font = new System.Drawing.Font("Open Sans Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_upload_map.Location = new System.Drawing.Point(298, 172);
            this.btn_upload_map.Name = "btn_upload_map";
            this.btn_upload_map.Size = new System.Drawing.Size(86, 22);
            this.btn_upload_map.TabIndex = 76;
            this.btn_upload_map.Text = "Upload";
            this.btn_upload_map.UseVisualStyleBackColor = false;
            this.btn_upload_map.Click += new System.EventHandler(this.btn_upload_map_Click);
            // 
            // txt_map
            // 
            this.txt_map.ForeColor = System.Drawing.Color.Black;
            this.txt_map.Location = new System.Drawing.Point(116, 172);
            this.txt_map.Name = "txt_map";
            this.txt_map.Size = new System.Drawing.Size(176, 22);
            this.txt_map.TabIndex = 77;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 78;
            this.label2.Text = "Map";
            // 
            // lbl_logo
            // 
            this.lbl_logo.AutoSize = true;
            this.lbl_logo.Location = new System.Drawing.Point(15, 204);
            this.lbl_logo.Name = "lbl_logo";
            this.lbl_logo.Size = new System.Drawing.Size(33, 15);
            this.lbl_logo.TabIndex = 81;
            this.lbl_logo.Text = "Logo";
            // 
            // txt_logo
            // 
            this.txt_logo.ForeColor = System.Drawing.Color.Black;
            this.txt_logo.Location = new System.Drawing.Point(116, 200);
            this.txt_logo.Name = "txt_logo";
            this.txt_logo.Size = new System.Drawing.Size(176, 22);
            this.txt_logo.TabIndex = 80;
            // 
            // btn_upload_logo
            // 
            this.btn_upload_logo.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_upload_logo.FlatAppearance.BorderSize = 0;
            this.btn_upload_logo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_upload_logo.Font = new System.Drawing.Font("Open Sans Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_upload_logo.Location = new System.Drawing.Point(298, 200);
            this.btn_upload_logo.Name = "btn_upload_logo";
            this.btn_upload_logo.Size = new System.Drawing.Size(86, 22);
            this.btn_upload_logo.TabIndex = 79;
            this.btn_upload_logo.Text = "Upload";
            this.btn_upload_logo.UseVisualStyleBackColor = false;
            this.btn_upload_logo.Click += new System.EventHandler(this.btn_upload_logo_Click);
            // 
            // lbl_seal
            // 
            this.lbl_seal.AutoSize = true;
            this.lbl_seal.Location = new System.Drawing.Point(15, 232);
            this.lbl_seal.Name = "lbl_seal";
            this.lbl_seal.Size = new System.Drawing.Size(28, 15);
            this.lbl_seal.TabIndex = 84;
            this.lbl_seal.Text = "Seal";
            // 
            // txt_seal
            // 
            this.txt_seal.ForeColor = System.Drawing.Color.Black;
            this.txt_seal.Location = new System.Drawing.Point(116, 228);
            this.txt_seal.Name = "txt_seal";
            this.txt_seal.Size = new System.Drawing.Size(176, 22);
            this.txt_seal.TabIndex = 83;
            // 
            // btn_upload_seal
            // 
            this.btn_upload_seal.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_upload_seal.FlatAppearance.BorderSize = 0;
            this.btn_upload_seal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_upload_seal.Font = new System.Drawing.Font("Open Sans Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_upload_seal.Location = new System.Drawing.Point(298, 228);
            this.btn_upload_seal.Name = "btn_upload_seal";
            this.btn_upload_seal.Size = new System.Drawing.Size(86, 22);
            this.btn_upload_seal.TabIndex = 82;
            this.btn_upload_seal.Text = "Upload";
            this.btn_upload_seal.UseVisualStyleBackColor = false;
            this.btn_upload_seal.Click += new System.EventHandler(this.btn_upload_seal_Click);
            // 
            // Frm_ManageMarathon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 329);
            this.Controls.Add(this.lbl_seal);
            this.Controls.Add(this.txt_seal);
            this.Controls.Add(this.btn_upload_seal);
            this.Controls.Add(this.lbl_logo);
            this.Controls.Add(this.txt_logo);
            this.Controls.Add(this.btn_upload_logo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_map);
            this.Controls.Add(this.btn_upload_map);
            this.Controls.Add(this.date_holdat);
            this.Controls.Add(this.lbl_year);
            this.Controls.Add(this.lbl_city);
            this.Controls.Add(this.txt_city);
            this.Controls.Add(this.lbl_event_title);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.countryList);
            this.Controls.Add(this.lbl_event_type);
            this.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_ManageMarathon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Marathon";
            this.Load += new System.EventHandler(this.Frm_ManageMarathon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_event_title;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.ComboBox countryList;
        private System.Windows.Forms.Label lbl_event_type;
        private System.Windows.Forms.TextBox txt_city;
        private System.Windows.Forms.Label lbl_city;
        private System.Windows.Forms.Label lbl_year;
        private System.Windows.Forms.DateTimePicker date_holdat;
        private System.Windows.Forms.Button btn_upload_map;
        private System.Windows.Forms.TextBox txt_map;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_logo;
        private System.Windows.Forms.TextBox txt_logo;
        private System.Windows.Forms.Button btn_upload_logo;
        private System.Windows.Forms.Label lbl_seal;
        private System.Windows.Forms.TextBox txt_seal;
        private System.Windows.Forms.Button btn_upload_seal;
    }
}