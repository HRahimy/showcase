using Showcase.Application.Common.Interfaces;
using Showcase.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Showcase.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}
