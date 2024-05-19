using mucpc.Application.Forms.FormResponses.Dtos;

namespace mucpc.Application.Workshops.RegisterRequests.Dtos;

public class CreateRegisterRequestDto
{
    public long? StudentId { get; set; }
    public CreateFormResponseCommand FormResponse { get; set; }
}
