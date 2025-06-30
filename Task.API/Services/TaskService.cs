using Task.API.DAL;
using Task.API.DTO;
using Task.API.Services;

public class TaskService(ITaskRepository iTaskRepository) : ITaskService
{
	private readonly ITaskRepository _iTaskRepository = iTaskRepository;

	public async Task<List<TaskListDTO>> GetAllTaskList()
	{
		return await _iTaskRepository.GetAllTaskList();
	} 

	public async Task<bool> AddTask(AddTaskDTO addTaskDTO)
	{
		return await _iTaskRepository.AddTask(addTaskDTO);
	}

	public async Task<bool> UpdateTask(UpdateTaskDTO updateTaskDTO)
	{
		return await _iTaskRepository.UpdateTask(updateTaskDTO);
	}

	public async Task<bool> DeleteTask(int taskId)
	{
		return await _iTaskRepository.DeleteTask(taskId);
	}
}