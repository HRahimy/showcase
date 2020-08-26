using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Showcase.Domain.Entities;

namespace Showcase.Persistence.Configurations
{
    public class BlogPostWatcherConfiguration : IEntityTypeConfiguration<BlogPostWatcher>
    {
        public void Configure(EntityTypeBuilder<BlogPostWatcher> builder)
        {
            builder.HasKey(e => new { e.BlogPostId, e.WatcherId });

            builder.HasOne(e => e.BlogPost)
                .WithMany(e => e.Watchers)
                .HasForeignKey(e => e.BlogPostId);

            builder.HasOne(e => e.Watcher)
                .WithMany(e => e.WatchingBlogPosts)
                .HasForeignKey(e => e.WatcherId);
        }
    }
}
