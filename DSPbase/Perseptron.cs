using System;
using System.Collections.Generic;

namespace DSPbase
{
    public class Perseptron
    {
        private readonly int inputNeuronCount;
        private readonly int neuronesOnHiddenLayer;
        private readonly int outputNeuroneCount;
        private readonly Random rand = new Random();
        private int[] inputVector;
        private List<TeachingObject> teachingObjects;
        private readonly double alpha, beta, mistakeDistance;

        private double[,] weightsToHidden, weightsFromHidden;
        private double[] hiddenBoundary, outputBoundary;

        private double[] hiddenOutput;
        private double[] perseptronOutput;

        public Perseptron(int inputNeuronCount, int outputNeuroneCount, double alpha, double beta, double mistakeDistance)
        {
            this.inputNeuronCount = inputNeuronCount;
            this.neuronesOnHiddenLayer = inputNeuronCount / 2;
            this.outputNeuroneCount = outputNeuroneCount;

            this.alpha = alpha;
            this.beta = beta;
            this.mistakeDistance = mistakeDistance;

            this.weightsToHidden = new double[inputNeuronCount, neuronesOnHiddenLayer];
            this.weightsFromHidden = new double[neuronesOnHiddenLayer, outputNeuroneCount];
            this.hiddenBoundary = new double[neuronesOnHiddenLayer];

            this.hiddenOutput = new double[neuronesOnHiddenLayer];
            this.perseptronOutput = new double[outputNeuroneCount];


            for (int i = 0; i < neuronesOnHiddenLayer; i++)
            {
                for (int j = 0; j < inputNeuronCount; j++)
                {
                    this.weightsToHidden[j, i] = rand.NextDouble() * 2 - 1;
                }
                for (int j = 0; j < outputNeuroneCount; j++)
                {
                    this.weightsFromHidden[i, j] = rand.NextDouble() * 2 - 1;
                }
                this.hiddenBoundary[i] = rand.NextDouble() * 2 - 1;
            }

            this.outputBoundary = new double[outputNeuroneCount];
            for (int j = 0; j < outputNeuroneCount; j++)
            {
                this.outputBoundary[j] = rand.NextDouble() * 2 - 1;
            }

            teachingObjects = new List<TeachingObject>();
        }

        public int Ask(int[] input)
        {
            inputVector = input;
            CountHiddenOutput();
            CountOutput();
            double resultValue = perseptronOutput[0];
            int result = 0;
            for (int i = 1; i < outputNeuroneCount; i++)
            {
                if (perseptronOutput[i] > resultValue)
                {
                    resultValue = perseptronOutput[i];
                    result = i;
                }
            }
            return result;
        }


        public bool Teach()
        {
            foreach (TeachingObject image in teachingObjects)
            {
                inputVector = image.InputVector;
                CountHiddenOutput();
                CountOutput();

                for (int i = 0; i < outputNeuroneCount; i++)
                {
                    int iterationCount = 0;
                    while (HasMistake(i, image.GroupNumber) && iterationCount < 20)
                    {
                        Correct(i, image);
                        iterationCount++;
                        CountHiddenOutput();
                        CountOutput();
                    }
                }
            }

            return false;
        }

        private void Correct(int k, TeachingObject image)
        {
            for (int i = 0; i < neuronesOnHiddenLayer; i++)
            {
                weightsFromHidden[i, k] += GetHiddenOutputCorrection(k, image.GroupNumber) * hiddenOutput[i];
            }

            outputBoundary[k] += GetHiddenOutputCorrection(k, image.GroupNumber);

            for (int j = 0; j < neuronesOnHiddenLayer; j++)
            {
                for (int i = 0; i < inputNeuronCount; i++)
                {
                    weightsToHidden[i, j] += GetHiddenInputCorrection(j, image.GroupNumber) * inputVector[i];
                }
                hiddenBoundary[j] += GetHiddenInputCorrection(j, image.GroupNumber);
            }
        }

        private double GetHiddenOutputCorrection(int k, double groupID)
        {
            return alpha * perseptronOutput[k] * (1 - perseptronOutput[k]) * this.GetDistance(k, groupID);
        }

        private double GetHiddenInputCorrection(int j, double groupID)
        {
            return beta * hiddenOutput[j] * (1 - hiddenOutput[j]) * GetHiddenDistance(j, groupID);
        }


        private double GetDistance(int j, double rightAnswer)
        {
            if (j == rightAnswer)
            {
                return 1- perseptronOutput[j];
            }
            return  0 -perseptronOutput[j];
        }

        private double GetAbsoluteDistance(int j, double rightAnswer)
        {
            if (j == rightAnswer)
            {
                return Math.Abs(perseptronOutput[j] - 1);
            }
            return Math.Abs(perseptronOutput[j] - 0);
        }


        private double GetHiddenDistance(int j, double rightAnswer)
        {
            double result = 0;

            for (int i = 0; i < outputNeuroneCount; i++)
            {
                result += this.GetDistance(i, rightAnswer) * perseptronOutput[i] * (1 - perseptronOutput[i]) * weightsToHidden[j, i];
            }

            return result;
        }
        private bool HasMistake(int j, double rightAnswer)
        {
            if (this.GetAbsoluteDistance(j, rightAnswer) > mistakeDistance)
            {
                return true;
            }
            return false;
        }
        public bool AddForTeaching(int[] inputs, int answer)
        {

            for (int i = 0; i < inputNeuronCount; i++)
            {
                inputs[i] = inputs[i] == -1 ? 0 : 1;
            }
            teachingObjects.Add(new TeachingObject
            {
                GroupNumber = answer,
                InputVector = inputs
            });

            return false;
        }

        private double HiddenInput(int j)
        {
            double result = 0;

            for (int i = 0; i < neuronesOnHiddenLayer; i++)
            {
                result += inputVector[i] * weightsToHidden[i, j];
            }
            result += hiddenBoundary[j];

            return SigmaFunction(result);
        }

        private double PerseptronOutput(int j)
        {
            double result = 0;

            for (int i = 0; i < outputNeuroneCount; i++)
            {
                result += hiddenOutput[i] * weightsFromHidden[i, j];
            }
            result += outputBoundary[j];

            return SigmaFunction(result);
        }

        private void CountHiddenOutput()
        {
            for (int i = 0; i < neuronesOnHiddenLayer; i++)
            {
                hiddenOutput[i] = HiddenInput(i);
            }
        }

        private double SigmaFunction(double input)
        {
            return 1 / (1 + Math.Exp(-1 * input));
        }

        private void CountOutput()
        {
            for (int i = 0; i < outputNeuroneCount; i++)
            {
                perseptronOutput[i] = PerseptronOutput(i);
            }
        }
    }
}