using Lib.Abstractions;

namespace Cap3ProblemasDeRestricoes.Implementations
{
    public class QueensConstraint : Constraint<int, int>
    {
        public List<int> Columns { get; private set; }
        public QueensConstraint(List<int> variables) : base(variables)
        {
            Columns = variables;
        }

        public override bool Satisfied(Dictionary<int, int> assignment)
        {
            foreach(var assignmentKeyValuePair in assignment)
            {
                var queenColumnsRange = Enumerable.Range(assignmentKeyValuePair.Key + 1, Columns.Count + 1).ToList();

                foreach(var column in queenColumnsRange)
                {
                    if(assignment.Keys.Contains(column))
                    {
                        var newPosition = assignment[column];

                        if(assignmentKeyValuePair.Value == newPosition)
                            return false;

                        if(Math.Abs(assignmentKeyValuePair.Value - newPosition) == Math.Abs(assignmentKeyValuePair.Key - column))
                            return false;
                    }
                }
            }

            return true;
        }
    }
}