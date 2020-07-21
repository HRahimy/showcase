using MediatR;
using Showcase.Application.Common.Interfaces;
using Showcase.Application.Projects.Commands.CreateNewProject;
using Showcase.Domain.Enums;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Projects.Commands.EditProject
{
    public class EditProjectCommand : IRequest
    {
        public string ProjectId { get; set; }
        public string NewName { get; set; }
        public string NewDescription { get; set; }
        public string NewThumbnailFileId { get; set; }
        public List<EPRogrammingLanguage> NewProgrammingLanguages { get; set; }
        public string NewRepositoryLink { get; set; }
        public string NewHostedAppLink { get; set; }

        public class Handler : IRequestHandler<EditProjectCommand>
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

            public async Task<Unit> Handle(EditProjectCommand request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
