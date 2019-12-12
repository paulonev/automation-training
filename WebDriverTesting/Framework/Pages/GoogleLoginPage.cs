using System;
using System.Collections.ObjectModel;
using System.Resources;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using WebDriver.Model;

namespace WebDriver.Pages
{
    public class GoogleLoginPage : AbstractPage
    {
        //btn for proceed
        [FindsBy(How = How.XPath, Using = "//*[@id='identifierNext']")]
        public IWebElement MovingForwardBtn { get; set; }

        //btn for finishing login
        [FindsBy(How = How.XPath, Using = "//*[@id='passwordNext']")]
        public IWebElement FinishLoginBtn { get; set; }
        
        //field for email
        [FindsBy(How = How.CssSelector, Using = "#identifierId")]
        public IWebElement EmailField { get; set; }
        
        //field for password
        [FindsBy(How = How.CssSelector, Using = ".I0VJ4d > div:nth-child(1) > input")]
        public IWebElement PassField { get; set; }

        public GoogleLoginPage(IWebDriver driver) : base(driver)
        {
            OpenPage("blank");
        }

        public override AbstractPage OpenPage(string url)
        {
            WaitForLoading("signin", _driver);
            return this;
        }

        //        public override AbstractPage SearchForTerms(string src)
//        {
//            throw new NotImplementedException();
//        }
//        public override int CountSearchResults()
//        {
//            throw new NotImplementedException();
//        }


        //SearchPage
        //AbstractPage
        public void LogInGoogle(User user)
        {
            
            EmailField = WaitForElementOnPage(By.CssSelector("#identifierId"));
            EmailField.SendKeys(user.USER_EMAIL);
            Thread.Sleep(500);
            ((IJavaScriptExecutor) _driver).ExecuteScript("arguments[0].click();", MovingForwardBtn);
            Thread.Sleep(1000);
            PassField = WaitForElementOnPage(By.CssSelector(".I0VJ4d > div:nth-child(1) > input"));
            PassField.SendKeys(user.USER_PASSWD);
            Thread.Sleep(500);
            ((IJavaScriptExecutor) _driver).ExecuteScript("arguments[0].click();", FinishLoginBtn);
            
            //auto-open of search page
//            Thread.Sleep(TimeSpan.FromSeconds(20));
//            return new SearchPage(driver).OpenPage();
        }

        private IWebElement WaitForElementOnPage(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            return wait.Until(drv => drv.FindElement(by));
        }
        
        //        public bool FieldEmailExists()
//        {
//            try
//            {
//                emailField = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
//                    .Until(d => d.FindElement(By.Id("identifierId")));
//                return true;
//            }
//            catch (NoSuchElementException ex)
//            {
//                Console.Write("element EmailField wasn't found on page" + ex.Message);
//                return false;
//            }
//        }
    }
}