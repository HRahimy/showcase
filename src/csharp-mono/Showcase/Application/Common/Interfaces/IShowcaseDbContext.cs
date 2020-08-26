using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Showcase.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Showcase.Application.Common.Interfaces
{
    public interface IShowcaseDbContext
    {
        DbSet<ActivityNote> ActivityNotes { get; set; }
        DbSet<BlogPost> BlogPosts { get; set; }
        DbSet<BlogPostTag> BlogPostTags { get; set; }
        DbSet<BlogPostWatcher> BlogPostWatchers { get; set; }
        DbSet<BucketFile> BucketFiles { get; set; }
        DbSet<DisplayProject> DisplayProjects { get; set; }
        DbSet<ProfileTag> ProfileTags { get; set; }
        DbSet<ProfileWatcher> ProfileWatchers { get; set; }
        DbSet<ProjectTag> ProjectTags { get; set; }
        DbSet<ProjectWatcher> ProjectWatchers { get; set; }
        DbSet<ShowcaseProfile> Profiles { get; set; }
        DbSet<Tag> Tags { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
