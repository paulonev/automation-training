using System.Data;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Pages;

namespace Tests
{
    public class OpenPageTests
    {
        private IWebDriver driver;
        
        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void Close()
        {
            driver.Close();
            driver = null;
        }

        [Test]
        public void Can_Open_Browse_Page()
        {
            HomePage hp = (HomePage) new HomePage(driver).OpenPage();
            string sampleText = hp.EnterBrowseMode().GetGamesText();
            
            Assert.AreEqual("220 Games", sampleText);
        }
    }
}