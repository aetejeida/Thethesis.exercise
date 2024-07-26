using thesis_exercise.Middleware;

namespace thesis_exercise.Extensions
{
    public static class IApplicationBuilderExtension
    {
        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder) 
        {
            return builder.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
