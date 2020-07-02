using Showcase.Domain.Enums;

namespace Showcase.Domain.Entities
{
    public class DisplayProject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SourceCodeUrl { get; set; }
        public EPRogrammingLanguage[] Languages { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
