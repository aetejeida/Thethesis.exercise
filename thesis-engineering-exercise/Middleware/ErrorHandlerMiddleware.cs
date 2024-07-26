using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using thesis_exercise.common;
using thesis_exercise.Helpers;

namespace thesis_exercise.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next) 
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) 
        {
            string message = "There was an error, please try again";
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error) 
                {
                    case DbUpdateConcurrencyException e:
                        message = UserErrorMessage.UpdateError;
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        break;

                    case DbUpdateException e:
                        message = UserErrorMessage.SaveUpdateDbError;
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        break;

                    case KeyNotFoundException e:
                        response.StatusCode = StatusCodes.Status404NotFound;
                        break;

                    case AppException e:
                        message = UserErrorMessage.RequestError;
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;

                    default:
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new { message });
                await response.WriteAsync(result);
            }

        }
    }
}
