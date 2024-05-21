using MediatR;
using mucpc.Dmain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mucpc.Application.Instructors.Queries.GetOverAllInstructorRating;

public class GetOverAllInstructorRatingQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetOverAllInstructorRatingQuery, double?>
{
    public async Task<double?> Handle(GetOverAllInstructorRatingQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.Instructors.GetOverAllInstructorRating(request.Id);
    }
}
