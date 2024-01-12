using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Mobile_Shop_Management_system.AllUserControl
{
    public partial class UC_Sale : UserControl
    {
        Function fn = new Function();
        string query;
        string quantity;
        public UC_Sale()
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
                string purchase_quentity = textBox7.Text;

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
            label13.Text = textBox8.Text;
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {

        }

        private void UC_Sale_Enter(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            query = "Select distinct cname from Mobile_Shop";
            setcomboBox(query, comboBox2);
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            string cname = comboBox2.Text;
            query = "Select mname from Mobile_Shop where cname ='" + cname + "'";
            setcomboBox(query, comboBox3);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select price from Mobile_Shop where mname = '" + comboBox3.Text + "'";
            DataSet ds = fn.GetData(query);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Columns.Contains("price"))
                {
                    //textBox6.Text = ds.Tables[0].Rows[0][12].ToString();
                    textBox6.Text = ds.Tables[0].Rows[0]["price"].ToString();
                }
                else
                {
                    // Handle the case where the "price" column is not found
                    MessageBox.Show("The 'price' column was not found in the result set.");
                }
            }
            else
            {
                // Handle the case where no rows were returned by the query
                MessageBox.Show("No data found for the selected mobile phone.");
            }
        }

        private void UC_Sale_Load(object sender, EventArgs e)
        {

        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            try { 
            string price = textBox6.Text;
            string quantity = textBox7.Text;
                if (int.TryParse(price, out int priceValue) && int.TryParse(quantity, out int quantityValue))
                {
                    string amount = Convert.ToString(int.Parse(price) * int.Parse(quantity));
                }

            }
            catch (Exception ex)
            {
                // Handle other exceptions if any
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_Click(object sender, EventArgs e)
        {
            try
            {
                string price = textBox6.Text;
                string quantity = textBox7.Text;
                if (int.TryParse(price, out int priceValue) && int.TryParse(quantity, out int quantityValue))
                {
                    textBox8.Text = Convert.ToString(int.Parse(price) * int.Parse(quantity));
                }
                else
                {
                    MessageBox.Show("Invalid input. Please enter valid numeric values for price and quantity.");
                }
            }
            catch (Exception ex)
            {
                // Handle other exceptions if any
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
