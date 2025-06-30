using Microsoft.AspNetCore.Mvc;
using Task.API.DTO;
using Task.API.ResponseModel;
using Task.API.Services;

namespace Task.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController(IUserService iUserService) : ControllerBase
	{
		private readonly IUserService _iUserService = iUserService;

		[HttpPost("AuthenticateUser")]
		public async Task<IActionResult> AuthenticateUser([FromBody] UserDTO userDTO)
		{
			ApiResponse apiResponse;

			if (userDTO == null)
			{
				apiResponse = new("User data is required");
				return BadRequest(apiResponse);
			}
			if (string.IsNullOrWhiteSpace(userDTO.UserName))
			{
				apiResponse = new("Username is required");
				return BadRequest(apiResponse);
			}
			if (string.IsNullOrWhiteSpace(userDTO.Password))
			{
				apiResponse = new("Password is required");
				return BadRequest(apiResponse);
			}

			var response = await _iUserService.AuthenticateUser(userDTO);
			apiResponse = new("Logged Successfully", response);
			return Ok(apiResponse);
		}













		//// GET: api/Users
		//[HttpGet]
		//public async Task<ActionResult<IEnumerable<User>>> GetUser()
		//{
		//	return await _context.User.ToListAsync();
		//}

		//// GET: api/Users/5
		//[HttpGet("{id}")]
		//public async Task<ActionResult<User>> GetUser(int id)
		//{
		//	var user = await _context.User.FindAsync(id);

		//	if (user == null)
		//	{
		//		return NotFound();
		//	}

		//	return user;
		//}

		//// PUT: api/Users/5
		//// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		//[HttpPut("{id}")]
		//public async Task<IActionResult> PutUser(int id, User user)
		//{
		//	if (id != user.Id)
		//	{
		//		return BadRequest();
		//	}

		//	_context.Entry(user).State = EntityState.Modified;

		//	try
		//	{
		//		await _context.SaveChangesAsync();
		//	}
		//	catch (DbUpdateConcurrencyException)
		//	{
		//		if (!UserExists(id))
		//		{
		//			return NotFound();
		//		}
		//		else
		//		{
		//			throw;
		//		}
		//	}

		//	return NoContent();
		//}

		//// POST: api/Users
		//// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		//[HttpPost]
		//public async Task<ActionResult<User>> PostUser(User user)
		//{
		//	_context.User.Add(user);
		//	await _context.SaveChangesAsync();

		//	return CreatedAtAction("GetUser", new { id = user.Id }, user);
		//}

		//// DELETE: api/Users/5
		//[HttpDelete("{id}")]
		//public async Task<IActionResult> DeleteUser(int id)
		//{
		//	var user = await _context.User.FindAsync(id);
		//	if (user == null)
		//	{
		//		return NotFound();
		//	}

		//	_context.User.Remove(user);
		//	await _context.SaveChangesAsync();

		//	return NoContent();
		//}

		//private bool UserExists(int id)
		//{
		//	return _context.User.Any(e => e.Id == id);
		//}
	}
}
