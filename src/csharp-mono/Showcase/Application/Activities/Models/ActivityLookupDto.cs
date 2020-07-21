using Showcase.Domain.Enums;

namespace Showcase.Application.Activities.Models
{
    public class ActivityLookupDto
    {
        public string ByUserWithName { get; set; }
        public string ByUserWithId { get; set; }
        public EActivityType ActivityType { get; set; }
        public string ActivitySubjectId { get; set; } // Primary key of the object that the activity was about
        public string Message { get; set; }
    }
}
