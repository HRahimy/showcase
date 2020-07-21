using MediatR;
using Showcase.Application.Activities.Models;

namespace Showcase.Application.Activities.Queries.GetProjectActivitiesList
{
    public class GetProjectActivitiesListQuery : IRequest<ActivitiesListVm>
    {
        public string ProjectId { get; set; }
        public int Page { get; set; } = 1;
    }
}
