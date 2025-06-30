using Task.API.DTO;

namespace Task.API.DAL
{
	public interface IUserRepository
	{
		Task<string?> AuthenticateUser(UserDTO userDTO);
	}
}
