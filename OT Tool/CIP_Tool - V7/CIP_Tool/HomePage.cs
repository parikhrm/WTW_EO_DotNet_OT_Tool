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
    public partial class HomePage : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();


        public HomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            checkaccess_list();
        }

        private void propose_ot_Click(object sender, EventArgs e)
        {
            this.Hide();
            OT_Approver obj1 = new OT_Approver();
            obj1.Show();
        }

        private void ot_tool_Click(object sender, EventArgs e)
        {
            this.Hide();
            OT obj1 = new OT();
            obj1.Show();
        }

   

        public void checkaccess_list()
        {
            Emp_Details obj_access = new Emp_Details();
            DataTable dtaa = new DataTable();
            obj_access.check_accesslevel(dtaa);
            check_access.DataSource = dtaa;
            check_access.DisplayMember = "OTTool_Access";
            conn.Close();
            //check_access.SelectedIndex = -1;
            if (check_access.Text == "Admin")
            {
                propose_ot.Enabled = true;
            }
            else 
            {
                propose_ot.Enabled = false;
            }
            check_access.Visible = false;
        }
    }
}
