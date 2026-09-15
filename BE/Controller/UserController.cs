using BE.Model;
using BE.Service;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controller
{
    // chua hieu phan nay
    [ApiController]
    [Route("api/[controller]")]

    // =========================

    public class UserController : ControllerBase
    {
        private readonly UserService service;

        public UserController(UserService service)
        {
            this.service = service;
        }

        // GET: api/user
        // get all user
        [HttpGet]
        public async Task<List<UserModel>> GetAllAsync()
        {
            return await service.GetAllAsync();
        }

        // get user by id
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetByIdAsync(long id)
        {
            var user = await service.GetByIdAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // Post: api/user
        // create user
        [HttpPost]
        public async Task<ActionResult<UserModel>> CreateAsync(UserModel userModel)
        {
            var user = await service.CreateAsync(userModel);

            return Ok(user);
        
        }

        // put: api/user
        // update user
        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel?>> UpdateAsync(long id, UserModel userModel)
        {
            var user = await service.UpdateAsync(id, userModel);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // DELETE: api/user/1
        // delete user
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await service.DeleteAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}