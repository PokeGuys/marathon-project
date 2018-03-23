namespace MarathonSystem
{
    partial class Frm_Certificate
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
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_event = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lbl_desc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.certTopBar = new System.Windows.Forms.Panel();
            this.certBotBar = new System.Windows.Forms.Panel();
            this.picSeal = new System.Windows.Forms.PictureBox();
            this.btn_download = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSeal)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.Font = new System.Drawing.Font("Palace Script MT", 48F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(16, 112);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(795, 60);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "YOUR NAME";
            this.lbl_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_name.Click += new System.EventHandler(this.Close_Click);
            // 
            // lbl_event
            // 
            this.lbl_event.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_event.Location = new System.Drawing.Point(12, 172);
            this.lbl_event.Name = "lbl_event";
            this.lbl_event.Size = new System.Drawing.Size(799, 43);
            this.lbl_event.TabIndex = 1;
            this.lbl_event.Text = "Officially completed the XXX Marathon on October 12, 2014";
            this.lbl_event.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_event.Click += new System.EventHandler(this.Close_Click);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(474, 313);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(207, 95);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 2;
            this.picLogo.TabStop = false;
            this.picLogo.Click += new System.EventHandler(this.Close_Click);
            // 
            // lbl_desc
            // 
            this.lbl_desc.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_desc.Location = new System.Drawing.Point(12, 226);
            this.lbl_desc.Name = "lbl_desc";
            this.lbl_desc.Size = new System.Drawing.Size(799, 68);
            this.lbl_desc.TabIndex = 3;
            this.lbl_desc.Text = "Official Finish Time: XX:XX:XX\r\nPace Per Mile: XX:XX\r\nOverall Place: 300 of 1539";
            this.lbl_desc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_desc.Click += new System.EventHandler(this.Close_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(799, 43);
            this.label1.TabIndex = 4;
            this.label1.Text = "CONGRATUATIONS !";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.Close_Click);
            // 
            // certTopBar
            // 
            this.certTopBar.BackColor = System.Drawing.Color.Maroon;
            this.certTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.certTopBar.Location = new System.Drawing.Point(0, 0);
            this.certTopBar.Name = "certTopBar";
            this.certTopBar.Size = new System.Drawing.Size(823, 33);
            this.certTopBar.TabIndex = 5;
            this.certTopBar.Click += new System.EventHandler(this.Close_Click);
            // 
            // certBotBar
            // 
            this.certBotBar.BackColor = System.Drawing.Color.MidnightBlue;
            this.certBotBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.certBotBar.Location = new System.Drawing.Point(0, 414);
            this.certBotBar.Name = "certBotBar";
            this.certBotBar.Size = new System.Drawing.Size(823, 33);
            this.certBotBar.TabIndex = 6;
            this.certBotBar.Click += new System.EventHandler(this.Close_Click);
            // 
            // picSeal
            // 
            this.picSeal.Location = new System.Drawing.Point(687, 288);
            this.picSeal.Name = "picSeal";
            this.picSeal.Size = new System.Drawing.Size(124, 120);
            this.picSeal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSeal.TabIndex = 7;
            this.picSeal.TabStop = false;
            // 
            // btn_download
            // 
            this.btn_download.FlatAppearance.BorderSize = 0;
            this.btn_download.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btn_download.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_download.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_download.Image = global::MarathonSystem.Properties.Resources.download;
            this.btn_download.Location = new System.Drawing.Point(12, 373);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(40, 35);
            this.btn_download.TabIndex = 8;
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // Frm_Certificate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(823, 447);
            this.Controls.Add(this.btn_download);
            this.Controls.Add(this.picSeal);
            this.Controls.Add(this.certBotBar);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_desc);
            this.Controls.Add(this.lbl_event);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.certTopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Certificate";
            this.Text = "Certificate";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSeal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_event;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lbl_desc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel certTopBar;
        private System.Windows.Forms.Panel certBotBar;
        private System.Windows.Forms.PictureBox picSeal;
        private System.Windows.Forms.Button btn_download;
    }
}