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
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Type { get; set; }
        public string EventTitle { get; set; }
        public int VolunteersNeeded { get; set; }
        public string EventDescription { get; set; }
        public int AttendingVolunteers { get; set; }
    }
}
