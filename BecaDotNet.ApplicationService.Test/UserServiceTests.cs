using Microsoft.VisualStudio.TestTools.UnitTesting;
using BecaDotNet.Domain.Model;

namespace BecaDotNet.ApplicationService.Tests
{
    [TestClass()]
    public class UserServiceTests
    {
        [TestMethod()]
        public void Create_Return_True_With_Valid_Data()
        {
            var expected = new User
            {
                Email = "testeduser@email.com",
                Name = "User From Test",
                Login = "userfromtest",
                Password = "passwordfromtest",
                IsActive = true
            };

            var service = new UserService();
            var result = service.Create(expected);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void Create_Return_False_With_Invalid_Data()
        {
            var expected = new User();
            var service = new UserService();
            var result = service.Create(expected);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Return_User_With_No_Password_Using_Valid_Login_Password()
        {
            var service = new UserService();
            var loginForTest = "admin";
            var passwordForTest = "pwd123";
            var result = service.Get(loginForTest, passwordForTest);
            Assert.IsNotNull(result);
            Assert.IsNull(result.Password);
        }

        [TestMethod()]
        public void Return_Null_Using_Invalid_Login_Password()
        {
            var service = new UserService();
            var loginForTest = "admin";
            var passwordForTest = "wrongpass";
            var result = service.Get(loginForTest, passwordForTest);
            Assert.IsNull(result);
        }
    }
}