using AutoMapper;
using MediatR;
using mucpc.Application.AppUsers.Dtos;
using mucpc.Dmain.Repositories;


namespace mucpc.Application.AppUsers.Admins.Queries.GetAdminById;

public class GetAdminByIdQueryHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetAdminByIdQuery, AppUserDto>
{
    public async Task<AppUserDto> Handle(GetAdminByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.AppUsers.GetFirstOrDefaultAsync(x => x.Id == request.Id, ["Role"]) ?? throw new Exception("admin not found!");
        return _mapper.Map<AppUserDto>(user);
    }
}
