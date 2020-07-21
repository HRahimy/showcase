using Showcase.Domain.Enums;
using System.Collections.Generic;

namespace Showcase.Domain.Entities
{
    public class Developer
    {
        public Developer()
        {
            Watchers = new HashSet<Watcher>();
        }
        public string DeveloperId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EPRogrammingLanguage[] Languages { get; set; }
        public ICollection<Watcher> Watchers { get; private set; }
    }
}
