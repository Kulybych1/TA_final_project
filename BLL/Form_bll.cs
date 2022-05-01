using System;
using System.Collections.Generic;
using System.Text;
using BBC1_task_4._1._1.Pages;
using BBC1_task_4._1._1.Definitions;
using OpenQA.Selenium;

namespace BBC1_task_4._1._1.BLL
{
    public class Form_bll
    {
        protected IWebDriver _driver;

        public Form_bll(IWebDriver driver) {
            _driver = driver;
        }

        public void FillForm(Dictionary<string, string> formKeyValuePairs, bool acceptNamePublishChecbox, bool acceptTermsOfServiceCheckbox)
        {
            var storiesPage = new StoriesPage(_driver);
            storiesPage.FillStoriesPageForm(formKeyValuePairs, acceptNamePublishChecbox, acceptTermsOfServiceCheckbox);
        }
    }
}
