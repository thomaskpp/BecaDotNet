using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace BecaDotNet.Infrastructure
{
    public class SqlClientFactory : DbProviderFactory
    {
        protected string ConnString => ConfigurationManager.ConnectionStrings["BecaDB"].ConnectionString;
        protected SqlConnection _sqlConn;

        public override DbConnection CreateConnection()
        {
            //var conn = connection.ConnectionString = ConnString;
            if (_sqlConn != null && _sqlConn.State == System.Data.ConnectionState.Open)
                return _sqlConn;

            if (_sqlConn == null)
                _sqlConn = new SqlConnection();

            _sqlConn.ConnectionString = ConnString;
            return _sqlConn;
        }

        public override DbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        public override DbDataAdapter CreateDataAdapter()
        {
            return new SqlDataAdapter();
        }
    }

}
