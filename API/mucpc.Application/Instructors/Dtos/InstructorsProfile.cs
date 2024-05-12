using AutoMapper;
using mucpc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mucpc.Application.Instructors.Dtos;

public class InstructorsProfile : Profile
{
    public InstructorsProfile()
    {
        CreateMap<Instructor, InstructorDto>();
        CreateMap<CreateInstructorDto, Instructor>();
    }
}
