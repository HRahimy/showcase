using Microsoft.AspNetCore.Http;
using Showcase.Application.Common.Interfaces;
using System.Security.Claims;

namespace Showcase.REST.Portfolio.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            Username = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
            Email = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
            IsAuthenticated = UserId != null;
        }

        public string UserId { get; }

        public string Username { get; }
        public string Email { get; }

        public bool IsAuthenticated { get; }
    }
}
