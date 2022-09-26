using System.Diagnostics;
using Cap1ProblemasPequenos.Implementations;
using Lib.Contracts;

namespace Cap1ProblemasPequenos.TestCases
{
    public class FibonacciTestCase : ITestCase
    {
        public string TestName { get; set; }

        public FibonacciTestCase(string testName)
        {
            TestName = testName;
        }

        public void RunTest()
        {
            var fibonacci = new Fibonacci();

            var cronometro1 = new Stopwatch();
            var cronometro2 = new Stopwatch();

            System.Console.WriteLine("Iniciando iteração sequencia fibonacci de forma iterativa - fibonacci.HandleFibonacciSequenceIterative(10000)");
            cronometro1.Start();
            var teste = fibonacci.HandleFibonacciSequenceIterative(10000).LastOrDefault();
            System.Console.WriteLine(teste);
            cronometro1.Stop();
            System.Console.WriteLine("Fim da iteração");

            System.Console.WriteLine("Iniciando iteração sequencia fibonacci de forma Recursiva - fibonacci.HandleFibonacciSequenceRecursive(10000)");
            cronometro2.Start();
            var teste2 = fibonacci.HandleFibonacciSequenceRecursive(10000);
            System.Console.WriteLine(teste2);
            cronometro2.Stop();
            System.Console.WriteLine("Fim da Recursão");

            System.Console.WriteLine($"Iteração {cronometro1.Elapsed.ToString()}");
            System.Console.WriteLine($"Recursão {cronometro2.Elapsed.ToString()}");
        }
    }
}