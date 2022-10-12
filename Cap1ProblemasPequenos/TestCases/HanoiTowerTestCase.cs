using Cap1ProblemasPequenos.Implementations;
using Lib.Contracts;

namespace Cap1ProblemasPequenos.TestCases
{
    public class HanoiTowerTestCase : ITestCase
    {
        public string TestName { get; set; }

        public HanoiTowerTestCase(string testName)
        {
            TestName = testName;
        }

        public void RunTest()
        {
            var teste = new HanoiTower();
        }
    }
}