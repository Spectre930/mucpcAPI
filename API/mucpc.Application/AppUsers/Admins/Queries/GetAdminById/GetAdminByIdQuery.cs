using MediatR;
using mucpc.Application.AppUsers.Dtos;


namespace mucpc.Application.AppUsers.Admins.Queries.GetAdminById;

public class GetAdminByIdQuery(long id) : IRequest<AppUserDto>
{
    public long Id { get; set; } = id;
}
