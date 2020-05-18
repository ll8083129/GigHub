using System;
using System.Collections.Generic;
using System.Linq;
using GigHub.Core.Models;
using GigHub.Core.Repositories;

namespace GigHub.Persistence.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        public ApplicationDbContext _context { get; set; }
        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _context.Attendances
                            .Where(a => a.AttendeeId == userId && a.Gig.DateTime > DateTime.Now)
                            .ToList();
        }
        public Attendance GetAttendance(string userId, int gigId)
        {
            return _context.Attendances
                    .SingleOrDefault(a => a.GigId == gigId && a.AttendeeId == userId);
        }

        public Following GetFollowing(string userId, string artistId)
        {
            return _context.Followings
                    .SingleOrDefault(f => f.FolloweeId == artistId && f.FollowerId == userId);
        }

        public bool Exist(string userId, int gigId)
        {
            return _context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == gigId);
        }

        public void Add(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
        }

        public void Remove(Attendance attendance)
        {
            _context.Attendances.Remove(attendance);
        }
    }
}