using Cap1ProblemasPequenos.TestCases;
using Lib.Implementations;

var testRunner = new ConsoleTestRunner("Capitulo 1 - Problemas pequenos",
                                        new FibonacciTestCase("Teste Fibonacci"));

testRunner.BuildInterface();