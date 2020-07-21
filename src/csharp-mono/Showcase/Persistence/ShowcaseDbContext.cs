using Microsoft.EntityFrameworkCore;
using Showcase.Application.Common.Interfaces;
using Showcase.Common;
using Showcase.Domain.Common;
using Showcase.Domain.Entities;
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

        }

        public ShowcaseDbContext(DbContextOptions<ShowcaseDbContext> options, 
            ICurrentUserService currentUserService,
            IDateTime dateTime)
            : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        // TODO: Add configuration classes for all entities
        public DbSet<DisplayProject> DisplayProjects { get; set; }
        public DbSet<Developer> Developers { get; set; }

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
        }
    }
}
