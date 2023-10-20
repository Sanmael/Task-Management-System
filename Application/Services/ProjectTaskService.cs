using Application.DTO;
using Application.Requests;
using Domain.Entitys;
using Domain.Enums;
using Domain.Interfaces;

namespace Application.Services
{
    public class ProjectTaskService
    {
        private readonly PersonService _personService;        
        private readonly IProjectTaskRepository _projectTaskRepository;

        public ProjectTaskService(PersonService personService, IProjectTaskRepository projectTaskRepository)
        {
            _personService = personService;
            _projectTaskRepository = projectTaskRepository;
        }

        public async Task InsertProjectTask(ProjectTaskRequest projectTaskRequest)
        {
            ProjectTask projectTask = new ProjectTask(projectTaskRequest.PersonAssigneeId, projectTaskRequest.PersonCreatedId, projectTaskRequest.Title, projectTaskRequest.Description, projectTaskRequest.DueDate, projectTaskRequest.DeliveryDate,
                (TaskPriorityType)projectTaskRequest.PriorityType, (Domain.Enums.TaskStatus)projectTaskRequest.TaskStatus, projectTaskRequest.ProjectId);

            await _projectTaskRepository.InsertProjectTask(projectTask);
        }
        public async Task<ProjectTaskDTO?> GetProjectTaskById(long id)
        {
            ProjectTask projectTask = await _projectTaskRepository.GetProjectTaskById(id);

            if (projectTask == null)
                return null;

            PersonDTO Assignee = await _personService.GetPersonById(projectTask!.PersonAssigneeId);

            PersonDTO CreatedBy = await _personService.GetPersonById(projectTask.PersonCreatedId);

            ProjectTaskDTO projectTaskDTO = new ProjectTaskDTO(projectTask.Id, Assignee!, CreatedBy!, projectTask.Title, projectTask.Description, projectTask.DueDate, projectTask.DeliveryDate,
                (int)projectTask.PriorityType, (int)projectTask.TaskStatus, projectTask.ProjectId);

            return projectTaskDTO;
        }
        public async Task<List<ProjectTaskDTO>?> GetAllTasksByProjectId(long id)
        {
            List<ProjectTask> projectTask = await _projectTaskRepository.GetAllTasksByProjectId(id);

            if (!projectTask.Any())
                return null;

            List<ProjectTaskDTO> projectTaskDTOs = new List<ProjectTaskDTO>(); 

            foreach (var task in projectTask)
            {
                projectTaskDTOs.Add(new ProjectTaskDTO(task.Id, await _personService.GetPersonById(task.PersonAssigneeId),
                    await _personService.GetPersonById(task.PersonCreatedId), task.Title, task.Description, task.DueDate, task.DeliveryDate, (int)task.PriorityType, (int)task.TaskStatus, task.ProjectId));
            }
           
            return projectTaskDTOs;
        }
    }
}
