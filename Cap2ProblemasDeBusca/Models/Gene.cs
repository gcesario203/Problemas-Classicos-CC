
namespace Cap2ProblemasDeBusca.Models
{
    public class Gene
    {
        public List<Codon> Codons { get; set; }

        public Gene(string geneValue)
        {
            StringToGene(geneValue);
        }

        private void StringToGene(string geneValue)
        {
            if(geneValue.Length % 3 != 0)
                return;

            var codon = geneValue.Substring(0,3);

            geneValue = geneValue.Remove(0,3);

            if(Codons == null)
                Codons = new List<Codon>();

            Codons.Add(new Codon(codon));

            if(string.IsNullOrEmpty(geneValue))
                return;

            StringToGene(geneValue);
        }
    }
}