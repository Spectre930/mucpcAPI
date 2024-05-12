

using mucpc.Domain.Entities;

namespace mucpc.Dmain.Repositories;

public interface IFormQuestionRepository
{
    Task EditQuestion(FormQuestion formQuestion);
    Task DeleteQuestion(long Id);
    Task AddQuestion(FormQuestion dto);
    Task<List<FormQuestion>> GetQuestionsByFormId(long FormId);
}
