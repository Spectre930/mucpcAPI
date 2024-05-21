using AutoMapper;
using mucpc.Application.Instructors.Dtos;
using mucpc.Application.Workshops.Dtos;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;


namespace mucpc.Application.Instructors;

internal class InstructorsService(IInstructorRepository _instructorRepository, IMapper _mapper) : IInstructorsService
{
    public async Task<IEnumerable<InstructorDto>> GetAll()
    {
        var instructors = await _instructorRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<InstructorDto>>(instructors);
    }

    public async Task<InstructorDto> GetById(long id)
    {
        var instructor = await _instructorRepository.GetFirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("instructor not found!");

        return _mapper.Map<InstructorDto>(instructor);
    }

    public async Task AddInstructor(CreateInstructorDto dto)
    {
        try
        {
            var instructor = _mapper.Map<Instructor>(dto);
            await _instructorRepository.AddInstructor(instructor);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task DeleteInstructor(long id)
    {
        try
        {

            await _instructorRepository.DeleteInstructor(id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    public async Task<double?> GetInstructorRatingInAWorkShop(long WorkShopId)
    {
        try
        {

            return await _instructorRepository.GetInstructorRatingInAWorkShop(WorkShopId);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<double?> GetOverAllInstructorRating(long InstructorId)
    {
        try
        {

            return await _instructorRepository.GetOverAllInstructorRating(InstructorId);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<WorkshopDto>> GetWorkShops(long InstructorId)
    {
        try
        {
            var workshops = await _instructorRepository.GetWorkShops(InstructorId);
            return _mapper.Map<IEnumerable<WorkshopDto>>(workshops);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task UpdateInstructor(InstructorDto instructor)
    {
        try
        {
            var obj = _mapper.Map<Instructor>(instructor);
            await _instructorRepository.UpdateInstructor(obj);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
