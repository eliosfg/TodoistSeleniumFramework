using AventStack.ExtentReports;
using CommonLibs.Implementation;
using NUnit.Framework;

namespace Guru99Tests.tests
{
    public class LoginPageTests : BaseTests
    {
        [Test]
        public void VerifyLoginTest()
        {
            extentReportUtils.createATestCase("Verify Login Test");
            extentReportUtils.addTestLog(Status.Info, "Performing Login");
            loginPage.LoginToApplication("user", "password");

            string expectedTitle = "Guru99 Bank Manager HomePage";
            string actualTitle = CmnDriver.GetPageTitle();
            
            Assert.AreEqual(expectedTitle, actualTitle);
        }
    }
}