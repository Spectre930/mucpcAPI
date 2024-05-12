using Microsoft.EntityFrameworkCore;
using mucpc.Application.Forms.FormQuestions.Dtos;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;
using MUCPC.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mucpc.Infrastructure.Repositories;

internal class FormQuestionRepository(mucpcDbContext _db) : IFormQuestionRepository
{
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
        var question = await _db.FormQuestions.FindAsync(formQuestion.Id);

        if (question is null)
        {
            throw new Exception("Question not found");
        }

        question.Question = formQuestion.Question;
        question.Type = formQuestion.Type;
        question.Options = formQuestion.Options;

        _db.FormQuestions.Update(question);
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
