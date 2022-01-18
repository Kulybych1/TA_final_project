using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;

namespace NUnitTestProject1TA_final_BBC1_Part2_Task3._1.PageObjectPages
{
    class HomePage_PO:BasePO
    {
        private readonly By bbcNewsFollowLink = By.XPath("//div[@id='orb-nav-links']//a[text()='News']");
        private readonly By bbcNewsCovidFollowLink = By.XPath("//div[contains(@class,'wide-navigation')]//a[contains(@href,'coronavirus')]");
        private readonly By actualHeadlineArticleName = By.XPath("//a[@rev='hero1|headline']");
       
        public HomePage_PO(IWebDriver driver) : base(driver) {}

        public bool areHeadlineArticleNameMach(string expected)
        {
            return driver.FindElement(actualHeadlineArticleName).Text.Contains(expected);
        }
    }
}
