using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;
using SeleniumExtras.PageObjects;
using SeleniumWebDriverExtensions;

namespace WebDriver.Page
{
    //homepage
    public class SeleniumHQHomePage
    {
        private string HOMEPAGE_URL = "https://getaround.com/";
        private IWebDriver driver;
        
        [FindsBy(How = How.XPath, Using = "//a[@href='/cars']")]
        public IWebElement SearchCarBtn { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//a[text() = 'Continue with Google']")]
        public IWebElement GoogleBtn { get; set; }
        
        public SeleniumHQHomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        public SeleniumHQHomePage OpenHomePage()
        {
            driver.Url = HOMEPAGE_URL;
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            //new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return this;
        }
        
        public SeleniumHQSearchPage OpenSearchPage()
        {
            IJavaScriptExecutor je = (IJavaScriptExecutor) driver;
            je.ExecuteScript("arguments[0].click();", SearchCarBtn);   
            
            return new SeleniumHQSearchPage(driver);
        }

        public SeleniumHQHomePage LogInByGoogle()
        {
            GoogleBtn.Click();
            return new GoogleLoginPageEmail(driver).MoveNextLogIn();
        }

//        public SeleniumHQSearchResultsPage SearchForTerms(string searchString)
//        {
//            InputStreetField.SendKeys(searchString);
//            //Find element taking into consideration explicit wait for finding it
//            //IWebElement searchTextBox = waitForElementLocatedBy(driver, By.Id("q"));
//            //searchTextBox.SendKeys(searchString);
//        }
        
            
        //ReadOnlyCollection<IWebElement> searchBtn = driver.FindElements(By.XPath("//*[@value='Go']"));
        //searchBtn[0].Click();
        
//        private IWebElement waitForElementLocatedBy(IWebDriver _driver, By by)
//        {
//            //TODO: try with predicate d => d.FindElement(by) at safe connection
//            return new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
//                .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by))[0];
//        }
    }
}