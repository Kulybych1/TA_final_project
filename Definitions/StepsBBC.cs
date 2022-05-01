using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using BBC1_task_4._1._1.Pages;
using BBC1_task_4._1._1.Definitions;
using System.Collections.Generic;

namespace BBC1_task_4._1._1.Definitions
{
    [Binding]
    public class StepsBBC : BaseStepDefinition
    {
        //empty fields
        private readonly string storyField = "Tell us your story. ";
        private readonly string nameField = "Name";
        private readonly string emailField = "Email address";
        private readonly string contactNumberField = "Contact number ";
        private readonly string locationField = "Location ";

        //CheckBoxCheck
        private readonly bool acceptCheckbox = true;
        private readonly bool declineCheckbox = false;

        [Given(@"User goes to bbc Stories page")]
        public void GivenUserGoesToBbcStoriesPage()
        {
            storiesPage = new StoriesPage(driver);
            form_Bll = new BLL.Form_bll(driver);
        }

        [When(@"User enter the (.*) (.*) (.*) (.*) (.*)")]
        public void WhenUserEnterTheIn(string textData, string nameData, string emailData, string conyactNumberData, string locationData)
        {
            var inputData = new Dictionary<string, string>()
           {
               {storyField, textData },
               {nameField, nameData },
               {emailField, emailData },
               {contactNumberField, conyactNumberData },
               {locationField, locationData },
           };
 
            form_Bll.FillForm(inputData, acceptCheckbox, acceptCheckbox);
        }

        [Then(@"User can see the form passed")]
        public void ThenUserCanSeeTheFormPassed()
        {
            storiesPage.ImplicitWait(30);
            Assert.IsTrue(storiesPage.ValidResultExpectedIsDisplayed());
        }

        [Then(@"User can see the form InvalidText assert")]
        public void ThenUserCanSeeTheFormInvalidTextAssert()
        {
            storiesPage.ImplicitWait(30);
            Assert.IsTrue(storiesPage.TextareaInvalidAssertIsDisplayed());
        }


        [Then(@"User can see the form InvalidName assert")]
        public void ThenUserCanSeeTheFormInvalidNameAssert()
        {
            storiesPage.ImplicitWait(30);
            Assert.IsTrue(storiesPage.NameInvalidAssertIsDisplayed());
        }

        [Then(@"User can see the form InvalidEmail assert")]
        public void ThenUserCanSeeTheFormInvalidEmailAssert()
        {
            storiesPage.ImplicitWait(30);
            Assert.IsTrue(storiesPage.EmailInvalidAsserttIsDisplayed());
        }


        [When(@"User enter data wirh unchecked box (.*) (.*) (.*) (.*) (.*) (.*)")]
        public void WhenUserEnterDataWirhUncheckedBox(string textData, string nameData, string emailData, string conyactNumberData, string locationData, bool check)
        {
            var inputData = new Dictionary<string, string>()
           {
               {storyField, textData },
               {nameField, nameData },
               {emailField, emailData },
               {contactNumberField, conyactNumberData },
               {locationField, locationData },
           };
           
            form_Bll.FillForm(inputData, acceptCheckbox, check);
        }

        [Then(@"User can see the form with UncheckedTermsOfServiceCheckbox assert")]
        public void ThenUserCanSeeTheFormWithUncheckedTermsOfServiceCheckboxAssert()
        {
            storiesPage.ImplicitWait(30);
            Assert.IsTrue(storiesPage.InvalidTermsOfServiceCheckboxAssertIsDisplayed());
        }

        [Given(@"User goes to bbc Home page")]
        public void GivenUserGoesToBbcHomePage()
        {
            homePage = new HomePage(driver);
            articles_Bll = new BLL.Articles_bll(driver);
        }

        [When(@"User navigates to Main (.*)")]
        public void WhenUserNavigatesToMain(string link)
        {
            driver.Navigate().GoToUrl(link);
        }

        [Then(@"User can see matcing articles (.*)")]
        public void ThenUserCanSeeMatcingArticles(string expected)
        {
            Assert.IsTrue(articles_Bll.HomePageArticlesCheck(expected));
        }

        [Given(@"User goes to covid news")]
        public void GivenUserGoesToCovidNews() //драйвер в отдельном классе 
        {
            covidNewsPage = new CovidNewsPage(driver);
            articles_Bll = new BLL.Articles_bll(driver);
        }

        [When(@"User navigates via the (.*)")]
        public void WhenUserNavigatesViaThe(string link)
        {
            driver.Navigate().GoToUrl(link);
        }

        [Then(@"User se articles ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void ThenUserSeArticles(string firstArticle, string underTheFirstArticle, int firstArticlePos, int underTheFirstPos)
        {
            var expectedHeadersList = new Dictionary<int, string>
            {
                { firstArticlePos, firstArticle},
                {underTheFirstPos,underTheFirstArticle }
            };

            Assert.IsTrue(articles_Bll.CovidSecondaryArticlesCheck(expectedHeadersList));
        }
    }
}

