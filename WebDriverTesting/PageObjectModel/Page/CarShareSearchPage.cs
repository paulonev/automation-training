using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


namespace WebDriver.Page
{
    public class CarShareSearchPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = ".location-input")]
        public IWebElement InputStreetField { get; set; }
        
        //internal page content to be private
        //*[@id='resInfo-0']
        public ReadOnlyCollection<IWebElement> SearchResults { get; set; }
        
      public CarShareSearchPage(IWebDriver driver)
      {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".location-input")));
            PageFactory.InitElements(driver, this);
      }
      public CarShareSearchPage SearchForTerms(string searchString)
      {
          InputStreetField.SendKeys(searchString);
          InputStreetField.SendKeys(Keys.Enter);
          return this;
      }
      
//        public SeleniumHQSearchResultsPage(IWebDriver driver, string searchString)
//        {
//            this.driver = driver;
//            this.searchString = searchString;
//            PageFactory.InitElements(driver,this);
//        }

        
        //By.CssSelector("div#search-results-list") check than amount of results != 0
        public int CountSearchResults()
        {
            //search results page goes here
            //XPATH *[@id="search-results-list"]
            SearchResults = driver.FindElements(By.CssSelector("div#search-results-list > div"));
            return SearchResults.Count;
        }
        
    }
}