using Showcase.Domain.Common;

namespace Showcase.Domain.Entities
{
    public class BucketFile : AuditableEntity
    {
        public string BucketFileId { get; set; }
        public string BucketName { get; set; }
        public string OriginalFileName { get; set; }
        public string FilePath { get; set; }
        public bool Uploaded { get; set; }
        // TODO: Create enums using standard types for the below metadata. See here https://cloud.google.com/storage/docs/metadata?_ga=2.147137079.-1682943862.1576792853&_gac=1.238357172.1589199078.EAIaIQobChMI18L25OOr6QIVmYKyCh2YbwP7EAAYASABEgIU_PD_BwE
        public string ContentTypeMetadata { get; set; }
        public string ContentEncodingMetadata { get; set; }
        public string ContentLanguageMetadata { get; set; }
        public string CacheControlMetadata { get; set; }

        public int SizeInBytes { get; set; }

        public string UiTitle { get; set; }
        public string UiDescription { get; set; }

        public bool Archived { get; set; }
    }
}
