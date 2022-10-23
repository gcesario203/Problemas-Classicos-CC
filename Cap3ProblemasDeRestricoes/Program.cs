using Cap3ProblemasDeRestricoes.TestCases;
using Lib.Implementations;

new ConsoleTestRunner("Capitulo 3 - Problemas de restrições",
                        new MapColoring("Colorindo o mapa de São Paulo"),
                        new Queens("Problema das 8 rainhas")
                      )
                    .BuildInterface();