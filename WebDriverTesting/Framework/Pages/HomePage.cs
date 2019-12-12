using System;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using WebDriver.Model;

namespace WebDriver.Pages
{
    //homepage
    public class HomePage : AbstractPage
    {
       [FindsBy(How = How.CssSelector, Using = "button.ProviderButton--google")]
        public IWebElement GoogleBtn { get; set; }

        public HomePage(IWebDriver driver) : base(driver)
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
        }

        public override AbstractPage OpenPage(string url)
        {
            _driver.Url = url;
            _driver.Navigate().GoToUrl(_driver.Url);
            _driver.Manage().Window.Maximize();
            return this;
        }

        public AbstractPage Login(User user)
        {
            string MainWindow = _driver.CurrentWindowHandle;
            
            GoogleBtn.Click();
            ReadOnlyCollection<string> windows = _driver.WindowHandles;

            string Popup = windows[1];
            _driver.SwitchTo().Window(Popup);
            
            new GoogleLoginPage(_driver).LogInGoogle(user);
            _driver.SwitchTo().Window(windows[0]);
            return new SearchPage(_driver);
            
        }

        //        public AbstractPage OpenHelpPage(string HelpPage_Url)
//        {
//            WaitForElementsToBeVisible(By.XPath("//a[@href='"+HelpPage_Url+"']"))[0].Click();
//            return new HelpPage(driver).OpenPage(HelpPage_Url);
//        }

        //
//        public override int CountSearchResults()
//        {
//            throw new NotImplementedException();
//        }
//
//        public override AbstractPage SearchForTerms(string src)
//        {
//            throw new NotImplementedException();
//        }

        //add method that waits for page loading
        
        //        private CarShareSearchPage OpenSearchPage()
//        {
//            IJavaScriptExecutor je = (IJavaScriptExecutor) driver;
//            je.ExecuteScript("arguments[0].click();", SearchCarBtn);   
//            
//            return new CarShareSearchPage(driver);
//        }

        
        //            var alert = driver.SwitchTo().Alert();
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//            wait.Until(ExpectedConditions.AlertState(true));
//            driver.SwitchTo().Alert().SendKeys("bobpixelgun@gmail.com");
            
//            alert1.SetAuthenticationCredentials("bobpixelgun@gmail.com", "Romashka_01");
            
//            driver.SwitchTo().Alert().Accept();

//        private IWebElement waitForElementLocatedBy(IWebDriver _driver, By by)
//        {
//            //TODO: try with predicate d => d.FindElement(by) at safe connection
//            return new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
//                .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by))[0];
//        }
    }
}