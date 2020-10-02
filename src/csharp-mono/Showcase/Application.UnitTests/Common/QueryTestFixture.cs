using AutoMapper;
using Moq;
using Showcase.Application.Common.Interfaces;
using Showcase.Application.Common.Mappings;
using Showcase.Common;
using Showcase.Persistence;
using System;
using Xunit;

namespace Showcase.Application.UnitTests.Common
{
    public class QueryTestFixture : IDisposable
    {
        protected readonly Mock<ICurrentUserService> _currentUserMock;
        private readonly DateTime _dateTime;
        private readonly Mock<IDateTime> _dateTimeMock;

        public QueryTestFixture()
        {
            _dateTime = new DateTime(3001, 1, 1);
            _dateTimeMock = new Mock<IDateTime>();
            _dateTimeMock.Setup(m => m.Now).Returns(_dateTime);

            Context = ShowcaseContextFactory.Create(_currentUserMock.Object, _dateTimeMock.Object);

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public ShowcaseDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public void Dispose()
        {
            ShowcaseContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
