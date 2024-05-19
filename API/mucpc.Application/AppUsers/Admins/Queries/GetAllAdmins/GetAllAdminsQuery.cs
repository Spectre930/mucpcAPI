using MediatR;
using mucpc.Application.AppUsers.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mucpc.Application.AppUsers.Admins.Queries.GetAllAdmins;

public class GetAllAdminsQuery : IRequest<IEnumerable<AppUserDto>>
{
}
