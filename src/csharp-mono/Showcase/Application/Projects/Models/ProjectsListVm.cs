using System.Collections.Generic;

namespace Showcase.Application.Projects.Models
{
    public class ProjectsListVm
    {
        public List<ProjectLookupDto> Projects { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }

    }
}
