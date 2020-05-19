using GigHub.Persistence;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHub.Core;
using GigHub.Core.Dtos;
using GigHub.Core.Models;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FollowingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public HttpResponseMessage Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_unitOfWork.Followings.IsFollowing(userId, dto.FolloweeId))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Following already exist.");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };
            _unitOfWork.Followings.AddFollowing(following);
            _unitOfWork.Complete();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Unfollow(string id)
        {
            var userId = User.Identity.GetUserId();
            
            var following = _unitOfWork.Followings.GetSingleFollowing(userId, id);
            if (following == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Following does not exist.");
            _unitOfWork.Followings.RemoveFollowing(following);
            _unitOfWork.Complete();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
