using Cap1ProblemasPequenos.Models;

namespace Cap1ProblemasPequenos.Implementations
{
    public class HanoiTower
    {
        private const int NUMBER_OF_DISCS = 3;
        private Tower TowerA { get; set; } = new Tower("Tower A");
        private Tower TowerB { get; set; } = new Tower("Tower B");
        private Tower TowerC { get; set; } = new Tower("Tower C");
        private Tower TowerD { get; set; } = new Tower("Tower D");
        private Tower TowerE { get; set; } = new Tower("Tower E");
        private Tower TowerF { get; set; } = new Tower("Tower F");

        private void PopulateTowerA()
        {
            for (var i = 1; i <= NUMBER_OF_DISCS; i++)
                TowerA.Discs.Push(i);
        }

        public HanoiTower()
        {
            PopulateTowerA();

            SolveHanoi(TowerA, TowerD, NUMBER_OF_DISCS, new List<Tower> { TowerC, TowerF, TowerE, TowerB });

            System.Console.WriteLine("TORRE A " + String.Join(" ", TowerA.Discs));
            System.Console.WriteLine("TORRE B " + String.Join(" ", TowerB.Discs));
            System.Console.WriteLine("TORRE C " + String.Join(" ", TowerC.Discs));
            System.Console.WriteLine("TORRE D " + String.Join(" ", TowerD.Discs));
            System.Console.WriteLine("TORRE E " + String.Join(" ", TowerE.Discs));
            System.Console.WriteLine("TORRE F " + String.Join(" ", TowerF.Discs));
        }

        public void SolveHanoi(Tower initTower, Tower endTower, int numberOfDiscs, IEnumerable<Tower> intermediateTowers)
        {
            if (numberOfDiscs == 1)
            {
                if (initTower.Discs.TryPop(out var result))
                {
                    System.Console.WriteLine($"Saiu da torre {initTower.Name} o valor {result}");
                    endTower.Discs.Push(result);
                    System.Console.WriteLine($"Entrou da torre {endTower.Name} o valor {result}");
                }
            }
            else
            {
                foreach (var intermediumTower in intermediateTowers)
                {
                    SolveHanoi(initTower, intermediumTower, numberOfDiscs - 1, new List<Tower> { endTower });
                    SolveHanoi(initTower, endTower, 1, intermediateTowers);
                    SolveHanoi(intermediumTower, endTower, numberOfDiscs - 1, new List<Tower> { initTower });
                }
            }
        }
    }
}