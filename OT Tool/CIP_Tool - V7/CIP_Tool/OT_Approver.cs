using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Windows.Forms.Integration;
using System.Windows.Forms.Design;

namespace CIP_Tool
{
    public partial class OT_Approver : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public OT_Approver()
        {
            InitializeComponent();
        }

        private void OT_Approver_Load(object sender, EventArgs e)
        {
            ot_proposer_list();
            ot_approver_list();
            checkaccess_list();
            searchby_ot_approver_name.SelectedIndex = -1;
            searchby_ot_proposer_name.SelectedIndex = -1;
            check_access.Visible = false;
            emailaddress.Visible = false;
            reset_overall();

        }

        public void reset_overall()
        {
            id.Enabled = false;
            id.Text = string.Empty;
            ot_date.CustomFormat = " ";
            ot_hours.Text = string.Empty;
            ot_proposer_comments.Text = string.Empty;
            ot_proposer_name.SelectedIndex = -1;
            ot_approver_name.SelectedIndex = -1;
            ot_approver_comments.Text = string.Empty;
            //check_access.Visible = false;
            if (check_access.Text == "Anup Yadav")
            {
                ot_approver_name.Enabled = true;
            }
            else if (check_access.Text == "Rinkesh Parikh")
            {
                ot_approver_name.Enabled = true;
            }
            else
            {
                ot_approver_name.Enabled = false;
            }
            insert.Enabled = true;
            update.Enabled = false;
            datagridview_display_overall();
        }

