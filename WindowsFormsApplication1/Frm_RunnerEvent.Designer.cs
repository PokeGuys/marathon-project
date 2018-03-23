namespace MarathonSystem
{
    partial class Frm_RunnerEvent
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
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_item = new System.Windows.Forms.Label();
            this.btn_checkin = new System.Windows.Forms.Button();
            this.lbl_status = new System.Windows.Forms.Label();
            this.btn_send = new System.Windows.Forms.Button();
            this.txt_finished = new System.Windows.Forms.TextBox();
            this.lbl_guntime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_update.FlatAppearance.BorderSize = 0;
            this.btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_update.Font = new System.Drawing.Font("Open Sans Light", 12F);
            this.btn_update.Location = new System.Drawing.Point(10, 171);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(337, 42);
            this.btn_update.TabIndex = 54;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_close.Location = new System.Drawing.Point(309, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(52, 46);
            this.btn_close.TabIndex = 53;
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
            this.lbl_title.Size = new System.Drawing.Size(368, 46);
            this.lbl_title.TabIndex = 52;
            this.lbl_title.Text = "Registered Event";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Lbl_title_MouseDown);
            this.lbl_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Lbl_title_MouseMove);
            // 
            // lbl_item
            // 
            this.lbl_item.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lbl_item.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_item.Font = new System.Drawing.Font("Open Sans Light", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_item.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_item.Location = new System.Drawing.Point(10, 87);
            this.lbl_item.Name = "lbl_item";
            this.lbl_item.Size = new System.Drawing.Size(337, 34);
            this.lbl_item.TabIndex = 56;
            this.lbl_item.Text = "   Event Name";
            this.lbl_item.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_checkin
            // 
            this.btn_checkin.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_checkin.FlatAppearance.BorderSize = 0;
            this.btn_checkin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_checkin.Font = new System.Drawing.Font("Open Sans Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_checkin.Location = new System.Drawing.Point(181, 219);
            this.btn_checkin.Name = "btn_checkin";
            this.btn_checkin.Size = new System.Drawing.Size(166, 32);
            this.btn_checkin.TabIndex = 58;
            this.btn_checkin.Text = "Checkin";
            this.btn_checkin.UseVisualStyleBackColor = false;
            this.btn_checkin.Click += new System.EventHandler(this.btn_checkin_Click);
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Font = new System.Drawing.Font("Open Sans", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status.Location = new System.Drawing.Point(7, 60);
            this.lbl_status.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(158, 15);
            this.lbl_status.TabIndex = 62;
            this.lbl_status.Text = "Race Kit: {0} | Checked-in: {1}";
            // 
            // btn_send
            // 
            this.btn_send.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_send.FlatAppearance.BorderSize = 0;
            this.btn_send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_send.Font = new System.Drawing.Font("Open Sans Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send.Location = new System.Drawing.Point(10, 219);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(165, 32);
            this.btn_send.TabIndex = 64;
            this.btn_send.Text = "Send Racekit";
            this.btn_send.UseVisualStyleBackColor = false;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // txt_finished
            // 
            this.txt_finished.Location = new System.Drawing.Point(12, 145);
            this.txt_finished.Name = "txt_finished";
            this.txt_finished.Size = new System.Drawing.Size(335, 20);
            this.txt_finished.TabIndex = 65;
            // 
            // lbl_guntime
            // 
            this.lbl_guntime.AutoSize = true;
            this.lbl_guntime.Font = new System.Drawing.Font("Open Sans", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_guntime.Location = new System.Drawing.Point(11, 127);
            this.lbl_guntime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_guntime.Name = "lbl_guntime";
            this.lbl_guntime.Size = new System.Drawing.Size(113, 15);
            this.lbl_guntime.TabIndex = 66;
            this.lbl_guntime.Text = "GunTime (in second)";
            // 
            // Frm_RunnerEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 263);
            this.Controls.Add(this.lbl_guntime);
            this.Controls.Add(this.txt_finished);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.btn_checkin);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.lbl_item);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_RunnerEvent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Runner Event";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_item;
        private System.Windows.Forms.Button btn_checkin;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox txt_finished;
        private System.Windows.Forms.Label lbl_guntime;
    }
}