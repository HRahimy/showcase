using MediatR;
using Microsoft.EntityFrameworkCore;
using Showcase.Application.Common.Exceptions;
using Showcase.Application.Common.Interfaces;
using Showcase.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Accounts.Commands.EditShowcaseProfile
{
    public class EditShowcaseProfileCommandHandler : IRequestHandler<EditShowcaseProfileCommand>
    {
        private readonly IShowcaseDbContext _context;
        private readonly IMediator _mediator;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserManager _userManager;

        public EditShowcaseProfileCommandHandler(IShowcaseDbContext context, IMediator mediator, ICurrentUserService currentUserService, IUserManager userManager)
        {
            _context = context;
            _mediator = mediator;
            _currentUserService = currentUserService;
            _userManager = userManager;
        }
        public async Task<Unit> Handle(EditShowcaseProfileCommand request, CancellationToken cancellationToken)
        {
            if (!_currentUserService.IsAuthenticated)
                throw new ForbiddenException(nameof(ShowcaseProfile), request.ProfileId, "Must be authenticated to run this command");

            var profile = await _context.Profiles.FindAsync(request.ProfileId);
            var image = await _context.BucketFiles.FindAsync(request.NewThumbnailFileId);

            if (profile == null)
                throw new NotFoundException(nameof(ShowcaseProfile), request.ProfileId);
            else if (profile.ProfileId != _currentUserService.UserId)
                throw new ForbiddenException(nameof(ShowcaseProfile), profile.ProfileId, "Authenticated user not the same as target user");

            if (image == null)
                throw new NotFoundException(nameof(BucketFile), request.NewThumbnailFileId);

            if (await _context.Profiles.Where(e => e.Username == request.NewProfileUsername).AnyAsync())
                throw new ResourceConflictException(nameof(ShowcaseProfile), request.ProfileId, "Username already exists");

            try
            {
                await _userManager.EditUserAsync(_currentUserService.UserId, request.NewProfileUsername, request.NewProfileName, request.NewProfileDescription);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            profile.Name = request.NewProfileName;
            profile.Username = request.NewProfileUsername;
            profile.ProfilePictureId = request.NewThumbnailFileId;
            profile.Description = request.NewProfileDescription;

            await _context.SaveChangesAsync(cancellationToken);


            return Unit.Value;
        }
    }
}
