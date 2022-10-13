using Cap2ProblemasDeBusca.Implementations;
using Lib.Contracts;

namespace Cap2ProblemasDeBusca.TestCases
{
    public class MazeCrawler : ITestCase
    {
        public string TestName { get ; set ; }

        public MazeCrawler(string testName)
        {
            TestName = testName;
        }

        public void RunTest()
        {
            LabyrinthDestroyer.Init();
        }
    }
}