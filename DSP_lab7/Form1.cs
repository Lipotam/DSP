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

        private HopfieldRecognizer recognizer;

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
                draws[(e.Y / elementHeight) * width + (e.X / elementWidth)] = 1;
            }
            else
            {
                draws[(e.Y / elementHeight) * width + (e.X / elementWidth)] = -1;
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
                    int coordinateX = (i % width) * elementWidth;
                    int coordinateY = (i / width) * elementHeight;
                    g.FillRectangle(Brushes.Black, coordinateX, coordinateY, elementWidth, elementHeight);
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
                    if (image.GetPixel(i, j).R == 0)
                    {
                        draws[j * width + i] = 1;
                    }
                    else
                    {
                        draws[j * width + i] = -1;
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
                            if (image.Height > 100 || image.Width > 100)
                            {
                                throw new DataException("Image too big");
                            }
                            if (size == 0)
                            {
                                size = image.Width * image.Height;
                                height = image.Height;
                                width = image.Width;
                                draws = new int[size];
                                elementHeight = panel1.Height / height;
                                elementWidth = panel1.Width / width;
                                panel1.Width = elementWidth * width;
                                panel1.Height = elementHeight * height;
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (recognizer == null)
            {
                recognizer = new HopfieldRecognizer(height, width);
            }
            if (size == 0)
            {
                MessageBox.Show("No image to teach ");
                return;
            }

            if (recognizer.TeachWithTheImage(draws))
            {
                MessageBox.Show("Teaching error");
            }
            else
            {
                MessageBox.Show("Success");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.recognizer == null)
            {
                MessageBox.Show("Error: no recognizer implemented");
                return;
            }
            draws = recognizer.Recognize(draws);
            MessageBox.Show("Success");
            panel1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size; i++)
            {
                draws[i] = -1;
            }
            panel1.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size; i++)
            {
                draws[i] = -1*draws[i];
            }
            panel1.Refresh();
        }
    }
}
