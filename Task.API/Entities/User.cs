namespace Task.API.Entities
{
	public class User : BaseEntity
	{
		public required string UserName { get; set; }

		public required string Password { get; set; } // need to change as password hash or any encrypted value.

		public string? FirstName { get; set; }

		public bool IsDeleted { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

		public DateTime? UpdatedAt { get; set; }

		public int CreatedUser { get; set; }

		public int? UpdatedUser { get; set; }
	}
}
