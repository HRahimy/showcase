using AutoMapper;
using Showcase.Application.Common.Mappings;
using Showcase.Domain.Entities;

namespace Showcase.Application.Developers.Queries.GetDevelopersList
{
    public class DeveloperLookupDto : IMapFrom<Developer>
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Developer, DeveloperLookupDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.DeveloperId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
        }
    }
}
