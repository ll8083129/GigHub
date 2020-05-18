using System.Collections.Generic;
using GigHub.Core.Models;
using GigHub.Persistence;

namespace GigHub.Core.Repositories
{
    public interface IFollowingRepository
    {
        IEnumerable<ApplicationUser> GetFollowings(string userId);
        bool IsFollowing(string userId, string followeeId);
        void AddFollowing(Following following);
        void RemoveFollowing(Following following);
        Following GetSingleFollowing(string userId, string id);
    }
}