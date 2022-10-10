using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TodoistApplication.Pages
{
    public class HomePage: BasePage
    {
        private IWebDriver _driver;

        //private IWebElement headerTitle => _driver.FindElement(By.CssSelector("header h1"));


        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetHeaderTitle()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(e => e.FindElement(By.CssSelector("header h1")).Displayed);
            IWebElement headerTitle = _driver.FindElement(By.CssSelector("header h1"));
            
            //IWebElement headerTitle = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector("header h1")));

            return headerTitle.Text;
        }
    }
}
