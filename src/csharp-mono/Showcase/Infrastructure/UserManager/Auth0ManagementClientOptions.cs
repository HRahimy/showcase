namespace Showcase.Infrastructure.UserManager
{
    public class Auth0ManagementClientOptions
    {
        public string Auth0ManagementClientId { get; set; }
        public string Auth0ManagementClientSecret { get; set; }
        public string Auth0ManagementClientAudience { get; set; }
        public string Auth0TenantDomain { get; set; }
        public string Auth0DatabaseConnectionId { get; set; }
    }
}
