using MediatR;

namespace Showcase.Application.Developers.Queries.GetProfileDetail
{
    public class GetProfileDetailQuery : IRequest<DeveloperProfileVm>
    {
        public string ProfileId { get; set; }
    }
}
