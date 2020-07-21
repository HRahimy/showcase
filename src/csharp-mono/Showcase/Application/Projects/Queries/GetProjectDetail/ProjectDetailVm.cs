using Showcase.Domain.Enums;
using System.Collections.Generic;

namespace Showcase.Application.Projects.Queries.GetProjectDetail
{
    public class ProjectDetailVm
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ThumbnailFileId { get; set; }
        public int Watchers { get; set; }
        public List<EPRogrammingLanguage> Languages { get; set; }
        public string ProjectRepositoryLink { get; set; }
        public string HostedAppLink { get; set; }
        public virtual List<TagDto> Tags { get; set; }
    }
}
