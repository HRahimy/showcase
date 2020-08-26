using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Showcase.Domain.Entities;

namespace Showcase.Persistence.Configurations
{
    public class ActivityNoteConfiguration : IEntityTypeConfiguration<ActivityNote>
    {
        public void Configure(EntityTypeBuilder<ActivityNote> builder)
        {
            builder.HasKey(e => e.ActivityNoteId);
            builder.Property(e => e.ActivityNoteId).ValueGeneratedOnAdd();

            builder.HasOne(e => e.ShowcaseProfile)
                .WithMany(e => e.Notes)
                .HasForeignKey(e => e.ShowcaseProfileId);

            builder.HasOne(e => e.BlogPost)
                .WithMany(e => e.Notes)
                .HasForeignKey(e => e.BlogPostId);

            builder.HasOne(e => e.Project)
                .WithMany(e => e.Notes)
                .HasForeignKey(e => e.ProjectId);
        }
    }
}
