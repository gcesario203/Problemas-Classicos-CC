using Cap2ProblemasDeBusca.Models;
using Lib.Contracts;

namespace Cap2ProblemasDeBusca.TestCases
{
    public class DnaSearch : ITestCase
    {
        public string TestName { get ; set ; }

        public DnaSearch(string testName)
        {
            TestName = testName;
        }

        public void RunTest()
        {
            var gene = new Gene("AAACGTCCCGTTTAAACCGGT");

            var codonToSearch = new Codon("GGT");

            var teste = LinearContains(gene, codonToSearch);

            System.Console.WriteLine(teste);
        }

        private bool LinearContains(Gene gene, Codon codonToSearch)
        {
            foreach(var codon in gene.Codons)
                if(codon.Equals(codonToSearch))
                    return true;

            return false;
        }
    }
}