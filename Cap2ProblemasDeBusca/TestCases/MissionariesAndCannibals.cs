using System.Diagnostics;
using Cap2ProblemasDeBusca.Models;
using Lib.Contracts;
using Lib.Models;

namespace Cap2ProblemasDeBusca.TestCases
{
    public class MissionariesAndCannibals : ITestCase
    {
        private const int MAX_NUM = 3;
        public string TestName { get; set; }

        public MissionariesAndCannibals(string testName)
        {
            TestName = testName;
        }

        public void RunTest()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var initialState = new MissionariesAndCannibalsState(MAX_NUM, MAX_NUM, true);

            var solution = new Node<MissionariesAndCannibalsState>(initialState, null).BreadthFirstSearch(initialState, initialState.GoalCheck, initialState.GetSolutionSteps);

            if(solution == null)
                System.Console.WriteLine("Nenhuma solução encontrada");
            else
            {
                var path = solution.NodeToPath(solution);

                initialState.DisplayPath(path);
            }
            stopwatch.Stop();

            System.Console.WriteLine("BFS - " + stopwatch.Elapsed.ToString());

            stopwatch.Reset();

            stopwatch.Start();
            var initialState2 = new MissionariesAndCannibalsState(MAX_NUM, MAX_NUM, true);

            var solution2 = new Node<MissionariesAndCannibalsState>(initialState2, null).DeepFirstSearch(initialState2, initialState2.GoalCheck, initialState2.GetSolutionSteps);

            if (solution2 == null)
                System.Console.WriteLine("Nenhuma solução encontrada");
            else
            {
                var path = solution2.NodeToPath(solution2);

                initialState2.DisplayPath(path);
            }

            stopwatch.Stop();

            System.Console.WriteLine("DFS - " + stopwatch.Elapsed.ToString());

            stopwatch.Reset();
        }
    }
}