using AutoMapper;
using MediatR;
using Showcase.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Developers.Queries.GetProfileDetail
{
    public class GetProfileDetailQueryHandler : IRequestHandler<GetProfileDetailQuery, DeveloperProfileVm>
    {
        private readonly IShowcaseDbContext _context;
        private readonly IMapper _mapper;

        public GetProfileDetailQueryHandler(IShowcaseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<DeveloperProfileVm> Handle(GetProfileDetailQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
