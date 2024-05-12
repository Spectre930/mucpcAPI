using Microsoft.EntityFrameworkCore;
using mucpc.Application.Forms.Dtos.FormAnalytics;
using mucpc.Dmain.DTO.FormAnalytics;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;
using MUCPC.Infrastructure.Persistence;

namespace mucpc.Infrastructure.Repositories;

internal class FormRepository : Repository<Form>, IFormRepository
{
    private readonly mucpcDbContext _db;
    public FormRepository(mucpcDbContext db) : base(db)
    {
        _db = db;
    }
    public async Task<long> AddForm(Form dto)
    {

        await _db.Forms.AddAsync(dto);
        await _db.SaveChangesAsync();
        var formId = dto.Id;
        return formId;
    }

    public async Task UpdateForm(Form form)
    {
        var obj = await _db.Forms.FirstOrDefaultAsync(x => x.Id == form.Id);
        if (obj == null)
        {
            throw new Exception("Form Not Found");
        }

        obj.Title = form.Title;
        obj.Description = form.Description;
        obj.WorkShopId = form.WorkShopId;
        obj.EvaluationForm = form.EvaluationForm;
        obj.RegistrationForm = form.RegistrationForm;
        _db.Forms.Update(obj);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteForm(long id)
    {
        var obj = await _db.Forms.FirstOrDefaultAsync(x => x.Id == id);
        if (obj == null)
        {
            throw new Exception("Form Not Found");
        }

        _db.FormQuestions.RemoveRange(_db.FormQuestions.Where(x => x.FormId == id));
        _db.QuestionsResponses.RemoveRange(_db.QuestionsResponses.Where(x => x.FormQuestion.FormId == id));
        _db.Forms.Remove(obj);
        await _db.SaveChangesAsync();
    }

    public async Task<FormAnalytics> GetFormAnalytics(long id)
    {
        var spResponse = await _db.Database
            .SqlQueryRaw<SpModel>($@"EXEC [dbo].[sp_FormAnalytics] @formId = {id}")
            .ToListAsync();

        var groupedByQuestion = spResponse.GroupBy(spModel => spModel.Question);
        List<QuestionAnalytics> questionAnalyticsList = new List<QuestionAnalytics>();
        foreach (var group in groupedByQuestion)
        {
            QuestionAnalytics questionAnalytics = new QuestionAnalytics();
            questionAnalytics.Question = group.Key;

            // Map responses for each question
            questionAnalytics.Responses = group.Select(spModel => new ResponseAnalytics
            {
                Response = spModel.Response,
                ResponseCount = spModel.ResponseCount,
                Percentage = spModel.Percentage
            }).ToList();

            // Add the QuestionAnalytics to the list
            questionAnalyticsList.Add(questionAnalytics);
        }

        var totalResponses = _db.FormResponses.Where(x => x.FormId == id).Count();
        var formAnalytics = new FormAnalytics
        {
            Questions = questionAnalyticsList,
            TotalResponses = totalResponses
        };

        return formAnalytics;
    }

    public async Task<IEnumerable<FormResponse>> GetFormResponses(long id)
    {
        var responses = await _db.Forms
            .Where(x => x.Id == id)
            .Include(x => x.FormResponses)
            .ThenInclude(fr => fr.QuestionsResponses)
            .Select(x => x.FormResponses)
            .FirstOrDefaultAsync();

        foreach (var response in responses)
        {
            foreach (var qr in response.QuestionsResponses)
            {
                qr.FormResponse = null;
            }
        }


        return responses.ToList();


    }

    public async Task<Form> GetById(long id)
    {
        return await _db.Forms.FindAsync(id) ?? throw new Exception("Form Not Found");
    }
}
