using Microsoft.EntityFrameworkCore;
using Showcase.Domain.Entities;
using Showcase.Persistence;
using System;

namespace Showcase.Application.UnitTests.Common
{
    public class ShowcaseContextFactory
    {
        public static ShowcaseDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ShowcaseDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ShowcaseDbContext(options);

            context.Database.EnsureCreated();

            context.Profiles.AddRange(new[]
            {
                new ShowcaseProfile { ProfileId = "HAMZA", Username = "hrah12", Email= "hamza@email.com", Name = "Hamza Rahimy" },
                new ShowcaseProfile { ProfileId = "JASON", Username = "jason13", Email = "jason@email.com", Name = "Jason Taylor" },
                new ShowcaseProfile {ProfileId = "ELON", Username = "elon14", Email = "elon@email.com", Name = "Elon Musk"}
            });

            context.DisplayProjects.Add(new DisplayProject
            {
                Id = "SHOWCASE",
                Name = "Showcase Portfolios",
                SourceCodeUrl = "https://github.com/HRahimy/showcase"
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(ShowcaseDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
