using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Runtime.Serialization;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumExtras.PageObjects;
using WebDriver.Driver;
using WebDriver.Model;
using WebDriver.Pages;
using WebDriver.Service;
using WebDriver.Steps;

namespace WebDriver.Tests
{
    [TestFixture]
    public class SeleniumTests
    {
//        private static DateTimeFormat DTF = new DateTimeFormat("dd/MM/yyyy");
        private IWebDriver driver;
        
        private string HOMEPAGE_URL = "https://getaround.com/cars";  
        private string SOMEPAGE = "https://getaround.com";
        private string HELPPAGE_URL = "https://help.getaround.com/";
        private string TRIPSPAGE_URL = "https://getaround.com/trips";
        
        private readonly string INVALID_TIMERANGE_MSG =
            "Please select a valid time range.";
        
        [FindsBy(How = How.CssSelector, Using = "button.ProviderButton--google")]
        public IWebElement GoogleBtn { get; set; }

        [SetUp]
        public void OpenBrowser()
        {
            //driver = DriverInstance.GetInstance();
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
            User user = UserCreator.TakeStaticCredentials();

            HomePage homePage = (HomePage) new HomePage(driver).OpenPage(HOMEPAGE_URL);
            SearchPage sp = (SearchPage) homePage.Login(user);

            int expectedSearchResultsNumber = sp
                .SearchForTerms("9th Avenue, New York, NY, USA", false)
                .CountSearchResults();

            Assert.IsTrue(expectedSearchResultsNumber > 0, "Search results are empty!");
        }

        //Open home page, login by Google, input search terms for location, choose first car and
        //pick wrong Start date
        [Test]
        public void TestOfInvalidTimeIntervals()
        {
            User user = UserCreator.TakeStaticCredentials();
            HomePage homePage = (HomePage) new HomePage(driver).OpenPage(HOMEPAGE_URL);
            SearchPage sp = (SearchPage) homePage.Login(user);

            CarSummaryPage csp = sp
                .SearchForTerms("9th Avenue, New York, NY, USA",false)
                .SelectCar();

            Assert.AreEqual(INVALID_TIMERANGE_MSG, csp.PickDate("26/12/2019"));
        }

        
        
        [TestCase("Chevrolet", "Chicago, IL, USA")]
        public void CountPickupsByMakeAndCityTest(string carMake, string loc)
        {
            User user = UserCreator.TakeStaticCredentials();
            //For example to test that there are more than 1 Toyota pickups in New York for renting
            HomePage homePage = (HomePage) new HomePage(driver).OpenPage(HOMEPAGE_URL);
            SearchPage sp = (SearchPage) homePage.Login(user);

            int expectedSearchResultsNumber = sp
                .SearchForTerms(loc, true)
                .CountSearchResultsCategory(carMake);

            Assert.AreEqual(0, expectedSearchResultsNumber);

        }
        
        [Test]
        public void SendFeedbackTest()
        {
            Request request = RequestCreator.WithCredentialsAsProperties();
            HelpPage helpPage = (HelpPage)new HelpPage(driver).OpenPage(HELPPAGE_URL);
            helpPage.GoToRequestPage();
            helpPage.SelectProblem(request.ProblemName);
//            helpPage.AddCredentials(request.Email, request.Subject, request.Description);
        }

        [Test]
        public void ViewUserTripsTest()
        {
            User user = UserCreator.TakeStaticCredentials();
            HomePage homePage = (HomePage) new HomePage(driver).OpenPage(HOMEPAGE_URL);
            SearchPage sp = (SearchPage) homePage.Login(user);
            int expected = sp.OpenUserTripsPage(TRIPSPAGE_URL).CountUserTrips();
            
            Console.WriteLine($"User trips: {expected}");
            Assert.IsFalse(expected > 0);
        }

        [TestCase(15,3)]
        [TestCase(20,3)]
        [TestCase(25,3)]    
        public void AmountOfCarsUserCanRent(int money, int durationHours)
        {
            User user = UserCreator.TakeStaticCredentials();
            //return how many cars can user afford to rent
            HomePage homePage = (HomePage) new HomePage(driver).OpenPage(HOMEPAGE_URL);
            SearchPage sp = (SearchPage) homePage.Login(user);

            
           //     /html/body/div[5]/div[5]/div[2]/div[1]/div[2]/div/div[1]/div[1]/div[2]/div/div/div/div/div/div/ul/li[1] Start time
           //     /html/body/div[5]/div[5]/div[2]/div[1]/div[2]/div/div[1]/div[2]/div[2]/div/div/div/div/div/div/ul/li[5] End time
           //     //div[@id="search-results-list"]/div[i]/div/div[2]/div   i-th price 
        }

        //        [Test]
//        public void DateTimeTest()
//        {
//            DateTime dt = DateTime.ParseExact("13/08/2020", DTF.FormatString , CultureInfo.InvariantCulture);
//            Console.WriteLine(dt.Day);
//        }


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