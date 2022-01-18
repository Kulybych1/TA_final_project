using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1TA_final_BBC1_Part2_Task3._1.PageFactoryPages
{
    class DataLists
    {
        private string textData { get; set; }
        private string nameData { get; set; }
        private string emailData { get; set; }
        private string contactNumberData { get; set; }
        private string locationData { get; set; }

        public DataLists(string textData, string nameData, string emailData, string contactNumberData, string locationData)
        {
            this.textData = textData;
            this.nameData = nameData;
            this.emailData = emailData;
            this.contactNumberData = contactNumberData;
            this.locationData = locationData;
            
        }

        public DataLists()
        {
            
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

        public List<string> getExpectedlistOfHearders()
        {
            List<string> expectedlistOfHearders = new List<string>
            {
            "Australia could refuse Djokovic entry - PM",
            "N Korea angers neighbours with new missile test",
            "Internet blackout as Kazakhstan fuel protests rage",
            "The Indian gorge that resembles the Grand Canyon",
            "Biden buys 500m test kits to tackle Omicron ",
            "WHO chief: An event cancelled is better than a life cancelled"
            };
            return expectedlistOfHearders;
        }
    }
}
