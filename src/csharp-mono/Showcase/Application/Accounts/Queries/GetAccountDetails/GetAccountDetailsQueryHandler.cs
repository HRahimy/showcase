using AutoMapper;
using MediatR;
using Showcase.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Accounts.Queries.GetAccountDetails
{
    public class GetAccountDetailsQueryHandler : IRequestHandler<GetAccountDetailsQuery, AccountDetailsVm>
    {
        private readonly IShowcaseDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserManager _userManager;

        public GetAccountDetailsQueryHandler(IShowcaseDbContext context, IMapper mapper, ICurrentUserService currentUserService, IUserManager userManager)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _userManager = userManager;
        }

        public async Task<AccountDetailsVm> Handle(GetAccountDetailsQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
