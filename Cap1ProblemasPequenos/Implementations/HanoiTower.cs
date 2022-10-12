namespace Cap1ProblemasPequenos.Implementations
{
    public class HanoiTower
    {
        private const int NUMBER_OF_DISCS = 9;
        private Stack<int> TowerA { get; set; } = new Stack<int>();
        private Stack<int> TowerB { get; set; } = new Stack<int>();
        private Stack<int> TowerC { get; set; } = new Stack<int>();

        private void PopulateTowerA()
        {
            for (var i = 1; i <= NUMBER_OF_DISCS; i++)
                TowerA.Push(i);
        }

        public HanoiTower()
        {
            PopulateTowerA();

            SolveHanoi(TowerA, TowerB, TowerC, NUMBER_OF_DISCS);

            System.Console.WriteLine("TORRE A " + String.Join(" ", TowerA));
            System.Console.WriteLine("TORRE B " + String.Join(" ", TowerB));
            System.Console.WriteLine("TORRE C " + String.Join(" ", TowerC));
        }

        public void SolveHanoi(Stack<int> initTower, Stack<int> endTower, Stack<int> intermediumTower, int numberOfDiscs)
        {
            if (numberOfDiscs == 1)
            {
                if (initTower.TryPop(out var result))
                    endTower.Push(result);
            }
            else
            {
                SolveHanoi(initTower, intermediumTower, endTower, numberOfDiscs - 1);
                SolveHanoi(initTower, endTower, intermediumTower, 1);
                SolveHanoi(intermediumTower, endTower, initTower, numberOfDiscs - 1);
            }
        }
    }
}