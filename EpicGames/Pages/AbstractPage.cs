using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Pages
{
    public abstract class AbstractPage
    {
        protected IWebDriver _driver;
        protected static int LOAD_TIMEOUT = 40;
        protected static int TIME_TO_FIND_ELEMENT = 30;

        public AbstractPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public virtual AbstractPage OpenPage()
        {
            return this;
        }

        protected void WaitForLoading()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(LOAD_TIMEOUT));
            wait.Until(d => ((IJavaScriptExecutor) d)
                .ExecuteScript("return document.readyState").Equals("complete"));
            
//            if (URL != "") _driver.Navigate().GoToUrl(URL);
//            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(LOAD_TIMEOUT));
//            wait.Until(ExpectedConditions.UrlContains(urlContains));
        }
        
        protected ReadOnlyCollection<IWebElement> FindElementsBy(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TIME_TO_FIND_ELEMENT));
            return wait.Until(drv => drv.FindElements(by));
        }
        
         
    }
}
