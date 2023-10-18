using Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DataAccess.Session
{
    public class DapperSession : IDisposable, ISession
    {
        public IDbConnection Connection { get; set; }
        public IDbTransaction? DbTransaction { get; }

        public DapperSession(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration.GetConnectionString("DefaultConnections"));

            Connection.Open();
        }
        public void Dispose()
        {
            Connection?.Dispose();
        }
    }
}
