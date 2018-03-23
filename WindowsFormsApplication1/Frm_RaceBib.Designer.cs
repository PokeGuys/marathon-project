namespace MarathonSystem
{
    partial class Frm_RaceBib
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
            this.btn_Close = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.cardSearch = new System.Windows.Forms.Panel();
            this.lblStartat = new System.Windows.Forms.Label();
            this.lblEvent = new System.Windows.Forms.Label();
            this.cardEvent = new System.Windows.Forms.Panel();
            this.lbl_total_postition_header = new System.Windows.Forms.Label();
            this.lbl_current_position = new System.Windows.Forms.Label();
            this.lbl_overall_header = new System.Windows.Forms.Label();
            this.cardResult = new System.Windows.Forms.Panel();
            this.lbl_pace = new System.Windows.Forms.Label();
            this.lbl_speed = new System.Windows.Forms.Label();
            this.lbl_distance = new System.Windows.Forms.Label();
            this.lbl_pace_header = new System.Windows.Forms.Label();
            this.lbl_speed_header = new System.Windows.Forms.Label();
            this.lbl_distance_header = new System.Windows.Forms.Label();
            this.lbl_finished_at = new System.Windows.Forms.Label();
            this.lbl_time_header = new System.Windows.Forms.Label();
            this.lbl_info = new System.Windows.Forms.Label();
            this.lbl_runner_name = new System.Windows.Forms.Label();
            this.btn_cert = new System.Windows.Forms.Button();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.cardSearch.SuspendLayout();
            this.cardEvent.SuspendLayout();
            this.cardResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_Close.Location = new System.Drawing.Point(351, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(87, 46);
            this.btn_Close.TabIndex = 6;
            this.btn_Close.Text = "×";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.lbl_title.Font = new System.Drawing.Font("Open Sans Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_title.Location = new System.Drawing.Point(0, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(438, 46);
            this.lbl_title.TabIndex = 5;
            this.lbl_title.Text = "Marathon Skills";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Lbl_title_MouseDown);
            this.lbl_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Lbl_title_MouseMove);
            // 
            // cardSearch
            // 
            this.cardSearch.BackColor = System.Drawing.SystemColors.Window;
            this.cardSearch.Controls.Add(this.lblStartat);
            this.cardSearch.Controls.Add(this.lblEvent);
            this.cardSearch.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardSearch.Location = new System.Drawing.Point(15, 62);
            this.cardSearch.Name = "cardSearch";
            this.cardSearch.Size = new System.Drawing.Size(406, 76);
            this.cardSearch.TabIndex = 7;
            // 
            // lblStartat
            // 
            this.lblStartat.AutoSize = true;
            this.lblStartat.Location = new System.Drawing.Point(10, 47);
            this.lblStartat.Name = "lblStartat";
            this.lblStartat.Size = new System.Drawing.Size(163, 15);
            this.lblStartat.TabIndex = 5;
            this.lblStartat.Text = " Running @ {city}, {created_at}";
            // 
            // lblEvent
            // 
            this.lblEvent.AutoEllipsis = true;
            this.lblEvent.Font = new System.Drawing.Font("Open Sans Semibold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.lblEvent.Location = new System.Drawing.Point(8, 9);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(387, 30);
            this.lblEvent.TabIndex = 2;
            this.lblEvent.Text = "Marathon Skills 2017";
            // 
            // cardEvent
            // 
            this.cardEvent.BackColor = System.Drawing.Color.White;
            this.cardEvent.Controls.Add(this.lbl_total_postition_header);
            this.cardEvent.Controls.Add(this.lbl_current_position);
            this.cardEvent.Controls.Add(this.lbl_overall_header);
            this.cardEvent.Controls.Add(this.cardResult);
            this.cardEvent.Controls.Add(this.lbl_info);
            this.cardEvent.Controls.Add(this.lbl_runner_name);
            this.cardEvent.Controls.Add(this.btn_cert);
            this.cardEvent.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardEvent.Location = new System.Drawing.Point(15, 153);
            this.cardEvent.Name = "cardEvent";
            this.cardEvent.Size = new System.Drawing.Size(406, 311);
            this.cardEvent.TabIndex = 8;
            // 
            // lbl_total_postition_header
            // 
            this.lbl_total_postition_header.Location = new System.Drawing.Point(13, 285);
            this.lbl_total_postition_header.Name = "lbl_total_postition_header";
            this.lbl_total_postition_header.Size = new System.Drawing.Size(382, 15);
            this.lbl_total_postition_header.TabIndex = 10;
            this.lbl_total_postition_header.Text = "Out of {Total}";
            this.lbl_total_postition_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_current_position
            // 
            this.lbl_current_position.Font = new System.Drawing.Font("Open Sans Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_current_position.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.lbl_current_position.Location = new System.Drawing.Point(13, 263);
            this.lbl_current_position.Name = "lbl_current_position";
            this.lbl_current_position.Size = new System.Drawing.Size(382, 15);
            this.lbl_current_position.TabIndex = 9;
            this.lbl_current_position.Text = "{Pos}";
            this.lbl_current_position.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_overall_header
            // 
            this.lbl_overall_header.Location = new System.Drawing.Point(13, 239);
            this.lbl_overall_header.Name = "lbl_overall_header";
            this.lbl_overall_header.Size = new System.Drawing.Size(382, 17);
            this.lbl_overall_header.TabIndex = 8;
            this.lbl_overall_header.Text = "Overall position";
            this.lbl_overall_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardResult
            // 
            this.cardResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.cardResult.Controls.Add(this.lbl_pace);
            this.cardResult.Controls.Add(this.lbl_speed);
            this.cardResult.Controls.Add(this.lbl_distance);
            this.cardResult.Controls.Add(this.lbl_pace_header);
            this.cardResult.Controls.Add(this.lbl_speed_header);
            this.cardResult.Controls.Add(this.lbl_distance_header);
            this.cardResult.Controls.Add(this.lbl_finished_at);
            this.cardResult.Controls.Add(this.lbl_time_header);
            this.cardResult.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cardResult.Location = new System.Drawing.Point(0, 69);
            this.cardResult.Name = "cardResult";
            this.cardResult.Size = new System.Drawing.Size(406, 163);
            this.cardResult.TabIndex = 7;
            // 
            // lbl_pace
            // 
            this.lbl_pace.AutoEllipsis = true;
            this.lbl_pace.Font = new System.Drawing.Font("Open Sans Semibold", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pace.ForeColor = System.Drawing.Color.White;
            this.lbl_pace.Location = new System.Drawing.Point(203, 129);
            this.lbl_pace.Name = "lbl_pace";
            this.lbl_pace.Size = new System.Drawing.Size(192, 24);
            this.lbl_pace.TabIndex = 11;
            this.lbl_pace.Text = "{Pace}";
            this.lbl_pace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_speed
            // 
            this.lbl_speed.AutoEllipsis = true;
            this.lbl_speed.Font = new System.Drawing.Font("Open Sans Semibold", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_speed.ForeColor = System.Drawing.Color.White;
            this.lbl_speed.Location = new System.Drawing.Point(203, 105);
            this.lbl_speed.Name = "lbl_speed";
            this.lbl_speed.Size = new System.Drawing.Size(192, 24);
            this.lbl_speed.TabIndex = 10;
            this.lbl_speed.Text = "{Speed}";
            this.lbl_speed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_distance
            // 
            this.lbl_distance.AutoEllipsis = true;
            this.lbl_distance.Font = new System.Drawing.Font("Open Sans Semibold", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_distance.ForeColor = System.Drawing.Color.White;
            this.lbl_distance.Location = new System.Drawing.Point(203, 81);
            this.lbl_distance.Name = "lbl_distance";
            this.lbl_distance.Size = new System.Drawing.Size(192, 24);
            this.lbl_distance.TabIndex = 9;
            this.lbl_distance.Text = "{Distance}";
            this.lbl_distance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_pace_header
            // 
            this.lbl_pace_header.AutoEllipsis = true;
            this.lbl_pace_header.Font = new System.Drawing.Font("Open Sans", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pace_header.ForeColor = System.Drawing.Color.White;
            this.lbl_pace_header.Location = new System.Drawing.Point(114, 129);
            this.lbl_pace_header.Name = "lbl_pace_header";
            this.lbl_pace_header.Size = new System.Drawing.Size(83, 24);
            this.lbl_pace_header.TabIndex = 8;
            this.lbl_pace_header.Text = "Pace";
            this.lbl_pace_header.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_speed_header
            // 
            this.lbl_speed_header.AutoEllipsis = true;
            this.lbl_speed_header.Font = new System.Drawing.Font("Open Sans", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_speed_header.ForeColor = System.Drawing.Color.White;
            this.lbl_speed_header.Location = new System.Drawing.Point(114, 105);
            this.lbl_speed_header.Name = "lbl_speed_header";
            this.lbl_speed_header.Size = new System.Drawing.Size(83, 24);
            this.lbl_speed_header.TabIndex = 7;
            this.lbl_speed_header.Text = "Speed";
            this.lbl_speed_header.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_distance_header
            // 
            this.lbl_distance_header.AutoEllipsis = true;
            this.lbl_distance_header.Font = new System.Drawing.Font("Open Sans", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_distance_header.ForeColor = System.Drawing.Color.White;
            this.lbl_distance_header.Location = new System.Drawing.Point(114, 81);
            this.lbl_distance_header.Name = "lbl_distance_header";
            this.lbl_distance_header.Size = new System.Drawing.Size(83, 24);
            this.lbl_distance_header.TabIndex = 6;
            this.lbl_distance_header.Text = "Finished";
            this.lbl_distance_header.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_finished_at
            // 
            this.lbl_finished_at.AutoEllipsis = true;
            this.lbl_finished_at.Font = new System.Drawing.Font("Open Sans Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_finished_at.ForeColor = System.Drawing.Color.White;
            this.lbl_finished_at.Location = new System.Drawing.Point(8, 35);
            this.lbl_finished_at.Name = "lbl_finished_at";
            this.lbl_finished_at.Size = new System.Drawing.Size(387, 46);
            this.lbl_finished_at.TabIndex = 5;
            this.lbl_finished_at.Text = "{Time}";
            this.lbl_finished_at.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_time_header
            // 
            this.lbl_time_header.AutoEllipsis = true;
            this.lbl_time_header.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time_header.ForeColor = System.Drawing.Color.White;
            this.lbl_time_header.Location = new System.Drawing.Point(13, 11);
            this.lbl_time_header.Name = "lbl_time_header";
            this.lbl_time_header.Size = new System.Drawing.Size(382, 24);
            this.lbl_time_header.TabIndex = 4;
            this.lbl_time_header.Text = "GUN TIME";
            this.lbl_time_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroToolTip1.SetToolTip(this.lbl_time_header, "Official time from the first runner (gunshot) to your finish, typically used for " +
        "ranking");
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Location = new System.Drawing.Point(10, 41);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(170, 15);
            this.lbl_info.TabIndex = 6;
            this.lbl_info.Text = " Bib #{ID} , {Country} , {Gender}";
            // 
            // lbl_runner_name
            // 
            this.lbl_runner_name.AutoEllipsis = true;
            this.lbl_runner_name.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_runner_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.lbl_runner_name.Location = new System.Drawing.Point(9, 18);
            this.lbl_runner_name.Name = "lbl_runner_name";
            this.lbl_runner_name.Size = new System.Drawing.Size(264, 24);
            this.lbl_runner_name.TabIndex = 3;
            this.lbl_runner_name.Text = "Runner Name";
            // 
            // btn_cert
            // 
            this.btn_cert.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.btn_cert.FlatAppearance.BorderSize = 2;
            this.btn_cert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cert.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.btn_cert.Image = global::MarathonSystem.Properties.Resources.trophy;
            this.btn_cert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cert.Location = new System.Drawing.Point(279, 18);
            this.btn_cert.Name = "btn_cert";
            this.btn_cert.Size = new System.Drawing.Size(116, 38);
            this.btn_cert.TabIndex = 0;
            this.btn_cert.Text = "Certificate";
            this.btn_cert.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cert.UseVisualStyleBackColor = true;
            this.btn_cert.Click += new System.EventHandler(this.btn_cert_Click);
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // Frm_RaceBib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 483);
            this.Controls.Add(this.cardEvent);
            this.Controls.Add(this.cardSearch);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.lbl_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_RaceBib";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Event Result";
            this.Load += new System.EventHandler(this.Frm_RaceBib_Load);
            this.cardSearch.ResumeLayout(false);
            this.cardSearch.PerformLayout();
            this.cardEvent.ResumeLayout(false);
            this.cardEvent.PerformLayout();
            this.cardResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Panel cardSearch;
        private System.Windows.Forms.Label lblStartat;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.Panel cardEvent;
        private System.Windows.Forms.Button btn_cert;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.Label lbl_runner_name;
        private System.Windows.Forms.Panel cardResult;
        private System.Windows.Forms.Label lbl_time_header;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private System.Windows.Forms.Label lbl_finished_at;
        private System.Windows.Forms.Label lbl_total_postition_header;
        private System.Windows.Forms.Label lbl_current_position;
        private System.Windows.Forms.Label lbl_overall_header;
        private System.Windows.Forms.Label lbl_pace;
        private System.Windows.Forms.Label lbl_speed;
        private System.Windows.Forms.Label lbl_distance;
        private System.Windows.Forms.Label lbl_pace_header;
        private System.Windows.Forms.Label lbl_speed_header;
        private System.Windows.Forms.Label lbl_distance_header;
    }
}