using System;
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
    public class SearchResultPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public SearchResultPage(IWebDriver driver1, WebDriverWait wait1)
        {
            driver = driver1;
            wait = wait1;
        }

        public void CheckPrice(int order, string price)
        {
            Assert.AreEqual(price, driver.FindElements(By.XPath(".//*[@id='flightModuleList']/div/li/div[2]/div/div[2]/div/div/div[1]/span[@class='visuallyhidden']"))[order-1].Text);
        }

        public void CheckPriceIsNotOneDollar(int order)
        {
            Assert.IsTrue("$1" != driver.FindElements(By.XPath(".//*[@id='flightModuleList']/div/li/div[2]/div/div[2]/div/div/div[1]/span[@class='visuallyhidden']"))[order - 1].Text);
        }

        public void CheckAirlinesBeneathStops()
        {
            int stopsID = 0;
            int airlinesIncludedID = 0;
            int countOfFilters = driver.FindElements(By.XPath(".//*[@id='filterContainer']/fieldset/legend/span[1]")).Count;
            for (int i=0; i<=countOfFilters; i++)
            {
                if (driver.FindElements(By.XPath(".//*[@id='filterContainer']/fieldset/legend/span[1]"))[i].GetAttribute("textContent") == "Stops")
                {
                    stopsID = i+1;
                }
                else if (driver.FindElements(By.XPath(".//*[@id='filterContainer']/fieldset/legend/span[1]"))[i].GetAttribute("textContent") == "Airlines included")
                {
                    airlinesIncludedID = i+1;
                }

                if (airlinesIncludedID != 0 && stopsID !=0)
                {
                    break;
                }
            }

            Assert.IsTrue(stopsID < airlinesIncludedID);
        }
    }
}
