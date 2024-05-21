using MediatR;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Instructors.Queries.GetInstructorRatingInAWorkShop;

public class GetInstructorRatingInAWorkShopQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetInstructorRatingInAWorkShopQuery, double?>
{
    public async Task<double?> Handle(GetInstructorRatingInAWorkShopQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.Instructors.GetInstructorRatingInAWorkShop(request.WorkshopId);
    }
}