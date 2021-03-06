﻿using AutoMapper;
using Shouldly;
using Showcase.Application.Developers.Queries.GetDevelopersList;
using Showcase.Application.Developers.Queries.GetProfileDetail;
using Showcase.Domain.Entities;
using Xunit;

namespace Showcase.Application.UnitTests.Mappings
{
    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            _configuration = fixture.ConfigurationProvider;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Fact]
        public void ShouldMapDeveloperToDeveloperLookupDto()
        {
            var entity = new ShowcaseProfile();

            var result = _mapper.Map<DeveloperLookupDto>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<DeveloperLookupDto>();
        }

        [Fact]
        public void ShouldMapDeveloperToDeveloperProfileVm()
        {
            var entity = new ShowcaseProfile();

            var result = _mapper.Map<DeveloperProfileDto>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<DeveloperProfileDto>();
        }
    }
}
