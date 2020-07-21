using AutoMapper;
using Showcase.Application.Common.Mappings;
using Showcase.Persistence;
using System;
using Xunit;

namespace Showcase.Application.UnitTests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public QueryTestFixture()
        {
            Context = ShowcaseContextFactory.Create();

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
