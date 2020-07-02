using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Common.Interfaces
{
    public interface IShowcaseDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
