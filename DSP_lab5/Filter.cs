using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace DSP_lab5
{
   public class Filter
    {
        public struct RGB_Color
        {
            public RGB_Color(int Red, int Green, int Blue)
            {
                R = Red;
                G = Green;
                B = Blue;
            }
            public int R, G, B;
        }

      
            private Bitmap UPicture = null;
            private BitmapData BmpData = null;
            private unsafe byte* Begin = (byte*)IntPtr.Zero;
            private int BytesPerPix = 0;

            public Filter(Bitmap MainBitmap)
            {
                if (MainBitmap != null)
                {
                    UPicture = (Bitmap)MainBitmap.Clone();
                    switch (UPicture.PixelFormat)
                    {
                        case PixelFormat.Format24bppRgb:
                            {
                                BytesPerPix = 3;
                                break;
                            }
                        case PixelFormat.Format32bppArgb:
                            {
                                BytesPerPix = 4;
                                break;
                            }
                        default:
                            {
                                throw new NotSupportedException("Формат пикселей не соответствует стандарту");
                            }
                    }
                    BmpData = UPicture.LockBits(new Rectangle(0, 0, UPicture.Width, UPicture.Height),
                              ImageLockMode.ReadWrite, UPicture.PixelFormat);
                    unsafe
                    {
                        Begin = (byte*)BmpData.Scan0;
                    }
                }
                else
                    throw new ArgumentException("Неверный параметр #1");
            }

            public Bitmap Picture
            {
                get { return UPicture; }
            }
            public int Height
            {
                get { return UPicture.Height; }
            }
            public int Width
            {
                get { return UPicture.Width; }
            }
            public int BytesPerPixel
            {
                get { return BytesPerPix; }
            }
            public IntPtr Safe_IMG_Scan0
            {
                get { return BmpData.Scan0; }
            }
            public unsafe byte* Unsafe_IMG_Scan0
            {
                get { return Begin; }
            }
            public int AllPixelsBytes
            {
                get { return UPicture.Width * UPicture.Height * BytesPerPix; }
            }
            public void UnLock()
            {
                UPicture.UnlockBits(BmpData);
            }
            public unsafe RGB_Color GetPixel(int X, int Y)
            {
                RGB_Color Pixel = new RGB_Color();
                int IDX = (Y * UPicture.Width + X) * BytesPerPix; //Вычисляем позицию пикселя
                Pixel.B = *(Begin + (IDX + 0)); //B
                Pixel.G = *(Begin + (IDX + 1)); //G
                Pixel.R = *(Begin + (IDX + 2)); //R
                return Pixel;
            }
            public unsafe void SetPixel(RGB_Color CL, int X, int Y)
            {
                int IDX = (Y * UPicture.Width + X) * BytesPerPix; //Вычисляем позицию пикселя
                *(Begin + (IDX + 0)) = Convert.ToByte(CL.B); //B
                *(Begin + (IDX + 1)) = Convert.ToByte(CL.G); //G
                *(Begin + (IDX + 2)) = Convert.ToByte(CL.R); //R
            }
        }
    }

