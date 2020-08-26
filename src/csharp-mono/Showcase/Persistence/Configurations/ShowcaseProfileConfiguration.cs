using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Showcase.Domain.Entities;

namespace Showcase.Persistence.Configurations
{
    public class ShowcaseProfileConfiguration : IEntityTypeConfiguration<ShowcaseProfile>
    {
        public void Configure(EntityTypeBuilder<ShowcaseProfile> builder)
        {
            builder.HasKey(e => e.ProfileId);
            builder.Property(e => e.ProfileId).ValueGeneratedOnAdd();

            builder.Property(e => e.Name).IsRequired();
        }
    }
}
