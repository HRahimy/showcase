using MediatR;
using Showcase.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Accounts.Commands.EditShowcaseProfile
{
    public class EditShowcaseProfileCommand : IRequest
    {
        public string UserId { get; set; }
        public string NewProfileUsername { get; set; }
        public string NewProfileDescription { get; set; }
        public string NewThumbnailFileId { get; set; }

        public class Handler : IRequestHandler<EditShowcaseProfileCommand>
        {
            private readonly IShowcaseDbContext _context;
            private readonly IMediator _mediator;
            private readonly ICurrentUserService _currentUserService;
            private readonly IUserManager _userManager;

            public Handler(IShowcaseDbContext context, IMediator mediator, ICurrentUserService currentUserService, IUserManager userManager)
            {
                _context = context;
                _mediator = mediator;
                _currentUserService = currentUserService;
                _userManager = userManager;
            }
            public async Task<Unit> Handle(EditShowcaseProfileCommand request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
