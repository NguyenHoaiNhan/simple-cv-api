using Microsoft.AspNetCore.Mvc;
using SimpleCV.Data.DTO;
using SimpleCV.Services.IServices;

namespace SimpleCV.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                return Ok(await _userService.GetUsers());
            }
            catch (Exception)
            {
                return BadRequest("Get all users failed");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                return Ok(await _userService.GetUser(id));
            }
            catch (Exception)
            {
                return BadRequest($"User with {id} not found");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserToAddDTO user)
        {
            try
            {
                return Ok(await _userService.AddUser(user));
            }
            catch (Exception)
            {
                return BadRequest("Add user failed");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(UserDTO user)
        {
            try
            {
                return Ok(await _userService.UpdateUser(user));
            }
            catch (Exception)
            {
                return BadRequest("Update user failed");
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUserProperties(int Id, [FromBody] List<UserPatchDTO> userPatchDto)
        {
            try
            {
                return Ok(await _userService.UpdateUserProperties(Id, userPatchDto));
            }
            catch (Exception)
            {
                return BadRequest("Update field failed");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Delete user failed");
            }
        }
    }
}