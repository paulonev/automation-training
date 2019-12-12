using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Runtime.Serialization;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace WebDriver.Pages
{
    public class CarSummaryPage : AbstractPage
    {
        private static DateTimeFormat DTF = new DateTimeFormat("dd/MM/yyyy");

        [FindsBy(How = How.CssSelector, Using = "input.pickup-date-input")]
        public IWebElement StartDateElement { get; set; }
        
        public CarSummaryPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public string PickDate(String date)
        {
            WaitForElementsToBeVisible(By.CssSelector(
                "input.pickup-date-input"));
            
            //            new WebDriverWait(driver, TimeSpan.FromSeconds(TIME_TO_FIND_ELEMENT))
//                .Until(ExpectedConditions.ElementIsVisible(
//                    By.CssSelector("input.pickup-date-input")));
            
            int day = GetDayFromDate(date);
//            int count = dates.Count; // counts right
            StartDateElement.Click();

            IWebElement dateBlock = WaitForElementsToBeVisible(By.XPath(
                "/html/body/div[5]/div[4]/div/div[2]/div/div/div/div[1]/div[2]/div/div[1]/div[1]" +
                "/div[1]/div/div/div/div/div/table/tbody/tr/td/div[contains(text(),"+day+")]"
            ))[0];
            
            dateBlock.Click();
            String str = WaitForElementsToBeVisible(By.CssSelector(
                ".invalid-time-range-message"))[0].Text;
            
            Thread.Sleep(500);
            return str;
        
            //            SetDate(date);
            //_datePickerPage = new DatePickerPage(driver);
            //_datePickerPage.SetDate(date);
        }
        
        
        //        private void SetDate(String date)
//        {
            //            dates = WaitForElementsToBeVisible(By.CssSelector(".picker__day--infocus"));
//            Thread.Sleep(1000);

//            var selectedDates = dates.Where(d => d.Text == day.ToString());
//            foreach (var d in dates)
//            {
//                if (d.Text == day.ToString())
//                {
//                    d.Click();
//                    break;
//                }
//            }
            
//            var webElements = selectedDates.ToArray();
//            if(webElements.Any()) webElements[0].Click();
//            else throw new ArgumentNullException($"Date '{date}' wasn't found");
//        }

        private int GetDayFromDate(String date)
        {
            DateTime dt = DateTime.ParseExact(date, DTF.FormatString , CultureInfo.InvariantCulture);
            return dt.Day;
        }
        
        private ReadOnlyCollection<IWebElement> WaitForElementsToBeVisible(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TIME_TO_FIND_ELEMENT));
            return wait.Until(drv => drv.FindElements(by));
        }

        public override AbstractPage OpenPage(string url)
        {
            throw new System.NotImplementedException();
        }

    }
}