using Cap1ProblemasPequenos.Models;

namespace Cap1ProblemasPequenos.Implementations
{
    public class HanoiTower
    {
        private const int NUMBER_OF_DISCS = 9;
        public Tower TowerA { get; set; } = new Tower("Tower A");
        public Tower TowerB { get; set; } = new Tower("Tower B");
        public Tower TowerC { get; set; } = new Tower("Tower C");
        public Tower TowerD { get; set; } = new Tower("Tower D");
        public Tower TowerE { get; set; } = new Tower("Tower E");
        public Tower TowerF { get; set; } = new Tower("Tower F");

        private void PopulateTowerA()
        {
            for (var i = 1; i <= NUMBER_OF_DISCS; i++)
                TowerB.Discs.Push(i);
        }

        public HanoiTower()
        {
            PopulateTowerA();

            SolveHanoi(TowerB, TowerD, NUMBER_OF_DISCS, new List<Tower> { TowerC, TowerF, TowerE,TowerA  });

            PrintTowerValues();
        }

        private void PrintTowerValues()
        {
            var towers =  this.GetType().GetProperties().Where(x => x.PropertyType == typeof(Tower));

            foreach(var tower in towers)
                System.Console.WriteLine(tower.GetValue(this).ToString());
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
                var towerWithMoreDiscs = intermediateTowers.FirstOrDefault(tower => tower.TotalDiscs == intermediateTowers.Max(x => x.TotalDiscs));
                var towerWithLessDiscs = intermediateTowers.FirstOrDefault(tower => tower.TotalDiscs == intermediateTowers.Min(x => x.TotalDiscs));

                SolveHanoi(initTower, towerWithLessDiscs, numberOfDiscs - 1, new List<Tower> { endTower });
                SolveHanoi(initTower, endTower, 1, intermediateTowers);
                SolveHanoi(towerWithMoreDiscs, endTower, numberOfDiscs - 1, new List<Tower> { initTower });

            }
        }
    }
}