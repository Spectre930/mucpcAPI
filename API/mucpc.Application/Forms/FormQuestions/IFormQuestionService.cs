using mucpc.Application.Forms.FormQuestions.Dtos;

namespace mucpc.Application.Forms.FormQuestions
{
    internal interface IFormQuestionService
    {
        Task AddQuestion(CreateFormQuestionDto dto);
        Task DeleteQuestion(long Id);
        Task EditQuestion(FormQuestionDto formQuestion);
        Task<List<FormQuestionDto>> GetQuestionsByFormId(long FormId);
    }
}