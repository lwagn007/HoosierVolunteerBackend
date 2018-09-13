using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoosierVolunteer.Models.Event
{
    public class EventListItem
    {
        public int EventId { get; set; }
        public DateRangeModel EventRange { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Type { get; set; }
        public string EventTitle { get; set; }
        public int VolunteersNeeded { get; set; }
    }
}
