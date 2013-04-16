using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPbase
{
    class TeachingObject
    {
        public int[] InputVector { get; set; }
        public int GroupNumber { get; set; }
        public int Count
        {
            get
            {
                int result = 0;
                for (int i = 0; i < InputVector.Count(); i++)
                {
                    result += InputVector[i];
                }
                return result;
            }
        }
    }
}
