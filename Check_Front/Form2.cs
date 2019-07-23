using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace Check_Front
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // save from upload
            Form1 frm1 = new Form1();
            string cs= @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=demo1;Integrated Security=True";
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            string cmd = "insert into knk values(" + frm1.file_name + ");";
            MessageBox.Show(frm1.file_name);//popup box
            SqlCommand sc = new SqlCommand(cmd, conn);
            //SqlDataAdapter da;
            MessageBox.Show(frm1.file_name);
            int da = sc.ExecuteNonQuery();
            if(da>0)
            {
                 MessageBox.Show("File Uploaded succesfully..!");
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
