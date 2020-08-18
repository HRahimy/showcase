namespace Showcase.Domain.Entities
{
    public class BlogPostWatcher
    {
        // WatcherId is the Auth0 user id
        public string WatcherId { get; set; }
        public string BlogPostId { get; set; }
        public bool Cancelled { get; set; }

        public ShowcaseProfile Watcher { get; set; }
        public BlogPost BlogPost { get; set; }
    }
}
