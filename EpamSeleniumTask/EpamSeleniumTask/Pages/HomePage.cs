using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;
using NUnit.Framework;

namespace EpamSeleniumTask.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public HomePage(IWebDriver driver1, WebDriverWait wait1)
        {
            driver = driver1;
            wait = wait1;
        }

        public void Open()
        {
            driver.Url = "https://www.expedia.com/";
            wait.Until(ExpectedConditions.TitleContains("Vacations"));
        }

        public void SelectFlights()
        {
            driver.FindElement(By.XPath).Click();
            driver.FindElement(By.CssSelector("button.tab.flight")).Click();
            //wait.Until(ExpectedConditions.ElementExists(driver.FindElement(By.Id("flight-type-roundtrip-label-hp-flight"))));
        }

        public void SelectFlyFrom(string city, string airport)
        {
            driver.FindElement(By.Id("flight-origin-hp-flight")).SendKeys(city);
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("autocomplete-dropdown")));
            driver.FindElement(By.PartialLinkText(airport));
        }
    }
}
