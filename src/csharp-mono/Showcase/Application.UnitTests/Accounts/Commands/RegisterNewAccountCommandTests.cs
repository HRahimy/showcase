using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using Showcase.Application.Accounts.Commands.RegisterNewAccount;
using Showcase.Application.Common.Exceptions;
using Showcase.Application.Common.Interfaces;
using Showcase.Application.UnitTests.Common;
using Showcase.Domain.Entities;
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
    }
}
