using AutoMapper;
using MediatR;
using Showcase.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Blogs.Queries.GetBlogPostDetail
{
    public class GetBlogPostDetailQueryHandler : IRequestHandler<GetBlogPostDetailQuery, BlogPostDetailVm>
    {
        private readonly IShowcaseDbContext _context;
        private readonly IMapper _mapper;

        public GetBlogPostDetailQueryHandler(IShowcaseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BlogPostDetailVm> Handle(GetBlogPostDetailQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
