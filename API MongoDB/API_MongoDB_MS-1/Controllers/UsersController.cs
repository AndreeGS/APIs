using API_MongoDB_MS_1.Services;
using API_MongoDB_MS_1.Models;
using Microsoft.AspNetCore.Mvc;


namespace API_MongoDB_MS_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.ReadAllUsers();
            return Ok(users);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userService.ReadUserById(id);

            if(user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User userCreate)
        {
            var user = await _userService.CreateUser(userCreate);

            return CreatedAtAction(nameof(GetUserById), new { id = userCreate.Id}, userCreate);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateUser(string id, User userUpdate)
        {
            var user = await _userService.ReadUserById(id);
            if (user == null)
                return NotFound();
            userUpdate.Id = user.Id;
            await _userService.UpdateUser(id, userUpdate);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userService.ReadUserById(id);
            if (user == null)
                return NoContent();

            await _userService.DeleteUser(id);

            return NoContent();

        }
    }
}
