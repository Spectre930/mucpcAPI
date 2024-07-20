using MediatR;

namespace mucpc.Application.Workshops.Queries.GetRegisteredEmails;

public class GetRegisteredEmailsQuery(long id) : IRequest<List<string>>
{
    public long Id { get; set; } = id;
}

