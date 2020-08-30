using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using Showcase.Application.Accounts.Commands.RegisterNewAccount;
using Showcase.Application.Common.Exceptions;
using Showcase.Application.Common.Interfaces;
using Showcase.Application.Common.Models;
using Showcase.Application.UnitTests.Common;
using Showcase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Showcase.Application.UnitTests.Accounts.Commands
{
    public class RegisterNewAccountCommandTests : CommandTestBase
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ICurrentUserService> _currentUserMock;
        private readonly Mock<IUserManager> _userManagerMock;
        private readonly RegisterNewAccountCommand.Handler _sut;

        public RegisterNewAccountCommandTests()
            : base()
        {
            _mediatorMock = new Mock<IMediator>();
            _currentUserMock = new Mock<ICurrentUserService>();
            _userManagerMock = new Mock<IUserManager>();
            _sut = new RegisterNewAccountCommand.Handler(_context, _mediatorMock.Object, _currentUserMock.Object, _userManagerMock.Object);
        }

        [Fact]
        public async Task GivenNonUniqueUsername_ThrowsResourceConflictException()
        {
            // Arrange
            var command = new RegisterNewAccountCommand
            {
                PublicProfileUsername = "hrah12",
                PublicProfileDescription = "dummy description"
            };

            // Assert
            await Assert.ThrowsAsync<ResourceConflictException>(() => _sut.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task GivenNonUniqueEmail_ThrowsResourceConflictException()
        {
            // Arrange
            _currentUserMock.Setup(m => m.Email).Returns("hamza@email.com");
            var command = new RegisterNewAccountCommand();

            // Assert
            await Assert.ThrowsAsync<ResourceConflictException>(() => _sut.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task GivenNonUniqueId_ThrowsResourceConflictException()
        {
            // Arrange
            _currentUserMock.Setup(m => m.UserId).Returns("HAMZA");
            var command = new RegisterNewAccountCommand();

            // Assert
            await Assert.ThrowsAsync<ResourceConflictException>(() => _sut.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task GivenNonUniqueUsername_ProfileIsntAdded()
        {
            // Arrange
            var command = new RegisterNewAccountCommand
            {
                PublicProfileUsername = "hrah12",
                PublicProfileDescription = "dummy description"
            };

            // Act
            await _sut.Handle(command, CancellationToken.None);

            // Assert
            var profiles = await _context.Profiles
                .Where(e => e.Username == command.PublicProfileUsername)
                .ToListAsync();
            Assert.Single<ShowcaseProfile>(profiles);
        }

        [Fact]
        public async Task GivenNonUniqueEmail_ProfileIsntAdded()
        {
            // Arrange
            _currentUserMock.Setup(m => m.Email).Returns("hamza@email.com");
            var command = new RegisterNewAccountCommand();

            // Act
            await _sut.Handle(command, CancellationToken.None);

            // Assert
            var profiles = await _context.Profiles
                .Where(e => e.Email == _currentUserMock.Object.Email)
                .ToListAsync();
            Assert.Single<ShowcaseProfile>(profiles);
        }

        [Fact]
        public async Task GivenNonUniqueId_ProfileIsntAdded()
        {
            // Arrange
            _currentUserMock.Setup(m => m.UserId).Returns("HAMZA");
            var command = new RegisterNewAccountCommand();

            // Act
            await _sut.Handle(command, CancellationToken.None);

            // Assert
            var profiles = await _context.Profiles
                .Where(e => e.ProfileId == _currentUserMock.Object.UserId)
                .ToListAsync();
            Assert.Single<ShowcaseProfile>(profiles);
        }

        // TODO: Test to verify that userId, userName, and email supplied in currentUserService is used to set values for profile in database
        [Fact]
        public async Task GivenValidRequest_ProfileIsAdded()
        {
            // Arrange
            _currentUserMock.Setup(m => m.UserId).Returns("NEWPROFILE");
            _currentUserMock.Setup(m => m.Username).Returns("New User");
            _currentUserMock.Setup(m => m.Email).Returns("newuser@email.com");
            var command = new RegisterNewAccountCommand
            {
                PublicProfileUsername = "newProfileGuy",
                PublicProfileDescription = "New profile guy's description"
            };

            // Act
            await _sut.Handle(command, CancellationToken.None);

            // Assert
            var profile = await _context.Profiles.FindAsync(_currentUserMock.Object.UserId);

            Assert.NotNull(profile);

            var notes = await _context.ActivityNotes.Where(e => e.ShowcaseProfileId == _currentUserMock.Object.UserId && e.CreatedOn == profile.CreatedOn).ToListAsync();
            Assert.True(notes.Count >= 1);

            Assert.Equal(_currentUserMock.Object.Username, profile.Name);
            Assert.Equal(_currentUserMock.Object.Email, profile.Email);
            Assert.Equal(_currentUserMock.Object.UserId, profile.ProfileId);

            Assert.Equal(command.PublicProfileUsername, profile.Username);
            Assert.Equal(profile.CreatedOn, DateTime.Now);
            Assert.Equal(profile.CreatedBy, _currentUserMock.Object.UserId);

            _userManagerMock.Verify(m => m.EditUserAsync(It.Is<string>(c => c == _currentUserMock.Object.UserId), It.Is<string>(c => c == command.PublicProfileUsername)
                , It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()
                , It.IsAny<Dictionary<string, object>>(), It.IsAny<Dictionary<string, object>>()
                , It.IsAny<bool>())
            , Times.Once);
        }

        [Fact]
        public async Task GivenUnverifiedEmail_ThrowsConflictException()
        {
            // Arrange
            _currentUserMock.Setup(m => m.UserId).Returns("NEWPROFILE");
            _currentUserMock.Setup(m => m.Username).Returns("New User");
            _currentUserMock.Setup(m => m.Email).Returns("newuser@email.com");
            _userManagerMock.Setup(m => m.GetUserAsync(_currentUserMock.Object.UserId)).ReturnsAsync((Result.Success(), new Auth0User { EmailVerified = false}));
            var command = new RegisterNewAccountCommand
            {
                PublicProfileUsername = "newProfileGuy",
                PublicProfileDescription = "New profile guy's description"
            };

            // Act
            await _sut.Handle(command, CancellationToken.None);

            // Assert
            _userManagerMock.Verify(m => m.GetUserAsync(It.Is<string>(c => c == _currentUserMock.Object.UserId)), Times.Once);
            _userManagerMock.Verify(m => m.EditUserAsync(It.Is<string>(c => c == _currentUserMock.Object.UserId), It.Is<string>(c => c == command.PublicProfileUsername)
                , It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()
                , It.IsAny<Dictionary<string, object>>(), It.IsAny<Dictionary<string, object>>()
                , It.IsAny<bool>())
            , Times.Never);

            await Assert.ThrowsAsync<ResourceConflictException>(() => _sut.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task GivenUnverifiedEmail_DoesNotAddProfile()
        {
            // Arrange
            _currentUserMock.Setup(m => m.UserId).Returns("NEWPROFILE");
            _currentUserMock.Setup(m => m.Username).Returns("New User");
            _currentUserMock.Setup(m => m.Email).Returns("newuser@email.com");
            _userManagerMock.Setup(m => m.GetUserAsync(_currentUserMock.Object.UserId)).ReturnsAsync((Result.Success(), new Auth0User { EmailVerified = false }));
            var command = new RegisterNewAccountCommand
            {
                PublicProfileUsername = "newProfileGuy",
                PublicProfileDescription = "New profile guy's description"
            };

            // Act
            await _sut.Handle(command, CancellationToken.None);

            // Assert
            var profile = await _context.Profiles.FindAsync(_currentUserMock.Object.UserId);
            Assert.Null(profile);
        }
    }
}
