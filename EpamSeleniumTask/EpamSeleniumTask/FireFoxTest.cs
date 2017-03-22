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
            driver = new FirefoxDriver();
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

            homePage.Open();
            homePage.SelectFlights();
            homePage.SelectFlyFrom("London", "Heathrow");
        }
    }
}
