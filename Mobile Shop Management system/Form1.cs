using Mobile_Shop_Management_system.AllUserControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobile_Shop_Management_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            uC_AddNewPhone1.Visible = false;
            uC_Customers1.Visible = false;
            uC_stock1.Visible = false;
            uC_CustomerRecords1.Visible = false;
            enableDisable(false,false,false);
            uC_PurchaseItems1.Visible = false;
            uC_DeletePhoneRecord1.Visible = false;
            uC_Sale1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uC_AddNewPhone1.Visible = true;
            uC_AddNewPhone1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            uC_Customers1.Visible=true;
            uC_Customers1.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            uC_stock1.Visible = true;
            uC_stock1.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            uC_CustomerRecords1.Visible=true;
            uC_CustomerRecords1.BringToFront();
        }
        public void enableDisable(Boolean txtbox, Boolean btn1, Boolean btn2)
        {
            textpassword.Visible = txtbox;
            btnverify.Visible = btn1;
            btncancel.Visible = btn2;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Enabled = false;
            enableDisable(true,true,true);
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            panel2.Enabled = true;
            enableDisable(false, false, false);
        }

        private void btnverify_Click(object sender, EventArgs e)
        {
            if(textpassword.Text=="Dheeraj")
            {
                panel2.Enabled = true;
                uC_DeletePhoneRecord1.Visible = true;
                uC_DeletePhoneRecord1.BringToFront();
                enableDisable(false, false, false); 
                textpassword.Clear();
            }
            else
            {
                MessageBox.Show("Wrong Password");
                textpassword.Clear();
            }
        }

        private void textpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            uC_PurchaseItems1.Visible = true;
            uC_PurchaseItems1.BringToFront();
        }

        private void uC_PurchaseItems1_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            uC_Sale1.Visible = true;
            uC_Sale1.BringToFront();
        }

        private void uC_Login1_Load(object sender, EventArgs e)
        {

        }

        private void uC_Login1_VisibleChanged(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }
    }
}
