using MediatR;
using Moq;
using Shouldly;
using Showcase.Application.Accounts.Commands.EditShowcaseProfile;
using Showcase.Application.Common.Exceptions;
using Showcase.Application.Common.Interfaces;
using Showcase.Application.UnitTests.Common;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Showcase.Application.UnitTests.Accounts.Commands
{
    public class EditShowcaseProfileCommandTests : CommandTestBase
    {
        private readonly EditShowcaseProfileCommandHandler _sut;

        public EditShowcaseProfileCommandTests()
            : base()
        {
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
                NewThumbnailFileId = "hamzaProfileImage1"
            };

            // Assert
            await Assert.ThrowsAsync<ForbiddenException>(() => _sut.Handle(command, CancellationToken.None));
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
        public async Task GivenNonUniqueUsername_ThrowsResourceConflictException()
        {
            _currentUserMock.Setup(x => x.IsAuthenticated).Returns(true);
            _currentUserMock.Setup(x => x.UserId).Returns("HAMZA");
            // Arrange
            var command = new EditShowcaseProfileCommand
            {
                ProfileId = "HAMZA",
                NewProfileDescription = "Dummy Description",
                NewProfileUsername = "hrah12",
                NewThumbnailFileId = "hamzaProfileImage1"
            };

            // Assert
            await Assert.ThrowsAsync<ResourceConflictException>(() => _sut.Handle(command, CancellationToken.None));
            var profile = await _context.Profiles.FindAsync("HAMZA");
            Assert.False(profile.LastModifiedOn == DateTime.Now);
        }

        [Fact]
        public async Task GivenNonExistingProfileImage_ThrowsNotFoundException()
        {
            _currentUserMock.Setup(x => x.IsAuthenticated).Returns(true);
            _currentUserMock.Setup(x => x.UserId).Returns("HAMZA");
            var nonExistantFileId = new Guid().ToString();
            var command = new EditShowcaseProfileCommand
            {
                ProfileId = "HAMZA",
                NewProfileDescription = "Dummy description",
                NewProfileUsername = "hrah42",
                NewThumbnailFileId = nonExistantFileId
            };

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task GivenValidRequest_UpdatesTheUser()
        {
            // Arrange
            _currentUserMock.Setup(x => x.IsAuthenticated).Returns(true);
            _currentUserMock.Setup(x => x.UserId).Returns("HAMZA");
            _currentUserMock.Setup(x => x.Username).Returns("hrahimy");
            var command = new EditShowcaseProfileCommand
            {
                ProfileId = "HAMZA",
                NewProfileDescription = "Dummy Description",
                NewProfileUsername = "hrah512",
                NewThumbnailFileId = "hamzaProfileImage1",
                NewProfileName = "Hamza Rahimy"
            };

            // Act
            await _sut.Handle(command, CancellationToken.None);

            // Assert
            _userManagerMock.Verify(m => m.EditUserAsync(It.Is<string>(c => c == _currentUserMock.Object.UserId)
                , It.Is<string>(c => c == command.NewProfileUsername)
                , It.Is<string>(c => c == command.NewProfileName)
                , It.Is<string>(c => c == command.NewProfileDescription))
            , Times.Once);
        }
    }
}
