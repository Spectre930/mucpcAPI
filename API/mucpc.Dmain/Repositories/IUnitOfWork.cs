namespace mucpc.Dmain.Repositories;

public interface IUnitOfWork
{
    IAnalyticsRepository Analytics { get; }
    IAppUserRepository AppUsers { get; }
    IInstructorRepository Instructors { get; }
    IFormRepository Forms { get; }
    IFormQuestionRepository FormQuestions { get; }
    IFormResponseRepository FormResponses { get; }
    IRoleRepository Roles { get; }
    IStudentRepository Students { get; }
    IWorkshopRepository Workshops { get; }
    IEmailSender EmailSender { get; }
    IRegisterRequestRepository RegisterRequests { get; }
    Task SaveAsync();
}
