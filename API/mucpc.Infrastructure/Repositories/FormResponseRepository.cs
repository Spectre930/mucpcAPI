using Microsoft.EntityFrameworkCore;
using mucpc.Application.Forms.FormResponses.Dtos;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;
using MUCPC.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mucpc.Infrastructure.Repositories;

internal class FormResponseRepository(mucpcDbContext _db) : IFormResponseRepository
{
    public async Task<long> AddResponse(FormResponse formResponse)
    {
        var form = await _db.Forms.FindAsync(formResponse.FormId) ?? throw new Exception("Form Not Found!");
        var student = await _db.Students.FindAsync(formResponse.StudentId) ?? throw new Exception("Student Not Found!");

        var obj = _db.FormResponses
            .FirstOrDefault(x => x.FormId == formResponse.FormId && x.StudentId == formResponse.StudentId);

        if (obj is not null && form.RegistrationForm)
            throw new Exception($"Student with Id:{student.UserId} already filled the form!");

        if (student.Workshops.Any(x => x.Id == form.WorkShopId))
            throw new Exception($"Student with Id:{student.UserId} is already Registered!");

        if (!student.Workshops.Any(x => x.Id == form.WorkShopId) && form.EvaluationForm)
            throw new Exception($"Student with Id:{student.UserId} is not Registered in this Workshop");

        await _db.FormResponses.AddAsync(formResponse);
        await _db.SaveChangesAsync();
        var responseId = formResponse.Id;

        foreach (var qr in formResponse.QuestionsResponses)
        {
            await _db.QuestionsResponses.AddAsync(qr);
        }
        await _db.SaveChangesAsync();

        return formResponse.Id;
    }

    public async Task DeleteResponse(long ResponseId)
    {
        var response = await _db.FormResponses.FirstOrDefaultAsync(r => r.Id == ResponseId) ?? throw new Exception("Response not found");

        _db.FormResponses.Remove(response);
        await _db.SaveChangesAsync();
    }

    public async Task<FormResponse> GetResponseById(long ResponseId)
    {
        var response = await _db.FormResponses
            .Where(x => x.Id == ResponseId)
            .Include(x => x.QuestionsResponses)
            .Select(x => new FormResponse
            {
                Id = x.Id,
                FormId = x.FormId,
                QuestionsResponses = x.QuestionsResponses.Select(qr => new QuestionResponse
                {
                    FormQuestionId = qr.FormQuestionId,
                    FormQuestion = qr.FormQuestion,
                    Response = qr.Response
                }).ToList()
            })
            .FirstOrDefaultAsync();

        if (response is null)
        {
            throw new Exception("Response not found");
        }
        return response;
    }
}
