using AutoMapper;
using mucpc.Application.Students.Commands.AddStudent;
using mucpc.Application.Students.Commands.UpdateStudent;
using mucpc.Domain.Entities;

namespace mucpc.Application.Students.Dtos;

public class StudentsProfile : Profile
{
    public StudentsProfile()
    {
        CreateMap<Student, StudentDto>();
        CreateMap<StudentDto, Student>();

        CreateMap<AddStudentCommand, Student>();
        CreateMap<UpdateStudentCommand, Student>();
    }
}
