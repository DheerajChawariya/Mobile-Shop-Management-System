using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobile_Shop_Management_system.AllUserControl
{
    public partial class UC_Customers : UserControl
    {
        Function fn = new Function();
        string query;
        string quantity;
        public UC_Customers()
        {
            InitializeComponent();
        }
        public void setcomboBox(string query, ComboBox cb)
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

        private void UC_Customers_Load(object sender, EventArgs e)
        {

        }

        private void UC_Customers_Enter(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            query = "Select distinct cname from Mobile_Shop ";
            setcomboBox(query, comboBox2);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            string cname = comboBox2.Text;
            query = "Select mname from Mobile_Shop where cname ='"+cname+"'";
            setcomboBox(query, comboBox3);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select * from Mobile_Shop where mname = '"+comboBox3.Text+"'";
            DataSet ds = fn.GetData(query);

            ramlabel.Text = ds.Tables[0].Rows[0][3].ToString();
            internallabel.Text = ds.Tables[0].Rows[0][4].ToString();
            expandablelabel.Text = ds.Tables[0].Rows[0][5].ToString();
            rearlabel.Text = ds.Tables[0].Rows[0][7].ToString();
            frontlabel.Text = ds.Tables[0].Rows[0][8].ToString();
            fingerlabel.Text = ds.Tables[0].Rows[0][9].ToString();
            string price = ds.Tables[0].Rows[0][12].ToString();
            label17.Text = textBox6.Text;
            Pricelabel.Text = Convert.ToString(int.Parse(price) * int.Parse(textBox6.Text));

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
            {
                string name = textBox1.Text;
                string gender = comboBox1.Text;
                Int64 contact = Int64.Parse(textBox2.Text);
                string email = textBox3.Text;
                string address = textBox4.Text;
                string imei = textBox5.Text;
                string company = comboBox2.Text;
                string model = comboBox3.Text;
                string purchase_quentity = textBox6.Text;

                string query1 = "select stock from Mobile_Shop where mname = '" + model + "'";
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source = DESKTOP-5H0SJOM\\SQLEXPRESS; database = Mobile_Shop_Management_System; integrated security = True";

                // Use a separate SqlCommand and SqlDataReader for reading the stock
                using (SqlCommand cmd1 = new SqlCommand(query1, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            quantity = reader.GetString(0);
                        }
                    }
                }

                if (int.Parse(quantity) - int.Parse(purchase_quentity) >= 0)
                {
                    // Create a new SqlCommand for the insert and update operations
                    using (SqlCommand insertCmd = new SqlCommand("insert into customerquantity (cname,gender,contact,email,caddress,imei,company,model,purchase_amount)values('" + name + "','" + gender + "','" + contact + "','" + email + "','" + address + "','" + imei + "','" + company + "','" + model + "','" + purchase_quentity + "')", conn))
                    {
                        int rowsAffected = insertCmd.ExecuteNonQuery();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        int remain = int.Parse(quantity) - int.Parse(purchase_quentity);

                        // Use a separate SqlCommand for the update operation
                        using (SqlCommand updateCmd = new SqlCommand("update Mobile_Shop set stock = '" + remain.ToString() + "' where mname = '" + model + "'", conn))
                        {
                            int rows = updateCmd.ExecuteNonQuery();
                            if (rows > 0)
                            {
                                MessageBox.Show("Updated stock");
                            }
                            else
                            {
                                MessageBox.Show("Not Updated stock");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Not enough stock");
                }
            }
            else
            {
                MessageBox.Show("Fill all the fields");
            }
        }
    }
}
