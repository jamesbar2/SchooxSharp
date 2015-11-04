using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using SchooxSharp.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace SchooxSharp.ApiTests
{
    [TestClass()]
    public class SchooxServiceTests
    {
        [TestMethod()]
        public void SchooxServiceTestCredentialsFromConfig()
        {
            var service = new SchooxService();
            Assert.AreEqual(service.AcademyId, 386);
            Assert.AreEqual(service.ApiKey, "schoox");
            Assert.AreEqual(service.BaseUrl, "https://www.schoox.com/api/v1");
        }

        [TestMethod()]
        public void SchooxServiceTestManualCredentials()
        {
            var service = new SchooxService("testschoox", 1);
            Assert.AreEqual(service.AcademyId, 1);
            Assert.AreEqual(service.ApiKey, "testschoox");
            Assert.AreEqual(service.BaseUrl, "https://www.schoox.com/api/v1");
        }

        [TestMethod()]
        public void GenerateBaseRequestTest()
        {
            var service = new SchooxService();
            var request = service.GenerateBaseRequest("/test");

            Assert.IsNotNull(request.Parameters.Find(u => u.Name == "apikey" && (string)u.Value == "schoox"));
            Assert.IsNotNull(request.Parameters.Find(u => u.Name == "acadId" && u.Value.ToString() == "386"));
        }
    }
}
