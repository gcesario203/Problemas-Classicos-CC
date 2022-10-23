using static Cap3ProblemasDeRestricoes.Enums.SpZones;
using Cap3ProblemasDeRestricoes.Implementations;
using Lib.Contracts;
using Lib.Implementations;

namespace Cap3ProblemasDeRestricoes.TestCases
{
    public class Queens : ITestCase
    {
        public string TestName { get; set; }

        public Queens(string testName)
        {
            TestName = testName;
        }

        public void RunTest()
        {
            var columns = Enumerable.Range(1, 8).ToList();

            var rows = new Dictionary<int, List<int>>();

            foreach (var column in columns)
                rows.Add(column, Enumerable.Range(1, 8).ToList());

            var _csp = new CSP<int, int>(columns, rows);

            _csp.AddConstraint(new QueensConstraint(columns));

            var solution = _csp.BackTrackingSearch();

            if (solution == null)
                System.Console.WriteLine("Sem solução!");
            else
                foreach (var solutionItem in solution)
                    System.Console.WriteLine($"COluna: {solutionItem.Key} - Linha: {solutionItem.Value}");
        }
    }
}