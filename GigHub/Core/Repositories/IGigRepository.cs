using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IGigRepository
    {
        Gig GetGigWithAttendees(int gigId);
        IEnumerable<Gig> GetGigsWithGenre(string userId);
        IEnumerable<Gig> GetGigUserAttending(string userId);
        Gig GetSingleGig(int gigId);
        void AddGig(Gig gig);
        IEnumerable<Gig> GetFutureGigs();
    }
}