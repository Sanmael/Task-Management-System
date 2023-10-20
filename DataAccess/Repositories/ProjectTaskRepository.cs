using Domain.Entitys;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProjectTaskRepository : IProjectTaskRepository
    {
        private readonly IBaseRepository _baseRepository;
        private readonly ISession _session;

        public ProjectTaskRepository(IBaseRepository baseRepository, ISession session)
        {
            _baseRepository = baseRepository;
            _session = session;
        }

        public Task<List<ProjectTask>> GetAllTasksByProjectId(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectTask> GetProjectTaskById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertProjectTask(ProjectTask task)
        {
            await _baseRepository.InsertAsync(task);
        }

    }
}
