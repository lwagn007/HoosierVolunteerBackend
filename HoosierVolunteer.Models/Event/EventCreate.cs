using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoosierVolunteer.Models.Event
{
    public class EventCreate
    {
        public string Start { get; set; } //
        public string End { get; set; } //
        public string Address { get; set; } //
        public string Zip { get; set; } //
        public string City { get; set; } //
        public string State { get; set; } //
        public string Type { get; set; } //
        public string EventTitle { get; set; } //
        public int VolunteersNeeded { get; set; } //
        public string EventDescription { get; set; } //
    }

    public class DateRangeModel
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
