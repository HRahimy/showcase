using AutoMapper;
using Showcase.Application.Common.Mappings;
using Showcase.Domain.Entities;

namespace Showcase.Application.Developers.Queries.GetProfileDetail
{
    public class DeveloperProfileDto : IMapFrom<ShowcaseProfile>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        // public string ThumbnailUrl { get; set; }
        // public virtual List<TagDto> Tags { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ShowcaseProfile, DeveloperProfileDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ProfileId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Username, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description));
        }
    }
}
