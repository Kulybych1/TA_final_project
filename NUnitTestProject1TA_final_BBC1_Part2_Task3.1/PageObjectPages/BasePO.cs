using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;

namespace NUnitTestProject1TA_final_BBC1_Part2_Task3._1.PageObjectPages
{
    class BasePO
    {
        protected IWebDriver driver;

        public BasePO(IWebDriver driver)
        {
            this.driver = driver;   
        }

        public void implicitWait(int seconds)
        {
            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(seconds);
        }
    }
}
