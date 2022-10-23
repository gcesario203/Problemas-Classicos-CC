using Lib.Abstractions;

namespace Cap3ProblemasDeRestricoes.Implementations
{
    public class MapColoringConstraint : Constraint<string, string>
    {
        public string _firstPlace { get; private set; }
        public string _lastPlace { get; private set; }
        public MapColoringConstraint(List<string> variables) : base(variables)
        {
            _firstPlace = variables.First();

            _lastPlace = variables.Last();
        }

        public override bool Satisfied(Dictionary<string, string> assignment)
        {
            if(!assignment.Keys.Contains(_firstPlace) || !assignment.Keys.Contains(_lastPlace))
                return true;

            return assignment[_firstPlace] != assignment[_lastPlace];
        }
    }
}