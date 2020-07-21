namespace Showcase.Domain.Entities
{
    public class Watcher
    {
        // WatcherId is the Auth0 user id
        public string WatcherId { get; set; }
        public string DeveloperId { get; set; }
        public bool Cancelled { get; set; }
    }
}
