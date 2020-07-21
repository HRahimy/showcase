namespace Showcase.Application.Accounts.Queries.GetAccountDetails
{
    // TODO: Add all the relevant fields to this Dto from Auth0's user data structure (see management api) and the Showcase user profiles data structure
    public class AccountDetailsVm
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ProfileUsername { get; set; }
        public string ProfileDescription { get; set; }
    }
}
