namespace Task.API.Entities
{
	public class TaskData : BaseEntity
	{
		public required string TaskName { get; set; }

		public required DateTime FinishDate { get; set; }

		public string? Description { get; set; }

		public required string Status { get; set; } // e.g., "Pending", "In Progress", "Completed". Need to change as key value pair

		public bool IsDeleted { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

		public DateTime? UpdatedAt { get; set; }

		public int CreatedUser { get; set; }

		public int? UpdatedUser { get; set; }
	}
}
