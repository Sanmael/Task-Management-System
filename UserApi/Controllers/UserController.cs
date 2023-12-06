using Application.DTO;
using Application.Exceptions;
using Application.Interfaces;
using Application.Services;
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
                IBaseResponse baseResponse = await _userService.InsertUserAsync(userDTO);

                if (baseResponse.IsSuccess)
                    return Ok(baseResponse.Data);
                
                return BadRequest(baseResponse.Data);
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
