using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace WebDriver.Page
{
    public class GoogleLoginPageEmail
    {
        private IWebDriver driver;

        //field for email 
        //private IWebElement emailField;
        
        //button for moving forward
        [FindsBy(How = How.XPath, Using = "//*[@id='identifierNext']")]
        public IWebElement MovingForwardBtn { get; set; }
        
        //field for email
        [FindsBy(How = How.XPath, Using = "//*[@id='identifierId']")]
        public IWebElement EmailField { get; set; }

        public GoogleLoginPageEmail(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public SeleniumHQHomePage MoveNextLogIn()
        {
            string inputString = "bobpixelgun@gmail.com";
            string js = "arguments[0].setAttribute('value','" + inputString + "')";
            ((IJavaScriptExecutor) driver).ExecuteScript(js, EmailField);
            
            ((IJavaScriptExecutor) driver).ExecuteScript("arguments[0].click();", MovingForwardBtn);
            return new GoogleLoginPassPage(driver).FinishLogIn();
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