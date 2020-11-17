using MediatR;
using Moq;
using Showcase.Application.Common.Interfaces;
using Showcase.Common;
using Showcase.Persistence;
using System;

namespace Showcase.Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly ShowcaseDbContext _context;
        protected readonly Mock<IMediator> _mediatorMock;
        protected readonly Mock<ICurrentUserService> _currentUserMock;
        protected readonly Mock<IUserManager> _userManagerMock;
        private readonly DateTime _dateTime;
        protected readonly Mock<IDateTime> _dateTimeMock;

        public CommandTestBase()
        {
            _mediatorMock = new Mock<IMediator>();
            _currentUserMock = new Mock<ICurrentUserService>();
            _userManagerMock = new Mock<IUserManager>();
            _dateTime = new DateTime(3001, 1, 1);
            _dateTimeMock = new Mock<IDateTime>();
            _dateTimeMock.Setup(m => m.Now).Returns(_dateTime);

            _context = ShowcaseContextFactory.Create(_currentUserMock.Object, _dateTimeMock.Object);
        }

        public void Dispose()
        {
            ShowcaseContextFactory.Destroy(_context);
        }
    }
}
