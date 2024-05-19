using AutoMapper;
using mucpc.Domain.Entities;
using System.Xml.Serialization;

namespace mucpc.Application.Students.Dtos;

public class StudentsProfile : Profile
{
    public StudentsProfile()
    {
        CreateMap<Student, StudentDto>();
        CreateMap<StudentDto, Student>();

        CreateMap<CreateStudentDto, Student>();
    }
}
