using OpenQA.Selenium;

namespace WebDriver.Page
{
    public class RequestPage : AbstractPage
    {
        public RequestPage(IWebDriver driver) : base(driver)
        {
        }

        
        
        public override AbstractPage OpenPage(string url)
        {
            throw new System.NotImplementedException();
        }
    }
}