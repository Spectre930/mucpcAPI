using Microsoft.EntityFrameworkCore;
using mucpc.Application.Forms.FormQuestions.Dtos;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;
using MUCPC.Infrastructure.Persistence;


namespace mucpc.Infrastructure.Repositories;

internal class FormQuestionRepository(mucpcDbContext _db) : IFormQuestionRepository
{
    public async Task<FormQuestion> GetById(long Id)
    {
        return await _db.FormQuestions.FindAsync(Id) ?? throw new Exception("question not found!");
    }
    public async Task DeleteQuestion(long Id)
    {
        var question = await _db.FormQuestions.FindAsync(Id);

        if (question is null)
        {
            throw new Exception("Question not found");
        }

        _db.FormQuestions.Remove(question);
        await _db.SaveChangesAsync();

    }

    public async Task EditQuestion(FormQuestion formQuestion)
    {
        _db.FormQuestions.Update(formQuestion);
        await _db.SaveChangesAsync();
    }

    public async Task AddQuestion(FormQuestion dto)
    {
        await _db.FormQuestions.AddAsync(dto);
        await _db.SaveChangesAsync();
    }

    public async Task<List<FormQuestion>> GetQuestionsByFormId(long FormId)
    {
        return await _db.FormQuestions
            .AsNoTracking()
            .Where(x => x.FormId == FormId)
            .ToListAsync();
    }
}
