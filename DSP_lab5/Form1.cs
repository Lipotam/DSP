using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using ZedGraph;

namespace DSP_lab5
{
    public partial class Form1 : Form
    {
        private Bitmap bAWImage;
        private byte[,] recognizedMap;
        private byte[,] groupMap;
        private byte[] inputBytes;
        private byte[] outputBytes;
        private int width, height;
        public readonly static double[,] weightFFT = { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };
        public Form1()
        {
            InitializeComponent();
        }

        private bool flag = false;
        List<int> listX = new List<int>();
        List<int> listY = new List<int>();

        public Bitmap Negative(Bitmap input)
        {
            byte[] inputBytes = GetBytes(input);

            width = input.Width;
            height = input.Height;

            for (int x = 0; x < width - 1; x++)
            {
                for (int y = 0; y < height - 1; y++)
                {
                    inputBytes[4 * (width * y + x) + 0] = (byte)(255 - inputBytes[4 * (width * y + x) + 0]);
                    inputBytes[4 * (width * y + x) + 1] = (byte)(255 - inputBytes[4 * (width * y + x) + 1]);
                    inputBytes[4 * (width * y + x) + 2] = (byte)(255 - inputBytes[4 * (width * y + x) + 2]);
                }
            }

            return GetBitmap(inputBytes, width, height);
        }

        public void SetPixelsToGroups(Bitmap input)
        {
            inputBytes = GetBytes(input);
            outputBytes = new byte[inputBytes.Length];
            recognizedMap = new byte[input.Width, input.Height];

            width = input.Width;
            height = input.Height;

            SetPixelGroup(1, 1);
        }

        private void SetPixelGroup(int coordinateX, int coordinateY)
        {
            byte rezult = 0;
            if (coordinateX < 1 || coordinateY < 1 || coordinateX >= width - 1 || coordinateY >= height - 1 || recognizedMap[coordinateX, coordinateY] != 0)
            {
                return;
            }

            rezult += (inputBytes[4 * (width * (coordinateY - 1) + coordinateX)])
                        > separateValue.Value
                        ? (byte)1
                        : (byte)0;
            rezult += (inputBytes[4 * (width * coordinateY + coordinateX + 1)])
                        > separateValue.Value
                        ? (byte)1
                        : (byte)0;
            rezult += (inputBytes[4 * (width * (coordinateY + 1) + coordinateX)])
                        > separateValue.Value
                        ? (byte)1
                        : (byte)0;
            rezult += (inputBytes[4 * (width * coordinateY + coordinateX - 1)])
                        > separateValue.Value
                        ? (byte)1
                        : (byte)0;

            recognizedMap[coordinateX, coordinateY] = rezult > 2
                                                          ? (byte)2
                                                          : (byte)1;
            SetPixelGroup(coordinateX + 1, coordinateY);
            SetPixelGroup(coordinateX, coordinateY + 1);
        }

