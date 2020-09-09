using MediatR;
using Moq;
using Showcase.Application.Accounts.Commands.ResetAccountPassword;
using Showcase.Application.Common.Exceptions;
using Showcase.Application.Common.Interfaces;
using Showcase.Application.UnitTests.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Showcase.Application.UnitTests.Accounts.Commands
{
    public class ResetAccountPasswordCommandTests : CommandTestBase
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ICurrentUserService> _currentUserMock;
        private readonly Mock<IUserManager> _userManagerMock;
        private readonly ResetAccountPasswordCommand.Handler _sut;

        public ResetAccountPasswordCommandTests()
            : base()
        {
            _mediatorMock = new Mock<IMediator>();
            _currentUserMock = new Mock<ICurrentUserService>();
            _userManagerMock = new Mock<IUserManager>();
            _sut = new ResetAccountPasswordCommand.Handler(_context, _mediatorMock.Object, _currentUserMock.Object, _userManagerMock.Object);
        }

        [Fact]
        public async Task GivenUnregisteredUser_ThrowsNotFoundException()
        {
            // Arrange
            _currentUserMock.Setup(m => m.UserId).Returns("NONREG");
            _currentUserMock.Setup(m => m.Email).Returns("nonreguser@email.com");
            var command = new ResetAccountPasswordCommand();

            // Assert
            _userManagerMock.Verify(m => m.ResetPasswordAsync(It.Is<string>(cc => cc == _currentUserMock.Object.Email)), Times.Never);
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(command, CancellationToken.None));
        }
    }
}
