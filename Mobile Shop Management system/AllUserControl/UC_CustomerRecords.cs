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
    public partial class UC_CustomerRecords : UserControl
    {
        Function fn = new Function();
        string query;
        public UC_CustomerRecords()
        {
            InitializeComponent();
        }

        private void UC_CustomerRecords_Enter(object sender, EventArgs e)
        {
            query = "select * from customerquantity";
            DataSet ds = fn.GetData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }
        Boolean flag;
        private void txtsearchbar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtsearchbar.SelectedIndex == 0)
            {
                flag = false;
                labelToSet.Text = "Enter Customer Name";
            }
            else if(txtsearchbar.SelectedIndex == 1)
            {
                flag = true;
                labelToSet.Text = "Enter IMEI";
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if(flag==false)
            {
                query = "select * from customerquantity where cname like '" + txtsearch.Text + "%'";
                DataSet ds = fn.GetData(query);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                query = "select * from customerquantity where imei like '" + txtsearch.Text + "%'";
                DataSet ds = fn.GetData(query);
                dataGridView1.DataSource= ds.Tables[0];
            }
        }

        private void UC_CustomerRecords_Load(object sender, EventArgs e)
        {

        }

        private void txtsearch_Enter(object sender, EventArgs e)
        {

        }
    }
}
