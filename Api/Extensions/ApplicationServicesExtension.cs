using Api.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Models.Interfaces;

namespace Api.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState.Where(e => e.Value.Errors.Count() > 0)
                    .SelectMany(e => e.Value.Errors).Select(e => e.ErrorMessage).ToArray();
                    var errorResponse = new ValidationErrorResponse { Errors = errors };
                    return new BadRequestObjectResult(errorResponse);
                };

            });
            return services;
        }
    }
}