        public void sendmail_outlook()
        {
            try
            {
                Outlook.Application _app = new Outlook.Application();
                Outlook.MailItem mail = (Outlook.MailItem)_app.CreateItem(Outlook.OlItemType.olMailItem);
                //mail.SentOnBehalfOfName = "IN_EDS_MIteam@wtwco.com";
                mail.SentOnBehalfOfName = emailaddress.Text;
                mail.To = "Ashutosh.Singh@wtwco.com;Anup.yadav@wtwco.com;rinkesh.parikh@wtwco.com";
                //mail.CC = cc_names.Text;
                mail.Subject = "Approval - Request for New OT";
                mail.Body = "Hi, Request you to approve the new OT." +
                            "Following is the link to access the OT tool :" +
                            " https://wtwonlineap.sharepoint.com/sites/tctnonclient_edskycoms/Documents/Forms/All%20Documents.aspx?id=%2Fsites%2Ftctnonclient%5Fedskycoms%2FDocuments%2FWorkflow%2FEDS%20%2D%20Dot%20Net%20Workflows%2FOT%20Tool%2FOT%5FTool%2Eexe&parent=%2Fsites%2Ftctnonclient%5Fedskycoms%2FDocuments%2FWorkflow%2FEDS%20%2D%20Dot%20Net%20Workflows%2FOT%20Tool ";
                //if (attachment_path.Text != string.Empty)
                //{
                //    mail.Attachments.Add(attachment_path.Text);
                //}
                mail.Importance = Outlook.OlImportance.olImportanceNormal;
                ((Outlook._MailItem)mail).Send();
                //MessageBox.Show("Your message has been sent successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ot_proposer_list()
        {
            Emp_Details obj_ot_proposer = new Emp_Details();
            Emp_Details obj_ot_proposer1 = new Emp_Details();

            DataTable dtaa = new DataTable();
            DataTable dtaa1 = new DataTable();

            obj_ot_proposer.reportingmanager_list (dtaa);
            obj_ot_proposer1.reportingmanager_list(dtaa1);

            ot_proposer_name.DataSource = dtaa;
            searchby_ot_proposer_name.DataSource = dtaa1;

            ot_proposer_name.DisplayMember = "Reporting Manager";
            searchby_ot_proposer_name.DisplayMember = "Reporting Manager";

            conn.Close();
            ot_proposer_name.SelectedIndex = -1;
        }

        public void ot_approver_list()
        {
            Emp_Details obj_ot_approver = new Emp_Details();
            Emp_Details obj_ot_approver1 = new Emp_Details();

            DataTable dtaa = new DataTable();
            DataTable dtaa1 = new DataTable();

            obj_ot_approver.ot_approver_list(dtaa);
            obj_ot_approver1.ot_approver_list(dtaa1);

            ot_approver_name.DataSource = dtaa;
            searchby_ot_approver_name.DataSource = dtaa1;

            ot_approver_name.DisplayMember = "EmpName";
            searchby_ot_approver_name.DisplayMember = "EmpName";
            conn.Close();
            ot_approver_name.SelectedIndex = -1;
        }

        public void checkaccess_list()
        {
            Emp_Details obj_access = new Emp_Details();
            DataTable dtaa = new DataTable();
            obj_access.check_accesslevel(dtaa);
            check_access.DataSource = dtaa;
            emailaddress.DataSource = dtaa;

            check_access.DisplayMember = "EmpName";
            emailaddress.DisplayMember = "EmailAddressNew";

            conn.Close();
            //check_access.SelectedIndex = -1;
        }

        private void reset_Click(object sender, EventArgs e)
        {
            reset_overall();
        }

        private void check_access_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (check_access.Text == "Anup Yadav")
            //{
            //    ot_approver_name.Enabled = true;
            //}
            //else if (check_access.Text == "Rinkesh Parikh")
            //{
            //    ot_approver_name.Enabled = true;
            //}
            //else
            //{
            //    ot_approver_name.Enabled = false;
            //}
        }

        private void insert_Click(object sender, EventArgs e)
        {
            string messsage = "Do you want to insert this record?";
            string title = "Message Box";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(messsage, title, buttons);
            if (result == DialogResult.Yes)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                try
                {
                    cmd.Parameters.Clear();
                    conn.ConnectionString = connectionstringtxt;
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.usp_ot_approver_ciptool_insert_daily_dotnet";
                    cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                    cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@OT_Date", ot_date.Value.Date);
                    cmd.Parameters.AddWithValue("@OT_Hours",ot_hours.Text);
                    if (string.IsNullOrEmpty(ot_proposer_comments.Text))
                    {
                        cmd.Parameters.AddWithValue("@OT_Proposer_Comments", ot_proposer_comments.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@OT_Proposer_Comments", ot_proposer_comments.Text);
                    }
                    cmd.Parameters.AddWithValue("@OT_Proposer_Name",ot_proposer_name.Text);
                    if (string.IsNullOrEmpty(ot_approver_name.Text))
                    {
                        cmd.Parameters.AddWithValue("@OT_Approver_Name", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@OT_Approver_Name", ot_approver_name.Text);
                    }
                    if (string.IsNullOrEmpty(ot_approver_comments.Text))
                    {
                        cmd.Parameters.AddWithValue("@OT_Approver_Comments", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@OT_Approver_Comments", ot_approver_comments.Text);
                    }
                    cmd.Parameters.AddWithValue("@LastUpdatedBy",Environment.UserName.ToString());
                    cmd.Parameters.AddWithValue("@MachineName",Environment.MachineName.ToString());

                    //if conditions
                    if (ot_date.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update OT date");
                    }
                    else if (string.IsNullOrEmpty(ot_hours.Text))
                    {
                        MessageBox.Show("Please update OT hours");
                    }
                    else if (string.IsNullOrEmpty(ot_proposer_name.Text))
                    {
                        MessageBox.Show("Please update OT Proposer Name");
                    }
                    else
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                        MessageBox.Show("" + uploadmessage.ToString());
                        reset_overall();
                        sendmail_outlook();
                    }
                }
                catch (Exception ab)
                {
                    MessageBox.Show("Error Generated Details :" + ab.ToString());
                }
            }
            else
            {
                id.Focus();
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            string messsage = "Do you want to insert this record?";
            string title = "Message Box";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(messsage, title, buttons);
            if (result == DialogResult.Yes)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                try
                {
                    cmd.Parameters.Clear();
                    conn.ConnectionString = connectionstringtxt;
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.usp_ot_approver_ciptool_update_daily_dotnet";
                    cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                    cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@OT_Date", ot_date.Value.Date);
                    cmd.Parameters.AddWithValue("@OT_Hours", ot_hours.Text);
                    if (string.IsNullOrEmpty(ot_proposer_comments.Text))
                    {
                        cmd.Parameters.AddWithValue("@OT_Proposer_Comments", ot_proposer_comments.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@OT_Proposer_Comments", ot_proposer_comments.Text);
                    }
                    cmd.Parameters.AddWithValue("ID",id.Text);
                    cmd.Parameters.AddWithValue("@OT_Proposer_Name", ot_proposer_name.Text);
                    if (string.IsNullOrEmpty(ot_approver_name.Text))
                    {
                        cmd.Parameters.AddWithValue("@OT_Approver_Name", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@OT_Approver_Name", ot_approver_name.Text);
                    }
                    if (string.IsNullOrEmpty(ot_approver_comments.Text))
                    {
                        cmd.Parameters.AddWithValue("@OT_Approver_Comments", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@OT_Approver_Comments", ot_approver_comments.Text);
                    }
                    cmd.Parameters.AddWithValue("@LastUpdatedBy", Environment.UserName.ToString());
                    cmd.Parameters.AddWithValue("@MachineName", Environment.MachineName.ToString());

                    //if conditions
                    if (ot_date.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update OT date");
                    }
                    else if (string.IsNullOrEmpty(ot_hours.Text))
                    {
                        MessageBox.Show("Please update OT hours");
                    }
                    else if (string.IsNullOrEmpty(ot_proposer_name.Text))
                    {
                        MessageBox.Show("Please update OT Proposer Name");
                    }
                    else
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                        MessageBox.Show("" + uploadmessage.ToString());
                        reset_overall();
                    }
                }
                catch (Exception ab)
                {
                    MessageBox.Show("Error Generated Details :" + ab.ToString());
                }
            }
            else
            {
                id.Focus();
            }
        }

        public void datagridview_display_overall()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();

                if (string.IsNullOrEmpty(searchby_ot_proposer_name.Text) && string.IsNullOrEmpty(searchby_ot_approver_name.Text) && searchby_ot_date.Text.Trim() == string.Empty && string.IsNullOrEmpty(searchby_status.Text))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select ID,OT_Date,OT_Hours,OT_Proposer_Name,OT_Proposer_Comments,OT_Approver_Name,OT_Approver_Comments,LastUpdatedBy,LastUpdatedDateTime,case when OT_Approver_Name is null then 'Pending' else 'Completed' end as Status from dbo.vw_ot_approval_dotnet order by OT_Date desc";
                }
                else
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.usp_ot_approver_ciptool_datagridview_search_dotnet";
                    if (string.IsNullOrEmpty(searchby_ot_proposer_name.Text))
                    {
                        cmd.Parameters.AddWithValue("@ot_proposer_name", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ot_proposer_name", searchby_ot_proposer_name.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_ot_approver_name.Text))
                    {
                        cmd.Parameters.AddWithValue("@ot_approver_name", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ot_approver_name", searchby_ot_approver_name.Text);
                    }
                    if (searchby_ot_date.Text.Trim() == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@ot_date", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ot_date", searchby_ot_date.Value.Date);
                    }
                    if (string.IsNullOrEmpty(searchby_status.Text))
                    {
                        cmd.Parameters.AddWithValue("@status", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@status",searchby_status.Text);
                    }
                }
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string messsage = "Do you want to update the record?";
            string title = "Message Box";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(messsage, title, buttons);
            if (result == DialogResult.Yes)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    id.Text = row.Cells["txt_ID"].Value.ToString();
                    ot_date.Text = row.Cells["txt_OT_Date"].Value.ToString();
                    ot_date.CustomFormat = "dd-MMMM-yyyy";
                    ot_hours.Text = row.Cells["txt_OT_Hours"].Value.ToString();
                    ot_proposer_name.Text = row.Cells["txt_OT_Proposer_Name"].Value.ToString();
                    if (string.IsNullOrEmpty(row.Cells["txt_OT_Proposer_Comments"].Value.ToString()))
                    {
                        ot_proposer_comments.Text = string.Empty;
                    }
                    else
                    {
                        ot_proposer_comments.Text = row.Cells["txt_OT_Proposer_Comments"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_OT_Approver_Name"].Value.ToString()))
                    {
                        ot_approver_name.SelectedIndex = -1;
                    }
                    else
                    {
                        ot_approver_name.Text = row.Cells["txt_OT_Approver_Name"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_OT_Approver_Comments"].Value.ToString()))
                    {
                        ot_approver_comments.Text = string.Empty;
                    }
                    else
                    {
                        ot_approver_comments.Text = row.Cells["txt_OT_Approver_Comments"].Value.ToString();
                    }
                }
                insert.Enabled = false;
                update.Enabled = true;
            }
            else
            {
                insert.Enabled = true;
                update.Enabled = false;
            }
        }

        private void homepage_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage obj_home = new HomePage();
            obj_home.Show();
        }

        private void ot_date_ValueChanged(object sender, EventArgs e)
        {
            ot_date.CustomFormat = "dd-MMMM-yyyy";
        }

        private void ot_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                ot_date.CustomFormat = " ";
            }
        }

        private void searchby_ot_date_ValueChanged(object sender, EventArgs e)
        {
            searchby_ot_date.CustomFormat = "dd-MMMM-yyyy";
            datagridview_display_overall();
        }

        private void searchby_ot_proposer_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void searchby_ot_approver_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow myrow in dataGridView1.Rows)
            {
                if (myrow.Cells["txt_Status"].Value.ToString() == "Pending")
                {
                    myrow.DefaultCellStyle.BackColor = Color.Orange;
                    myrow.DefaultCellStyle.ForeColor = Color.Black;
                }
                else 
                {
                    myrow.DefaultCellStyle.BackColor = Color.Green;
                    myrow.DefaultCellStyle.ForeColor = Color.Black;
                }
                
            }
        }

        private void searchby_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void searchby_status_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                searchby_status.SelectedIndex = -1;
            }
        }

    }
}
