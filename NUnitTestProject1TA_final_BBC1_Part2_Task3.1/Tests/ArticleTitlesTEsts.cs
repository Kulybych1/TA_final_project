using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;
using NUnitTestProject1TA_final_BBC1_Part2_Task3._1.PageFactoryPages;
using System.Linq;

namespace NUnitTestProject1TA_final_BBC1_Part2_Task3._1.Tests
{
    class ArticleTitlesTEsts : BaseTests
    {
        private const string expectedHeadlineArticleName = "Challenging weeks ahead, PM says, as cases top 200k";
        private const string bbc_main_url = "https://www.bbc.com/";
        private const string bbc_news_url = "https://www.bbc.com/news/coronavirus";


        [Test]
        public void checkNameOfHeadlineArticle()
        {
            getDriver().Navigate().GoToUrl(bbc_main_url);
            Assert.IsTrue(homePage().areHeadlineArticleNameMach(expectedHeadlineArticleName));
        }

        [Test]
        public void checkSecondaryArticlesTitles()
        {
           getDriver().Navigate().GoToUrl(bbc_news_url);
           Assert.IsTrue(covidNewsPage().areSecondaryArticlesMatch());
        }
    }
}
