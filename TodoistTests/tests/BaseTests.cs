using System;
using System.IO;
using AventStack.ExtentReports;
using CommonLibs.Implementation;
using CommonLibs.Utils;
using TodoistApplication.Pages;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace TodoistTests.tests
{
    public class BaseTests
    {
        public WebDriverManager WebDriverManager;
        public LoginPage loginPage;
        private IConfigurationRoot _configuration;
        public ExtentReportUtils extentReportUtils;
        string url;

        ScreenshotUtils screenshot;

        string currentProjectDirectory;
        string  currentSolutionDirectory;
        string reportFilename;

        [OneTimeSetUp]
        public void preSetup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            currentProjectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            currentSolutionDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            _configuration = new ConfigurationBuilder().AddJsonFile(currentProjectDirectory + "/config/appSettings.json").Build();
            
            reportFilename = currentSolutionDirectory + "/reports/guru99TestReport.html";
            extentReportUtils = new ExtentReportUtils(reportFilename);
        }

        [SetUp]
        public void Setup()
        {
            extentReportUtils.createATestCase("Setup");
            string browserType = _configuration["browserType"];
            WebDriverManager = BrowserDriverFactory.GetBrowser(browserType);

            extentReportUtils.addTestLog(Status.Info, "Browser Type - " + browserType);
            
            url = _configuration["baseUrl"];
            extentReportUtils.addTestLog(Status.Info, "Base URL - " + url);
            WebDriverManager.NavigateToURL(url);

            loginPage = new LoginPage(WebDriverManager.Driver);

            screenshot = new ScreenshotUtils(WebDriverManager.Driver);
        }

        [TearDown]
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

            WebDriverManager.CloseAllBrowser();
        }

        [OneTimeTearDown]
        public void PostCleanUp()
        {
            extentReportUtils.flushReport();
        }
    }
}