using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace CommonLibs.Implementation
{
    public class CommonDriver
    {
        public IWebDriver Driver { get; private set; }
        public int PageLoadTimeout { private get => pageLoadTimeout; set => pageLoadTimeout = value; }
        public int ElementDetectionTimeout { private get => elementDetectionTimeout; set => elementDetectionTimeout = value; }

        private int pageLoadTimeout;

        private int elementDetectionTimeout;

        public CommonDriver(string browserType)
        {
            pageLoadTimeout = 50;
            elementDetectionTimeout = 10;

            if (browserType.Equals("chrome")) 
            {
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("--lang=en");

                Driver = new ChromeDriver(chromeOptions);
            } else if (browserType.Equals("edge"))
            {
                Driver = new EdgeDriver();
            } else
            {
                throw new Exception("Invalid Browser Type " + browserType);
            }
        }

        public void NavigateToFirstURL(string url)
        {
            url = url.Trim();

            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(PageLoadTimeout);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(elementDetectionTimeout);

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