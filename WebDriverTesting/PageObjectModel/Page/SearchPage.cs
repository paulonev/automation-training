using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


namespace WebDriver.Page
{
    public class SearchPage : AbstractPage
    {
        [FindsBy(How = How.CssSelector, Using = ".location-input")]
        public IWebElement InputStreetField { get; set; }
        
        public ReadOnlyCollection<IWebElement> SearchResults { get; set; }
        
//        [FindsBy(How = How.CssSelector, Using = "#search-results-list > div:nth-child(1) > div.car-row > div.car-basics > a")]
//        public IWebElement NavToFirstCar { get; set; }
        
        public SearchPage(IWebDriver driver) : base(driver)
        {
            OpenPage();
        }

        public override AbstractPage OpenPage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(LOAD_TIMEOUT))
                  .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".location-input")));
            return this;
        }

        public SearchPage SearchForTerms(string searchString)
        {
            InputStreetField = WaitForElementsToBeVisible(By.CssSelector(".location-input"))[0];
            Thread.Sleep(TimeSpan.FromSeconds(5));
            InputStreetField.SendKeys(searchString);
            Thread.Sleep(500);
            InputStreetField.SendKeys(Keys.Enter);
            Thread.Sleep(TimeSpan.FromSeconds(5));
            return this;
        }

        public CarSummaryPage SelectCar()
        {
            Thread.Sleep(5000);
            WaitForElementsToBeVisible(
              By.CssSelector("#search-results-list > div:nth-child(1) > div.car-row > div.car-basics > a"))[0].Click();
          
            return new CarSummaryPage(driver);
        }
      
       //By.CssSelector("div#search-results-list") check that amount of results != 0
        public int CountSearchResults()
        {
            SearchResults = WaitForElementsToBeVisible(By.CssSelector("div#search-results-list > div:nth-child(1)"));
            SearchResults = WaitForElementsToBeVisible(By.CssSelector("div#search-results-list > div"));
//           Thread.Sleep(TimeSpan.FromSeconds(5));
            return SearchResults.Count;
        }

        private ReadOnlyCollection<IWebElement> WaitForElementsToBeVisible(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TIME_TO_FIND_ELEMENT));
            return wait.Until(drv => drv.FindElements(by));
        }
    }
}