using Application.DTO;
using Application.Requests;
using Domain.Entitys;
using Domain.Interfaces;

namespace Application.Services
{
    public class ProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly PersonService _personService;
        private readonly ProjectTaskService _projectTaskService;

        public ProjectService(IProjectRepository projectRepository, PersonService personService, ProjectTaskService projectTaskService)
        {
            _projectRepository = projectRepository;
            _personService = personService;
            _projectTaskService = projectTaskService;
        }

        public async Task InsertProject(ProjectRequest projectRequest)
        {
            Project project = new Project(projectRequest.CreatedByPersonId, projectRequest.Name, projectRequest.Description, projectRequest.DueDate, projectRequest.DeliveryDate);

            await _projectRepository.InsertProject(project);
        }
        public async Task<ProjectDTO?> GetProjectById(long id)
        {
            Project project = await _projectRepository.GetProjectById(id);

            if (project == null)
                return null;

            PersonDTO personCreatedBy = await _personService.GetPersonById(project.PersonCreatedBy);

            List<ProjectTaskDTO>? projectTasksDTO = await _projectTaskService.GetAllTasksByProjectId(project.Id);

            ProjectDTO projectDTO = new ProjectDTO(project.Id, personCreatedBy!, project.Name, project.Description, project.DueDate, project.DeliveryDate, project.DeletionDate);

            if (projectTasksDTO != null)
            {
                projectDTO.AddTasks(projectTasksDTO);
            }

            return projectDTO;
        }
    }
}
