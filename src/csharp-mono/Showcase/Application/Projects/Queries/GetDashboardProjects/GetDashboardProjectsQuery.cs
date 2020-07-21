using MediatR;
using Showcase.Application.Projects.Models;

namespace Showcase.Application.Projects.Queries.GetDashboardProjects
{
    public class GetDashboardProjectsQuery : IRequest<ProjectsListVm>
    {
    }
}
