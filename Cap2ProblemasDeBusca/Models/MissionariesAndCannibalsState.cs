using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cap2ProblemasDeBusca.Models
{
    public class MissionariesAndCannibalsState
    {
        public const int MAX_NUM = 3;
        private int WestCannibals;
        private int EastCannibals;
        private int WestMissionaries;
        private int EastMissionaries;

        private bool Boat;

        public bool IsLegal {get {
            if(WestMissionaries < WestCannibals && WestMissionaries > 0)
                return false;

            if(EastMissionaries < EastCannibals && EastMissionaries > 0)
                return false;

            return true;
        }}

        public MissionariesAndCannibalsState(int wC, int eC, int wM, int eM, bool boat)
        {
            WestCannibals = wC;
            EastCannibals = eC;
            WestMissionaries = wM;
            EastMissionaries = eM;

            Boat = boat;
        }

        public bool GoalCheck() => IsLegal && EastCannibals == MAX_NUM && EastMissionaries == MAX_NUM;

        public override string ToString()
        {
            var str = "";

            str += $"On the west bank there are {WestCannibals} cannibals and {WestMissionaries} missionaries \n";
            str += $"On the east bank there are {EastCannibals} cannibals and {EastMissionaries} missionaries \n";
            str += $"The boat is on the {(Boat ? "West" : "East") } \n";

            return str;
        }
    }
}