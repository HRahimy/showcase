using AutoMapper;
using MediatR;
using Showcase.Application.Common.Interfaces;
using Showcase.Application.Projects.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Projects.Queries.GetProjectDetail
{
    public class GetProjectDetailQueryHandler : IRequestHandler<GetProjectDetailQuery, ProjectDetailVm>
    {
        private readonly IShowcaseDbContext _context;
        private readonly IMapper _mapper;

        public GetProjectDetailQueryHandler(IShowcaseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        Task<ProjectDetailVm> IRequestHandler<GetProjectDetailQuery, ProjectDetailVm>.Handle(GetProjectDetailQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
