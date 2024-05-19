using AutoMapper;
using mucpc.Application.Forms.Commands.CreateForm;
using mucpc.Application.Forms.Commands.UpdateForm;
using mucpc.Domain.Entities;

namespace mucpc.Application.Forms.Dtos;

public class FormProfiles : Profile
{
    public FormProfiles()
    {
        CreateMap<Form, FormDto>();
        CreateMap<FormDto, Form>();
        CreateMap<CreateFormDto, Form>();
        CreateMap<CreateFormCommand, Form>();
        CreateMap<UpdateFormCommand, Form>();
    }
}
