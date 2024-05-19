using AutoMapper;
using MediatR;
using mucpc.Application.Instructors.Dtos;
using mucpc.Dmain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mucpc.Application.Analytics.Queries.GetHighestRatedInstructor;

public class GetHighestRatedInstructorQueryHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetHighestRatedInstructorQuery, InstructorDto>
{
    public async Task<InstructorDto> Handle(GetHighestRatedInstructorQuery request, CancellationToken cancellationToken)
    {
        var instructor = await _unitOfWork.Analytics.GetHighestRatedInstructor();
        return _mapper.Map<InstructorDto>(instructor);
    }
}
