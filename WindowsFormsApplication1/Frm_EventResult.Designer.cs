namespace MarathonSystem
{
    partial class Frm_EventResult
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cardEvent = new System.Windows.Forms.Panel();
            this.newsColumn = new System.Windows.Forms.Panel();
            this.lbl_runner_finished_at = new System.Windows.Forms.Label();
            this.lbl_runner_name = new System.Windows.Forms.Label();
            this.lbl_news_id = new System.Windows.Forms.Label();
            this.cardTable = new System.Windows.Forms.Panel();
            this.lbl_message = new System.Windows.Forms.Label();
            this.lbl_eventHeader = new System.Windows.Forms.Label();
            this.btn_viewAll = new System.Windows.Forms.Button();
            this.cardResultList = new System.Windows.Forms.Panel();
            this.btnView = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.resultList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cardEventHeader = new System.Windows.Forms.Label();
            this.cardSearch.SuspendLayout();
            this.cardEvent.SuspendLayout();
            this.newsColumn.SuspendLayout();
            this.cardTable.SuspendLayout();
            this.cardResultList.SuspendLayout();
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
            this.btn_Close.TabIndex = 3;
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
            this.lbl_title.TabIndex = 2;
            this.lbl_title.Text = "Marathon Skills";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_title_MouseDown);
            this.lbl_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_title_MouseMove);
            // 
            // cardSearch
            // 
            this.cardSearch.BackColor = System.Drawing.SystemColors.Window;
            this.cardSearch.Controls.Add(this.lblStartat);
            this.cardSearch.Controls.Add(this.lblEvent);
            this.cardSearch.Controls.Add(this.btnSearch);
            this.cardSearch.Controls.Add(this.txtSearch);
            this.cardSearch.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardSearch.Location = new System.Drawing.Point(15, 62);
            this.cardSearch.Name = "cardSearch";
            this.cardSearch.Size = new System.Drawing.Size(406, 106);
            this.cardSearch.TabIndex = 4;
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
            this.lblEvent.Text = "Marathon Skills";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(336, 49);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(59, 43);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(11, 70);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(319, 22);
            this.txtSearch.TabIndex = 0;
            // 
            // cardEvent
            // 
            this.cardEvent.BackColor = System.Drawing.Color.White;
            this.cardEvent.Controls.Add(this.newsColumn);
            this.cardEvent.Controls.Add(this.cardTable);
            this.cardEvent.Controls.Add(this.lbl_eventHeader);
            this.cardEvent.Controls.Add(this.btn_viewAll);
            this.cardEvent.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardEvent.Location = new System.Drawing.Point(15, 177);
            this.cardEvent.Name = "cardEvent";
            this.cardEvent.Size = new System.Drawing.Size(406, 280);
            this.cardEvent.TabIndex = 6;
            // 
            // newsColumn
            // 
            this.newsColumn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newsColumn.BackColor = System.Drawing.Color.Gainsboro;
            this.newsColumn.Controls.Add(this.lbl_runner_finished_at);
            this.newsColumn.Controls.Add(this.lbl_runner_name);
            this.newsColumn.Controls.Add(this.lbl_news_id);
            this.newsColumn.Location = new System.Drawing.Point(0, 56);
            this.newsColumn.Name = "newsColumn";
            this.newsColumn.Size = new System.Drawing.Size(406, 24);
            this.newsColumn.TabIndex = 13;
            // 
            // lbl_runner_finished_at
            // 
            this.lbl_runner_finished_at.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_runner_finished_at.AutoSize = true;
            this.lbl_runner_finished_at.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_runner_finished_at.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_runner_finished_at.Location = new System.Drawing.Point(301, 3);
            this.lbl_runner_finished_at.Name = "lbl_runner_finished_at";
            this.lbl_runner_finished_at.Size = new System.Drawing.Size(54, 17);
            this.lbl_runner_finished_at.TabIndex = 2;
            this.lbl_runner_finished_at.Text = "Finished";
            // 
            // lbl_runner_name
            // 
            this.lbl_runner_name.AutoSize = true;
            this.lbl_runner_name.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_runner_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_runner_name.Location = new System.Drawing.Point(114, 3);
            this.lbl_runner_name.Name = "lbl_runner_name";
            this.lbl_runner_name.Size = new System.Drawing.Size(41, 17);
            this.lbl_runner_name.TabIndex = 1;
            this.lbl_runner_name.Text = "Name";
            // 
            // lbl_news_id
            // 
            this.lbl_news_id.AutoSize = true;
            this.lbl_news_id.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_news_id.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_news_id.Location = new System.Drawing.Point(6, 3);
            this.lbl_news_id.Name = "lbl_news_id";
            this.lbl_news_id.Size = new System.Drawing.Size(19, 17);
            this.lbl_news_id.TabIndex = 0;
            this.lbl_news_id.Text = "ID";
            // 
            // cardTable
            // 
            this.cardTable.Controls.Add(this.lbl_message);
            this.cardTable.Location = new System.Drawing.Point(0, 56);
            this.cardTable.Name = "cardTable";
            this.cardTable.Size = new System.Drawing.Size(406, 169);
            this.cardTable.TabIndex = 7;
            // 
            // lbl_message
            // 
            this.lbl_message.BackColor = System.Drawing.Color.White;
            this.lbl_message.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_message.Location = new System.Drawing.Point(9, 36);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(386, 46);
            this.lbl_message.TabIndex = 23;
            this.lbl_message.Text = "Loading...";
            this.lbl_message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_eventHeader
            // 
            this.lbl_eventHeader.AutoEllipsis = true;
            this.lbl_eventHeader.Font = new System.Drawing.Font("Open Sans Semibold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_eventHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.lbl_eventHeader.Location = new System.Drawing.Point(9, 11);
            this.lbl_eventHeader.Name = "lbl_eventHeader";
            this.lbl_eventHeader.Size = new System.Drawing.Size(385, 37);
            this.lbl_eventHeader.TabIndex = 4;
            this.lbl_eventHeader.Text = "Event Name";
            this.lbl_eventHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_viewAll
            // 
            this.btn_viewAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.btn_viewAll.FlatAppearance.BorderSize = 0;
            this.btn_viewAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_viewAll.ForeColor = System.Drawing.Color.White;
            this.btn_viewAll.Location = new System.Drawing.Point(297, 238);
            this.btn_viewAll.Name = "btn_viewAll";
            this.btn_viewAll.Size = new System.Drawing.Size(98, 30);
            this.btn_viewAll.TabIndex = 3;
            this.btn_viewAll.Text = "View Results";
            this.btn_viewAll.UseVisualStyleBackColor = false;
            this.btn_viewAll.Click += new System.EventHandler(this.btn_viewAll_Click);
            // 
            // cardResultList
            // 
            this.cardResultList.BackColor = System.Drawing.Color.White;
            this.cardResultList.Controls.Add(this.btnView);
            this.cardResultList.Controls.Add(this.btnBack);
            this.cardResultList.Controls.Add(this.resultList);
            this.cardResultList.Controls.Add(this.cardEventHeader);
            this.cardResultList.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardResultList.Location = new System.Drawing.Point(15, 177);
            this.cardResultList.Name = "cardResultList";
            this.cardResultList.Size = new System.Drawing.Size(406, 280);
            this.cardResultList.TabIndex = 14;
            this.cardResultList.Visible = false;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.btnView.FlatAppearance.BorderSize = 0;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(297, 238);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(98, 30);
            this.btnView.TabIndex = 16;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(193, 238);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(98, 30);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // resultList
            // 
            this.resultList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.resultList.FullRowSelect = true;
            this.resultList.Location = new System.Drawing.Point(14, 51);
            this.resultList.Name = "resultList";
            this.resultList.Size = new System.Drawing.Size(380, 173);
            this.resultList.TabIndex = 5;
            this.resultList.UseCompatibleStateImageBehavior = false;
            this.resultList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "BIB";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "NAME";
            this.columnHeader2.Width = 117;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "COUNTRY";
            this.columnHeader3.Width = 112;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "GUN TIME";
            this.columnHeader4.Width = 106;
            // 
            // cardEventHeader
            // 
            this.cardEventHeader.AutoEllipsis = true;
            this.cardEventHeader.Font = new System.Drawing.Font("Open Sans Semibold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardEventHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.cardEventHeader.Location = new System.Drawing.Point(9, 11);
            this.cardEventHeader.Name = "cardEventHeader";
            this.cardEventHeader.Size = new System.Drawing.Size(385, 37);
            this.cardEventHeader.TabIndex = 4;
            this.cardEventHeader.Text = "Event Name";
            this.cardEventHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_EventResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 467);
            this.Controls.Add(this.cardSearch);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.cardResultList);
            this.Controls.Add(this.cardEvent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_EventResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Event Result";
            this.Load += new System.EventHandler(this.Frm_EventResult_Load);
            this.cardSearch.ResumeLayout(false);
            this.cardSearch.PerformLayout();
            this.cardEvent.ResumeLayout(false);
            this.newsColumn.ResumeLayout(false);
            this.newsColumn.PerformLayout();
            this.cardTable.ResumeLayout(false);
            this.cardResultList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Panel cardSearch;
        private System.Windows.Forms.Label lblStartat;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.Panel cardEvent;
        private System.Windows.Forms.Panel cardTable;
        private System.Windows.Forms.Label lbl_eventHeader;
        private System.Windows.Forms.Button btn_viewAll;
        private System.Windows.Forms.Panel newsColumn;
        private System.Windows.Forms.Label lbl_runner_finished_at;
        private System.Windows.Forms.Label lbl_runner_name;
        private System.Windows.Forms.Label lbl_news_id;
        private System.Windows.Forms.Panel cardResultList;
        private System.Windows.Forms.ListView resultList;
        private System.Windows.Forms.Label cardEventHeader;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lbl_message;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}