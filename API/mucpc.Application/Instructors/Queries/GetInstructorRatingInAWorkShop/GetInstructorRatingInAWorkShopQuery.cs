using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mucpc.Application.Instructors.Queries.GetInstructorRatingInAWorkShop;

public class GetInstructorRatingInAWorkShopQuery(long workshopId) : IRequest<double?>
{
    public long WorkshopId { get; set; } = workshopId;
}
