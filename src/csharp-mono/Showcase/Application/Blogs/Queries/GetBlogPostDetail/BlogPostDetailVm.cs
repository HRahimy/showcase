using System.Collections.Generic;

namespace Showcase.Application.Blogs.Queries.GetBlogPostDetail
{
    public class BlogPostDetailVm
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ContentString { get; set; }
        public virtual List<TagDto> Tags { get; set; }
    }
}
