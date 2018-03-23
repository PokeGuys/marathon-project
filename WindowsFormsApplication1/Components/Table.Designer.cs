namespace MarathonSystem.Components
{
    partial class Table
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
            this.tableList = new System.Windows.Forms.ListView();
            this.btn_view = new MetroFramework.Controls.MetroButton();
            this.btn_remove = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // tableList
            // 
            this.tableList.Font = new System.Drawing.Font("Open Sans", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableList.FullRowSelect = true;
            this.tableList.Location = new System.Drawing.Point(0, 0);
            this.tableList.Margin = new System.Windows.Forms.Padding(2);
            this.tableList.MultiSelect = false;
            this.tableList.Name = "tableList";
            this.tableList.Size = new System.Drawing.Size(477, 258);
            this.tableList.TabIndex = 4;
            this.tableList.UseCompatibleStateImageBehavior = false;
            this.tableList.View = System.Windows.Forms.View.Details;
            // 
            // btn_view
            // 
            this.btn_view.Location = new System.Drawing.Point(239, 258);
            this.btn_view.Margin = new System.Windows.Forms.Padding(2);
            this.btn_view.Name = "btn_view";
            this.btn_view.Size = new System.Drawing.Size(238, 41);
            this.btn_view.TabIndex = 1;
            this.btn_view.Text = "View";
            this.btn_view.UseSelectable = true;
            this.btn_view.Click += new System.EventHandler(this.btn_view_Click);
            // 
            // btn_remove
            // 
            this.btn_remove.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_remove.Location = new System.Drawing.Point(0, 258);
            this.btn_remove.Margin = new System.Windows.Forms.Padding(2);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(238, 41);
            this.btn_remove.TabIndex = 2;
            this.btn_remove.Text = "Remove";
            this.btn_remove.UseSelectable = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(477, 299);
            this.Controls.Add(this.tableList);
            this.Controls.Add(this.btn_remove);
            this.Controls.Add(this.btn_view);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Table";
            this.Text = "Table";
            this.Load += new System.EventHandler(this.Table_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroButton btn_view;
        private MetroFramework.Controls.MetroButton btn_remove;
        public System.Windows.Forms.ListView tableList;
    }
}