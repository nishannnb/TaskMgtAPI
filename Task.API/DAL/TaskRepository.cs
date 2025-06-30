using Microsoft.EntityFrameworkCore;
using Task.API.DTO;
using Task.API.Entities;

namespace Task.API.DAL
{
	public class TaskRepository(TaskAPIContext taskAPIContext) : ITaskRepository
	{
		private readonly TaskAPIContext _taskAPIContext = taskAPIContext;


		public async Task<List<TaskListDTO>> GetAllTaskList()
		{
			var response = await _taskAPIContext.TaskData.Where(c => c.IsDeleted == false)
				.OrderByDescending(c => c.FinishDate).ToListAsync();

			return response.Select(c => new TaskListDTO()
			{
				TaskId = c.Id,
				TaskName = c.TaskName,
				FinishDate = c.FinishDate,
				Description = c.Description,
				Status = c.Status,
			}).ToList();
		}

		public async Task<bool> AddTask(AddTaskDTO addTaskDTO)
		{
			TaskData taskData = new()
			{
				TaskName = addTaskDTO.TaskName,
				FinishDate = addTaskDTO.FinishDate,
				Description = addTaskDTO.Description,
				Status = addTaskDTO.Status,
				CreatedUser = addTaskDTO.CreatedUser,
			};
			await _taskAPIContext.TaskData.AddAsync(taskData);
			await _taskAPIContext.SaveChangesAsync();
			return true;
		}

		public async Task<bool> UpdateTask(UpdateTaskDTO updateTaskDTO)
		{
			var taskData = await _taskAPIContext.TaskData.FirstOrDefaultAsync(c => c.Id == updateTaskDTO.TaskId && c.IsDeleted == false);
			if (taskData == null)
			{
				return false;
			}

			taskData.TaskName = updateTaskDTO.TaskName;
			taskData.FinishDate = updateTaskDTO.FinishDate;
			taskData.Description = updateTaskDTO.Description;
			taskData.Status = updateTaskDTO.Status;
			taskData.UpdatedUser = updateTaskDTO.UpdatedUser;
			taskData.UpdatedAt = DateTime.UtcNow;

			_taskAPIContext.TaskData.Update(taskData);
			await _taskAPIContext.SaveChangesAsync();
			return true;
		}

		public async Task<bool> DeleteTask(int taskId)
		{
			var task = await _taskAPIContext.TaskData.FirstOrDefaultAsync(c => c.Id == taskId && c.IsDeleted == false);
			if (task == null)
			{
				return false;
			}
			task.IsDeleted = true;
			_taskAPIContext.TaskData.Update(task);
			await _taskAPIContext.SaveChangesAsync();
			return true;
		}
	}
}
