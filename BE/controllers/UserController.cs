using BE.dtos;
using BE.dtos.Room;
using BE.dtos.User;
using BE.services;
using Microsoft.AspNetCore.Mvc;

namespace BE.controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserResponseDto>>> GetAllUser()
        {
            var rs = await _service.GetAllUser();
            return Ok(rs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseDto>> GetUserById(int id)
        {
            var rs = await _service.GetUserById(id);
            if(rs == null)
            {
                return NotFound();
            }
            return Ok(rs);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<UserResponseDto>> UpdateUser(int id, UpdateUserDto user)
        {
            var updateuser = await _service.UpdateUser(id, user);

            if (updateuser == null)
                return NotFound();

            return Ok(updateuser);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleteuser = await _service.DeleteUser(id);

            if (!deleteuser)
                return NotFound();

            return Ok(deleteuser);
        }
    }
}
