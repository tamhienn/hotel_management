using BE.Model;
using BE.Repository;

namespace BE.Service
{

    public class UserService : IUserService
{
	public readonly IUserRepository repository;

    public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        // get all user
        public async Task<List<UserModel>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }     }

}
