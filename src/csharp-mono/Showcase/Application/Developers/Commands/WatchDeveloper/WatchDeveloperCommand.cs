using MediatR;
using Showcase.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Developers.Commands.WatchDeveloper
{
    public class WatchDeveloperCommand : IRequest
    {
        public string DeveloperId { get; set; }

        public class Handler : IRequestHandler<WatchDeveloperCommand>
        {
            private readonly IShowcaseDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IShowcaseDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(WatchDeveloperCommand request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
