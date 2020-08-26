using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Showcase.Domain.Entities;

namespace Showcase.Persistence.Configurations
{
    public class BucketFileConfiguration : IEntityTypeConfiguration<BucketFile>
    {
        public void Configure(EntityTypeBuilder<BucketFile> builder)
        {
            builder.HasKey(e => e.BucketFileId);
            builder.Property(e => e.BucketFileId).ValueGeneratedOnAdd();
        }
    }
}
