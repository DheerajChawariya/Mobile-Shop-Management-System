using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mobile_Shop_Management_system.AllUserControl
{
    public partial class UC_Bill : UserControl
    {
        Function fn = new Function();
        string query;
        public UC_Bill()
        {
            InitializeComponent();
        }

        public void setcombobox(string query, System.Windows.Forms.ComboBox cb)
        {
            using (SqlDataReader dr = fn.GetforCombo(query))
            {
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        cb.Items.Add(dr.GetString(i));
                    }
                }
            }
        }
        private void UC_Bill_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "Select * from customerquantity where cname = '" + comboBox1.Text+"'";
            DataSet ds = fn.GetData(query);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                namelabel.Text = ds.Tables[0].Rows[0]["cname"].ToString();
                genderlabel.Text = ds.Tables[0].Rows[0]["gender"].ToString();
                Contactlabel.Text = ds.Tables[0].Rows[0]["contact"].ToString();
                emaillabel.Text = ds.Tables[0].Rows[0]["email"].ToString();
                addresslabel.Text = ds.Tables[0].Rows[0]["caddress"].ToString();
                IMEIlabel.Text = ds.Tables[0].Rows[0]["imei"].ToString();
                Comapanylabel.Text = ds.Tables[0].Rows[0]["company"].ToString();
                modellabel.Text= ds.Tables[0].Rows[0]["model"].ToString();

            }
            else
            {
                namelabel.Text = "No data found for the specified customer name.";
            }
        }

        private void modellabel_Click(object sender, EventArgs e)
        {

        }

        private void modellabel_Enter(object sender, EventArgs e)
        {

        }

        private void UC_Bill_Enter(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            query = "Select cname from customerquantity ";
            setcombobox(query, comboBox1);

            comboBox2.Items.Clear();
            query = "Select distinct cname from Mobile_Shop ";
            setcombobox(query, comboBox2);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select * from Mobile_Shop where mname = '" + comboBox2.Text + "'";
            DataSet ds = fn.GetData(query);
            if (ds.Tables[0].Rows.Count > 0)
            { 
            ramlabel.Text = ds.Tables[0].Rows[0][3].ToString();
            internallabel.Text = ds.Tables[0].Rows[0][4].ToString();
            externallabel.Text = ds.Tables[0].Rows[0][5].ToString();
            rearcameralabel.Text = ds.Tables[0].Rows[0][7].ToString();
            frontcameralabel.Text = ds.Tables[0].Rows[0][8].ToString();
            fingerprintlabel.Text = ds.Tables[0].Rows[0][9].ToString();
            string price = ds.Tables[0].Rows[0][12].ToString();
                //label17.Text = textBox6.Text;
                //Pricelabel.Text = Convert.ToString(int.Parse(price) * int.Parse(textBox6.Text));
            }
            else
            {
                MessageBox.Show("No matching record found for the selected mobile name.");
            }
        }
    }
}
