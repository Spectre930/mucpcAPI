using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using mucpc.Dmain.DTO;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;
using MUCPC.Infrastructure.Persistence;
namespace mucpc.Infrastructure.Repositories;

internal class InstructorRepository(mucpcDbContext _db) : Repository<Instructor>(_db), IInstructorRepository
{
    public async Task AddInstructor(Instructor instructor)
    {
        if (await GetFirstOrDefaultAsync(s => s.Email == instructor.Email) == null)
        {
            await _db.Instructors.AddAsync(instructor);
            await _db.SaveChangesAsync();
            return;
        }
        throw new Exception("email already exists!");
    }

    public async Task DeleteInstructor(long id)
    {
        var instructor = await GetFirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Instructor Not Found!");
        Remove(instructor);
        await _db.SaveChangesAsync();
    }

    public async Task<double?> GetInstructorRatingInAWorkShop(long WorkShopId)
    {
        var form = await _db.Forms
       .Where(f => f.WorkShopId == WorkShopId && f.EvaluationForm)
       .FirstOrDefaultAsync();

        // Check if the form was found
        if (form is null)
        {
            throw new ArgumentException($"No Evaluation form found for Workshop ID {WorkShopId}.");
        }

        // Define the parameter for the stored procedure
        var formIdParam = new SqlParameter("@formId", form.Id);

        // Execute the stored procedure and retrieve the result
        var averageRating = _db.Database
            .SqlQueryRaw<double?>("EXEC dbo.sp_CalculateInstructorRatingInAWorkshop @formId",
                                 formIdParam)
            .AsEnumerable() // Perform the operation on the client side
            .FirstOrDefault();

        // Return the average rating
        return averageRating;
    }

    public async Task<double?> GetOverAllInstructorRating(long InstructorId)
    {
        var instructor = await _db.Instructors.FindAsync(InstructorId);
        if (instructor is null)
        {
            throw new Exception("Instructor is not found");
        }

        if (instructor.Rating is not null)
            return instructor.Rating;


        // Define the parameter for the stored procedure
        var instructorIdParam = new SqlParameter("@instructorId", InstructorId);

        // Execute the stored procedure and retrieve the result
        var averageRating = _db.Database
            .SqlQueryRaw<double?>("EXEC dbo.sp_CalculateOverallAverageInstructorRating @instructorId",
                                 instructorIdParam)
            .AsEnumerable() // Perform the operation on the client side
            .FirstOrDefault();

        // Return the average rating
        return averageRating;

    }

    public async Task<IEnumerable<WorkShop>> GetWorkShops(long InstructorId)
    {

        var instructor = await _db.Instructors.FindAsync(InstructorId) ?? throw new Exception("Instructor Not Found");


        return await _db.WorkShops
            .Where(w => w.InstructorId == InstructorId)
            .ToListAsync();
    }

    public async Task UpdateInstructor(Instructor instructor)
    {
        var i = await GetFirstOrDefaultAsync(x => x.Id == instructor.Id) ?? throw new Exception("Instructor Not Found!");

        i.FirstName = instructor.FirstName;
        i.MiddleName = instructor.MiddleName;
        i.LastName = instructor.LastName;
        i.PhoneNumber = instructor.PhoneNumber;
        i.Email = instructor.Email;
        i.Address = instructor.Address;
        i.YearsOfExpertise = instructor.YearsOfExpertise;
        i.Major = instructor.Major;
        i.DegreeLevel = instructor.DegreeLevel; ;

        _db.Instructors.Update(i);

    }

}
