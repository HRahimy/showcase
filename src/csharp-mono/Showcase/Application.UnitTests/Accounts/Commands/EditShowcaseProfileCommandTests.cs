using MediatR;
using Moq;
using Showcase.Application.Accounts.Commands.EditShowcaseProfile;
using Showcase.Application.Common.Interfaces;
using Showcase.Application.UnitTests.Common;
using Xunit;

namespace Showcase.Application.UnitTests.Accounts.Commands
{
    public class EditShowcaseProfileCommandTests : CommandTestBase
    {
        [Fact]
        public void GivenRequesterAndTargetProfileIdMismatch_ThrowsNotAuthorizedException()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            // TODO: Figure out how to mock interface and give the mocked interface properties specific values
        }

        // TODO: Test to disallow unauthenticated edit operations
    }
}
