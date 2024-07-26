using Microsoft.OpenApi.Models;
using thesis_exercise.common.LoggerManager;
using thesis_exercise.data.Repositories;
using thesis_exercise.data.Repositories.Interface;
using thesis_exercise.services.Implementation;
using thesis_exercise.services.Interface;
using thesis_exercise.services.Mapping;

namespace thesis_exercise.Extensions
{
    public static class AppServiceExtension
    {
        public static void AddApplicationServices(this IServiceCollection services) 
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();

            //Services
            services.AddScoped<IComputerService, ComputerService>();

            //Repository
            services.AddScoped<IComputerRepository, ComputerRepository>();

            services.AddAutoMapper(MappingProfiles.ConfigureMapping);
        }

        public static void AddSwagger(this IServiceCollection services) 
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Thesis Exercise",
                    Version = "v1",
                    Description = "Thesis Exercise"
                });

            });
        }
    }
}
    