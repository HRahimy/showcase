using System;
using System.Collections.Generic;

namespace Showcase.Application.Common.Models
{
    public class Auth0User
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneVerified { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<UserIdentity> UserIdentities { get; set; }
        public Dictionary<string, object> UserMetadata { get; set; }
        public Dictionary<string, object> AppMetadata { get; set; }
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public List<string> MultiFactor { get; set; }
        public string LastIp { get; set; }
        public string LastLogin { get; set; }
        public int LoginsCount { get; set; }
        public bool Blocked { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
    }

    public class UserIdentity
    {
        public string Connection { get; set; }
        public string UserId { get; set; }
        public string Provider { get; set; }
        public bool IsSocial { get; set; }
    }
}
