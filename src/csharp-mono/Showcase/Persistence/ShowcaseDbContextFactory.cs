using Microsoft.EntityFrameworkCore;

namespace Showcase.Persistence
{
    public class ShowcaseDbContextFactory : DesignTimeDbContextFactoryBase<ShowcaseDbContext>
    {
        protected override ShowcaseDbContext CreateNewInstance(DbContextOptions<ShowcaseDbContext> options)
        {
            return new ShowcaseDbContext(options);
        }
    }
}
