using Domain.Entitys;
using Domain.Interfaces;
using MockDataAccess.Tests.Repositories;

namespace MockDataAccess.Tests.BaseRepository
{
    public class BaseMockRepository : IBaseRepository
    {
        private readonly MockEntityRepository _mockEntityRepository;
        public BaseMockRepository(MockEntityRepository mockEntityRepository)
        {
            _mockEntityRepository = mockEntityRepository;
        }
        public Task DeleteAsync(BaseEntity entity)
        {
            _mockEntityRepository.GetAllEntities().Remove(entity);

            return Task.CompletedTask;
        }

        public Task InsertAsync(BaseEntity entity)
        {
            entity.Id = new Random().Next();
            _mockEntityRepository.GetAllEntities().Add(entity);

            return Task.CompletedTask;
        }

        public Task UpdateAsync(BaseEntity entity)
        {
            _mockEntityRepository.GetAllEntities().RemoveAll(x => x.GetType() == entity.GetType() && x.Id == entity.Id);
            _mockEntityRepository.GetAllEntities().Add(entity);

            return Task.CompletedTask;
        }
    }
}
