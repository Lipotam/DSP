using System;
using System.Collections.Generic;

namespace DSPbase
{
    public class Perseptron
    {
        private int inputNeuronCount;
        private int neuronesOnHiddenLayer;
        private int outputNeuroneCount;
        private readonly Random rand = new Random();
        private int[] inputVector;
        private List<TeachingObject> teachingObjects;

        private double[,] weightsToHidden, weightsFromHidden;
        private double[] hiddenBoundary, outputBoundary;


        private double[] hiddenOutput;
        private double[] perseptronOutput;

        public Perseptron(int inputNeuronCount, int outputNeuroneCount)
        {
            this.inputNeuronCount = inputNeuronCount;
            this.neuronesOnHiddenLayer = inputNeuronCount / 2;
            this.outputNeuroneCount = outputNeuroneCount;

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
            throw new NotImplementedException();
        }


        public bool Teach()
        {

            throw new NotImplementedException();
            

            for (int i = 0; i < neuronesOnHiddenLayer; i++)
            {
                hiddenOutput[i] = HiddenInput(i);
            }
            for (int i = 0; i < outputNeuroneCount; i++)
            {
                perseptronOutput[i] = PerseptronOutput(i);
            }




           
        }

        public bool AddForTeaching(int[] inputs, int answer)
        {
            teachingObjects.Add(new TeachingObject {
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

            return result > 0 ? 1 : -1;
        }

        private double PerseptronOutput(int j)
        {
            double result = 0;

            for (int i = 0; i < outputNeuroneCount; i++)
            {
                result += hiddenOutput[i] * weightsFromHidden[i, j];
            }
            result += outputBoundary[j];

            return result > 0 ? 1 : -1;
        }
    }
}
