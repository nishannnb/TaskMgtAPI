using Microsoft.AspNetCore.Mvc;
using Task.API.DTO;
using Task.API.ResponseModel;
using Task.API.Services;

namespace Task.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TasksController(ITaskService iTaskService) : ControllerBase
	{
		private readonly ITaskService _iTaskService = iTaskService;

		[HttpGet("GetAllTaskList")]
		public async Task<IActionResult> GetAllTaskList()
		{
			var response = await _iTaskService.GetAllTaskList();

			ApiResponse apiResponse;
			if (response == null)
			{
				apiResponse = new("Not found the tasks", response);
				return NotFound(apiResponse);
			}

			apiResponse = new("Task list retrieved successfully", response);
			return Ok(apiResponse);
		}

		[HttpPost("CreateTask")]
		public async Task<IActionResult> CreateTask([FromBody] AddTaskDTO addTaskDTO)
		{
			ApiResponse apiResponse;
			if (addTaskDTO == null)
			{
				apiResponse = new("Task data is required");
				return BadRequest(apiResponse);
			}
			if (string.IsNullOrWhiteSpace(addTaskDTO.TaskName))
			{
				apiResponse = new("Task name is required");
				return BadRequest(apiResponse);
			}
			if (addTaskDTO.FinishDate == default)
			{
				apiResponse = new("Finish date is required");
				return BadRequest(apiResponse);
			}

			var response = await _iTaskService.AddTask(addTaskDTO);
			if (response)
			{
				apiResponse = new("Task added successfully", response);
				return Ok(apiResponse);
			}
			apiResponse = new("Add task is Failed");
			return BadRequest(apiResponse);
		}

		[HttpPut("UpdateTask")]
		public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskDTO updateTaskDTO)
		{
			ApiResponse apiResponse;
			if (updateTaskDTO == null)
			{
				apiResponse = new("Task data is required");
				return BadRequest(apiResponse);
			}
			if (updateTaskDTO.TaskId <= 0)
			{
				apiResponse = new("Task ID is required");
				return BadRequest(apiResponse);
			}
			var response = await _iTaskService.UpdateTask(updateTaskDTO);
			if (response)
			{
				apiResponse = new("Task updated successfully", response);
				return Ok(apiResponse);
			}
			apiResponse = new("Update task is Failed");
			return BadRequest(apiResponse);
		}

		[HttpDelete("DeleteTask/{taskId}")]
		public async Task<IActionResult> DeleteTask(int taskId)
		{
			ApiResponse apiResponse;
			if (taskId <= 0)
			{
				apiResponse = new("Task ID is required");
				return BadRequest(apiResponse);
			}
			var response = await _iTaskService.DeleteTask(taskId);
			if (response)
			{
				apiResponse = new("Task deleted successfully", response);
				return Ok(apiResponse);
			}
			apiResponse = new("Delete task is Failed");
			return BadRequest(apiResponse);
		}
	}
}
