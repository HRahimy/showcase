using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Showcase.Application.Common.Exceptions;
using Showcase.Application.Common.Interfaces;
using Showcase.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Developers.Queries.GetProfileDetail
{
    public class GetProfileDetailQueryHandler : IRequestHandler<GetProfileDetailQuery, DeveloperProfileDto>
    {
        private readonly IShowcaseDbContext _context;
        private readonly IMapper _mapper;

        public GetProfileDetailQueryHandler(IShowcaseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<DeveloperProfileDto> Handle(GetProfileDetailQuery request, CancellationToken cancellationToken)
        {
            var vm = await _context.Developers
                .Where(e => e.ProfileId == request.ProfileId)
                .ProjectTo<DeveloperProfileDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);

            if (vm == null)
                throw new NotFoundException(nameof(ShowcaseProfile), request.ProfileId);

            return vm;
        }
    }
}
