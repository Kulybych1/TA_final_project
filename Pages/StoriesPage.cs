using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;
using BBC1_task_4._1._1.Definitions;

namespace BBC1_task_4._1._1.Pages
{
    public class StoriesPage : BasePage
    {
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

        [FindsBy(How = How.XPath, Using = "//div/textarea | //input[@placeholder]")]
        private IList<IWebElement> textBoxForm;

        public StoriesPage(IWebDriver driver) : base(driver) { }

        public void FillStoriesPageForm(Dictionary<string, string> formKeyValuePair, bool acceptNamePublishChecbox, bool acceptTermsOfServiceCheckbox) //Сменить название валью 
        {
            foreach (var element in textBoxForm)
            {
                var elementValue = formKeyValuePair[element.GetAttribute("placeholder")];
                element.SendKeys(elementValue);
            }

            if (acceptNamePublishChecbox == true)
                namePublishChecbox.Click();

            if (acceptTermsOfServiceCheckbox == true)
                termsOfServiceCheckbox.Click();

            submitButton.Click();
        }


        public bool ValidResultExpectedIsDisplayed()
        {
            return validResultExpected.Displayed;
        }

        public bool TextareaInvalidAssertIsDisplayed()
        {
            return textareaInvalidAssert.Displayed;     
        }

        public bool NameInvalidAssertIsDisplayed()
        {
            return nameInvalidAssert.Displayed;      
        }

        public bool EmailInvalidAsserttIsDisplayed()
        {
            return emailInvalidAssert.Displayed;
        }

        public bool InvalidTermsOfServiceCheckboxAssertIsDisplayed()
        {
            return invalidTermsOfServiceCheckboxAssert.Displayed;
        }
    }
}
