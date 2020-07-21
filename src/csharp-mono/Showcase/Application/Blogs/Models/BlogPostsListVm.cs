using System.Collections.Generic;

namespace Showcase.Application.Blogs.Models
{
    public class BlogPostsListVm
    {
        public IList<BlogPostLookupDto> Posts { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
