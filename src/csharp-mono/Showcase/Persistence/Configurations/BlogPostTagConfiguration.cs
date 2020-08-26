using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Showcase.Domain.Entities;

namespace Showcase.Persistence.Configurations
{
    public class BlogPostTagConfiguration : IEntityTypeConfiguration<BlogPostTag>
    {
        public void Configure(EntityTypeBuilder<BlogPostTag> builder)
        {
            builder.HasKey(e => new { e.BlogPostId, e.TagId });

            builder.HasOne(e => e.BlogPost)
                .WithMany(e => e.Tags)
                .HasForeignKey(e => e.BlogPostId);

            builder.HasOne(e => e.Tag)
                .WithMany(e => e.BlogPostTags)
                .HasForeignKey(e => e.TagId);
        }
    }
}
