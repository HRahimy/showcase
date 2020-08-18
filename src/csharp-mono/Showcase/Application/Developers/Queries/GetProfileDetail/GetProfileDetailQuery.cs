using MediatR;

namespace Showcase.Application.Developers.Queries.GetProfileDetail
{
    public class GetProfileDetailQuery : IRequest<DeveloperProfileDto>
    {
        public string ProfileId { get; set; }
    }
}
