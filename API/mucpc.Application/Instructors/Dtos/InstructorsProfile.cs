using AutoMapper;
using mucpc.Application.Instructors.Commands.AddInstructor;
using mucpc.Application.Instructors.Commands.UpdateInstructor;
using mucpc.Domain.Entities;

namespace mucpc.Application.Instructors.Dtos;

public class InstructorsProfile : Profile
{
    public InstructorsProfile()
    {
        CreateMap<Instructor, InstructorDto>();
        CreateMap<CreateInstructorDto, Instructor>();
        CreateMap<AddInstructorCommand, Instructor>();
        CreateMap<UpdateInstructorCommand, Instructor>();

    }
}
