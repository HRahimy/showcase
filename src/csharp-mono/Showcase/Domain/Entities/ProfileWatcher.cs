namespace Showcase.Domain.Entities
{
    public class ProfileWatcher
    {
        // WatcherId is the Auth0 user id
        public string WatcherId { get; set; }
        public string WatcheeId { get; set; }
        public bool Cancelled { get; set; }

        public ShowcaseProfile Watcher { get; set; }
        public ShowcaseProfile Watchee { get; set; }
    }
}
