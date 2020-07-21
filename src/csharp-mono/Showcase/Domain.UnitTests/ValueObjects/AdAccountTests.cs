using Showcase.Domain.Exceptions;
using Showcase.Domain.ValueObjects;
using Xunit;

namespace Showcase.Domain.UnitTests.ValueObjects
{
    public class AdAccountTests
    {
        [Fact]
        public void ShouldHaveCorrectDomainAndName()
        {
            var account = AdAccount.For("Showcase\\Hamza");

            Assert.Equal("Showcase", account.Domain);
            Assert.Equal("Hamza", account.Name);
        }

        [Fact]
        public void ToStringReturnsCorrectFormat()
        {
            const string value = "Showcase\\Hamza";

            var account = AdAccount.For(value);

            Assert.Equal(value, account.ToString());
        }

        [Fact]
        public void ImplicitConversionToStringResultsInCorrectString()
        {
            const string value = "Showcase\\Hamza";

            var account = AdAccount.For(value);

            string result = account;

            Assert.Equal(value, result);
        }

        [Fact]
        public void ExplicitConversionFromStringSetsDomainAndName()
        {
            var account = (AdAccount) "Showcase\\Hamza";

            Assert.Equal("Showcase", account.Domain);
            Assert.Equal("Hamza", account.Name);
        }

        [Fact]
        public void ShouldThrowAdAccountInvalidExceptionForInvalidAdAccount()
        {
            Assert.Throws<AdAccountInvalidException>(() => (AdAccount)"ShowcaseHamza");
        }
    }
}
