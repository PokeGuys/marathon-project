namespace MarathonSystem
{
    partial class Frm_Volunteer
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
            this.btn_close = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btn_next = new System.Windows.Forms.Button();
            this.volunteerList = new System.Windows.Forms.ComboBox();
            this.lbl_volunteer = new System.Windows.Forms.Label();
            this.lbl_runner = new System.Windows.Forms.Label();
            this.hr = new System.Windows.Forms.Panel();
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
            this.btn_close.Location = new System.Drawing.Point(281, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(53, 47);
            this.btn_close.TabIndex = 40;
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
            this.lbl_title.Size = new System.Drawing.Size(334, 47);
            this.lbl_title.TabIndex = 39;
            this.lbl_title.Text = "Assign Volunteer";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Lbl_title_MouseDown);
            this.lbl_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Lbl_title_MouseMove);
            // 
            // btn_next
            // 
            this.btn_next.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_next.Enabled = false;
            this.btn_next.FlatAppearance.BorderSize = 0;
            this.btn_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_next.Font = new System.Drawing.Font("Open Sans Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_next.ForeColor = System.Drawing.Color.Black;
            this.btn_next.Location = new System.Drawing.Point(12, 145);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(309, 42);
            this.btn_next.TabIndex = 52;
            this.btn_next.Text = "Submit";
            this.btn_next.UseVisualStyleBackColor = false;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // volunteerList
            // 
            this.volunteerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.volunteerList.Font = new System.Drawing.Font("Open Sans Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volunteerList.FormattingEnabled = true;
            this.volunteerList.Location = new System.Drawing.Point(12, 105);
            this.volunteerList.Name = "volunteerList";
            this.volunteerList.Size = new System.Drawing.Size(309, 23);
            this.volunteerList.TabIndex = 53;
            this.volunteerList.SelectedIndexChanged += new System.EventHandler(this.volunteerList_SelectedIndexChanged);
            // 
            // lbl_volunteer
            // 
            this.lbl_volunteer.AutoSize = true;
            this.lbl_volunteer.Font = new System.Drawing.Font("Open Sans Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_volunteer.Location = new System.Drawing.Point(9, 87);
            this.lbl_volunteer.Name = "lbl_volunteer";
            this.lbl_volunteer.Size = new System.Drawing.Size(73, 15);
            this.lbl_volunteer.TabIndex = 54;
            this.lbl_volunteer.Text = "Volunteer List";
            // 
            // lbl_runner
            // 
            this.lbl_runner.AutoSize = true;
            this.lbl_runner.Font = new System.Drawing.Font("Open Sans Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_runner.Location = new System.Drawing.Point(12, 56);
            this.lbl_runner.Name = "lbl_runner";
            this.lbl_runner.Size = new System.Drawing.Size(48, 15);
            this.lbl_runner.TabIndex = 55;
            this.lbl_runner.Text = "Runner: ";
            // 
            // hr
            // 
            this.hr.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.hr.Location = new System.Drawing.Point(10, 78);
            this.hr.Name = "hr";
            this.hr.Size = new System.Drawing.Size(315, 2);
            this.hr.TabIndex = 56;
            // 
            // Frm_Volunteer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 200);
            this.Controls.Add(this.hr);
            this.Controls.Add(this.lbl_runner);
            this.Controls.Add(this.lbl_volunteer);
            this.Controls.Add(this.volunteerList);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.lbl_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Volunteer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assign Volunteer";
            this.Load += new System.EventHandler(this.Frm_Volunteer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.ComboBox volunteerList;
        private System.Windows.Forms.Label lbl_volunteer;
        private System.Windows.Forms.Label lbl_runner;
        private System.Windows.Forms.Panel hr;
    }
}