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
    public partial class UC_DeletePhoneRecord : UserControl
    {
        Function fn = new Function();
        string query;
        public UC_DeletePhoneRecord()
        {
            InitializeComponent();
        }

        private void UC_DeletePhoneRecord_Load(object sender, EventArgs e)
        {

        }

        private void UC_DeletePhoneRecord_Enter(object sender, EventArgs e)
        {
            query = "Select * from Mobile_Shop";
            DataSet ds = fn.GetData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            query = "Select * from Mobile_Shop where cname like '"+textBox1.Text+ "%' or mname like '"+textBox1.Text+"%'";
            DataSet ds = fn.GetData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }
        int bid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            query = "delete from Mobile_Shop where mid=" + bid + "";
            if (MessageBox.Show("Deleting records of " + bid + "", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                fn.setdata(query);
            }
            else
            {
                MessageBox.Show("You cancel the deleting");
            }
        }
    }
}
