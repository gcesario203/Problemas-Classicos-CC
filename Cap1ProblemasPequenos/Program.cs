using Cap1ProblemasPequenos.TestCases;
using Lib.Implementations;

var testRunner = new ConsoleTestRunner("Capitulo 1 - Problemas pequenos",
                                        new FibonacciTestCase("Teste Fibonacci"),
                                        new GeneCompresserTestCase("Teste de compressão de bits"),
                                        new OneTimePadCryptoTestCase("Teste de criptografia inquebravel"),
                                        new PiCalculatorTestCase("Calculo de PI"),
                                        new HanoiTowerTestCase("Torre de hanoi"));

testRunner.BuildInterface();