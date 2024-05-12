

using AutoMapper;
using mucpc.Application.Forms.FormQuestions.Dtos;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;

namespace mucpc.Application.Forms.FormQuestions;

internal class FormQuestionService(IFormQuestionRepository _FQRepository, IMapper _mapper) : IFormQuestionService
{
    public async Task DeleteQuestion(long Id)
    {
        await _FQRepository.DeleteQuestion(Id);
    }

    public async Task EditQuestion(FormQuestionDto formQuestion)
    {
        var question = _mapper.Map<FormQuestion>(formQuestion);

        await _FQRepository.EditQuestion(question);
    }

    public async Task AddQuestion(CreateFormQuestionDto dto)
    {
        var question = new FormQuestion
        {
            Question = dto.Question,
            Type = dto.Type,
            Options = String.Join(",", dto.Options),
            FormId = dto.FormId
        };

        await _FQRepository.AddQuestion(question);
    }

    public async Task<List<FormQuestionDto>> GetQuestionsByFormId(long FormId)
    {
        var questions = await _FQRepository.GetQuestionsByFormId(FormId);
        return _mapper.Map<List<FormQuestionDto>>(questions);
    }
}
