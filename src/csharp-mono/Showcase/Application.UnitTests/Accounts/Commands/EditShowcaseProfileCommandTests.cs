using MediatR;
using Moq;
using Showcase.Application.Accounts.Commands.EditShowcaseProfile;
using Showcase.Application.Common.Exceptions;
using Showcase.Application.Common.Interfaces;
using Showcase.Application.UnitTests.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Showcase.Application.UnitTests.Accounts.Commands
{
    public class EditShowcaseProfileCommandTests : CommandTestBase
    {
        [Fact]
        public async Task GivenRequesterAndTargetProfileIdMismatch_ThrowsNotAllowedException()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var currentUserMock = new Mock<ICurrentUserService>();
            var userManagerMock = new Mock<IUserManager>();

            currentUserMock.Setup(x => x.IsAuthenticated).Returns(true);
            currentUserMock.Setup(x => x.UserId).Returns("HRAH");
            currentUserMock.Setup(x => x.Username).Returns("hrahimy");

            var sut = new EditShowcaseProfileCommandHandler(_context, mediatorMock.Object, currentUserMock.Object, userManagerMock.Object);

            // Act
            var command = new EditShowcaseProfileCommand
            {
                ProfileId = "HAMZA",
                NewProfileDescription = "Dummy Description",
                NewProfileUsername = "dummyusername",
                NewThumbnailFileId = "dummyFileId"
            };

            await Assert.ThrowsAsync<MethodNotAllowedException>(() => sut.Handle(command, CancellationToken.None));
        }

        // TODO: Test to disallow unauthenticated edit operations
    }
}
