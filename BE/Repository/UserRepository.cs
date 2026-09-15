using BE.Data;
using BE.Model;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository;
public class UserRepository
{
	private readonly AppDbContext appDbContext;

	public UserRepository(AppDbContext appDbContext)
	{
		this.appDbContext = appDbContext;
	}
	// Get all user
	public async Task<List<UserModel>> GetAllAsync()
	{
		return await appDbContext.users.ToListAsync();
	}

	// get user by id
	public async Task<UserModel?> GetByIdAsync(long id)
	{
		return await appDbContext.users.FindAsync(id);
	}
	// create user 
	public async Task<UserModel> CreateAsync(UserModel userModel)
	{
		appDbContext.users.Add(userModel);
		await appDbContext.SaveChangesAsync();
		return userModel;
	}

    // update user 
    public async Task<UserModel?> UpdateAsync(long id, UserModel userModel)
	{
		var existingUser = await appDbContext.users.FindAsync(id);
		if(existingUser == null)
		{
			return null;
		}

        existingUser.FullName = userModel.FullName;
        existingUser.PasswordHash = userModel.PasswordHash;
        existingUser.Email = userModel.Email;
        existingUser.Role = userModel.Role;

        await appDbContext.SaveChangesAsync();

        return existingUser;
    }

    // Delete user
    public async Task<bool> DeleteAsync(long id)
    {
        var user = await appDbContext.users.FindAsync(id);

        if (user == null)
        {
            return false;
        }

        appDbContext.users.Remove(user);

        await appDbContext.SaveChangesAsync();

        return true;
    }
}

