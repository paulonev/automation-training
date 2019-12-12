using System;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace WebDriver.Page
{
    public abstract class AbstractPage
    {
        protected static int LOAD_TIMEOUT = 40;
        protected static int TIME_TO_FIND_ELEMENT = 30;
        protected IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//body")]
        public IWebElement Body { get; set; }

        public abstract AbstractPage OpenPage(string url);
        
//        public abstract AbstractPage Login();
//        public abstract AbstractPage SearchForTerms(string src);
//        public abstract int CountSearchResults();
        
        protected AbstractPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        protected void WaitForLoading(string urlContains, IWebDriver driver, string URL = "")
        {
            if(URL != "") driver.Navigate().GoToUrl(URL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(LOAD_TIMEOUT));
            wait.Until(ExpectedConditions.UrlContains(urlContains)); //method falls

//            return this;
        }
        
        protected ReadOnlyCollection<IWebElement> FindElementsBy(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TIME_TO_FIND_ELEMENT));
            return wait.Until(drv => drv.FindElements(by));
        }
        
        protected IWebElement WaitForElementToBeVisible(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TIME_TO_FIND_ELEMENT));
            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }


        protected void FocusAway()
        {
            Body.Click();
        }
    }
}