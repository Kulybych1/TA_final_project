using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;
using NUnitTestProject1TA_final_BBC1_Part2_Task3._1.PageObjectPages;

namespace NUnitTestProject1TA_final_BBC1_Part2_Task3._1.PO_Tests
{
    class BaseTests_PO
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.bbc.com/news/10725415");

            if (driver.FindElement(By.XPath("//button[@class='tp-close tp-active']")).Displayed)
                driver.FindElement(By.XPath("//button[@class='tp-close tp-active']")).Click();
        }

        public IWebDriver getDriver()
        {
            return driver;
        }

        public StoriesPage_PO storiesPage()
        {
            return new StoriesPage_PO(getDriver());
        }

        public HomePage_PO homePage()
        {
            return new HomePage_PO(getDriver());
        }

        public CovidNews_PO covidNewsPage()
        {
            return new CovidNews_PO(getDriver());
        }

        [TearDown]
        public void tearDown()
        {
            driver.Quit();
        }
    }
}
