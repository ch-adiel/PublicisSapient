using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PublicisSapient.Middlewares;
using PublicisSapient.Models;
using PublicisSapient.Models.ViewModels;
using PublicisSapient.Repositories;
using PublicisSapient.Repositories.Interfaces;
using System.Net;

namespace PublicisSapient.Extensions
{
    public static class StartupExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<CreditCard>, Repository<CreditCard>>();
        }
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
        }

        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "API",
                    Version = "v2",
                    Description = "API Service",
                });
            });
        }
    }
}
