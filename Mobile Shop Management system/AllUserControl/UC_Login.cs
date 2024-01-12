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
    public partial class UC_Login : UserControl
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public UC_Login()
        {
            InitializeComponent();
        }
        int abc;
        private void timer1_Tick(object sender, EventArgs e)
        {
            abc++;
            if(abc == 10)
            {
                abc = 0;
                //This connection is created for checking user name and password is correct or not
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                string query = "select * from login where username = @user and confirm_password = @pass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", txtusername.Text);
                cmd.Parameters.AddWithValue("@pass", txtpassword.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    this.Hide();
                    timer1.Stop();
                }
                else
                {
                    panel1.Visible = true;
                    MessageBox.Show("wrong password");
                    timer1.Stop();
                }
                con.Close();
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
            panel1.Visible = false;
            this.guna2WinProgressIndicator1.Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnlogin_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void UC_Login_VisibleChanged(object sender, EventArgs e)
        {
            panel1.Visible=true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            uC_CreateAccount1.Visible = true;
            BringToFront();
        }

        private void UC_Login_Load(object sender, EventArgs e)
        {
            uC_CreateAccount1.Visible = false;
        }
    }
}
