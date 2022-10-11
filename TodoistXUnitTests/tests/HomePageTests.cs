using AventStack.ExtentReports;
using CommonLibs.Implementation;
using CommonLibs.Utils;
using TodoistApplication.Pages;

namespace TodoistTests.tests
{
    [Collection("Sequence")]
    public class HomePageTests : IClassFixture<BaseTestFixture>, IDisposable
    {
        private WebDriverManager webDriverManager;
        private BaseTestFixture BaseTestFixture { get; }
        private LoginPage loginPage;
        private HomePage homePage;
        private ScreenshotUtils screenshot;

        public HomePageTests(BaseTestFixture baseTestFixture)
        {
            BaseTestFixture = baseTestFixture;
            webDriverManager = BrowserDriverFactory.GetBrowser(BaseTestFixture.Config.GetBrowserType());
            loginPage = new LoginPage(webDriverManager.Driver);
            screenshot = new ScreenshotUtils(webDriverManager.Driver);
            homePage = new HomePage(webDriverManager.Driver);

            webDriverManager.NavigateToURL(BaseTestFixture.Config.GetBaseUrl());
            loginPage.LoginToApplication("eliosfg@gmail.com", "SaulFuentes1234");
        }

        [Theory]
        [InlineData("My task title", "My task description")]
        public void VerifyANewTaskCanBeAdded(string taskTitle, string taskDescription)
        {
            BaseTestFixture.ExtentReportUtils.createATestCase("Verify a new task can be added");
            BaseTestFixture.ExtentReportUtils.addTestLog(Status.Info, "Creating new task");
            
            homePage.AddNewTask(taskTitle, taskDescription);

            Assert.True(homePage.IsTaskDisplayed(taskTitle), $"Task \"{taskTitle}\" was not created");
        }

        [Theory]
        [InlineData("Another task title")]
        public void VerifyATaskCanBeDeleted(string taskTitle)
        {
            BaseTestFixture.ExtentReportUtils.createATestCase("Verify a task can be deleted");
            BaseTestFixture.ExtentReportUtils.addTestLog(Status.Info, "Creating new task");
            homePage.AddNewTask(taskTitle, "task description");

            BaseTestFixture.ExtentReportUtils.addTestLog(Status.Info, $"Deleting the task \"{taskTitle}\"");
            homePage.DeleteTask(taskTitle);

            Assert.False(homePage.IsTaskDisplayed(taskTitle));
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

            webDriverManager.CloseAllBrowser();
        }
    }
}