using MediatR;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Workshops.Queries.GetRegisteredEmails;

public class GetRegisteredEmailsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetRegisteredEmailsQuery, List<string>>
{
    public async Task<List<string>> Handle(GetRegisteredEmailsQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.Workshops.GetRegisteredEmails(request.Id);
    }
}
