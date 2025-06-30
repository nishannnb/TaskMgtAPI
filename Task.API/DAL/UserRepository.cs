using Microsoft.EntityFrameworkCore;
using Task.API.DTO;

namespace Task.API.DAL
{
	public class UserRepository(TaskAPIContext taskAPIContext) : IUserRepository
	{
		private readonly TaskAPIContext _taskAPIContext = taskAPIContext;

		public async Task<string?> AuthenticateUser(UserDTO userDTO)
		{
			var response = await _taskAPIContext.User.FirstOrDefaultAsync(u => u.UserName == userDTO.UserName && u.Password == userDTO.Password && u.IsDeleted == false);

			return response?.UserName;
		}
	}
}
