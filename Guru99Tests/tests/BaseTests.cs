using System;
using System.IO;
using CommonLibs.Implementation;
using Guru99Application.Pages;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Guru99Tests.tests
{
    public class BaseTests
    {
        public CommonDriver CmnDriver;
        public Guru99LoginPage loginPage;
        private IConfigurationRoot _configuration;
        public ExtentReportUtils extentReportUtils;
        string url;

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
            extentReportUtils.addTestLog(Status.Info, "Base URL - " + baseUrl);
            CmnDriver.NavigateToFirstURL(url);

            loginPage = new Guru99LoginPage(CmnDriver.Driver);
        }

        [TearDown]
        public void TearDown()
        {
            CmnDriver.CloseAllBrowser();
        }

        [OneTimeTearDown]
        public void PostCleanUp()
        {
            extentReportUtils.flushReport();
        }
    }
}