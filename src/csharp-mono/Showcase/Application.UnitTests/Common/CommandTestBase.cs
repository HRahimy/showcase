using Showcase.Persistence;
using System;

namespace Showcase.Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly ShowcaseDbContext _context;

        public CommandTestBase()
        {
            _context = ShowcaseContextFactory.Create();
        }

        public void Dispose()
        {
            ShowcaseContextFactory.Destroy(_context);
        }
    }
}
