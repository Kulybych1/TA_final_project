﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;

namespace NUnitTestProject1TA_final_BBC1_Part2_Task3._1.PageFactoryPages
{
    class CovidNewsPage:BasePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[@class='no-mpu']//h3[contains(@class,'gs-u-mt+')]")]
        protected IWebElement actualHeadlineArticleName;

        private readonly By listOfHeaders = By.XPath("//div[@class='no-mpu']//div[@class='gel-layout gel-layout--equal']//h3[contains(@class,'gel-pica-bold nw-o-link-split__text')]");

        public CovidNewsPage(IWebDriver driver) : base(driver) {
            this.driver = driver;
        }

        public bool areSecondaryArticlesMatch()
        {
            int[] elementPositionToCheck = new int[] { 0, 3 }; //Finds the first from the right and the one under it 
            bool expected = true;

            DataLists expectedResults = new DataLists();

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