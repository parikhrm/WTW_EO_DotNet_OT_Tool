using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
//using Outlook = Microsoft.Office.Interop.Outlook;
using System.Net.Mail;
//using System.Windows.Forms.Integration;
using System.Windows.Forms.Design;

namespace CIP_Tool
{
    public partial class OT : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public OT()
        {
            InitializeComponent();
        }

        private void OT_Load(object sender, EventArgs e)
        {
            
            reportingmanager_list();
            adminlevel_check();
            reset_overall();
        }

        public void reset_overall()
        {
            hrcloudid.Text = string.Empty;
            otdate.Text = DateTime.Now.ToLongDateString();
            requestid.Enabled = false;
            otminutes.Enabled = false;
            otminutes.Text = string.Empty;
            othours.Enabled = false;
            othours.Text = string.Empty;
            comments.Text = string.Empty;
            empname.Enabled = false;
            processname_load();
            datagridview1_display_overall();
            empname.SelectedIndex = -1;
            starttime.CustomFormat = " ";
            endtime.CustomFormat = " ";
            breakstarttime.CustomFormat = " ";
            breakendtime.CustomFormat = " ";
            insert.Enabled = true;
            update.Enabled = false;
            searchby_month.CustomFormat = " ";
            breakstarttime.Visible = false;
            breakendtime.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            //updatestatus.Enabled = false;
            //rejected.Enabled = false;
            ot_code.Text = string.Empty;
        }

