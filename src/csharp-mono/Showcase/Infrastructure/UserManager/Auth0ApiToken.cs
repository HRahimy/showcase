namespace Showcase.Infrastructure.UserManager
{
    public class Auth0ApiToken
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public string Scope { get; set; }
        public int ExpiresIn { get; set; }
    }
}
