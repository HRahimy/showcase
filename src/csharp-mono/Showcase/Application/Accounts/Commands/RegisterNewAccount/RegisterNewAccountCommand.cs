using MediatR;
using Showcase.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Accounts.Commands.RegisterNewAccount
{
    /*
     * Detects the current user through the currentUserService
     * Creates new UserProfile record for the database.
     * Assigns id value from currentUserService to Id field of new UserProfile record
     * Updates the given profile data from the request to the new UserProfile record
     * Pushes new UserProfile record to database
     * Calls userManager service to update the showcase_profile_created field in the app_metadata of the user
     */
    public class RegisterNewAccountCommand : IRequest
    {
        public string PublicProfileUsername { get; set; }
        public string PublicProfileDescription { get; set; }
        public string ThumbnailFileId { get; set; }

        public class Handler : IRequestHandler<RegisterNewAccountCommand>
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
            public async Task<Unit> Handle(RegisterNewAccountCommand request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
