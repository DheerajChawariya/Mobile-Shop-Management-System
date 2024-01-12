using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobile_Shop_Management_system.AllUserControl
{
    public partial class UC_CreateAccount : UserControl
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public UC_CreateAccount()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btncreate_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text == txtconfirm.Text)
            {
                //This sql connection is done to create new account
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                string query = "Insert into login(username,password,confirm_password,email,contact) values('" + txtusername.Text + "','" + txtpassword.Text + "','" + txtconfirm.Text + "','" + txtemail.Text + "','" + txtcontact.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("password created");
                }
                else
                {
                    MessageBox.Show("error occured");
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Please check your password");
            }
        }
    }
}
