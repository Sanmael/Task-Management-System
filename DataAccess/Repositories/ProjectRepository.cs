using Domain.Entitys;
using Domain.Interfaces;


namespace DataAccess.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IBaseRepository _baseRepository;
        private readonly ISession _session;
        public ProjectRepository(IBaseRepository baseRepository, ISession session)
        {
            _baseRepository = baseRepository;
            _session = session;
        }

        public Task<Project> GetProjectById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertProject(Project project)
        {
            await _baseRepository.InsertAsync(project);
        }
    }
}
