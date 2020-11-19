using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpPOC;
using RestSharpPOC.Models.Request;

namespace APIPOCTests
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestMethod1()
        {
            var api = new Demo();
            var response = api.GetUsers();
            Assert.AreEqual(1, response.Page);
        }
        [DeploymentItem("Test Data\\CreateUser.csv"),
            DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "CreateUser.csv", "CreateUser#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void CreateNewUserTest()
        {
            //string payload = @"{
            //                    ""name"": ""morpheus"",
            //                    ""job"": ""leader""
            //                   }"; 

            var user = new CreateUserReq
            {
                name = TestContext.DataRow["Name"].ToString(),
                job = TestContext.DataRow["Job"].ToString()
            };

            var api = new Demo();
            var response = api.CreateNewUser(user);
            Assert.AreEqual(user.name, response.name);
        }
    }
}
