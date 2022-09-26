using Lib.Contracts;

namespace Lib.Abstractions
{
    public abstract class BaseTestRunner : ITestRunner
    {
        protected IEnumerable<ITestCase> TestCases;

        public string TestName { get ; set ; }

        public abstract void BuildInterface();
    }
}