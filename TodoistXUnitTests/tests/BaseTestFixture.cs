using CommonLibs.Implementation;
using CommonLibs.Utils;
using TodoistXUnitTests.config;

namespace TodoistTests.tests
{
    public class BaseTestFixture : IDisposable
    {
        public Config Config { get; }
        public ExtentReportUtils ExtentReportUtils { get => extentReportUtils; }
        private ExtentReportUtils extentReportUtils;
        public BaseTestFixture()
        {
            Config = new();
            string reportFileName = Config.GetReportFilename();
            extentReportUtils = new ExtentReportUtils(reportFileName);
        }

        public void Dispose()
        {
            ExtentReportUtils.flushReport();
        }
    }
}