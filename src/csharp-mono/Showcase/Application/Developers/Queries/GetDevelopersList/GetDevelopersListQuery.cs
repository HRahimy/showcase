using MediatR;

namespace Showcase.Application.Developers.Queries.GetDevelopersList
{
    public class GetDevelopersListQuery : IRequest<DevelopersListVm>
    {
    }
}
