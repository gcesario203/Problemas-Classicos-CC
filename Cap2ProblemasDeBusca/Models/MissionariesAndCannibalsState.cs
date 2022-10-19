namespace Cap2ProblemasDeBusca.Models
{
    public class MissionariesAndCannibalsState : IEquatable<MissionariesAndCannibalsState>
    {
        private Guid Id;
        public const int MAX_NUM = 3;
        private int WestCannibals;
        private int EastCannibals;
        private int WestMissionaries;
        private int EastMissionaries;

        private bool Boat;

        public bool IsLegal
        {
            get
            {
                if (WestMissionaries < WestCannibals && WestMissionaries > 0)
                    return false;

                if (EastMissionaries < EastCannibals && EastMissionaries > 0)
                    return false;

                return true;
            }
        }

        public MissionariesAndCannibalsState(int numberOfMissionaries, int numberOfCannibals, bool boat)
        {

            EastCannibals = MAX_NUM - numberOfCannibals;
            EastMissionaries = MAX_NUM - numberOfMissionaries;

            WestMissionaries = numberOfMissionaries;
            WestCannibals = numberOfCannibals;

            Boat = boat;

            Id = Guid.NewGuid();
        }

        public bool GoalCheck(MissionariesAndCannibalsState currentState)
            => currentState.IsLegal && currentState.EastCannibals == MAX_NUM && currentState.EastMissionaries == MAX_NUM;

        public IEnumerable<MissionariesAndCannibalsState> GetSolutionSteps(MissionariesAndCannibalsState currentState)
        {
            var sucessors = new List<MissionariesAndCannibalsState>();

            if (currentState.Boat)
            {
                if (currentState.WestMissionaries > 1)
                    sucessors.Add(new MissionariesAndCannibalsState(currentState.WestMissionaries - 2, currentState.WestCannibals, !currentState.Boat));
                if (currentState.WestMissionaries > 0)
                    sucessors.Add(new MissionariesAndCannibalsState(currentState.WestMissionaries - 1, currentState.WestCannibals, !currentState.Boat));
                if (currentState.WestCannibals > 1)
                    sucessors.Add(new MissionariesAndCannibalsState(currentState.WestMissionaries, currentState.WestCannibals - 2, !currentState.Boat));
                if (currentState.WestCannibals > 0)
                    sucessors.Add(new MissionariesAndCannibalsState(currentState.WestMissionaries, currentState.WestCannibals - 1, !currentState.Boat));
                if (currentState.WestCannibals > 0 && currentState.WestMissionaries > 0)
                    sucessors.Add(new MissionariesAndCannibalsState(currentState.WestMissionaries - 1, currentState.WestCannibals - 1, !currentState.Boat));
            }
            else
            {
                if (currentState.EastMissionaries > 1)
                    sucessors.Add(new MissionariesAndCannibalsState(currentState.WestMissionaries + 2, currentState.WestCannibals, !currentState.Boat));
                if (currentState.EastMissionaries > 0)
                    sucessors.Add(new MissionariesAndCannibalsState(currentState.WestMissionaries + 1, currentState.WestCannibals, !currentState.Boat));
                if (currentState.EastCannibals > 1)
                    sucessors.Add(new MissionariesAndCannibalsState(currentState.WestMissionaries, currentState.WestCannibals + 2, !currentState.Boat));
                if (currentState.EastCannibals > 0)
                    sucessors.Add(new MissionariesAndCannibalsState(currentState.WestMissionaries, currentState.WestCannibals + 1, !currentState.Boat));
                if (currentState.EastCannibals > 0 && currentState.EastMissionaries > 0)
                    sucessors.Add(new MissionariesAndCannibalsState(currentState.WestMissionaries + 1, currentState.WestCannibals + 1, !currentState.Boat));
            }

            return sucessors.Where(x => x.IsLegal).ToList();
        }

        public void DisplayPath(IEnumerable<MissionariesAndCannibalsState> path)
        {
            if (path.Count() == 0)
                return;

            var initialState = path.First();

            path = path.Where(x => x.Id != initialState.Id).ToList();

            System.Console.WriteLine(initialState.ToString());

            foreach (var currentState in path)
            {
                if (currentState.Boat)
                    System.Console.WriteLine($"{initialState.EastCannibals - currentState.EastCannibals} Cannibals {initialState.EastMissionaries - currentState.EastMissionaries} Missionaries moved from the east to the west bank\n");
                else
                    System.Console.WriteLine($"{initialState.WestCannibals - currentState.WestCannibals} Cannibals {initialState.WestMissionaries - currentState.WestMissionaries} Missionaries moved from the west to the east bank\n");

                System.Console.WriteLine(currentState.ToString());

                initialState = currentState;
            }
        }

        public override string ToString()
        {
            var str = "";

            str += $"On the west bank there are {WestCannibals} cannibals and {WestMissionaries} missionaries \n";
            str += $"On the east bank there are {EastCannibals} cannibals and {EastMissionaries} missionaries \n";
            str += $"The boat is on the {(Boat ? "West" : "East")} \n";

            return str;
        }

        public bool Equals(MissionariesAndCannibalsState? other)
        => WestCannibals == other.WestCannibals && EastCannibals == other.EastCannibals && WestMissionaries == other.WestMissionaries && EastMissionaries == other.EastMissionaries && Boat == other.Boat;
    }
}