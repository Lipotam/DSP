using System.Linq;

namespace DSPbase
{
    public class HopfieldRecognizer
    {
        private readonly int size;
        private int[,] weights;
        private int[] image;

        public HopfieldRecognizer(int height, int width)
        {
        
            this.size = height * width;
            this.weights = new int[size, size];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    weights[i, j] = 0;
                }
            }
        }

        public bool TeachWithTheImage(int[] inputImage)
        {
            if (inputImage.Count() != size)
            {
                return true;
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    weights[i, j] += i != j
                        ? inputImage[i] * inputImage[j]
                        : 0;
                }
            }
            return false;
        }

        public int[] Recognize(int[] inputImage)
        {
            if (inputImage.Count() != size)
            {
                return null;
            }

            this.image = inputImage;
            bool flag = true;
            while (flag)
            {
                flag = false;
                int[] temp = new int[size];

                for (int i = 0; i < size; i++)
                {
                    int result = 0;
                    for (int j = 0; j < size; j++)
                    {
                        result += inputImage[j] * weights[i, j];
                    }
                    result = result > 0 ? 1 : -1;
                    if (result != image[i])
                    {
                        flag = true;
                    }
                    temp[i] = result;
                }
                image = temp;
            }
            return image;
        }
    }
}
