using MediatR;
using Showcase.Application.Common.Interfaces;
using Showcase.Domain.Enums;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Projects.Commands.CreateNewProject
{
    public class CreateNewProjectCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<EPRogrammingLanguage> Languages { get; set; }
        public string ThumbnailFileId { get; set; }
        public string ProjectRepositoryLink { get; set; }
        public string HostedAppLink { get; set; }

        public class Handler : IRequestHandler<CreateNewProjectCommand>
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

            public async Task<Unit> Handle(CreateNewProjectCommand request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
