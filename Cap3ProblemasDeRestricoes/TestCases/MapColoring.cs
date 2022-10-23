using static Cap3ProblemasDeRestricoes.Enums.SpZones;
using Cap3ProblemasDeRestricoes.Implementations;
using Lib.Contracts;
using Lib.Implementations;

namespace Cap3ProblemasDeRestricoes.TestCases
{
    public class MapColoring : ITestCase
    {
        public string TestName { get; set; }

        public MapColoring(string testName)
        {
            TestName = testName;
        }

        public void RunTest()
        {
            var variables = new List<string>{
                SOUTH_ZONE,
                WEST_ZONE,
                NORTH_ZONE,
                EAST_ZONE,
            };

            var domains = new Dictionary<string, List<string>>();

            foreach (var variable in variables)
                domains.Add(variable, new List<string> { "red", "green", "blue" });

            var _csp = new CSP<string, string>(variables, domains);

            _csp.AddConstraint(new MapColoringConstraint(new List<string> { SOUTH_ZONE, WEST_ZONE }));
            _csp.AddConstraint(new MapColoringConstraint(new List<string> { NORTH_ZONE, EAST_ZONE }));

            var solution = _csp.BackTrackingSearch();

            if (solution == null)
                System.Console.WriteLine("Sem solução!");
            else
                foreach (var solutionItem in solution)
                    System.Console.WriteLine($"Zona: {solutionItem.Key} - Cor: {solutionItem.Value}");
        }
    }
}