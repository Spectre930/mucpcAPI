using AutoMapper;
using mucpc.Domain.Entities;

namespace mucpc.Application.Forms.FormQuestions.Responses.Dtos;
public class QuestionResponseProfile : Profile
{
    public QuestionResponseProfile()
    {
        CreateMap<QuestionResponse, QuestionResponseDto>();
        CreateMap<CreateQuestionResponseDto, QuestionResponse>();
    }
}

