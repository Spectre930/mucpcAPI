using AutoMapper;
using MediatR;
using mucpc.Application.Forms.Dtos;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Workshops.Queries.GetRegistrationForm;

public class GetRegistrationFormQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetRegistrationFormQuery, FormDto>
{
    public async Task<FormDto> Handle(GetRegistrationFormQuery request, CancellationToken cancellationToken)
    {
        var regForm = await unitOfWork.Forms.GetFirstOrDefaultAsync(x => x.WorkShopId == request.workshopId && x.RegistrationForm) ?? throw new Exception("No Registration Form Found!");
        return mapper.Map<FormDto>(regForm);
    }
}
