using Cap1ProblemasPequenos.Implementations;
using Lib.Contracts;

namespace Cap1ProblemasPequenos.TestCases
{
    public class OneTimePadCryptoTestCase : ITestCase
    {
        public string TestName { get ; set ; }

        public OneTimePadCryptoTestCase(string testName)
        {
            TestName = testName;
        }

        public void RunTest()
        {
            var strToEncrypt = "ÓÓÓ´EU TE AMO";

            System.Console.WriteLine($"Descriptografando: {strToEncrypt}");
            var (dummy, encrypted) = OneTimePadCrypto.Encrypt(strToEncrypt);

            var decryptedKeys = OneTimePadCrypto.Decrypt(dummy, encrypted);

            System.Console.WriteLine($"Resultado: {strToEncrypt == decryptedKeys}");
        }
    }
}