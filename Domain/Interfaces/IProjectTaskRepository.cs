using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProjectTaskRepository
    {
        public Task InsertProjectTask(ProjectTask task);        
        public Task<ProjectTask> GetProjectTaskById(long id);        
        public Task<List<ProjectTask>> GetAllTasksByProjectId(long id);
    }
}
