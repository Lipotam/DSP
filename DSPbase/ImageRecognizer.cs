using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        private byte[,] recognizedMap;
        private byte[,] groupMap;

        private readonly byte separateValue;

        List<int> listX = new List<int>();
        List<int> listY = new List<int>();

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

            outputImage = GetBitmap(outputBytes, width, height);
        }

        private void RecognizeToGroups()
        {
            groupMap = new byte[width, height];
            byte groupId = 1;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (groupMap[i, j] == 0)
                    {
                        groupId += SetGroupToPixel(i, j, groupId, 0);
                    }
                }
            }
        }

        private byte SetGroupToPixel(int coordinateX, int coordinateY, byte groupID, byte recursiveNesting)
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

            if (GetGrayColorFromInput(coordinateX,coordinateY) < separateValue)
            {
                groupMap[coordinateX, coordinateY] = groupID;
            }
            else
            {
                groupMap[coordinateX, coordinateY] = 1;
                return 0;
            }

            if (!(coordinateX - 1 < 0 || coordinateY < 0 || coordinateX - 1 > width - 1 || coordinateY > height - 1) && GetGrayColorFromInput(coordinateX, coordinateY) < separateValue && groupMap[coordinateX - 1, coordinateY] == 0)
            {
                SetGroupToPixel(coordinateX - 1, coordinateY, groupID, (byte)(recursiveNesting + 1));
            }

            if (!(coordinateX + 1 < 0 || coordinateY < 0 || coordinateX + 1 > width - 1 || coordinateY > height - 1) && GetGrayColorFromInput(coordinateX, coordinateY) < separateValue && groupMap[coordinateX + 1, coordinateY] == 0)
            {
                SetGroupToPixel(coordinateX + 1, coordinateY, groupID, (byte)(recursiveNesting + 1));
            }

            if (!(coordinateX < 0 || coordinateY - 1 < 0 || coordinateX > width - 1 || coordinateY - 1 > height - 1) && GetGrayColorFromInput(coordinateX, coordinateY) < separateValue && groupMap[coordinateX, coordinateY - 1] == 0)
            {
                SetGroupToPixel(coordinateX, coordinateY - 1, groupID, (byte)(recursiveNesting + 1));
            }

            if (!(coordinateX < 0 || coordinateY + 1 < 0 || coordinateX > width - 1 || coordinateY + 1 > height - 1) && GetGrayColorFromInput(coordinateX, coordinateY) < separateValue && groupMap[coordinateX, coordinateY + 1] == 0)
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

            if (groupMap[coordinateX, coordinateY] == groupID)
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

            outputImage = GetBitmap(outputBytes, width, height);
        }

        private byte GetGrayColorFromInput(int x, int y)
        {
            return
                    (byte)
                    (0.30 * inputBytes[4 * (width * y + x) + 0] +
                      0.59 * inputBytes[4 * (width * y + x) + 1] +
                      0.11 * inputBytes[4 * (width * y + x) + 2]);
        }

        private Bitmap GetBitmap(byte[] input, int width, int height)
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

    }
}
