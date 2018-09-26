using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoosierVolunteer.Models
{
    public class Events
    {
        [Key]
        public int EventId { get; set; }

        public Guid CreatorId { get; set; }
        public DateRange EventRange { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Type { get; set; }
        public string EventTitle { get; set; }
        public int VolunteersNeeded { get; set; }
        public int AttendingVolunteers { get; set; }
        public string EventDescription { get; set; }
        public DateTime Created { get; set; }
    }

    public class DateRange
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public bool Equals(DateTime date)
        {
            if (date == null)
            {
                return false;
            }
            
            if ((Start <= date) && (date <= End))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
