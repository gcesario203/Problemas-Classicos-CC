using System.Diagnostics.CodeAnalysis;
using Cap2ProblemasDeBusca.Contracts;

namespace Cap2ProblemasDeBusca.Models
{
    public class LabyrinthLocation : IEqualityComparer<LabyrinthLocation>, IComparableObject<LabyrinthLocation>
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public LabyrinthLocation(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public bool Equals(LabyrinthLocation? x, LabyrinthLocation? y)
        => x.Row == y.Row && x.Column == y.Column;

        public bool Equals(LabyrinthLocation? x)
        => Equals(this, x);

        public int GetHashCode([DisallowNull] LabyrinthLocation obj)
        => obj.GetHashCode();

        public bool Compare(LabyrinthLocation obj)
        => Equals(this, obj);
    }
}