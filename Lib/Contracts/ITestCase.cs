namespace Lib.Contracts
{
    public interface ITestCase
    {
        string TestName { get; set; }
        void RunTest();
    }
}