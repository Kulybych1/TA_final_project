using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;
using NUnitTestProject1TA_final_BBC1_Part2_Task3._1.PageFactoryPages;

namespace NUnitTestProject1TA_final_BBC1_Part2_Task3._1.Tests
{
    class BaseTests
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

        public StoriesPage storiesPage()
        {
            return new StoriesPage(getDriver());
        }

        public HomePage homePage()
        {
            return new HomePage(getDriver());
        }

        public CovidNewsPage covidNewsPage()
        {
            return new CovidNewsPage(getDriver());
        }

        [TearDown]
        public void tearDown()
        {
            driver.Quit();
        }
    }
}
