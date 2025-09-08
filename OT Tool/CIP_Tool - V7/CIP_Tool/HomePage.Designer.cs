namespace CIP_Tool
{
    partial class HomePage
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
            this.propose_ot = new System.Windows.Forms.Button();
            this.ot_tool = new System.Windows.Forms.Button();
            this.check_access = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // propose_ot
            // 
            this.propose_ot.BackColor = System.Drawing.Color.Purple;
            this.propose_ot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propose_ot.ForeColor = System.Drawing.Color.White;
            this.propose_ot.Location = new System.Drawing.Point(345, 188);
            this.propose_ot.Name = "propose_ot";
            this.propose_ot.Size = new System.Drawing.Size(300, 153);
            this.propose_ot.TabIndex = 2;
            this.propose_ot.Text = "Propose OT (LMs)";
            this.propose_ot.UseVisualStyleBackColor = false;
            this.propose_ot.Click += new System.EventHandler(this.propose_ot_Click);
            // 
            // ot_tool
            // 
            this.ot_tool.BackColor = System.Drawing.Color.Purple;
            this.ot_tool.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ot_tool.ForeColor = System.Drawing.Color.White;
            this.ot_tool.Location = new System.Drawing.Point(725, 188);
            this.ot_tool.Name = "ot_tool";
            this.ot_tool.Size = new System.Drawing.Size(300, 153);
            this.ot_tool.TabIndex = 3;
            this.ot_tool.Text = "OT Tool";
            this.ot_tool.UseVisualStyleBackColor = false;
            this.ot_tool.Click += new System.EventHandler(this.ot_tool_Click);
            // 
            // check_access
            // 
            this.check_access.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.check_access.FormattingEnabled = true;
            this.check_access.Location = new System.Drawing.Point(459, 29);
            this.check_access.Name = "check_access";
            this.check_access.Size = new System.Drawing.Size(121, 28);
            this.check_access.TabIndex = 4;
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1489, 640);
            this.Controls.Add(this.check_access);
            this.Controls.Add(this.ot_tool);
            this.Controls.Add(this.propose_ot);
            this.Name = "HomePage";
            this.Text = "HomePage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button propose_ot;
        private System.Windows.Forms.Button ot_tool;
        private System.Windows.Forms.ComboBox check_access;
    }
}