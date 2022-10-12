using Cap1ProblemasPequenos.Implementations;
using Lib.Contracts;

namespace Cap1ProblemasPequenos.TestCases
{
    public class PiCalculatorTestCase : ITestCase
    {
        public string TestName { get ; set ; }

        public PiCalculatorTestCase(string testName)
        {
            TestName = testName;
        }

        public void RunTest()
        {
            System.Console.WriteLine(PiCalculator.CalculatePi(1000000));
        }
    }
}