using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GoodRBF
{
    public class RBFGrid
    {
        public List<InputCell> InputCells
        {
            get;
            protected set;
        }
        public List<Neuron> OutputCells
        {
            get;
            protected set;
        }

        List<RBFCell> HiddenCells
        {
            get;
            set;
        }

        Dictionary<int, List<double[]>> TrainingSet
        {
            get;
            set;
        }

        public double MaxErrorValue
        {
            set;
            get;
        }

        public int InputCellCount
        {
            set
            {
                this.InputCells.Clear();
                this.TrainingSet.Clear();
                for (int i = 0; i < value; i++)
                {
                    this.InputCells.Add(new InputCell());
                }
            }
            get
            {
                return this.InputCells.Count;
            }
        }
        public int OutputCellCount
        {
            set
            {
                this.OutputCells.Clear();
                this.TrainingSet.Clear();
                for (int i = 0; i < value; i++)
                {
                    this.OutputCells.Add( new Neuron(value) );
                }
            }
            get
            {
                return OutputCells.Count;
            }
        }

        double[] input;
        public double[] Input
        {
            set
            {
                input = value;
                HiddenInput = null;
            }
            get
            {
                return input;
            }
        }

        double[] hiddenInput;
        double[] HiddenInput
        {
            set
            {
                hiddenInput = value;
            }
            get
            {
                if (hiddenInput != null) return hiddenInput;
                hiddenInput = new double[this.InputCellCount];
                for (int i = 0; i < InputCellCount; i++)
                {
                    this.InputCells[i].Input = new double[1];
                    this.InputCells[i].Input[0] = this.Input[i];
                    this.InputCells[i].DoWork();
                    hiddenInput[i] = this.InputCells[i].Output;
                }
                return hiddenInput;
            }
        }

        public double LearnSpeed
        {
            set;
            get;
        }   

        public double[] Output
        {
            get
            {
                double[] result = new double[this.OutputCellCount];
                for (int i = 0; i < this.OutputCellCount; i++)
                {
                    result[i] = this.OutputCells[i].Output;
                }
                return result;
            }
        }

        public RBFGrid()
        {
            this.InputCells = new List<InputCell>();
            this.OutputCells = new List<Neuron>();
            this.HiddenCells = new List<RBFCell>();
            this.TrainingSet = new Dictionary<int, List<double[]>>();
            this.LearnSpeed = 0.1;
            this.MaxErrorValue = 0.33;
        }

        public void LearnImage(int OutputNumber)
        {
            if (Input.Count() < this.InputCellCount)
            {
                throw new InvalidOperationException("Image size is not consistent with InputCell Count");
            }

            if (OutputNumber >= this.OutputCellCount)
            {
                throw new ArgumentOutOfRangeException("Have not output with this number");
            }

            while(this.HiddenCells.Count <= OutputNumber)
            {
                this.HiddenCells.Add(new RBFCell(this.InputCellCount));
            }

            if( !this.TrainingSet.ContainsKey(OutputNumber) )
            {
                this.TrainingSet.Add(OutputNumber, new List<double[]>() );
            }
            
            for(int i = 0; i < this.HiddenInput.Count(); i++)
            {
                this.HiddenCells[OutputNumber].Expectations[i] *= TrainingSet[OutputNumber].Count;
                this.HiddenCells[OutputNumber].Expectations[i] += this.HiddenInput[i];
                this.HiddenCells[OutputNumber].Expectations[i] /= (TrainingSet[OutputNumber].Count + 1);
            }

            this.TrainingSet[OutputNumber].Add((double[])Input.Clone());
        }

        public void EndLearn()
        {
            //рассчитываю сигмы и, конечно, обучаю выходные нейроны
            //очень важно согласовать здесь все размерности массивов

            //сигмы
            foreach (RBFCell cell in this.HiddenCells)
            {
                double MinDist = double.MaxValue;
                for (int i = 0; i < this.HiddenCells.Count; i++)
                {
                    double dist = cell.Dist(HiddenCells[i].Expectations);
                    if ( (dist < MinDist) && (dist != 0) )
                    {
                        MinDist = dist;
                    }
                }
                cell.Sigma = MinDist / 2;
                if (cell.Sigma == 0) cell.Sigma = 1;
            }

            //а теперь градиентный спуск
            Random R = new Random();
            for (int i = 0; i < this.HiddenCells.Count(); i++)
            {
                this.OutputCells[i].InputWidth = this.HiddenCells.Count();
                this.OutputCells[i].InitWeights(() => 2 * R.NextDouble() - 1);
                this.OutputCells[i].Iteration = 0;
            }
            for (int i = this.HiddenCells.Count(); i < this.OutputCellCount; i++)
            {
                this.OutputCells[i].InputWidth = 0;
                this.OutputCells[i].InitWeights(() => 0);
            }

            double error;
            
            //Обучаем
            /*
            foreach (var pair in this.TrainingSet)
            {
                do
                {
                    foreach (double[] img in pair.Value)
                    {

                        double[] ResVect = new double[this.OutputCellCount];
                        ResVect[pair.Key] = 1;
                        this.Input = img;
                        this.DoWork();

                        for (int i = 0; i < this.OutputCellCount; i++)
                        {
                            double err = ResVect[i] - this.OutputCells[i].Output;
                            for (int w = 0; w < this.OutputCells[i].InputWidth; w++)
                            {
                                this.OutputCells[i].Weights[w] += err * this.OutputCells[i].Input[w] * this.LearnSpeed;
                                this.OutputCells[i].Threshoold += err * this.LearnSpeed;
                                this.OutputCells[i].Iteration++;
                            }
                        }
                    }
                    //Проверяем, насколько хорошо усвоена выборка
                    error = 0;
                    foreach (double[] img in pair.Value)
                    {
                        double[] ResVect = new double[this.OutputCellCount];
                        ResVect[pair.Key] = 1;
                        this.Input = img;
                        this.DoWork();
                        double err = RBFGrid.Dist(ResVect, this.Output) / 2;
                        if (err > error) error = err;
                    }
                } while (error > this.MaxErrorValue);
            }
            */

            //Обучаем
            do
            {
                foreach (var pair in this.TrainingSet)
                {
                    foreach (double[] img in pair.Value)
                    {
                        double[] ResVect = new double[this.OutputCellCount];
                        ResVect[pair.Key] = 1;
                        this.Input = img;
                        this.DoWork();

                        for (int i = 0; i < this.OutputCellCount; i++)
                        {
                            double err = ResVect[i] - this.OutputCells[i].Output;
                            for (int w = 0; w < this.OutputCells[i].InputWidth; w++)
                            {
                                this.OutputCells[i].Weights[w] += err * this.OutputCells[i].Input[w] * this.LearnSpeed;
                                this.OutputCells[i].Threshoold += err * this.LearnSpeed;
                                this.OutputCells[i].Iteration++;
                            }
                        }

                    }
                }
                //Проверяем, насколько хорошо усвоена выборка
                error = 0;
                foreach (var pair in this.TrainingSet)
                {
                    foreach (double[] img in pair.Value)
                    {
                        double[] ResVect = new double[this.OutputCellCount];
                        ResVect[pair.Key] = 1;
                        this.Input = img;
                        this.DoWork();
                        double err = RBFGrid.Dist(ResVect, this.Output) / 2;
                        if (err > error) error = err;
                    }
                }

            } while (error > this.MaxErrorValue);

            this.Input = null;
        }

        public double[] AVGImage(int OutputNumber)
        {
            return (double[])this.HiddenCells[OutputNumber].Expectations.Clone();
        }

        public void DoWork()
        {
            foreach(var cell in this.HiddenCells)
            {
                cell.Input = this.HiddenInput;
                cell.DoWork();
            }
            
            double[] rbfvalue = new double[this.HiddenCells.Count];
            for(int i = 0; i < this.HiddenCells.Count; i++)
                rbfvalue[i] = this.HiddenCells[i].Output;
            
            foreach (var cell in this.OutputCells)
            {
                cell.Input = rbfvalue;
                cell.DoWork();
            }

        }

        public static double Dist(double[] A, double[] B)
        {
            double dist = 0;
            for (int i = 0; i < A.Count(); i++)
            {
                double dif = (A[i] - B[i]);
                dist += dif * dif;
            }
            return dist;
        }

        public void CellReset(int index)
        {
            this.HiddenCells[index].Clear();
            this.OutputCells[index].Clear();
            this.TrainingSet[index].Clear();
        }

    }
}