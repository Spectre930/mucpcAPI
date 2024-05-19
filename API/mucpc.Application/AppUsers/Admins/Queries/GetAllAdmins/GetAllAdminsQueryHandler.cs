using AutoMapper;
using MediatR;
using mucpc.Application.AppUsers.Dtos;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.AppUsers.Admins.Queries.GetAllAdmins;

public class GetAllAdminsQueryHandler(IUnitOfWork _unitOfWork,
    IMapper _mapper) : IRequestHandler<GetAllAdminsQuery, IEnumerable<AppUserDto>>
{
    public async Task<IEnumerable<AppUserDto>> Handle(GetAllAdminsQuery request, CancellationToken cancellationToken)
    {
        var users = await _unitOfWork.AppUsers.GetAllAsync(["Role"]);
        users = users.Where(x => x.Role.RoleName != "Student").ToList();
        return _mapper.Map<IEnumerable<AppUserDto>>(users);
    }
}
