using Task.API.DTO;

namespace Task.API.Services
{
	public interface ITaskService
	{
		Task<List<TaskListDTO>> GetAllTaskList();

		Task<bool> AddTask(AddTaskDTO addTaskDTO);

		Task<bool> UpdateTask(UpdateTaskDTO updateTaskDTO);

		Task<bool> DeleteTask(int taskId);

	}
}
