namespace Task.API.DTO
{
	public record TaskListDTO
	{
		public int TaskId { get; set; }

		public required string TaskName { get; set; }

		public required DateTime FinishDate { get; set; }

		public string? Description { get; set; }

		public required string Status { get; set; }
	}
}
