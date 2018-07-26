using BecaDotNet.Domain.Model;
using Dapper;
using System;
using System.Data;
using System.Linq;

namespace BecaDotNet.Infrastructure.DAPPER
{
    
    public class UserInfraDAPPER
    {
        SqlClientFactory factory;

        public UserInfraDAPPER()
        {
            factory = new SqlClientFactory();
        }

        public User Create(User user)
        {
            try
            {
                var command = "STP_Register_User";
                using (var conn = factory.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@NAME", user.Name, DbType.String, ParameterDirection.Input);
                    parameters.Add("@EMAIL", user.Email, DbType.String, ParameterDirection.Input);
                    parameters.Add("@LOGIN", user.Login, DbType.String, ParameterDirection.Input);
                    parameters.Add("@PASSWORD", user.Password, DbType.String, ParameterDirection.Input);

                    var result = conn.Query<User>(command, parameters, commandType: CommandType.StoredProcedure).AsList().FirstOrDefault();
                    return result;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
