using AutoMapper;
using MediatR;
using Showcase.Application.Common.Interfaces;
using Showcase.Application.Projects.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Projects.Queries.GetDeveloperProjects
{
    public class GetDeveloperProjectsQueryHandler : IRequestHandler<GetDeveloperProjectsQuery, ProjectsListVm>
    {
        private readonly IShowcaseDbContext _context;
        private readonly IMapper _mapper;

        public GetDeveloperProjectsQueryHandler(IShowcaseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProjectsListVm> Handle(GetDeveloperProjectsQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
