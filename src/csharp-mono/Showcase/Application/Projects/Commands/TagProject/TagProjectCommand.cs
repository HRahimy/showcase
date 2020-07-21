﻿using MediatR;
using Showcase.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Projects.Commands.TagProject
{
    public class TagProjectCommand : IRequest
    {
        public string ProjectId { get; set; }
        public string TagName { get; set; }

        public class Handler : IRequestHandler<TagProjectCommand>
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

            public async Task<Unit> Handle(TagProjectCommand request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
