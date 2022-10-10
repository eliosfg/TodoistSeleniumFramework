using AventStack.ExtentReports;
using CommonLibs.Implementation;
using CommonLibs.Utils;
using TodoistApplication.Pages;
using Xunit.Abstractions;

namespace TodoistTests.tests
{
    [Collection("Sequence")]
    public class LoginPageTests : IClassFixture<BaseTestFixture>, IDisposable
    {
        public CommonDriver CmnDriver { get; }
        public BaseTestFixture BaseTestFixture { get; }
        public LoginPage loginPage;
        ScreenshotUtils screenshot;

        public LoginPageTests(BaseTestFixture baseTestFixture, ITestOutputHelper outpuHelper)
        {
            BaseTestFixture = baseTestFixture;
            CmnDriver = new CommonDriver(BaseTestFixture.Config.GetBrowserType());
            loginPage = new LoginPage(CmnDriver.Driver);
            screenshot = new ScreenshotUtils(CmnDriver.Driver);
            
        }

        [Fact]
        public void VerifyLoginTest()
        {
            BaseTestFixture.ExtentReportUtils.createATestCase("Verify Login Test");
            CmnDriver.NavigateToFirstURL(BaseTestFixture.Config.GetBaseUrl());
            BaseTestFixture.ExtentReportUtils.addTestLog(Status.Info, "Performing Login");
            loginPage.LoginToApplication("eliosfg@gmail.com", "SaulFuentes1234");
            HomePage homePage = new HomePage(CmnDriver.Driver);
            
            string expectedTitle = "Today";
            
            string actualTitle = homePage.GetHeaderTitle();

            Assert.Contains(expectedTitle, actualTitle);
        }

        [Fact]
        public void VerifyTest2()
        {
            BaseTestFixture.ExtentReportUtils.createATestCase("Verify Test 2");
            CmnDriver.NavigateToFirstURL("https://www.google.com");
            Console.WriteLine("Test 2");
        }

        public void Dispose()
        {
            string currentExecutionTime = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'-'mm'-'ss");
            string screenshotFilename = $@"{BaseTestFixture.Config.CurrentSolutionDirectory}\screenshots\test-{currentExecutionTime}.jpeg";

            /*
            Console.WriteLine(TestContext.CurrentContext.Result.Outcome);

            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
            {
                extentReportUtils.addTestLog(Status.Fail, "One or more step failed");
                screenshot.CaptureAndSaveScreenshot(screenshotFilename);
                extentReportUtils.addScreenshot(screenshotFilename);
            }*/

            CmnDriver.CloseAllBrowser();
        }
    }
}