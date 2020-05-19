using System.Collections.Generic;
using GigHub.Core.Models;
using GigHub.Core.Repositories;
using System.Linq;

namespace GigHub.Persistence.Repositories
{
    class UserNotificationRepository : IUserNotificationRepository
    {
        private readonly ApplicationDbContext _context;

        public UserNotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserNotification> GetNewUserNotificationsFor(string userId)
        {
            return _context.UserNotifications
                .Where(un => un.UserID == userId && un.IsRead == false)
                .ToList();
        }

    }
}