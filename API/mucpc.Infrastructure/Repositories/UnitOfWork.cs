using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using mucpc.Dmain.Repositories;
using mucpc.Infrastructure.Extension;
using MUCPC.Infrastructure.Persistence;

namespace mucpc.Infrastructure.Repositories;

internal class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly mucpcDbContext _db;
    private readonly IConfiguration _configuration;
    private readonly IOptions<GmailSettings> _gmailsettings;
    public IAnalyticsRepository Analytics { get; private set; }

    public IAppUserRepository AppUsers { get; private set; }

    public IInstructorRepository Instructors { get; private set; }

    public IFormRepository Forms { get; private set; }

    public IFormQuestionRepository FormQuestions { get; private set; }

    public IFormResponseRepository FormResponses { get; private set; }

    public IRoleRepository Roles { get; private set; }

    public IStudentRepository Students { get; private set; }

    public IWorkshopRepository Workshops { get; private set; }

    public IEmailSender EmailSender { get; private set; }
    public IRegisterRequestRepository RegisterRequests { get; private set; }


    public UnitOfWork(mucpcDbContext db, IConfiguration configuration, IOptions<GmailSettings> gmailsettings)
    {
        _db = db;
        _configuration = configuration;
        _gmailsettings = gmailsettings;

        Analytics = new AnalyticsRepository(_db);
        AppUsers = new AppUserRepository(_db, _configuration);
        Instructors = new InstructorRepository(_db);
        Forms = new FormRepository(_db);
        FormQuestions = new FormQuestionRepository(_db);
        FormResponses = new FormResponseRepository(_db);
        Roles = new RoleRepository(_db);
        Students = new StudentRepository(_db, AppUsers);
        Workshops = new WorkshopRepository(_db, FormResponses);
        EmailSender = new EmailSender(_gmailsettings);
        RegisterRequests = new RegisterRequestRepository(_db, FormResponses, EmailSender);

    }
    public void Dispose()
    {
        _db.Dispose();
    }

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}
