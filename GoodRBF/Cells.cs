using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodRBF
{
    public class InputCell : BaseCell
    {
        public double MaxOutputValue
        {
            set;
            get;
        }

        public double MinOutputValue
        {
            set;
            get;
        }

        public double MaxInputValue
        {
            set;
            get;
        }

        public double MinInputValue
        {
            set;
            get;
        }

        public override void DoWork()
        {
            if ((this.Input[0] - MinInputValue) < (this.MaxInputValue - this.Input[0]))
            {
                this.Output = MinOutputValue;
            }
            else 
            {
                this.Output = MaxOutputValue;
            }
        }

        public InputCell()
        {
            this.InputWidth = 1;

            MaxOutputValue = 1;
            MinOutputValue = -1;

            MaxInputValue = 255;
            MinInputValue = 0;
        }
    }

    public class Neuron : BaseCell
    {
        public double[] Weights
        {
            protected set;
            get;
        }

        public override void Reset()
        {
            Weights = null;
            Threshoold = 0;
            base.Reset();
        }
        public override void Clear()
        {
            base.Clear();
            this.Threshoold = 0;
            for (int i = 0; i < this.Weights.Count(); i++)
            {
                this.Weights[i] = 0;
            }
        }

        public override int InputWidth
        {
            get
            {
                return base.InputWidth;
            }
            set
            {
                base.InputWidth = value;
                this.Weights = new double[this.InputWidth];
            }
        }

        public override void DoWork()
        {
            this.Output = 0;
            for(int i = 0; i < this.InputWidth; i++)
            {
                this.Output += this.Weights[i]*this.Input[i];
            }
            this.Output += Threshoold;
            this.Output = 2 / (1 + Math.Exp(-this.Output)) - 1;
        }

        public double Threshoold
        {
            set;
            get;
        }
        public int Iteration
        {
            set;
            get;
        }

        public void InitWeights( System.Func<int,double> Init )
        {
            for (int i = 0; i < this.InputWidth; i++)
            {
                this.Weights[i] = Init(i);
            }
        }
        public void InitWeights(System.Func<double> Init)
        {
            for (int i = 0; i < this.InputWidth; i++)
            {
                this.Weights[i] = Init();
            }
        }

        public Neuron() { }
        public Neuron(int inWidth) : base(inWidth) { }
    }

    public class RBFCell : BaseCell
    {
        public double Sigma
        {
            set;
            get;
        }

        public double[] Expectations
        {
            protected set;
            get;
        }

        public override void Reset()
        {
            this.Expectations = null;
            this.Sigma = 0;
            base.Reset();
        }

        public override void Clear()
        {
            base.Clear();
            this.Sigma = 0;
            for (int i = 0; i < this.Expectations.Count(); i++)
            {
                this.Expectations[i] = 0;
            }
        }

        public override int InputWidth
        {
            get
            {
                return base.InputWidth;
            }
            set
            {
                base.InputWidth = value;
                this.Expectations = new double[this.InputWidth];
            }
        }

        public override void DoWork()
        {
            this.Output = -this.Dist(this.Input)/(this.Sigma * this.Sigma);
            this.Output = Math.Exp(this.Output);
        }

        public double Dist(double[] image)
        {
            double dist = 0;
            for (int i = 0; i < this.InputWidth; i++)
            {
                double dif = (image[i] - Expectations[i]);
                dist += dif * dif;
            }
            return dist;
        }

        public RBFCell(int inWidth) : base(inWidth) { }
        public RBFCell() { }
    }
}
