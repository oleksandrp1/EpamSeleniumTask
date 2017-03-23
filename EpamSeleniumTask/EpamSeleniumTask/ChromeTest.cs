using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using EpamSeleniumTask.Pages;

namespace EpamSeleniumTask
{
    [TestFixture]
    public class ChromeTest
    {
        public IWebDriver driver;
        public WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }

        [Test]
        public void SearchFlight()
        {
            HomePage homePage = new HomePage(driver, wait);
            SearchResultPage searchResulttPage = new SearchResultPage(driver, wait);

            homePage.Open();
            homePage.SelectFlights();
            homePage.SelectFlyFrom("London", "Heathrow");
            homePage.SelectFlyTo("Dublin", "Dublin, Ireland (DUB)");
            homePage.SelectDeparting("12/01/2017");
            homePage.SelectReturning("12/07/2017");
            homePage.PickAdult(2);
            homePage.ClickSearch();
            searchResulttPage.CheckPrice(1, "$102.80");
            searchResulttPage.CheckPriceIsNotOneDollar(1);
            searchResulttPage.CheckAirlinesBeneathStops();
        }
    }
}
