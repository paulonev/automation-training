using System;
using AngleSharp.Html.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace WebDriver.Driver
{
    public class DriverInstance
    {
        private static IWebDriver driver;

        private DriverInstance() { }

        /// <summary>
        /// Setup driver config for browsers
        /// </summary>
        /// <param name="browser">Name of browser or "" for FF</param>
        /// <returns></returns>
        public static IWebDriver GetInstance(string browser = "")
        {
            if (driver == null)
            {
                switch (browser)
                {
                    case "chrome":
                    {
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver();
                        break;
                    }
                    default:
                    {
                        //new DriverManager().SetUpDriver(new FirefoxConfig());
                        driver = new FirefoxDriver("/Resources/geckodriver");
                        break;
                    }
                }
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseDriver()
        {
            driver.Quit();
            driver = null;
        }
    }
}
