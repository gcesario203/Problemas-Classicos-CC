using Cap1ProblemasPequenos.Implementations;
using Lib.Contracts;

namespace Cap1ProblemasPequenos.TestCases
{
    public class GeneCompresserTestCase : ITestCase
    {
        public string TestName { get; set; }

        public GeneCompresserTestCase(string testName)
        {
            TestName = testName;
        }

        public void RunTest()
        {
            new GeneCompresser("TTTAAACGTACGTT");
        }
    }
}