using MediatR;
using mucpc.Application.Forms.Dtos;

namespace mucpc.Application.Workshops.Queries.GetRegistrationForm;

public class GetRegistrationFormQuery(long id) : IRequest<FormDto>
{
    public long workshopId { get; set; } = id;
}
