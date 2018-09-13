using HoosierVolunteer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoosierVolunteer.Services
{
    public class UserService
    {
        private readonly Guid _creatorId;

        public UserService(Guid creatorId)
        {
            _creatorId = creatorId;
        }

        public UserInfoEdit GetUserById(int userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .AspNetUsers
                    .Single(e => e.EventId == eventId && e.CreatorId == _creatorId);
                return
                    new EventDetail
                    {
                        EventId = entity.EventId,
                        EventTitle = entity.EventTitle,
                        EventRange = new DateRangeModel()
                        {
                            Start = entity.EventRange.Start,
                            End = entity.EventRange.End
                        },
                        VolunteersNeeded = entity.VolunteersNeeded,
                        AttendingVolunteers = entity.AttendingVolunteers,
                        EventDescription = entity.EventDescription,
                    };
            }
        }
    }
}
