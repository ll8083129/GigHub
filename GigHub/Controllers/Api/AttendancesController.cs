
using Microsoft.AspNet.Identity;
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
    public class AttendancesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public AttendancesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public HttpResponseMessage Attend(AttendanceDto gig)
        {
            var userId = User.Identity.GetUserId();
            var exists = _unitOfWork.Attendances.Exist(userId, gig.GigId);
            if (exists)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Attendance already exist.");

            var attendance = new Attendance
            {
                GigId = gig.GigId,
                AttendeeId = userId
            };

            _unitOfWork.Attendances.Add(attendance);
            _unitOfWork.Complete();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpDelete]
        public HttpResponseMessage CancelAttend(int id)
        {
            var userId = User.Identity.GetUserId();

            var attendance = _unitOfWork.Attendances.GetAttendance(userId, id);

            if (attendance == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Attendance does not exist.");

            _unitOfWork.Attendances
                .Remove(attendance);
            _unitOfWork.Complete();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
