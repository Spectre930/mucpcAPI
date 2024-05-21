using MediatR;

namespace mucpc.Application.Instructors.Queries.GetOverAllInstructorRating;

public class GetOverAllInstructorRatingQuery(long id) : IRequest<double?>
{
    public long Id { get; set; } = id;
}
