using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DSP_lab5
{
    public class Negative
    {
        public static unsafe Bitmap ProcessImage(Filter Main)
        {
            for (int I = 0; I < Main.AllPixelsBytes; I += Main.BytesPerPixel)
            {
                *(Main.Unsafe_IMG_Scan0 + (I + 0)) = (byte)(255 - (*(Main.Unsafe_IMG_Scan0 + I + 0))); //B  
                *(Main.Unsafe_IMG_Scan0 + (I + 1)) = (byte)(255 - (*(Main.Unsafe_IMG_Scan0 + I + 1))); //G  
                *(Main.Unsafe_IMG_Scan0 + (I + 2)) = (byte)(255 - (*(Main.Unsafe_IMG_Scan0 + I + 2))); //R  
            }
            Main.UnLock();
            return Main.Picture;
        }
    }
}
