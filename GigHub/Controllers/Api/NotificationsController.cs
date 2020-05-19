using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHub.Core;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using GigHub.Persistence;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<NotificationDto> GetNewNotification()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _unitOfWork.Notifications.GetNewNotificationsFor(userId);
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationUser, UserDto>();
                cfg.CreateMap<Gig, GigDto>();
                cfg.CreateMap<Notification, NotificationDto>();
            });
            var mapper = config.CreateMapper();



            return notifications.Select(mapper.Map<Notification, NotificationDto>);
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();
            _unitOfWork.UserNotifications.GetNewUserNotificationsFor(userId);
            var notifications = _unitOfWork.UserNotifications.GetNewUserNotificationsFor(userId);

            foreach (var notification  in notifications)
            {
                notification.Read();
            }
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
