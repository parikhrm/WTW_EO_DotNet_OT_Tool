namespace CIP_Tool
{
    partial class OT_Approver
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reset = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.insert = new System.Windows.Forms.Button();
            this.ot_approver_comments = new System.Windows.Forms.TextBox();
            this.ot_approver_name = new System.Windows.Forms.ComboBox();
            this.ot_proposer_name = new System.Windows.Forms.ComboBox();
            this.ot_proposer_comments = new System.Windows.Forms.TextBox();
            this.ot_hours = new System.Windows.Forms.TextBox();
            this.ot_date = new System.Windows.Forms.DateTimePicker();
            this.id = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.check_access = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txt_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_OT_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_OT_Hours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_OT_Proposer_Comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_OT_Proposer_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_OT_Approver_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_OT_Approver_Comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_LastUpdatedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchby_ot_date = new System.Windows.Forms.DateTimePicker();
            this.searchby_ot_proposer_name = new System.Windows.Forms.ComboBox();
            this.searchby_ot_approver_name = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.homepage = new System.Windows.Forms.Button();
            this.searchby_status = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.emailaddress = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "OT Date";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.reset);
            this.groupBox1.Controls.Add(this.update);
            this.groupBox1.Controls.Add(this.insert);
            this.groupBox1.Controls.Add(this.ot_approver_comments);
            this.groupBox1.Controls.Add(this.ot_approver_name);
            this.groupBox1.Controls.Add(this.ot_proposer_name);
            this.groupBox1.Controls.Add(this.ot_proposer_comments);
            this.groupBox1.Controls.Add(this.ot_hours);
            this.groupBox1.Controls.Add(this.ot_date);
            this.groupBox1.Controls.Add(this.id);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(29, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(682, 586);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(335, 486);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(110, 41);
            this.reset.TabIndex = 16;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(202, 486);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(110, 41);
            this.update.TabIndex = 15;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // insert
            // 
            this.insert.Location = new System.Drawing.Point(75, 486);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(110, 41);
            this.insert.TabIndex = 14;
            this.insert.Text = "Insert";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // ot_approver_comments
            // 
            this.ot_approver_comments.Location = new System.Drawing.Point(192, 387);
            this.ot_approver_comments.Multiline = true;
            this.ot_approver_comments.Name = "ot_approver_comments";
            this.ot_approver_comments.Size = new System.Drawing.Size(480, 60);
            this.ot_approver_comments.TabIndex = 13;
            // 
            // ot_approver_name
            // 
            this.ot_approver_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ot_approver_name.FormattingEnabled = true;
            this.ot_approver_name.Location = new System.Drawing.Point(192, 335);
            this.ot_approver_name.Name = "ot_approver_name";
            this.ot_approver_name.Size = new System.Drawing.Size(258, 28);
            this.ot_approver_name.TabIndex = 11;
            // 
            // ot_proposer_name
            // 
            this.ot_proposer_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ot_proposer_name.FormattingEnabled = true;
            this.ot_proposer_name.Location = new System.Drawing.Point(192, 189);
            this.ot_proposer_name.Name = "ot_proposer_name";
            this.ot_proposer_name.Size = new System.Drawing.Size(258, 28);
            this.ot_proposer_name.TabIndex = 7;
            // 
            // ot_proposer_comments
            // 
            this.ot_proposer_comments.Location = new System.Drawing.Point(192, 238);
            this.ot_proposer_comments.Multiline = true;
            this.ot_proposer_comments.Name = "ot_proposer_comments";
            this.ot_proposer_comments.Size = new System.Drawing.Size(480, 54);
            this.ot_proposer_comments.TabIndex = 9;
            // 
            // ot_hours
            // 
            this.ot_hours.Location = new System.Drawing.Point(192, 133);
            this.ot_hours.Name = "ot_hours";
            this.ot_hours.Size = new System.Drawing.Size(122, 26);
            this.ot_hours.TabIndex = 5;
            // 
            // ot_date
            // 
            this.ot_date.CustomFormat = " ";
            this.ot_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ot_date.Location = new System.Drawing.Point(192, 78);
            this.ot_date.Name = "ot_date";
            this.ot_date.Size = new System.Drawing.Size(237, 26);
            this.ot_date.TabIndex = 3;
            this.ot_date.ValueChanged += new System.EventHandler(this.ot_date_ValueChanged);
            this.ot_date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ot_date_KeyDown);
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(192, 22);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(100, 26);
            this.id.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 387);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "OT Approver Comments";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 335);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "OT Approver Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "OT Proposer Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "OT Proposer Comment";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "OT Hours";
            // 
            // check_access
            // 
            this.check_access.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.check_access.FormattingEnabled = true;
            this.check_access.Location = new System.Drawing.Point(544, 13);
            this.check_access.Name = "check_access";
            this.check_access.Size = new System.Drawing.Size(121, 28);
            this.check_access.TabIndex = 3;
            this.check_access.SelectedIndexChanged += new System.EventHandler(this.check_access_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txt_ID,
            this.txt_OT_Date,
            this.txt_OT_Hours,
            this.txt_OT_Proposer_Comments,
            this.txt_OT_Proposer_Name,
            this.txt_OT_Approver_Name,
            this.txt_OT_Approver_Comments,
            this.txt_LastUpdatedBy,
            this.txt_LastUpdatedDateTime,
            this.txt_Status});
            this.dataGridView1.Location = new System.Drawing.Point(736, 152);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(944, 477);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // txt_ID
            // 
            this.txt_ID.DataPropertyName = "ID";
            this.txt_ID.HeaderText = "ID";
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.ReadOnly = true;
            // 
            // txt_OT_Date
            // 
            this.txt_OT_Date.DataPropertyName = "OT_Date";
            this.txt_OT_Date.HeaderText = "OT_Date";
            this.txt_OT_Date.Name = "txt_OT_Date";
            this.txt_OT_Date.ReadOnly = true;
            // 
            // txt_OT_Hours
            // 
            this.txt_OT_Hours.DataPropertyName = "OT_Hours";
            this.txt_OT_Hours.HeaderText = "OT_Hours";
            this.txt_OT_Hours.Name = "txt_OT_Hours";
            this.txt_OT_Hours.ReadOnly = true;
            // 
            // txt_OT_Proposer_Comments
            // 
            this.txt_OT_Proposer_Comments.DataPropertyName = "OT_Proposer_Comments";
            this.txt_OT_Proposer_Comments.HeaderText = "OT_Proposer_Comments";
            this.txt_OT_Proposer_Comments.Name = "txt_OT_Proposer_Comments";
            this.txt_OT_Proposer_Comments.ReadOnly = true;
            // 
            // txt_OT_Proposer_Name
            // 
            this.txt_OT_Proposer_Name.DataPropertyName = "OT_Proposer_Name";
            this.txt_OT_Proposer_Name.HeaderText = "OT_Proposer_Name";
            this.txt_OT_Proposer_Name.Name = "txt_OT_Proposer_Name";
            this.txt_OT_Proposer_Name.ReadOnly = true;
            // 
            // txt_OT_Approver_Name
            // 
            this.txt_OT_Approver_Name.DataPropertyName = "OT_Approver_Name";
            this.txt_OT_Approver_Name.HeaderText = "OT_Approver_Name";
            this.txt_OT_Approver_Name.Name = "txt_OT_Approver_Name";
            this.txt_OT_Approver_Name.ReadOnly = true;
            // 
            // txt_OT_Approver_Comments
            // 
            this.txt_OT_Approver_Comments.DataPropertyName = "OT_Approver_Comments";
            this.txt_OT_Approver_Comments.HeaderText = "OT_Appprover_Comments";
            this.txt_OT_Approver_Comments.Name = "txt_OT_Approver_Comments";
            this.txt_OT_Approver_Comments.ReadOnly = true;
            // 
            // txt_LastUpdatedBy
            // 
            this.txt_LastUpdatedBy.DataPropertyName = "LastUpdatedBy";
            this.txt_LastUpdatedBy.HeaderText = "LastUpdatedBy";
            this.txt_LastUpdatedBy.Name = "txt_LastUpdatedBy";
            this.txt_LastUpdatedBy.ReadOnly = true;
            // 
            // txt_LastUpdatedDateTime
            // 
            this.txt_LastUpdatedDateTime.DataPropertyName = "LastUpdatedDateTime";
            this.txt_LastUpdatedDateTime.HeaderText = "LastUpdatedDateTime";
            this.txt_LastUpdatedDateTime.Name = "txt_LastUpdatedDateTime";
            this.txt_LastUpdatedDateTime.ReadOnly = true;
            // 
            // txt_Status
            // 
            this.txt_Status.DataPropertyName = "Status";
            this.txt_Status.HeaderText = "Status";
            this.txt_Status.Name = "txt_Status";
            this.txt_Status.ReadOnly = true;
            // 
            // searchby_ot_date
            // 
            this.searchby_ot_date.CustomFormat = " ";
            this.searchby_ot_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.searchby_ot_date.Location = new System.Drawing.Point(736, 57);
            this.searchby_ot_date.Name = "searchby_ot_date";
            this.searchby_ot_date.Size = new System.Drawing.Size(224, 26);
            this.searchby_ot_date.TabIndex = 5;
            this.searchby_ot_date.ValueChanged += new System.EventHandler(this.searchby_ot_date_ValueChanged);
            // 
            // searchby_ot_proposer_name
            // 
            this.searchby_ot_proposer_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchby_ot_proposer_name.FormattingEnabled = true;
            this.searchby_ot_proposer_name.Location = new System.Drawing.Point(1160, 56);
            this.searchby_ot_proposer_name.Name = "searchby_ot_proposer_name";
            this.searchby_ot_proposer_name.Size = new System.Drawing.Size(245, 28);
            this.searchby_ot_proposer_name.TabIndex = 6;
            this.searchby_ot_proposer_name.SelectedIndexChanged += new System.EventHandler(this.searchby_ot_proposer_name_SelectedIndexChanged);
            // 
            // searchby_ot_approver_name
            // 
            this.searchby_ot_approver_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchby_ot_approver_name.FormattingEnabled = true;
            this.searchby_ot_approver_name.Location = new System.Drawing.Point(1418, 56);
            this.searchby_ot_approver_name.Name = "searchby_ot_approver_name";
            this.searchby_ot_approver_name.Size = new System.Drawing.Size(231, 28);
            this.searchby_ot_approver_name.TabIndex = 7;
            this.searchby_ot_approver_name.SelectedIndexChanged += new System.EventHandler(this.searchby_ot_approver_name_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(769, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Search by OT Date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1177, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(219, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Search by OT Proposer Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1427, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(219, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "Search by OT Approver Name";
            // 
            // homepage
            // 
            this.homepage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.homepage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homepage.Location = new System.Drawing.Point(29, 8);
            this.homepage.Name = "homepage";
            this.homepage.Size = new System.Drawing.Size(166, 37);
            this.homepage.TabIndex = 36;
            this.homepage.Text = "Home Page";
            this.homepage.UseVisualStyleBackColor = false;
            this.homepage.Click += new System.EventHandler(this.homepage_Click);
            // 
            // searchby_status
            // 
            this.searchby_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchby_status.FormattingEnabled = true;
            this.searchby_status.Items.AddRange(new object[] {
            "Completed",
            "Pending"});
            this.searchby_status.Location = new System.Drawing.Point(966, 57);
            this.searchby_status.Name = "searchby_status";
            this.searchby_status.Size = new System.Drawing.Size(188, 28);
            this.searchby_status.TabIndex = 37;
            this.searchby_status.SelectedIndexChanged += new System.EventHandler(this.searchby_status_SelectedIndexChanged);
            this.searchby_status.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchby_status_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(995, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(131, 20);
            this.label11.TabIndex = 38;
            this.label11.Text = "Search by Status";
            // 
            // emailaddress
            // 
            this.emailaddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.emailaddress.FormattingEnabled = true;
            this.emailaddress.Location = new System.Drawing.Point(690, 13);
            this.emailaddress.Name = "emailaddress";
            this.emailaddress.Size = new System.Drawing.Size(121, 28);
            this.emailaddress.TabIndex = 39;
            // 
            // OT_Approver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1716, 1050);
            this.Controls.Add(this.emailaddress);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.searchby_status);
            this.Controls.Add(this.homepage);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.searchby_ot_approver_name);
            this.Controls.Add(this.searchby_ot_proposer_name);
            this.Controls.Add(this.searchby_ot_date);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.check_access);
            this.Controls.Add(this.groupBox1);
            this.Name = "OT_Approver";
            this.Text = "OT_Approver";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OT_Approver_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ot_approver_comments;
        private System.Windows.Forms.ComboBox ot_approver_name;
        private System.Windows.Forms.ComboBox ot_proposer_name;
        private System.Windows.Forms.TextBox ot_proposer_comments;
        private System.Windows.Forms.TextBox ot_hours;
        private System.Windows.Forms.DateTimePicker ot_date;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.ComboBox check_access;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker searchby_ot_date;
        private System.Windows.Forms.ComboBox searchby_ot_proposer_name;
        private System.Windows.Forms.ComboBox searchby_ot_approver_name;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button homepage;
        private System.Windows.Forms.ComboBox searchby_status;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_OT_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_OT_Hours;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_OT_Proposer_Comments;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_OT_Proposer_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_OT_Approver_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_OT_Approver_Comments;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_LastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_LastUpdatedDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Status;
        private System.Windows.Forms.ComboBox emailaddress;
    }
}