using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;

namespace BBC1_task_4._1._1.Pages
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//a[@rev='hero1|headline']")]
        protected IWebElement headlineArticleName; 

        public HomePage(IWebDriver driver) : base(driver) { }

        public bool AreHeadlineArticleNameMach(string expected)
        {
            return headlineArticleName.Text.Contains(expected);
        }
    }
}
