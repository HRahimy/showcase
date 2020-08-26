using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Showcase.Domain.Entities;

namespace Showcase.Persistence.Configurations
{
    public class ProfileTagConfiguration : IEntityTypeConfiguration<ProfileTag>
    {
        public void Configure(EntityTypeBuilder<ProfileTag> builder)
        {
            builder.HasKey(e => new { e.ShowcaseProfileId, e.TagId });

            builder.HasOne(e => e.ShowcaseProfile)
                .WithMany(e => e.Tags)
                .HasForeignKey(e => e.ShowcaseProfileId);

            builder.HasOne(e => e.Tag)
                .WithMany(e => e.ProfileTags)
                .HasForeignKey(e => e.TagId);
        }
    }
}
