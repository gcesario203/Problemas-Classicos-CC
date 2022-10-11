using System.Diagnostics;

namespace Cap1ProblemasPequenos.Implementations
{
    ///<summary>
    /// O C# é mto pica, ai nem deu muita graça esse teste
    ///</summary>
    public class GeneCompresser
    {
        public Dictionary<char, byte> GeneValues { get; set; } = new Dictionary<char, byte>();

        public Queue<byte> CompressedBytes = new Queue<byte>();

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
        private void Compress(string value)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            System.Console.WriteLine("Inicio de compressão");

            foreach (var charFromValue in value.ToUpper())
            {
                var byteToEnqueue = GeneValues.FirstOrDefault(gene => gene.Key == charFromValue);

                if (byteToEnqueue.Key == 0)
                {
                    System.Console.WriteLine("Gene inválido");

                    break;
                }

                CompressedBytes.Enqueue(byteToEnqueue.Value);
            }

            stopwatch.Stop();

            System.Console.WriteLine("Tempo de compressão: " + stopwatch.Elapsed.ToString());

            System.Console.WriteLine("Tamanho do gene após compressão: " + GetSizeOfCompressedBytes());

            System.Console.WriteLine("Comprimido! - " + string.Join("", CompressedBytes));
        }

        private int GetSizeOfCompressedBytes()=> CompressedBytes.Sum(x => System.Runtime.InteropServices.Marshal.SizeOf(x));

        private void Decompress()
        {
            var teste = "";
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            System.Console.WriteLine("Inicio de descompressão");

            foreach (var byteFromBitString in CompressedBytes)
            {
                var byteToEnqueue = GeneValues.FirstOrDefault(gene => gene.Value == byteFromBitString);

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

            System.Console.WriteLine("Descomprimido! - " + teste);
        }
    }
}