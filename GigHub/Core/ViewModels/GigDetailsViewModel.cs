using GigHub.Core.Models;

namespace GigHub.Core.ViewModels
{
    public class GigDetailsViewModel
    {
        public bool isAttending;
        public bool isFollowing;

        public Gig Gig { get; set; }
    }
}