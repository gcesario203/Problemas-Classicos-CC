using System.Diagnostics;
using Cap2ProblemasDeBusca.Models;
using Lib.Contracts;

namespace Cap2ProblemasDeBusca.TestCases
{
    public class DnaSearch : ITestCase
    {
        public string TestName { get; set; }

        public DnaSearch(string testName)
        {
            TestName = testName;
        }

        public void RunTest()
        {
            var stopWatch = new Stopwatch();
            var gene = new Gene("AAACGTCCCGTTTAAACCGGT");

            var codonToSearch = new Codon("GGT");

            System.Console.WriteLine("Iniciando a busca linear");
            stopWatch.Start();
            LinearContains(gene, codonToSearch);

            stopWatch.Stop();

            System.Console.WriteLine("A busca linear levou " + stopWatch.Elapsed.ToString());

            System.Console.WriteLine("Iniciando a busca binaria");
            stopWatch.Start();
            BinaryContains(gene, codonToSearch);

            stopWatch.Stop();

            System.Console.WriteLine("A busca binaria levou " + stopWatch.Elapsed.ToString());

            stopWatch.Reset();
        }

        private bool LinearContains(Gene gene, Codon codonToSearch)
        {
            foreach (var codon in gene.Codons)
                if (codon.Equals(codonToSearch))
                    return true;

            return false;
        }

        private bool BinaryContains(Gene gene, Codon codonToSearch)
        {
            int init = 0, end = gene.Codons.Count - 1;

            gene.Codons = gene.Codons.OrderBy(x => x.NucleotidesSize).ToList();
            while (init <= end)
            {
                int intermedium = (init + end) / 2;

                if (gene.Codons[intermedium].NucleotidesSize < codonToSearch.NucleotidesSize)
                    init = intermedium + 1;
                else if (gene.Codons[intermedium].NucleotidesSize > codonToSearch.NucleotidesSize)
                    end = intermedium - 1;
                else
                    return true;
            }

            return false;
        }
    }
}