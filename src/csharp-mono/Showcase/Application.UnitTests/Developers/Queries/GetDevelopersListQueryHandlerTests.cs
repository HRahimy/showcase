using AutoMapper;
using Shouldly;
using Showcase.Application.Developers.Queries.GetDevelopersList;
using Showcase.Application.UnitTests.Common;
using Showcase.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Showcase.Application.UnitTests.Developers.Queries
{
    [Collection("QueryCollection")]
    public class GetDevelopersListQueryHandlerTests
    {
        private readonly ShowcaseDbContext _context;
        private readonly IMapper _mapper;

        public GetDevelopersListQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetDevelopersTest()
        {
            var sut = new GetDevelopersListQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetDevelopersListQuery(), CancellationToken.None);

            result.ShouldBeOfType<DevelopersListVm>();

            result.Developers.Count.ShouldBe(3);
        }
    }
}
