namespace Task.API.DTO
{
	public record UserDTO
	{
		public required string UserName { get; set; }

		public required string Password { get; set; }
	}
}
