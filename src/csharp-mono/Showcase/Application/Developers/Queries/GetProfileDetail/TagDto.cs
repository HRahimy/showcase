using AutoMapper;
using System;

namespace Showcase.Application.Developers.Queries.GetProfileDetail
{
    public class TagDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime TaggedOn { get; set; }
    }
}
