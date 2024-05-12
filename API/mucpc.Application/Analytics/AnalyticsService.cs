using AutoMapper;
using mucpc.Application.Instructors.Dtos;
using mucpc.Application.Workshops.Dtos;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;

namespace mucpc.Application.Analytics;

internal class AnalyticsService(IAnalyticsRepository _analyticsRepository,
    IMapper _mapper) : IAnalyticsService
{
    public async Task<List<int?>> GetAcademicYears()
    {
        return await _analyticsRepository.GetAcademicYears();
    }

    public async Task<InstructorDto> GetHighestRatedInstructor()
    {
        var instructor = await _analyticsRepository.GetHighestRatedInstructor();
        return _mapper.Map<InstructorDto>(instructor);
    }

    public async Task<WorkshopDto> GetHighestRatedWorkshop()
    {
        var workshops = await _analyticsRepository.GetHighestRatedWorkshop();
        return _mapper.Map<WorkshopDto>(workshops);
    }

    public async Task<InstructorDto> GetHighestRatedInstructorInAnAcademicYear(int year)
    {
        var instructor = await _analyticsRepository.GetHighestRatedInstructorInAnAcademicYear(year);
        return _mapper.Map<InstructorDto>(instructor);

    }

    public async Task<WorkshopDto> GetHighestRatedWorkshopInAnAcademicYear(int year)
    {
        var workshop = await _analyticsRepository.GetHighestRatedWorkshopInAnAcademicYear(year);
        return _mapper.Map<WorkshopDto>(workshop);
    }

    public async Task<int> NumberOfInstructors()
    {
        return await _analyticsRepository.NumberOfInstructors();
    }

    public async Task<int> NumberOfStudents()
    {
        return await _analyticsRepository.NumberOfStudents();
    }

    public async Task<int> NumberOfWorkShops()
    {
        return await _analyticsRepository.NumberOfWorkShops();
    }

    public async Task<int> NumberOfWorkShopsInAnAcademicYear(int year)
    {
        return await _analyticsRepository.NumberOfWorkShopsInAnAcademicYear(year);
    }
}
