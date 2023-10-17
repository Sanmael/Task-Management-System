using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Session
{
    public class DapperSession : IDisposable
    {
        public IDbConnection DbConnection { get; }
        public IDbTransaction? Transaction { get; set; }
        public DapperSession(IConfiguration configuration)
        {
            DbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnections"));

            DbConnection.Open();
        }
        public void Dispose()
        {
            DbConnection?.Dispose();
        }
    }
}
