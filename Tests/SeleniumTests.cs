using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace Tests
{
    [TestFixture]
    public class SeleniumTests
    {
        private IWebDriver driver;
        
        [SetUp]
        public void OpenBrowser()
        {
            driver = new FirefoxDriver();
            driver.Url = "http://www.seleniumhq.org/";
            //driver.Manage().Window.Maximize();
            //general timeouts
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
        }

        [Test]
        public void OpenCloseTest()
        {
            //homepage
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Message = "Time for opening url expired";
                //Find element taking into consideration explicit wait for finding it
            IWebElement searchTextBox = waitForElementLocatedBy(driver, By.Id("q"));
            searchTextBox.SendKeys("selenium csharp");
            
            ReadOnlyCollection<IWebElement> searchBtn = driver.FindElements(By.XPath("//*[@value='Go']"));
            searchBtn[0].Click();

            //search results page goes here
            ReadOnlyCollection<IWebElement> searchResults = 
                new WebDriverWait(driver,TimeSpan.FromSeconds(10))
                    .Until(d => d.FindElements(By.XPath("//div[contains(@class,'gsc-webResult') and contains(.,'selenium') and contains(.,'csharp')]")));

            Assert.IsTrue(searchResults.Count > 0, "Search results are empty!");

            //Console.WriteLine("Search results number for requested term: " + searchResults.Count);
            //Thread.Sleep(5000); wrong to use, not 
        }

        private IWebElement waitForElementLocatedBy(IWebDriver _driver, By by)
        {
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                    .Until(d => d.FindElement(by));
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
            driver = null;
        }
        
        
    }
}