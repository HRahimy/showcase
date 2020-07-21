using AutoMapper;
using MediatR;
using Showcase.Application.Blogs.Models;
using Showcase.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Blogs.Queries.GetDeveloperBlogPosts
{
    public class GetDeveloperBlogPostsQueryHandler : IRequestHandler<GetDeveloperBlogPostsQuery, BlogPostsListVm>
    {
        private readonly IShowcaseDbContext _context;
        private readonly IMapper _mapper;

        public GetDeveloperBlogPostsQueryHandler(IShowcaseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BlogPostsListVm> Handle(GetDeveloperBlogPostsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
