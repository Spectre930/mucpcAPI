using AutoMapper;
using MediatR;
using mucpc.Application.Instructors.Dtos;
using mucpc.Dmain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mucpc.Application.Analytics.Queries.GetHighestRatedInstructorInAnAcademicYear;
public class GetHighestRatedInstructorInAnAcademicYearQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetHighestRatedInstructorInAnAcademicYearQuery, InstructorDto>
{
    public async Task<InstructorDto> Handle(GetHighestRatedInstructorInAnAcademicYearQuery request, CancellationToken cancellationToken)
    {
        var instructor = await unitOfWork.Analytics.GetHighestRatedInstructorInAnAcademicYear(request.Year);
        return mapper.Map<InstructorDto>(instructor);
    }
}

