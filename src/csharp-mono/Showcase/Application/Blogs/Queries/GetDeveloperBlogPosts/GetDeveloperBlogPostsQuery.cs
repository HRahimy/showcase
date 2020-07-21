using MediatR;
using Showcase.Application.Blogs.Models;

namespace Showcase.Application.Blogs.Queries.GetDeveloperBlogPosts
{
    public class GetDeveloperBlogPostsQuery : IRequest<BlogPostsListVm>
    {
        public string DeveloperUserId { get; set; }
        public int Page { get; set; } = 1;
    }
}
