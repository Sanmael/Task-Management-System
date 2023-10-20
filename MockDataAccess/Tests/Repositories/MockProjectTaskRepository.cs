using Domain.Entitys;
using Domain.Interfaces;

namespace MockDataAccess.Tests.Repositories
{
    public class MockProjectTaskRepository : IProjectTaskRepository
    {
        private readonly IBaseRepository _baseRepository;
        private readonly GetMockRepository<ProjectTask> _getMockRepository;

        public MockProjectTaskRepository(IBaseRepository baseRepository, MockEntityRepository mockEntityRepository)
        {
            _baseRepository = baseRepository;
            _getMockRepository = new GetMockRepository<ProjectTask>(mockEntityRepository);
        }

        public Task<List<ProjectTask>> GetAllTasksByProjectId(long id)
        {
            List<ProjectTask> projectTasks = _getMockRepository.FindEntities(x => x.ProjectId == id)!;

            return Task.FromResult(projectTasks);
        }

        public Task<ProjectTask> GetProjectTaskById(long id)
        {
            ProjectTask projectTask = _getMockRepository.FindEntity(x => x.Id == id);

            return Task.FromResult(projectTask);
        }

        public async Task InsertProjectTask(ProjectTask task)
        {
            await _baseRepository.InsertAsync(task);
        }
    }
}
