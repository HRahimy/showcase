using MediatR;
using Showcase.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Blogs.Commands.TagBlogPost
{
    public class TagBlogPostCommand : IRequest
    {
        public string BlogPostId { get; set; }
        public List<string> Tags { get; set; }

        public class Handler : IRequestHandler<TagBlogPostCommand>
        {
            private readonly IShowcaseDbContext _context;
            private readonly IMediator _mediator;
            private readonly ICurrentUserService _currentUserService;

            public Handler(IShowcaseDbContext context, IMediator mediator, ICurrentUserService currentUserService)
            {
                _context = context;
                _mediator = mediator;
                _currentUserService = currentUserService;
            }

            public async Task<Unit> Handle(TagBlogPostCommand request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
