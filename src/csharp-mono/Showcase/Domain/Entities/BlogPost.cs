using Showcase.Domain.Common;
using System.Collections.Generic;

namespace Showcase.Domain.Entities
{
    public class BlogPost : AuditableEntity
    {
        public BlogPost()
        {
            Tags = new HashSet<BlogPostTag>();
            Watchers = new HashSet<BlogPostWatcher>();
            Notes = new HashSet<ActivityNote>();
        }

        public string BlogPostId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string PostContentString { get; set; }
        public string PostContentMdFileId { get; set; }
        public string PostThumbnailFileId { get; set; }

        public ICollection<BlogPostTag> Tags { get; private set; }
        public ICollection<BlogPostWatcher> Watchers { get; private set; }
        public ICollection<ActivityNote> Notes { get; private set; }

        public BucketFile PostContentMdFile { get; set; }
        public BucketFile PostThumbnailFile { get; set; }
    }
}
