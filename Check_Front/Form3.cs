using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Check_Front
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            TopMost = true;
        }
        int cropX;
        int cropY;
        int cropWidth;

        int cropHeight;
        int oCropX;
        int oCropY;
        public Pen cropPen;

        public DashStyle cropDashStyle = DashStyle.DashDot;
        public bool Makeselection = false;
        private void button1_Click(object sender, EventArgs e)
        {
            Makeselection = true;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Cursor = Cursors.Default;

            try
            {
                if (cropWidth < 1)
                {
                    return;
                }
                Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
                //First we define a rectangle with the help of already calculated points
                Bitmap OriginalImage = new Bitmap(pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);
                //Original image
                Bitmap N_img = new Bitmap(cropWidth, cropHeight);
                // for cropinf image
                Graphics g = Graphics.FromImage(N_img);
                // create graphics
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                //set image attributes
                g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);

                pictureBox1.Image = N_img;
                pictureBox1.Width = N_img.Width;
                pictureBox1.Height = N_img.Height;
                
                button2.Enabled = false;
            }
            catch (Exception ex)
            {
            }
        }


        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
          /*  if (TabControl1.SelectedIndex == 4)
            {
                Point TextStartLocation = e.Location;
                if (CreateText)
                {
                    Cursor = Cursors.IBeam;
                }
            }
            else
            {
                Cursor = Cursors.Default;*/
                if (Makeselection)
                {

                    try
                    {
                        if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            Cursor = Cursors.Cross;
                            cropX = e.X;
                            cropY = e.Y;

                            cropPen = new Pen(Color.Black, 1);
                            cropPen.DashStyle = DashStyle.DashDotDot;


                        }
                        pictureBox1.Refresh();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            


        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (Makeselection)
            {
                Cursor = Cursors.Default;
            }

        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
           /* if (TabControl1.SelectedIndex == 4)
            {
                Point TextStartLocation = e.Location;
                if (CreateText)
                {
                    Cursor = Cursors.IBeam;
                }
            }
            else
            {
                Cursor = Cursors.Default;*/
                if (Makeselection)
                {

                    try
                    {
                        if (pictureBox1.Image == null)
                            return;


                        if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            pictureBox1.Refresh();
                            cropWidth = e.X - cropX;
                            cropHeight = e.Y - cropY;
                            pictureBox1.CreateGraphics().DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight);
                        }



                    }
                    catch (Exception ex)
                    {
                        //if (ex.Number == 5)
                        //    return;
                    }
                }
           

        }

        
    }
}
}
