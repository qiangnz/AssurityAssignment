using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;

namespace AssurityAssignment
{
    [TestClass]
    public class AssurityAPITesting
    {
        //Access API and get API response details
        public string GetAPIDetails()
        {
            var client = new RestClient("https://api.tmsandbox.co.nz/");
            var request = new RestRequest("v1/Categories/6328/Details.json?catalogue=false");
            
            RestResponse response = client.Execute(request);
            var getAPIDetails = response.Content;

            return getAPIDetails;
        }


        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
