using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Showcase.Domain.Entities;

namespace Showcase.Persistence.Configurations
{
    public class ProjectTagConfiguration : IEntityTypeConfiguration<ProjectTag>
    {
        public void Configure(EntityTypeBuilder<ProjectTag> builder)
        {
            builder.HasKey(e => new { e.DisplayProjectId, e.TagId });

            builder.HasOne(e => e.DisplayProject)
                .WithMany(e => e.Tags)
                .HasForeignKey(e => e.DisplayProjectId);

            builder.HasOne(e => e.Tag)
                .WithMany(e => e.ProjectTags)
                .HasForeignKey(e => e.TagId);
        }
    }
}
