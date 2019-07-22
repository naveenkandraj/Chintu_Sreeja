using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Chintu_Sreeja
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;

        }
        OpenFileDialog ofd = new OpenFileDialog();
        Bitmap N_img;
        private void button1_Click(object sender, EventArgs e)
        {
            //ofd.ShowDialog();
            //ofd.Filter = "PNG|*.png|*.jpeg|*.jpg";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
               
                //Process.Start("start " + textBox1.Text);
                //Process.Start("ping 127.0.0.1 -t");
            }
        }
        public String file_name
        {
            get { return ofd.FileName; }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        PictureBox pic = new PictureBox();

        private void button3_Click(object sender, EventArgs e)
        {
            //Open
            //pic.Image = (Image)new Bitmap(ofd.FileName);
            N_img = new Bitmap(ofd.FileName);
            pictureBox1.Image = N_img;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Rotate
            N_img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Image = N_img;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        Graphics g;

        private void button5_Click(object sender, EventArgs e)
        {
            //Crop

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //>
            N_img.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pictureBox1.Image = N_img;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            g.RotateTransform(1.0f);
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //<
            N_img.RotateFlip(RotateFlipType.RotateNoneFlipY);
            pictureBox1.Image = N_img;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(" your file is being uploading..!");
            /*Form form2 = new Form()
            {
                TopMost = true,
                
            };
            form2.Show();*/
            Form2 frm2 = new Form2();
            frm2.Show();

        }

        
    }
}
