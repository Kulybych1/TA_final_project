using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BBC1_task_4._1._1.Pages
{
    public class BasePage
    {
        private IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void ImplicitWait(int seconds)
        {
            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(seconds);
        }

        public void WaitVisibilityOfElement(long timeToWait, string element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(element)));
        }
    }
}
