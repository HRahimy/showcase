using AutoMapper;
using MediatR;
using Showcase.Application.Activities.Models;
using Showcase.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Activities.Queries.GetDeveloperActivitiesList
{
    public class GetDeveloperActivitiesListQueryHandler : IRequestHandler<GetDeveloperActivitiesListQuery, ActivitiesListVm>
    {
        private readonly IShowcaseDbContext _context;
        private readonly IMapper _mapper;

        public GetDeveloperActivitiesListQueryHandler(IShowcaseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActivitiesListVm> Handle(GetDeveloperActivitiesListQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
