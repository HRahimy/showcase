namespace Showcase.Domain.Entities
{
    public class ProjectTag
    {
        public string DisplayProjectId { get; set; }
        public string TagId { get; set; }

        public DisplayProject DisplayProject { get; set; }
        public Tag Tag { get; set; }
    }
}
