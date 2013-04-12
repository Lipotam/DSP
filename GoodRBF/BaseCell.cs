using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodRBF
{
    public abstract class BaseCell
    {
        double[] input;
        public double[] Input
        {
            set
            {
                if (value == null) throw new NullReferenceException();
                if (value.Count() < this.InputWidth) throw new System.ArgumentOutOfRangeException("Too few values");
                input = value;
                Output = double.NaN;
            }
            get
            {
                return input;
            }
        }

        double output;
        public double Output
        {
            get
            {
                if (output != double.NaN)
                {
                    return output;
                }
                DoWork();
                return output;
            }
            protected set
            {
                output = value;
            }
        }

        public abstract void DoWork();

        public virtual void Reset()
        {
            input = null;
            Output = double.NaN;
            this.inputWidth = 1;
        }
        public virtual void Clear()
        {
            this.Output = 0;
        }

        int inputWidth;
        public virtual int InputWidth
        {
            get
            {
                return inputWidth;
            }
            set
            {
                this.Reset();
                inputWidth = value;
            }
        }
        public BaseCell()
        {
            this.InputWidth = 1;
        }
        public BaseCell(int InWidth)
        {
            Reset();
            this.InputWidth = InWidth;
        }
    }
}
