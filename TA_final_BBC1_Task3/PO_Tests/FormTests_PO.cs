using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;
using NUnitTestProject1TA_final_BBC1_Part2_Task3._1.PageObjectPages;
using System.Linq;

namespace NUnitTestProject1TA_final_BBC1_Part2_Task3._1.PO_Tests
{
    class FormTests_PO:BaseTests_PO
    {
        //ValidDataForFormInputs
        private string textData = "Here is my story sdfsdsddddfgvvvv";
        private const string nameData = "Nick";
        private const string emailData = "fjqgrezlvvpvwgpi@nthrw.com";
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
            DataLists_PO setDataList = new DataLists_PO(textData, nameData, emailData, conyactNumberData, locationData);

            storiesPage().fillStoriesPageForm(setDataList, acceptCheckbox, acceptCheckbox);

            storiesPage().implicitWait(30);
            Assert.IsTrue(storiesPage().validResultExpectedIsDisplayed());
        }

        [Test]
        public void checkTheFormWithInvalidTextareaInput()
        {
            DataLists_PO setDataList = new DataLists_PO(invalidTextData, nameData, emailData, conyactNumberData, locationData);

            storiesPage().fillStoriesPageForm(setDataList, acceptCheckbox, acceptCheckbox);

            storiesPage().implicitWait(30);
            Assert.IsTrue(storiesPage().textareaInvalidAssertIsDisplayed());
        }

        [Test]
        public void checkTheFormWithInvalidNameInput()
        {
            DataLists_PO setDataList = new DataLists_PO(textData, invalidNameData, emailData, conyactNumberData, locationData);

            storiesPage().fillStoriesPageForm(setDataList, acceptCheckbox, acceptCheckbox);

            storiesPage().implicitWait(30);
            Assert.IsTrue(storiesPage().nameInvalidAssertIsDisplayed());
        }

        [Test]
        public void checkTheFormWithInvalidEmailInput()
        {
            DataLists_PO setDataList = new DataLists_PO(textData, nameData, invalidEmailData, conyactNumberData, locationData);

            storiesPage().fillStoriesPageForm(setDataList, acceptCheckbox, acceptCheckbox);

            storiesPage().implicitWait(30);
            Assert.IsTrue(storiesPage().emailInvalidAsserttIsDisplayed());
        }

        [Test]
        public void checkTheFormWithUncheckedTermsOfServiceCheckbox()
        {
            DataLists_PO setDataList = new DataLists_PO(textData, nameData, emailData, conyactNumberData, locationData);

            storiesPage().fillStoriesPageForm(setDataList, acceptCheckbox, notAcceptCheckbox);

            storiesPage().implicitWait(30);
            Assert.IsTrue(storiesPage().invalidTermsOfServiceCheckboxAssertIsDisplayed());
        }
    }
}
