using AutoMapper;
using Shouldly;
using Showcase.Application.Common.Exceptions;
using Showcase.Application.Developers.Queries.GetProfileDetail;
using Showcase.Application.UnitTests.Common;
using Showcase.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Showcase.Application.UnitTests.Developers.Queries
{
    [Collection("QueryCollection")]
    public class GetDeveloperDetailQueryHandlerTests
    {
        private readonly ShowcaseDbContext _context;
        private readonly IMapper _mapper;

        public GetDeveloperDetailQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetDeveloperDetail()
        {
            var sut = new GetProfileDetailQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetProfileDetailQuery { ProfileId = "HAMZA" }, CancellationToken.None);

            result.ShouldBeOfType<DeveloperProfileDto>();
            result.Id.ShouldBe("HAMZA");
        }

        [Fact]
        public async Task Handle_GivenInvalidId_ShouldThrowNotFoundException()
        {
            var invalidId = "ASDFE534E24ER";

            var query = new GetProfileDetailQuery { ProfileId = invalidId };

            var sut = new GetProfileDetailQueryHandler(_context, _mapper);

            await Assert.ThrowsAsync<NotFoundException>(() => sut.Handle(query, CancellationToken.None));
        }
    }
}
