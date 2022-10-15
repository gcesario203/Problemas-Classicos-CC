using Cap2ProblemasDeBusca.Enums;

namespace Cap2ProblemasDeBusca.Models
{
    public class Maze
    {
        private int Rows;
        private int Columns;
        public LabyrinthLocation Start { get; set; }

        public LabyrinthLocation Goal { get; set; }

        private List<List<string>> Grid = new List<List<string>>();

        public float Sparseness { get; set; }

        public Maze()
        {
            
        }
        public Maze(LabyrinthLocation start,
                    LabyrinthLocation goal,
                    int rows = 10,
                    int columns = 10,
                    float sparseness = 0.2f)
        {
            Start = start == null ? new LabyrinthLocation(0, 0) : start;
            Goal = goal == null ? new LabyrinthLocation(rows - 1, columns - 1) : goal;
            Rows = rows;
            Columns = columns;
            Sparseness = sparseness;

            for (var x = 0; x < Rows; x++)
            {
                Grid.Add(new List<string>());
                for (var y = 0; y < Columns; y++)
                    Grid[x].Add(LabyrinthCell.EMPTY);
            }

            RandomFill(Rows, Columns, Sparseness);

            Grid[Start.Row][Start.Column] = LabyrinthCell.START;
            Grid[Goal.Row][Goal.Column] = LabyrinthCell.GOAL;
        }

        private void RandomFill(int rows, int columns, float sparseness)
        {
            for (var x = 0; x < rows; x++)
            {
                for (var y = 0; y < columns; y++)
                {
                    var random = new Random();
                    if (random.Next((int)Sparseness * 100, 100) < Sparseness * 100)
                        Grid[x][y] = LabyrinthCell.BLOCKED;
                }
            }
        }

        public List<LabyrinthLocation> GetSuccessors(LabyrinthLocation location)
        {
            var returnLocation = new List<LabyrinthLocation>();

            if (location.Row + 1 < this.Rows && Grid[location.Row + 1][location.Column] != LabyrinthCell.BLOCKED)
                returnLocation.Add(new LabyrinthLocation(location.Row + 1, location.Column));

            if (location.Row - 1 >= 0 && Grid[location.Row - 1][location.Column] != LabyrinthCell.BLOCKED)
                returnLocation.Add(new LabyrinthLocation(location.Row - 1, location.Column));

            if (location.Column + 1 < this.Columns && Grid[location.Row][location.Column + 1] != LabyrinthCell.BLOCKED)
                returnLocation.Add(new LabyrinthLocation(location.Row, location.Column + 1));

            if (location.Column - 1 >= 0 && Grid[location.Row][location.Column - 1] != LabyrinthCell.BLOCKED)
                returnLocation.Add(new LabyrinthLocation(location.Row, location.Column - 1));

            return returnLocation;
        }
        public bool GotToTheGoal(LabyrinthLocation location) => Goal.Equals(location);

        public void Mark(List<LabyrinthLocation> path)
        {
            foreach (var location in path)
                Grid[location.Row][location.Column] = LabyrinthCell.PATH;

            Grid[Start.Row][Start.Column] = LabyrinthCell.START;
            Grid[Goal.Row][Goal.Column] = LabyrinthCell.GOAL;
        }

        public void Clear(List<LabyrinthLocation> path)
        {
            foreach (var location in path)
                Grid[location.Row][location.Column] = LabyrinthCell.EMPTY;

            Grid[Start.Row][Start.Column] = LabyrinthCell.START;
            Grid[Goal.Row][Goal.Column] = LabyrinthCell.GOAL;
        }

        public double EuclidianDistance(LabyrinthLocation actualLocation, LabyrinthLocation locationToCompare)
        {
            var xDelta = actualLocation.Column - locationToCompare.Column;
            var yDelta = actualLocation.Row - locationToCompare.Row;

            return (Math.Sqrt((xDelta * xDelta) + (yDelta * yDelta)));
        }

        public double ManhattanDistance(LabyrinthLocation actualLocation, LabyrinthLocation locationToCompare)
        {
            var xDelta = Math.Abs(actualLocation.Column - locationToCompare.Column);
            var yDelta = Math.Abs(actualLocation.Row - locationToCompare.Row);

            return (xDelta + yDelta);
        }

        public override string ToString()
        {
            var output = "";

            foreach (var rows in Grid)
            {
                foreach (var column in rows)
                {
                    output += column;
                }

                output += "\n";
            }

            return output;
        }
    }
}