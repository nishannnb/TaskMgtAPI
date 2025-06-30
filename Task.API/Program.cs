using Microsoft.EntityFrameworkCore;
using Task.API.DAL;
using Task.API.Middlewares;
using Task.API.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TaskAPIContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("TaskAPIContext") ?? throw new InvalidOperationException("Connection string 'TaskAPIContext' not found.")));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", policy =>
	{
		policy.AllowAnyOrigin()
			  .AllowAnyHeader()
			  .AllowAnyMethod();
	});
});

var app = builder.Build();

app.UseRouting();
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.MapControllers();
app.UsePathBase("/basepath");
app.UseMiddleware<ExceptionMiddleware>();
app.Run();
