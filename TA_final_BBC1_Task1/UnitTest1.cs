using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;

namespace TA_final_BBC1_Part1_Task1
{
    public class Tests
    {
        private WebDriver driver;
        private readonly By bbcNewsFollowLink = By.XPath("//div[@id='orb-nav-links']//a[text()='News']");
        private readonly By bbcNewsCovidFollowLink = By.XPath("//div[contains(@class,'wide-navigation')]//a[contains(@href,'coronavirus')]");

        private readonly By actualHeadlineArticleName = By.XPath("//div[@class='no-mpu']//h3[contains(@class,'gs-u-mt+')]");
        private const string expectedHeadlineArticleName = "Half of colds will be Covid, warn UK researchers";

        private readonly By listOfHeaders = By.XPath("//div[@class='gel-wrap gs-u-pt+']//h3[@class='gs-c-promo-heading__title gel-pica-bold nw-o-link-split__text']");

        List<string> expectedlistOfHearders = new List<string>
            {
            " Djokovic entry - PM",
            "N Koreaneighbours with new missile test",
            "Internets Kazakhstan fuel protests rage",
            "The Indian resembles the Grand Canyon",
            "Biden buys 500m test kits to tackle Omicron ",
            "WHO chief: An event cancelled is better than a life cancelled"
            };

        private readonly By searchInput = By.XPath("//input[@id='orb-search-q']");
        private readonly By searchButton = By.XPath("//button[@id='orb-search-button']");
        private readonly By actualFistArticleInSearch = By.XPath("//p[@class='ssrcss-6arcww-PromoHeadline e1f5wbog4']//span[1]");


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.bbc.com/");
        }

        [Test]
        public void checkNameOfHeadlineArticle()
        {
            driver.FindElement(bbcNewsFollowLink).Click();
            driver.FindElement(bbcNewsCovidFollowLink).Click();
            Assert.AreEqual(expectedHeadlineArticleName, driver.FindElement(actualHeadlineArticleName).Text);
        }

        [Test]
        public void checkSecondaryArticlesTitles()
        {
            int[] elementPositionToCheck = new int[] { 0, 3}; //Finds the first from the right and the one under it 
            bool expected = true;

           
            IList<IWebElement> findMainHeadArticles = driver.FindElements(listOfHeaders);

            for (int i = 0; i < findMainHeadArticles.Count; i++)
            {
                if (i < elementPositionToCheck.Length && !findMainHeadArticles[elementPositionToCheck[i]].Text.Equals(expectedlistOfHearders[elementPositionToCheck[i]]))
                {
                    expected = false;
                    throw new System.Exception(findMainHeadArticles[elementPositionToCheck[i]].Text);
                }

                if (i > elementPositionToCheck.Length) break;
            }

            Assert.IsTrue(expected);
        }

        [Test]
        public void test1()
        {
            driver.FindElement(bbcNewsFollowLink).Click();
            driver.FindElement(bbcNewsCovidFollowLink).Click();

            string headlineArticleLinkText = driver.FindElement(actualHeadlineArticleName).Text;
            driver.FindElement(searchInput).SendKeys(headlineArticleLinkText);

            driver.FindElement(searchButton).Click();

            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(30);

            Assert.IsTrue(driver.FindElement(actualFistArticleInSearch).Text.Contains(expectedHeadlineArticleName));
        }


        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}