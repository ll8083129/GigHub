using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHub.Core.Models;
using GigHub.Core.Repositories;

namespace GigHub.Persistence.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        public ApplicationDbContext _context { get; private set; }
        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ApplicationUser> GetFollowings(string userId)
        {
            return _context.Followings
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();
        }

        public bool IsFollowing(string userId, string followeeId)
        {
            return _context.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followeeId);
        }

        public void AddFollowing(Following following)
        {
            _context.Followings.Add(following);
        }

        public void RemoveFollowing(Following following)
        {
            _context.Followings.Remove(following);
        }

        public Following GetSingleFollowing(string userId,string id)
        {
            return _context.Followings
                .SingleOrDefault(f => f.FollowerId == userId && f.FolloweeId == id);
        }
    }
}