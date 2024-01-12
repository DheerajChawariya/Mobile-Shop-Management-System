using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobile_Shop_Management_system.AllUserControl
{
    public partial class UC_AddNewPhone : UserControl
    {
        public UC_AddNewPhone()
        {
            InitializeComponent();
        }
        Function fn = new Function();
        string query;

        private void UC_AddNewPhone_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" &&textBox2.Text != "" && comboBox1.Text!="" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "" && comboBox5.Text != "" && comboBox6.Text != "" && comboBox7.Text != "" && comboBox8.Text != "" && comboBox9.Text != "" && textBox8.Text != "")
            {
                string company = textBox1.Text;
                string model = textBox2.Text;
                string ram = comboBox1.Text;
                string internal_storage = comboBox2.Text;
                string expendable_storage = comboBox3.Text;
                string display = comboBox4.Text;
                string rear_camera = comboBox5.Text;
                string front_camera = comboBox6.Text;
                string fingerprint = comboBox7.Text;
                string sim_type = comboBox8.Text;
                string network = comboBox9.Text;
                Int64 price = Int64.Parse(textBox8.Text);

                query = "insert into Mobile_Shop(cname,mname,ram,internal,expendable,diplay,rear_camera,Front_camera,fingerprint,sim,network,price) values('" + company + "','" + model + "','" + ram + "','" + internal_storage + "','" + expendable_storage + "','" + display + "','" + expendable_storage + "','" + rear_camera + "','" + front_camera + "','" + fingerprint + "','" + sim_type + "','" + network + "'," + price + ")";
                fn.setdata(query);
            }
            else
            {
                MessageBox.Show("Fill all the details");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox8.Clear();
        }

        private void UC_AddNewPhone_Enter(object sender, EventArgs e)
        {

        }
    }
}
