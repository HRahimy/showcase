using Auth0.ManagementApi.Models;
using AutoMapper;
using Showcase.Application.Common.Mappings;
using System;
using System.Collections.Generic;

namespace Showcase.Application.Common.Models
{
    public class ShowcaseUser : IMapFrom<User>
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public bool? EmailVerified { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public bool? PhoneVerified { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public virtual List<UserIdentity> UserIdentities { get; set; }
        public Dictionary<string, object> UserMetadata { get; set; }
        public Dictionary<string, object> AppMetadata { get; set; }
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string[] MultiFactor { get; set; }
        public string? LastIp { get; set; }
        public DateTime? LastLogin { get; set; }
        public string? LoginsCount { get; set; }
        public bool? Blocked { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, ShowcaseUser>()
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.UserId))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(d => d.EmailVerified, opt => opt.MapFrom(s => s.EmailVerified))
                .ForMember(d => d.Username, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber))
                .ForMember(d => d.PhoneVerified, opt => opt.MapFrom(s => s.PhoneVerified))
                .ForMember(d => d.CreatedAt, opt => opt.MapFrom(s => s.CreatedAt))
                .ForMember(d => d.UpdatedAt, opt => opt.MapFrom(s => s.UpdatedAt))
                .ForMember(d => d.UserMetadata, opt => opt.MapFrom(s => s.UserMetadata))
                .ForMember(d => d.AppMetadata, opt => opt.MapFrom(s => s.AppMetadata))
                .ForMember(d => d.Picture, opt => opt.MapFrom(s => s.Picture))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.FullName))
                .ForMember(d => d.Nickname, opt => opt.MapFrom(s => s.NickName))
                .ForMember(d => d.MultiFactor, opt => opt.MapFrom(s => s.Multifactor))
                .ForMember(d => d.LastIp, opt => opt.MapFrom(s => s.LastIpAddress))
                .ForMember(d => d.LastLogin, opt => opt.MapFrom(s => s.LastLogin))
                .ForMember(d => d.LoginsCount, opt => opt.MapFrom(s => s.LoginsCount))
                .ForMember(d => d.Blocked, opt => opt.MapFrom(s => s.Blocked))
                .ForMember(d => d.GivenName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.FamilyName, opt => opt.MapFrom(s => s.LastName));
        }
    }

    public class UserIdentity : IMapFrom<Identity>
    {
        public string Connection { get; set; }
        public string UserId { get; set; }
        public string Provider { get; set; }
        public bool? IsSocial { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Identity, UserIdentity>()
                .ForMember(d => d.Connection, opt => opt.MapFrom(s => s.Connection))
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.UserId))
                .ForMember(d => d.Provider, opt => opt.MapFrom(s => s.Provider))
                .ForMember(d => d.IsSocial, opt => opt.MapFrom(s => s.IsSocial));
        }
    }
}
