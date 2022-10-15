namespace Cap2ProblemasDeBusca.Models
{
    public class LabyrinthLocation : IEquatable<LabyrinthLocation>
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public LabyrinthLocation(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public bool Equals(LabyrinthLocation? x)
        => Row == x.Row && Column == x.Column;
    }
}