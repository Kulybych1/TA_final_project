using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;


namespace NUnitTestProject1TA_final_BBC1_Part2_Task3._1.PageFactoryPages
{
    class HomePage:BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[@id='orb-nav-links']//a[text()='News']")]
        protected IWebElement bbcNewsFollowLink;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'wide-navigation')]//a[contains(@href,'coronavirus')]")]
        protected IWebElement bbcNewsCovidFollowLink;

        [FindsBy(How = How.XPath, Using = "//a[@rev='hero1|headline']")]
        protected IWebElement actualHeadlineArticleName;

        

        public HomePage(IWebDriver driver) : base(driver) { }

        public bool areHeadlineArticleNameMach(string expected)
        {
            return actualHeadlineArticleName.Text.Contains(expected);
        }



    }
}
