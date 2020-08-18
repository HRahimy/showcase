namespace Showcase.Domain.Entities
{
    public class ProfileTag
    {
        public string ShowcaseProfileId { get; set; }
        public string TagId { get; set; }
        public ShowcaseProfile ShowcaseProfile { get; set; }
        public Tag Tag { get; set; }
    }
}
