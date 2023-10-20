using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProjectRepository
    {
        public Task InsertProject(Project project);
        public Task<Project> GetProjectById(long id);
    }
}
