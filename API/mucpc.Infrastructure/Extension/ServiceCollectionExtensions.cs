using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mucpc.Dmain.Repositories;
using mucpc.Infrastructure.Repositories;
using mucpc.Infrastructure.Seeders;
using mucpc.Infrastructure.Seeders.interfaces;
using MUCPC.Infrastructure.Persistence;

namespace mucpc.Infrastructure.Extension;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<mucpcDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IRoleSeeder, RoleSeeder>();
        services.AddScoped<IAdminSeeder, AdminSeeder>();
    }
}