        public void adminlevel_check()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                //adminlevel.SelectedIndex = -1;
                Emp_Details obj_empnames = new Emp_Details();
                DataTable dtaa = new DataTable();
                obj_empnames.check_accesslevel(dtaa);
                adminlevel.DataSource = dtaa;
                adminlevel.DisplayMember = "OTTool_Access";
                conn.Close();
                adminlevel.Visible = false;
                emailaddress.Visible = false;
                if (adminlevel.Text == "Admin")
                {
                    //insert.Enabled = true;
                    //update.Enabled = true;
                    dataGridView1.Enabled = true;
                    dataGridView1.AllowUserToDeleteRows = true;
                    dataGridView1.ReadOnly = false;
                    updatestatus.Enabled = true;
                    rejected.Enabled = true;
                    searchby_associatename.Enabled = true;
                    searchby_reportingmanagername.Enabled = true;
                    button4.Enabled = true;
                }
                else
                {
                    //insert.Enabled = false;
                    //update.Enabled = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.ReadOnly = true;
                    updatestatus.Enabled = false;
                    rejected.Enabled = false;
                    searchby_associatename.Enabled = false;
                    searchby_reportingmanagername.Enabled = false;
                    button4.Enabled = false;
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void emailaddress_load()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                emailaddress.SelectedIndex = -1;
                emailaddress.Visible = false;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                sda.SelectCommand = cmd;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.vw_emp_details_dotnet where 1=1 and EmpName = @EmpName";
                cmd.Parameters.AddWithValue("@EmpName", empname.Text);
                sda.Fill(dt);
                emailaddress.DataSource = dt;
                emailaddress.DisplayMember = "EmailAddressNew";
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void processname_load()
        {
            Emp_Details obj_processname = new Emp_Details();
            DataTable dtaa = new DataTable();
            obj_processname.process_list(dtaa);
            processname.DataSource = dtaa;
            processname.DisplayMember = "Process";
            conn.Close();
            processname.SelectedIndex = -1;
        }

        public void empname_list()
        {
            Emp_Details obj_empname = new Emp_Details();
            DataTable dtaa = new DataTable();
            obj_empname.empname_list_basedon_reportingmanager(dtaa,searchby_reportingmanagername.Text);
            searchby_associatename.DataSource = dtaa;
            searchby_associatename.DisplayMember = "EmpName";
            conn.Close();
            searchby_associatename.SelectedIndex = -1;
        }

        public void reportingmanager_list()
        {
            Emp_Details obj_reportingmanager = new Emp_Details();
            DataTable dtaa = new DataTable();
            obj_reportingmanager.reportingmanager_list(dtaa);
            searchby_reportingmanagername.DataSource = dtaa;
            searchby_reportingmanagername.DisplayMember = "Reporting Manager";
            conn.Close();
            searchby_reportingmanagername.SelectedIndex = -1;
        }

        public void empname_load()
        {
            if (!string.IsNullOrEmpty(hrcloudid.Text) && hrcloudid.TextLength == 7)
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
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select EmpName from dbo.tbl_emp_details with(nolock) where [EmpID - New] = @empidparam";
                    cmd.Parameters.AddWithValue("@empidparam", hrcloudid.Text);
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                    empname.DataSource = dt;
                    empname.DisplayMember = "EmpName";
                }
                catch (Exception ab)
                {
                    MessageBox.Show("Error Generated Details: " + ab.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid HR Cloud ID");
                hrcloudid.Focus();
                empname.SelectedIndex = -1;
            }
        }

        private void hrcloudid_Leave(object sender, EventArgs e)
        {
            //empname_load();
        }

        public void calculate_ot_minutes()
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
                cmd.CommandText = "dbo.usp_calcuate_OTMinutes_dotnet";
                cmd.Parameters.AddWithValue("@Starttime", starttime.Value.ToShortTimeString());
                cmd.Parameters.AddWithValue("@EndTime", endtime.Value.ToShortTimeString());
                cmd.Parameters.AddWithValue("@Date",otdate.Value.Date);
                //cmd.Parameters.AddWithValue("@BreakStartTime", breakstarttime.Value.ToShortTimeString());
                //cmd.Parameters.AddWithValue("@BreakEndTime", breakendtime.Value.ToShortTimeString());
                cmd.Parameters.Add("@OTMinutes_Final", SqlDbType.Int);
                cmd.Parameters["@OTMinutes_Final"].Direction = ParameterDirection.Output;

                //if conditions
                if (starttime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Start Time");
                }
                else if (endtime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update End Time");
                }
                //else if (breakstarttime.Text.Trim() == string.Empty)
                //{
                //    MessageBox.Show("Please update Break Start Time");
                //}
                //else if (breakendtime.Text.Trim() == string.Empty)
                //{
                //    MessageBox.Show("Please update Break End Time");
                //}
                else
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    otminutes.Text = cmd.Parameters["@OTMinutes_Final"].Value.ToString();
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
            }
        }

        public void calculate_ot_hours()
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
                cmd.CommandText = "dbo.usp_calcuate_OTHours_dotnet";
                cmd.Parameters.AddWithValue("@Starttime", starttime.Value.ToShortTimeString());
                cmd.Parameters.AddWithValue("@EndTime", endtime.Value.ToShortTimeString());
                cmd.Parameters.AddWithValue("@Date",otdate.Value.Date);
                //cmd.Parameters.AddWithValue("@BreakStartTime", breakstarttime.Value.ToShortTimeString());
                //cmd.Parameters.AddWithValue("@BreakEndTime", breakendtime.Value.ToShortTimeString());
                cmd.Parameters.Add("@OTMinutes_Final", SqlDbType.Float);
                cmd.Parameters["@OTMinutes_Final"].Direction = ParameterDirection.Output;

                //if conditions
                if (starttime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Start Time");
                }
                else if (endtime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update End Time");
                }
                //else if (breakstarttime.Text.Trim() == string.Empty)
                //{
                //    MessageBox.Show("Please update Break Start Time");
                //}
                //else if (breakendtime.Text.Trim() == string.Empty)
                //{
                //    MessageBox.Show("Please update Break End Time");
                //}
                else
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    othours.Text = cmd.Parameters["@OTMinutes_Final"].Value.ToString();
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculate_ot_minutes();
            calculate_ot_hours();
        }

        private void starttime_MouseDown(object sender, MouseEventArgs e)
        {
            starttime.CustomFormat = "HH:mm";
            //starttime.Text = DateTime.Now.ToShortTimeString();
            if (requestid.Text != string.Empty)
            {
                otminutes.Text = string.Empty;
            }
        }

        private void endtime_MouseDown(object sender, MouseEventArgs e)
        {
            endtime.CustomFormat = "HH:mm";
            //endtime.Text = DateTime.Now.ToShortTimeString();
            if (requestid.Text != string.Empty)
            {
                otminutes.Text = string.Empty;
            }
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
                    cmd.CommandText = "dbo.usp_ot_ciptool_insert_daily_dotnet";
                    cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                    cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@HRCloudID", hrcloudid.Text);
                    cmd.Parameters.AddWithValue("@EmpName", empname.Text);
                    cmd.Parameters.AddWithValue("@OTDate", otdate.Value.Date);
                    cmd.Parameters.AddWithValue("@OTStartTime", starttime.Value.ToShortTimeString());
                    cmd.Parameters.AddWithValue("@OTEndTime", endtime.Value.ToShortTimeString());
                    cmd.Parameters.AddWithValue("@TotalOTInMinutes", otminutes.Text);
                    cmd.Parameters.AddWithValue("@ProcessName", processname.Text);
                    cmd.Parameters.AddWithValue("@Comments", comments.Text);
                    cmd.Parameters.AddWithValue("@IsDeleted", 0);
                    cmd.Parameters.AddWithValue("@LastUpdatedDateTime", DateTime.Now.ToLocalTime());
                    cmd.Parameters.AddWithValue("@LastUpdatedBy", Environment.UserName.ToString());
                    cmd.Parameters.AddWithValue("@MachineName", Environment.MachineName.ToString());
                    cmd.Parameters.AddWithValue("@OT_Code",ot_code.Text);
                    //cmd.Parameters.AddWithValue("@BreakStartTime", breakstarttime.Value.ToShortTimeString());
                    //cmd.Parameters.AddWithValue("@BreakEndTime", breakendtime.Value.ToShortTimeString());

                    if (string.IsNullOrEmpty(hrcloudid.Text))
                    {
                        MessageBox.Show("Please update HR Cloud ID");
                    }
                    else if (string.IsNullOrEmpty(ot_code.Text))
                    {
                        MessageBox.Show("Please update OT Code");
                    }
                    else if (string.IsNullOrEmpty(empname.Text))
                    {
                        MessageBox.Show("Please update Colleague Name");
                    }
                    else if (starttime.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update Start Time");
                    }
                    else if (endtime.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update End Time");
                    }
                    else if (string.IsNullOrEmpty(otminutes.Text))
                    {
                        MessageBox.Show("Please update OT Minutes");
                    }
                    else if (string.IsNullOrEmpty(processname.Text))
                    {
                        MessageBox.Show("Please update Process Name");
                    }
                    //else if (breakstarttime.Text.Trim() == string.Empty)
                    //{
                    //    MessageBox.Show("Please update Break Start Time");
                    //}
                    //else if (breakendtime.Text.Trim() == string.Empty)
                    //{
                    //    MessageBox.Show("Please update Break End Time");
                    //}
                    //else if (Convert.ToInt32(otminutes.Text) < 0)
                    //{
                    //    MessageBox.Show("OT minutes cannot be negative");
                    //}
                    //else if (Convert.ToInt32(othours) < 0)
                    //{
                    //    MessageBox.Show("OT hours cannot be negative");
                    //}
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
                comments.Focus();
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            string messsage = "Do you want to update this record?";
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
                    cmd.CommandText = "dbo.usp_ot_ciptool_update_daily_dotnet";
                    cmd.Parameters.AddWithValue("@RequestID", requestid.Text);
                    cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                    cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@HRCloudID", hrcloudid.Text);
                    cmd.Parameters.AddWithValue("@EmpName", empname.Text);
                    cmd.Parameters.AddWithValue("@OTDate", otdate.Value.Date);
                    cmd.Parameters.AddWithValue("@OTStartTime", starttime.Value.ToShortTimeString());
                    cmd.Parameters.AddWithValue("@OTEndTime", endtime.Value.ToShortTimeString());
                    cmd.Parameters.AddWithValue("@TotalOTInMinutes", otminutes.Text);
                    cmd.Parameters.AddWithValue("@ProcessName", processname.Text);
                    cmd.Parameters.AddWithValue("@Comments", comments.Text);
                    cmd.Parameters.AddWithValue("@LastUpdatedDateTime", DateTime.Now.ToLocalTime());
                    cmd.Parameters.AddWithValue("@LastUpdatedBy", Environment.UserName.ToString());
                    cmd.Parameters.AddWithValue("@MachineName", Environment.MachineName.ToString());
                    //cmd.Parameters.AddWithValue("@BreakStartTime", breakstarttime.Value.ToShortTimeString());
                    //cmd.Parameters.AddWithValue("@BreakEndTime", breakendtime.Value.ToShortTimeString());
                    cmd.Parameters.AddWithValue("@OT_Code",ot_code.Text);

                    if (string.IsNullOrEmpty(hrcloudid.Text))
                    {
                        MessageBox.Show("Please update HR Cloud ID");
                    }
                    else if (string.IsNullOrEmpty(ot_code.Text))
                    {
                        MessageBox.Show("Please update OT Code");
                    }
                    else if (string.IsNullOrEmpty(empname.Text))
                    {
                        MessageBox.Show("Please update Colleague Name");
                    }
                    else if (starttime.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update Start Time");
                    }
                    else if (endtime.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update End Time");
                    }
                    else if (string.IsNullOrEmpty(otminutes.Text))
                    {
                        MessageBox.Show("Please update OT Minutes");
                    }
                    else if (string.IsNullOrEmpty(processname.Text))
                    {
                        MessageBox.Show("Please update Process Name");
                    }

                    //else if (breakstarttime.Text.Trim() == string.Empty)
                    //{
                    //    MessageBox.Show("Please update Break Start Time");
                    //}
                    //else if (breakendtime.Text.Trim() == string.Empty)
                    //{
                    //    MessageBox.Show("Please update Break End Time");
                    //}
                    //else if (Convert.ToInt32(otminutes.Text) < 0)
                    //{
                    //    MessageBox.Show("OT minutes cannot be negative");
                    //}
                    //else if (Convert.ToInt32(othours) < 0)
                    //{
                    //    MessageBox.Show("OT hours cannot be negative");
                    //}
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
                comments.Focus();
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            reset_overall();
        }

        public void datagridview1_display_overall()
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

                if (string.IsNullOrEmpty(searchby_associatename.Text) && string.IsNullOrEmpty(searchby_reportingmanagername.Text) && searchby_month.Text.Trim() == string.Empty && adminlevel.Text == "Admin")
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select RequestID,HRCloudID,EmpName,ReportingManager,OTDate,OTStartTime,OTEndTime,BreakStartTime,BreakEndTime,TotalOTInHours,TotalOTInMinutes,ProcessName,OT_Code,Comments,Verified_by,case when Verified_by is not null then 'Yes' else 'No' end as Verified_by_Rag,ClaimSubmitted_by,case when ClaimSubmitted_by is not null then 'Yes' else 'No' end as ClaimSubmitted_by_Rag, Time_Worked as AOM_TimeWorked from dbo.vw_ot_dotnet where 1=1 /*dateadd(dd,1,eomonth(OTDate,-1)) = dateadd(dd,1,eomonth(@Monthparam,-1))*/ order by OTDate asc";
                    //cmd.Parameters.AddWithValue("@Monthparam", DateTime.Now.Date);
                }
                else if (string.IsNullOrEmpty(searchby_associatename.Text) && string.IsNullOrEmpty(searchby_reportingmanagername.Text) && searchby_month.Text.Trim() == string.Empty && adminlevel.Text != "Admin")
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select RequestID,HRCloudID,EmpName,ReportingManager,OTDate,OTStartTime,OTEndTime,BreakStartTime,BreakEndTime,TotalOTInHours,TotalOTInMinutes,ProcessName,OT_Code,Comments,Verified_by,case when Verified_by is not null then 'Yes' else 'No' end as Verified_by_Rag,ClaimSubmitted_by,case when ClaimSubmitted_by is not null then 'Yes' else 'No' end as ClaimSubmitted_by_Rag, Time_Worked as AOM_TimeWorked from dbo.vw_ot_dotnet where 1=1 and INTID = @intid /*dateadd(dd,1,eomonth(OTDate,-1)) = dateadd(dd,1,eomonth(@Monthparam,-1))*/ order by OTDate asc";
                    cmd.Parameters.AddWithValue("@intid", Environment.UserName.ToString());
                    //cmd.Parameters.AddWithValue("@Monthparam", DateTime.Now.Date);
                }
                else
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.usp_ot_ciptool_datagridview_search_dotnet";
                    if (string.IsNullOrEmpty(searchby_associatename.Text))
                    {
                        cmd.Parameters.AddWithValue("@associatename", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@associatename", searchby_associatename.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_reportingmanagername.Text))
                    {
                        cmd.Parameters.AddWithValue("@reportingmanager", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@reportingmanager", searchby_reportingmanagername.Text);
                    }
                    if (searchby_month.Text.Trim() == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@month", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@month", searchby_month.Value.Date);
                    }
                    cmd.Parameters.AddWithValue("@intid",Environment.UserName.ToString());
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
        

        public void update_status()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    if (row.Cells["txtVerified"].Value != null)
                    {
                        if (Convert.ToBoolean(row.Cells["txtVerified"].Value) == true)
                        {
                            if (conn.State == ConnectionState.Open)
                            {
                                conn.Close();
                            }
                            conn.ConnectionString = connectionstringtxt;
                            cmd.Connection = conn;
                            conn.Open();
                            cmd.Parameters.Clear();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "exec dbo.usp_ot_datagrid_update_verified_dotnet @RequestID,@LastUpdatedDateTime,@LastUpdatedBy";
                            cmd.Parameters.AddWithValue("@RequestID", row.Cells["txtRequestID"].Value);
                            cmd.Parameters.AddWithValue("@LastUpdatedDateTime", DateTime.Now.ToLocalTime());
                            cmd.Parameters.AddWithValue("@LastUpdatedBy", Environment.UserName.ToString());
                            cmd.ExecuteNonQuery();
                        }
                    }
                    //if (row.Cells["txtOkToPay"].Value != null)
                    //{
                    //        if (Convert.ToBoolean(row.Cells["txtOkToPay"].Value) == true)
                    //        {
                    //            if (conn.State == ConnectionState.Open)
                    //            {
                    //                conn.Close();
                    //            }
                    //            conn.ConnectionString = connectionstringtxt;
                    //            cmd.Connection = conn;
                    //            conn.Open();
                    //            cmd.Parameters.Clear();
                    //            cmd.CommandText = "exec usp_ot_datagrid_update_oktopay_dotnet @RequestID,@LastUpdatedDateTime,@LastUpdatedBy";
                    //            cmd.Parameters.AddWithValue("@RequestID", row.Cells["txtRequestID"].Value);
                    //            cmd.Parameters.AddWithValue("@LastUpdatedDateTime", DateTime.Now.ToLocalTime());
                    //            cmd.Parameters.AddWithValue("@LastUpdatedBy", Environment.UserName.ToString());
                    //            cmd.ExecuteNonQuery();
                    //        }
                    // }

                    if (row.Cells["txtClaimSubmitted"].Value != null)
                    {
                        if (Convert.ToBoolean(row.Cells["txtClaimSubmitted"].Value) == true)
                        {
                            if (conn.State == ConnectionState.Open)
                            {
                                conn.Close();
                            }
                            conn.ConnectionString = connectionstringtxt;
                            cmd.Connection = conn;
                            conn.Open();
                            cmd.Parameters.Clear();
                            cmd.CommandText = "exec dbo.usp_ot_datagrid_update_claimsubmitted_dotnet @RequestID,@LastUpdatedDateTime,@LastUpdatedBy";
                            cmd.Parameters.AddWithValue("@RequestID", row.Cells["txtRequestID"].Value);
                            cmd.Parameters.AddWithValue("@LastUpdatedDateTime", DateTime.Now.ToLocalTime());
                            cmd.Parameters.AddWithValue("@LastUpdatedBy", Environment.UserName.ToString());
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                MessageBox.Show("Records Updated Successfully");
                reset_overall();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            update_status();
            datagridview1_display_overall();
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
                    requestid.Text = row.Cells["txtRequestID"].Value.ToString();
                    hrcloudid.Text = row.Cells["txtHRCloudID"].Value.ToString();
                    empname_load();
                    empname.Text = row.Cells["txtEmpName"].Value.ToString();
                    otdate.Text = row.Cells["txtOTDate"].Value.ToString();
                    otdate.CustomFormat = "dd-MMMM-yyyy";
                    starttime.CustomFormat = "HH:mm";
                    starttime.Text = row.Cells["txtOTStartTime"].Value.ToString();
                    endtime.CustomFormat = "HH:mm";
                    endtime.Text = row.Cells["txtOTEndTime"].Value.ToString();
                    //breakstarttime.CustomFormat = "HH:mm";
                    //breakstarttime.Text = row.Cells["txtBreakStartTime"].Value.ToString();
                    //breakendtime.CustomFormat = "HH:mm";
                    //breakendtime.Text = row.Cells["txtBreakEndTime"].Value.ToString();
                    //otminutes.Text = row.Cells["txtTotalOTInMinutes"].Value.ToString();
                    processname.Text = row.Cells["txtProcessName"].Value.ToString();
                    comments.Text = row.Cells["txtComments"].Value.ToString();
                    ot_code.Text = row.Cells["txtOTCode"].Value.ToString();
                    otminutes.Text = string.Empty;
                    othours.Text = string.Empty;

                }
                insert.Enabled = false;
                if (adminlevel.Text == "Admin")
                {
                    update.Enabled = true;
                    rejected.Enabled = true;
                }
                else
                {
                    update.Enabled = false;
                    rejected.Enabled = false;
                }
            }
            else
            {
                comments.Focus();
                insert.Enabled = true;
                update.Enabled = false;
            }
        }

        private void breakstarttime_MouseDown(object sender, MouseEventArgs e)
        {
            breakstarttime.CustomFormat = "HH:mm";
            breakstarttime.Text = DateTime.Now.ToShortTimeString();
            if (requestid.Text != string.Empty)
            {
                otminutes.Text = string.Empty;
            }
        }

        private void breakendtime_MouseDown(object sender, MouseEventArgs e)
        {
            breakendtime.CustomFormat = "HH:mm";
            breakendtime.Text = DateTime.Now.ToShortTimeString();
            if (requestid.Text != string.Empty)
            {
                otminutes.Text = string.Empty;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://A20-CB-DBSE01P/Reports/report/DRD%20MI%20Mumbai/DRD%20Reports/rpt_SSRS_OTReport_RawData_DotNet");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }



        private void empname_SelectedIndexChanged(object sender, EventArgs e)
        {
            emailaddress_load();
        }

        private void breakstarttime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                breakstarttime.CustomFormat = " ";
            }
        }

        private void breakendtime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                breakendtime.CustomFormat = " ";
            }
        }

        private void searchby_reportingmanagername_SelectedIndexChanged(object sender, EventArgs e)
        {
            datagridview1_display_overall();
            empname_list();
        }

        private void searchby_associatename_SelectedIndexChanged(object sender, EventArgs e)
        {
            datagridview1_display_overall();
        }

        private void searchby_month_ValueChanged(object sender, EventArgs e)
        {
            searchby_month.CustomFormat = "MMM-yyyy";
            datagridview1_display_overall();
        }

        private void searchby_month_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                searchby_month.CustomFormat = " ";
                datagridview1_display_overall();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow myrow in dataGridView1.Rows)
            {
                if (myrow.Cells["txtVerified_by_Rag"].Value.ToString() == "Yes" && myrow.Cells["txtClaimSubmitted_by_Rag"].Value.ToString() == "No" )
                {
                    myrow.DefaultCellStyle.BackColor = Color.Orange;
                    myrow.DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (myrow.Cells["txtVerified_by_Rag"].Value.ToString() == "Yes" && myrow.Cells["txtClaimSubmitted_by_Rag"].Value.ToString() == "Yes")
                {
                    myrow.DefaultCellStyle.BackColor = Color.Green;
                    myrow.DefaultCellStyle.ForeColor = Color.White;
                }
                
            }
        }

        private void searchby_reportingmanagername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                searchby_reportingmanagername.SelectedIndex = -1;
            }
        }

        private void searchby_associatename_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                searchby_associatename.SelectedIndex = -1;
            }
        }

        private void rejected_Click(object sender, EventArgs e)
        {
            string messsage = "Do you want to update this record?";
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
                    cmd.CommandText = "dbo.usp_ot_ciptool_rejected_dotnet";
                    cmd.Parameters.AddWithValue("@RequestID", requestid.Text);
                    cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                    cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@LastUpdatedDateTime", DateTime.Now.ToLocalTime());
                    cmd.Parameters.AddWithValue("@LastUpdatedBy", Environment.UserName.ToString());
                    cmd.Parameters.AddWithValue("@MachineName", Environment.MachineName.ToString());
                    
                    if (string.IsNullOrEmpty(requestid.Text))
                    {
                        MessageBox.Show("Please update RequestID");
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
                comments.Focus();
            }
        }

        private void starttime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void requestid_TextChanged(object sender, EventArgs e)
        {

        }

        private void hrcloudid_TextChanged(object sender, EventArgs e)
        {
            //empname_load();
        }

        private void hrcloudid_TabIndexChanged(object sender, EventArgs e)
        {
            //empname_load();
        }

        private void hrcloudid_MouseEnter(object sender, EventArgs e)
        {
            //empname_load();
        }

        private void hrcloudid_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void hrcloudid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                empname_load();
            }
        }

        private void homepage_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage obj_home = new HomePage();
            obj_home.Show();
        }
    
    }
}
