namespace Task.API.ResponseModel
{
	public class ApiResponse
	{
		public ApiResponse(string message, object? data = null)
		{
			Code = "Success";
			Message = message;
			Data = data;
		}

		public ApiResponse(string message)
		{
			Code = "Error";
			Message = message;
		}

		public ApiResponse(string message, Exception exception)
		{
			Code = "Error";
			Message = message;
			Data = exception.Message;
		}

		public string Code { get; set; }

		public string Message { get; set; }

		public object? Data { get; set; }
	}
}
