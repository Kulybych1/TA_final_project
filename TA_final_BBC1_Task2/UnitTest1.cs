using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace TA_final_BBC1_Part2_Task2
{
    public class DataLists
    {
        private  string textData {get;set;}
        private  string nameData { get;set;}
        private  string emailData { get;set;}
        private  string contactNumberData { get;set;}
        private  string locationData { get;set;}

        public DataLists(string textData, string nameData, string emailData, string contactNumberData, string locationData)
        {
            this.textData = textData;
            this.nameData = nameData;
            this.emailData = emailData;
            this.contactNumberData = contactNumberData;
            this.locationData = locationData;
        }

        public List<string> getDataForFormInputs()
        {
            List<string> validDataForFormInputs = new List<string>
            {
            textData,
            nameData,
            emailData,
            contactNumberData,
            locationData
            };
            return validDataForFormInputs;
        }
    }

    public class Tests
    {
        private WebDriver driver;

        //input elements
        private readonly By inputText = By.XPath("//textarea[@aria-label='Tell us your story. ']");
        private readonly By inputName = By.XPath("//input[@aria-label='Name']");
        private readonly By inputEmail = By.XPath("//input[@aria-label='Email address']");
        private readonly By inputContactNumber = By.XPath("//input[@aria-label='Contact number ']");
        private readonly By inputLication = By.XPath("//input[@aria-label='Location ']");

        //Invalid input elements assert
        private readonly By emailInvalidAssert = By.XPath("//input[@aria-label='Email address' and contains(@class,'error__input')]");
        private readonly By textareaInvalidAssert = By.XPath("//textarea[@aria-label='Tell us your story. ' and contains(@class,'long--error')]");
        private readonly By nameInvalidAssert = By.XPath("//input[@aria-label='Name' and contains(@class,'error__input')]");
        private readonly By invalidTermsOfServiceCheckboxAssert = By.XPath("//div[@class='checkbox']//div[@class='input-error-message']");

        //checkboxes
        private readonly By namePublishChecbox = By.XPath("//p[contains(text(),'publish my name')]/../../..//input[@type='checkbox']");
        private readonly By termsOfServiceCheckbox = By.XPath("//p[contains(text(),'I accept the ')]/../../..//input[@type='checkbox']");

        //button
        private readonly By submitButton = By.XPath("//div[@class='embed-content-container']//button[@class='button']");

        //Epected
        private readonly By validResultExpected = By.XPath("//p[contains(text(),'thanks for asking your question')]");

        //ValidDataForFormInputs
        private const string textData = "Here is my story He";
        private const string nameData = "Nick";
        private const string emailData = "fjqgrezlevoopvwgpi@nthrw.com";
        private const string conyactNumberData = "+3806723424";
        private const string locationData = "Kyiv";

        //InvalidDataForFormInputs
        private const string invalidTextData = "";
        private const string invalidNameData = "";
        private const string invalidEmailData = "fjqgrezlevoopvwgpi";


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

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.bbc.com/news/10725415");
            
            if(driver.FindElement(By.XPath("//button[@class='tp-close tp-active']")).Displayed)
                driver.FindElement(By.XPath("//button[@class='tp-close tp-active']")).Click();
        }

        [Test]
        public void checkTheFormWithValidInput()
        {
            DataLists getDataList = new DataLists(textData, nameData, emailData, conyactNumberData, locationData);

            for (int i = 0; i < recieveTheListOfInputFields().Count; i++)
                driver.FindElement(recieveTheListOfInputFields()[i]).SendKeys(getDataList.getDataForFormInputs()[i]);

            driver.FindElement(namePublishChecbox).Click();
            driver.FindElement(termsOfServiceCheckbox).Click();

            driver.FindElement(submitButton).Click();

            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(30);

            Assert.IsTrue(driver.FindElement(validResultExpected).Displayed);
        }

        [Test]
        public void checkTheFormWithInvalidTextareaInput()
        {
            DataLists getDataList = new DataLists(invalidTextData, nameData, emailData, conyactNumberData, locationData);

            for (int i = 0; i < recieveTheListOfInputFields().Count; i++)
                driver.FindElement(recieveTheListOfInputFields()[i]).SendKeys(getDataList.getDataForFormInputs()[i]);

            driver.FindElement(namePublishChecbox).Click();
            driver.FindElement(termsOfServiceCheckbox).Click();

            driver.FindElement(submitButton).Click();

            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(30);

            Assert.IsTrue(driver.FindElement(textareaInvalidAssert).Displayed);
        }

        [Test]
        public void checkTheFormWithInvalidNameInput()
        {
            DataLists getDataList = new DataLists(textData, invalidNameData, emailData, conyactNumberData, locationData);

            for (int i = 0; i < recieveTheListOfInputFields().Count; i++)
                driver.FindElement(recieveTheListOfInputFields()[i]).SendKeys(getDataList.getDataForFormInputs()[i]);

            driver.FindElement(namePublishChecbox).Click();
            driver.FindElement(termsOfServiceCheckbox).Click();

            driver.FindElement(submitButton).Click();

            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(30);

            Assert.IsTrue(driver.FindElement(nameInvalidAssert).Displayed);
        }

        [Test]
        public void checkTheFormWithInvalidEmailInput()
        {
            DataLists getDataList = new DataLists(textData, nameData, invalidEmailData, conyactNumberData, locationData);

            for (int i = 0; i < recieveTheListOfInputFields().Count; i++)
                driver.FindElement(recieveTheListOfInputFields()[i]).SendKeys(getDataList.getDataForFormInputs()[i]);

            driver.FindElement(namePublishChecbox).Click();
            driver.FindElement(termsOfServiceCheckbox).Click();

            driver.FindElement(submitButton).Click();

            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(30);

            Assert.IsTrue(driver.FindElement(emailInvalidAssert).Displayed);
        }

        [Test]
        public void checkTheFormWithUncheckedTermsOfServiceCheckbox()
        {
            DataLists getDataList = new DataLists(textData, nameData, emailData, conyactNumberData, locationData);

            for (int i = 0; i < recieveTheListOfInputFields().Count; i++)
                driver.FindElement(recieveTheListOfInputFields()[i]).SendKeys(getDataList.getDataForFormInputs()[i]);

            driver.FindElement(namePublishChecbox).Click();

            driver.FindElement(submitButton).Click();

            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(30);

            Assert.IsTrue(driver.FindElement(invalidTermsOfServiceCheckboxAssert).Displayed);
        }

        [TearDown]
        public void tearDown()
        {
            driver.Quit();
        }
    }
}