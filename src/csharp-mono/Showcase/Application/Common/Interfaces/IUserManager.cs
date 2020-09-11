using Showcase.Application.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Showcase.Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string name, string email, string password, string givenName = null, string familyName = null, string nickName = null, string username = null, Dictionary<string, object> userMetadata = null, Dictionary<string, object> appMetadata = null);
        Task<(Result Result, ShowcaseUser User)> GetUserAsync(string userId);
        Task<(Result Result, ShowcaseUser User)> EditUserAsync(string userId, string userName = null, string givenName = null, string familyName = null, string nickName = null, string name = null, Dictionary<string, object> userMetadata = null, Dictionary<string, object> appMetadata = null, bool blocked = false);
        Task<(Result Result, ShowcaseUser User)> VerifyEmail(string userId);
        Task<(Result Result, ShowcaseUser User)> SendVerificationEmail(string userId);
        /* Uses Auth0 Authentication API to send password reset email to the user
         */
        Task<(Result Result, ShowcaseUser User)> ResetPasswordAsync(string email);
        Task<Result> DeleteUserAsync(string userId);
    }
}
