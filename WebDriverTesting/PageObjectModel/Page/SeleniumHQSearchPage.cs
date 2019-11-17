using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


namespace WebDriver.Page
{
    public class SeleniumHQSearchPage
    {
        private IWebDriver driver;
        private IWebElement inputStreetField;
//        private string searchString;
//        public IWebElement InputStreetField { get; set; }


        [FindsBy(How = How.CssSelector, Using = "div.location-input-wrapper")]
        public IWebElement InputStreetField
        {
            get => inputStreetField;
            set => inputStreetField = value;
        }
        
//            => new WebDriverWait(this.driver, TimeSpan.FromSeconds(40))
//            .Until(d=>d.FindElement(By.XPath("//input[@type='text']")));

        //internal page content to be private
        //*[@id='resInfo-0']
        public ReadOnlyCollection<IWebElement> SearchResults { get; set; }
        
      public SeleniumHQSearchPage(IWebDriver driver)
      {
            this.driver = driver;
            //this.driver.Url = driver.Url + "cars";
            PageFactory.InitElements(driver, this);
      }
      public SeleniumHQSearchPage SearchForTerms(string searchString)
      {
          InputStreetField = driver.FindElement(By.CssSelector("input.location-input"));
          string js = "arguments[0].setAttribute('value','" + searchString + "')";
          ((IJavaScriptExecutor) driver).ExecuteScript(js, inputStreetField);
          
          //inputStreetField.SendKeys(searchString);
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