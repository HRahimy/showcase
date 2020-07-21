using MediatR;

namespace Showcase.Application.Blogs.Queries.GetBlogPostDetail
{
    public class GetBlogPostDetailQuery : IRequest<BlogPostDetailVm>
    {
        public string PostId { get; set; }
    }
}
