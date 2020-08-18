namespace Showcase.Domain.Entities
{
    public class BlogPostTag
    {
        public string BlogPostId { get; set; }
        public string TagId { get; set; }

        public BlogPost BlogPost { get; set; }
        public Tag Tag { get; set; }
    }
}
