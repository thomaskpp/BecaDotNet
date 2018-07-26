using System.Data.Common;

namespace BecaDotNet.Infrastructure.ADO
{
    public abstract class DbProviderFactory
    {
        public abstract DbConnection CreateConnection();
        public abstract DbCommand CreateCommand();
        public abstract DbDataAdapter CreateDataAdapter();
    }
}
