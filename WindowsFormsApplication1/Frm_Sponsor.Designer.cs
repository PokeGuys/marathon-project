namespace MarathonSystem
{
    partial class Frm_Sponsor
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
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_cancel = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_runner = new System.Windows.Forms.Label();
            this.runnerList = new System.Windows.Forms.ComboBox();
            this.txt_Name = new MetroFramework.Controls.MetroTextBox();
            this.txt_Sponsorship = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // btn_next
            // 
            this.btn_next.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_next.Enabled = false;
            this.btn_next.FlatAppearance.BorderSize = 0;
            this.btn_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_next.Font = new System.Drawing.Font("Open Sans Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_next.ForeColor = System.Drawing.Color.Black;
            this.btn_next.Location = new System.Drawing.Point(159, 186);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(137, 42);
            this.btn_next.TabIndex = 51;
            this.btn_next.Text = "Next";
            this.btn_next.UseVisualStyleBackColor = false;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_close.Location = new System.Drawing.Point(256, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(52, 47);
            this.btn_close.TabIndex = 50;
            this.btn_close.Text = "×";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.lbl_title.Font = new System.Drawing.Font("Microsoft YaHei Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_title.Location = new System.Drawing.Point(0, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(308, 47);
            this.lbl_title.TabIndex = 49;
            this.lbl_title.Text = "Sponsor runner";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Lbl_title_MouseDown);
            this.lbl_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Lbl_title_MouseMove);
            // 
            // lbl_cancel
            // 
            this.lbl_cancel.AutoSize = true;
            this.lbl_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_cancel.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl_cancel.Location = new System.Drawing.Point(12, 202);
            this.lbl_cancel.Name = "lbl_cancel";
            this.lbl_cancel.Size = new System.Drawing.Size(51, 16);
            this.lbl_cancel.TabIndex = 52;
            this.lbl_cancel.Text = "< Cancel";
            this.lbl_cancel.Click += new System.EventHandler(this.lbl_cancel_Click);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(12, 63);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(58, 13);
            this.lbl_name.TabIndex = 53;
            this.lbl_name.Text = "Your name";
            // 
            // lbl_runner
            // 
            this.lbl_runner.AutoSize = true;
            this.lbl_runner.Location = new System.Drawing.Point(12, 104);
            this.lbl_runner.Name = "lbl_runner";
            this.lbl_runner.Size = new System.Drawing.Size(42, 13);
            this.lbl_runner.TabIndex = 55;
            this.lbl_runner.Text = "Runner";
            // 
            // runnerList
            // 
            this.runnerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.runnerList.FormattingEnabled = true;
            this.runnerList.Location = new System.Drawing.Point(15, 120);
            this.runnerList.Name = "runnerList";
            this.runnerList.Size = new System.Drawing.Size(280, 21);
            this.runnerList.TabIndex = 56;
            // 
            // txt_Name
            // 
            // 
            // 
            // 
            this.txt_Name.CustomButton.Image = null;
            this.txt_Name.CustomButton.Location = new System.Drawing.Point(260, 1);
            this.txt_Name.CustomButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Name.CustomButton.Name = "";
            this.txt_Name.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txt_Name.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_Name.CustomButton.TabIndex = 1;
            this.txt_Name.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_Name.CustomButton.UseSelectable = true;
            this.txt_Name.CustomButton.Visible = false;
            this.txt_Name.Lines = new string[0];
            this.txt_Name.Location = new System.Drawing.Point(15, 81);
            this.txt_Name.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Name.MaxLength = 32767;
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.PasswordChar = '\0';
            this.txt_Name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_Name.SelectedText = "";
            this.txt_Name.SelectionLength = 0;
            this.txt_Name.SelectionStart = 0;
            this.txt_Name.ShortcutsEnabled = true;
            this.txt_Name.Size = new System.Drawing.Size(280, 21);
            this.txt_Name.TabIndex = 59;
            this.txt_Name.UseSelectable = true;
            this.txt_Name.WaterMark = "Your name";
            this.txt_Name.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_Name.WaterMarkFont = new System.Drawing.Font("Open Sans Light", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // txt_Sponsorship
            // 
            // 
            // 
            // 
            this.txt_Sponsorship.CustomButton.Image = null;
            this.txt_Sponsorship.CustomButton.Location = new System.Drawing.Point(260, 1);
            this.txt_Sponsorship.CustomButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Sponsorship.CustomButton.Name = "";
            this.txt_Sponsorship.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txt_Sponsorship.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_Sponsorship.CustomButton.TabIndex = 1;
            this.txt_Sponsorship.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_Sponsorship.CustomButton.UseSelectable = true;
            this.txt_Sponsorship.CustomButton.Visible = false;
            this.txt_Sponsorship.Lines = new string[0];
            this.txt_Sponsorship.Location = new System.Drawing.Point(15, 145);
            this.txt_Sponsorship.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Sponsorship.MaxLength = 32767;
            this.txt_Sponsorship.Name = "txt_Sponsorship";
            this.txt_Sponsorship.PasswordChar = '\0';
            this.txt_Sponsorship.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_Sponsorship.SelectedText = "";
            this.txt_Sponsorship.SelectionLength = 0;
            this.txt_Sponsorship.SelectionStart = 0;
            this.txt_Sponsorship.ShortcutsEnabled = true;
            this.txt_Sponsorship.Size = new System.Drawing.Size(280, 21);
            this.txt_Sponsorship.TabIndex = 60;
            this.txt_Sponsorship.UseSelectable = true;
            this.txt_Sponsorship.WaterMark = "Sponsorship";
            this.txt_Sponsorship.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_Sponsorship.WaterMarkFont = new System.Drawing.Font("Open Sans Light", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Sponsorship.TextChanged += new System.EventHandler(this.txtField_TextChange);
            // 
            // Frm_Sponsor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 243);
            this.Controls.Add(this.txt_Sponsorship);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.runnerList);
            this.Controls.Add(this.lbl_runner);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.lbl_cancel);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.lbl_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Sponsor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sponsor runner";
            this.Load += new System.EventHandler(this.Frm_Sponsor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_cancel;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_runner;
        private System.Windows.Forms.ComboBox runnerList;
        private MetroFramework.Controls.MetroTextBox txt_Name;
        private MetroFramework.Controls.MetroTextBox txt_Sponsorship;
    }
}