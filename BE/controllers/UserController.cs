using BE.Dto;
using BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAllAsync()
        {
            var user = await _service.GetAllAsync();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetByIdAsync(long id)
        {
            var user = await _service.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateAsync(CreateUserDto user) // đổi từ UserDto
        {
            var newUser = await _service.CreateAsync(user);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = newUser.Id }, newUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdateAsync(long id, UpdateUserDto user) // đổi từ UserDto
        {
            var updatedUser = await _service.UpdateAsync(id, user);
            if (updatedUser == null) return NotFound();
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}