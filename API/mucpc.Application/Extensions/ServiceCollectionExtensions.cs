using Microsoft.Extensions.DependencyInjection;
using mucpc.Application.Analytics;
using mucpc.Application.Instructors;
using mucpc.Application.Roles;

namespace mucpc.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRolesService, RolesService>();
        services.AddScoped<IInstructorsService, InstructorsService>();
        services.AddScoped<IAnalyticsService, AnalyticsService>();

        services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
    }
}