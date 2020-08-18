using Showcase.Domain.Enums;

namespace Showcase.Domain.Entities
{
    public class ActivityNote
    {
        public string NoteId { get; set; }
        public EActivityType ActivityType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string NoteText { get; set; }

        // Only used if Activity is related to a profile
        public string ShowcaseProfileId { get; set; }
        public ShowcaseProfile ShowcaseProfile { get; set; }

        // Only used if Activity is related to a blog post
        public string BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }

        // Only used if Activity is related to a Display Project
        public string ProjectId { get; set; }
        public DisplayProject Project { get; set; }
    }
}
