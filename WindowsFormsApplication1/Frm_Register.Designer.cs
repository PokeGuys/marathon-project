namespace MarathonSystem
{
    partial class frm_Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Register));
            this.radio_F = new System.Windows.Forms.RadioButton();
            this.radio_M = new System.Windows.Forms.RadioButton();
            this.lbl_gender = new System.Windows.Forms.Label();
            this.lbl_country = new System.Windows.Forms.Label();
            this.lbl_phone = new System.Windows.Forms.Label();
            this.txt_Phone = new System.Windows.Forms.TextBox();
            this.lbl_idcard = new System.Windows.Forms.Label();
            this.txt_idcard = new System.Windows.Forms.TextBox();
            this.lbl_birthday = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_register = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.Btn_close = new System.Windows.Forms.Button();
            this.chk_extra = new System.Windows.Forms.CheckBox();
            this.combo_country = new System.Windows.Forms.ComboBox();
            this.grpType = new System.Windows.Forms.Panel();
            this.radio_member = new System.Windows.Forms.RadioButton();
            this.radio_volunteer = new System.Windows.Forms.RadioButton();
            this.grpBasic = new System.Windows.Forms.Panel();
            this.lbl_email = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.lbl_password_confirm = new System.Windows.Forms.Label();
            this.txt_password_confirmation = new System.Windows.Forms.TextBox();
            this.lbl_password = new System.Windows.Forms.Label();
            this.lbl_username = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.grpExtra = new System.Windows.Forms.Panel();
            this.birthdayPicker = new System.Windows.Forms.DateTimePicker();
            this.grpAdmin = new System.Windows.Forms.Panel();
            this.lbl_state = new System.Windows.Forms.Label();
            this.statusList = new System.Windows.Forms.ComboBox();
            this.grpType.SuspendLayout();
            this.grpBasic.SuspendLayout();
            this.grpExtra.SuspendLayout();
            this.grpAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // radio_F
            // 
            this.radio_F.AutoSize = true;
            this.radio_F.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_F.Location = new System.Drawing.Point(231, 110);
            this.radio_F.Name = "radio_F";
            this.radio_F.Size = new System.Drawing.Size(66, 21);
            this.radio_F.TabIndex = 59;
            this.radio_F.TabStop = true;
            this.radio_F.Text = "Female";
            this.radio_F.UseVisualStyleBackColor = true;
            this.radio_F.CheckedChanged += new System.EventHandler(this.requiredFieldCheck);
            // 
            // radio_M
            // 
            this.radio_M.AutoSize = true;
            this.radio_M.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_M.Location = new System.Drawing.Point(124, 110);
            this.radio_M.Name = "radio_M";
            this.radio_M.Size = new System.Drawing.Size(52, 21);
            this.radio_M.TabIndex = 58;
            this.radio_M.TabStop = true;
            this.radio_M.Text = "Male";
            this.radio_M.UseVisualStyleBackColor = true;
            this.radio_M.CheckedChanged += new System.EventHandler(this.requiredFieldCheck);
            // 
            // lbl_gender
            // 
            this.lbl_gender.AutoSize = true;
            this.lbl_gender.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_gender.Location = new System.Drawing.Point(6, 110);
            this.lbl_gender.Name = "lbl_gender";
            this.lbl_gender.Size = new System.Drawing.Size(50, 17);
            this.lbl_gender.TabIndex = 57;
            this.lbl_gender.Text = "Gender";
            // 
            // lbl_country
            // 
            this.lbl_country.AutoSize = true;
            this.lbl_country.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_country.Location = new System.Drawing.Point(6, 72);
            this.lbl_country.Name = "lbl_country";
            this.lbl_country.Size = new System.Drawing.Size(51, 17);
            this.lbl_country.TabIndex = 56;
            this.lbl_country.Text = "Country";
            // 
            // lbl_phone
            // 
            this.lbl_phone.AutoSize = true;
            this.lbl_phone.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_phone.Location = new System.Drawing.Point(6, 39);
            this.lbl_phone.Name = "lbl_phone";
            this.lbl_phone.Size = new System.Drawing.Size(92, 17);
            this.lbl_phone.TabIndex = 54;
            this.lbl_phone.Text = "Phone Number";
            // 
            // txt_Phone
            // 
            this.txt_Phone.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Phone.Location = new System.Drawing.Point(124, 36);
            this.txt_Phone.Name = "txt_Phone";
            this.txt_Phone.Size = new System.Drawing.Size(173, 24);
            this.txt_Phone.TabIndex = 53;
            this.txt_Phone.Tag = "phone";
            this.txt_Phone.TextChanged += new System.EventHandler(this.requiredFieldCheck);
            // 
            // lbl_idcard
            // 
            this.lbl_idcard.AutoSize = true;
            this.lbl_idcard.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_idcard.Location = new System.Drawing.Point(8, 208);
            this.lbl_idcard.Name = "lbl_idcard";
            this.lbl_idcard.Size = new System.Drawing.Size(47, 17);
            this.lbl_idcard.TabIndex = 52;
            this.lbl_idcard.Text = "ID Card";
            // 
            // txt_idcard
            // 
            this.txt_idcard.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_idcard.Location = new System.Drawing.Point(124, 205);
            this.txt_idcard.Name = "txt_idcard";
            this.txt_idcard.Size = new System.Drawing.Size(173, 24);
            this.txt_idcard.TabIndex = 51;
            this.txt_idcard.Tag = "idcard";
            this.txt_idcard.TextChanged += new System.EventHandler(this.requiredFieldCheck);
            // 
            // lbl_birthday
            // 
            this.lbl_birthday.AutoSize = true;
            this.lbl_birthday.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_birthday.Location = new System.Drawing.Point(6, 6);
            this.lbl_birthday.Name = "lbl_birthday";
            this.lbl_birthday.Size = new System.Drawing.Size(54, 17);
            this.lbl_birthday.TabIndex = 50;
            this.lbl_birthday.Text = "Birthday";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.FlatAppearance.BorderSize = 0;
            this.btn_Cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btn_Cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Open Sans Light", 12F);
            this.btn_Cancel.Location = new System.Drawing.Point(98, 329);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(67, 42);
            this.btn_Cancel.TabIndex = 40;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_register
            // 
            this.btn_register.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_register.Enabled = false;
            this.btn_register.FlatAppearance.BorderSize = 0;
            this.btn_register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_register.Font = new System.Drawing.Font("Open Sans Light", 12F);
            this.btn_register.ForeColor = System.Drawing.Color.DimGray;
            this.btn_register.Location = new System.Drawing.Point(171, 329);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(141, 42);
            this.btn_register.TabIndex = 39;
            this.btn_register.Text = "Submit";
            this.btn_register.UseVisualStyleBackColor = false;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.lbl_title.Font = new System.Drawing.Font("Open Sans Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(-1, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(334, 46);
            this.lbl_title.TabIndex = 37;
            this.lbl_title.Text = "Register Member";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Lbl_title_MouseDown);
            this.lbl_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Lbl_title_MouseMove);
            // 
            // Btn_close
            // 
            this.Btn_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.Btn_close.FlatAppearance.BorderSize = 0;
            this.Btn_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.Btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_close.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_close.ForeColor = System.Drawing.SystemColors.Window;
            this.Btn_close.Location = new System.Drawing.Point(280, 0);
            this.Btn_close.Name = "Btn_close";
            this.Btn_close.Size = new System.Drawing.Size(53, 46);
            this.Btn_close.TabIndex = 60;
            this.Btn_close.Text = "×";
            this.Btn_close.UseVisualStyleBackColor = false;
            this.Btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // chk_extra
            // 
            this.chk_extra.AutoSize = true;
            this.chk_extra.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_extra.Location = new System.Drawing.Point(12, 340);
            this.chk_extra.Name = "chk_extra";
            this.chk_extra.Size = new System.Drawing.Size(55, 21);
            this.chk_extra.TabIndex = 61;
            this.chk_extra.Text = "Extra";
            this.chk_extra.UseVisualStyleBackColor = true;
            this.chk_extra.CheckedChanged += new System.EventHandler(this.chk_extra_CheckedChanged);
            // 
            // combo_country
            // 
            this.combo_country.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_country.FormattingEnabled = true;
            this.combo_country.Location = new System.Drawing.Point(124, 79);
            this.combo_country.Name = "combo_country";
            this.combo_country.Size = new System.Drawing.Size(173, 21);
            this.combo_country.TabIndex = 60;
            this.combo_country.Tag = "country";
            this.combo_country.TextChanged += new System.EventHandler(this.requiredFieldCheck);
            // 
            // grpType
            // 
            this.grpType.Controls.Add(this.radio_member);
            this.grpType.Controls.Add(this.radio_volunteer);
            this.grpType.Location = new System.Drawing.Point(12, 53);
            this.grpType.Name = "grpType";
            this.grpType.Size = new System.Drawing.Size(321, 43);
            this.grpType.TabIndex = 0;
            // 
            // radio_member
            // 
            this.radio_member.AutoSize = true;
            this.radio_member.Checked = true;
            this.radio_member.Location = new System.Drawing.Point(9, 13);
            this.radio_member.Name = "radio_member";
            this.radio_member.Size = new System.Drawing.Size(119, 17);
            this.radio_member.TabIndex = 68;
            this.radio_member.TabStop = true;
            this.radio_member.Tag = "0";
            this.radio_member.Text = "Register as Member";
            this.radio_member.UseVisualStyleBackColor = true;
            // 
            // radio_volunteer
            // 
            this.radio_volunteer.AutoSize = true;
            this.radio_volunteer.Location = new System.Drawing.Point(172, 13);
            this.radio_volunteer.Name = "radio_volunteer";
            this.radio_volunteer.Size = new System.Drawing.Size(126, 17);
            this.radio_volunteer.TabIndex = 67;
            this.radio_volunteer.Tag = "2";
            this.radio_volunteer.Text = "Register as Volunteer";
            this.radio_volunteer.UseVisualStyleBackColor = true;
            // 
            // grpBasic
            // 
            this.grpBasic.Controls.Add(this.lbl_email);
            this.grpBasic.Controls.Add(this.txt_email);
            this.grpBasic.Controls.Add(this.lbl_name);
            this.grpBasic.Controls.Add(this.txt_name);
            this.grpBasic.Controls.Add(this.lbl_idcard);
            this.grpBasic.Controls.Add(this.lbl_password_confirm);
            this.grpBasic.Controls.Add(this.txt_password_confirmation);
            this.grpBasic.Controls.Add(this.lbl_password);
            this.grpBasic.Controls.Add(this.lbl_username);
            this.grpBasic.Controls.Add(this.txt_password);
            this.grpBasic.Controls.Add(this.txt_idcard);
            this.grpBasic.Controls.Add(this.txt_username);
            this.grpBasic.Location = new System.Drawing.Point(12, 90);
            this.grpBasic.Name = "grpBasic";
            this.grpBasic.Size = new System.Drawing.Size(321, 240);
            this.grpBasic.TabIndex = 63;
            this.grpBasic.Paint += new System.Windows.Forms.PaintEventHandler(this.grpBasic_Paint);
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_email.Location = new System.Drawing.Point(6, 169);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(38, 17);
            this.lbl_email.TabIndex = 58;
            this.lbl_email.Text = "Email";
            // 
            // txt_email
            // 
            this.txt_email.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_email.Location = new System.Drawing.Point(124, 166);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(173, 24);
            this.txt_email.TabIndex = 57;
            this.txt_email.TextChanged += new System.EventHandler(this.requiredFieldCheck);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(5, 129);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(41, 17);
            this.lbl_name.TabIndex = 56;
            this.lbl_name.Text = "Name";
            // 
            // txt_name
            // 
            this.txt_name.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.Location = new System.Drawing.Point(124, 127);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(173, 24);
            this.txt_name.TabIndex = 55;
            this.txt_name.TextChanged += new System.EventHandler(this.requiredFieldCheck);
            // 
            // lbl_password_confirm
            // 
            this.lbl_password_confirm.AutoSize = true;
            this.lbl_password_confirm.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_password_confirm.Location = new System.Drawing.Point(6, 91);
            this.lbl_password_confirm.Name = "lbl_password_confirm";
            this.lbl_password_confirm.Size = new System.Drawing.Size(112, 17);
            this.lbl_password_confirm.TabIndex = 54;
            this.lbl_password_confirm.Text = "Re-enter password";
            // 
            // txt_password_confirmation
            // 
            this.txt_password_confirmation.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password_confirmation.Location = new System.Drawing.Point(124, 88);
            this.txt_password_confirmation.Name = "txt_password_confirmation";
            this.txt_password_confirmation.PasswordChar = '•';
            this.txt_password_confirmation.Size = new System.Drawing.Size(173, 24);
            this.txt_password_confirmation.TabIndex = 53;
            this.txt_password_confirmation.TextChanged += new System.EventHandler(this.requiredFieldCheck);
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_password.Location = new System.Drawing.Point(6, 52);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(61, 17);
            this.lbl_password.TabIndex = 52;
            this.lbl_password.Text = "Password";
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_username.Location = new System.Drawing.Point(6, 11);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(66, 17);
            this.lbl_username.TabIndex = 51;
            this.lbl_username.Text = "Username";
            // 
            // txt_password
            // 
            this.txt_password.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.Location = new System.Drawing.Point(124, 49);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '•';
            this.txt_password.Size = new System.Drawing.Size(173, 24);
            this.txt_password.TabIndex = 50;
            this.txt_password.TextChanged += new System.EventHandler(this.requiredFieldCheck);
            // 
            // txt_username
            // 
            this.txt_username.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_username.Location = new System.Drawing.Point(124, 10);
            this.txt_username.MaxLength = 20;
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(173, 24);
            this.txt_username.TabIndex = 49;
            this.txt_username.TextChanged += new System.EventHandler(this.requiredFieldCheck);
            // 
            // grpExtra
            // 
            this.grpExtra.Controls.Add(this.birthdayPicker);
            this.grpExtra.Controls.Add(this.combo_country);
            this.grpExtra.Controls.Add(this.radio_F);
            this.grpExtra.Controls.Add(this.lbl_country);
            this.grpExtra.Controls.Add(this.lbl_phone);
            this.grpExtra.Controls.Add(this.lbl_birthday);
            this.grpExtra.Controls.Add(this.lbl_gender);
            this.grpExtra.Controls.Add(this.radio_M);
            this.grpExtra.Controls.Add(this.txt_Phone);
            this.grpExtra.Location = new System.Drawing.Point(12, 327);
            this.grpExtra.Name = "grpExtra";
            this.grpExtra.Size = new System.Drawing.Size(321, 141);
            this.grpExtra.TabIndex = 64;
            this.grpExtra.Visible = false;
            // 
            // birthdayPicker
            // 
            this.birthdayPicker.CustomFormat = "   ";
            this.birthdayPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.birthdayPicker.Location = new System.Drawing.Point(124, 1);
            this.birthdayPicker.MaxDate = new System.DateTime(1999, 7, 2, 0, 0, 0, 0);
            this.birthdayPicker.MinDate = new System.DateTime(1853, 1, 1, 0, 0, 0, 0);
            this.birthdayPicker.Name = "birthdayPicker";
            this.birthdayPicker.Size = new System.Drawing.Size(173, 20);
            this.birthdayPicker.TabIndex = 61;
            this.birthdayPicker.Tag = "birthday";
            this.birthdayPicker.Value = new System.DateTime(1999, 6, 5, 0, 0, 0, 0);
            this.birthdayPicker.ValueChanged += new System.EventHandler(this.birthdayPicker_ValueChanged);
            // 
            // grpAdmin
            // 
            this.grpAdmin.Controls.Add(this.lbl_state);
            this.grpAdmin.Controls.Add(this.statusList);
            this.grpAdmin.Location = new System.Drawing.Point(12, 53);
            this.grpAdmin.Name = "grpAdmin";
            this.grpAdmin.Size = new System.Drawing.Size(321, 43);
            this.grpAdmin.TabIndex = 69;
            this.grpAdmin.Visible = false;
            // 
            // lbl_state
            // 
            this.lbl_state.AutoSize = true;
            this.lbl_state.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_state.Location = new System.Drawing.Point(6, 11);
            this.lbl_state.Name = "lbl_state";
            this.lbl_state.Size = new System.Drawing.Size(88, 17);
            this.lbl_state.TabIndex = 52;
            this.lbl_state.Text = "Account status";
            // 
            // statusList
            // 
            this.statusList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusList.FormattingEnabled = true;
            this.statusList.Location = new System.Drawing.Point(124, 11);
            this.statusList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.statusList.Name = "statusList";
            this.statusList.Size = new System.Drawing.Size(173, 21);
            this.statusList.TabIndex = 0;
            // 
            // frm_Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 380);
            this.Controls.Add(this.grpAdmin);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.chk_extra);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.grpExtra);
            this.Controls.Add(this.grpType);
            this.Controls.Add(this.Btn_close);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.grpBasic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Register Member";
            this.Load += new System.EventHandler(this.frm_Register_Load);
            this.grpType.ResumeLayout(false);
            this.grpType.PerformLayout();
            this.grpBasic.ResumeLayout(false);
            this.grpBasic.PerformLayout();
            this.grpExtra.ResumeLayout(false);
            this.grpExtra.PerformLayout();
            this.grpAdmin.ResumeLayout(false);
            this.grpAdmin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radio_F;
        private System.Windows.Forms.RadioButton radio_M;
        private System.Windows.Forms.Label lbl_gender;
        private System.Windows.Forms.Label lbl_country;
        private System.Windows.Forms.Label lbl_phone;
        private System.Windows.Forms.TextBox txt_Phone;
        private System.Windows.Forms.Label lbl_idcard;
        private System.Windows.Forms.TextBox txt_idcard;
        private System.Windows.Forms.Label lbl_birthday;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button Btn_close;
        private System.Windows.Forms.CheckBox chk_extra;
        private System.Windows.Forms.Panel grpExtra;
        private System.Windows.Forms.ComboBox combo_country;
        private System.Windows.Forms.Panel grpType;
        private System.Windows.Forms.RadioButton radio_member;
        private System.Windows.Forms.RadioButton radio_volunteer;
        private System.Windows.Forms.Panel grpBasic;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label lbl_password_confirm;
        private System.Windows.Forms.TextBox txt_password_confirmation;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.DateTimePicker birthdayPicker;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Panel grpAdmin;
        private System.Windows.Forms.Label lbl_state;
        private System.Windows.Forms.ComboBox statusList;
    }
}