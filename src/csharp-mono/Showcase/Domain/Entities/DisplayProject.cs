using Showcase.Domain.Common;
using System.Collections.Generic;

namespace Showcase.Domain.Entities
{
    public class DisplayProject : AuditableEntity
    {
        public DisplayProject()
        {
            Notes = new HashSet<ActivityNote>();
            Watchers = new HashSet<ProjectWatcher>();
            Tags = new HashSet<ProjectTag>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string SourceCodeUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public ICollection<ActivityNote> Notes { get; private set; }
        public ICollection<ProjectWatcher> Watchers { get; private set; }
        public ICollection<ProjectTag> Tags { get; private set; }
    }
}
