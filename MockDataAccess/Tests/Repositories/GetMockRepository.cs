using DataAccess.Tests.Repositories;

namespace MockDataAccess.Tests.Repositories
{
    public class GetMockRepository<BaseEntity>
    {
        private readonly MockEntityRepository _entityRepository;

        public GetMockRepository(MockEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public BaseEntity? FindEntity(Func<BaseEntity, bool> predicate)
        {
            var entitys = _entityRepository.GetAllEntities();

            var entity = entitys.OfType<BaseEntity>().FirstOrDefault(predicate);

            return entity;
        }
        public List<BaseEntity?> FindEntities(Func<BaseEntity, bool> predicate)
        {
            List<Domain.Entitys.BaseEntity> entitys = _entityRepository.GetAllEntities();

            List<BaseEntity?> entitysFilter = entitys.OfType<BaseEntity>().Where(predicate).ToList();

            return entitysFilter;
        }
    }
}
