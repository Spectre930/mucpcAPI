using MediatR;
using mucpc.Dmain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mucpc.Application.Analytics.Queries.NumberOfInstructors;
public class NumberOfInstructorsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<NumberOfInstructorsQuery, int>
{
    public async Task<int> Handle(NumberOfInstructorsQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.Analytics.NumberOfInstructors();
    }
}

