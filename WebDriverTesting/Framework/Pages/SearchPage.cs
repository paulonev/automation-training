using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


namespace WebDriver.Pages
{
    public class SearchPage : AbstractPage
    {
        [FindsBy(How = How.CssSelector, Using = ".location-input")]
        public IWebElement InputStreetField { get; set; }

//        private readonly string resultsListInDOM = "div#search-results-list > div";
//        private readonly string resultsListInDOM = "/html/body/div[5]/div[5]/div[2]/div[2]/div[4]/div/div[1]/a";
        private readonly string resultsListInDOM = "//div[@id=\"search-results-list\"]/div/div";
        private readonly string firstElementInResultsList = "//div[@id=\"search-results-list\"]/div[1]/div";
        
        public ReadOnlyCollection<IWebElement> SearchResults { get; set; }
        public ReadOnlyCollection<IWebElement> SearchResultLabels { get; set; }


        public SearchPage(IWebDriver driver) : base(driver)
        {
//            OpenPage("blank");
        }

        public override AbstractPage OpenPage(string url)
        {
            _driver.Url = url;
            new WebDriverWait(_driver, TimeSpan.FromSeconds(LOAD_TIMEOUT))
                  .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".location-input")));
            return this;
        }

        public SearchPage SearchForTerms(string searchString, bool withFilters)
        {
            InputStreetField = FindElementsBy(By.CssSelector(".location-input"))[0];
            Thread.Sleep(TimeSpan.FromSeconds(5));
            InputStreetField.SendKeys(searchString);
            Thread.Sleep(500);
            InputStreetField.SendKeys(Keys.Enter);
            Thread.Sleep(TimeSpan.FromSeconds(5));
            if (withFilters)
            {
                //click on Filters Icon to select flag
                FindElementsBy(By.CssSelector(".toggle-filters-panel-button"))[0].Click();
                FindElementsBy(By.CssSelector("div.ant-row:nth-child(4) > div:nth-child(2) > div:nth-child(1) > label:nth-child(1) > span"))[1].Click();
                Thread.Sleep(500);
            }
            
            return this;
        }

        public CarSummaryPage SelectCar()
        {
            Thread.Sleep(5000);
            FindElementsBy(
              By.CssSelector("#search-results-list > div:nth-child(1) > div.car-row > div.car-basics > a"))[0].Click();
          
            return new CarSummaryPage(_driver);
        }
        
        
      
       //By.CssSelector("div#search-results-list") check that amount of results != 0
        public int CountSearchResults()
        {
            SearchResults = FindElementsBy(By.XPath(firstElementInResultsList));
            SearchResults = FindElementsBy(By.XPath(resultsListInDOM));
            //div#search-results-list > div
            
            //           Thread.Sleep(TimeSpan.FromSeconds(5));
            return SearchResults.Count;
        }

        public int CountSearchResultsCategory(String carMake)
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            int count = 0;
            SearchResultLabels = FindElementsBy(By.XPath(firstElementInResultsList + "/div/a"));
            SearchResultLabels = FindElementsBy(By.XPath(resultsListInDOM + "/div/a"));

            foreach (var car in SearchResultLabels)
            {
                if (car.Text.Contains(carMake)) count++;
            }            
            return count;
        }

        public TripsPage OpenUserTripsPage(string url)
        {
            Thread.Sleep(1000);
            return new TripsPage(_driver, url);
        }
//        private ReadOnlyCollection<IWebElement> WaitForElementsToBeVisible(By by)
//        {
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TIME_TO_FIND_ELEMENT));
//            return wait.Until(drv => drv.FindElements(by));
//        }
    }
}