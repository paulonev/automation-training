using System.Threading;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Pages
{
    public class HomePage : AbstractPage
    {
        private readonly string HOMEPAGE_URL = "https://www.epicgames.com";

        private IWebElement BrowseBtn;
        
        
        public HomePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        public override AbstractPage OpenPage()
        {
            _driver.Url = HOMEPAGE_URL;
            WaitForLoading();
            return this;
        }

        public GamesPage EnterBrowseMode()
        {
            BrowseBtn =
                FindElementsBy(By.XPath("//a[@class='NavigationHorizontal-item_88fdc2f9']"))[0];
            ((IJavaScriptExecutor) _driver).ExecuteScript("arguments[0].click();", BrowseBtn);
            return new GamesPage(_driver);
        }
    }
}