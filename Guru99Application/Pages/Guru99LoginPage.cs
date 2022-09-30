using OpenQA.Selenium;

namespace Guru99Application.Pages
{
    public class Guru99LoginPage : BasePage
    {
        private IWebDriver _driver;

        private IWebElement username => _driver.FindElement(By.Name("uid"));
        private IWebElement password => _driver.FindElement(By.Name("password"));
        private IWebElement loginButton => _driver.FindElement(By.Id("btnLogin"));

        public Guru99LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void LoginToApplication(string sUsername, string sPassword)
        {
            cmnElement.SetText(username, sUsername);
            cmnElement.SetText(password, sPassword);

            cmnElement.ClickElement(loginButton);
        }
    }
}