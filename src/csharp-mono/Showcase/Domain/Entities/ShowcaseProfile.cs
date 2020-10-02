using Showcase.Domain.Common;
using System.Collections.Generic;

namespace Showcase.Domain.Entities
{
    public class ShowcaseProfile : AuditableEntity
    {
        public ShowcaseProfile()
        {
            Watchers = new HashSet<ProfileWatcher>();
            WatchingProfiles = new HashSet<ProfileWatcher>();
            WatchingBlogPosts = new HashSet<BlogPostWatcher>();
            WatchingProjects = new HashSet<ProjectWatcher>();
            Tags = new HashSet<ProfileTag>();
            Notes = new HashSet<ActivityNote>();
        }
        public string ProfileId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProfilePictureId { get; set; }
        public ICollection<ProfileWatcher> Watchers { get; private set; }
        public ICollection<ProfileWatcher> WatchingProfiles { get; private set; }
        public ICollection<BlogPostWatcher> WatchingBlogPosts { get; private set; }
        public ICollection<ProjectWatcher> WatchingProjects { get; private set; }
        public ICollection<ProfileTag> Tags { get; private set; }
        public ICollection<ActivityNote> Notes { get; private set; }
        public BucketFile ProfilePicture { get; set; }
    }
}
