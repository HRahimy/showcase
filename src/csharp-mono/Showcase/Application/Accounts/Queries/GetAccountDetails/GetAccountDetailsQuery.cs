using MediatR;

namespace Showcase.Application.Accounts.Queries.GetAccountDetails
{
    public class GetAccountDetailsQuery : IRequest<AccountDetailsVm>
    {
    }
}
