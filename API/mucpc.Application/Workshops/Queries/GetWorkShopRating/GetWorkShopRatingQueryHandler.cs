using MediatR;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Workshops.Queries.GetWorkShopRating;

public class GetWorkShopRatingQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetWorkShopRatingQuery, double?>
{
    public async Task<double?> Handle(GetWorkShopRatingQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.Workshops.GetWorkShopRating(request.Id);
    }
}
