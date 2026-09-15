using BE.Model;

namespace BE.Repository
{
	public interface IUserRepository
	{
		Task<List<UserModel>> GetAllAsync();

		Task<UserModel?> GetByIdAsync(long id);

		Task<UserModel> CreateAsync(UserModel user);

		Task<UserModel?> UpdateAsync(long id, UserModel user);

		Task<bool> DeleteAsync(long id);
	}
}