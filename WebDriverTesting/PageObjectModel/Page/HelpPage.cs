using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebDriver.Page
{
    public class HelpPage : AbstractPage
    {
        public HelpPage(IWebDriver driver) : base(driver)
        {
        }

        public override AbstractPage OpenPage(string url)
        {
            driver.Url = url;
            driver.Navigate().GoToUrl(driver.Url);
            driver.Manage().Window.Maximize();
            return this;
        }

        public AbstractPage GoToRequestPage()
        {
            FindElementsBy(By.XPath("//a[contains(text(),\"Submit a request\")]"))
                [0].Click();

            return new RequestPage(driver);
        }

        public void SelectProblem(string problem)
        {
            FindElementsBy(By.
                XPath("//div[@class='form-field select optional request_ticket_form_id']"))[0].Click();
            IWebElement selectElement = 
                WaitForElementToBeVisible(By.XPath("//div[@class=\"nesty-panel\"]"));
            ((IJavaScriptExecutor) driver)
                .ExecuteScript("arguments[0].scrollIntoView(true);", selectElement);
//*[@id=\"request_issue_type_select\"]
//            IWebElement selectElement =
//                WaitForElementsToBeVisible(By.XPath("//div[@class=\"nesty-panel\"]"))[0];

//            var select = new SelectElement(selectElement);
            Thread.Sleep(1000);
            
//            select.SelectByText(problem);
            driver.FindElement(By.CssSelector(" body:nth-child(2) > div.nesty-panel:nth-child(10) > div:nth-child(1)")).Click();
            Thread.Sleep(1000);
            
        }

        public void AddCredentials(string e, string s, string d)
        {
            //email, subject, description
            
        }
    }
}