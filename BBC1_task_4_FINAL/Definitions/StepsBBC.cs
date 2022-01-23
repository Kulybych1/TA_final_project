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
        ////ValidDataForFormInputs
        //private readonly string textData = "Here is my story sdfsdfsdfsdfdfsdfs";
        //private readonly string nameData = "Nick";
        //private readonly string emailData = "fjqgrezlevoopvwgpi@nthrw.com";
        //private readonly string conyactNumberData = "+3806723424";
        //private readonly string locationData = "Kyiv";

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

            storiesPage.FillStoriesPageForm(inputData, acceptCheckbox, acceptCheckbox);
        }

        [Then(@"User can see the form is (.*)")]
        public void ThenUserCanSeeTheFormIs(string message)
        {
            storiesPage.ImplicitWait(30);
            Assert.IsTrue(storiesPage.ValidResultExpectedIsDisplayed().Contains(message));
        }

        [Then(@"User can see the form InvalidText assert (.*)")]
        public void ThenUserCanSeeTheFormInvalidTextAssert(string message)
        {
            storiesPage.ImplicitWait(30);
            Assert.IsTrue(storiesPage.TextareaInvalidAssertIsDisplayed().Contains(message));
        }

        [Then(@"User can see the form InvalidName assert (.*)")]
        public void ThenUserCanSeeTheFormInvalidNameAssert(string message)
        {
            storiesPage.ImplicitWait(30);
            Assert.IsTrue(storiesPage.NameInvalidAssertIsDisplayed().Contains(message));
        }

        [Then(@"User can see the form InvalidEmail assert (.*)")]
        public void ThenUserCanSeeTheFormInvalidEmailAssert(string message)
        {
            storiesPage.ImplicitWait(30);
            Assert.IsTrue(storiesPage.EmailInvalidAsserttIsDisplayed().Contains(message));
        }

        [When(@"User enter data wirh unchecked box (.*) (.*) (.*) (.*) (.*) (.*)")]
        public void WhenUserEnterDataWirhUncheckedBox(string textData, string nameData, string emailData, string conyactNumberData, string locationData, string check)
        {
            var inputData = new Dictionary<string, string>()
           {
               {storyField, textData },
               {nameField, nameData },
               {emailField, emailData },
               {contactNumberField, conyactNumberData },
               {locationField, locationData },
           };

            if(check=="tree")
                storiesPage.FillStoriesPageForm(inputData, acceptCheckbox, acceptCheckbox);
            else storiesPage.FillStoriesPageForm(inputData, acceptCheckbox, declineCheckbox);
        }

        [Then(@"User can see the form with UncheckedTermsOfServiceCheckbox assert (.*)")]
        public void ThenUserCanSeeTheFormWithUncheckedTermsOfServiceCheckboxAssert(string message)
        {
            storiesPage.ImplicitWait(30);
            Assert.IsTrue(storiesPage.InvalidTermsOfServiceCheckboxAssertIsDisplayed().Contains(message));
        }


        [Given(@"User goes to bbc Home page")]
        public void GivenUserGoesToBbcHomePage()
        {
            homePage = new HomePage(driver);
        }

        [When(@"User navigates to Main (.*)")]
        public void WhenUserNavigatesToMain(string link)
        {
            driver.Navigate().GoToUrl(link);
        }

        [Then(@"User can see matcing articles (.*)")]
        public void ThenUserCanSeeMatcingArticles(string expected)
        {
            Assert.IsTrue(homePage.AreHeadlineArticleNameMach(expected));
        }


        [Given(@"User goes to bbc covid news")]
        public void GivenUserGoesToBbcCovidNews()
        {
            covidNewsPage = new CovidNewsPage(driver);
        }

        [When(@"User navigates to news (.*)")]
        public void WhenUserNavigatesToNews(string link)
        {
            driver.Navigate().GoToUrl(link);
        }

        [Then(@"User see matcing articles (.*) (.*) (.*) (.*) (.*)")]
        public void ThenUserSeeMatcingArticles(string firstArticle, string secondArticle, string thirdArticle, string fourthArticle, string fifthArticle)
        {
            Assert.IsTrue(covidNewsPage.AreSecondaryArticlesMatch(firstArticle, secondArticle, thirdArticle, fourthArticle, fifthArticle));
        }

    }
}

