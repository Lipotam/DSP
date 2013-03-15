using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DSPbase;

namespace DSP_lab7
{
    public partial class Form1 : Form
    {
        private int size = 0;
        private int height;
        private int width;

        private int elementWidth, elementHeight;

        private int[] draws;
        private Bitmap image;

        public Form1()
        {
            InitializeComponent();
        }


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                draws[(e.Y / 2) * height + (e.X / 2)] = 1;
            }
            else
            {
                draws[(e.Y / 2) * height + (e.X / 2)] = -1;
            }
            panel1.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            for (int i = 0; i < size; i++)
            {
                if (draws[i] == 1)
                {
                    int vert = (i  % height) * 2;
                    int gor = i / width * 2;
                    g.FillRectangle(Brushes.Black, vert, gor,2, 2);
                }
            }
        }

        private void DrawTheImage()
        {
            ImageRecognizer imageRecongizer = new ImageRecognizer(image, 128, 0);
            imageRecongizer.TransformToBlackAndWhite();
            image = imageRecongizer.OutputImage;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (image.GetPixel(i, j).R == 255)
                    {
                        draws[j * height + i] = 1;
                    }
                    else
                    {
                        draws[j * height + i] = -1;
                    }
                }
            }

            panel1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp,*.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Stream myStream;
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            image = new Bitmap(openFileDialog1.FileName);
                            if (size == 0)
                            {
                                size = image.Width * image.Height;
                                height = image.Height;
                                width = image.Width;
                                draws = new int[size];
                                panel1.Width = width * 2;
                                panel1.Height = height * 2;
                            }
                            else
                            {
                                if (height != image.Height || width != image.Width)
                                {
                                    throw new DataException("Image doesn't match the parameters");
                                }
                            }
                            DrawTheImage();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
