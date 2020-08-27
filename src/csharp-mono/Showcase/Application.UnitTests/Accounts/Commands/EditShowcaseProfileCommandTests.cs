using MediatR;
using Moq;
using Shouldly;
using Showcase.Application.Accounts.Commands.EditShowcaseProfile;
using Showcase.Application.Common.Exceptions;
using Showcase.Application.Common.Interfaces;
using Showcase.Application.UnitTests.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Showcase.Application.UnitTests.Accounts.Commands
{
    public class EditShowcaseProfileCommandTests : CommandTestBase
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ICurrentUserService> _currentUserMock;
        private readonly Mock<IUserManager> _userManagerMock;
        private readonly EditShowcaseProfileCommandHandler _sut;

        public EditShowcaseProfileCommandTests()
            : base()
        {
            _mediatorMock = new Mock<IMediator>();
            _currentUserMock = new Mock<ICurrentUserService>();
            _userManagerMock = new Mock<IUserManager>();
            _sut = new EditShowcaseProfileCommandHandler(_context, _mediatorMock.Object, _currentUserMock.Object, _userManagerMock.Object);
        }

        [Fact]
        public async Task GivenRequesterAndTargetProfileIdMismatch_ThrowsForbiddenException()
        {
            // Arrange
            _currentUserMock.Setup(x => x.IsAuthenticated).Returns(true);
            _currentUserMock.Setup(x => x.UserId).Returns("HRAH");
            _currentUserMock.Setup(x => x.Username).Returns("hrahimy");
            var command = new EditShowcaseProfileCommand
            {
                ProfileId = "HAMZA",
                NewProfileDescription = "Dummy Description",
                NewProfileUsername = "dummyusername",
                NewThumbnailFileId = "dummyFileId"
            };

            // Assert
            await Assert.ThrowsAsync<ForbiddenException>(() => _sut.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task GivenRequesterAndTargetProfileIdMismatch_DoesNotModifyProfile()
        {
            // Arrange
            _currentUserMock.Setup(x => x.IsAuthenticated).Returns(true);
            _currentUserMock.Setup(x => x.UserId).Returns("HRAH");
            _currentUserMock.Setup(x => x.Username).Returns("hrahimy");
            var command = new EditShowcaseProfileCommand
            {
                ProfileId = "HAMZA",
                NewProfileDescription = "Dummy Description",
                NewProfileUsername = "dummyusername",
                NewThumbnailFileId = "dummyFileId"
            };

            // Act
            await _sut.Handle(command, CancellationToken.None);

            // Assert
            var profile = await _context.Profiles.FindAsync("HAMZA");
            Assert.False(profile.LastModifiedOn == DateTime.Now);
        }

        [Fact]
        public async Task GivenRequesterNotAuthenticated_ThrowsForbiddenException()
        {
            // Arrange
            var commandMock = new Mock<EditShowcaseProfileCommand>();
            _currentUserMock.Setup(x => x.IsAuthenticated).Returns(false);

            // Assert
            await Assert.ThrowsAsync<ForbiddenException>(() => _sut.Handle(commandMock.Object, CancellationToken.None));
        }

        [Fact]
        public async Task GivenNonUniqueUsername_ThrowsNotAllowedException()
        {
            // Arrange
            var command = new EditShowcaseProfileCommand
            {
                ProfileId = "HAMZA",
                NewProfileDescription = "Dummy Description",
                NewProfileUsername = "hrah12",
                NewThumbnailFileId = "dummyFileId"
            };

            // Assert
            await Assert.ThrowsAsync<MethodNotAllowedException>(() => _sut.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task GivenNonUniqueUsername_DoesNotModifyProfile()
        {
            // Arrange
            var command = new EditShowcaseProfileCommand
            {
                ProfileId = "HAMZA",
                NewProfileDescription = "Dummy Description",
                NewProfileUsername = "hrah12",
                NewThumbnailFileId = "dummyFileId"
            };

            // Act
            await _sut.Handle(command, CancellationToken.None);

            // Assert
            var profile = await _context.Profiles.FindAsync("HAMZA");
            Assert.False(profile.LastModifiedOn == DateTime.Now);
        }
    }
}
