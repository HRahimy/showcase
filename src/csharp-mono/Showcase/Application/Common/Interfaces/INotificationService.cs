using Showcase.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Showcase.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}
