using OpenQA.Selenium;

namespace TodoistApplication.Pages
{
    public class LoginPage : BasePage
    {
        private IWebDriver _driver;

        private IWebElement username => _driver.FindElement(By.CssSelector("input[autocomplete='email']"));
        private IWebElement password => _driver.FindElement(By.CssSelector("input[autocomplete='current-password']"));
        private IWebElement loginButton => _driver.FindElement(By.CssSelector("button[data-gtm-id='start-email-login']"));

        public LoginPage(IWebDriver driver)
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