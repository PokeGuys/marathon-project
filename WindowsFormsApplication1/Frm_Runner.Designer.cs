namespace MarathonSystem
{
    partial class Frm_Runner
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
            this.lbl_date = new System.Windows.Forms.Label();
            this.lbl_username = new System.Windows.Forms.Label();
            this.PersonalHR = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.tabEvent = new System.Windows.Forms.TabPage();
            this.btn_view = new System.Windows.Forms.Button();
            this.eventList = new System.Windows.Forms.ListView();
            this.tabPersonal = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.radio_female = new MetroFramework.Controls.MetroRadioButton();
            this.radio_male = new MetroFramework.Controls.MetroRadioButton();
            this.countryList = new MetroFramework.Controls.MetroComboBox();
            this.txt_phone = new MetroFramework.Controls.MetroTextBox();
            this.lbl_gender = new System.Windows.Forms.Label();
            this.lbl_country = new System.Windows.Forms.Label();
            this.lbl_phone = new System.Windows.Forms.Label();
            this.lbl_idcard = new System.Windows.Forms.Label();
            this.lbl_birthday = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.birthday = new MetroFramework.Controls.MetroDateTime();
            this.txt_idcard = new MetroFramework.Controls.MetroTextBox();
            this.txt_name = new MetroFramework.Controls.MetroTextBox();
            this.txt_email = new MetroFramework.Controls.MetroTextBox();
            this.txt_password = new MetroFramework.Controls.MetroTextBox();
            this.tab = new MetroFramework.Controls.MetroTabControl();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_submit = new System.Windows.Forms.Button();
            this.btn_cert = new System.Windows.Forms.Button();
            this.tabEvent.SuspendLayout();
            this.tabPersonal.SuspendLayout();
            this.tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.Font = new System.Drawing.Font("Open Sans", 8.25F);
            this.lbl_date.Location = new System.Drawing.Point(6, 59);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(0, 15);
            this.lbl_date.TabIndex = 98;
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_username.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_username.Location = new System.Drawing.Point(6, 93);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(0, 22);
            this.lbl_username.TabIndex = 97;
            // 
            // PersonalHR
            // 
            this.PersonalHR.BackColor = System.Drawing.Color.Gray;
            this.PersonalHR.Location = new System.Drawing.Point(10, 119);
            this.PersonalHR.Name = "PersonalHR";
            this.PersonalHR.Size = new System.Drawing.Size(404, 1);
            this.PersonalHR.TabIndex = 95;
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
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(53, 46);
            this.btn_close.TabIndex = 94;
            this.btn_close.Text = "×";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.lbl_title.Font = new System.Drawing.Font("Open Sans Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_title.Location = new System.Drawing.Point(0, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(430, 46);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "Edit Member";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Lbl_title_MouseDown);
            this.lbl_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Lbl_title_MouseMove);
            // 
            // tabEvent
            // 
            this.tabEvent.BackColor = System.Drawing.Color.White;
            this.tabEvent.Controls.Add(this.btn_cert);
            this.tabEvent.Controls.Add(this.btn_view);
            this.tabEvent.Controls.Add(this.eventList);
            this.tabEvent.Location = new System.Drawing.Point(4, 38);
            this.tabEvent.Margin = new System.Windows.Forms.Padding(2);
            this.tabEvent.Name = "tabEvent";
            this.tabEvent.Size = new System.Drawing.Size(403, 237);
            this.tabEvent.TabIndex = 1;
            this.tabEvent.Text = "Event";
            // 
            // btn_view
            // 
            this.btn_view.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btn_view.FlatAppearance.BorderSize = 0;
            this.btn_view.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_view.Font = new System.Drawing.Font("Open Sans Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_view.ForeColor = System.Drawing.Color.White;
            this.btn_view.Location = new System.Drawing.Point(306, 188);
            this.btn_view.Name = "btn_view";
            this.btn_view.Size = new System.Drawing.Size(90, 42);
            this.btn_view.TabIndex = 101;
            this.btn_view.Text = "View";
            this.btn_view.UseVisualStyleBackColor = false;
            this.btn_view.Click += new System.EventHandler(this.btn_view_Click);
            // 
            // eventList
            // 
            this.eventList.FullRowSelect = true;
            this.eventList.Location = new System.Drawing.Point(8, 6);
            this.eventList.Name = "eventList";
            this.eventList.Size = new System.Drawing.Size(388, 176);
            this.eventList.TabIndex = 0;
            this.eventList.UseCompatibleStateImageBehavior = false;
            // 
            // tabPersonal
            // 
            this.tabPersonal.BackColor = System.Drawing.Color.White;
            this.tabPersonal.Controls.Add(this.label1);
            this.tabPersonal.Controls.Add(this.radio_female);
            this.tabPersonal.Controls.Add(this.radio_male);
            this.tabPersonal.Controls.Add(this.countryList);
            this.tabPersonal.Controls.Add(this.txt_phone);
            this.tabPersonal.Controls.Add(this.lbl_gender);
            this.tabPersonal.Controls.Add(this.lbl_country);
            this.tabPersonal.Controls.Add(this.lbl_phone);
            this.tabPersonal.Controls.Add(this.lbl_idcard);
            this.tabPersonal.Controls.Add(this.lbl_birthday);
            this.tabPersonal.Controls.Add(this.lbl_name);
            this.tabPersonal.Controls.Add(this.lbl_email);
            this.tabPersonal.Controls.Add(this.birthday);
            this.tabPersonal.Controls.Add(this.txt_idcard);
            this.tabPersonal.Controls.Add(this.txt_name);
            this.tabPersonal.Controls.Add(this.txt_email);
            this.tabPersonal.Controls.Add(this.txt_password);
            this.tabPersonal.Location = new System.Drawing.Point(4, 38);
            this.tabPersonal.Margin = new System.Windows.Forms.Padding(2);
            this.tabPersonal.Name = "tabPersonal";
            this.tabPersonal.Size = new System.Drawing.Size(403, 237);
            this.tabPersonal.TabIndex = 0;
            this.tabPersonal.Text = "Personal";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 93;
            this.label1.Text = "New Password";
            // 
            // radio_female
            // 
            this.radio_female.AutoSize = true;
            this.radio_female.Location = new System.Drawing.Point(336, 207);
            this.radio_female.Margin = new System.Windows.Forms.Padding(2);
            this.radio_female.Name = "radio_female";
            this.radio_female.Size = new System.Drawing.Size(61, 15);
            this.radio_female.TabIndex = 92;
            this.radio_female.Text = "Female";
            this.radio_female.UseSelectable = true;
            // 
            // radio_male
            // 
            this.radio_male.AutoSize = true;
            this.radio_male.Location = new System.Drawing.Point(116, 207);
            this.radio_male.Margin = new System.Windows.Forms.Padding(2);
            this.radio_male.Name = "radio_male";
            this.radio_male.Size = new System.Drawing.Size(49, 15);
            this.radio_male.TabIndex = 91;
            this.radio_male.Text = "Male";
            this.radio_male.UseSelectable = true;
            // 
            // countryList
            // 
            this.countryList.FormattingEnabled = true;
            this.countryList.ItemHeight = 23;
            this.countryList.Location = new System.Drawing.Point(116, 171);
            this.countryList.Margin = new System.Windows.Forms.Padding(2);
            this.countryList.Name = "countryList";
            this.countryList.Size = new System.Drawing.Size(270, 29);
            this.countryList.TabIndex = 90;
            this.countryList.UseSelectable = true;
            // 
            // txt_phone
            // 
            // 
            // 
            // 
            this.txt_phone.CustomButton.Image = null;
            this.txt_phone.CustomButton.Location = new System.Drawing.Point(249, 1);
            this.txt_phone.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txt_phone.CustomButton.Name = "";
            this.txt_phone.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txt_phone.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_phone.CustomButton.TabIndex = 1;
            this.txt_phone.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_phone.CustomButton.UseSelectable = true;
            this.txt_phone.CustomButton.Visible = false;
            this.txt_phone.Lines = new string[0];
            this.txt_phone.Location = new System.Drawing.Point(116, 146);
            this.txt_phone.Margin = new System.Windows.Forms.Padding(2);
            this.txt_phone.MaxLength = 32767;
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.PasswordChar = '\0';
            this.txt_phone.PromptText = "Phone";
            this.txt_phone.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_phone.SelectedText = "";
            this.txt_phone.SelectionLength = 0;
            this.txt_phone.SelectionStart = 0;
            this.txt_phone.ShortcutsEnabled = true;
            this.txt_phone.Size = new System.Drawing.Size(269, 21);
            this.txt_phone.TabIndex = 89;
            this.txt_phone.UseSelectable = true;
            this.txt_phone.WaterMark = "Phone";
            this.txt_phone.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_phone.WaterMarkFont = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lbl_gender
            // 
            this.lbl_gender.AutoSize = true;
            this.lbl_gender.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_gender.Location = new System.Drawing.Point(16, 205);
            this.lbl_gender.Name = "lbl_gender";
            this.lbl_gender.Size = new System.Drawing.Size(50, 17);
            this.lbl_gender.TabIndex = 88;
            this.lbl_gender.Text = "Gender";
            // 
            // lbl_country
            // 
            this.lbl_country.AutoSize = true;
            this.lbl_country.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_country.Location = new System.Drawing.Point(16, 172);
            this.lbl_country.Name = "lbl_country";
            this.lbl_country.Size = new System.Drawing.Size(51, 17);
            this.lbl_country.TabIndex = 87;
            this.lbl_country.Text = "Country";
            // 
            // lbl_phone
            // 
            this.lbl_phone.AutoSize = true;
            this.lbl_phone.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_phone.Location = new System.Drawing.Point(16, 146);
            this.lbl_phone.Name = "lbl_phone";
            this.lbl_phone.Size = new System.Drawing.Size(92, 17);
            this.lbl_phone.TabIndex = 86;
            this.lbl_phone.Text = "Phone Number";
            // 
            // lbl_idcard
            // 
            this.lbl_idcard.AutoSize = true;
            this.lbl_idcard.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_idcard.Location = new System.Drawing.Point(16, 124);
            this.lbl_idcard.Name = "lbl_idcard";
            this.lbl_idcard.Size = new System.Drawing.Size(47, 17);
            this.lbl_idcard.TabIndex = 85;
            this.lbl_idcard.Text = "ID Card";
            // 
            // lbl_birthday
            // 
            this.lbl_birthday.AutoSize = true;
            this.lbl_birthday.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_birthday.Location = new System.Drawing.Point(16, 94);
            this.lbl_birthday.Name = "lbl_birthday";
            this.lbl_birthday.Size = new System.Drawing.Size(54, 17);
            this.lbl_birthday.TabIndex = 84;
            this.lbl_birthday.Text = "Birthday";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(16, 66);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(41, 17);
            this.lbl_name.TabIndex = 83;
            this.lbl_name.Text = "Name";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_email.Location = new System.Drawing.Point(16, 41);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(38, 17);
            this.lbl_email.TabIndex = 82;
            this.lbl_email.Text = "Email";
            // 
            // birthday
            // 
            this.birthday.CustomFormat = " ";
            this.birthday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.birthday.Location = new System.Drawing.Point(116, 87);
            this.birthday.Margin = new System.Windows.Forms.Padding(2);
            this.birthday.MaxDate = new System.DateTime(1999, 6, 6, 0, 0, 0, 0);
            this.birthday.MinimumSize = new System.Drawing.Size(0, 29);
            this.birthday.Name = "birthday";
            this.birthday.Size = new System.Drawing.Size(270, 29);
            this.birthday.TabIndex = 5;
            this.birthday.Value = new System.DateTime(1999, 6, 6, 0, 0, 0, 0);
            this.birthday.ValueChanged += new System.EventHandler(this.birthday_ValueChanged);
            // 
            // txt_idcard
            // 
            // 
            // 
            // 
            this.txt_idcard.CustomButton.Image = null;
            this.txt_idcard.CustomButton.Location = new System.Drawing.Point(248, 1);
            this.txt_idcard.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txt_idcard.CustomButton.Name = "";
            this.txt_idcard.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txt_idcard.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_idcard.CustomButton.TabIndex = 1;
            this.txt_idcard.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_idcard.CustomButton.UseSelectable = true;
            this.txt_idcard.CustomButton.Visible = false;
            this.txt_idcard.Lines = new string[0];
            this.txt_idcard.Location = new System.Drawing.Point(116, 121);
            this.txt_idcard.Margin = new System.Windows.Forms.Padding(2);
            this.txt_idcard.MaxLength = 32767;
            this.txt_idcard.Name = "txt_idcard";
            this.txt_idcard.PasswordChar = '\0';
            this.txt_idcard.PromptText = "ID Card";
            this.txt_idcard.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_idcard.SelectedText = "";
            this.txt_idcard.SelectionLength = 0;
            this.txt_idcard.SelectionStart = 0;
            this.txt_idcard.ShortcutsEnabled = true;
            this.txt_idcard.Size = new System.Drawing.Size(268, 21);
            this.txt_idcard.TabIndex = 4;
            this.txt_idcard.UseSelectable = true;
            this.txt_idcard.WaterMark = "ID Card";
            this.txt_idcard.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_idcard.WaterMarkFont = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txt_name
            // 
            // 
            // 
            // 
            this.txt_name.CustomButton.Image = null;
            this.txt_name.CustomButton.Location = new System.Drawing.Point(248, 1);
            this.txt_name.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txt_name.CustomButton.Name = "";
            this.txt_name.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txt_name.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_name.CustomButton.TabIndex = 1;
            this.txt_name.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_name.CustomButton.UseSelectable = true;
            this.txt_name.CustomButton.Visible = false;
            this.txt_name.Lines = new string[0];
            this.txt_name.Location = new System.Drawing.Point(116, 62);
            this.txt_name.Margin = new System.Windows.Forms.Padding(2);
            this.txt_name.MaxLength = 32767;
            this.txt_name.Name = "txt_name";
            this.txt_name.PasswordChar = '\0';
            this.txt_name.PromptText = "Name";
            this.txt_name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_name.SelectedText = "";
            this.txt_name.SelectionLength = 0;
            this.txt_name.SelectionStart = 0;
            this.txt_name.ShortcutsEnabled = true;
            this.txt_name.Size = new System.Drawing.Size(268, 21);
            this.txt_name.TabIndex = 2;
            this.txt_name.UseSelectable = true;
            this.txt_name.WaterMark = "Name";
            this.txt_name.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_name.WaterMarkFont = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txt_email
            // 
            // 
            // 
            // 
            this.txt_email.CustomButton.Image = null;
            this.txt_email.CustomButton.Location = new System.Drawing.Point(248, 1);
            this.txt_email.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txt_email.CustomButton.Name = "";
            this.txt_email.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txt_email.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_email.CustomButton.TabIndex = 1;
            this.txt_email.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_email.CustomButton.UseSelectable = true;
            this.txt_email.CustomButton.Visible = false;
            this.txt_email.Lines = new string[0];
            this.txt_email.Location = new System.Drawing.Point(116, 37);
            this.txt_email.Margin = new System.Windows.Forms.Padding(2);
            this.txt_email.MaxLength = 32767;
            this.txt_email.Name = "txt_email";
            this.txt_email.PasswordChar = '\0';
            this.txt_email.PromptText = "Email";
            this.txt_email.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_email.SelectedText = "";
            this.txt_email.SelectionLength = 0;
            this.txt_email.SelectionStart = 0;
            this.txt_email.ShortcutsEnabled = true;
            this.txt_email.Size = new System.Drawing.Size(268, 21);
            this.txt_email.TabIndex = 1;
            this.txt_email.UseSelectable = true;
            this.txt_email.WaterMark = "Email";
            this.txt_email.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_email.WaterMarkFont = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txt_password
            // 
            // 
            // 
            // 
            this.txt_password.CustomButton.Image = null;
            this.txt_password.CustomButton.Location = new System.Drawing.Point(248, 1);
            this.txt_password.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txt_password.CustomButton.Name = "";
            this.txt_password.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txt_password.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_password.CustomButton.TabIndex = 1;
            this.txt_password.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_password.CustomButton.UseSelectable = true;
            this.txt_password.CustomButton.Visible = false;
            this.txt_password.Lines = new string[0];
            this.txt_password.Location = new System.Drawing.Point(116, 12);
            this.txt_password.Margin = new System.Windows.Forms.Padding(2);
            this.txt_password.MaxLength = 32767;
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '•';
            this.txt_password.PromptText = "New Password";
            this.txt_password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_password.SelectedText = "";
            this.txt_password.SelectionLength = 0;
            this.txt_password.SelectionStart = 0;
            this.txt_password.ShortcutsEnabled = true;
            this.txt_password.Size = new System.Drawing.Size(268, 21);
            this.txt_password.TabIndex = 0;
            this.txt_password.UseSelectable = true;
            this.txt_password.WaterMark = "New Password";
            this.txt_password.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_password.WaterMarkFont = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPersonal);
            this.tab.Controls.Add(this.tabEvent);
            this.tab.Location = new System.Drawing.Point(9, 126);
            this.tab.Margin = new System.Windows.Forms.Padding(2);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 1;
            this.tab.Size = new System.Drawing.Size(411, 279);
            this.tab.TabIndex = 99;
            this.tab.UseSelectable = true;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.White;
            this.btn_cancel.FlatAppearance.BorderSize = 0;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Open Sans Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(132, 419);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(88, 42);
            this.btn_cancel.TabIndex = 101;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_submit
            // 
            this.btn_submit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btn_submit.FlatAppearance.BorderSize = 0;
            this.btn_submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_submit.Font = new System.Drawing.Font("Open Sans Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.ForeColor = System.Drawing.Color.White;
            this.btn_submit.Location = new System.Drawing.Point(226, 419);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(190, 42);
            this.btn_submit.TabIndex = 100;
            this.btn_submit.Text = "Submit";
            this.btn_submit.UseVisualStyleBackColor = false;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // btn_cert
            // 
            this.btn_cert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btn_cert.FlatAppearance.BorderSize = 0;
            this.btn_cert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cert.Font = new System.Drawing.Font("Open Sans Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cert.ForeColor = System.Drawing.Color.White;
            this.btn_cert.Location = new System.Drawing.Point(8, 188);
            this.btn_cert.Name = "btn_cert";
            this.btn_cert.Size = new System.Drawing.Size(292, 42);
            this.btn_cert.TabIndex = 102;
            this.btn_cert.Text = "Issues Certificate";
            this.btn_cert.UseVisualStyleBackColor = false;
            this.btn_cert.Click += new System.EventHandler(this.btn_cert_Click);
            // 
            // Frm_Runner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(429, 475);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.lbl_date);
            this.Controls.Add(this.lbl_username);
            this.Controls.Add(this.PersonalHR);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.lbl_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Runner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Profile";
            this.Load += new System.EventHandler(this.Frm_Runner_Load);
            this.tabEvent.ResumeLayout(false);
            this.tabPersonal.ResumeLayout(false);
            this.tabPersonal.PerformLayout();
            this.tab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.Panel PersonalHR;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.TabPage tabEvent;
        private System.Windows.Forms.TabPage tabPersonal;
        private MetroFramework.Controls.MetroRadioButton radio_female;
        private MetroFramework.Controls.MetroRadioButton radio_male;
        private MetroFramework.Controls.MetroComboBox countryList;
        private MetroFramework.Controls.MetroTextBox txt_phone;
        private System.Windows.Forms.Label lbl_gender;
        private System.Windows.Forms.Label lbl_country;
        private System.Windows.Forms.Label lbl_phone;
        private System.Windows.Forms.Label lbl_idcard;
        private System.Windows.Forms.Label lbl_birthday;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_email;
        private MetroFramework.Controls.MetroDateTime birthday;
        private MetroFramework.Controls.MetroTextBox txt_idcard;
        private MetroFramework.Controls.MetroTextBox txt_name;
        private MetroFramework.Controls.MetroTextBox txt_email;
        private MetroFramework.Controls.MetroTextBox txt_password;
        private MetroFramework.Controls.MetroTabControl tab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Button btn_view;
        private System.Windows.Forms.ListView eventList;
        private System.Windows.Forms.Button btn_cert;
    }
}