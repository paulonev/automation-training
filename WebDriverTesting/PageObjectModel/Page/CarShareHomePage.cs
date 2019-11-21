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
        private string HOMEPAGE_URL = "https://getaround.com/cars";
        private IWebDriver driver;
        
        [FindsBy(How = How.CssSelector, Using = "button.ProviderButton--google")]
        public IWebElement GoogleBtn { get; set; }
        
        public CarShareHomePage(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            PageFactory.InitElements(driver,this);
        }

        public CarShareHomePage OpenHomePage()
        {
            driver.Navigate().GoToUrl(HOMEPAGE_URL);
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
            
            GoogleLoginPage loginPage = new GoogleLoginPage(driver);
            loginPage.LogInGoogle();

            driver.SwitchTo().Window(MainWindow);
            
            return new CarShareSearchPage(driver);
            
        }
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