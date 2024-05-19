
using MediatR;
using mucpc.Application.Forms.Dtos;

namespace mucpc.Application.Forms.Queries.GetAllForms;

public class GetAllFormsQuery : IRequest<IEnumerable<FormVm>>
{
}

