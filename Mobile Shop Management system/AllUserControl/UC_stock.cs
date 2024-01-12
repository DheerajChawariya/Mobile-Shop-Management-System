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
    public partial class UC_stock : UserControl
    {
        Function fn = new Function();
        string query;
        public UC_stock()
        {
            InitializeComponent();
        }

        private void label20_Enter(object sender, EventArgs e)
        {

        }

        private void UC_stock_Enter(object sender, EventArgs e)
        {
            query = "Select * from Mobile_Shop";
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
            query = "select * from Mobile_Shop where mid = " + bid + "";
            DataSet ds = fn.GetData(query);
            
            Companylabel.Text = ds.Tables[0].Rows[0][1].ToString();
            Modellabel.Text = ds.Tables[0].Rows[0][2].ToString();
            ramlabel.Text = ds.Tables[0].Rows[0][3].ToString();
            internallabel.Text = ds.Tables[0].Rows[0][4].ToString();
            expandablelabel.Text = ds.Tables[0].Rows[0][5].ToString();
            diaplaylabel.Text = ds.Tables[0].Rows[0][6].ToString();
            rearlabel.Text = ds.Tables[0].Rows[0][7].ToString();
            frontlabel.Text = ds.Tables[0].Rows[0][8].ToString();
            fingerprintlabel.Text = ds.Tables[0].Rows[0][9].ToString();
            simlabel.Text = ds.Tables[0].Rows[0][10].ToString();
            networklabel.Text = ds.Tables[0].Rows[0][11].ToString();
            pricelabel.Text = ds.Tables[0].Rows[0][12].ToString();
            Stocklabel.Text = ds.Tables[0].Rows[0][13].ToString();
        }

        private void UC_stock_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
