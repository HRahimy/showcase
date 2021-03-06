﻿using MediatR;
using Showcase.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Blogs.Commands.PublishBlogPost
{
    public class PublishBlogPostCommand : IRequest
    {
        public string BlogPostId { get; set; }

        public class Handler : IRequestHandler<PublishBlogPostCommand>
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
            public async Task<Unit> Handle(PublishBlogPostCommand request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
