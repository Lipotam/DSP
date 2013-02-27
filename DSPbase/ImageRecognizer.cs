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
        private List<ImageObject> objectList;
        private int kMedians;
        private List<ImageObject> hitImagesList;
        private readonly double areaCoefficient, perimeterCoefficient, elongationCoefficient, densityCoefficient, massCenterCoefficient;

        private readonly int lowestRedValue;
        private readonly int highestRedValue;
        private readonly int lowestGreenValue;
        private readonly int higestGreenValue;
        private readonly int lowestBlueValue;
        private readonly int highestBlueValue;
        private readonly int minimalSquare;
        private readonly byte separateValue;

        private static readonly Random random = new Random();

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

        List<int> listX;
        List<int> listY;

        public ImageRecognizer(Bitmap inputImage, byte separateValue, int minimalSquare,
                                    int kMedians = 1, double areaCoefficient = 1, double perimeterCoefficient = 1,
                                    double elongationCoefficient = 1, double densityCoefficient = 1, double massCenterCoefficient = 1,
                                     int lowestRedValue = 0, int highestRedValue = 255,
                                     int lowestGreenValue = 0, int higestGreenValue = 255,
                                     int lowestBlueValue = 0, int highestBlueValue = 255)
        {
            this.inputImage = inputImage;
            this.separateValue = separateValue;
            inputBytes = GetBytes(inputImage);
            width = inputImage.Width;
            height = inputImage.Height;
            this.lowestRedValue = lowestRedValue;
            this.highestRedValue = highestRedValue;
            this.lowestGreenValue = lowestGreenValue;
            this.higestGreenValue = higestGreenValue;
            this.lowestBlueValue = lowestBlueValue;
            this.highestBlueValue = highestBlueValue;
            this.minimalSquare = minimalSquare;
            this.kMedians = kMedians;
            this.areaCoefficient = areaCoefficient;
            this.perimeterCoefficient = perimeterCoefficient;
            this.elongationCoefficient = elongationCoefficient;
            this.densityCoefficient = densityCoefficient;
            this.massCenterCoefficient = massCenterCoefficient;
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

        public void RecognizePixelsToGroups()
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

        public void PaintFromGroupMap()
        {
            int maxGroupNumer = this.GetGroupNumber();

            List<Color> colorList = new List<Color>();
            for (int i = 0; i < maxGroupNumer; i++)
            {
                colorList.Add(GetRandomColor());
            }
            if (groupMap != null)
            {
                outputBytes = new byte[inputBytes.Length];

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        this.SetColorToOutputbytes(x, y, this.groupMap[x, y] == 1
                            ? Color.White
                            : colorList.ToArray()[this.groupMap[x, y] - 1]);
                    }
                }
                outputImage = GetBitmap(outputBytes);
            }
        }

        public void SetObjectsToGroups()
        {
            FakeImageObject[] mediansArray = new FakeImageObject[kMedians];
            for (int i = 0; i < kMedians; i++)
            {
                mediansArray[i] = GetRandomFromObjectList();
            }

            List<ImageObject>[] imageClasses = new List<ImageObject>[kMedians];
            for (int i = 0; i < kMedians; i++)
            {
                imageClasses[i] = new List<ImageObject>();
            }

            foreach (ImageObject imageObject in objectList)
            {
                imageClasses[GetClassIndex(mediansArray, imageObject)].Add(imageObject);
            }

            bool flag = true;
            while (flag)
            {
                flag = false;
                mediansArray = new FakeImageObject[kMedians];

                for (int i = 0; i < kMedians; i++)
                {
                    mediansArray[i] = GetAverageFromImageList(imageClasses[i]);
                }

                List<ImageObject>[] tempImageClasses = new List<ImageObject>[kMedians];
                for (int i = 0; i < kMedians; i++)
                {
                    tempImageClasses[i] = new List<ImageObject>();
                }
                foreach (List<ImageObject> objectList1 in imageClasses)
                {
                    foreach (ImageObject imageObject in objectList1)
                    {
                        tempImageClasses[GetClassIndex(mediansArray, imageObject)].Add(imageObject);
                    }
                }

                for (int i = 0; i < kMedians; i++)
                {
                    if (tempImageClasses[i].Count != imageClasses[i].Count)
                    {
                        flag = true;
                    }
                }

                imageClasses = tempImageClasses;
            }

            foreach (List<ImageObject> imageObjectList in imageClasses)
            {
                foreach (ImageObject imageObject in imageObjectList)
                {
                    foreach (Point point in imageObject.Points)
                    {
                        groupMap[point.X, point.Y] = Array.IndexOf(imageClasses, imageObjectList) + 2;
                    }
                }
            }
        }

        public void SetPixelsToObjectGroupsWithFilter()
        {
            ImageObject[] objectArray = new ImageObject[GetGroupNumber() + 1];
            objectArray[0] = new ImageObject();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (objectArray[groupMap[x, y]] == null)
                    {
                        objectArray[groupMap[x, y]] = new ImageObject();
                        objectArray[groupMap[x, y]].GroupId = groupMap[x, y];
                    }

                    objectArray[groupMap[x, y]].AddPoint(new Point(x, y));

                    if (!(
                        IsGroupEqualToGroupnumber(x - 1, y, groupMap[x, y]) &&
                        IsGroupEqualToGroupnumber(x + 1, y, groupMap[x, y]) &&
                        IsGroupEqualToGroupnumber(x, y - 1, groupMap[x, y]) &&
                        IsGroupEqualToGroupnumber(x, y + 1, groupMap[x, y])))
                    {
                        objectArray[groupMap[x, y]].IncrementPerimeter();
                    }
                }
            }
            objectList = new List<ImageObject>();
            foreach (ImageObject imageObject in objectArray)
            {
                if (imageObject.Area == 0 || imageObject.GroupId == 1)
                {
                    continue;
                }
                if (imageObject.Area > minimalSquare)
                {
                    objectList.Add(imageObject);
                }
                else
                {
                    foreach (Point point in imageObject.Points)
                    {
                        groupMap[point.X, point.Y] = 1;
                    }
                }
            }
        }

        private FakeImageObject GetAverageFromImageList(List<ImageObject> imageList)
        {
            if (imageList.Count == 0)
            {
                return new FakeImageObject();
            }
            return new FakeImageObject()
                {
                    Area = (int)imageList.Average(x => x.Area),
                    Density = imageList.Average(x => x.Density),
                    Elongation = imageList.Average(x => x.Elongation),
                    Perimeter = (int)imageList.Average(x => x.Perimeter),
                    MassCenter = new Point((int)imageList.Average(x => x.MassCenter.X), (int)imageList.Average(x => x.MassCenter.Y))
                };
        }

        private int GetClassIndex(FakeImageObject[] classes, ImageObject imageObject)
        {
            double[] distances = new double[classes.Count()];

            for (int i = 0; i < classes.Count(); i++)
            {
                distances[i] =
                        Math.Abs(areaCoefficient * (classes[i].Area - imageObject.Area)) +
                        Math.Abs(densityCoefficient * (classes[i].Density - imageObject.Density)) +
                        Math.Abs(elongationCoefficient * (classes[i].Elongation - imageObject.Elongation)) +
                        Math.Abs(perimeterCoefficient * (classes[i].Perimeter - imageObject.Perimeter)) +
                        Math.Abs(massCenterCoefficient * Math.Sqrt(
                        (classes[i].MassCenter.X - imageObject.MassCenter.X) * (classes[i].MassCenter.X - imageObject.MassCenter.X) +
                        (classes[i].MassCenter.Y - imageObject.MassCenter.Y) * (classes[i].MassCenter.Y - imageObject.MassCenter.Y))
                        );
            }

            return Array.IndexOf(distances, distances.Min());
        }

        private FakeImageObject GetRandomFromObjectList()
        {
            FakeImageObject result = new FakeImageObject();
            if (hitImagesList == null)
            {
                hitImagesList = new List<ImageObject>();
            }

            if (hitImagesList.Count == objectList.Count)
            {
                result.SetPropertiesFromImageObject(objectList.First());
                return result;
            }

            ImageObject randomImage;

            do
            {
                randomImage = objectList.ToArray()[random.Next(0, objectList.Count - 1)];
            } while (hitImagesList.Contains(randomImage));

            hitImagesList.Add(randomImage);
            result.SetPropertiesFromImageObject(randomImage);
            return result;
        }

        private int GetGroupNumber()
        {
            int maxGroupNumer = groupMap[0, 0];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (groupMap[x, y] > maxGroupNumer)
                    {
                        maxGroupNumer = groupMap[x, y];
                    }
                }
            }

            return maxGroupNumer;
        }

        private Color GetRandomColor()
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

        private bool IsGroupEqualToGroupnumber(int x, int y, int groupNumber)
        {
            if (!(x < 0 || y < 0 || x > width - 1 || y > height - 1) && groupMap[x, y] == groupNumber)
            {
                return true;
            }
            return false;
        }

        private byte GetGrayColorFromInput(int x, int y)
        {
            return (byte)
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
    }
}