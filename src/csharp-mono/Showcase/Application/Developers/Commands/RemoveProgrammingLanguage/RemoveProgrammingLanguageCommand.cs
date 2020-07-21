using MediatR;
using Showcase.Application.Common.Interfaces;
using Showcase.Domain.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Developers.Commands.RemoveProgrammingLanguage
{
    public class RemoveProgrammingLanguageCommand : IRequest
    {
        public string DeveloperId { get; set; }
        public EPRogrammingLanguage Language { get; set; }

        public class Handler : IRequestHandler<RemoveProgrammingLanguageCommand>
        {
            private readonly IShowcaseDbContext _context;
            private readonly IMediator _mediator;
            private readonly ICurrentUserService _currentUserService;

            public Handler(IShowcaseDbContext context, IMediator mediator, ICurrentUserService currentUserService)
            {
                _context = context;
                _mediator = mediator;
                _currentUserService = currentUserService;
            }

            public async Task<Unit> Handle(RemoveProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                return Unit.Value;
            }
        }
    }
}
