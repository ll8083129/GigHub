using System.Collections.Generic;
using GigHub.Core.Models;
using GigHub.Persistence;

namespace GigHub.Core.Repositories
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetFutureAttendances(string userId);
        Attendance GetAttendance(string userId, int gigId);
        Following GetFollowing(string userId, string artistId);
        bool Exist(string userId, int gigId);
        void Add(Attendance attendance);
        void Remove(Attendance attendance);
    }
}