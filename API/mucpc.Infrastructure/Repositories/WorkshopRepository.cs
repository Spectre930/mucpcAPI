using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;
using MUCPC.Infrastructure.Persistence;

namespace mucpc.Infrastructure.Repositories;

internal class WorkshopRepository(mucpcDbContext _db,
    IFormResponseRepository _FRrepositroy) : Repository<WorkShop>(_db), IWorkshopRepository
{
    public async Task AddWorkShop(WorkShop dto)
    {
        await _db.WorkShops.AddAsync(dto);
        await _db.SaveChangesAsync();
    }

    public async Task EvaluateWorkshop(long workshopId, FormResponse evaluation)
    {
        var workshop = _db.WorkShops.Include(w => w.Students).FirstOrDefault(w => w.Id == workshopId) ?? throw new Exception("Workshop Not Found!");

        var form = _db.Forms.FirstOrDefault(f => f.WorkShopId == workshopId && f.EvaluationForm) ?? throw new Exception("No Evaluation Form Found!");

        var student = workshop.Students.Where(s => s.UserId == evaluation.StudentId).FirstOrDefault() ?? throw new Exception("Student is not registered in this workshop!");

        await _FRrepositroy.AddResponse(evaluation);
    }

    public int GetLastWorkshopNumber(int academicYear, string semester)
    {
        var lastWorkshop = _db.WorkShops
          .Where(w => w.Number.StartsWith($"CPC{academicYear}{semester}"))
          .OrderByDescending(w => w.Number)
          .FirstOrDefault();
        if (lastWorkshop == null)
        {
            return 1;
        }
        var WorkshopNumber = lastWorkshop.Number;

        int indexOfPattern = WorkshopNumber.IndexOf(semester, StringComparison.OrdinalIgnoreCase);

        string substringAfterPattern = WorkshopNumber.Substring(indexOfPattern + semester.Length);

        int.TryParse(substringAfterPattern, out int result);

        return result;

    }

    public async Task<List<string>> GetRegisteredEmails(long WorkShopId)
    {
        var workshop = await _db.WorkShops.FindAsync(WorkShopId) ?? throw new Exception("Workshop Not Found!");

        var form = await _db.Forms
            .Where(f => f.WorkShopId == WorkShopId && f.RegistrationForm)
            .FirstOrDefaultAsync() ?? throw new Exception("No Registration Form Found!");

        var emails = await _db.Students
            .Include(s => s.Workshops)
            .Include(s => s.User)
            .Where(s => s.Workshops.Contains(workshop))
            .Select(s => s.User.Email)
            .ToListAsync();

        return emails;
    }

    public async Task<List<RegisterRequest>> GetRegisterRequests(long workshopId)
    {
        var requests = await _db.RegisterRequests.Where(rr => rr.WorkShopId == workshopId).ToListAsync();

        return requests;
    }

    public async Task<double?> GetWorkShopRating(long WorkShopId)
    {
        var workshop = await _db.WorkShops.FindAsync(WorkShopId);
        if (workshop.Rating is not null)
        {
            return workshop.Rating;
        }


        var form = await _db.Forms
       .Where(f => f.WorkShopId == WorkShopId && f.EvaluationForm)
       .FirstOrDefaultAsync() ?? throw new ArgumentException($"No form found for Workshop ID {WorkShopId}.");


        // Define the parameter for the stored procedure
        var formIdParam = new SqlParameter("@formId", form.Id);

        // Execute the stored procedure and retrieve the result
        var averageRating = _db.Database
            .SqlQueryRaw<double?>("EXEC dbo.sp_CalculateWorkShopAverageRating @formId",
                                 formIdParam)
            .AsEnumerable() // Perform the operation on the client side
            .FirstOrDefault();

        // Return the average rating
        return averageRating;
    }

    public async Task<IEnumerable<WorkShop>> GetWorkshopsOfAnAcedemicYear(int academicYear)
    {
        return await _db.WorkShops
            .Where(_db => _db.AcedemicYear == academicYear)
            .ToListAsync();
    }

    public async Task<IEnumerable<WorkShop>> GetWorkshopsOfRecentSemester()
    {

        var result = GetRecent();
        return await _db.WorkShops
            .Where(w => w.AcedemicYear == result.academicYear && w.Semester == result.semester)
            .ToListAsync();
    }

    public async Task UpdateWorkShop(WorkShop workShop)
    {
        _db.WorkShops.Update(workShop);
        await _db.SaveChangesAsync();
    }


    public (int academicYear, string semester) GetRecent()
    {

        DateOnly workshopDate = DateOnly.FromDateTime(DateTime.Now); // Example workshop date

        // Determine the academic year based on the workshop date
        int academicYear = workshopDate.Month >= 9 ? workshopDate.Year : workshopDate.Year - 1;
        int currentAcademicYear = academicYear % 100; // Example: 2023-2024 becomes 23
        workshopDate = new DateOnly(academicYear, workshopDate.Month, workshopDate.Day);
        string currentSemester = "";
        if (workshopDate >= new DateOnly(academicYear, 9, 1) && workshopDate <= new DateOnly(academicYear, 1, 31))
        {
            currentSemester = "Fall";

        }
        else if (workshopDate >= new DateOnly(academicYear, 2, 1) && workshopDate <= new DateOnly(academicYear, 6, 2))
        {
            currentSemester = "Spring";
        }
        else if (workshopDate >= new DateOnly(academicYear, 6, 3) && workshopDate <= new DateOnly(academicYear, 8, 31))
        {
            currentSemester = "Summer";
        }
        else
        {
            currentSemester = "";
        }

        return (currentAcademicYear, currentSemester);
    }
}
