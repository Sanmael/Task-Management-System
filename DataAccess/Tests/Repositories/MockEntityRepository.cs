using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Tests.Repositories
{
    public class MockEntityRepository
    {
        private readonly List<BaseEntity> _entities = new List<BaseEntity>();
        public List<BaseEntity> GetAllEntities()
        {
            return _entities;
        }
    }
}
