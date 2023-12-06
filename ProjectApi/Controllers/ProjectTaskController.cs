using Application.Requests;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskController : ControllerBase
    {
        private readonly ProjectTaskService _projectTaskService;
        public ProjectTaskController(ProjectTaskService projectTaskService)
        {
            _projectTaskService = projectTaskService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTask(ProjectTaskRequest projectTaskRequest)
        {
            await _projectTaskService.InsertProjectTask(projectTaskRequest);

            return Ok(projectTaskRequest);
        }
    }
}
