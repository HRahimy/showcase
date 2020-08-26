using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Showcase.Domain.Entities;

namespace Showcase.Persistence.Configurations
{
    public class ProfileWatcherConfiguration : IEntityTypeConfiguration<ProfileWatcher>
    {
        public void Configure(EntityTypeBuilder<ProfileWatcher> builder)
        {
            builder.HasKey(e => new { e.WatcherId, e.WatcheeId });

            builder.HasOne(e => e.Watcher)
                .WithMany(e => e.Watchers)
                .HasForeignKey(e => e.WatcherId);

            builder.HasOne(e => e.Watchee)
                .WithMany(e => e.WatchingProfiles)
                .HasForeignKey(e => e.WatcheeId);
        }
    }
}
