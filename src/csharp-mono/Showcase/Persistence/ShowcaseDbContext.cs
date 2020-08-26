using Microsoft.EntityFrameworkCore;
using Npgsql;
using Showcase.Application.Common.Interfaces;
using Showcase.Common;
using Showcase.Domain.Common;
using Showcase.Domain.Entities;
using Showcase.Domain.Enums;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Persistence
{
    public class ShowcaseDbContext : DbContext, IShowcaseDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public ShowcaseDbContext(DbContextOptions<ShowcaseDbContext> options)
            : base(options)
        {
            // Map enums
            NpgsqlConnection.GlobalTypeMapper.MapEnum<EActivityType>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<EPRogrammingLanguage>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<ETagType>();
        }

        public ShowcaseDbContext(DbContextOptions<ShowcaseDbContext> options, 
            ICurrentUserService currentUserService,
            IDateTime dateTime)
            : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;

            // Map enums
            NpgsqlConnection.GlobalTypeMapper.MapEnum<EActivityType>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<EPRogrammingLanguage>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<ETagType>();
        }

        public DbSet<ActivityNote> ActivityNotes { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogPostTag> BlogPostTags { get; set; }
        public DbSet<BlogPostWatcher> BlogPostWatchers { get; set; }
        public DbSet<BucketFile> BucketFiles { get; set; }
        public DbSet<DisplayProject> DisplayProjects { get; set; }
        public DbSet<ProfileTag> ProfileTags { get; set; }
        public DbSet<ProfileWatcher> ProfileWatchers { get; set; }
        public DbSet<ProjectTag> ProjectTags { get; set; }
        public DbSet<ProjectWatcher> ProjectWatchers { get; set; }
        public DbSet<ShowcaseProfile> Profiles { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.CreatedOn = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModifiedOn = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShowcaseDbContext).Assembly);

            modelBuilder.HasPostgresEnum<EActivityType>();
            modelBuilder.HasPostgresEnum<EPRogrammingLanguage>();
            modelBuilder.HasPostgresEnum<ETagType>();
        }
    }
}
