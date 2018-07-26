using BecaDotNet.Domain.Model;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace BecaDotNet.Infrastructure.ADO
{
    public class UserInfraADO
    {
        

        public User Get(string login, string password)
        {
            var factory = new SqlClientFactory();
            var connection = factory.CreateConnection();
            var command = factory.CreateCommand();
            command.Connection= connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from tb_user where login =@login and password=@password";
            command.Parameters.Add(new SqlParameter("@login",login));
            command.Parameters.Add(new SqlParameter("@password", password));
            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var objUser = GetFromReader(reader);
                        return objUser;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();
                connection.Dispose();
            }
        }

        private User GetFromReader(DbDataReader reader)
        {
            try
            {
                int.TryParse(reader["ID"].ToString(), out int id);
                DateTime.TryParse(reader["REGISTER_DATE"].ToString(), out DateTime registerDate);
                bool.TryParse(reader["IS_ACTIVE"].ToString(), out bool isActive);
                return new User
                {
                    Id = id,
                    Email = reader["EMAIL"].ToString(),
                    IsActive = isActive,
                    Name = reader["NAME"].ToString(),
                    Login = reader["LOGIN"].ToString(),
                    RegisterDate = registerDate
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
