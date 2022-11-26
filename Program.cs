using System;

namespace Perceptron
{
    class Program
    {
        public static void Main(string[] args)
        {
            //initialize variables
            //int[][] input_patterns = new int[4][2];  <-- java people
            int[,] input_patterns = new int[4,2];
            int[] desired = new int[4];
            double learning_rate = 0.1;
            double delta, error;
            double w1, w2, bias;
            int max_epoch = 50, curr_epoch = 0;
            Random rand = new Random();

            input_patterns[0, 0] = 0;
            input_patterns[0, 1] = 0;
            desired[0] = 0;

            input_patterns[1, 0] = 1;
            input_patterns[1, 1] = 0;
            desired[1] = 1;

            input_patterns[2, 0] = 0;
            input_patterns[2, 1] = 1;
            desired[2] = 1;

            input_patterns[3, 0] = 1;
            input_patterns[3, 1] = 1;
            desired[3] = 1;

            //randomize the weights
            w1 = rand.NextDouble();
            w2 = rand.NextDouble();
            bias = rand.NextDouble();

            //continue learning until (1) error > 0 (2) current epoch < max_epoch
            do
            {
                error = 0;
                for (int i = 0; i < 4; i++)
                {
                    double v = 0;
                    double output = 0;
                    //perform the actual summation function
                    int x1 = input_patterns[i, 0];
                    int x2 = input_patterns[i, 1];

                    v = x1 * w1 + x2 * w2 + bias;

                    //activation function: binary step function
                    if (v >= 0)
                    {
                        output = 1;
                    }
                    else
                    {
                        output = 0;
                    }

                    delta = desired[i] - output;
                    error += Math.Abs(delta);

                    Console.WriteLine("v = {0}, delta = {1}, error = {2}",v,delta,error);
                    //network learning procedure
                    if (delta != 0)
                    {
                        w1 += learning_rate * delta * x1;
                        w2 += learning_rate * delta * x2;
                        bias += learning_rate * delta;
                    }
                }
                Console.WriteLine("Epoch# {0} is finished! error = {1}", curr_epoch, error);
                curr_epoch++;
            } while (curr_epoch < max_epoch && error > 0);

            //testing
            int test_x1 = 0;
            int test_x2 = 0;
            double test_v;

            test_v = test_x1 * w1 + test_x2 * w2 + bias;

            if(test_v >= 0)
            {
                Console.WriteLine("TRUE");
            }
            else
            {
                Console.WriteLine("FALSE");
            }
        }
    }

}

