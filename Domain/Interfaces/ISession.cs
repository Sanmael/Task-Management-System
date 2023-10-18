using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISession
    {
        public IDbTransaction? DbTransaction {  get; }
        public IDbConnection Connection { get; set; }
    }
}
