using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Core.Models
{
    public class UserNotification
    {
        public string UserID { get; private set; }

        public int NotificationId { get; private set; }

        public ApplicationUser User { get; private set; }
        public Notification Notification { get; private set; }

        public bool IsRead { get; private set; }
        protected UserNotification()
        {
        }
        public UserNotification(ApplicationUser user, Notification notification)
        {
            if (user == null)
            {
                throw new ArgumentException("user");
            };
            if (notification == null)
            {
                throw new ArgumentException("notification");
            };
            User = user;
            Notification = notification;
        }

        internal void Read()
        {
            IsRead = true;
        }
    }
}