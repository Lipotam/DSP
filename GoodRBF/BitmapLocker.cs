using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;

namespace GoodRBF
{
    public class BitmapLocker : IEnumerable
    {
        public class BitmapLockerEnumerator : IEnumerator
        {
            int index = -1;
            BitmapLocker Owner;
            public object Current
            {
                get
                {
                    unsafe
                    {
                        return *((uint*)Owner.BmpData.Scan0 + index);                        
                    }
                }
            }
            public bool MoveNext()
            {
                index++;
                if (index >= Owner.Width * Owner.Height)
                {
                    return false;
                }
                return true;
            }

            public void Reset()
            {
                index = -1;
            }

            public BitmapLockerEnumerator(BitmapLocker owner)
            {
                this.Owner = owner;
            }
        }
        public IEnumerator GetEnumerator()
        {
            return new BitmapLockerEnumerator(this);
        }

        public Bitmap Image
        {
            protected set;
            get;
        }

        public long Width
        {
            get 
            {
                if (this.Image == null) return 0;
                return Image.Width; 
            }
        }
        public long Height
        {
            get
            {
                if (this.Image == null) return 0;
                return Image.Height;
            }
        }

        BitmapData BmpData;

        public BitmapLocker()
        {
            BmpData = null;
        }

        public void Lock(Bitmap Img)
        {
            if (BmpData != null) throw new InvalidOperationException("Image are locked!");
            if (Img == null) throw new ArgumentNullException("Image can not be null.");
            this.Image = Img;

            BmpData = Image.LockBits(new Rectangle(new Point(0, 0), Image.Size), ImageLockMode.ReadWrite, PixelFormat.Format32bppPArgb);
        }

        public void Unlock()
        {
            this.Image.UnlockBits(this.BmpData);
            this.BmpData = null;
        }

        public uint this[int y, int x]
        {
            set
            {
                unsafe
                {
                    *((uint*)BmpData.Scan0 + y * BmpData.Width + x) = value;
                }
            }
            get 
            {
                unsafe
                {
                    return *((uint*)BmpData.Scan0 + y * BmpData.Width + x);
                }
            }
        }

        public uint[] D4Scope(int y, int x)
        {
            uint[] Scope = new uint[4];
            if (y != 0) Scope[0] = this[y - 1, x];
            else Scope[0] = 0;
            if (x != 0) Scope[1] = this[y, x - 1];
            else Scope[1] = 0;

            Scope[2] = this[y, x + 1];
            Scope[3] = this[y+1, x];

            return Scope;
        }

        public uint[] DNScope(int y, int x, uint Radius)
        {
            uint Size = 2*Radius + 1;
            uint[] Scope = new uint[Size*Size];

            int index = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Scope[index] = this[i, j];
                    index++;
                }
            }

            return Scope;
        }
    }
}