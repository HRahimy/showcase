using MediatR;
using Showcase.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Blogs.Commands.AddBlogPost
{
    public class AddBlogPostCommand : IRequest
    {
        public string Title { get; set; }
        public string PostContentString { get; set; }
        public List<string> ProjectIdTags { get; set; }
        public List<string> Tags { get; set; }

        public class Handler : IRequestHandler<AddBlogPostCommand>
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

            public async Task<Unit> Handle(AddBlogPostCommand request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
