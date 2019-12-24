using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;

namespace WebDriver.Page
{
    public class TripsPage : AbstractPage
    {
        public TripsPage(IWebDriver driver, string url) : base(driver)
        {
            OpenPage(url);
        }

        public override AbstractPage OpenPage(string url)
        {
            driver.Url = url;
            return this;
        }

        public int CountUserTrips()
        {
            ReadOnlyCollection<IWebElement> trips =
                FindElementsBy(By.XPath("//div[@class='user-history-section']/div"));
//            Thread.Sleep(1000);
            return trips.Count;
        }
    }
}