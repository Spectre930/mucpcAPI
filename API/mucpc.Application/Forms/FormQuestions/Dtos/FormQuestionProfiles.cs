using AutoMapper;
using mucpc.Domain.Entities;

namespace mucpc.Application.Forms.FormQuestions.Dtos;

public class FormQuestionProfiles : Profile
{
    public FormQuestionProfiles()
    {
        CreateMap<FormQuestion, FormQuestionDto>();
        CreateMap<CreateFormQuestionDto, FormQuestion>();
    }
}
