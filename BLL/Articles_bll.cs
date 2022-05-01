using System;
using System.Collections.Generic;
using System.Text;
using BBC1_task_4._1._1.Pages;
using BBC1_task_4._1._1.Definitions;
using OpenQA.Selenium;

namespace BBC1_task_4._1._1.BLL
{
    public class Articles_bll //без блл, как название класса, без андерскора в классах 
    {
        private IWebDriver _driver;

        public Articles_bll(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool CovidSecondaryArticlesCheck(Dictionary<int, string> expectedHeaders)
        {
            var covidNews = new CovidNewsPage(_driver);
            return covidNews.AreSecondaryArticlesMatch(expectedHeaders);
        }

        public bool HomePageArticlesCheck(string expectedArticle)
        {
            var homePage = new HomePage(_driver);
            return homePage.AreHeadlineArticleNameMach(expectedArticle);
        }
    }
}
