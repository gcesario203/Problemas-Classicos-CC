using Cap2ProblemasDeBusca.TestCases;
using Lib.Implementations;

var testRunner = new ConsoleTestRunner("Capitulo 2 - Problemas de busca",
                                        new DnaSearch("Busca linear em Gene"));

testRunner.BuildInterface();