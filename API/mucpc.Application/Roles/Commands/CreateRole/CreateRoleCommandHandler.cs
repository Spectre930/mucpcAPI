//using AutoMapper;
//using MediatR;
//using mucpc.Dmain.Repositories;
//using mucpc.Domain.Entities;

//namespace mucpc.Application.Roles.Commands.CreateRole;

//public class CreateRoleCommandHandler(IRoleRepository _roleRepository,
//    IMapper _mapper) : IRequestHandler<CreateRoleCommand, int>
//{
//    public async Task<int > Handle(CreateRoleCommand request, CancellationToken cancellationToken)
//    {
//        var role = _mapper.Map<Role>(request);
//        await _roleRepository.AddRole(role);
//        return role.Id;
//    }
//}
