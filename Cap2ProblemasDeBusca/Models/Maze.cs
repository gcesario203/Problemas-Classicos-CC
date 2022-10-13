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

        public Maze(LabyrinthLocation start,
                    LabyrinthLocation goal,
                    int rows = 10,
                    int columns = 10,
                    float sparseness = 0.2f)
        {
            Start = start == null ? new LabyrinthLocation(0, 0) : start;
            Start = goal == null ? new LabyrinthLocation(rows, columns) : goal;
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

        }

        private void RandomFill(int rows, int columns, float sparseness)
        {
            for (var x = 0; x < rows; x++)
            {
                for (var y = 0; y < columns; y++)
                {
                    var teste = new Random();
                    if (teste.Next((int)Sparseness * 100, 100) < Sparseness * 100)
                        Grid[x][y] = LabyrinthCell.BLOCKED;
                }
            }
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