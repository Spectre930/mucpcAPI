using AutoMapper;
using mucpc.Domain.Entities;
using System.Xml.Serialization;

namespace mucpc.Application.Students.Dtos;

public class StudentsProfile : Profile
{
    public StudentsProfile()
    {
        CreateMap<Student, StudentDto>()
            .ForMember(u => u.Email, opt =>
            opt.MapFrom(src => src.User.Email))
            .ForMember(u => u.Password, opt =>
            opt.MapFrom(src => src.User.Password))
            .ForMember(u => u.Role, opt =>
            opt.MapFrom(src => src.User.Role))
            .ForMember(u => u.RoleId, opt =>
            opt.MapFrom(src => src.User.RoleId));

        CreateMap<CreateStudentDto, Student>();
    }
}
