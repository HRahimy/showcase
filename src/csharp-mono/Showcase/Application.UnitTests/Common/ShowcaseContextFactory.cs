using Microsoft.EntityFrameworkCore;
using Showcase.Domain.Entities;
using Showcase.Domain.Enums;
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

            context.Developers.AddRange(new[]
            {
                new Developer { DeveloperId = "HAMZA", Name = "Hamza Rahimy" },
                new Developer { DeveloperId = "JASON", Name = "Jason Taylor" },
                new Developer {DeveloperId = "ELON", Name = "Elon Musk"}
            });

            context.DisplayProjects.Add(new DisplayProject
            {
                Id = "SHOWCASE",
                Name = "Showcase Portfolios",
                Languages = new EPRogrammingLanguage[] {
                    EPRogrammingLanguage.CSharp,
                    EPRogrammingLanguage.JavaScript
                },
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
