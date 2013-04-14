using System;
using System.Collections.Generic;

namespace DSPbase
{
    public class CompetitiveNet
    {
        private readonly int inputCount;
        private int[] inputVector;
        private readonly int outputClassCount;
        private readonly Random rand = new Random();
        private List<TeachingObject> teachingObjects;
        private int[] winsCount;
        private double[,] weights;
        private double betta = 0.3;

        private double[] netOutput;

        public CompetitiveNet(int inputCount, int outputClassCount)
        {
            this.inputCount = inputCount;
            this.outputClassCount = outputClassCount;

            this.weights = new double[inputCount, outputClassCount];

            this.netOutput = new double[outputClassCount];
            this.winsCount = new int[outputClassCount];

            for (int i = 0; i < outputClassCount; i++)
            {
                for (int j = 0; j < inputCount; j++)
                {
                    this.weights[j, i] = rand.NextDouble()  ;
                }
                winsCount[i] = 0;
            }

            teachingObjects = new List<TeachingObject>();
        }

        public int Ask(int[] input)
        {
            inputVector = input;
            GetOutput(input);
            double resultValue = this.netOutput[0];
            int result = 0;
            for (int i = 1; i < this.outputClassCount; i++)
            {
                if (this.netOutput[i] > resultValue)
                {
                    resultValue = this.netOutput[i];
                    result = i;
                }
            }
            return result;
        }

        private void GetOutput(int[] inputs)
        {

            for (int j = 0; j < this.outputClassCount; j++)
            {
                this.netOutput[j] = 0;
                for (int i = 0; i < inputCount; i++)
                {
                    this.netOutput[j] += weights[i, j] * inputs[i];
                }
            }
        }

        public bool Teach()
        {
            foreach (TeachingObject image in teachingObjects)
            {
                inputVector = image.InputVector;
                GetOutput(image.InputVector);
                int bestIndex = GetBest();
                ChangeWeights(bestIndex);

            }

            return false;
        }

        private void ChangeWeights(int index)
        {
            for (int i = 0; i < inputCount; i++)
            {
                weights[i, index] += betta * (inputVector[i] - weights[i, index]);
            }
        }
        private int GetBest()
        {
            int result = 0;
            double[] distances = new double[outputClassCount];

            for (int j = 0; j < this.outputClassCount; j++)
            {
                distances[j] = 0;
                for (int i = 0; i < inputCount; i++)
                {
                    distances[j] += (weights[i, j] - inputVector[i]) * (weights[i, j] - inputVector[i]);
                }
                distances[j] = Math.Sqrt(distances[j])* winsCount[j];
            }

            double minValue = distances[0];
            for (int i = 1; i < this.outputClassCount; i++)
            {
                if (minValue > distances[i])
                {
                    minValue = distances[i];
                    result = i;
                }
            }

            winsCount[result]++;
            return result;
        }

        public bool AddForTeaching(int[] inputs, int answer)
        {
            teachingObjects.Add(new TeachingObject
            {
                GroupNumber = answer,
                InputVector = inputs
            });

            return false;
        }
    }
}