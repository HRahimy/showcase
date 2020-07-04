using Microsoft.EntityFrameworkCore;
using Showcase.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Common.Interfaces
{
    public interface IShowcaseDbContext
    {
        DbSet<DisplayProject> DisplayProjects { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
