using System.Collections.Generic;

namespace Showcase.Domain.Entities
{
    public class BlogPost
    {
        public BlogPost()
        {
            Tags = new HashSet<BlogPostTag>();
            Watchers = new HashSet<BlogPostWatcher>();
            Notes = new HashSet<ActivityNote>();
            ProgrammingLanguages = new HashSet<ProgrammingLanguage>();
        }

        public string PostId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string PostContentString { get; set; }
        public string PostContentMdFileId { get; set; }

        public ICollection<BlogPostTag> Tags { get; private set; }
        public ICollection<BlogPostWatcher> Watchers { get; private set; }
        public ICollection<ActivityNote> Notes { get; private set; }
        public ICollection<ProgrammingLanguage> ProgrammingLanguages { get; private set; }

        // TODO: Add bucket file entity reference for PostContentMdFileId once implemented
    }
}
