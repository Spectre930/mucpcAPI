using Microsoft.EntityFrameworkCore;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;
using MUCPC.Infrastructure.Persistence;


namespace mucpc.Infrastructure.Repositories;

internal class RegisterRequestRepository(mucpcDbContext _db,
    IFormResponseRepository _FRrepository
    , IEmailSender _emailSender) : Repository<RegisterRequest>(_db), IRegisterRequestRepository
{
    public async Task AddRegisterRequest(RegisterRequest dto)
    {
        var workshop = await _db.WorkShops.FindAsync(dto.WorkShopId) ?? throw new Exception("Workshop Not Found!");

        var email = _db.Students.Find(dto.StudentId).User.Email ?? throw new Exception("Student not found!");



        //send email of pending verification
        await _emailSender.SendPendingVerificationEmail(email, workshop.Title);



        _db.RegisterRequests.Add(dto);
        await _db.SaveChangesAsync();

    }

    public async Task VerifyRequest(long requestId, bool isAccepted)
    {
        var request = await _db.RegisterRequests
            .Include(r => r.FormResponse)
            .Include(r => r.Student)
            .Include(r => r.FormResponse.QuestionsResponses)
            .FirstOrDefaultAsync(x => x.Id == requestId);

        if (request is null)
            throw new Exception("Request Not Found!");

        request.isAccepted = isAccepted;

        if (isAccepted)
            request.Status = "Accepted";
        else
            request.Status = "Rejected";

        _db.RegisterRequests.Update(request);
        await _db.SaveChangesAsync();



        //send email of acceptence or rejection
        //  var email = _db.AppUsers.Find(request.Student.UserId).Email ?? "10121672@mu.edu.lb";
        var email = "10121672@mu.edu.lb";
        var workshopName = _db.WorkShops.Find(request.WorkShopId).Title;

        if (isAccepted)
        {
            try
            {
                await _emailSender.SendRegistrationApprovedEmail(email, workshopName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (request.StudentId != null)
            {
                var workshop = await _db.WorkShops
                    .Where(w => w.Id == request.WorkShopId)
                    .Include(w => w.Students)
                    .FirstOrDefaultAsync();
                var student = await _db.Students
                    .Where(s => s.UserId == request.StudentId)
                    .Include(s => s.Workshops)
                    .FirstOrDefaultAsync();
                if (workshop != null)
                {
                    if (!student.Workshops.Contains(workshop))
                        student.Workshops.Add(workshop);

                    if (!workshop.Students.Contains(student))
                        workshop.Students.Add(student);

                    _db.WorkShops.Update(workshop);
                    _db.Students.Update(student);
                    await _db.SaveChangesAsync();
                }
            }
        }
        else
        {
            try
            {
                await _emailSender.SendRegistrationRejectedEmail(email, workshopName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }



}
