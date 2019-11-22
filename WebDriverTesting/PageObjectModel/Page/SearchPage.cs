using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


namespace WebDriver.Page
{
    public class SearchPage : AbstractPage
    {
        
        [FindsBy(How = How.CssSelector, Using = ".location-input")]
        public IWebElement InputStreetField { get; set; }
        
        public ReadOnlyCollection<IWebElement> SearchResults { get; set; }

        public SearchPage(IWebDriver driver) : base(driver)
        {
            this.OpenPage();
        }

      public override AbstractPage OpenPage()
      {
          return WaitForLoading("https://getaround.com/search", driver);
      }

      public override AbstractPage Login()
      {
          throw new NotImplementedException();
      }

      public override AbstractPage SearchForTerms(string searchString)
      {
          InputStreetField = WaitForElementsToBeVisible(By.CssSelector(".location-input"))[0];
          InputStreetField.SendKeys(searchString);
          InputStreetField.SendKeys(Keys.Enter);
          return this;
      }
      
       //By.CssSelector("div#search-results-list") check that amount of results != 0
       public override int CountSearchResults()
       {
            SearchResults = WaitForElementsToBeVisible(By.CssSelector("div#search-results-list > div"));
            return SearchResults.Count;
       }

       private ReadOnlyCollection<IWebElement> WaitForElementsToBeVisible(By by)
       {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            return wait.Until(drv => drv.FindElements(by));
       }
    }
}