using MediatR;

namespace Showcase.Application.Accounts.Commands.EditShowcaseProfile
{
    public class EditShowcaseProfileCommand : IRequest
    {
        public string ProfileId { get; set; }
        public string NewProfileName { get; set; }
        public string NewProfileUsername { get; set; }
        public string NewProfileDescription { get; set; }
        public string NewThumbnailFileId { get; set; }
    }
}
