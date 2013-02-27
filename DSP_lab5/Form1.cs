using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using ZedGraph;
using DSPbase;

namespace DSP_lab5
{
    public partial class Form1 : Form
    {
        private ImageRecognizer image;
        public Form1()
        {
            InitializeComponent();
        }

        private byte[] GetBytes(Bitmap input)
        {
            if (input == null)
            {
                return null;
            }
            int bytesCount = input.Width * input.Height * 4;
            BitmapData inputData = input.LockBits(
                new Rectangle(0, 0, input.Width, input.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppRgb);

            byte[] output = new byte[bytesCount];
            System.Runtime.InteropServices.Marshal.Copy(inputData.Scan0, output, 0, bytesCount);
            input.UnlockBits(inputData);
            return output;
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
                            pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            image = new ImageRecognizer((Bitmap)pictureBox1.Image,(byte)separateValue.Value);
            image.TransformToBlackAndWhite();
            pictureBox2.Image = image.OutputImage;
            image.RecognizePixelsToGroups();
            image.PaintFromGroupMap();
            pictureBox3.Image = image.OutputImage;
            DrawHistogram(zedGraphControl2, pictureBox1);
        }
        public PointPairList Histogram(PictureBox pb)
        {
            int width, height;

            width = pb.Image.Width;
            height = pb.Image.Height;

            byte[] inputBytes = GetBytes((Bitmap)pb.Image);
            int[] intencity = new int[256];
            int index;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    byte r = inputBytes[4 * (width * y + x) + 0];
                    byte g = inputBytes[4 * (width * y + x) + 1];
                    byte b = inputBytes[4 * (width * y + x) + 2];

                    index = (int)(0.3 * r + 0.59 * g + 0.11 * b);

                    intencity[index]++;
                }
            }
            PointPairList points = new PointPairList();
            for (int i = 0; i < 256; i++)
            {
                points.Add(i, intencity[i]);
            }
            return points;

        }

        private void DrawHistogram(ZedGraphControl control, PictureBox pictureBox)
        {
            control.GraphPane.CurveList.Clear();
            control.GraphPane.AddCurve("Function", Histogram(pictureBox), Color.Blue, SymbolType.None);
            control.AxisChange();
            control.Invalidate();
        }
    }
}