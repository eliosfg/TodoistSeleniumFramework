using AventStack.ExtentReports;
using CommonLibs.Implementation;
using NUnit.Framework;
using TodoistApplication.Pages;

namespace TodoistTests.tests
{
    public class LoginPageTests : BaseTests
    {
        [Test]
        public void VerifyLoginTest()
        {
            extentReportUtils.createATestCase("Verify Login Test");
            extentReportUtils.addTestLog(Status.Info, "Performing Login");
            loginPage.LoginToApplication("eliosfg@gmail.com", "SaulFuentes1234");
            HomePage homePage = new HomePage(WebDriverManager.Driver);

            string expectedTitle = "Today";
            string actualTitle = homePage.GetHeaderTitle();

            Assert.IsTrue(actualTitle.Contains(expectedTitle));
        }
    }
}