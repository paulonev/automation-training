using System;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace WebDriver.Page
{
    public class GoogleLoginPage
    {
        private IWebDriver driver;

        //field for email 
        //private IWebElement emailField;

        //button for moving forward
        [FindsBy(How = How.XPath, Using = "//*[@id='identifierNext']")]
        public IWebElement MovingForwardBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='passwordNext']")]
        public IWebElement FinishLoginBtn { get; set; }
        
        //field for email
        [FindsBy(How = How.CssSelector, Using = "#identifierId")]
        public IWebElement EmailField { get; set; }
        
        //field for password
        [FindsBy(How = How.CssSelector, Using = ".I0VJ4d > div:nth-child(1) > input")]
        public IWebElement PassField { get; set; }

        public GoogleLoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void LogInGoogle()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d=>d.FindElement(By.CssSelector("#identifierId")));
            EmailField.SendKeys("bobpixelgun@gmail.com");
//            driver.FindElement(By.CssSelector("#identifierId")).SendKeys("bobpixelgun@gmail.com");
            ((IJavaScriptExecutor) driver).ExecuteScript("arguments[0].click();", MovingForwardBtn);

            wait.Until(d=>d.FindElement(By.CssSelector(".I0VJ4d > div:nth-child(1) > input")));
//            driver.FindElement(By.CssSelector(".I0VJ4d > div:nth-child(1) > input")).SendKeys("Romashka_01");
            PassField.SendKeys("Romashka_01");
            
            ((IJavaScriptExecutor) driver).ExecuteScript("arguments[0].click();", FinishLoginBtn);
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