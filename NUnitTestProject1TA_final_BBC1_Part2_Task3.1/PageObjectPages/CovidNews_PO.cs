using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;


namespace NUnitTestProject1TA_final_BBC1_Part2_Task3._1.PageObjectPages
{
    class CovidNews_PO:BasePO
    {
        private readonly By actualHeadlineArticleName = By.XPath("//div[@class='no-mpu']//h3[contains(@class,'gs-u-mt+')]");
        private readonly By listOfHeaders = By.XPath("//div[@class='no-mpu']//div[@class='gel-layout gel-layout--equal']//h3[contains(@class,'gel-pica-bold nw-o-link-split__text')]");

        public CovidNews_PO(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public bool areSecondaryArticlesMatch()
        {
            int[] elementPositionToCheck = new int[] { 0, 3 }; //Finds the first from the right and the one under it 
            bool expected = true;

            DataLists_PO expectedResults = new DataLists_PO();

            IList<IWebElement> findMainHeadArticles = driver.FindElements(listOfHeaders);

            for (int i = 0; i < findMainHeadArticles.Count; i++)
            {
                if (i < elementPositionToCheck.Length && !findMainHeadArticles[elementPositionToCheck[i]].Text.Equals(expectedResults.getExpectedlistOfHearders()[elementPositionToCheck[i]]))
                {
                    expected = false;
                    throw new System.Exception(findMainHeadArticles[elementPositionToCheck[i]].Text);
                }

                if (i > elementPositionToCheck.Length) break;
            }

            return expected;
        }
    }
}
