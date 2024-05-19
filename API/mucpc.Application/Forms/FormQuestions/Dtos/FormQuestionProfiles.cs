using AutoMapper;
using mucpc.Application.Forms.FormQuestions.Commands.AddQuestion;
using mucpc.Application.Forms.FormQuestions.Commands.EditQuestion;
using mucpc.Domain.Entities;

namespace mucpc.Application.Forms.FormQuestions.Dtos;

public class FormQuestionProfiles : Profile
{
    public FormQuestionProfiles()
    {
        CreateMap<FormQuestion, FormQuestionDto>();
        CreateMap<FormQuestionDto, FormQuestion>();
        CreateMap<CreateFormQuestionDto, FormQuestion>();
        CreateMap<EditQuestionCommand, FormQuestion>()
            .ForMember(dest => dest.Options, opt =>
            opt.MapFrom(src => String.Join(",", src.Options)));
        CreateMap<AddQuestionCommand, FormQuestion>()
            .ForMember(dest => dest.Options, opt =>
            opt.MapFrom(src => String.Join(",", src.Options)));
    }
}
