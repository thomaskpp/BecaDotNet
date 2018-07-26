using BecaDotNet.Domain.Model;
using System.Collections.Generic;

namespace BecaDotNet.Domain.Services
{
    public interface IUserService
    {
        User Get(int id);
        User Get(string login, string password);
        bool Create(User user);
        User Alter(User user);
        bool Remove(int id);
        IEnumerable<User> Get(User filter);
    }
}
