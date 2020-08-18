using System.Collections.Generic;

namespace Showcase.Domain.Entities
{
    public class ShowcaseProfile
    {
        public ShowcaseProfile()
        {
            Watchers = new HashSet<ProfileWatcher>();
            Languages = new HashSet<ProgrammingLanguage>();
            Tags = new HashSet<ProfileTag>();
            Notes = new HashSet<ActivityNote>();
        }
        public string ProfileId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ProfileWatcher> Watchers { get; private set; }
        public ICollection<ProgrammingLanguage> Languages { get; private set; }
        public ICollection<ProfileTag> Tags { get; private set; }
        public ICollection<ActivityNote> Notes { get; private set; }
    }
}
