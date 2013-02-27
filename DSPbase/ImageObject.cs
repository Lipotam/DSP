using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DSPbase
{
    class ImageObject
    {
        private List<Point> pointList;
        private int perimeter;
        private int groupId;
        public int GroupId
        {
            set
            {
                this.groupId = value;
            }
            get
            {
                return groupId;
            }
        }

        public List<Point> Points
        {
            get
            {
                return pointList;
            }
        }

        public int Area
        {
            get
            {
                return pointList.Count;
            }
        }

        public int Perimeter
        {
            get
            {
                return perimeter;
            }
        }

        public double Elongation
        {
            get
            {
                double m02 = GetMoment(0, 2),
                    m20 = GetMoment(2, 0),
                    m11 = GetMoment(1, 1);
                double sqrtRezult = Math.Sqrt((m20 - m02) * (m20 - m02) + 4 * m11 * m11);

                return (m20 + m02 + sqrtRezult) / (m20 + m02 - sqrtRezult);
            }
        }

        public Point MassCenter
        {
            get
            {
                int minimalX = (int)pointList.Min(t => t.X);
                int minimalY = (int)pointList.Min(t => t.Y);
                return new Point(
                       (int)pointList.Average(t => t.X-minimalX),
                       (int)pointList.Average(t => t.Y-minimalY));
            }
        }

        public double Density
        {
            get
            {
                return (double)perimeter * perimeter / Area;
            }
        }

        public ImageObject()
        {
            pointList = new List<Point>();
            perimeter = 0;
        }

        public void AddPoint(Point objectPoint)
        {
            pointList.Add(objectPoint);
        }


        public void IncrementPerimeter()
        {
            perimeter++;
        }
        private int GetMoment(int i, int j)
        {
            int result = 0;
            Point massCenter = MassCenter;

            foreach (Point point in pointList)
            {
                result += power(point.X - massCenter.X, i) * power(point.Y - massCenter.Y, j);
            }
            return result;
        }

        private int power(int x, int power)
        {
            if (power == 0)
            {
                return 1;
            }
            else
            {
                if (power == 1)
                {
                    return x;
                }
                else
                {
                    return x * x;
                }
            }
        }
    }
}
