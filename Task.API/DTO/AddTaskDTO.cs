namespace Task.API.DTO
{
	public class AddTaskDTO
	{
		public required string TaskName { get; set; }

		public required DateTime FinishDate { get; set; }

		public string? Description { get; set; }

		public required string Status { get; set; }

		public int CreatedUser { get; set; }

	}
}
