using MediatR;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Analytics.Queries.NumberOfWorkShopsInAnAcademicYear;

public class NumberOfWorkShopsInAnAcademicYearQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<NumberOfWorkShopsInAnAcademicYearQuery, int>
{
    public async Task<int> Handle(NumberOfWorkShopsInAnAcademicYearQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.Analytics.NumberOfWorkShopsInAnAcademicYear(request.Year);
    }
}
