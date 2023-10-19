using Domain.Entitys;


namespace MockDataAccess.Tests.Repositories
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
