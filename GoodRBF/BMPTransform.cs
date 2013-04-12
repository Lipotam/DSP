using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GoodRBF
{
    public static class BMPTransform
    {
        public static double[] BitmapToDouble(Bitmap Image)
        {
            BitmapLocker Locker = new BitmapLocker();
            Locker.Lock(Image);
            double[] result = new double[Image.Width * Image.Height];
            int i = 0;
            foreach (uint n in Locker)
            {
                byte r = (byte)(n >> 16);
                byte g = (byte)(n >> 8);
                byte b = (byte)n;
                result[i] = (byte)(0.3 * r + 0.59 * g + 0.11 * b);
                i++;
            }
            Locker.Unlock();
            return result;
        }

        public static Bitmap DoubleToBitmap(double[] Values, int Width, int Height, double min, double max)
        {
            Bitmap result = new Bitmap(Width, Height);
            BitmapLocker Locker = new BitmapLocker();
            Locker.Lock(result);
            int index = 0;
            for (int i = 0; i < Locker.Height; i++)
            {
                for (int j = 0; j < Locker.Width; j++)
                {
                    double p = 255 * (Values[index]-min) / (max - min);
                    byte h = (byte)p;
                    Locker[i, j] = ((uint)255 << 24) + ((uint)h << 16) + ((uint)h << 8) + h;
                    index++;
                }
            }
            Locker.Unlock();
            return result;
        }

    }
}
