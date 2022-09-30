using System;
using System.IO;
using AventStack.ExtentReports;
using CommonLibs.Implementation;
using CommonLibs.Utils;
using Guru99Application.Pages;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Guru99Tests.tests
{
    public class BaseTests
    {
        public CommonDriver CmnDriver;
        public Guru99LoginPage loginPage;
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
            CmnDriver = new CommonDriver(browserType);

            extentReportUtils.addTestLog(Status.Info, "Browser Type - " + browserType);
            
            url = _configuration["baseUrl"];
            extentReportUtils.addTestLog(Status.Info, "Base URL - " + url);
            CmnDriver.NavigateToFirstURL(url);

            loginPage = new Guru99LoginPage(CmnDriver.Driver);

            screenshot = new ScreenshotUtils(CmnDriver.Driver);
        }

        [TearDown]
        public void TearDown()
        {
            string currentExecutionTime = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'-'mm'-'ss");
            string screenshotFilename = $@"{currentSolutionDirectory}\screenshots\test-{currentExecutionTime}.jpeg";

            Console.WriteLine(TestContext.CurrentContext.Result.Outcome);
            
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Error)
            {
                extentReportUtils.addTestLog(Status.Fail, "One or more step failed");
                screenshot.CaptureAndSaveScreenshot(screenshotFilename);
                extentReportUtils.addScreenshot(screenshotFilename);
            }

            CmnDriver.CloseAllBrowser();
        }

        [OneTimeTearDown]
        public void PostCleanUp()
        {
            extentReportUtils.flushReport();
        }
    }
}