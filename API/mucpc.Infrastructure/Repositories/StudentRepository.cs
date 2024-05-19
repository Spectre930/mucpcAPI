using Microsoft.EntityFrameworkCore;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;
using MUCPC.Infrastructure.Persistence;


namespace mucpc.Infrastructure.Repositories;

internal class StudentRepository
    (mucpcDbContext _db,
    IAppUserRepository _userRepository)
    : Repository<Student>(_db),
    IStudentRepository
{
    public async Task AddStudent(Student dto)
    {
        await _db.Students.AddAsync(dto);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteStudent(long id)
    {
        await _userRepository.DeleteUser(id);
    }

    public async Task<Student> GetById(long id)
    {
        var student = await _db.Students
            .Include(s => s.User)
            .ThenInclude(u => u.Role)
            .Where(s => s.UserId == id)
            .FirstOrDefaultAsync() ?? throw new Exception("student not found!");

        return student;
    }

    public async Task<IEnumerable<WorkShop>> GetWorkshops(long studentId)
    {
        var student = await _db.Students
            .Where(s => s.UserId == studentId)
            .Include(s => s.Workshops)
             .Select(s => new
             {
                 Workshops = s.Workshops.Select(w => new WorkShop
                 {
                     Id = w.Id,
                     Title = w.Title,
                     Number = w.Number,
                     DateAndTime = w.DateAndTime,
                     Semester = w.Semester,
                     AcedemicYear = w.AcedemicYear,
                     TargetedFaculties = w.TargetedFaculties,
                     Price = w.Price,
                     Duration = w.Duration,
                     Objectives = w.Objectives,
                     DeliveryType = w.DeliveryType,
                     Speaker = w.Speaker,
                     OrganizedBy = w.OrganizedBy,
                     RegistrationLink = w.RegistrationLink,
                     MaxNumberOfAttendees = w.MaxNumberOfAttendees,
                     Rating = w.Rating,
                     Description = w.Description,
                     NumberOfHours = w.NumberOfHours,
                     InstructorId = w.InstructorId,
                 }).ToList()

             })
            .FirstOrDefaultAsync();

        if (student is null)
            throw new Exception("Student Not Found!");


        return student.Workshops;
    }


    public async Task UpdateStudent(Student student)
    {
        var obj = await _db.Students.Include(s => s.User).FirstOrDefaultAsync(s => s.UserId == student.UserId) ?? throw new Exception("User Not Found!");

        _db.Students.Update(obj);
        await _db.SaveChangesAsync();


    }
}
