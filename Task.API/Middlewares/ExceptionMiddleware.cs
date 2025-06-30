using Task.API.ResponseModel;

namespace Task.API.Middlewares
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ExceptionMiddleware> _logger;

		public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async System.Threading.Tasks.Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An unhandled exception occurred.");

				context.Response.StatusCode = StatusCodes.Status500InternalServerError;
				ApiResponse apiResponse = new("An unexpected error occurred. Please try again later.", ex);
				await context.Response.WriteAsJsonAsync(apiResponse);
			}
		}
	}
}
