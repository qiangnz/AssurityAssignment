using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Linq;

namespace AssurityAssignment
{
    [TestClass]
    public class AssurityAPITesting
    {
        //Access API and get contents method
        public string GetAPIContents()
        {
            var client = new RestClient("https://api.tmsandbox.co.nz/");
            var request = new RestRequest("v1/Categories/6328/Details.json?catalogue=false");
            
            RestResponse response = client.Execute(request);
            var apiContents = response.Content;

            return apiContents;
        }

        //Acceptance Criteria Validation
        [TestMethod]
        public void AcceptanceCriteria()
        {
            //Arrange
            //Set the value of sample data used in the method being tested
            string criteriaName = "Badges";
            bool criteriaCanRelist=true;
            string criteriaPromName = "Feature";
            string criteriaPromDescription = "Better position in category";

            //Action
            //Invoke the method being tested
            Contents apiContents = new Contents();
            _Promotions apipromotions = new _Promotions();

            //Call method get API contents
            GetAPIContents();
            var jsonContents=GetAPIContents();
            apiContents = JsonConvert.DeserializeObject<Contents>(jsonContents);

            //Set "Promotions" into a List
            var promotionsList = apiContents.Promotions.ToList();
            //Loop "Promotions" elements
            foreach (var promotion in promotionsList)
            {
                if (promotion.Name.ToString()==criteriaPromName && promotion.Description.ToString()==criteriaPromDescription)
                {
                    return;
                }
            }

            //Assert
            //Verify the tested method behaves as expected
            Assert.AreEqual(criteriaName, apiContents.Name);
            Assert.AreEqual(criteriaCanRelist, apiContents.CanRelist);
            Assert.AreEqual(criteriaPromName, apipromotions.Name.ToString());
            Assert.AreEqual(criteriaPromDescription, apipromotions.Description.ToString());

        }
    }
}
