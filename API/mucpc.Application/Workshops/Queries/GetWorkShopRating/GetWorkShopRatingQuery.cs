using MediatR;
using System;
namespace mucpc.Application.Workshops.Queries.GetWorkShopRating;

public class GetWorkShopRatingQuery(long id) : IRequest<double?>
{
    public long Id { get; set; } = id;
}
