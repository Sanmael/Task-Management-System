using Application.DTO;
using Application.Exceptions;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(UserDTO userDTO)
        {
            try
            {
                await _userService.InsertUser(userDTO);
                return Ok(userDTO);
            }
            catch (TaskApplicatioException ex)
            {
                return BadRequest(ex.Message);
            }            
        }
        [HttpGet]
        public async Task<IActionResult> GetUserAsync(long id)
        {
            UserDTO? userDTO = await _userService.GetUserById(id);

            if (userDTO == null)
                return NotFound();

            return Ok(userDTO);
        }
    }
}
