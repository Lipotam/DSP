using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Drawing;

namespace DSPbase
{
    public class ImageRecognizer
    {
        private readonly Bitmap inputImage;
        private byte[] inputBytes;
        private int width, height;

        private Bitmap outputImage;
        private byte[] outputBytes;

        private  static Random random = new Random();

        public Bitmap InputImage
        {
            get
            {
                return inputImage;
            }
        }

        public Bitmap OutputImage
        {
            get
            {
                return outputImage;
            }
        }
        private int[,] groupMap;

        private readonly byte separateValue;

        List<int> listX;
        List<int> listY;

        public ImageRecognizer(Bitmap inputImage, byte separateValue)
        {
            this.inputImage = inputImage;
            this.separateValue = separateValue;
            inputBytes = GetBytes(inputImage);
            width = inputImage.Width;
            height = inputImage.Height;
        }

        public void Negative()
        {
            if (inputBytes == null)
            {
                inputBytes = GetBytes(inputImage);
                width = inputImage.Width;
                height = inputImage.Height;
            }
            outputBytes = new byte[inputBytes.Length];
            for (int x = 0; x < width - 1; x++)
            {
                for (int y = 0; y < height - 1; y++)
                {
                    outputBytes[4 * (width * y + x) + 0] = (byte)(255 - inputBytes[4 * (width * y + x) + 0]);
                    outputBytes[4 * (width * y + x) + 1] = (byte)(255 - inputBytes[4 * (width * y + x) + 1]);
                    outputBytes[4 * (width * y + x) + 2] = (byte)(255 - inputBytes[4 * (width * y + x) + 2]);
                }
            }

            outputImage = GetBitmap(outputBytes);
        }

        public void RecognizeToGroups()
        {
            groupMap = new int[width, height];
            int groupId = 2;

            listX = new List<int>();
            listY = new List<int>();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {

                    groupId += SetGroupToPixel(i, j, groupId, 0);
                }
            }
        }

        private byte SetGroupToPixel(int coordinateX, int coordinateY, int groupId, byte recursiveNesting)
        {
            if (coordinateX < 0 || coordinateY < 0 || coordinateX > width - 1 || coordinateY > height - 1 || groupMap[coordinateX, coordinateY] != 0)
            {
                return 0;
            }

            if (recursiveNesting >= 10)
            {
                listX.Add(coordinateX);
                listY.Add(coordinateY);
                return 0;
            }

            if (GetGrayColorFromInput(coordinateX, coordinateY) > separateValue)
            {
                groupMap[coordinateX, coordinateY] = groupId;
            }
            else
            {
                groupMap[coordinateX, coordinateY] = 1;
                return 0;
            }

            if (!(coordinateX - 1 < 0 || coordinateY < 0 || coordinateX - 1 > width - 1 || coordinateY > height - 1) && groupMap[coordinateX - 1, coordinateY] == 0)
            {
                SetGroupToPixel(coordinateX - 1, coordinateY, groupId, (byte)(recursiveNesting + 1));
            }

            if (!(coordinateX + 1 < 0 || coordinateY < 0 || coordinateX + 1 > width - 1 || coordinateY > height - 1) && groupMap[coordinateX + 1, coordinateY] == 0)
            {
                SetGroupToPixel(coordinateX + 1, coordinateY, groupId, (byte)(recursiveNesting + 1));
            }

            if (!(coordinateX < 0 || coordinateY - 1 < 0 || coordinateX > width - 1 || coordinateY - 1 > height - 1) && groupMap[coordinateX, coordinateY - 1] == 0)
            {
                SetGroupToPixel(coordinateX, coordinateY - 1, groupId, (byte)(recursiveNesting + 1));
            }

            if (!(coordinateX < 0 || coordinateY + 1 < 0 || coordinateX > width - 1 || coordinateY + 1 > height - 1) && groupMap[coordinateX, coordinateY + 1] == 0)
            {
                SetGroupToPixel(coordinateX, coordinateY + 1, groupId, (byte)(recursiveNesting + 1));
            }

            while (recursiveNesting == 0 && listX.Count > 0)
            {
                int tempX = listX.First();
                int tempY = listY.First();
                listX.Remove(listX.First());
                listY.Remove(listY.First());
                SetGroupToPixel(tempX, tempY, groupId, (byte)(recursiveNesting + 1));
            }

            if (groupMap[coordinateX, coordinateY] == groupId)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        public void TransformToBlackAndWhite()
        {
            if (inputBytes == null)
            {
                inputBytes = GetBytes(inputImage);
                width = inputImage.Width;
                height = inputImage.Height;
            }
            outputBytes = new byte[inputBytes.Length];
            for (int x = 0; x < width - 1; x++)
            {
                for (int y = 0; y < height - 1; y++)
                {
                    outputBytes[4 * (width * y + x) + 0] =
                        outputBytes[4 * (width * y + x) + 1] =
                        outputBytes[4 * (width * y + x) + 2] =
                        GetGrayColorFromInput(x, y)
                        > separateValue
                        ? (byte)255
                        : (byte)0;
                }
            }

            outputImage = GetBitmap(outputBytes);
        }

        private byte GetGrayColorFromInput(int x, int y)
        {
            return
                    (byte)
                    (0.30 * inputBytes[4 * (width * y + x) + 0] +
                      0.59 * inputBytes[4 * (width * y + x) + 1] +
                      0.11 * inputBytes[4 * (width * y + x) + 2]);
        }

        private Bitmap GetBitmap(byte[] input)
        {
            if (input.Length % 4 != 0) return null;
            Bitmap output = new Bitmap(width, height);
            BitmapData outputData = output.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format32bppRgb
                );

            System.Runtime.InteropServices.Marshal.Copy(input, 0, outputData.Scan0, input.Length);
            output.UnlockBits(outputData);
            return output;
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

        public void PaintFromGroupMap()
        {
            if (groupMap != null)
            {
                outputBytes = new byte[inputBytes.Length];

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        if (groupMap[x, y] == 1)
                        {
                            SetColorToOutputbytes(x, y, Color.White);
                        }
                        else
                        {
                           SetColorToOutputbytes(x,y,GetRandomColor());
                        }
                    }
                }
                outputImage = GetBitmap(outputBytes);
            }
        }

        private Color GetRandomColor(int lowestRedValue = 0, int highestRedValue = 255,
                                     int lowestGreenValue = 0, int higestGreenValue = 255,
                                     int lowestBlueValue = 0, int highestBlueValue = 255
                                    )
        {
            
            return Color.FromArgb(
                random.Next(lowestRedValue, highestRedValue),
                random.Next(lowestGreenValue, higestGreenValue),
                random.Next(lowestBlueValue, highestBlueValue)
                );
        }

        private void SetColorToOutputbytes(int x, int y, Color colorToset)
        {
            outputBytes[4 * (width * y + x) + 0] = colorToset.B;
            outputBytes[4 * (width * y + x) + 1] = colorToset.G;
            outputBytes[4 * (width * y + x) + 2] = colorToset.R;
        }

    }
}
