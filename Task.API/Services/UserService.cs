using Task.API.DAL;
using Task.API.DTO;

namespace Task.API.Services
{
	public class UserService(IUserRepository iUserRepository) : IUserService
	{
		private readonly IUserRepository _iUserRepository = iUserRepository;

		public async Task<string?> AuthenticateUser(UserDTO userDTO)
		{

			return await _iUserRepository.AuthenticateUser(userDTO);
		}
	}
}
