using mucpc.Application.Forms.FormResponses.Dtos;
using mucpc.Application.Students.Dtos;
using mucpc.Application.Workshops.Dtos;

namespace mucpc.Application.Workshops.RegisterRequests.Dtos;

public class RegisterRequestDto
{
    public long Id { get; set; }
    public DateTime RequestDateTime { get; set; }
    public long? StudentId { get; set; }
    public StudentDto? Student { get; set; }
    public long FormResponseId { get; set; }
    public FormResponseDto FormResponse { get; set; }
    public bool isAccepted { get; set; } = false;
    public string? Status { get; set; }
    public long WorkShopId { get; set; }
    public WorkshopDto WorkShop { get; set; }
}
