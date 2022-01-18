using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;

namespace NUnitTestProject1TA_final_BBC1_Part2_Task3._1.PageFactoryPages
{
    class StoriesPage:BasePage
    {
        //input elements
        [FindsBy(How = How.XPath, Using = "//textarea[@aria-label='Tell us your story. ']")]
        protected IWebElement inputText;
        
        [FindsBy(How = How.XPath, Using = "//input[@aria-label='Name']")]
        private IWebElement inputName;
        
        [FindsBy(How = How.XPath, Using = "//input[@aria-label='Email address']")]
        private IWebElement inputEmail;
        
        [FindsBy(How = How.XPath, Using = "//input[@aria-label='Contact number ']")]
        private IWebElement inputContactNumber;
        
        [FindsBy(How = How.XPath, Using = "//input[@aria-label='Location ']")]
        private IWebElement inputLication;

        //checkboxes
        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'publish my name')]/../../..//input[@type='checkbox']")]
        private IWebElement namePublishChecbox;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'I accept the ')]/../../..//input[@type='checkbox']")]
        private IWebElement termsOfServiceCheckbox;

        //button
        [FindsBy(How = How.XPath, Using = "//div[@class='embed-content-container']//button[@class='button']")]
        private IWebElement submitButton;

        //Expected
        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'thanks for asking your question')]")]
        private IWebElement validResultExpected;

        //Invalid input elements assert
        [FindsBy(How = How.XPath, Using = "//input[@aria-label='Email address' and contains(@class,'error__input')]")]
        private IWebElement emailInvalidAssert;

        [FindsBy(How = How.XPath, Using = "//textarea[@aria-label='Tell us your story. ' and contains(@class,'long--error')]")]
        private IWebElement textareaInvalidAssert;

        [FindsBy(How = How.XPath, Using = "//input[@aria-label='Name' and contains(@class,'error__input')]")]
        private IWebElement nameInvalidAssert;

        [FindsBy(How = How.XPath, Using = "//div[@class='checkbox']//div[@class='input-error-message']")]
        private IWebElement invalidTermsOfServiceCheckboxAssert;

        public List<IWebElement> recieveTheListOfInputFields()
        {
            List<IWebElement> listOfInputFields = new List<IWebElement>
            {
            inputText,
            inputName,
            inputEmail,
            inputContactNumber,
            inputLication
            };
            return listOfInputFields;
        }

        public StoriesPage(IWebDriver driver) : base(driver) { }

        public void fillStoriesPageForm(DataLists getDataList, bool acceptNamePublishChecbox, bool acceptTermsOfServiceCheckbox)
        {

            for (int i = 0; i < recieveTheListOfInputFields().Count; i++)
                recieveTheListOfInputFields()[i].SendKeys(getDataList.getDataForFormInputs()[i]);


            if (acceptNamePublishChecbox == true)
                namePublishChecbox.Click();

            if (acceptTermsOfServiceCheckbox == true)
                termsOfServiceCheckbox.Click();

            submitButton.Click();  
        }

        public bool validResultExpectedIsDisplayed()
        {
            return validResultExpected.Displayed;
        }

        public bool textareaInvalidAssertIsDisplayed()
        {
            return textareaInvalidAssert.Displayed;
        }

        public bool nameInvalidAssertIsDisplayed()
        {
            return nameInvalidAssert.Displayed;
        }

        public bool emailInvalidAsserttIsDisplayed()
        {
            return emailInvalidAssert.Displayed;
        }

        public bool invalidTermsOfServiceCheckboxAssertIsDisplayed()
        {
            return invalidTermsOfServiceCheckboxAssert.Displayed;
        }
    }
}
