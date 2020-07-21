using MediatR;
using Showcase.Application.Blogs.Models;

namespace Showcase.Application.Blogs.Queries.GetProjectBlogPosts
{
    public class GetProjectBlogPostsQuery : IRequest<BlogPostsListVm>
    {
        public string ProjectId { get; set; }
        public int Page { get; set; } = 1;
    }
}
