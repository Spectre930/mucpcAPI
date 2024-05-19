using MediatR;
using mucpc.Dmain.Repositories;


namespace mucpc.Application.Analytics.Queries.NumberOfStudents;

public class NumberOfStudentsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<NumberOfStudentsQuery, int>
{
    public async Task<int> Handle(NumberOfStudentsQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.Analytics.NumberOfStudents();
    }
}

