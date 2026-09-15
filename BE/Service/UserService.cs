using BE.Model;
using BE.Repository;

namespace BE.Service;
public class UserService
{
	private readonly UserRepository userRepository;

	public UserService(UserRepository userRepository)
	{
		this.userRepository = userRepository;
	}
	
	// get all user
	public async Task<List<UserModel>> GetAllAsync()
	{
		return await userRepository.GetAllAsync();
	}
	
	// get user by id
	public async Task<UserModel?> GetByIdAsync(long id) {
		{
			return await userRepository.GetByIdAsync(id);
		} 
	}

	// create user
	public async Task<UserModel> CreateAsync(UserModel userModel)
	{
		return await userRepository.CreateAsync(userModel);
	}

	// update user 
	public async Task<UserModel?> UpdateAsync(long id, UserModel userModel)
	{
		return await userRepository.UpdateAsync(id, userModel);
	}

    // Delete user
    public async Task<bool> DeleteAsync(long id)
    {
        return await userRepository.DeleteAsync(id);
    }

}
