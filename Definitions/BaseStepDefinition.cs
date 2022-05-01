using BBC1_task_4._1._1.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;
using BBC1_task_4._1._1.BLL;


namespace BBC1_task_4._1._1.Definitions
{
    public class BaseStepDefinition
    {
        protected IWebDriver driver;
        protected StoriesPage storiesPage = null;
        protected CovidNewsPage covidNewsPage = null;
        protected HomePage homePage = null;
        protected Articles_bll articles_Bll = null;
        protected Form_bll form_Bll = null;

        private readonly By pop_up = By.XPath("//button[@class='fc-button fc-cta-consent fc-primary-button']");

        [Before]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.bbc.com/news/10725415");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(pop_up));

            driver.FindElement(pop_up).Click();
        }

        [After]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
