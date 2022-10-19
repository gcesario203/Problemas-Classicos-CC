using Cap2ProblemasDeBusca.Models;
using Lib.Contracts;
using Lib.Models;

namespace Cap2ProblemasDeBusca.TestCases
{
    public class MissionariesAndCannibals : ITestCase
    {
        private const int MAX_NUM = 3;
        public string TestName { get ; set ; }

        public MissionariesAndCannibals(string testName)
        {
            TestName = testName;
        }

        public void RunTest()
        {
            var initialState = new MissionariesAndCannibalsState(MAX_NUM, MAX_NUM, true);

            var solution = new Node<MissionariesAndCannibalsState>(initialState, null).BreadthFirstSearch(initialState, initialState.GoalCheck, initialState.GetSolutionSteps);

            if(solution == null)
                System.Console.WriteLine("Nenhuma solução encontrada");
            else
            {
                var path = solution.NodeToPath(solution);

                initialState.DisplayPath(path);
            }
        }
    }
}