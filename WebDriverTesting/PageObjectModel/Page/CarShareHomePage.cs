using System;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace WebDriver.Page
{
    //homepage
    public class CarShareHomePage
    {
        private string HOMEPAGE_URL = "https://getaround.com/";
        private IWebDriver driver;
        
        [FindsBy(How = How.XPath, Using = "//a[@href='/cars']")]
        public IWebElement SearchCarBtn { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//a[text() = 'Continue with Google']")]
        public IWebElement GoogleBtn { get; set; }
        
        public CarShareHomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        public CarShareHomePage OpenHomePage()
        {
//            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
            driver.Url = HOMEPAGE_URL;
            return this;
        }

        public CarShareSearchPage Login()
        {
            string MainWindow = driver.CurrentWindowHandle;
            
            GoogleBtn.Click();
            ReadOnlyCollection<string> windows = driver.WindowHandles;

            string Popup = windows[1];
            driver.SwitchTo().Window(Popup);
            
//            Thread.Sleep(5000);
            
            //            WebDriverWait waitForLogin = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//            waitForLogin.Until(ExpectedConditions.ElementExists(By.CssSelector(".location-input")));           

//            foreach (var window in driver.WindowHandles)
//            {
//                Console.WriteLine(window);
//            }
            
//            driver.SwitchTo().Window(MainWindow);
            new GoogleLoginPage(driver).LogInGoogle();
            
            driver.SwitchTo().Window(windows[0]);
            return new CarShareSearchPage(driver);
            
        }
        public CarShareSearchPage OpenSearchPage()
        {
            IJavaScriptExecutor je = (IJavaScriptExecutor) driver;
            je.ExecuteScript("arguments[0].click();", SearchCarBtn);   
            
            return new CarShareSearchPage(driver);
        }

        
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