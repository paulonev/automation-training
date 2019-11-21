using System;
using System.Collections.ObjectModel;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumExtras.PageObjects;
using WebDriver.Page;

namespace WebDriver.Tests
{
    [TestFixture]
    public class SeleniumTests
    {
        private IWebDriver driver;
        private string HOMEPAGE_URL = "https://getaround.com/";

//        [FindsBy(How = How.XPath, Using = "//a[text() = 'Continue with Google']")]
        [FindsBy(How = How.CssSelector, Using = "button.ProviderButton--google")]
        public IWebElement GoogleBtn { get; set; }

        [SetUp]
        public void OpenBrowser()
        {
            driver = new FirefoxDriver();
            //driver.Url = "http://www.seleniumhq.org/";
            //driver.Manage().Window.Maximize();
            //general timeouts
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        //We automate test that opens home page of web application, moves to it's searching cars page
        //Inputs given term of location and counts results of search query and stores it in 
        //[expectedSearchResultsNumber] variable
        [Test]
        public void CheckSearchResultsAmount()
        {
            CarShareHomePage sp = new CarShareHomePage(driver).OpenHomePage();

            int expectedSearchResultsNumber = sp.Login()
                .SearchForTerms("6th Street, Los Angeles, CA, USA")
                .CountSearchResults();

            Assert.IsTrue(expectedSearchResultsNumber > 0, "Search results are empty!");
        }

        //Open home page, login by Google, input search terms for location and select wrong data intervals
        [Test]
        public void TestOfInvalidTimeIntervals()
        {
            CarShareHomePage homePage = new CarShareHomePage(driver).OpenHomePage();

            homePage.Login().SearchForTerms("6th Street, Los Angeles, CA, USA");
            
        }


//        [Test]
//        public void IsAlertPresent()
//        {
//            try
//            {
//                PageFactory.InitElements(driver, this);
//                driver.Navigate().GoToUrl(HOMEPAGE_URL);
//                GoogleBtn.Click();
//
//                IAlert alert = driver.SwitchTo().Alert();
//                Console.WriteLine(alert.Text + "Alert is displayed");
//            }
//            catch (NoAlertPresentException ex)
//            {
//                Console.WriteLine("Alert is not displayed");
//            }
//        }

        [Test]
        public void CheckWindows()
        {
            driver.Navigate().GoToUrl(HOMEPAGE_URL);
            PageFactory.InitElements(driver, this);
            GoogleBtn.Click();
            
            ReadOnlyCollection<string> windows = driver.WindowHandles;
            foreach (var window in windows)
            {
                Console.WriteLine(window);
            }
        }

    [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
            driver = null;
        }
        
        
    }
}