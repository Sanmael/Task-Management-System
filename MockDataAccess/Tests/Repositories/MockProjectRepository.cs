using Domain.Entitys;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockDataAccess.Tests.Repositories
{
    public class MockProjectRepository : IProjectRepository
    {
        private readonly IBaseRepository _baseRepository;
        private readonly GetMockRepository<Project> _getMockRepository;

        public MockProjectRepository(IBaseRepository baseRepository, MockEntityRepository mockEntityRepository)
        {
            _baseRepository = baseRepository;
            _getMockRepository = new GetMockRepository<Project>(mockEntityRepository);
        }

        public Task<Project> GetProjectById(long id)
        {
            Project project = _getMockRepository.FindEntity(x=> x.Id == id)!;

            return Task.FromResult(project);
        }

        public async Task InsertProject(Project project)
        {
            await _baseRepository.InsertAsync(project);
        }
    }
}
