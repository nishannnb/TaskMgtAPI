using Task.API.DTO;

namespace Task.API.Services
{
	public interface IUserService
	{
		Task<string?> AuthenticateUser(UserDTO userDTO);
	}
}
