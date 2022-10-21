using Lib.Abstractions;
using Lib.Contracts;

namespace Lib.Implementations
{
    public class ConsoleTestRunner : BaseTestRunner
    {
        private bool RunningFlag;

        private HashSet<string> EnableChoices = new HashSet<string> { "0" };
        public ConsoleTestRunner(string testName, params ITestCase[] testCases)
        {
            TestName = testName;
            TestCases = testCases;
        }

        public override void BuildInterface()
        {
            RunningFlag = true;

            while (RunningFlag == true)
            {
                System.Console.WriteLine($"{TestName} Iniciado!");
                System.Console.WriteLine("Selecione uma das opções para rodar");

                BuildMenuOptions();

                var choice = Console.ReadLine();

                if (string.IsNullOrEmpty(choice) || !EnableChoices.Contains(choice))
                {
                    System.Console.WriteLine("Selecione uma opção valida!");
                    continue;
                }

                if (choice == "0")
                {
                    RunningFlag = false;
                    continue;
                }

                TestCases.ToArray()[int.Parse(choice) - 1].RunTest();
            }
        }

        private void BuildMenuOptions()
        {
            if (TestCases == null)
                return;

            for (var i = 0; i < TestCases.Count(); i++)
            {
                EnableChoices.Add((i + 1).ToString());
                System.Console.WriteLine($"{i + 1} - {TestCases.ToArray()[i].TestName}");
            };


            System.Console.WriteLine("0 - Finalizar aplicação");
        }
    }
}