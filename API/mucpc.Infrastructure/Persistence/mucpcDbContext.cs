using Microsoft.EntityFrameworkCore;
using mucpc.Domain.Entities;



namespace MUCPC.Infrastructure.Persistence;

internal class mucpcDbContext(DbContextOptions<mucpcDbContext> options) : DbContext(options)
{
    internal DbSet<AppUser> AppUsers { get; set; }
    internal DbSet<Instructor> Instructors { get; set; }
    internal DbSet<RegisterRequest> RegisterRequests { get; set; }
    internal DbSet<Student> Students { get; set; }
    internal DbSet<WorkShop> WorkShops { get; set; }
    internal DbSet<Role> Roles { get; set; }
    internal DbSet<Form> Forms { get; set; }
    internal DbSet<FormQuestion> FormQuestions { get; set; }
    internal DbSet<QuestionResponse> QuestionsResponses { get; set; }
    internal DbSet<FormResponse> FormResponses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QuestionResponse>().HasKey(se => new { se.FormQuestionId, se.FormResponseId });

        modelBuilder.Entity<QuestionResponse>()
        .HasOne(qr => qr.FormQuestion)
        .WithMany(fq => fq.QuestionResponses)
        .HasForeignKey(qr => qr.FormQuestionId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<QuestionResponse>()
            .HasOne(qr => qr.FormResponse)
            .WithMany(fr => fr.QuestionsResponses)
            .HasForeignKey(qr => qr.FormResponseId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Instructor>()
             .HasIndex(c => c.Email)
             .IsUnique();

        modelBuilder.Entity<AppUser>()
             .HasIndex(c => c.Email)
             .IsUnique();

        modelBuilder.Entity<WorkShop>()
          .HasIndex(c => c.Number)
          .IsUnique();

        modelBuilder.Entity<WorkShop>()
    .HasOne(p => p.Instructor)
    .WithMany(b => b.WorkShops)
    .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<RegisterRequest>()
       .HasOne(r => r.WorkShop)
       .WithMany(w => w.RegisterRequests)
       .HasForeignKey(r => r.WorkShopId)
       .OnDelete(DeleteBehavior.NoAction);
    }


}
