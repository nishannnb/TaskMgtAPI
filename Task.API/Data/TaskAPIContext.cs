using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Task.API.Entities;

public class TaskAPIContext : DbContext
{
	public TaskAPIContext(DbContextOptions<TaskAPIContext> options)
		: base(options)
	{

	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
	}

	public DbSet<User> User { get; set; }

	public DbSet<TaskData> TaskData { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<User>()
			.Property(u => u.UserName)
			.IsRequired();
		modelBuilder.Entity<User>()
			.Property(u => u.Password)
			.IsRequired();
		modelBuilder.Entity<TaskData>()
			.Property(t => t.TaskName)
			.IsRequired();
		modelBuilder.Entity<TaskData>()
			.Property(t => t.FinishDate)
			.IsRequired();
		modelBuilder.Entity<TaskData>()
			.Property(t => t.Status)
			.IsRequired();



		var user = new User
		{
			Id = 1,
			UserName = "admin",
			Password = "Abcd@123",
			FirstName = "Admin",
			IsDeleted = false,
			CreatedAt = new DateTime(),
			CreatedUser = 1
		};
		modelBuilder.Entity<User>().HasData(user);


		var taskData = new TaskData
		{
			Id = 1,
			TaskName = "Task 01",
			FinishDate = DateTime.UtcNow.AddDays(10),
			Description = "Task 01 description",
			Status = "Pending",
			IsDeleted = false,
			CreatedAt = DateTime.UtcNow,
			CreatedUser = 1
		};
		modelBuilder.Entity<TaskData>().HasData(taskData);
	}
}
