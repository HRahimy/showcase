using MediatR;
using Showcase.Application.Activities.Models;

namespace Showcase.Application.Activities.Queries.GetDeveloperActivitiesList
{
    public class GetDeveloperActivitiesListQuery : IRequest<ActivitiesListVm>
    {
        public string DeveloperId { get; set; }
        public int Page { get; set; } = 1;
    }
}
