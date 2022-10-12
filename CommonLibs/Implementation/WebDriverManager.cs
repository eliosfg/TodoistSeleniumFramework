using OpenQA.Selenium;
using System;

namespace CommonLibs.Implementation
{
    public abstract class WebDriverManager
    {
        private IWebDriver driver;
        public int PageLoadTimeout { private get => pageLoadTimeout; set => pageLoadTimeout = value; }
        public int ElementDetectionTimeout { private get => elementDetectionTimeout; set => elementDetectionTimeout = value; }
        private int pageLoadTimeout;
        private int elementDetectionTimeout;

        protected abstract void createWebDriver();

        public IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    createWebDriver();
                }
                return driver;
            }

            set { driver = value; }
        }

        public void NavigateToURL(string url)
        {
            url = url.Trim();

            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(PageLoadTimeout);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(elementDetectionTimeout);

            Driver.Navigate().GoToUrl(url);

            Driver.Url = url;
        }

        public void CloseBrowser()
        {
            if (Driver != null)
            {
                Driver.Close();
            }
        }

        public void CloseAllBrowser()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
            }
        }

        public string GetPageTitle()
        {
            return Driver.Title;
        }
    }
}
