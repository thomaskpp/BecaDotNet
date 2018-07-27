using BecaDotNet.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BecaDotNet.Infrastructure.DAPPER.Tests
{
    [TestClass()]
    public class UserInfraDAPPERTests
    {
        [TestMethod()]
        public void Success_With_Valids_Pameters()
        {
            var expected = new User
            {
                Email = "testeduser@email.com",
                Name = "User From Test",
                Login = "userfromtest",
                Password = "passwordfromtest",
                IsActive = true
            };

            var userInfraDapperForTest = new UserInfraDAPPER();
            var result = userInfraDapperForTest.Create(expected);

            Assert.AreEqual(expected.Email, result.Email);
            Assert.AreEqual(expected.Name, result.Name);
        }

        [TestMethod()]
        public void Success_With_No_Return_With_Empty_Required()
        {
            var objForTest= new User();
            var userInfraDapperForTest = new UserInfraDAPPER();
            var result = userInfraDapperForTest.Create(objForTest);
            Assert.IsNull(result);
        }
    }
}