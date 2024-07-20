using MediatR;

namespace mucpc.Application.Workshops.Commands.UpdateWorkShop;

public class UpdateWorkShopCommand : IRequest
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public int? NumberOfHours { get; set; }
    public string? TargetedFaculties { get; set; }
    public int? Price { get; set; }
    public string? Duration { get; set; }
    public string? Objectives { get; set; }
    public string? DeliveryType { get; set; }
    public DateTime DateAndTime { get; set; }
    public string? Speaker { get; set; }
    public string? OrganizedBy { get; set; }
    public string? RegistrationLink { get; set; }
    public int? MaxNumberOfAttendees { get; set; }
    public double? Rating { get; set; }
    public long? InstructorId { get; set; }
}
