using Microsoft.Extensions.Options;
using Showcase.Application.Common.Interfaces;
using Showcase.Application.Common.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using AutoMapper;

namespace Showcase.Infrastructure.UserManager
{
    public class UserManagerService : IUserManager
    {
        public UserManagerService(IOptions<Auth0ManagementClientOptions> optionsAccessor, IMapper mapper)
        {
            Options = optionsAccessor.Value;
            _mapper = mapper;
            RenewAccessToken();
        }

        public Auth0ManagementClientOptions Options { get; }

        private readonly IMapper _mapper;
        private Auth0ApiToken apiToken;
        private DateTime tokenExpiresOn;

        private void RenewAccessToken()
        {
            var restClient = new RestClient($"https://{Options.Auth0TenantDomain}/oauth/token");
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("content-type", "application/x-ww-form-urlencoded");
            restRequest.AddParameter("application/x-www-form-urlencoded", $"grant_type=client_credentials&client_id={Options.Auth0ManagementClientId}&client_secret={Options.Auth0ManagementClientSecret}&audience={Options.Auth0ManagementClientAudience}", ParameterType.RequestBody);
            var response = restClient.Execute<Auth0ApiToken>(restRequest);

            if (response.StatusCode != HttpStatusCode.OK) throw new Exception($"Could not get API token. Error: ({response.ErrorMessage})");
            apiToken = response.Data;
            var tokenCreatedOn = DateTime.Now;
            tokenExpiresOn = tokenCreatedOn.AddSeconds(apiToken.ExpiresIn);
        }

        public Task<(Result Result, string UserId)> CreateUserAsync(string name, string email, string password, string givenName = null, string familyName = null, string nickName = null, string username = null, Dictionary<string, object> userMetadata = null, Dictionary<string, object> appMetadata = null)
        {
            if (tokenExpiresOn <= DateTime.Now)
                RenewAccessToken();
            throw new System.NotImplementedException();
        }

        public Task<Result> DeleteUserAsync(string userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<(Result Result, ShowcaseUser User)> EditUserAsync(string userId, string userName = null, string givenName = null, string familyName = null, string nickName = null, string name = null, Dictionary<string, object> userMetadata = null, Dictionary<string, object> appMetadata = null, bool blocked = false)
        {
            try
            {
                if (tokenExpiresOn <= DateTime.Now)
                    RenewAccessToken();

                var managementClient = new ManagementApiClient(apiToken.AccessToken, Options.Auth0TenantDomain);

                var editedUser = await managementClient.Users.UpdateAsync(userId, new UserUpdateRequest
                {
                    UserName = userName,
                    FirstName = givenName,
                    LastName = familyName,
                    NickName = nickName,
                    FullName = name,
                    UserMetadata = userMetadata,
                    AppMetadata = appMetadata,
                    Blocked = blocked,
                });

                var toReturnUser = _mapper.Map<ShowcaseUser>(editedUser);

                return (Result.Success(), toReturnUser);

            } catch (Exception ex)
            {
                return (Result.Failure(new List<string>(new string[] { ex.Message })), null);
            }
        }

        public Task<(Result Result, ShowcaseUser User)> GetUserAsync(string userId)
        {
            if (tokenExpiresOn <= DateTime.Now)
                RenewAccessToken();
            throw new System.NotImplementedException();
        }

        public Task<(Result Result, ShowcaseUser User)> ResetPasswordAsync(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<(Result Result, ShowcaseUser User)> SendVerificationEmail(string userId)
        {
            if (tokenExpiresOn <= DateTime.Now)
                RenewAccessToken();
            throw new System.NotImplementedException();
        }

        public Task<(Result Result, ShowcaseUser User)> VerifyEmail(string userId)
        {
            if (tokenExpiresOn <= DateTime.Now)
                RenewAccessToken();
            throw new System.NotImplementedException();
        }
    }
}
