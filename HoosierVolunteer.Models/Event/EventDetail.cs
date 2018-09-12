using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoosierVolunteer.Models.Event
{
    public class EventDetail
    {
        public Guid CreatorId { get; set; }
        public int EventId { get; set; }
        public DateRangeModel EventRange { get; set; }
        public int Type { get; set; }
        public string EventTitle { get; set; }
        public int VolunteersNeeded { get; set; }
        public string EventDescription { get; set; }
        public int AttendingVolunteers { get; set; }
    }
}
