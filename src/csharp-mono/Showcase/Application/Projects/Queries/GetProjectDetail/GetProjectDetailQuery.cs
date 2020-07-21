using MediatR;

namespace Showcase.Application.Projects.Queries.GetProjectDetail
{
    public class GetProjectDetailQuery : IRequest<ProjectDetailVm>
    {
        public string ProjectId { get; set; }
    }
}
