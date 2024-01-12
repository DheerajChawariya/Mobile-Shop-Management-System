using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobile_Shop_Management_system.AllUserControl
{
    public partial class UC_PurchaseItems : UserControl
    {
        Function fn = new Function();
        string query;
        string quantity;
        // line number 93 is not executed
        // line number 183 is not executed
        public UC_PurchaseItems()
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //converting input data name into variable 
            string name = textBox1.Text;
            string gender = comboBox1.Text;
            string contact = textBox2.Text;
            string address = textBox4.Text;
            string email = textBox3.Text;
            String IMEI = textBox5.Text;
            string apple_model = comboBox2.Text;
            string samsung_model = comboBox3.Text;
            string vivo_model = comboBox4.Text;
            string realme_model = comboBox5.Text;
            string apple_quantity = textBox6.Text;
            string samsung_quantity = textBox7.Text;
            string vivo_quantity = textBox8.Text;
            string realme_quantity = textBox9.Text;

            //codding of checkbox1
            if (checkBox1.Checked)
            {
               //If all the text boxes are fill the code enter into if case
                if (name != "" && gender != "" && contact != "" && address != "" && email != "" && IMEI != "" && apple_model != "" && apple_quantity != "")
                {
                    string company = checkBox1.Text;
                    string model = comboBox2.Text;
                    string purchase_quentity = textBox6.Text;

                    string query1 = "select stock from Mobile_Shop where mname = '" + model + "'";
                    SqlConnection conn = new SqlConnection();
                    
                    //creating connection of database
                    conn.ConnectionString = "data source = DESKTOP-5H0SJOM\\SQLEXPRESS; database = Mobile_Shop_Management_System; integrated security = True";

                    string quantity = "";
                    // Use a separate SqlCommand and SqlDataReader for reading the stock
                    using (SqlCommand cmd1 = new SqlCommand(query1, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                quantity = reader.GetString(0);
                                //int quantity1 = Convert.ToInt32(quantity);
                            }
                        }
                    }
                    //Converting variable data types into int
                    if (int.TryParse(quantity, out int stockQuantity) && int.TryParse(apple_quantity, out int purchaseQuantity))
                    {
                        //converting data into int and substract it by (database stock into purchase quantity)
                        try
                        {
                            //Code does not entered in this line
                            if (int.Parse(quantity) - int.Parse(apple_quantity) >= 0)
                            {
                                // Create a new SqlCommand for the insert and update operations
                                using (SqlCommand insertCmd = new SqlCommand("insert into customerquantity (cname,gender,contact,email,caddress,imei,company,model,purchase_amount)values('" + name + "','" + gender + "','" + contact + "','" + email + "','" + address + "','" + IMEI + "','" + company + "','" + model + "','" + purchase_quentity + "')", conn))
                                {
                                    int rowsAffected = insertCmd.ExecuteNonQuery();
                                    textBox1.Clear();
                                    textBox2.Clear();
                                    textBox3.Clear();
                                    textBox4.Clear();
                                    textBox5.Clear();
                                    textBox6.Clear();
                                    textBox7.Clear();
                                    textBox8.Clear();
                                    textBox9.Clear();

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
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Not enough stock");
                    }
                }


            }
            else
            {
                MessageBox.Show("Fill all the boxes");
            }

            //codding of checkbox2

            if (checkBox2.Checked)
            {
                //If all the text boxes are fill the code enter into if case
                if (name != "" && gender != "" && contact != "" && address != "" && email != "" && IMEI != "" && samsung_model != "" && samsung_quantity != "")
                {
                    string company = checkBox2.Text;
                    string model = comboBox3.Text;
                    string purchase_quentity = textBox7.Text;

                    string query1 = "select stock from Mobile_Shop where mname = '" + model + "'";
                    SqlConnection conn = new SqlConnection();

                    //creating connection of database
                    conn.ConnectionString = "data source = DESKTOP-5H0SJOM\\SQLEXPRESS; database = Mobile_Shop_Management_System; integrated security = True";

                    string quantity = "";
                    // Use a separate SqlCommand and SqlDataReader for reading the stock
                    using (SqlCommand cmd1 = new SqlCommand(query1, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                quantity = reader.GetString(0);
                                //int quantity1 = Convert.ToInt32(quantity);
                            }
                        }
                    }
                    //Converting variable data types into int
                    if (int.TryParse(quantity, out int stockQuantity) && int.TryParse(samsung_quantity, out int purchaseQuantity))
                    {
                        //converting data into int and substract it by (database stock into purchase quantity)
                        try
                        {
                            //Code does not entered in this line
                            if (int.Parse(quantity) - int.Parse(samsung_quantity) >= 0)
                            {
                                // Create a new SqlCommand for the insert and update operations
                                using (SqlCommand insertCmd = new SqlCommand("insert into customerquantity (cname,gender,contact,email,caddress,imei,company,model,purchase_amount)values('" + name + "','" + gender + "','" + contact + "','" + email + "','" + address + "','" + IMEI + "','" + company + "','" + model + "','" + purchase_quentity + "')", conn))
                                {
                                    int rowsAffected = insertCmd.ExecuteNonQuery();
                                    textBox1.Clear();
                                    textBox2.Clear();
                                    textBox3.Clear();
                                    textBox4.Clear();
                                    textBox5.Clear();
                                    textBox6.Clear();
                                    textBox7.Clear();
                                    textBox8.Clear();
                                    textBox9.Clear();

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
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Not enough stock");
                    }
                }

            }
            else
            {
                MessageBox.Show("Fill all the boxes");
            }

            //Codding of Checkbox 3
            if (checkBox3.Checked)
            {
                //If all the text boxes are fill the code enter into if case
                if (name != "" && gender != "" && contact != "" && address != "" && email != "" && IMEI != "" && vivo_model != "" && vivo_quantity != "")
                {
                    string company = checkBox3.Text;
                    string model = comboBox4.Text;
                    string purchase_quentity = textBox8.Text;

                    string query1 = "select stock from Mobile_Shop where mname = '" + model + "'";
                    SqlConnection conn = new SqlConnection();

                    //creating connection of database
                    conn.ConnectionString = "data source = DESKTOP-5H0SJOM\\SQLEXPRESS; database = Mobile_Shop_Management_System; integrated security = True";

                    string quantity = "";
                    // Use a separate SqlCommand and SqlDataReader for reading the stock
                    using (SqlCommand cmd1 = new SqlCommand(query1, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                quantity = reader.GetString(0);
                                //int quantity1 = Convert.ToInt32(quantity);
                            }
                        }
                    }
                    //Converting variable data types into int
                    if (int.TryParse(quantity, out int stockQuantity) && int.TryParse(vivo_quantity, out int purchaseQuantity))
                    {
                        //converting data into int and substract it by (database stock into purchase quantity)
                        try
                        {
                            //Code does not entered in this line
                            if (int.Parse(quantity) - int.Parse(vivo_quantity) >= 0)
                            {
                                // Create a new SqlCommand for the insert and update operations
                                using (SqlCommand insertCmd = new SqlCommand("insert into customerquantity (cname,gender,contact,email,caddress,imei,company,model,purchase_amount)values('" + name + "','" + gender + "','" + contact + "','" + email + "','" + address + "','" + IMEI + "','" + company + "','" + model + "','" + purchase_quentity + "')", conn))
                                {
                                    int rowsAffected = insertCmd.ExecuteNonQuery();
                                    textBox1.Clear();
                                    textBox2.Clear();
                                    textBox3.Clear();
                                    textBox4.Clear();
                                    textBox5.Clear();
                                    textBox6.Clear();
                                    textBox7.Clear();
                                    textBox8.Clear();
                                    textBox9.Clear();

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
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Not enough stock");
                    }
                }

            }
            else
            {
                MessageBox.Show("Fill all the boxes");
            }

            // Codding of checkBox4
            if (checkBox4.Checked)
            {
                //If all the text boxes are fill the code enter into if case
                if (name != "" && gender != "" && contact != "" && address != "" && email != "" && IMEI != "" && realme_model != "" && realme_quantity != "")
                {
                    string company = checkBox4.Text;
                    string model = comboBox5.Text;
                    string purchase_quentity = textBox9.Text;

                    string query1 = "select stock from Mobile_Shop where mname = '" + model + "'";
                    SqlConnection conn = new SqlConnection();

                    //creating connection of database
                    conn.ConnectionString = "data source = DESKTOP-5H0SJOM\\SQLEXPRESS; database = Mobile_Shop_Management_System; integrated security = True";

                    string quantity = "";
                    // Use a separate SqlCommand and SqlDataReader for reading the stock
                    using (SqlCommand cmd1 = new SqlCommand(query1, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                quantity = reader.GetString(0);
                                //int quantity1 = Convert.ToInt32(quantity);
                            }
                        }
                    }
                    //Converting variable data types into int
                    if (int.TryParse(quantity, out int stockQuantity) && int.TryParse(realme_quantity, out int purchaseQuantity))
                    {
                        //converting data into int and substract it by (database stock can substract purchase quantity)
                        try
                        {
                            //Code does not entered in this line
                            if (int.Parse(quantity) - int.Parse(realme_quantity) >= 0)
                            {
                                // Create a new SqlCommand for the insert and update operations
                                using (SqlCommand insertCmd = new SqlCommand("insert into customerquantity (cname,gender,contact,email,caddress,imei,company,model,purchase_amount)values('" + name + "','" + gender + "','" + contact + "','" + email + "','" + address + "','" + IMEI + "','" + company + "','" + model + "','" + purchase_quentity + "')", conn))
                                {
                                    int rowsAffected = insertCmd.ExecuteNonQuery();
                                    textBox1.Clear();
                                    textBox2.Clear();
                                    textBox3.Clear();
                                    textBox4.Clear();
                                    textBox5.Clear();
                                    textBox6.Clear();
                                    textBox7.Clear();
                                    textBox8.Clear();
                                    textBox9.Clear();

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
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Not enough stock");
                    }
                }

            }
            else
            {
                MessageBox.Show("Fill all the boxes");
            }
            //codding of price label if multible check boxes are select then what price should be shown
            //codding of apple phone 
            if(checkBox1.Checked==true)
            {
                //Query to get data from mobile shop table
                query = "select * from Mobile_Shop where mname = '" + comboBox2.Text + "'";
                DataSet ds = fn.GetData(query);

                //creating string to store fetch data 
                string price = ds.Tables[0].Rows[0][12].ToString();

                //show table data
                label17.Text = textBox6.Text;
                Pricelabel.Text = Convert.ToString(int.Parse(price) * int.Parse(textBox6.Text));
            }

            //if check apple and samsung both are purchase 
             if(checkBox1.Checked==true && checkBox2.Checked==true)
            {
                //Query to get data from mobile shop table
                query = "select * from Mobile_Shop where mname = '" + comboBox2.Text + "'";
                DataSet ds = fn.GetData(query);

                //Query to get second check box data
                string query1 = "select * from Mobile_Shop where mname = '" + comboBox3.Text + "'";
                DataSet ds1 = fn.GetData(query1);

                //creating string to store fetch data 
                string price = ds.Tables[0].Rows[0][12].ToString();
                string price2 = ds1.Tables[0].Rows[0][12].ToString();

                //show table data
                label17.Text = Convert.ToString(int.Parse(textBox6.Text)+int.Parse(textBox7.Text));

                //calculate check box 1 and check box 2 price
                Pricelabel.Text = Convert.ToString
                                          (int.Parse(price2) + int.Parse(price) * 
                                          int.Parse(textBox6.Text) + int.Parse(textBox7.Text));
            }

            //if check apple, vivo & samsung are purchase
            if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true)
            {
                //Query to get apple check box data
                query = "select * from Mobile_Shop where mname = '" + comboBox2.Text + "'";
                DataSet ds = fn.GetData(query);

                //Query to get samsung check box data
                string query1 = "select * from Mobile_Shop where mname = '" + comboBox3.Text + "'";
                DataSet ds1 = fn.GetData(query1);

                //query to get vivo check box data
                string query2 = "select * from Mobile_Shop where mname = '" + comboBox4.Text + "'";
                DataSet ds2 = fn.GetData(query2);

                //creating string to store fetch data 
                string price = ds.Tables[0].Rows[0][12].ToString();
                string price2 = ds1.Tables[0].Rows[0][12].ToString();
                string price3 = ds2.Tables[0].Rows[0][12].ToString();

                //show table data
                label17.Text = Convert.ToString(int.Parse(textBox6.Text) + 
                                                int.Parse(textBox7.Text) +
                                                int.Parse(textBox8.Text));

                //calculate check box 1, check box 2 and check box 3 price
                Pricelabel.Text = Convert.ToString
                                          (int.Parse(price2) + int.Parse(price) + int.Parse(price3) *
                                          int.Parse(textBox6.Text) + int.Parse(textBox7.Text) + int.Parse(textBox8.Text));
            }

            //if check box1,2,3,and 4 are select
            if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true && checkBox4.Checked==true)
            {
                //Query to get apple check box data
                query = "select * from Mobile_Shop where mname = '" + comboBox2.Text + "'";
                DataSet ds = fn.GetData(query);

                //Query to get samsung check box data
                string query1 = "select * from Mobile_Shop where mname = '" + comboBox3.Text + "'";
                DataSet ds1 = fn.GetData(query1);

                //query to get vivo check box data
                string query2 = "select * from Mobile_Shop where mname = '" + comboBox4.Text + "'";
                DataSet ds2 = fn.GetData(query2);

                //query to get realme check box data
                string query3 = "select * from Mobile_Shop where mname = '" + comboBox5.Text + "'";
                DataSet ds3 = fn.GetData(query3);

                //creating string to store fetch data 
                string price = ds.Tables[0].Rows[0][12].ToString();
                string price2 = ds1.Tables[0].Rows[0][12].ToString();
                string price3 = ds2.Tables[0].Rows[0][12].ToString();
                string price4 = ds3.Tables[0].Rows[0][12].ToString();

                //show table data
                label17.Text = Convert.ToString(int.Parse(textBox6.Text) +
                                                int.Parse(textBox7.Text) +
                                                int.Parse(textBox8.Text) +
                                                int.Parse(textBox9.Text));

                //calculate check box 1, check box 2, check box 3 and check box 4 price
                Pricelabel.Text = Convert.ToString
                                          ((int.Parse(price2) + int.Parse(price) + int.Parse(price3) + int.Parse(price4)) *
                                          (int.Parse(textBox6.Text) + int.Parse(textBox7.Text) + int.Parse(textBox8.Text) +
                                          int.Parse(textBox9.Text)));
            }

            //if apple and vivo is purchase
            if(checkBox1.Checked==true && checkBox3.Checked == true)
            {
                //Query to get apple check box data
                query = "select * from Mobile_Shop where mname = '" + comboBox2.Text + "'";
                DataSet ds = fn.GetData(query);

                //query to get vivo check box data
                string query2 = "select * from Mobile_Shop where mname = '" + comboBox4.Text + "'";
                DataSet ds2 = fn.GetData(query2);

                //creating string to store fetch data 
                string price = ds.Tables[0].Rows[0][12].ToString();
                string price3 = ds2.Tables[0].Rows[0][12].ToString();

                //show table data
                label17.Text = Convert.ToString(int.Parse(textBox6.Text) +
                                                int.Parse(textBox8.Text));

                //calculate check box 1, and check box 3 price
                Pricelabel.Text = Convert.ToString
                                          (( int.Parse(price) + int.Parse(price3)) *
                                          (int.Parse(textBox6.Text) + int.Parse(textBox8.Text)));
            }

            // if apple and realme is purchase
            if (checkBox1.Checked == true && checkBox4.Checked == true)
            {
                //Query to get apple check box data
                query = "select * from Mobile_Shop where mname = '" + comboBox2.Text + "'";
                DataSet ds = fn.GetData(query);

                //query to get vivo check box data
                string query2 = "select * from Mobile_Shop where mname = '" + comboBox5.Text + "'";
                DataSet ds2 = fn.GetData(query2);

                //creating string to store fetch data 
                string price = ds.Tables[0].Rows[0][12].ToString();
                string price3 = ds2.Tables[0].Rows[0][12].ToString();

                //show table data
                label17.Text = Convert.ToString(int.Parse(textBox6.Text) +
                                                int.Parse(textBox9.Text));

                //calculate check box 1, and check box 3 price
                Pricelabel.Text = Convert.ToString
                                          ((int.Parse(price) + int.Parse(price3)) *
                                          (int.Parse(textBox6.Text) + int.Parse(textBox9.Text)));
            }
            // if samsung and vivo phone is purchase
            if (checkBox2.Checked == true && checkBox3.Checked == true)
            {
                //Query to get samsung check box data
                query = "select * from Mobile_Shop where mname = '" + comboBox3.Text + "'";
                DataSet ds = fn.GetData(query);

                //query to get vivo check box data
                string query2 = "select * from Mobile_Shop where mname = '" + comboBox4.Text + "'";
                DataSet ds2 = fn.GetData(query2);

                //creating string to store fetch data 
                string price = ds.Tables[0].Rows[0][12].ToString();
                string price3 = ds2.Tables[0].Rows[0][12].ToString();

                //show table data
                label17.Text = Convert.ToString(int.Parse(textBox7.Text) +
                                                int.Parse(textBox8.Text));

                //calculate check box 2, and check box 3 price
                Pricelabel.Text = Convert.ToString
                                          ((int.Parse(price) + int.Parse(price3)) *
                                          (int.Parse(textBox7.Text) + int.Parse(textBox8.Text)));
            }
            // if samsung and realme phone is purchase
            if (checkBox2.Checked == true && checkBox4.Checked == true)
            {
                //Query to get samsung check box data
                query = "select * from Mobile_Shop where mname = '" + comboBox3.Text + "'";
                DataSet ds = fn.GetData(query);

                //query to get vivo check box data
                string query2 = "select * from Mobile_Shop where mname = '" + comboBox5.Text + "'";
                DataSet ds2 = fn.GetData(query2);

                //creating string to store fetch data 
                string price = ds.Tables[0].Rows[0][12].ToString();
                string price3 = ds2.Tables[0].Rows[0][12].ToString();

                //show table data
                label17.Text = Convert.ToString(int.Parse(textBox7.Text) +
                                                int.Parse(textBox9.Text));

                //calculate check box 2, and check box 3 price
                Pricelabel.Text = Convert.ToString
                                          ((int.Parse(price) + int.Parse(price3)) *
                                          (int.Parse(textBox7.Text) + int.Parse(textBox9.Text)));
            }
            //vivo and realme purchase
            if (checkBox3.Checked == true && checkBox4.Checked == true)
            {
                //Query to get samsung check box data
                query = "select * from Mobile_Shop where mname = '" + comboBox4.Text + "'";
                DataSet ds = fn.GetData(query);

                //query to get vivo check box data
                string query2 = "select * from Mobile_Shop where mname = '" + comboBox5.Text + "'";
                DataSet ds2 = fn.GetData(query2);

                //creating string to store fetch data 
                string price = ds.Tables[0].Rows[0][12].ToString();
                string price3 = ds2.Tables[0].Rows[0][12].ToString();

                //show table data
                label17.Text = Convert.ToString(int.Parse(textBox8.Text) +
                                                int.Parse(textBox9.Text));

                //calculate check box 2, and check box 3 price
                Pricelabel.Text = Convert.ToString
                                          ((int.Parse(price) + int.Parse(price3)) *
                                          (int.Parse(textBox8.Text) + int.Parse(textBox9.Text)));
            }
            if(checkBox2.Checked==true && checkBox3.Checked==true && checkBox4.Checked==true)
            {
                //Query to get samsung check box data
                string query1 = "select * from Mobile_Shop where mname = '" + comboBox3.Text + "'";
                DataSet ds1 = fn.GetData(query1);

                //query to get vivo check box data
                string query2 = "select * from Mobile_Shop where mname = '" + comboBox4.Text + "'";
                DataSet ds2 = fn.GetData(query2);

                //query to get realme check box data
                string query3 = "select * from Mobile_Shop where mname = '" + comboBox5.Text + "'";
                DataSet ds3 = fn.GetData(query3);

                //creating string to store fetch data 
                string price2 = ds1.Tables[0].Rows[0][12].ToString();
                string price3 = ds2.Tables[0].Rows[0][12].ToString();
                string price4 = ds3.Tables[0].Rows[0][12].ToString();

                //show table data
                label17.Text = Convert.ToString(int.Parse(textBox7.Text) +
                                                int.Parse(textBox8.Text) +
                                                int.Parse(textBox9.Text));

                //calculate check box 2, check box 3, check box 4 price
                Pricelabel.Text = Convert.ToString
                                          ((int.Parse(price2) + int.Parse(price3) + int.Parse(price4)) *
                                          (int.Parse(textBox7.Text) + int.Parse(textBox8.Text) +
                                          int.Parse(textBox9.Text)));
            }

        }

        private void UC_PurchaseItems_Enter(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            query = "Select mname from Mobile_Shop where cname = 'apple' ";
            setcomboBox(query, comboBox2);

            comboBox3.Items.Clear();
            query = "Select mname from Mobile_Shop where cname = 'Samsung' ";
            setcomboBox(query, comboBox3);

            comboBox4.Items.Clear();
            query = "Select mname from Mobile_Shop where cname = 'Vivo' ";
            setcomboBox(query, comboBox4);

            comboBox5.Items.Clear();
            query = "Select mname from Mobile_Shop where cname = 'Realme' ";
            setcomboBox(query, comboBox5);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select * from Mobile_Shop where mname = '" + comboBox2.Text + "'";
            DataSet ds = fn.GetData(query);

            string price = ds.Tables[0].Rows[0][12].ToString();
            label17.Text = textBox6.Text;
            Pricelabel.Text = Convert.ToString(int.Parse(price) * int.Parse(textBox6.Text));
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select * from Mobile_Shop where mname = '" + comboBox3.Text + "'";
            DataSet ds = fn.GetData(query);

            string price = ds.Tables[0].Rows[0][12].ToString();
            label17.Text = textBox7.Text;
            Pricelabel.Text = Convert.ToString(int.Parse(price) * int.Parse(textBox7.Text));
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select * from Mobile_Shop where mname = '" + comboBox4.Text + "'";
            DataSet ds = fn.GetData(query);

            string price = ds.Tables[0].Rows[0][12].ToString();
            label17.Text = textBox8.Text;
            Pricelabel.Text = Convert.ToString(int.Parse(price) * int.Parse(textBox8.Text));
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            query = "select * from Mobile_Shop where mname = '" + comboBox5.Text + "'";
            DataSet ds = fn.GetData(query);

            string price = ds.Tables[0].Rows[0][12].ToString();
            label17.Text = textBox9.Text;
            Pricelabel.Text = Convert.ToString(int.Parse(price) * int.Parse(textBox9.Text));
        }
       

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            uC_Bill1.Visible = true;
            uC_Bill1.BringToFront();
        }

        private void UC_PurchaseItems_Load(object sender, EventArgs e)
        {
             uC_Bill1.Visible = false;
        }

        private void uC_Bill1_Load(object sender, EventArgs e)
        {

        }
    }
}
