
using AutoMapper;
using mucpc.Application.AppUsers.Dtos;
using mucpc.Application.Roles;
using mucpc.Application.Students.Dtos;
using mucpc.Application.Workshops.Dtos;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;

namespace mucpc.Application.Students;

internal class StudnetsService(IStudentRepository _studentRepository,
    IAppUserRepository _userRepository,
    IRoleRepository _rolesRepository,
    IMapper _mapper) : IStudnetsService
{
    public async Task<IEnumerable<StudentDto>> GetAll()
    {
        var students = await _studentRepository.GetAllAsync(["User"]);
        return _mapper.Map<IEnumerable<StudentDto>>(students);
    }
    public async Task<StudentDto> GetById(long id)
    {
        var student = await _studentRepository.GetById(id);
        return _mapper.Map<StudentDto>(student);
    }
    public async Task AddStudent(CreateStudentDto dto)
    {
        dto.user.RoleId = _rolesRepository.GetFirstOrDefaultAsync(r => r.RoleName == "Student").Id;

        var student = _mapper.Map<Student>(dto);

        await _userRepository.AddUser(student.User);

        student.UserId = _userRepository.GetFirstOrDefaultAsync(u => u.Email == dto.user.Email).Id;

        await _studentRepository.AddStudent(student);
    }
    public async Task UpdateStudent(StudentDto student)
    {
        var obj = _mapper.Map<Student>(student);

        await _userRepository.UpdateUser(obj.User);

        await _studentRepository.UpdateStudent(obj);
    }

    public async Task DeleteStudent(long id)
    {
        var student = await GetById(id);
        var obj = _mapper.Map<Student>(student);
        _studentRepository.Remove(obj);
    }

    public async Task<IEnumerable<WorkshopDto>> GetWorkshops(long studentId)
    {
        var workshops = _studentRepository.GetWorkshops(studentId);
        return _mapper.Map<IEnumerable<WorkshopDto>>(workshops);
    }

}