        private void Recognize()
        {
            groupMap = new byte[width, height];
            int groupID = 100;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (groupMap[i, j] == 0)
                    {
                        groupID += SetGroupToPixel(i, j, groupID, 0);

                    }
                }
            }
        }

        private byte SetGroupToPixel(int coordinateX, int coordinateY, int groupID, byte recursiveNesting)
        {
            if (coordinateX < 0 || coordinateY < 0 || coordinateX > width - 1 || coordinateY > height - 1 || groupMap[coordinateX, coordinateY] != 0)
            {
                return 0;
            }

            if (recursiveNesting >= 100)
            {
                listX.Add(coordinateX);
                listY.Add(coordinateY);
                return 0;
            }


            if (recognizedMap[coordinateX, coordinateY] == 2)
            {
                groupMap[coordinateX, coordinateY] = 2;
                outputBytes[4 * (width * coordinateY + coordinateX)] = (byte)groupID;
                outputBytes[4 * (width * coordinateY + coordinateX) + 1] = (byte)groupID;
                outputBytes[4 * (width * coordinateY + coordinateX) + 2] = (byte)groupID;
            }
            else
            {
                groupMap[coordinateX, coordinateY] = 1;
                outputBytes[4 * (width * coordinateY + coordinateX)] = 255;
                outputBytes[4 * (width * coordinateY + coordinateX) + 1] = 255;
                outputBytes[4 * (width * coordinateY + coordinateX) + 2] = 255;
                return 0;
            }

            if (!(coordinateX - 1 < 0 || coordinateY < 0 || coordinateX - 1 > width - 1 || coordinateY > height - 1) && recognizedMap[coordinateX - 1, coordinateY] == 2 && groupMap[coordinateX - 1, coordinateY] == 0)
            {
                SetGroupToPixel(coordinateX - 1, coordinateY, groupID, (byte)(recursiveNesting + 1));
            }

            if (!(coordinateX + 1 < 0 || coordinateY < 0 || coordinateX + 1 > width - 1 || coordinateY > height - 1) && recognizedMap[coordinateX + 1, coordinateY] == 2 && groupMap[coordinateX + 1, coordinateY] == 0)
            {
                SetGroupToPixel(coordinateX + 1, coordinateY, groupID, (byte)(recursiveNesting + 1));
            }

            if (!(coordinateX < 0 || coordinateY - 1 < 0 || coordinateX > width - 1 || coordinateY - 1 > height - 1) && recognizedMap[coordinateX, coordinateY - 1] == 2 && groupMap[coordinateX, coordinateY - 1] == 0)
            {
                SetGroupToPixel(coordinateX, coordinateY - 1, groupID, (byte)(recursiveNesting + 1));
            }

            if (!(coordinateX < 0 || coordinateY + 1 < 0 || coordinateX > width - 1 || coordinateY + 1 > height - 1) && recognizedMap[coordinateX, coordinateY + 1] == 2 && groupMap[coordinateX, coordinateY + 1] == 0)
            {
                SetGroupToPixel(coordinateX, coordinateY + 1, groupID, (byte)(recursiveNesting + 1));
            }

            while (recursiveNesting == 0 && listX.Count > 0)
            {
                int tempX = listX.First();
                int tempY = listY.First();
                listX.Remove(listX.First());
                listY.Remove(listY.First());
                SetGroupToPixel(tempX, tempY, groupID, (byte)(recursiveNesting + 1));
            }

            if (recognizedMap[coordinateX, coordinateY] == 2)
            {
                return 100;
            }
            else
            {
                return 0;
            }
        }


        public Bitmap TransformToBlackAndWhite(Bitmap input)
        {
            byte[] inputBytes = GetBytes(input);

            int width = input.Width;
            int height = input.Height;

            for (int x = 0; x < width - 1; x++)
            {
                for (int y = 0; y < height - 1; y++)
                {
                    inputBytes[4 * (width * y + x) + 0] =
                        inputBytes[4 * (width * y + x) + 1] =
                        inputBytes[4 * (width * y + x) + 2] =
                        (byte)(0.30 * inputBytes[4 * (width * y + x) + 0] +
                                0.59 * inputBytes[4 * (width * y + x) + 1] +
                                0.11 * inputBytes[4 * (width * y + x) + 2])
                        > (byte)separateValue.Value
                        ? (byte)255
                        : (byte)0;
                }
            }

            return GetBitmap(inputBytes, width, height);
        }

        public Bitmap FBF(Bitmap input)
        {
            byte[] inputBytes = GetBytes(input);
            byte[] outputBytes = new byte[inputBytes.Length];
            int[] oi = new int[inputBytes.Length];

            int width = input.Width;
            int height = input.Height;

            int wWidth = weightFFT.GetLength(0);
            int wHeight = weightFFT.GetLength(1);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    double rSum = 0, gSum = 0, bSum = 0, kernelSum = 0;

                    for (int i = 0; i < wWidth; i++)
                    {
                        for (int j = 0; j < wHeight; j++)
                        {
                            int pixelPosX = x + (i - (wWidth / 2));
                            int pixelPosY = y + (j - (wHeight / 2));
                            if ((pixelPosX < 0) || (pixelPosX >= width) || (pixelPosY < 0) || (pixelPosY >= height))
                                continue;

                            double kernelVal = weightFFT[i, j];

                            rSum += inputBytes[4 * (width * pixelPosY + pixelPosX) + 0] * weightFFT[i, j];
                            gSum += inputBytes[4 * (width * pixelPosY + pixelPosX) + 1] * weightFFT[i, j];
                            bSum += inputBytes[4 * (width * pixelPosY + pixelPosX) + 2] * weightFFT[i, j];

                            kernelSum += kernelVal;
                        }
                    }
                    if (kernelSum <= 0) kernelSum = 1;

                    if (rSum < 0) rSum = 0;
                    if (rSum > 255) rSum = 255;

                    if (gSum < 0) gSum = 0;
                    if (gSum > 255) gSum = 255;

                    if (bSum < 0) bSum = 0;
                    if (bSum > 255) bSum = 255;

                    outputBytes[4 * (width * y + x) + 0] = (byte)rSum;
                    outputBytes[4 * (width * y + x) + 1] = (byte)gSum;
                    outputBytes[4 * (width * y + x) + 2] = (byte)bSum;
                }
            }

            return GetBitmap(outputBytes, width, height);
        }

        private Bitmap GetBitmap(byte[] input, int width, int height)
        {
            if (input.Length % 4 != 0) return null;
            Bitmap output = new Bitmap(width, height);
            BitmapData outputData = output.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format32bppRgb);

            System.Runtime.InteropServices.Marshal.Copy(input, 0, outputData.Scan0, input.Length);
            output.UnlockBits(outputData);
            return output;
        }

        private byte[] GetBytes(Bitmap input)
        {
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
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp,*.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            Bitmap bit = new Bitmap(openFileDialog1.FileName);
                            pictureBox1.Image = bit;
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
            bAWImage = TransformToBlackAndWhite((Bitmap)pictureBox1.Image);
            pictureBox2.Image = bAWImage;
            SetPixelsToGroups(bAWImage);
            Recognize();
            pictureBox3.Image = GetBitmap(outputBytes, bAWImage.Width, bAWImage.Height);
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