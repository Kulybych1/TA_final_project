using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;
using NUnitTestProject1TA_final_BBC1_Part2_Task3._1.PageFactoryPages;
using System.Linq;

namespace NUnitTestProject1TA_final_BBC1_Part2_Task3._1.Tests
{

    class FormTests : BaseTests
    {
        //ValidDataForFormInputs
        private string textData = "Here is my story sdfsdfsdfsdfs";
        private const string nameData = "Nick";
        private const string emailData = "fjqgrezlevoopvwgpi@nthrw.com";
        private const string conyactNumberData = "+3806723424";
        private const string locationData = "Kyiv";

        //InvalidDataForFormInputs
        private string invalidTextData = "";
        private const string invalidNameData = "";
        private const string invalidEmailData = "fjqgrezlevoopvwgpi";

        //CheckBoxCheck
        private const bool acceptCheckbox = true;
        private const bool notAcceptCheckbox = false;

    
        [Test]
        public void checkTheFormWithValidInput()
        {
            DataLists setDataList = new DataLists(textData, nameData, emailData, conyactNumberData, locationData);

            storiesPage().fillStoriesPageForm(setDataList, acceptCheckbox, acceptCheckbox);

            storiesPage().implicitWait(30);
            Assert.IsTrue(storiesPage().validResultExpectedIsDisplayed());
        }

        [Test]
        public void checkTheFormWithInvalidTextareaInput()
        {
            DataLists setDataList = new DataLists(invalidTextData, nameData, emailData, conyactNumberData, locationData);

            storiesPage().fillStoriesPageForm(setDataList, acceptCheckbox, acceptCheckbox);

            storiesPage().implicitWait(30);
            Assert.IsTrue(storiesPage().textareaInvalidAssertIsDisplayed());
        }

        [Test]
        public void checkTheFormWithInvalidNameInput()
        {
            DataLists setDataList = new DataLists(textData, invalidNameData, emailData, conyactNumberData, locationData);

            storiesPage().fillStoriesPageForm(setDataList, acceptCheckbox, acceptCheckbox);

            storiesPage().implicitWait(30);
            Assert.IsTrue(storiesPage().nameInvalidAssertIsDisplayed());
        }

        [Test]
        public void checkTheFormWithInvalidEmailInput()
        {
            DataLists setDataList = new DataLists(textData, nameData, invalidEmailData, conyactNumberData, locationData);

            storiesPage().fillStoriesPageForm(setDataList, acceptCheckbox, acceptCheckbox);

            storiesPage().implicitWait(30);
            Assert.IsTrue(storiesPage().emailInvalidAsserttIsDisplayed());
        }

        [Test]
        public void checkTheFormWithUncheckedTermsOfServiceCheckbox() {
            DataLists setDataList = new DataLists(textData, nameData, emailData, conyactNumberData, locationData);

            storiesPage().fillStoriesPageForm(setDataList, acceptCheckbox, notAcceptCheckbox);

            storiesPage().implicitWait(30);
            Assert.IsTrue(storiesPage().invalidTermsOfServiceCheckboxAssertIsDisplayed());
        }
    }
}
