using AutoMapper;
using mucpc.Domain.Entities;

namespace mucpc.Application.Forms.Dtos;

public class FormProfiles : Profile
{
    public FormProfiles()
    {
        CreateMap<Form, FormDto>();
        CreateMap<CreateFormDto, Form>();
    }
}
