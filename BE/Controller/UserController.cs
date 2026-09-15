using BE.Model;
using BE.Service;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserService(IUserService service)
        {
            this.service = service;
        }

        // GET: api/user
        // Lấy tất cả User
        [HttpGet]
        public async Task<List<UserModel>> GetAllAsync()
        {
            return await service.GetAllAsync();
        }
    }
}