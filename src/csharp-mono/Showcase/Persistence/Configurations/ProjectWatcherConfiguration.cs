using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Showcase.Domain.Entities;

namespace Showcase.Persistence.Configurations
{
    public class ProjectWatcherConfiguration : IEntityTypeConfiguration<ProjectWatcher>
    {
        public void Configure(EntityTypeBuilder<ProjectWatcher> builder)
        {
            builder.HasKey(e => new { e.DisplayProjectId, e.WatcherId });

            builder.HasOne(e => e.DisplayProject)
                .WithMany(e => e.Watchers)
                .HasForeignKey(e => e.DisplayProjectId);

            builder.HasOne(e => e.Watcher)
                .WithMany(e => e.WatchingProjects)
                .HasForeignKey(e => e.WatcherId);
        }
    }
}
