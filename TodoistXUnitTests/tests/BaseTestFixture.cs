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

    /*
    public class BaseTestsFixture
    {

        ScreenshotUtils screenshot;

        string currentProjectDirectory;
        string  currentSolutionDirectory;
        string reportFilename;

        //[OneTimeSetUp]
        public void preSetup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            currentProjectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            currentSolutionDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            _configuration = new ConfigurationBuilder().AddJsonFile(currentProjectDirectory + "/config/appSettings.json").Build();
            
            reportFilename = currentSolutionDirectory + "/reports/guru99TestReport.html";
            extentReportUtils = new ExtentReportUtils(reportFilename);
        }

        //[SetUp]
        public void Setup()
        {
            extentReportUtils.createATestCase("Setup");
            string browserType = _configuration["browserType"];
            CmnDriver = new CommonDriver(browserType);

            extentReportUtils.addTestLog(Status.Info, "Browser Type - " + browserType);
            
            url = _configuration["baseUrl"];
            extentReportUtils.addTestLog(Status.Info, "Base URL - " + url);
            CmnDriver.NavigateToFirstURL(url);

            loginPage = new LoginPage(CmnDriver.Driver);

            screenshot = new ScreenshotUtils(CmnDriver.Driver);
        }
        
        //[TearDown]
        public void TearDown()
        {
            string currentExecutionTime = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'-'mm'-'ss");
            string screenshotFilename = $@"{currentSolutionDirectory}\screenshots\test-{currentExecutionTime}.jpeg";

            Console.WriteLine(TestContext.CurrentContext.Result.Outcome);
            
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
            {
                extentReportUtils.addTestLog(Status.Fail, "One or more step failed");
                screenshot.CaptureAndSaveScreenshot(screenshotFilename);
                extentReportUtils.addScreenshot(screenshotFilename);
            }

            CmnDriver.CloseAllBrowser();
        }

        //[OneTimeTearDown]
        public void PostCleanUp()
        {
            extentReportUtils.flushReport();
        }
    }
    */
}