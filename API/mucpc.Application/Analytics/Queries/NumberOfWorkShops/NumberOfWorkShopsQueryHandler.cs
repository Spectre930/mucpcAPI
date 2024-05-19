using MediatR;
using mucpc.Dmain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mucpc.Application.Analytics.Queries.NumberOfWorkShops;

public class NumberOfWorkShopsQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<NumberOfWorkShopsQuery, int>
{
    public async Task<int> Handle(NumberOfWorkShopsQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Analytics.NumberOfWorkShops();
    }
}
