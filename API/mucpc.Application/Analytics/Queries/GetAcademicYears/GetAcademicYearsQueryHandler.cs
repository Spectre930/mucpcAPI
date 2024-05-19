using MediatR;
using mucpc.Dmain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mucpc.Application.Analytics.Queries.GetAcademicYears;
public class GetAcademicYearsQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetAcademicYearsQuery, List<int?>>
{
    public async Task<List<int?>> Handle(GetAcademicYearsQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Analytics.GetAcademicYears();
    }
}

