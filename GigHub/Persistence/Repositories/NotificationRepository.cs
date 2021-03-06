﻿using System.Collections.Generic;
using System.Data.Entity;
using GigHub.Core.Models;
using GigHub.Core.Repositories;
using System.Linq;
namespace GigHub.Persistence.Repositories
{
    class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;

        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Notification> GetNewNotificationsFor(string userId)
        {
            return _context.UserNotifications
                .Where(un => un.UserID == userId && un.IsRead == false)
                .Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .ToList();
        }
    }
}