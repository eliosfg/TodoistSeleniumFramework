using CommonLibs.Implementation;
using CommonLibs.Utils;
using TodoistXUnitTests.config;

namespace TodoistTests.tests
{
    public class BaseTestFixture : IDisposable
    {
        public Config Config { get; }
        public ExtentReportUtils ExtentReportUtils { get; }

        public BaseTestFixture()
        {
            Config = new();
            ExtentReportUtils = new ExtentReportUtils(Config.GetReportFilename());
            
        }

        public void Dispose()
        {
            ExtentReportUtils.flushReport();
        }
    }
}