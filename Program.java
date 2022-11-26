public class Program {
    public static void main(String[] args) {
        // Inputs
        int[][] inputPatterns = new int[][] {
            { 0, 0 }, { 0, 1 }, { 1, 0 }, { 1, 1 }
        };
        
        // Output
        int[] desired = new int[] { 0, 1, 1, 1 };

        // Props
        double learningRate = 0.1;
        double delta, error;

        int maxEpoch = 50;
        int currentEpoch = 0;

        double w1 = Math.random();
        double w2 = Math.random();
        double bias = Math.random();

        do {
            // Reset error
            error = 0;

            // For every Inputs
            for (int i = 0; i < inputPatterns.length; i++) {
                double v = 0;
                double output = 0;

                // perform summation
                
                int x1 = inputPatterns[i][0];
                int x2 = inputPatterns[i][1];

                v = x1 * w1 + x2 * w2 + bias;

                // Activation function: binary-step function 
                // using ternary operator 
  
                output = v >= 0 ? 1 : 0;
                
                // Get delta
                delta = desired[i] - output;
                // Get absolute value of delta
                // and add it to the error
                error += Math.abs(delta);

                System.out.printf("v = %f, delta = %.2f, error = %.2f\n", v, delta, error);

                if (delta != 0) {
                    w1 += learningRate * delta * x1;
                    w2 += learningRate * delta * x2;
                    bias += learningRate * delta;
                }
            }
  
            System.out.printf("Epoch# %d is finished! error = %.2f\n", currentEpoch, error);
            currentEpoch++;
        } while (currentEpoch < maxEpoch && error > 0);

        // Testing 
        int testX1 = 0;
        int testX2 = 0;
        double testV = testX1 * w1 + testX2 * w2 + bias;

        if (testV >= 0) {
          System.out.println("TRUE");
        } else {
          System.out.println("FALSE");
        }
    }
}
