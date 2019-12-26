using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Pages
{
    public class GamesPage : AbstractPage
    {
//        private readonly string PAGE_URL = "https://www.epicgames.com/store/en-US/browse";
        
        public GamesPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        public override AbstractPage OpenPage()
        {
            WaitForLoading();
            Thread.Sleep(2000);
            return this;
        }

        public string GetGamesText()
        {
            IWebElement totalGames = FindElementsBy(By.XPath("//span[contains(text(),'220 Games')]"))[0];
            return totalGames.Text;
        }

        public static string GetGameTitle(IWebDriver driver, int game)
        {
            string titleXPath = "//div[contains(@class, 'cardsContainer')]" +
                                "/child::div["+game+"]//ancestor::span[contains(@class,'Card-title')]";
            IWebElement gameCardTitle = new WebDriverWait(driver, TimeSpan.FromSeconds(TIME_TO_FIND_ELEMENT))
                .Until(c => c.FindElement(By.XPath(titleXPath)));
            return gameCardTitle.Text;
        }

        public void SelectParameters(string cat, string feat)
        {
            SelectFeature(feat);
            SelectCategory(cat);
        }

        private void SelectFeature(string feature)
        {
            IWebElement feat = FindElementCustom("//li[contains(@data-testid,\"",  feature.ToUpper() + "\")]");
            ((IJavaScriptExecutor) _driver).ExecuteScript("arguments[0].click();", feat); 
            Thread.Sleep(1000); 
        
        }
        
        private void SelectCategory(string category)
        {
            IWebElement cat = FindElementCustom("//li[contains(@data-testid,\"",  category.ToUpper() + "\")]");
            ((IJavaScriptExecutor) _driver).ExecuteScript("arguments[0].click();", cat); 
            Thread.Sleep(1000); 
        }

        private IWebElement FindElementCustom(string pattern, string feature)
        {
            string customXPath = pattern + feature;
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(TIME_TO_FIND_ELEMENT))
                .Until(e => e.FindElement(By.XPath(customXPath + "//button")));
        }

    }
}