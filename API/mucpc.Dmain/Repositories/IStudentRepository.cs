using mucpc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mucpc.Dmain.Repositories;

public interface IStudentRepository : IRepository<Student>
{
    Task<Student> GetById(long id);
    Task DeleteStudent(long id);
    Task AddStudent(Student dto);
    Task UpdateStudent(Student student);
    Task<IEnumerable<WorkShop>> GetWorkshops(long studentId);
}
