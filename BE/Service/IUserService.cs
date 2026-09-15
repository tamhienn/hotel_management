using BE.Repository;
using BE.Model;

namespace BE.Service;

public interface IUserService
{
	Task<List<UserModel>> GetAllAsync();
}
