﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
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
            wait.Until(ExpectedConditions.ElementExists(By.Id("tab-flight-tab-hp")));
        }

        public void SelectFlights()
        {
            driver.FindElement(By.Id("tab-flight-tab-hp")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.Id("flight-origin-hp-flight")));
        }

        public void SelectFlyFrom(string city, string airport)
        {
            driver.FindElement(By.Id("flight-origin-hp-flight")).SendKeys(city + Keys.Right);
            wait.Until(ExpectedConditions.ElementExists(By.Id("typeaheadDataPlain")));
            driver.FindElement(By.PartialLinkText(airport)).Click();
        }

        public void SelectFlyTo(string city, string airport)
        {
            driver.FindElement(By.Id("flight-destination-hp-flight")).SendKeys(city + Keys.Right);
            wait.Until(ExpectedConditions.ElementExists(By.Id("typeaheadDataPlain")));
            driver.FindElement(By.PartialLinkText(airport)).Click();
        }

        /*private void SetDatepicker(string cssSelector, string date)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until<bool>(
                d => driver.FindElement(By.CssSelector(cssSelector)).Displayed);
            (driver as IJavaScriptExecutor).ExecuteScript(
                String.Format("$('{0}').datepicker('setDate', '{1}')", cssSelector, date));
        }
        public void SelectDeparting1(string date)
        {
            driver.FindElement(By.CssSelector("#flight-departing-hp-flight")).Click();
            this.SetDatepicker("#flight-departing-hp-flight", date);
            //driver.FindElement(By.Id("flight-departing-hp-flight")).Clear();
            //driver.FindElement(By.Id("flight-departing-hp-flight")).SendKeys(data);
        }*/

        public void SelectDeparting(string date)
        {
            driver.FindElement(By.Id("flight-departing-hp-flight")).Clear();
            driver.FindElement(By.Id("flight-departing-hp-flight")).SendKeys(date);
        }

        public void SelectReturning(string date)
        {
            driver.FindElement(By.Id("flight-returning-hp-flight")).Clear();
            driver.FindElement(By.Id("flight-returning-hp-flight")).SendKeys(date);
        }

        public void PickAdult(int number)
        {
            SelectElement adult = new SelectElement(driver.FindElement(By.Id("flight-adults-hp-flight")));
            adult.SelectByText(number.ToString());
        }

        public void ClickSearch()
        {
            driver.FindElement(By.XPath("//*[@type='submit']")).Click();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(".//*[@id='acol-interstitial']/div")));
        }
    }
}
