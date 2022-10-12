namespace Cap1ProblemasPequenos.Implementations
{
    public static class PiCalculator
    {
        public static float CalculatePi(int numberOfTerms)
        {
            var constant = 4f;
            var denominator = 1f;

            var operation = 1f;

            var piAccumulator = 0f;

            for (var i = 0; i <= numberOfTerms; i++)
            {
                piAccumulator += operation * (constant / denominator);

                denominator += 2f;

                operation *= -1f;
            }

            return piAccumulator;
        }
    }
}