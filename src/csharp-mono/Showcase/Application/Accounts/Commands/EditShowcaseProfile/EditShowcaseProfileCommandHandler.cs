using MediatR;
using Showcase.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Accounts.Commands.EditShowcaseProfile
{
    public class EditShowcaseProfileCommandHandler : IRequestHandler<EditShowcaseProfileCommand>
    {
        private readonly IShowcaseDbContext _context;
        private readonly IMediator _mediator;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserManager _userManager;

        public EditShowcaseProfileCommandHandler(IShowcaseDbContext context, IMediator mediator, ICurrentUserService currentUserService, IUserManager userManager)
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
