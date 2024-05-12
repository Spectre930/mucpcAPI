
using AutoMapper;
using mucpc.Domain.Entities;

namespace mucpc.Application.Forms.FormResponses.Dtos;

public class FormResponseProfile : Profile
{
    public FormResponseProfile()
    {
        CreateMap<FormResponse, FormResponseDto>();
        CreateMap<CreateFormResponseDto, FormResponse>();
    }
}
