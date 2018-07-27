using BecaDotNet.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BecaDotNet.Infrastructure.ADO.Tests
{
    [TestClass()]
    public class UserInfraADOTests
    {
        [TestMethod()]
        public void Return_Valid_User()
        {
            var userExpected = new User { Id = 1 };
            var loginForTest = "admin";
            var passwordForTest = "pwd123";
            var userInfraAdoForTest = new UserInfraADO();
            var testResult = userInfraAdoForTest.Get(loginForTest, passwordForTest);
            Assert.AreEqual(userExpected.Id, testResult.Id);
        }
        [TestMethod()]
        public void NoReturn_Invalid_User()
        {
            var loginForTest = "admin";
            var passwordForTest = "pwd1231";
            var userInfraAdoForTest = new UserInfraADO();
            var testResult = userInfraAdoForTest.Get(loginForTest, passwordForTest);
            Assert.IsNull(testResult);
        }
    }
}