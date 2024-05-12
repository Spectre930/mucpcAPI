using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;
using MUCPC.Infrastructure.Persistence;

namespace mucpc.Infrastructure.Repositories;

internal class AnalyticsRepository(mucpcDbContext _db) : IAnalyticsRepository
{

    public async Task<List<int?>> GetAcademicYears()
    {
        return await _db.WorkShops
           .Select(w => w.AcedemicYear)
           .Distinct()
           .ToListAsync();

    }

    public async Task<Instructor> GetHighestRatedInstructor()
    {

        return await _db.Instructors
            .OrderByDescending(i => i.Rating)
            .FirstOrDefaultAsync();
    }

    public async Task<Instructor> GetHighestRatedInstructorInAnAcademicYear(int year)
    {
        var workshops = await _db.WorkShops
            .Where(w => w.AcedemicYear == year)
            .Include(w => w.Instructor)
            .ToListAsync();

        var workshopIds = workshops.Select(w => w.Id);

        var forms = await _db.Forms
            .Where(f => workshopIds.Contains(f.WorkShopId) && f.EvaluationForm)
            .ToListAsync();
        var dictionary = new Dictionary<long, double?>();
        foreach (var f in forms)
        {
            // Define the parameter for the stored procedure
            var formIdParam = new SqlParameter("@formId", f.Id);

            // Execute the stored procedure and retrieve the result
            var averageRating = _db.Database
                .SqlQueryRaw<double?>("EXEC dbo.sp_CalculateInstructorRatingInAWorkshop @formId",
                                     formIdParam)
            .AsEnumerable() // Perform the operation on the client side
            .FirstOrDefault();
            dictionary.Add(f.Id, averageRating);
        }

        var max = dictionary.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

        var workshopId = forms.FirstOrDefault(w => w.Id == max).WorkShopId;

        return workshops
            .Where(w => w.Id == workshopId)
            .Select(w => w.Instructor)
            .FirstOrDefault();

        //var instructors = await _db.WorkShops
        //    .Where(w => w.AcedemicYear == year)
        //    .Select(w => w.Instructor)
        //    .Distinct()
        //    .ToListAsync();

        //return instructors.MaxBy(i => i.Rating);

    }

    public async Task<WorkShop> GetHighestRatedWorkshop()
    {
        return await _db.WorkShops
            .OrderByDescending(w => w.Rating)
            .FirstOrDefaultAsync();
    }

    public async Task<WorkShop> GetHighestRatedWorkshopInAnAcademicYear(int year)
    {
        return await _db.WorkShops
            .Where(w => w.AcedemicYear == year)
            .OrderByDescending(w => w.Rating)
            .FirstOrDefaultAsync();
    }

    public async Task<int> NumberOfInstructors()
    {
        return await _db.Instructors.CountAsync();
    }

    public async Task<int> NumberOfStudents()
    {
        return await _db.Students.CountAsync();
    }

    public async Task<int> NumberOfWorkShops()
    {
        return await _db.WorkShops.CountAsync();
    }

    public Task<int> NumberOfWorkShopsInAnAcademicYear(int year)
    {
        return _db.WorkShops.Where(w => w.AcedemicYear == year).CountAsync();
    }
}
