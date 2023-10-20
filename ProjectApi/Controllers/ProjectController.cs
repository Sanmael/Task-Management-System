using Application.DTO;
using Application.Interfaces;
using Application.Requests;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService _projectService;

        public ProjectController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(ProjectRequest projectRequest)
        {
            await _projectService.InsertProject(projectRequest);

            return Ok(projectRequest);
        }
        [HttpGet]
        public async Task<IActionResult> GetProjectById(long id)
        {
            ProjectDTO projectDTO = await _projectService.GetProjectById(id);

            return Ok(projectDTO);
        }       
    }
}
