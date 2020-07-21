using System.Collections.Generic;

namespace Showcase.Application.Activities.Models
{
    public class ActivitiesListVm
    {
        public IList<ActivityLookupDto> Activities { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
