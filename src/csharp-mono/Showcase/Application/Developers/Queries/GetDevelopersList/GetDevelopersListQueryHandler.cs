using AutoMapper;
using MediatR;
using Showcase.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Developers.Queries.GetDevelopersList
{
    public class GetDevelopersListQueryHandler : IRequestHandler<GetDevelopersListQuery, DevelopersListVm>
    {
        private readonly IShowcaseDbContext _context;
        private readonly IMapper _mapper;

        public GetDevelopersListQueryHandler(IShowcaseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<DevelopersListVm> Handle(GetDevelopersListQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
