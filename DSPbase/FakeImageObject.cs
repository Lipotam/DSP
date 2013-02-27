using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPbase
{
    class FakeImageObject
    {
        public int Area { get; set; }

        public int Perimeter { get; set; }

        public double Elongation { get; set; }

        public Point MassCenter { get; set; }

        public double Density { get; set; }

        public void SetPropertiesFromImageObject(ImageObject imageObject)
        {
            Area = imageObject.Area;
            Density = imageObject.Density;
            Elongation = imageObject.Elongation;
            MassCenter = imageObject.MassCenter;
            Density = imageObject.Density;
        }
    }
}
