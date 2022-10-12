using System.Collections;
using System.Text;

namespace Cap1ProblemasPequenos.Implementations
{
    public static class OneTimePadCrypto
    {

        public static string Decrypt(BitArray key1, BitArray key2) => key1.Xor(key2).BitArrayToStr();

        public static (BitArray dummy, BitArray encrypted) Encrypt(string originalStr)
        {
            var originalStrBytes = Encoding.UTF8.GetBytes(originalStr);
            var originalStrBits = new BitArray(originalStrBytes);

            var dummyBits = GenerateToken(originalStrBytes.Count());

            var encrypted = originalStrBits.Xor(dummyBits);

            return (dummyBits, encrypted);
        }
        private static BitArray GenerateToken(int tokenLength)
        {
            var byteArray = new byte[tokenLength];

            new Random().NextBytes(byteArray);

            return new BitArray(byteArray);
        }

        private static String BitArrayToStr(this BitArray ba)
        {
            byte[] strArr = new byte[ba.Length / 8];

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();

            for (int i = 0; i < ba.Length / 8; i++)
            {
                for (int index = i * 8, m = 1; index < i * 8 + 8; index++, m *= 2)
                {
                    strArr[i] += ba.Get(index) ? (byte)m : (byte)0;
                }
            }

            return encoding.GetString(strArr);
        }
    }
}