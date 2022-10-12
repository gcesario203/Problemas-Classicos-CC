using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Cap1ProblemasPequenos.Implementations
{
    ///<summary>
    /// O C# é mto pica, ai nem deu muita graça esse teste
    ///</summary>
    public class GeneCompresser
    {
        public long CompressedBytes { get; set; } = 1;
        public Dictionary<char, byte> GeneValues { get; set; } = new Dictionary<char, byte>();

        public GeneCompresser(string compressedValue)
        {
            System.Console.WriteLine("Gene que será comprimido: " + compressedValue);
            FillByteDict();
            Compress(compressedValue);

            Decompress();
        }

        private void FillByteDict()
        {
            GeneValues.Add('A', 0b00);
            GeneValues.Add('C', 0b01);
            GeneValues.Add('G', 0b10);
            GeneValues.Add('T', 0b11);
        }

        private int GetCompressedGeneSize() => Convert.ToString(CompressedBytes, 2).ToArray().Length;
        private void Compress(string value)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            System.Console.WriteLine("Inicio de compressão");

            var teste = new List<byte>();

            foreach (var charFromValue in value.ToUpper())
            {

                CompressedBytes <<= 2;

                var byteToEnqueue = GeneValues.FirstOrDefault(gene => gene.Key == charFromValue);

                if (byteToEnqueue.Key == 0)
                {
                    System.Console.WriteLine("Gene inválido");

                    break;
                }

                CompressedBytes |= byteToEnqueue.Value;
            }

            stopwatch.Stop();

            System.Console.WriteLine("Tempo de compressão: " + stopwatch.Elapsed.ToString());

            System.Console.WriteLine("Tamanho do gene após compressão: " + Marshal.SizeOf(CompressedBytes));

            System.Console.WriteLine("Comprimido! - " + Convert.ToString(CompressedBytes, 2));
        }

        private void Decompress()
        {
            var teste = "";
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            System.Console.WriteLine("Inicio de descompressão");

            for (var i = 0; i < GetCompressedGeneSize() - 1; i += 2)
            {

                var valueToGet = CompressedBytes >> i & 0b11;

                var byteToEnqueue = GeneValues.FirstOrDefault(gene => gene.Value == valueToGet);

                if (byteToEnqueue.Key == 0)
                {
                    System.Console.WriteLine("Gene inválido");

                    break;
                }
                teste += byteToEnqueue.Key;
            }

            stopwatch.Stop();

            System.Console.WriteLine("Tempo de descompressão: " + stopwatch.Elapsed.ToString());

            System.Console.WriteLine("Tamanho do gene após descompressão: " + System.Text.ASCIIEncoding.ASCII.GetByteCount(teste));

            System.Console.WriteLine("Descomprimido! - " + String.Join("", teste.Reverse()));
        }
    }
}