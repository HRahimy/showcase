namespace Showcase.Domain.Entities
{
    public class ProjectWatcher
    {
        public string WatcherId { get; set; }
        public string DisplayProjectId { get; set; }
        public bool Cancelled { get; set; }

        public ShowcaseProfile Watcher { get; set; }
        public DisplayProject DisplayProject { get; set; }
    }
}
