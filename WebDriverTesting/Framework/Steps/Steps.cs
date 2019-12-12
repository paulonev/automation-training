using System;
using OpenQA.Selenium;
using WebDriver.Driver;
using WebDriver.Model;
using WebDriver.Pages;

namespace WebDriver.Steps
{
    public class TestingSteps
    {
        private IWebDriver _driver;
        
        public HomePage HomePage { get; set; }
        public SearchPage SearchPage { get; set; }
        
        public TestingSteps()
        {
            DriverInit();
        }
        
        public void DriverInit()
        {
            _driver = DriverInstance.GetInstance();
        }

        public void DriverClose()
        {
            DriverInstance.CloseDriver();
        }

        public void OpenHomePage(string url)
        {
            HomePage = (HomePage) 
                new HomePage(_driver).OpenPage(url);
        }
        
        public void LoginUser(User user)
        {
            SearchPage = (SearchPage) HomePage.Login(user);
        }

        public void SelectBy(string location)
        {
            
        }
    }
}
