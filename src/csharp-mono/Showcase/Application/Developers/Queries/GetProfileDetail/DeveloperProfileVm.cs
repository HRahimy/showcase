using System.Collections.Generic;

namespace Showcase.Application.Developers.Queries.GetProfileDetail
{
    public class DeveloperProfileVm
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
        public virtual List<TagDto> Tags { get; set; }
    }
}
