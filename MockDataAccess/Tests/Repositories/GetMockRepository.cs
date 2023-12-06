using Domain.Entitys;

namespace MockDataAccess.Tests.Repositories
{
    public class GetMockRepository<T>
    {
        private readonly MockEntityRepository _entityRepository;
        public GetMockRepository(MockEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public T? FindEntity(Func<T, bool> predicate)
        {
            List<BaseEntity> baseEntitys = _entityRepository.GetAllEntities();

            T? entity = baseEntitys.OfType<T>().FirstOrDefault(predicate);

            return entity;
        }
        public List<T?> FindEntities(Func<T, bool> predicate)
        {
            List<BaseEntity> baseEntitys = _entityRepository.GetAllEntities();

            List<T?> entitysFilter = baseEntitys.OfType<T>().Where(predicate).ToList()!;

            return entitysFilter;
        }
    }
}
