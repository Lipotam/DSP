using System;

namespace DSPbase
{
    public class Perseptron
    {
        private int inputNeuronCount; 
        private int neuronesOnHiddenLayer; 
        private int outputNeuroneCount;

        public Perseptron(int inputNeuronCount, int outputNeuroneCount)
        {
            this.inputNeuronCount = inputNeuronCount;
            this.neuronesOnHiddenLayer = inputNeuronCount / 2;
            this.outputNeuroneCount = outputNeuroneCount;
           throw new NotImplementedException();
        }

        public int Ask(int[] input)
        {
            throw new NotImplementedException();
        }


        public bool Teach(int[] inputs, int answer)
        {
            throw new NotImplementedException();
        }
    }
}
