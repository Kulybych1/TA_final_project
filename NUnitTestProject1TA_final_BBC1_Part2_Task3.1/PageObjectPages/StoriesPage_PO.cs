using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;

namespace NUnitTestProject1TA_final_BBC1_Part2_Task3._1.PageObjectPages
{
    class StoriesPage_PO : BasePO
    {
        //input elements
        private readonly By inputText = By.XPath("//textarea[@aria-label='Tell us your story. ']");
        private readonly By inputName = By.XPath("//input[@aria-label='Name']");
        private readonly By inputEmail = By.XPath("//input[@aria-label='Email address']");
        private readonly By inputContactNumber = By.XPath("//input[@aria-label='Contact number ']");
        private readonly By inputLication = By.XPath("//input[@aria-label='Location ']");

        //checkboxes
        private readonly By namePublishChecbox = By.XPath("//p[contains(text(),'publish my name')]/../../..//input[@type='checkbox']");
        private readonly By termsOfServiceCheckbox = By.XPath("//p[contains(text(),'I accept the ')]/../../..//input[@type='checkbox']");

        //button
        private readonly By submitButton = By.XPath("//div[@class='embed-content-container']//button[@class='button']");

        //Expected
        private readonly By validResultExpected = By.XPath("//p[contains(text(),'thanks for asking your question')]");

        //Invalid input elements assert

        private readonly By emailInvalidAssert = By.XPath("//input[@aria-label='Email address' and contains(@class,'error__input')]");
        private readonly By textareaInvalidAssert = By.XPath("//textarea[@aria-label='Tell us your story. ' and contains(@class,'long--error')]");
        private readonly By nameInvalidAssert = By.XPath("//input[@aria-label='Name' and contains(@class,'error__input')]");
        private readonly By invalidTermsOfServiceCheckboxAssert = By.XPath("//div[@class='checkbox']//div[@class='input-error-message']");

        public List<By> recieveTheListOfInputFields()
        {
            List<By> listOfInputFields = new List<By>
            {
            inputText,
            inputName,
            inputEmail,
            inputContactNumber,
            inputLication
            };
            return listOfInputFields;
        }

        public StoriesPage_PO(IWebDriver driver) : base(driver) { }

        public void fillStoriesPageForm(DataLists_PO getDataList, bool acceptNamePublishChecbox, bool acceptTermsOfServiceCheckbox)
        {

            for (int i = 0; i < recieveTheListOfInputFields().Count; i++)
                driver.FindElement(recieveTheListOfInputFields()[i]).SendKeys(getDataList.getDataForFormInputs()[i]);

            if (acceptNamePublishChecbox == true)
                driver.FindElement(namePublishChecbox).Click();

            if (acceptTermsOfServiceCheckbox == true)
                driver.FindElement(termsOfServiceCheckbox).Click();

            driver.FindElement(submitButton).Click();
        }

        public bool validResultExpectedIsDisplayed()
        {
            return driver.FindElement(validResultExpected).Displayed;
        }

        public bool textareaInvalidAssertIsDisplayed()
        {
            return driver.FindElement(textareaInvalidAssert).Displayed;
        }

        public bool nameInvalidAssertIsDisplayed()
        {
            return driver.FindElement(nameInvalidAssert).Displayed;
        }

        public bool emailInvalidAsserttIsDisplayed()
        {
            return driver.FindElement(emailInvalidAssert).Displayed;
        }

        public bool invalidTermsOfServiceCheckboxAssertIsDisplayed()
        {
            return driver.FindElement(invalidTermsOfServiceCheckboxAssert).Displayed;
        }
    }
}
