namespace Cap2ProblemasDeBusca.Models
{
    public class LabyrinthLocation
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public LabyrinthLocation(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}