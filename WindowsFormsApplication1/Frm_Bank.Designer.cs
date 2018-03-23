namespace MarathonSystem
{
    partial class Frm_Bank
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Bank));
            this.lbl_item = new System.Windows.Forms.Label();
            this.lbl_cancel = new System.Windows.Forms.Label();
            this.btn_pay = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_cost = new System.Windows.Forms.Label();
            this.btn_upload = new System.Windows.Forms.Button();
            this.lbl_filename = new System.Windows.Forms.Label();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.lbl_preview = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_item
            // 
            this.lbl_item.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lbl_item.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_item.Font = new System.Drawing.Font("Open Sans Light", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_item.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_item.Location = new System.Drawing.Point(13, 85);
            this.lbl_item.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_item.Name = "lbl_item";
            this.lbl_item.Size = new System.Drawing.Size(449, 42);
            this.lbl_item.TabIndex = 45;
            this.lbl_item.Text = "   Event Registration";
            this.lbl_item.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_cancel
            // 
            this.lbl_cancel.AutoSize = true;
            this.lbl_cancel.Font = new System.Drawing.Font("Open Sans Light", 8.25F);
            this.lbl_cancel.Location = new System.Drawing.Point(13, 407);
            this.lbl_cancel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cancel.Name = "lbl_cancel";
            this.lbl_cancel.Size = new System.Drawing.Size(159, 19);
            this.lbl_cancel.TabIndex = 44;
            this.lbl_cancel.Text = "< Back to previous page";
            this.lbl_cancel.Click += new System.EventHandler(this.lbl_cancel_Click);
            // 
            // btn_pay
            // 
            this.btn_pay.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_pay.FlatAppearance.BorderSize = 0;
            this.btn_pay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pay.Font = new System.Drawing.Font("Open Sans Light", 12F);
            this.btn_pay.Location = new System.Drawing.Point(241, 388);
            this.btn_pay.Margin = new System.Windows.Forms.Padding(4);
            this.btn_pay.Name = "btn_pay";
            this.btn_pay.Size = new System.Drawing.Size(221, 52);
            this.btn_pay.TabIndex = 43;
            this.btn_pay.Text = "Pay Now";
            this.btn_pay.UseVisualStyleBackColor = false;
            this.btn_pay.Click += new System.EventHandler(this.btn_pay_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_close.Location = new System.Drawing.Point(412, 0);
            this.btn_close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(69, 57);
            this.btn_close.TabIndex = 42;
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
            this.lbl_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(490, 57);
            this.lbl_title.TabIndex = 41;
            this.lbl_title.Text = "Payment via Bank-in";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_title_MouseDown);
            this.lbl_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_title_MouseMove);
            // 
            // lbl_cost
            // 
            this.lbl_cost.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lbl_cost.Font = new System.Drawing.Font("Open Sans Light", 8.25F);
            this.lbl_cost.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_cost.Location = new System.Drawing.Point(218, 96);
            this.lbl_cost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cost.Name = "lbl_cost";
            this.lbl_cost.Size = new System.Drawing.Size(222, 20);
            this.lbl_cost.TabIndex = 47;
            this.lbl_cost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_upload
            // 
            this.btn_upload.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_upload.FlatAppearance.BorderSize = 0;
            this.btn_upload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_upload.Font = new System.Drawing.Font("Open Sans Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_upload.Location = new System.Drawing.Point(13, 166);
            this.btn_upload.Margin = new System.Windows.Forms.Padding(4);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(449, 40);
            this.btn_upload.TabIndex = 48;
            this.btn_upload.Text = "Click here to upload file";
            this.btn_upload.UseVisualStyleBackColor = false;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // lbl_filename
            // 
            this.lbl_filename.AutoSize = true;
            this.lbl_filename.Font = new System.Drawing.Font("Open Sans", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_filename.Location = new System.Drawing.Point(13, 143);
            this.lbl_filename.Name = "lbl_filename";
            this.lbl_filename.Size = new System.Drawing.Size(0, 19);
            this.lbl_filename.TabIndex = 49;
            // 
            // picPreview
            // 
            this.picPreview.Location = new System.Drawing.Point(19, 246);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(443, 135);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 50;
            this.picPreview.TabStop = false;
            this.picPreview.Click += new System.EventHandler(this.picPreview_Click);
            // 
            // lbl_preview
            // 
            this.lbl_preview.AutoSize = true;
            this.lbl_preview.Font = new System.Drawing.Font("Open Sans Light", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_preview.Location = new System.Drawing.Point(15, 224);
            this.lbl_preview.Name = "lbl_preview";
            this.lbl_preview.Size = new System.Drawing.Size(57, 19);
            this.lbl_preview.TabIndex = 51;
            this.lbl_preview.Text = "Preview";
            // 
            // Frm_Bank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 453);
            this.Controls.Add(this.lbl_preview);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.lbl_filename);
            this.Controls.Add(this.btn_upload);
            this.Controls.Add(this.lbl_cancel);
            this.Controls.Add(this.btn_pay);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.lbl_cost);
            this.Controls.Add(this.lbl_item);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_Bank";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payment via Bank-in";
            this.Load += new System.EventHandler(this.Frm_Bank_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_item;
        private System.Windows.Forms.Label lbl_cancel;
        private System.Windows.Forms.Button btn_pay;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_cost;
        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.Label lbl_filename;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Label lbl_preview;
    }
}