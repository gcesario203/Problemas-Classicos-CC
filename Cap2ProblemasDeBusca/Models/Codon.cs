using System.Diagnostics.CodeAnalysis;
using Cap2ProblemasDeBusca.Enums;

namespace Cap2ProblemasDeBusca.Models
{
    public class Codon : IEqualityComparer<Codon>
    {
        public Nucleotide[] Nucleotides { get; set; } = new Nucleotide[3];

        public int NucleotidesSize { get => Nucleotides.Sum(x => (int)x);}

        public Codon(string nucleotides)
        {
            var nucleotideToPrepend = new List<Nucleotide>();

            foreach (var nucleotide in nucleotides)
            {
                var item = (Nucleotide)Enum.Parse(typeof(Nucleotide), nucleotide.ToString());

                nucleotideToPrepend.Add(item);
            }

            Nucleotides = nucleotideToPrepend.ToArray();

        }

        public bool Equals(Codon? x, Codon? y) => Enumerable.SequenceEqual(x.Nucleotides, y.Nucleotides);

        public bool Equals(Codon? x) => Equals(this, x);

        public int GetHashCode([DisallowNull] Codon obj) => obj.GetHashCode();
    }
}