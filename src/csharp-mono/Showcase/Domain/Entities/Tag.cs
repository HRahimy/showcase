using Showcase.Domain.Enums;
using System.Collections.Generic;

namespace Showcase.Domain.Entities
{
    public class Tag
    {
        public Tag()
        {
            BlogPostTags = new HashSet<BlogPostTag>();
            ProjectTags = new HashSet<ProjectTag>();
            ProfileTags = new HashSet<ProfileTag>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public ETagType Type { get; set; }

        // Value for this property must be null unless Type is set to ProgrammingLanguage in which case value must be provided
        public EPRogrammingLanguage ProgrammingLanguageTag { get; set; }

        public ICollection<BlogPostTag> BlogPostTags { get; private set; }
        public ICollection<ProjectTag> ProjectTags { get; private set; }
        public ICollection<ProfileTag> ProfileTags { get; private set; }
    }
}
