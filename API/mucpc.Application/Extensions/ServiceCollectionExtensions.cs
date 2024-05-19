using Microsoft.Extensions.DependencyInjection;
using mucpc.Application.Analytics;
using mucpc.Application.AppUsers;
using mucpc.Application.AppUsers.Admins;
using mucpc.Application.Forms;
using mucpc.Application.Forms.FormQuestions;
using mucpc.Application.Forms.FormResponses;
using mucpc.Application.Instructors;
using mucpc.Application.Roles;
using mucpc.Application.Students;
using mucpc.Application.Workshops;
using mucpc.Application.Workshops.RegisterRequests;

namespace mucpc.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
        services.AddAutoMapper(applicationAssembly);

        //services.AddScoped<IAdminsService, AdminsService>();
        //services.AddScoped<IAuthService, AuthService>();
        //services.AddScoped<IStudnetsService, StudnetsService>();
        //services.AddScoped<IRolesService, RolesService>();
        //services.AddScoped<IInstructorsService, InstructorsService>();
        //services.AddScoped<IAnalyticsService, AnalyticsService>();

        ////form services
        //services.AddScoped<IFormQuestionService, FormQuestionService>();
        //services.AddScoped<IFormService, FormService>();
        //services.AddScoped<IFormResponsesService, FormResponsesService>();

        //services.AddScoped<IWorkshopsService, WorkshopsService>();
        //services.AddScoped<IRegisterRequestsService, RegisterRequestsService>();

    }
}