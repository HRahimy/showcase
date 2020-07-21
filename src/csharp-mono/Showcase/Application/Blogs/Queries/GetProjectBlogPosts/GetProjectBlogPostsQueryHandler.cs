using AutoMapper;
using MediatR;
using Showcase.Application.Blogs.Models;
using Showcase.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Blogs.Queries.GetProjectBlogPosts
{
    public class GetProjectBlogPostsQueryHandler : IRequestHandler<GetProjectBlogPostsQuery, BlogPostsListVm>
    {
        private readonly IShowcaseDbContext _context;
        private readonly IMapper _mapper;

        public GetProjectBlogPostsQueryHandler(IShowcaseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BlogPostsListVm> Handle(GetProjectBlogPostsQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
