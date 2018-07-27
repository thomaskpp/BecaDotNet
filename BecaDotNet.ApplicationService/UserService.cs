using System.Collections.Generic;
using BecaDotNet.Domain.Model;
using BecaDotNet.Domain.Services;
using BecaDotNet.Infrastructure.ADO;
using BecaDotNet.Infrastructure.DAPPER;

namespace BecaDotNet.ApplicationService
{
    public class UserService : IUserService
    {
        public User Alter(User user)
        {
            throw new System.NotImplementedException();
        }

        public bool Create(User user)
        {
            var userDapperInfra = new UserInfraDAPPER();
            var result = userDapperInfra.Create(user);
            return result != null;
        }

        public User Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public User Get(string login, string password)
        {
            var userAdoInfra = new UserInfraADO();
            var objUser = userAdoInfra.Get(login, password);
            return objUser;
        }

        public IEnumerable<User> Get(User filter)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
