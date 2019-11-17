using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace WebDriver.Page
{
    public class GoogleLoginPassPage
    {
        private IWebDriver driver;

        //button for moving forward
        [FindsBy(How = How.Id, Using = "identifierNext")]
        private IWebElement movingForwardBtn;
        
        //field for password 
        [FindsBy(How = How.Id, Using = "identifierId")]
        public IWebElement PasswordField { get; set; }
        
        //CssSelector for "Continue with Google" btn [button.ProviderButton--google]
        public GoogleLoginPassPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public SeleniumHQHomePage FinishLogIn()
        {
            PasswordField.SendKeys("Romashka_01");
            movingForwardBtn.Click();
            return new SeleniumHQHomePage(driver);
        }
        
    }
}