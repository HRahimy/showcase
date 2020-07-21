using MediatR;
using Showcase.Application.Projects.Models;

namespace Showcase.Application.Projects.Queries.GetDeveloperProjects
{
    public class GetDeveloperProjectsQuery : IRequest<ProjectsListVm>
    {
        public string DeveloperUserId { get; set; }
        public int Page { get; set; } = 1;
    }
}
