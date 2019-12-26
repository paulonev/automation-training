using System;
using System.Data;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Pages;

namespace Tests
{
    public class SelectCategoriesTest
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

        [TestCase("Shooter","Multiplayer","Tom Clancy's Rainbow Six Quarantine")]
        [TestCase("Strategy","Singleplayer","Mutant Year Zero: Road To Eden")]
        public void Select_Categories(string c, string f, string expectedName)
        {
            int gameNumber = 2;
            HomePage hp = (HomePage) new HomePage(driver).OpenPage();
            GamesPage gp = (GamesPage) hp.EnterBrowseMode().OpenPage();

            gp.SelectParameters(c,f);
            string gameTitle = GamesPage.GetGameTitle(driver, gameNumber);
            
            Assert.AreEqual(expectedName, gameTitle);
            
        }
    }
}